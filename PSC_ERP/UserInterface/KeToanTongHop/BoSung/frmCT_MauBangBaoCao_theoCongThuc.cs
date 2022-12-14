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
    public partial class frmCT_MauBangBaoCao_theoCongThuc : Form
    {
        CT_MauBangBaoCaoList _CT_MauBangBaoCaoList;
        HeThongTaiKhoan1List _HeThongTaiKhoanList;
        HeThongTaiKhoan1List _HeThongTaiKhoanList1;        
        MucNganSachList _MucNganSachList;
        BCKQHoatDongKinhDoanhList _BCKQHoatDongKinhDoanhList;
        BoPhanList _boPhanList;
        byte _loai = 1;

        private int _maCongThuc = 0;
        public frmCT_MauBangBaoCao_theoCongThuc(BCKQHoatDongKinhDoanh _BCKQHoatDongKinhDoanh)
        {
            InitializeComponent();
            _CT_MauBangBaoCaoList = _BCKQHoatDongKinhDoanh.CT_MauBangBaoCaoList;
            cTMauBangBaoCaoListBindingSource.DataSource = _CT_MauBangBaoCaoList;
            _loai = 2;
            KhoiTao();
        }

        public frmCT_MauBangBaoCao_theoCongThuc(BCKQHoatDongKinhDoanh _BCKQHoatDongKinhDoanh,int maCongThuc)
        {
            InitializeComponent();
            _maCongThuc = maCongThuc;
            _CT_MauBangBaoCaoList = _BCKQHoatDongKinhDoanh.CT_MauBangBaoCaoList;
            cTMauBangBaoCaoListBindingSource.DataSource = _CT_MauBangBaoCaoList;
            _loai = 2;
            KhoiTao();
        }

        
        public frmCT_MauBangBaoCao_theoCongThuc(BangCanDoiKeToan _BangCanDoiKeToan)
        {
            InitializeComponent();
            _CT_MauBangBaoCaoList = _BangCanDoiKeToan.CT_MauBangBaoCaoList;
            cTMauBangBaoCaoListBindingSource.DataSource = _CT_MauBangBaoCaoList;
            _loai = 1;
            KhoiTao();
        }

        public frmCT_MauBangBaoCao_theoCongThuc(BangTongHopTinhHinhKinhPhi _BangTongHopTinhHinhKinhPhi, byte loai)
        {
            InitializeComponent();
            _CT_MauBangBaoCaoList = _BangTongHopTinhHinhKinhPhi.CT_MauBangBaoCaoList;
            cTMauBangBaoCaoListBindingSource.DataSource = _CT_MauBangBaoCaoList;
            _loai = loai;
            KhoiTao();
        }

        public frmCT_MauBangBaoCao_theoCongThuc(BCKQHoatDongKinhDoanh _BCKQHoatDongKinhDoanh, byte loai)
        {
            InitializeComponent();
            _CT_MauBangBaoCaoList = _BCKQHoatDongKinhDoanh.CT_MauBangBaoCaoList;
            cTMauBangBaoCaoListBindingSource.DataSource = _CT_MauBangBaoCaoList;
            _loai = loai;
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

            _MucNganSachList = MucNganSachList.GetMucNganSachList();
            MucNganSach mucNganSach = MucNganSach.NewMucNganSach();
            mucNganSach.MaMucNganSachQL = "None";
            mucNganSach.TenMucNganSach = "None";
            _MucNganSachList.Insert(0, mucNganSach);
            mucNganSachListBindingSource.DataSource = _MucNganSachList;
            
            _BCKQHoatDongKinhDoanhList = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhListByMaCongThuc(_loai,_maCongThuc);
            BCKQHoatDongKinhDoanh bcKetQuaHoatDongKinhDoanh = BCKQHoatDongKinhDoanh.NewBCKQHoatDongKinhDoanh();
            bcKetQuaHoatDongKinhDoanh.MaSo = "None";
            bcKetQuaHoatDongKinhDoanh.TenMuc = "None";
            _BCKQHoatDongKinhDoanhList.Insert(0,bcKetQuaHoatDongKinhDoanh);
            bCKQHoatDongKinhDoanhListBindingSource.DataSource = _BCKQHoatDongKinhDoanhList;

            _boPhanList = BoPhanList.GetBoPhanListByMaBoPhanChaNotNull();
            BoPhan itemBoPhan = BoPhan.NewBoPhan("Không chọn");
            _boPhanList.Insert(0, itemBoPhan);
            this.boPhanListBindingSource.DataSource = _boPhanList;
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
            this.Close();
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
                col.Hidden = true;
                //x =  //= System.Drawing.w;//RoyalBlue
            }

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Header.Caption = "Tài Khoản";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Header.VisiblePosition = 1;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].EditorComponent = cbu_TaiKhoan;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Hidden = false;
            
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaTaiKhoanDoiUng"].Header.Caption = "Tài Khoản Đối Ứng";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaTaiKhoanDoiUng"].Header.VisiblePosition = 2;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaTaiKhoanDoiUng"].EditorComponent = cbu_TaiKhoanDU;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaTaiKhoanDoiUng"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["Loai"].Header.Caption = "Loại";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["Loai"].Header.VisiblePosition = 3;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["Loai"].EditorComponent = cbeu_Loai;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["Loai"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["CongTru"].Header.Caption = "Cộng Trừ";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["CongTru"].Header.VisiblePosition = 4;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["CongTru"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaMucLienQuan"].Header.Caption = "Mục TK Liên Quan";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaMucLienQuan"].Header.VisiblePosition = 2;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaMucLienQuan"].EditorComponent = cbu_MucLienQuan;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaMucLienQuan"].Hidden = false;
            
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["NoCo"].Header.Caption = "Nợ Có";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["NoCo"].Header.VisiblePosition = 5;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["NoCo"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaBoPhan"].Header.Caption = "Bộ Phận";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaBoPhan"].Header.VisiblePosition = 6;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaBoPhan"].EditorComponent = cmbu_Bophan;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaBoPhan"].Hidden = false;
        
        }
        #endregion 

        #region tlslblXoa_Click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdu_DanhSachMuc.DeleteSelectedRows();
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
            
        }
        #endregion 

        #region cbu_MucNganSach_InitializeLayout
        private void cbu_MucNganSach_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.cbu_MucNganSach.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cbu_MucNganSach.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cbu_MucNganSach.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                //x =  //= System.Drawing.w;//RoyalBlue
            }

            cbu_MucNganSach.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Header.Caption = "Mã Mục";
            cbu_MucNganSach.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Header.VisiblePosition = 1;
            cbu_MucNganSach.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Hidden = false;

            cbu_MucNganSach.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Header.Caption = "Tên Mục";
            cbu_MucNganSach.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Header.VisiblePosition = 2;
            cbu_MucNganSach.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Hidden = false;         
        }
        #endregion 

        #region cbu_HoatDong_InitializeLayout
        private void cbu_HoatDong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }
        #endregion

        private void cmbu_Bophan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_Bophan, "TenBoPhan");
            foreach (UltraGridColumn col in this.cmbu_Bophan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cmbu_Bophan.Width;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
        }
       
    }
}