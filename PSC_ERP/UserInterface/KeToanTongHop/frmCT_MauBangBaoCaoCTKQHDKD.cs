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

namespace PSC_ERP
{
    public partial class frmCT_MauBangBaoCaoCTKQHDKD : Form
    {
        CT_MauBangBaoCaoList _CT_MauBangBaoCaoList;
        HeThongTaiKhoan1List _HeThongTaiKhoanList;
        HeThongTaiKhoan1List _HeThongTaiKhoanList1;        
        
        CongTyList _CongTyList;
        BCKQHoatDongKinhDoanhList _BCKQHoatDongKinhDoanhList;
        byte _loai = 1; 


        public frmCT_MauBangBaoCaoCTKQHDKD(BCKQHoatDongKinhDoanh _BCKQHoatDongKinhDoanh)
        {
            InitializeComponent();
            _CT_MauBangBaoCaoList = _BCKQHoatDongKinhDoanh.CT_MauBangBaoCaoList;
            cTMauBangBaoCaoListBindingSource.DataSource = _CT_MauBangBaoCaoList;
            _loai = 4;
            KhoiTao();
        }

        public frmCT_MauBangBaoCaoCTKQHDKD(BangCanDoiKeToan _BangCanDoiKeToan)
        {
            InitializeComponent();
            _CT_MauBangBaoCaoList = _BangCanDoiKeToan.CT_MauBangBaoCaoList;
            cTMauBangBaoCaoListBindingSource.DataSource = _CT_MauBangBaoCaoList;
            _loai = 1;
            KhoiTao();
        }

        public frmCT_MauBangBaoCaoCTKQHDKD(BCKQHoatDongKinhDoanh _BCKQHoatDongKinhDoanh, byte loai)
        {
            InitializeComponent();
            _CT_MauBangBaoCaoList = _BCKQHoatDongKinhDoanh.CT_MauBangBaoCaoList;
            cTMauBangBaoCaoListBindingSource.DataSource = _CT_MauBangBaoCaoList;
            _loai = loai;
            KhoiTao();
        }

        public frmCT_MauBangBaoCaoCTKQHDKD(BangTongHopTinhHinhKinhPhi _BangTongHopTinhHinhKinhPhi)
        {
            InitializeComponent();
            _CT_MauBangBaoCaoList = _BangTongHopTinhHinhKinhPhi.CT_MauBangBaoCaoList;
            cTMauBangBaoCaoListBindingSource.DataSource = _CT_MauBangBaoCaoList;
            _loai = 5;
            KhoiTao();
        }


        private void KhoiTao()
        {
            _HeThongTaiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List();
            HeThongTaiKhoan1 heThongTaiKhoan = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
            heThongTaiKhoan.SoHieuTK = "None";
            heThongTaiKhoan.TenTaiKhoan = "None";
            _HeThongTaiKhoanList.Insert(0, heThongTaiKhoan);
            heThongTaiKhoan1ListBindingSource.DataSource = _HeThongTaiKhoanList;

            _HeThongTaiKhoanList1 = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List();
            HeThongTaiKhoan1 heThongTaiKhoan1 = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
            heThongTaiKhoan1.SoHieuTK = "None";
            heThongTaiKhoan1.TenTaiKhoan = "None";
            _HeThongTaiKhoanList1.Insert(0, heThongTaiKhoan1);
            heThongTaiKhoan1ListBindingSource1.DataSource = _HeThongTaiKhoanList1;

            _CongTyList = CongTyList.GetCongTyList();
            congTyListBindingSource.DataSource = _CongTyList;
            
            //_BCKQHoatDongKinhDoanhList = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhList(_loai);
            //BCKQHoatDongKinhDoanh bcKetQuaHoatDongKinhDoanh = BCKQHoatDongKinhDoanh.NewBCKQHoatDongKinhDoanh();
            //bcKetQuaHoatDongKinhDoanh.MaSo = "None";
            //bcKetQuaHoatDongKinhDoanh.TenMuc = "None";
            //_BCKQHoatDongKinhDoanhList.Insert(0,bcKetQuaHoatDongKinhDoanh);
            //bCKQHoatDongKinhDoanhListBindingSource.DataSource = _BCKQHoatDongKinhDoanhList;
        }

        #region Kiểm tra dữ liệu
        private Boolean KiemTraDuLieu()
        {
            Boolean kq = true;
            //if (cbeu_CongTru.Text == "")
            //{
            //    MessageBox.Show(this, "Vui Lòng Nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txt_MaSo.Focus();
            //    kq = false;
            //}
            //else if (txt_TenMucTK.Text == "")
            //{
            //    MessageBox.Show(this, "Vui Lòng Nhập Tên Mục", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txt_TenMucTK.Focus();
            //    kq = false;
            //}
            return kq;
        }

