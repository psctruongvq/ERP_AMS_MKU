using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using System.IO;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Shared;
using Infragistics.Win;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace PSC_ERP
{
    //Thành nè
    public partial class frmHopDongDichVu : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        DoiTacList _DoiTacList;
        DoiTac _DoiTac;
        BoPhanList _BoPhanList = BoPhanList.GetBoPhanListBy_All();

        HopDongMuaBan _HopDongMuaBan;
        HopDongMuaBanList _HopDongMuaBanList = HopDongMuaBanList.NewHopDongMuaBanList();
        OpenFileDialog _OpenFileDialog;
        DonViTinhList _DonViTinhList;
        DonViTinhList _DonViTinhKhoiLuongList;
        CT_HopDongDichVuList _CTHopDongDichVuList;
        ChiTietThanhToanList _chiTietThanhToan;
        string _Path;
        HamDungChung t = new HamDungChung();
        private bool _muaBan;
        Util util = new Util();
        int flag = 0;
        bool bTrucTiep = false;

        public bool _OK = false;

        private byte _tinhTrang = 0;

        #endregion

        #region New
        private void SetGiaTriMacDinhHopDong()
        {
            _HopDongMuaBan.MaNguoiKy = 14277;//Người đại diện hợp đồng mặc định là "Nguyễn Quý Hòa"
            cbu_ThueSuat.Value = 10;
            _HopDongMuaBan.ThueSuat = 10;
            _HopDongMuaBan.TinhTrang = _tinhTrang;
        }

        private bool SetSoHopDongTrongDai()
        {
            if ((!_HopDongMuaBan.HDTrongNgoaiDai) && _HopDongMuaBan.TinhTrang==1)//Là HĐ trong đài
            {
                if(_HopDongMuaBan.IsNew)
                {
                    //_HopDongMuaBan.SoHopDong = HopDongMuaBan.SetSoHopDongTrongDai(_HopDongMuaBan.NgayLap);
                    txtu_SoHopDong.Text = HopDongMuaBan.SetSoHopDongTrongDai(_HopDongMuaBan.NgayLap);

                }
            }
            else if(_HopDongMuaBan.HDTrongNgoaiDai)
            {
                if (txtu_SoHopDong.Text.Trim() == "")
                {
                    //MessageBox.Show("Đây là Hợp đồng ngoài đài, Vui lòng nhập Số hợp đồng!");
                    MessageBox.Show("Vui lòng nhập Số hợp đồng!");
                    txtu_SoHopDong.Focus();
                    return false;
                }
            }
            return true;
        }

        private bool SetSoThamDinhHopDong()
        {
            if ((!_HopDongMuaBan.HDTrongNgoaiDai) && _HopDongMuaBan.TinhTrang == 1)//Là HĐ trong đài
            {
                if (_HopDongMuaBan.IsNew)
                {
                    //_HopDongMuaBan.SoThamDinh = HopDongMuaBan.SetSoThamDinhHopDong(_HopDongMuaBan.NgayLap);
                    txtu_SoThamDinh.Text = HopDongMuaBan.SetSoThamDinhHopDong(_HopDongMuaBan.NgayLap);

                }
            }
            //else if (_HopDongMuaBan.HDTrongNgoaiDai)
            //{
            //    if (txtu_SoThamDinh.Text.Trim() == "")
            //    {
            //        MessageBox.Show("Đây là Hợp đồng ngoài đài, Vui lòng nhập Số thẩm định!");
            //        txtu_SoThamDinh.Focus();
            //        return false;
            //    }
            //}
            return true;
        }

        private string SetGhiChu()
        {
            if (!_HopDongMuaBan.HDTrongNgoaiDai)
            {
                return " - Đang nhập Hợp đồng trong đài...";
            }
            else
            {
                return " - Đang nhập Hợp đồng ngoài đài...";
            }

        }

        private bool KiemTraSoHopDongHopLe()
        {
            string sohopdong=txtu_SoHopDong.Text.Trim() ;
            if ((!_HopDongMuaBan.HDTrongNgoaiDai) && _HopDongMuaBan.TinhTrang==1 )//Là HĐ trong đài
            {
                int soTTHD;
                if (!int.TryParse(sohopdong.Substring(0, 3), out soTTHD))
                {
                    MessageBox.Show("Số hợp đồng không hợp lệ! 3 ký tự đầu phải là số!");
                    txtu_SoHopDong.Focus();
                    return false;
                }

            }
            else//là HĐ ngoài đài
            {
                if (sohopdong.Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập vào Số hợp đồng!");
                    txtu_SoHopDong.Focus();
                    return false;
                }
 
            }
            if (HopDongMuaBan.KiemTraTrungSoHopDong(_HopDongMuaBan.MaHopDong, sohopdong))
            {
                MessageBox.Show("Trùng số hợp đồng! Vui lòng chỉnh lại!");
                txtu_SoHopDong.Focus();
                return false;
            }

            return true;
        }

        private bool KiemTraSoThamDinhHopDongHopLe()
        {
            string sothamdinh = txtu_SoThamDinh.Text.Trim();
            if ((!_HopDongMuaBan.HDTrongNgoaiDai) && _HopDongMuaBan.TinhTrang==1)//Là HĐ trong đài
            {
                int soTTTD;
                if (!int.TryParse(sothamdinh.Substring(0, 3), out soTTTD))
                {
                    MessageBox.Show("Số thẩm định không hợp lệ! 3 ký tự đầu phải là số!");
                    txtu_SoThamDinh.Focus();
                    return false;
                }

            }
            //else//là HĐ ngoài đài
            //{
            //    if (sothamdinh.Length == 0)
            //    {
            //        MessageBox.Show("Vui lòng nhập vào Số thẩm định!");
            //        txtu_SoThamDinh.Focus();
            //        return false;
            //    }

            //}
            if (sothamdinh.Length > 0)
            {
                if (HopDongMuaBan.KiemTraTrungSoThamDinhHopDong(_HopDongMuaBan.MaHopDong, sothamdinh))
                {
                    MessageBox.Show("Trùng số thẩm định! Vui lòng chỉnh lại!");
                    txtu_SoThamDinh.Focus();
                    return false;
                }
            }

            return true;
        }

        private void KiemTraKhoaHDTrongNgoaiDai()
        {
            if (!_HopDongMuaBan.HDTrongNgoaiDai)
                cb_LoaiHD.Enabled = false;
        }

        private bool KiemTraChiTietThanhToan()
        {
            foreach (ChiTietThanhToan ctthanhtoan in _HopDongMuaBan.chiTietThanhToan)
            {
                if (ctthanhtoan.NgayThanhToan == null)
                {
                    MessageBox.Show("Nhập vào Ngày thanh toán");
                    return false;
                }
                else if (ctthanhtoan.PhanTramThanhToan == 0)
                {
                    MessageBox.Show("Nhập vào % thanh toán");
                    return false;
                }
                else if (ctthanhtoan.SoTien == 0)
                {
                    MessageBox.Show("Nhập vào Số tiền thanh toán");
                    return false;
                }

            }
            return true;
        }

        private int TinhSoNgayNghi_TuNgayDenNgay(DateTime tuNgay, DateTime denNgay)
        {
            int soNgay=0;

            TimeSpan diff = denNgay - tuNgay;
            int days = diff.Days;
            for (int i = 0; i <= days; i++)
            {
                DateTime testDate=tuNgay.AddDays(i);
                if(testDate.DayOfWeek==DayOfWeek.Saturday||testDate.DayOfWeek==DayOfWeek.Sunday||NgayHoliday.LaNgayLe(testDate.Date))
                {
                    soNgay+=1;
                }
                
            }
            return soNgay;
        }

        private int TinhSoNgayNghi_TuNgaySoNgay(DateTime tuNgay, int soNgay)
        {
            int soNgayNghi = 0;
            DateTime denNgayTemp=tuNgay.AddDays(soNgay);

            int soNgayTemp = TinhSoNgayNghi_TuNgayDenNgay(tuNgay, denNgayTemp);
            DateTime denNgay=tuNgay.AddDays(soNgayTemp+soNgay);
            soNgayNghi = TinhSoNgayNghi_TuNgayDenNgay(tuNgay, denNgay);
            return soNgayNghi;
        }

        private int TinhSoNgay(DateTime tuNgay, DateTime denNgay)
        {
            int soNgay = 0;
            TimeSpan diff = denNgay - tuNgay;
            int days = diff.Days;
            soNgay = days - TinhSoNgayNghi_TuNgayDenNgay(tuNgay, denNgay);
            
            return soNgay;
        }

        private DateTime TinhDenNgay(DateTime tuNgay, int soNgay,bool coTruNgayLe)
        {
            if (coTruNgayLe)
            {
                return tuNgay.AddDays(TinhSoNgayNghi_TuNgaySoNgay(tuNgay, soNgay)+soNgay);
            }
            else
            {
                return tuNgay.AddDays(soNgay);
            }

        }
        #endregion//New

        #region Loads
        public frmHopDongDichVu()
        {
            InitializeComponent();
            Them();
            KhoiTao();
            bTrucTiep = true;
        }

        public frmHopDongDichVu(bool muaBan)
        {
            InitializeComponent();
            Them(muaBan);
            KhoiTao();
            bTrucTiep = true;
        }

        public frmHopDongDichVu(HopDongMuaBan HopDongMuaBan)
        {
            InitializeComponent();
            KhoiTao(HopDongMuaBan);
        }
        public frmHopDongDichVu(long _maDoiTac, DateTime NgayLap, int LoaiHopDong)//M
        {
            InitializeComponent();
            Them();
            KhoiTao();
            bTrucTiep = true;
            _HopDongMuaBan.MaDoiTac = _maDoiTac;//M
            _HopDongMuaBan.NgayLap = NgayLap;//M
            _HopDongMuaBan.MaLoaiHopDong = LoaiHopDong;//M
            cmbeu_LoaiHopDong.ReadOnly = true;//M
            grdLU_KhachHang.Properties.ReadOnly = true;

        }

        
        

        #region ultracmbHangHoa_InitializeLayout
        private void ultracmbHangHoa_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            e.Layout.Override.HeaderAppearance.BackColor = Color.White;

            //e.DisplayLayout.Override.HeaderAppearance.BackColor = Color.White;
            e.Layout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            //this.cmbu_HangHoa.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in e.Layout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
            e.Layout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            e.Layout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Hàng Hóa";
            e.Layout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;

            e.Layout.Bands[0].Columns["TenHangHoa"].Hidden = false;
            e.Layout.Bands[0].Columns["TenHangHoa"].Header.Caption = "Tên Hàng Hóa";
            e.Layout.Bands[0].Columns["TenHangHoa"].Width = 100;
            e.Layout.Bands[0].Columns["TenHangHoa"].Header.VisiblePosition = 1;

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

            cmbu_NguoiLienLac.DisplayLayout.Override.HeaderAppearance.BackColor = Color.White;
            this.cmbu_NguoiLienLac.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.cmbu_NguoiLienLac.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }

        }
        #endregion

        #region ultracmbDiaChiGH_InitializeLayout
        
        #endregion

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
            this.cmbu_LoaiTien.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            foreach (UltraGridColumn col in this.cmbu_LoaiTien.DisplayLayout.Bands[0].Columns)
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
            this.cmbu_NguoiDaiDien.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
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
            cmbu_NguoiDaiDien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 350;
            cmbu_NguoiDaiDien.DisplayLayout.Bands[0].Columns["TenChucVu"].Hidden = false;
            cmbu_NguoiDaiDien.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Chức Vụ";
            cmbu_NguoiDaiDien.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.VisiblePosition = 3;

            FilterCombo fil = new FilterCombo(cmbu_NguoiDaiDien, "TenNhanVien");
        }
        #endregion
       

        #region Process
        private void KhoiTao()
        {
            

            tenNhanVienListBindingSource.DataSource = TenNhanVienList.GetTenNhanVienList();
            NguoiDaiDienList_bindingSource.DataSource = TenNhanVienList.GetTenNhanVienList_NguoiDaiDienHopDong();


            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();

            loaiTienListBindingSource1.DataSource = LoaiTienList.GetLoaiTienList();

            loaiHopDongListBindingSource.DataSource = LoaiHopDongList.GetLoaiHopDongList();

            _DoiTacList = DoiTacList.GetDoiTacList("", 0);         
            doiTacListBindingSource.DataSource = _DoiTacList;

            
            BoPhan _BoPhan = BoPhan.NewBoPhan(0, "Không Chọn");
            _BoPhanList.Insert(0, _BoPhan);
            boPhanListBindingSource.DataSource = _BoPhanList;

            DonViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
        }

        private void Them(bool muaBan)
        {
            _HopDongMuaBan = _HopDongMuaBanList.AddNew();
            SetGiaTriMacDinhHopDong();
            HopDongMuaBanBindingSource.DataSource = _HopDongMuaBan;
            CT_HopDongDichVu_bindingSource.DataSource = _HopDongMuaBan.CT_HopDongDichVu;
            ChiTietThanhToanbd.DataSource = _HopDongMuaBan.chiTietThanhToan;

            _muaBan = muaBan;
            _HopDongMuaBan.MuaBan = _muaBan;
        }

        private void Them()
        {
            _HopDongMuaBan = _HopDongMuaBanList.AddNew();
            SetGiaTriMacDinhHopDong();
            HopDongMuaBanBindingSource.DataSource = _HopDongMuaBan;
            CT_HopDongDichVu_bindingSource.DataSource = _HopDongMuaBan.CT_HopDongDichVu;
            ChiTietThanhToanbd.DataSource = _HopDongMuaBan.chiTietThanhToan;
        }

        private void KhoiTao(HopDongMuaBan hopDongMuaBan)
        {
            _HopDongMuaBan = hopDongMuaBan;
            SetGiaTriMacDinhHopDong();
            HopDongMuaBanBindingSource.DataSource = _HopDongMuaBan;

            _chiTietThanhToan = _HopDongMuaBan.chiTietThanhToan;
            ChiTietThanhToanbd.DataSource = _chiTietThanhToan;

            _CTHopDongDichVuList = _HopDongMuaBan.CT_HopDongDichVu;
            CT_HopDongDichVu_bindingSource.DataSource = _CTHopDongDichVuList;

            tenNhanVienListBindingSource.DataSource = TenNhanVienList.GetTenNhanVienList();
            NguoiDaiDienList_bindingSource.DataSource = TenNhanVienList.GetTenNhanVienList_NguoiDaiDienHopDong();

            //loaiHangHoaListBindingSource.DataSource = LoaiHangHoaList.GetLoaiHangHoaList(0);

            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();

            loaiTienListBindingSource1.DataSource = LoaiTienList.GetLoaiTienList();

            loaiHopDongListBindingSource.DataSource = LoaiHopDongList.GetLoaiHopDongList();

            _DoiTacList = DoiTacList.GetDoiTacList("", 0);           
            doiTacListBindingSource.DataSource = _DoiTacList;

            BoPhan _BoPhan = BoPhan.NewBoPhan(0, "Không Chọn");
            _BoPhanList.Insert(0, _BoPhan);
            boPhanListBindingSource.DataSource = _BoPhanList;

            DonViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();

        }

        private bool KiemTraDuLieu()
        {
            bool kq = true;

            if (_HopDongMuaBan.MaLoaiHopDong==0)
            {
                MessageBox.Show(this, util.LoaiHopDong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbeu_LoaiHopDong.Focus();
                return false;
            }
            //if (txtu_TenHopDong.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show(this, "Vui lòng nhập vào nôi dung Hợp đồng!", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtu_TenHopDong.Focus();
            //    return false;
            //}  //Temp
            //    else if(_HopDongMuaBan.TongTien==0)
            //{
            //    MessageBox.Show(this, "Vui Lòng Nhập vào tổng tiền", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    numeu_TongTien.Focus();
            //    return false;
            //}   //Temp
            else if (_HopDongMuaBan.MaDoiTac == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn Khách Hàng", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                grdLU_KhachHang.Focus();
                return false;
            }
            //else if (_HopDongMuaBan.chiTietThanhToan.Count == 0)
            //{
            //    MessageBox.Show(this, "Vui Lòng Nhập Chi Tiết Thanh Toán", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    return false;
            //}       //Temp
            
            return kq;

        }

        private bool LuuDuLieu()
        {
            bool kq = true;
            try
            {
                if (SetSoHopDongTrongDai() && SetSoThamDinhHopDong())
                {
                    if (KiemTraSoHopDongHopLe() && KiemTraSoThamDinhHopDongHopLe())
                    {
                        _HopDongMuaBan.ApplyEdit();
                        HopDongMuaBanBindingSource.EndEdit();
                        if (bTrucTiep && KiemTraDuLieu() && KiemTraChiTietThanhToan())
                            _HopDongMuaBanList.Save();
                        _OK = true;
                    }
                    else
                    {
                        kq = false;
                    }
                }
                else
                {
                    kq = false;
                }
            }
            catch (ApplicationException ex)
            {
                kq = false;
            }
            return kq;
        }
        #endregion

        #region Event
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            Them(_muaBan);
            cb_LoaiHD.Enabled = true;
           // txt_GhiChu.Text= SetGhiChu();

        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            textEdit_Focus1.Focus();
            textEdit_Focus2.Focus();

                //B
                if (KiemTraDuLieu() && KiemTraChiTietThanhToan())
                {
                    if (MessageBox.Show(this, "Bạn Muốn Lưu Dữ Liệu", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        if (LuuDuLieu() == true)
                        {
                            MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            KiemTraKhoaHDTrongNgoaiDai();
                        }
                    }
                }
                //E
            
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            if (_HopDongMuaBan.IsNew == false)
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
                //Report.SetParameterValue("@MaHopDong", _HopDongMuaBan.MaHopDong,"CT_HopDongMuaBan");

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
            }
            else
            {
                MessageBox.Show(this, "Hợp Đồng Chưa Được Cập Nhật", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        //private void cmbu_KhachHang_AfterCloseUp(object sender, EventArgs e)
        //{

        //    if (cmbu_KhachHang.ActiveRow != null)
        //    {
        //        if (Convert.ToInt32(cmbu_KhachHang.Value) == 0 && flag != 0)
        //        {
        //            frmKhachHang dlg = new frmKhachHang();
        //            if (dlg.ShowDialog() != DialogResult.OK)
        //            {
        //                _DoiTacList = DoiTacList.GetDoiTacList(false);
        //                DoiTac doiTac = DoiTac.NewDoiTac(0, "Thêm Mới.....");
        //                _DoiTacList.Insert(0, doiTac);
        //                doiTacListBindingSource.DataSource = _DoiTacList;
        //            }
        //        }
        //    }
        //    flag++;
        //}

        private void cb_LoaiHD_CheckedChanged(object sender, EventArgs e)
        {
            if (!cb_LoaiHD.Checked)
                this.Text = "Hợp Đồng Dịch Vụ - Trong Đài";
            else
                this.Text = "Hợp Đồng Dịch Vụ - Ngoài Đài";
        }
        #endregion

        private void grd_CTHopDongDichVu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung hdc = new HamDungChung();
            hdc.ultragrdEmail_InitializeLayout(sender, e);

            HamDungChung.EditBand(grd_CTHopDongDichVu.DisplayLayout.Bands[0],
                new string[9] { "HangHoa", "MaDonViTinh", "SoLuong", "DonGia", "ThanhTien", "SoThangTrongHan", "NgayApDung", "NgayHetHanPS", "SoLanPhatSong" },
                new string[9] { "Tên hàng hóa", "Đơn vị tính", "Số lượng", "Đơn giá", "Thành tiền", "Bản quyền(tháng)", "Ngày áp dụng(Bản quyền)", "Ngày hết hạn(Bản quyền)", "Số lần phát sóng(Bản quyền)" },
                new int[9] { 200, 120, 100, 120, 150, 120, 120, 120, 120 },
                new Control[9] { null, cmb_DonViTinh, null, null, null, null, null, null, null },
                new KieuDuLieu[9] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.So, KieuDuLieu.TienLe, KieuDuLieu.TienLe, KieuDuLieu.Null, KieuDuLieu.Ngay, KieuDuLieu.Ngay, KieuDuLieu.Null },
                new bool[9] { true, true, true, true, true, true, true, true, true });

            //màu và font chữ
            foreach (UltraGridColumn col in this.grd_CTHopDongDichVu.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            this.grd_CTHopDongDichVu.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grd_CTHopDongDichVu.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
        }

        private void cmb_DonViTinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmb_DonViTinh.DisplayLayout.Bands[0],
               new string[2] { "TenDonViTinh", "MaQuanLy" },
               new string[2] { "Đơn vị tính", "Mã quản lý" },
               new int[2] { 150, 80 },
               new Control[2] { null, null },
               new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
               new bool[2] { false, false });

            //màu và font chữ
            foreach (UltraGridColumn col in this.cmb_DonViTinh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            this.cmb_DonViTinh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cmb_DonViTinh.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
        }

        private void grd_CTHopDongDichVu_AfterCellUpdate(object sender, CellEventArgs e)
        {
            TinhTongTien();
        }

        private void TinhTongTien()
        {
            decimal _soTien = 0;
            if (grd_CTHopDongDichVu.Rows.Count > 0)
            {
                foreach (CT_HopDongDichVu item in _HopDongMuaBan.CT_HopDongDichVu)
                {
                    _soTien += item.ThanhTien;
                }
            }
            _HopDongMuaBan.TongTien = _soTien;
        }

        private void grd_CTThanhToan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung hdc = new HamDungChung();
            hdc.ultragrdEmail_InitializeLayout(sender, e);

            HamDungChung.EditBand(grd_CTThanhToan.DisplayLayout.Bands[0],
                new string[6] { "NgayThanhToan", "PhanTramThanhToan", "SoTien", "TienThue", "TienPhat", "GhiChu" },
                new string[6] { "Ngày thanh toán", "% thanh toán", "Số tiền", "Tiền thuế", "Tiền phạt", "Ghi chú" },
                new int[6] { 140, 120, 130, 130, 130, 220 },
                new Control[6] { null, null, null, null, null, null },
                new KieuDuLieu[6] { KieuDuLieu.Ngay, KieuDuLieu.Tien, KieuDuLieu.TienLe, KieuDuLieu.TienLe, KieuDuLieu.TienLe, KieuDuLieu.Null },
                new bool[6] { true, true, true, true, true, true });

            //màu và font chữ
            foreach (UltraGridColumn col in this.grd_CTThanhToan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            this.grd_CTThanhToan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grd_CTThanhToan.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
        }

        private void cb_MaNguoiKy_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cb_MaNguoiKy.DisplayLayout.Bands[0],
               new string[2] { "TenNhanVien", "TenChucVu" },
               new string[2] { "Tên", "Chức Vụ" },
               new int[2] { 150, 150 },
               new Control[2] { null, null },
               new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
               new bool[2] { false, false });

            //màu và font chữ
            foreach (UltraGridColumn col in this.cb_MaNguoiKy.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            this.cb_MaNguoiKy.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cb_MaNguoiKy.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;

        }

        private void grdLU_KhachHang_EditValueChanged(object sender, EventArgs e)
        {
            if (grdLU_KhachHang.EditValue != null)
            {
                long maDoiTac;
                if (long.TryParse(grdLU_KhachHang.EditValue.ToString(), out maDoiTac))
                {
                    _DoiTac = DoiTac.GetDoiTacWithoutChild(maDoiTac);

                    txtu_MaSoThue.Value = _DoiTac.MaSoThue;
                    txt_DiaChiKhachHang.Value = _DoiTac.DiaChi;
                    //NguoiLienLacListBindingSource.DataSource = _DoiTac.NguoiLienLacList;
                    //diaChiDoiTacListBindingSource.DataSource = _DoiTac.DiaChi_DoiTacList;
                    //diaChiDoiTacListBindingSource1.DataSource = _DoiTac.DiaChi_DoiTacList;
                    //DienThoaiListBindingSource.DataSource = _DoiTac.DoiTac_DienThoai_FaxList;
                    //tKNganHangListBindingSource.DataSource = _DoiTac.TK_NganHangList;
                }
            }
            else
            {
                txtu_MaSoThue.Text = string.Empty;
                txt_DiaChiKhachHang.Value = string.Empty;
                //NguoiLienLacListBindingSource.DataSource = NguoiLienLacList.NewNguoiLienLacList();
                //diaChiDoiTacListBindingSource.DataSource = DiaChi_DoiTacList.NewDiaChi_DoiTacList();
                //diaChiDoiTacListBindingSource1.DataSource = DiaChi_DoiTacList.NewDiaChi_DoiTacList();
                //DienThoaiListBindingSource.DataSource = DoiTac_DienThoai_FaxList.NewDoiTac_DienThoai_FaxList();
                //tKNganHangListBindingSource.DataSource = TK_NganHangList.NewTK_NganHangList();
            }

        }

        private void grdLU_KhachHang_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            //if (grdLU_KhachHang.EditValue != null)
            //{
            //    if (Convert.ToInt32(grdLU_KhachHang.EditValue) == 0 && flag != 0)
            //    {
            //        frmKhachHang dlg = new frmKhachHang();
            //        if (dlg.ShowDialog() != DialogResult.OK)
            //        {
            //            _DoiTacList = DoiTacList.GetDoiTacList(false);
            //            DoiTac doiTac = DoiTac.NewDoiTac(0, "Thêm Mới.....");
            //            _DoiTacList.Insert(0, doiTac);
            //            doiTacListBindingSource.DataSource = _DoiTacList;
            //        }
            //    }
            //}
            //flag++;

        }

        private void frmHopDongDichVu_Load(object sender, EventArgs e)
        {
            if (!_HopDongMuaBan.IsNew)
            {
                KiemTraKhoaHDTrongNgoaiDai();
            }
            this.Text = this.Text + SetGhiChu();
        }

        private void cb_LoaiNgay_CheckedChanged(object sender, EventArgs e)
        {
            //if (_HopDongMuaBan.SoNgay > 1)
            //{
               // if (cb_LoaiNgay.Checked == true)
               // {
                   // _HopDongMuaBan.NgayHetHan = TinhDenNgay(_HopDongMuaBan.TuNgay.Date, _HopDongMuaBan.SoNgay, true);
                //}
                //else
                //{
                   // _HopDongMuaBan.NgayHetHan = TinhDenNgay(_HopDongMuaBan.TuNgay.Date, _HopDongMuaBan.SoNgay, false);
               // }
            //}
            //_HopDongMuaBan.LoaiNgay = cb_LoaiNgay.Checked;
            
        }

        private void dteu_TuNgay_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateChange = new DateTime();
            if (DateTime.TryParse(dteu_TuNgay.Value.ToString(),out dateChange))
            {
                if (_HopDongMuaBan.SoNgay > 1)
                {
                    if (cb_LoaiNgay.Checked == true)
                    {
                        _HopDongMuaBan.NgayHetHan = TinhDenNgay(dateChange.Date, _HopDongMuaBan.SoNgay, true);
                    }
                    else
                    {
                        _HopDongMuaBan.NgayHetHan = TinhDenNgay(dateChange.Date, _HopDongMuaBan.SoNgay, false);
                    }
                }
                _HopDongMuaBan.TuNgay = dateChange;
            }
            
        }



        private void txt_SoNgay_Leave(object sender, EventArgs e)
        {
            int temp;
            if (int.TryParse(txt_SoNgay.Text, out temp))
            {
                if (temp > 1)
                {
                    if (cb_LoaiNgay.Checked == true)
                    {
                        _HopDongMuaBan.NgayHetHan = TinhDenNgay(_HopDongMuaBan.TuNgay, temp, true);
                    }
                    else
                    {
                        _HopDongMuaBan.NgayHetHan = TinhDenNgay(_HopDongMuaBan.TuNgay, temp, false);
                    }
                }
            }
           
        }

        

        private void grd_CTThanhToan_AfterCellUpdate(object sender, CellEventArgs e)
        {
            ChiTietThanhToan ctthanhtoan = ChiTietThanhToanbd.Current as ChiTietThanhToan;
            if (e.Cell.Column.Key == "PhanTramThanhToan")
            {
                ctthanhtoan.SoTien = (_HopDongMuaBan.TongTien * ctthanhtoan.PhanTramThanhToan) / 100;
                ctthanhtoan.TienThue = (ctthanhtoan.SoTien * (decimal)_HopDongMuaBan.ThueSuat) / 100;
            }
        }

        private void ultraGroupBox2_Click(object sender, EventArgs e)
        {

        }

    }
}
