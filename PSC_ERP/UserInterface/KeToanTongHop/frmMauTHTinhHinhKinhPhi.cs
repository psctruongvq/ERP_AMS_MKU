using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmMauTHTinhHinhKinhPhi : Form
    {

        BangTongHopTinhHinhKinhPhiList _BangTongHopTinhHinhKinhPhiList = BangTongHopTinhHinhKinhPhiList.NewBangTongHopTinhHinhKinhPhiList();

        BangTongHopTinhHinhKinhPhiList _BangTongHopTinhHinhKinhPhiCapMotList = BangTongHopTinhHinhKinhPhiList.NewBangTongHopTinhHinhKinhPhiList();
        byte _loaiMau = 7;

        #region Contructors

        public frmMauTHTinhHinhKinhPhi()
        {
            InitializeComponent();           
           // KhoiTao();
        }

        #endregion 

        public void ShowMauTHTinhHinhKinhPHi()
        {
            _loaiMau = 7;
            KhoiTao();
            this.Show();
        }


        public void ShowMauBaoCaoTinhHinhTangGiamTSCD()
        {
            _loaiMau = 8;
            KhoiTao();
            this.Text = "Báo Cáo Tình Hình Tăng, Giảm TSCĐ";
            this.Show();
        }

        #region Khởi Tạo
        private void KhoiTao()
        {
            _BangTongHopTinhHinhKinhPhiList = BangTongHopTinhHinhKinhPhiList.GetBangTongHopTinhHinhKinhPhiList(ERP_Library.Security.CurrentUser.Info.MaCongTy, _loaiMau );
            bangTongHopTinhHinhKinhPhiListBindingSource.DataSource = _BangTongHopTinhHinhKinhPhiList;            
            //_BCKQHoatDongKinhDoanhListComBo = BCKQHoatDongKinhDoanhList.GetBCKQHoatDongKinhDoanhList();
            
            //BCKQHoatDongKinhDoanhListBindingSource1.DataSource = _BCKQHoatDongKinhDoanhListComBo;
            HeThongTaiKhoan1 heThongTaiKhoan = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
            HeThongTaiKhoan1List _HeThongTaiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List();
            _HeThongTaiKhoanList.Insert(0, heThongTaiKhoan);
            //heThongTaiKhoan1ListBindingSource.DataSource = _HeThongTaiKhoanList;
            _BangTongHopTinhHinhKinhPhiCapMotList = BangTongHopTinhHinhKinhPhiList.GetBangTongHopTinhHinhKinhPhiList((byte)1, _loaiMau,ERP_Library.Security.CurrentUser.Info.MaCongTy);
            BangTongHopTinhHinhKinhPhi _bangTHKP = BangTongHopTinhHinhKinhPhi.NewBangTongHopTinhHinhKinhPhi();
            _bangTHKP.TenMucTaiKhoan = "Không chọn";
            _BangTongHopTinhHinhKinhPhiCapMotList.Insert(0, _bangTHKP);
            bangTongHopTinhHinhKinhPhiListBindingSource1.DataSource = _BangTongHopTinhHinhKinhPhiCapMotList;

        }
        #endregion

        #region Lưu Dữ Liệu

        private Boolean LuuDuLieu()
        {
            try
            {
                _BangTongHopTinhHinhKinhPhiList.ApplyEdit();
                _BangTongHopTinhHinhKinhPhiList.Save();              
                bangTongHopTinhHinhKinhPhiListBindingSource.DataSource = _BangTongHopTinhHinhKinhPhiList;              
            }
            catch
            {
                return false;
            }
            return true;

        }

        #endregion

        #region Kiểm tra dữ liệu

        private Boolean KiemTraDuLieu()
        {
            Boolean kq = true;
            if (txt_MaSo.Text == "")
            {
                MessageBox.Show(this, "Vui Lòng Nhập Mã Số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaSo.Focus();
                kq = false;
            }
            else if (txt_TenMucTK.Text == "")
            {
                MessageBox.Show(this, "Vui Lòng Nhập Tên Mục", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenMucTK.Focus();
                kq = false;
            }
            return kq;
        }

        private Boolean KiemTraDuLieu(BangTongHopTinhHinhKinhPhi bangTongHopTinhHinhKinhPhi)
        {
            Boolean kq = true;
            if (bangTongHopTinhHinhKinhPhi.MaSo == "")
            {
                MessageBox.Show(this, "Vui Lòng Nhập Mã Số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaSo.Focus();
                kq = false;
            }
            else if (bangTongHopTinhHinhKinhPhi.TenMucTaiKhoan == "")
            {
                MessageBox.Show(this, "Vui Lòng Nhập Tên Mục", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenMucTK.Focus();
                kq = false;
            }
            return kq;
        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (LuuDuLieu() == true)
            {
                MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _BangTongHopTinhHinhKinhPhiCapMotList = BangTongHopTinhHinhKinhPhiList.GetBangTongHopTinhHinhKinhPhiList((byte)1, _loaiMau, ERP_Library.Security.CurrentUser.Info.MaCongTy);
                BangTongHopTinhHinhKinhPhi _bangTHKP = BangTongHopTinhHinhKinhPhi.NewBangTongHopTinhHinhKinhPhi();
                _bangTHKP.TenMucTaiKhoan = "Không chọn";
                _BangTongHopTinhHinhKinhPhiCapMotList.Insert(0, _bangTHKP);
                bangTongHopTinhHinhKinhPhiListBindingSource1.DataSource = _BangTongHopTinhHinhKinhPhiCapMotList;
            }
            else
            {
                MessageBox.Show(this, "Cập Nhật Không Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
        }
        #endregion

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            if (_BangTongHopTinhHinhKinhPhiList.Count == 0)
            {
                BangTongHopTinhHinhKinhPhi bangTongHopTinhHinhKinhPhi = BangTongHopTinhHinhKinhPhi.NewBangTongHopTinhHinhKinhPhi();
                bangTongHopTinhHinhKinhPhi.SoTTSapXep = BangTongHopTinhHinhKinhPhi.LaySTTSapXepMax(_loaiMau) + 1;
                bangTongHopTinhHinhKinhPhi.SoTTTinhToan = BangTongHopTinhHinhKinhPhi.LaySoTTTinhToanMax(_loaiMau) + 1;
                bangTongHopTinhHinhKinhPhi.LoaiMau = _loaiMau; 
                _BangTongHopTinhHinhKinhPhiList.Add(bangTongHopTinhHinhKinhPhi);                
                grdu_DanhSachMuc.ActiveRow = grdu_DanhSachMuc.Rows[0];
            }
            else
            {
                if (KiemTraDuLieu() == true)
                {
                    BangTongHopTinhHinhKinhPhi bangTongHopTinhHinhKinhPhi = BangTongHopTinhHinhKinhPhi.NewBangTongHopTinhHinhKinhPhi();
                    bangTongHopTinhHinhKinhPhi.SoTTSapXep = BangTongHopTinhHinhKinhPhi.LaySTTSapXepMax(_loaiMau) + 1;
                    bangTongHopTinhHinhKinhPhi.SoTTTinhToan = BangTongHopTinhHinhKinhPhi.LaySoTTTinhToanMax(_loaiMau) + 1;
                    bangTongHopTinhHinhKinhPhi.LoaiMau = _loaiMau;
                    _BangTongHopTinhHinhKinhPhiList.Add(bangTongHopTinhHinhKinhPhi);
                    grdu_DanhSachMuc.ActiveRow = grdu_DanhSachMuc.Rows[_BangTongHopTinhHinhKinhPhiList.Count - 1];
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

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoTTSapXep"].Header.Caption = "Số Thứ Tự";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoTTSapXep"].Header.VisiblePosition = 1;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoTTSapXep"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaSo"].Header.Caption = "Mã Mục";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaSo"].Header.VisiblePosition = 2;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaSo"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["TenMucTaiKhoan"].Header.Caption = "Tên Mục";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["TenMucTaiKhoan"].Header.VisiblePosition = 3;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["TenMucTaiKhoan"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoTTTinhToan"].Header.Caption = "TT Tính Toán";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoTTTinhToan"].Header.VisiblePosition = 4;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["SoTTTinhToan"].Hidden = false;            

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["Loai"].Header.Caption = "Loại";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["Loai"].Header.VisiblePosition = 5;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["Loai"].Hidden = false;


            foreach (UltraGridColumn col in this.grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                //x =  //= System.Drawing.w;//RoyalBlue
            }

            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["SoHieu"].Header.Caption = "Tài Khoản";
            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["SoHieu"].Header.VisiblePosition = 1;
            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["SoHieu"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["CongTru"].Header.Caption = "Cộng Trừ";
            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["CongTru"].Header.VisiblePosition = 4;
            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["CongTru"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[1].Columns["NoCo"].Hidden = false;
         
        }
        #endregion 

        #region bt_ChiTiet_Click
        private void bt_ChiTiet_Click(object sender, EventArgs e)
        {
            //frmCT_MauBangBaoCao dlg = new frmCT_MauBangBaoCao((BangTongHopTinhHinhKinhPhi)(bangTongHopTinhHinhKinhPhiListBindingSource.Current), _loaiMau);
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{ 
            
            //}
        }
        #endregion 

        #region tlslblXoa_Click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdu_DanhSachMuc.DeleteSelectedRows();
        }
        #endregion 

        #region tlslblUndo_Click
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _BangTongHopTinhHinhKinhPhiList = BangTongHopTinhHinhKinhPhiList.GetBangTongHopTinhHinhKinhPhiList( ERP_Library.Security.CurrentUser.Info.MaCongTy, _loaiMau );
            bangTongHopTinhHinhKinhPhiListBindingSource.DataSource = _BangTongHopTinhHinhKinhPhiList;        
        }
        #endregion 

        private void grdu_DanhSachMuc_AfterRowInsert(object sender, RowEventArgs e)
        {
            BangTongHopTinhHinhKinhPhi bangTongHop = (BangTongHopTinhHinhKinhPhi)(bangTongHopTinhHinhKinhPhiListBindingSource.Current);
           
        }

        private void cbu_MucTaiKhoanCha_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.cbu_MucTaiKhoanCha.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cbu_MucTaiKhoanCha.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cbu_MucTaiKhoanCha.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                //x =  //= System.Drawing.w;//RoyalBlue
            }

            cbu_MucTaiKhoanCha.DisplayLayout.Bands[0].Columns["TenMucTaiKhoan"].Header.Caption = "Tên Mục";
            cbu_MucTaiKhoanCha.DisplayLayout.Bands[0].Columns["TenMucTaiKhoan"].Header.VisiblePosition = 3;
            cbu_MucTaiKhoanCha.DisplayLayout.Bands[0].Columns["TenMucTaiKhoan"].Hidden = false;
            cbu_MucTaiKhoanCha.DisplayLayout.Bands[0].Columns["TenMucTaiKhoan"].Width = 300;
      
                     
        }
             

    }
}