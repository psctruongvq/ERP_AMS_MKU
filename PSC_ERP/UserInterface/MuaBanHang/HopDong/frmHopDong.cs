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
    public partial class frmHopDong : Form
    {
        #region Properties

        DoiTacList _DoiTacList;
        DoiTac _DoiTac;
      
        BangBaoGiaList _BangBaoGiaList;
        BangBaoGia _BangBaoGia;
        HopDongMuaBan _HopDongMuaBan ;
        OpenFileDialog _OpenFileDialog;
        HangHoaList _HangHoaList=HangHoaList.NewHangHoaList();
        HangHoa _HangHoa;
        DonViTinhList _DonViTinhList;
        DonViTinhList _DonViTinhKhoiLuongList;
        string _Path;
        HamDungChung t = new HamDungChung();
        private bool  _muaBan;
        Util util = new Util();
        int flag = 0;
        
        #endregion

        #region contructors
        public frmHopDong()
        {
            InitializeComponent();
            ////KhaiBaoSuKien();
            ////Invisible();
            Them();
            KhoiTao();           
           
        }

        public frmHopDong(bool muaBan)
        {
            InitializeComponent();           
            //KhaiBaoSuKien();
            //Invisible();
            Them(muaBan);
            KhoiTao();
            
        }

        public frmHopDong(HopDongMuaBan HopDongMuaBan)
        {
            InitializeComponent();
            //KhaiBaoSuKien();
            //Invisible();
            KhoiTao(HopDongMuaBan);
        }
        #endregion

        #region Khai Báo Sự Kiện
        private void KhaiBaoSuKien() 
        {
            t.EventForm(this);
            t.EventGrid(grdu_ChiTietHopDong);
            t.EventGrid(grdu_DotGiaoNhan);
            t.EventGrid(grdu_DotThanhToan);            
            t.EventsControl(cmbu_KhachHang);                    
        }
        #endregion 

        #region Khởi Tạo

        private void KhoiTao()
        {        
            _BangBaoGiaList = BangBaoGiaList.GetBangBaoGiaList();

            BangBaoGiaListBindingSource.DataSource = _BangBaoGiaList;                           

            tenNhanVienListBindingSource.DataSource = TenNhanVienList.GetTenNhanVienList();

            //loaiHangHoaListBindingSource.DataSource = LoaiHangHoaList.GetLoaiHangHoaList(0);            

            phuongThucTTListBindingSource.DataSource = PhuongThucThanhToanList.GetPhuongThucThanhToanList();

            PTGiaoNhanListBindingSource.DataSource = PhuongThucGiaoNhanList.GetPhuongThucGiaoNhanList();
           
            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();

            loaiTienListBindingSource1.DataSource = LoaiTienList.GetLoaiTienList();

            loaiHopDongListBindingSource.DataSource = LoaiHopDongList.GetLoaiHopDongList();

            _DoiTacList = DoiTacList.GetDoiTacList("", false);
            DoiTac doiTac = DoiTac.NewDoiTac(0, "Thêm Mới.....");
            _DoiTacList.Insert(0, doiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;
            _HangHoaList = HangHoaList.GetHangHoaList();
            _HangHoa= HangHoa.NewHangHoa("Thêm Mới", 0);
            _HangHoaList.Insert(0, _HangHoa);
            hangHoaListBindingSource.DataSource = _HangHoaList;

        }
        private void Them(bool muaBan )
        {
            _HopDongMuaBan = HopDongMuaBan.NewHopDongMuaBan();
            HopDongMuaBanBindingSource.DataSource = _HopDongMuaBan;
            CT_HopDongMuaBanListBindingSource.DataSource = _HopDongMuaBan.CT_HopDongMuaBanList;
            dotGiaoHangHDMBListBindingSource.DataSource = _HopDongMuaBan.DotGiaoHangHDMBList;
            DotThanhToanListBindingSource.DataSource = _HopDongMuaBan.DotThanhToanHDMBList;
            _muaBan = muaBan;
            //cmbeu_LoaiHopDong.Value = loai;
            _HopDongMuaBan.MuaBan = _muaBan;           
                      
        }
        private void Them()
        {
            _HopDongMuaBan = HopDongMuaBan.NewHopDongMuaBan();
            HopDongMuaBanBindingSource.DataSource = _HopDongMuaBan;
            CT_HopDongMuaBanListBindingSource.DataSource = _HopDongMuaBan.CT_HopDongMuaBanList;
            dotGiaoHangHDMBListBindingSource.DataSource = _HopDongMuaBan.DotGiaoHangHDMBList;
            DotThanhToanListBindingSource.DataSource = _HopDongMuaBan.DotThanhToanHDMBList;
            
        }
        private void KhoiTao(HopDongMuaBan hopDongMuaBan)
        {
            _HopDongMuaBan = hopDongMuaBan;
            HopDongMuaBanBindingSource.DataSource = _HopDongMuaBan;
            CT_HopDongMuaBanListBindingSource.DataSource = _HopDongMuaBan.CT_HopDongMuaBanList;
            dotGiaoHangHDMBListBindingSource.DataSource = _HopDongMuaBan.DotGiaoHangHDMBList;
            DotThanhToanListBindingSource.DataSource = _HopDongMuaBan.DotThanhToanHDMBList;

            tenNhanVienListBindingSource.DataSource = TenNhanVienList.GetTenNhanVienList();

            _BangBaoGiaList = BangBaoGiaList.GetBangBaoGiaList();
            BangBaoGiaListBindingSource.DataSource = _BangBaoGiaList;           

            loaiHangHoaListBindingSource.DataSource = LoaiHangHoaList.GetLoaiHangHoaList(0);

            phuongThucTTListBindingSource.DataSource = PhuongThucThanhToanList.GetPhuongThucThanhToanList();

            PTGiaoNhanListBindingSource.DataSource = PhuongThucGiaoNhanList.GetPhuongThucGiaoNhanList();          

            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();

            loaiTienListBindingSource1.DataSource = LoaiTienList.GetLoaiTienList();

            loaiHopDongListBindingSource.DataSource = LoaiHopDongList.GetLoaiHopDongList();
            _DoiTacList = DoiTacList.GetDoiTacList("", false);
            DoiTac doiTac = DoiTac.NewDoiTac(0, "Thêm Mới.....");
            _DoiTacList.Insert(0, doiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;

        }

        #endregion       

        #region Invisible Button
        private void Invisible()
        {          
            t.EventForm(this);                   
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
            else if (_HopDongMuaBan.MaDoiTac == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn Khách Hàng", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbu_KhachHang.Focus();
                return false;
            }
            else if (_HopDongMuaBan.MaNguoiKy == 0)
            {
                MessageBox.Show(this, "Vui Chọn Người Đại Diện", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbu_NguoiDaiDien.Focus();
                return false;
            }
            else if (_HopDongMuaBan.CT_HopDongMuaBanList.Count == 0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Chi Tiết Hợp Đồng", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return false;
            }
            else if (_HopDongMuaBan.DotGiaoHangHDMBList.Count == 0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Đợt Giao Hàng Hợp Đồng", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
            
            else if (_HopDongMuaBan.IsNew == true  && _HopDongMuaBan.SoHopDong != string.Empty && HopDongMuaBan.KiemTraSoHopDongTonTai(txtu_SoHopDong.Text.Trim(),_HopDongMuaBan.MaLoaiHopDong,_HopDongMuaBan.MuaBan) == false)
            {
                MessageBox.Show(this, util.sohopdongbitrung, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtu_SoHopDong.Focus();
                return false;
            }
            return kq;

        }
        #endregion

        #region Kiểm Tra Hàng Hóa Bị Trùng
        private Boolean KiemTraHangHoaBiTrung()
        {
            for (int i = 0; i < _HopDongMuaBan.CT_HopDongMuaBanList.Count; i++)
            {
                for (int j = 0; j < _HopDongMuaBan.CT_HopDongMuaBanList.Count; j++)
                {
                     if (i != j)
                    {
                        if (_HopDongMuaBan.CT_HopDongMuaBanList[i].MaHangHoa == _HopDongMuaBan.CT_HopDongMuaBanList[j].MaHangHoa)
                        {
                            HangHoa hangHoa = HangHoa.GetHangHoa(_HopDongMuaBan.CT_HopDongMuaBanList[i].MaHangHoa);
                            MessageBox.Show(this,"Hàng hóa" +hangHoa.TenHangHoa.ToString() + " bị trùng","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            grdu_ChiTietHopDong.ActiveRow = grdu_ChiTietHopDong.Rows[i];
                            grdu_ChiTietHopDong.Focus();
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
                //if (_HopDongMuaBan.IsNew)
                //{                     
                //    _HopDongMuaBan.SoHopDong = HopDongMuaBan.SoHopDongTuDongTang(_HopDongMuaBan.MaLoaiHopDong, _muaBan);
                   
                //}
                _HopDongMuaBan.ApplyEdit();
                _HopDongMuaBan.Save();
            }
            catch (ApplicationException ex)
            {
                kq = false;
            }
            return kq;
        }

        #endregion
      
        #region ConvertFileToBinary
        private byte[] ConvertFileToBinary(OpenFileDialog openFileDialog)
        {
            byte[] value = new byte[0];
            if (openFileDialog.FileName.Trim() != string.Empty)
            {
                FileStream stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                value = new byte[Convert.ToInt32(stream.Length)];
                stream.Read(value, 0, value.Length);
                stream.Close();
            }
            return value;
        }
        #endregion

        #region btnFileDinhKem_Click
        private void btnFileDinhKem_Click(object sender, EventArgs e)
        {
            _Path = Application.StartupPath;           
            _OpenFileDialog = new OpenFileDialog();
            _OpenFileDialog.Title = "Chọn file cần đính kèm";
            _OpenFileDialog.InitialDirectory = _Path;
            if (_OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                ultratxtFileDinhKem.Value = _OpenFileDialog.FileName.Substring(_OpenFileDialog.FileName.LastIndexOf("\\") + 1);
                byte[] value = ConvertFileToBinary(_OpenFileDialog);
                ultratxtFileDinhKem.Text = _OpenFileDialog.FileName;
               // _HopDong.FileDinhKem = value;
            }
        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu() == true)
            {
                if (KiemTraHangHoaBiTrung() == true)
                {
                    //double tong = (double)(this.ultranueTongTien.Value);
                    if (MessageBox.Show(this, "Bạn Muốn Lưu Dữ Liệu", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        if (LuuDuLieu() == true)
                        {
                            MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                       // else MessageBox.Show(this, "Cập Nhật Không Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
            Them(_muaBan);
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

        #region ultragrdChiTietHangHoa_InitializeLayout
        private void ultragrdChiTietHangHoa_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
           
            t.ultragrdEmail_InitializeLayout(sender, e);           

            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["MaCTHopDong"].Hidden = true;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["MaHopDong"].Hidden = true;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["MaHangHoa"].Hidden = true;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Hidden = true;            
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = true;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["ChietKhau"].Hidden = true;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["KhoiLuong"].Hidden = true;

            //grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.Caption = "Thể Loại";
            //grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].EditorControl = cmbu_LoaiHangHoa;
            //grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Width = 100;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Hidden = true;

            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.Caption = "Thể Loại";
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["TenHangHoa"].EditorControl = cmbu_HangHoa;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["TenHangHoa"].Width = 100;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.VisiblePosition = 0;

            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Hàng Hóa/Dịch Vụ";
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 1;

            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["SoLuong"].Header.Caption = "Số Lượng";
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["SoLuong"].Header.VisiblePosition = 2;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["SoLuong"].MaskInput = "nnnnnnnnn";
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["SoLuong"].Width = 70;
            
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Caption = "Đơn Vị Tính";
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["TenDonViTinh"].EditorControl = cmbu_DonViTinh;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Width = 70;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.VisiblePosition = 3;
            
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["KhoiLuong"].Header.Caption = "KL Vàng";
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["KhoiLuong"].Header.VisiblePosition = 4;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["KhoiLuong"].MaskInput = "nnnnnnnnn.nnnn";                    
            
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["DonGia"].Header.Caption = "Đơn Giá";
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["DonGia"].Width = 70;
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["DonGia"].Header.VisiblePosition = 7;                       
            
            grdu_ChiTietHopDong.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.Caption = "Thành Tiền";
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
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
            }
        }
        #endregion

        #region ultracmbHangHoa_InitializeLayout
        private void ultracmbHangHoa_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            e.Layout.Override.HeaderAppearance.BackColor = Color.SteelBlue;

            //e.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
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

            //e.Layout.Bands[0].Columns["GiaBanSi"].Hidden = false;
            //e.Layout.Bands[0].Columns["GiaBanSi"].Header.Caption = "Giá Hiện tại";
            //e.Layout.Bands[0].Columns["GiaBanSi"].Header.VisiblePosition = 2;

           
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

        #region ultracmbDiaChiGH_InitializeLayout
        private void ultracmbDiaChiGH_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            cmbu_DiaChiGH.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.cmbu_DiaChiGH.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.cmbu_DiaChiGH.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }           

            cmbu_DiaChiGH.DisplayLayout.Bands[0].Columns["TenDiaChiChung"].Header.Caption = "Địa Chỉ";
            cmbu_DiaChiGH.DisplayLayout.Bands[0].Columns["TenDiaChiChung"].Width = 260;
            cmbu_DiaChiGH.DisplayLayout.Bands[0].Columns["TenDiaChiChung"].Hidden = false;

        }
        #endregion

        #region ultracmbDiaChiHD_InitializeLayout
        private void ultracmbDiaChiHD_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {         
          
            cmbu_DiaChiHD.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.cmbu_DiaChiHD.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.cmbu_DiaChiHD.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            cmbu_DiaChiHD.DisplayLayout.Bands[0].Columns["TenDiaChiChung"].Header.Caption = "Địa Chỉ";
            cmbu_DiaChiHD.DisplayLayout.Bands[0].Columns["TenDiaChiChung"].Width = 260;
            cmbu_DiaChiHD.DisplayLayout.Bands[0].Columns["TenDiaChiChung"].Hidden = false;
        }
        #endregion       

        #region ultracmbBangGia_InitializeLayout
        private void ultracmbBangGia_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        //    cmbu_BangBaoGia.DisplayLayout.Bands[0].Columns["MaBangBaoGia"].Hidden = true;
        //    cmbu_BangBaoGia.DisplayLayout.Bands[0].Columns["MaKhachHang"].Hidden = true;
        //    cmbu_BangBaoGia.DisplayLayout.Bands[0].Columns["TenKhachHang"].Header.Caption = "Khách Hàng";
        //    cmbu_BangBaoGia.DisplayLayout.Bands[0].Columns["TenKhachHang"].Width = 100;
        //    cmbu_BangBaoGia.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
        //    cmbu_BangBaoGia.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 80;
        //    cmbu_BangBaoGia.DisplayLayout.Bands[0].Columns["NoiDung"].Header.Caption = "Nội Dung";
        //    cmbu_BangBaoGia.DisplayLayout.Bands[0].Columns["NoiDung"].Width = 200;

        //    cmbu_BangBaoGia.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
        //    cmbu_BangBaoGia.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

        //    foreach (UltraGridColumn col in this.cmbu_BangBaoGia.DisplayLayout.Bands[0].Columns)
        //    {
        //        col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
        //        col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
        //        col.Header.Appearance.ForeColor = Color.Navy;
        //    }
        }
        #endregion

        #region ultracmbPTGiaoNhan_InitializeLayout
        private void ultracmbPTGiaoNhan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_PhuongThucGiaoNhan.DisplayLayout.Bands[0].Columns["MaPhuongThucGiaoNhan"].Hidden = true;
            cmbu_PhuongThucGiaoNhan.DisplayLayout.Bands[0].Columns["MaPTGNQL"].Header.Caption = "Mã Quản Lý";
            cmbu_PhuongThucGiaoNhan.DisplayLayout.Bands[0].Columns["TenPhuongThuc"].Header.Caption = "Phương Thức Giao Nhận";
            cmbu_PhuongThucGiaoNhan.DisplayLayout.Bands[0].Columns["TenPhuongThuc"].Width = 200;

            cmbu_PhuongThucGiaoNhan.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            cmbu_PhuongThucGiaoNhan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.cmbu_PhuongThucGiaoNhan.DisplayLayout.Bands[0].Columns)
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

        #region ultraGridDotGiaoNhan_InitializeLayout
        private void ultraGridDotGiaoNhan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            t.ultragrdEmail_InitializeLayout(sender, e);
            grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns["MaChiTiet"].Hidden = true;
            grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns["MaHopDongMuaBan"].Hidden = true;
            grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns["DaGiaoHang"].Hidden = true;

            grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns["MaPhuongThucGiaoNhan"].Header.Caption = "Phương Thức Giao Nhận";
            grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns["MaPhuongThucGiaoNhan"].EditorControl = cmbu_PhuongThucGiaoNhan;

            grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns["NgayGiao"].Header.Caption = "Ngày Giao";
            grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns["MaDiaChi"].Header.Caption = "Địa Chỉ Giao Hàng";
            grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns["MaDiaChi"].EditorControl = cmbu_DiaChiGH;
            grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns["MaDiaChi"].Width = 150;

            grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns["MaDiaChiHD"].Header.Caption = "Địa Chỉ Gởi Hóa Đơn";
            grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns["MaDiaChiHD"].EditorControl = cmbu_DiaChiHD;
            grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns["MaDiaChiHD"].Width = 150;

            grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns["ChiPhiVanChuyen"].Header.Caption = "Chi Phí Vận Chuyển";
            grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns["ChiPhiVanChuyen"].Width = 100;
            grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns["ChiPhiVanChuyen"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns["ChiPhiVanChuyen"].Format = "###,###,###,###,###";

            grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns["NoiDung"].Header.Caption = "Nội Dung";
            grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns["NoiDung"].Width = 100;

            grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns["ChiTiet"].Header.Caption = "Thêm CT";
            grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns["ChiTiet"].Width = 70;
            grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns["ChiTiet"].EditorControl = txtu_ThemCT;
            grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns["ChiTiet"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns["ChiTiet"].CellActivation = Activation.ActivateOnly;

            grdu_DotGiaoNhan.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.grdu_DotGiaoNhan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_DotGiaoNhan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
            grdu_DotGiaoNhan.DisplayLayout.Bands[1].Hidden = true;
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

        #region ultraCbLoaiHangHoa_InitializeLayout
        private void ultraCbLoaiHangHoa_InitializeLayout(object sender, InitializeLayoutEventArgs e)
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

            cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Hidden= false;
            cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.Caption = "Tên Loại Hàng Hóa";
            cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.VisiblePosition = 1;
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

        #region txtu_ThemCT_EditorButtonClick
        private void txtu_ThemCT_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            int[] temp = new int[50];
            int i = 0;

            CT_HopDongMuaBanList _ct_HopDongMuaBanList = CT_HopDongMuaBanList.NewCT_HopDongMuaBanList(_HopDongMuaBan.CT_HopDongMuaBanList);
            if (((DotGiaoHangHDMB)(dotGiaoHangHDMBListBindingSource.Current)).CT_DotGiaoHangHDMBList.Count == 0)
            {

                foreach (DotGiaoHangHDMB dotGiaoHangHDMB in _HopDongMuaBan.DotGiaoHangHDMBList)
                {
                    foreach (CT_DotGiaoHangHDMB ctDotGiaoHangHDMB in dotGiaoHangHDMB.CT_DotGiaoHangHDMBList)
                    {
                        for (int j = 0; j < _ct_HopDongMuaBanList.Count; j++)
                        {
                            CT_HopDongMuaBan ctHopDongMuaBan = _ct_HopDongMuaBanList[j];
                            if (ctDotGiaoHangHDMB.MaHangHoa == ctHopDongMuaBan.MaHangHoa)
                            {
                                if (ctDotGiaoHangHDMB.SoLuong == ctHopDongMuaBan.SoLuong && ctDotGiaoHangHDMB.KhoiLuong == ctHopDongMuaBan.KhoiLuong)
                                {
                                    temp[i] = j;
                                    i++;
                                }
                                else
                                {
                                    ctHopDongMuaBan.SoLuong = (short)(ctHopDongMuaBan.SoLuong - ctDotGiaoHangHDMB.SoLuong);

                                    ctHopDongMuaBan.KhoiLuong = ctHopDongMuaBan.KhoiLuong - ctDotGiaoHangHDMB.KhoiLuong;
                                    if (ctHopDongMuaBan.SoLuong == 0 && ctHopDongMuaBan.KhoiLuong == 0)
                                    {
                                        temp[i] = j;
                                        i++;
                                    }
                                }

                            }
                        }
                    }
                }
                for (int j = 0; j < i; j++)
                {
                    _ct_HopDongMuaBanList.RemoveAt(temp[j]);
                    i--; j--;
                }              
            }

            frmChiTietDotGiaoNhan dlg = new frmChiTietDotGiaoNhan(((DotGiaoHangHDMB)(dotGiaoHangHDMBListBindingSource.Current)), _ct_HopDongMuaBanList);
            dlg.ShowDialog();          
           
        }

        private void KhoiTaoChiTietDotGiaoNhan( CT_DotGiaoHangHDMBList _ctDotGiaoHangHDMBList,  CT_HopDongMuaBanList _ctHopDongMuaBanList)
        {
            CT_DotGiaoHangHDMB ctDotGiaoNhanHDMB;
            foreach (CT_HopDongMuaBan ctHopDongMuaBan in _ctHopDongMuaBanList)
            {
                ctDotGiaoNhanHDMB = CT_DotGiaoHangHDMB.NewCT_DotGiaoHangHDMB(ctHopDongMuaBan);
                _ctDotGiaoHangHDMBList.Add(ctDotGiaoNhanHDMB);
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
                //_HangHoaList.Clear();
                _HangHoaList = HangHoaList.GetHangHoaList((int)cmbu_LoaiHangHoa.ActiveRow.Cells["MaLoaiHangHoa"].Value, 0);
                _HangHoaList.Insert(0, _hangHoa);
            }
            
            hangHoaListBindingSource.DataSource = _HangHoaList;           
            cmbu_HangHoa.DataSource = hangHoaListBindingSource;
        }       
        #endregion

        #region ultracmbKhachHang_ValueChanged
        private void ultracmbKhachHang_ValueChanged(object sender, EventArgs e)
        {

            if (cmbu_KhachHang.ActiveRow != null)
            {
                _DoiTac = DoiTac.GetDoiTac((long)cmbu_KhachHang.ActiveRow.Cells["MaDoiTac"].Value);

                txtu_MaSoThue.Value = _DoiTac.MaSoThue;
                NguoiLienLacListBindingSource.DataSource = _DoiTac.NguoiLienLacList;
                diaChiDoiTacListBindingSource.DataSource = _DoiTac.DiaChi_DoiTacList;
                diaChiDoiTacListBindingSource1.DataSource = _DoiTac.DiaChi_DoiTacList;
                DienThoaiListBindingSource.DataSource = _DoiTac.DoiTac_DienThoai_FaxList;
                tKNganHangListBindingSource.DataSource = _DoiTac.TK_NganHangList;
                //phuongThucTTListBindingSource.DataSource = _DoiTac.DoiTac_PhuongThucThanhToanList;
            }
            else
            {
                txtu_MaSoThue.Text = string.Empty;
                NguoiLienLacListBindingSource.DataSource = NguoiLienLacList.NewNguoiLienLacList();
                diaChiDoiTacListBindingSource.DataSource = DiaChi_DoiTacList.NewDiaChi_DoiTacList();
                diaChiDoiTacListBindingSource1.DataSource = DiaChi_DoiTacList.NewDiaChi_DoiTacList();
                DienThoaiListBindingSource.DataSource = DoiTac_DienThoai_FaxList.NewDoiTac_DienThoai_FaxList();
                tKNganHangListBindingSource.DataSource = TK_NganHangList.NewTK_NganHangList();
                // phuongThucTTListBindingSource.DataSource = PhuongThucThanhToanList.NewPhuongThucThanhToanList();
            }

        }
        #endregion
         
        #region ultracmbBangGia_ValueChanged
        private void ultracmbBangGia_ValueChanged(object sender, EventArgs e)
        {
            //if (cmbu_BangBaoGia.ActiveRow != null)
            //{
            //    _BangBaoGia = BangBaoGia.GetBangBaoGia((int)cmbu_BangBaoGia.ActiveRow.Cells["MaBangBaoGia"].Value);

            //    KhachHangListBindingSource.DataSource = DoiTac.GetDoiTac(_BangBaoGia.MaKhachHang);
            //}
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
                    foreach (CT_HopDongMuaBan ct_HopDongMuaBan in _HopDongMuaBan.CT_HopDongMuaBanList)
                    {
                        _TongTien = _TongTien + ct_HopDongMuaBan.ThanhTien;
                    }
                    _HopDongMuaBan.TongTien = _TongTien;
                }
                grdu_ChiTietHopDong.UpdateData();
            }
        }
        #endregion

        #region grdu_ChiTietHopDong_Click
        private void grdu_ChiTietHopDong_Click(object sender, EventArgs e)
        {
           // grdu_ChiTietHopDong.UpdateData();

        }
        #endregion

        #region cmbu_HangHoa_ValueChanged
        private void cmbu_HangHoa_ValueChanged(object sender, EventArgs e)
        {

            DonViTinh _donViTinh = DonViTinh.NewDonViTinh();
            _donViTinh.TenDonViTinh = "None";

            DonViTinh _donViTinh1 = DonViTinh.NewDonViTinh();
            _donViTinh1.TenDonViTinh = "None";

            if (cmbu_HangHoa.ActiveRow != null)
            {
                HangHoa _hangHoa = HangHoa.GetHangHoa((Int32)cmbu_HangHoa.ActiveRow.Cells["MaHangHoa"].Value);
                _DonViTinhList = _hangHoa.DanhSachDVT;
                _DonViTinhList.Insert(0, _donViTinh);
                DonViTinhListBindingSource.DataSource = _DonViTinhList;

                _DonViTinhKhoiLuongList = _hangHoa.DanhSachDVKL;
                _DonViTinhKhoiLuongList.Insert(0, _donViTinh1);
                donViTinhListBindingSource1.DataSource = _DonViTinhKhoiLuongList;

                if (CT_HopDongMuaBanListBindingSource.Current != null)
                    ((CT_HopDongMuaBan)CT_HopDongMuaBanListBindingSource.Current).MaHangHoa = (Int32)cmbu_HangHoa.ActiveRow.Cells["MaHangHoa"].Value;
                int soLuong = 0;
            }
                //foreach (CT_HopDongMuaBan ct in _HopDongMuaBan.CT_HopDongMuaBanList)
                //{
                //    if (ct.MaHangHoa == Convert.ToInt32(cmbu_TenHangHoa.ActiveRow.Cells["MaHangHoa"].Value))
                //    {
                //        soLuong += ct.SoLuong;
                //    }
                //} 
            
        }
        #endregion

        #region cmbu_DonViTinh_ValueChanged
        private void cmbu_DonViTinh_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_DonViTinh.ActiveRow != null)
            {
                ((CT_HopDongMuaBan)CT_HopDongMuaBanListBindingSource.Current).MaDonViTinh = Convert.ToInt32(cmbu_DonViTinh.ActiveRow.Cells["MaDonViTinh"].Value);
            }
        }
        #endregion       

        #region grdu_ChiTietHopDong_AfterCellUpdate
        private void grdu_ChiTietHopDong_AfterCellUpdate(object sender, CellEventArgs e)
        {
            grdu_ChiTietHopDong.UpdateData();
            Decimal _TongTien = 0;
            if (grdu_ChiTietHopDong.ActiveCell == grdu_ChiTietHopDong.ActiveRow.Cells["ThanhTien"])
            {
                foreach (CT_HopDongMuaBan ct_HopDongMuaBan in _HopDongMuaBan.CT_HopDongMuaBanList)
                {
                    _TongTien = _TongTien + ct_HopDongMuaBan.ThanhTien;
                }
                _HopDongMuaBan.TongTien = _TongTien;
            }
            if (grdu_ChiTietHopDong.ActiveCell == grdu_ChiTietHopDong.ActiveRow.Cells["TenHangHoa"])
            {
                KiemTraHangHoaBiTrung();
            }

        }
        #endregion

        #region grdu_DotGiaoNhan_KeyDown
        private void grdu_DotGiaoNhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode== Keys.Tab)
            {
                grdu_DotGiaoNhan.UpdateData();
            }
        }
        #endregion

        #region grdu_DotThanhToan_KeyDown
        private void grdu_DotThanhToan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                grdu_DotThanhToan.UpdateData();
            }
        }
        #endregion

        #region tlslblIn_Click
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
        #endregion        

        #region CT_HopDongMuaBanListBindingSource_CurrentChanged
        private void CT_HopDongMuaBanListBindingSource_CurrentChanged(object sender, EventArgs e)
        {
                Decimal _TongTien = 0;
           
                foreach (CT_HopDongMuaBan ct_HopDongMuaBan in _HopDongMuaBan.CT_HopDongMuaBanList)
                {
                    _TongTien = _TongTien + ct_HopDongMuaBan.ThanhTien;
                }
                _HopDongMuaBan.TongTien = _TongTien;

            }
        #endregion 

        #region grdu_DotThanhToan_AfterCellUpdate
            private void grdu_DotThanhToan_AfterCellUpdate(object sender, CellEventArgs e)
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

        #region grdu_ChiTietHopDong_Leave
        private void grdu_ChiTietHopDong_Leave(object sender, EventArgs e)
        {
            grdu_ChiTietHopDong.UpdateData();

            Decimal _TongTien = 0;
            foreach (CT_HopDongMuaBan ct_HopDongMuaBan in _HopDongMuaBan.CT_HopDongMuaBanList)
            {
                _TongTien = _TongTien + ct_HopDongMuaBan.ThanhTien;
            }
            _HopDongMuaBan.TongTien = _TongTien;

           // KiemTraHangHoaBiTrung();
                
        }
        #endregion             

        #region cmbu_KhachHang_AfterCloseUp
        private void cmbu_KhachHang_AfterCloseUp(object sender, EventArgs e)
        {
            
            if (cmbu_KhachHang.ActiveRow != null)
            {
                if (Convert.ToInt32(cmbu_KhachHang.Value) == 0 && flag !=0)
                {
                    frmKhachHang dlg = new frmKhachHang();
                    if (dlg.ShowDialog() != DialogResult.OK)
                    {
                        _DoiTacList = DoiTacList.GetDoiTacList(false);
                        DoiTac doiTac = DoiTac.NewDoiTac(0, "Thêm Mới.....");
                        _DoiTacList.Insert(0, doiTac);
                        doiTacListBindingSource.DataSource = _DoiTacList;
                    }
                }
            }
            flag++;
        }
        #endregion       
       
        #region frmHopDong_KeyDown
        private void frmHopDong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Hop Dong", "Help_BanHang.chm");
            }
        }
        #endregion 

        #region tlslblTroGiup_Click
        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            Main.frmMain.LoadHelp(this, "Hop Dong", "Help_BanHang.chm");
        }
        #endregion 
        
        #region cb_LoaiHD_CheckedChanged
        private void cb_LoaiHD_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_LoaiHD.Checked != true)
                txtu_SoHopDong.ReadOnly = true;
            else txtu_SoHopDong.ReadOnly = false;
        }
        #endregion 

        
        public void GetList(HangHoaList _HangHoaList)
        {

            
                //_HangHoa = HangHoa.NewHangHoa("Thêm mới...", 0);
                _HangHoaList.Insert(0, _HangHoa);
                HangHoaBindingSource.DataSource = _HangHoaList;            

        }


        #region cmbu_HangHoa_AfterCloseUp
        private void cmbu_HangHoa_AfterCloseUp(object sender, EventArgs e)
        {            
            if (cmbu_HangHoa.ActiveRow != null)
            {
                if (cmbu_HangHoa.ActiveRow.Index == 0)
                {
                    frmHangHoa frm = new frmHangHoa();
                    if (frm.ShowDialog()!= DialogResult.OK)
                    {
                        _HangHoaList = HangHoaList.GetHangHoaList();
                        _HangHoa = HangHoa.NewHangHoa("Thêm Mới", 0);
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
