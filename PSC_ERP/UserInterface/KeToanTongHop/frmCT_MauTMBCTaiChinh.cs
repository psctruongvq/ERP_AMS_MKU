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
    public partial class frmCT_MauTMBCTaiChinh : Form
    {
        CT_CongThucTMBCTaiChinhList _CT_CongThucTMBCTaiChinhList = CT_CongThucTMBCTaiChinhList.NewCT_CongThucTMBCTaiChinhList();
        HeThongTaiKhoan1List _HeThongTaiKhoanList;
        HeThongTaiKhoan1List _HeThongTaiKhoanList1;
        CT_MucTMBCTaiChinhList _CT_MucTMBCTaiChinhList;
        byte _loai = 1;

        #region BoSung
        private byte _isNHNN = 0;
        private int _maThongTu = 0;
        #endregion//BoSung


        public frmCT_MauTMBCTaiChinh(CT_MucTMBCTaiChinh _CT_MucTMBCTaiChinh)
        {
            InitializeComponent();
            _CT_CongThucTMBCTaiChinhList = _CT_MucTMBCTaiChinh.CT_CongThucTMBCTaiChinhList;
            cTCongThucTMBCTaiChinhListBindingSource.DataSource = _CT_CongThucTMBCTaiChinhList;            
            KhoiTao();
        }

        public frmCT_MauTMBCTaiChinh(CT_MucTMBCTaiChinh _CT_MucTMBCTaiChinh,int maThongTu,byte isNHNN)
        {
            InitializeComponent();
            _maThongTu = maThongTu;
            _isNHNN = isNHNN;
            _CT_CongThucTMBCTaiChinhList = _CT_MucTMBCTaiChinh.CT_CongThucTMBCTaiChinhList;
            cTCongThucTMBCTaiChinhListBindingSource.DataSource = _CT_CongThucTMBCTaiChinhList;
            KhoiTao();
        }

    
        private void KhoiTao()
        {
            _HeThongTaiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List(Convert.ToByte(0));
            HeThongTaiKhoan1 heThongTaiKhoan = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
            heThongTaiKhoan.SoHieuTK = "None";
            heThongTaiKhoan.TenTaiKhoan = "None";
            _HeThongTaiKhoanList.Insert(0, heThongTaiKhoan);
            heThongTaiKhoan1ListBindingSource.DataSource = _HeThongTaiKhoanList;

            _HeThongTaiKhoanList1 = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List(Convert.ToByte(0));
            HeThongTaiKhoan1 heThongTaiKhoan1 = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
            heThongTaiKhoan1.SoHieuTK = "None";
            heThongTaiKhoan1.TenTaiKhoan = "None";
            _HeThongTaiKhoanList1.Insert(0, heThongTaiKhoan1);
            heThongTaiKhoan1ListBindingSource1.DataSource = _HeThongTaiKhoanList1;

            _CT_MucTMBCTaiChinhList = CT_MucTMBCTaiChinhList.GetCT_MucTMBCTaiChinhListbyMaThongTu(_maThongTu, _isNHNN); //CT_MucTMBCTaiChinhList.GetCT_MucTMBCTaiChinhList();
            CT_MucTMBCTaiChinh _CT_MucTMBCTaiChinh = CT_MucTMBCTaiChinh.NewCT_MucTMBCTaiChinh();            
            _CT_MucTMBCTaiChinh.TenMucCapHai = "None";
            _CT_MucTMBCTaiChinhList.Insert(0, _CT_MucTMBCTaiChinh);
            cTMucTMBCTaiChinhListBindingSource.DataSource = _CT_MucTMBCTaiChinhList;
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
        }
        #endregion

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            if (_CT_CongThucTMBCTaiChinhList.Count == 0)
            {
                 CT_CongThucTMBCTaiChinh _CT_CongThucTMBCTaiChinh = CT_CongThucTMBCTaiChinh.NewCT_CongThucTMBCTaiChinh();
                 _CT_CongThucTMBCTaiChinhList.Add(_CT_CongThucTMBCTaiChinh);                
                 grdu_DanhSachMuc.ActiveRow = grdu_DanhSachMuc.Rows[_CT_CongThucTMBCTaiChinhList.Count - 1];                 
            }
            else
            {
                if (KiemTraDuLieu() == true)
                {
                    CT_CongThucTMBCTaiChinh _CT_CongThucTMBCTaiChinh = CT_CongThucTMBCTaiChinh.NewCT_CongThucTMBCTaiChinh();
                    _CT_CongThucTMBCTaiChinhList.Add(_CT_CongThucTMBCTaiChinh);
                    grdu_DanhSachMuc.ActiveRow = grdu_DanhSachMuc.Rows[_CT_CongThucTMBCTaiChinhList.Count - 1];
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

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["LoaiTinh"].Header.Caption = "Loại";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["LoaiTinh"].Header.VisiblePosition = 3;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["LoaiTinh"].EditorComponent = cbeu_Loai;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["LoaiTinh"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["CongTru"].Header.Caption = "Cộng Trừ";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["CongTru"].Header.VisiblePosition = 4;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["CongTru"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaMucLienQuan"].Header.Caption = "Mục TK Liên Quan";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaMucLienQuan"].Header.VisiblePosition = 5;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaMucLienQuan"].EditorComponent = cbu_MucLienQuan;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["MaMucLienQuan"].Hidden = false;
            
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["NoCo"].Header.Caption = "Nợ Có";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["NoCo"].Header.VisiblePosition = 6;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["NoCo"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["ThuocCot"].Header.Caption = "Thuộc cột";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["ThuocCot"].Header.VisiblePosition = 7;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["ThuocCot"].Hidden = false;

            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["LayTheoLuyKe"].Header.Caption = "Lấy theo LK";
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["LayTheoLuyKe"].Header.VisiblePosition = 8;
            grdu_DanhSachMuc.DisplayLayout.Bands[0].Columns["LayTheoLuyKe"].Hidden = false;
        
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
                col.Hidden = true;
                //x =  //= System.Drawing.w;//RoyalBlue
            }
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["MaSo"].Header.Caption = "Mã Số";
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["MaSo"].Header.VisiblePosition = 1;
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["MaSo"].Hidden = false;

            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["TenMucCapHai"].Header.Caption = "Tên Mục";
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["TenMucCapHai"].Header.VisiblePosition = 1;
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["TenMucCapHai"].Hidden = false;

            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["capMuc"].Header.Caption = "Cấp Mục";
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["capMuc"].Header.VisiblePosition = 4;
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["capMuc"].Hidden = false;

            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            cbu_MucLienQuan.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;  
            
        }
        #endregion 

        #region cbu_TaiKhoan_ValueChanged
        private void cbu_TaiKhoan_ValueChanged(object sender, EventArgs e)
        {
            if (cbu_TaiKhoan.Value != null || Convert.ToInt32(cbu_TaiKhoan.Value) != 0)
            {
               // ((CT_CongThucTMBCTaiChinh)(cTCongThucTMBCTaiChinhListBindingSource.Current)).MaTaiKhoan = Convert.ToInt32(cbu_TaiKhoan.Value);
               // ((CT_CongThucTMBCTaiChinh)(cTCongThucTMBCTaiChinhListBindingSource.Current)).SoHieuTK = cbu_TaiKhoan.Text;
            }
        }
        #endregion       

        private void tlslblUndo_Click(object sender, EventArgs e)
        {

        }
    }
}