        private Boolean KiemTraDuLieu(BCKQHoatDongKinhDoanh bckqHoatDongKinhDoanh)
        {
            Boolean kq = true;
            //if (bckqHoatDongKinhDoanh.MaSo == 0)
            //{
            //    MessageBox.Show(this, "Vui Lòng Nhập Mã Số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txt_MaSo.Focus();
            //    kq = false;
            //}
            //else if (bckqHoatDongKinhDoanh.TenMuc == "")
            //{
            //    MessageBox.Show(this, "Vui Lòng Nhập Tên Mục", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txt_TenMucTK.Focus();
            //    kq = false;
            //}
            return kq;
        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            //if (LuuDuLieu() == true)
            //{
            //    MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show(this, "Cập Nhật Không Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }
        #endregion

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            if (_CT_MauBangBaoCaoList.Count == 0)
            {
                CT_MauBangBaoCao ctMauBangBaoCao= CT_MauBangBaoCao.NewCT_MauBangBaoCao(0,_loai);
                _CT_MauBangBaoCaoList.Add(ctMauBangBaoCao);
                grdu_DanhSachMuc.ActiveRow = grdu_DanhSachMuc.Rows[_CT_MauBangBaoCaoList.Count - 1];
            }
            else
            {
                if (KiemTraDuLieu() == true)
                {
                    CT_MauBangBaoCao ctMauBangBaoCao = CT_MauBangBaoCao.NewCT_MauBangBaoCao(0, _loai);
                    _CT_MauBangBaoCaoList.Add(ctMauBangBaoCao);
                    grdu_DanhSachMuc.ActiveRow = grdu_DanhSachMuc.Rows[_CT_MauBangBaoCaoList.Count - 1];
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

        #region grdu_DanhSachMuc_InitializeLayout
        private void grdu_DanhSachMuc_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.grdu_DanhSachMuc.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DanhSachMuc.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                //x =  //= System.Drawing.w;//RoyalBlue
            }

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["LoaiMau"].Hidden = true;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaChiTiet"].Hidden = true;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaMuc"].Hidden = true;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Hidden = true;            

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoHieu"].Header.Caption = "Tài Khoản";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoHieu"].Header.VisiblePosition = 1;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaTaiKhoanDoiUng"].Header.Caption = "Tài Khoản Đối Ứng";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaTaiKhoanDoiUng"].Header.VisiblePosition = 2;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaTaiKhoanDoiUng"].EditorComponent = cbu_TaiKhoanDU;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["Loai"].Header.Caption = "Loại";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["Loai"].Header.VisiblePosition = 3;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["Loai"].EditorComponent = cbeu_Loai;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["CongTru"].Header.Caption = "Cộng Trừ";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["CongTru"].Header.VisiblePosition = 4;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaMucLienQuan"].Header.Caption = "Mục TK Liên Quan";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaMucLienQuan"].Header.VisiblePosition = 2;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaMucLienQuan"].EditorComponent = cbu_MucLienQuan;
            
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["NoCo"].Header.Caption = "Nợ Có";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["NoCo"].Header.VisiblePosition = 5;            
        
        }
        #endregion 

        #region tlslblXoa_Click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {

        }
        #endregion 

        #region cbu_TaiKhoan_InitializeLayout
        private void cbu_TaiKhoan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbu_TaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbu_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            cbu_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            cbu_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;

            cbu_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            cbu_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 100;
            cbu_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;
            cbu_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;

        }
        #endregion 

        #region cbu_TaiKhoanDU_InitializeLayout
        private void cbu_TaiKhoanDU_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbu_TaiKhoanDU.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbu_TaiKhoanDU.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            cbu_TaiKhoanDU.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            cbu_TaiKhoanDU.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;

            cbu_TaiKhoanDU.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            cbu_TaiKhoanDU.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 100;
            cbu_TaiKhoanDU.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;
            cbu_TaiKhoanDU.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
        }
        #endregion 

        #region cbu_MucLienQuan_InitializeLayout
        private void cbu_MucLienQuan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.cbu_MucLienQuan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cbu_MucLienQuan.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cbu_MucLienQuan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                //x =  //= System.Drawing.w;//RoyalBlue
            }
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["MaMuc"].Hidden = true;
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["Loai"].Hidden = true;
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["LoaiBaoCao"].Hidden = true;
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["MaMucCha"].Hidden = true;

            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["MaSo"].Header.Caption = "Mã Mục";
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["MaSo"].Header.VisiblePosition = 1;

            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["TenMuc"].Header.Caption = "Tên Mục";
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["TenMuc"].Header.VisiblePosition = 2;

            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["ThuyetMinh"].Header.Caption = "Thuyết Minh";
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["ThuyetMinh"].Header.VisiblePosition = 3;

            
        }
        #endregion 

        #region cbu_TaiKhoan_ValueChanged
        private void cbu_TaiKhoan_ValueChanged(object sender, EventArgs e)
        {
            if (cbu_TaiKhoan.Value != null || Convert.ToInt32(cbu_TaiKhoan.Value) != 0)
            {
                ((CT_MauBangBaoCao)(cTMauBangBaoCaoListBindingSource.Current)).MaTaiKhoan = Convert.ToInt32(cbu_TaiKhoan.Value);
                ((CT_MauBangBaoCao)(cTMauBangBaoCaoListBindingSource.Current)).SoHieu = cbu_TaiKhoan.Text;
            }
        }
        #endregion 

        #region cbu_MucNganSach_InitializeLayout
        private void cbu_MucNganSach_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.cbu_CongTy.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cbu_CongTy.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cbu_CongTy.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                //x =  //= System.Drawing.w;//RoyalBlue
            }

            cbu_CongTy.DisplayLayout.Bands[0].Columns["MaCongTyQuanLy"].Header.Caption = "Mã Công Ty";
            cbu_CongTy.DisplayLayout.Bands[0].Columns["MaCongTyQuanLy"].Header.VisiblePosition = 1;
            cbu_CongTy.DisplayLayout.Bands[0].Columns["MaCongTyQuanLy"].Hidden = false;

            cbu_CongTy.DisplayLayout.Bands[0].Columns["TenCongTy"].Header.Caption = "Tên Công Ty";
            cbu_CongTy.DisplayLayout.Bands[0].Columns["TenCongTy"].Header.VisiblePosition = 2;
            cbu_CongTy.DisplayLayout.Bands[0].Columns["TenCongTy"].Hidden = false;         
        }
        #endregion 

        #region cbu_HoatDong_InitializeLayout
        private void cbu_HoatDong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }
        #endregion

     

    }
}