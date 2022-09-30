using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win;
using Infragistics.Shared;
using Infragistics.Win.UltraWinGrid;
//long 

namespace PSC_ERP
{
    public partial class frmTaiKhoanKetChuyen : Form
    {

        TaiKhoanKetChuyenList _TaiKhoanKetChuyenList = TaiKhoanKetChuyenList.NewTaiKhoanKetChuyenList();

        #region Contructors
        public frmTaiKhoanKetChuyen()
        {
            InitializeComponent();
            KhoiTao();
        }
        #endregion 

        #region Khởi Tạo
        private void KhoiTao()
        {

            _TaiKhoanKetChuyenList = TaiKhoanKetChuyenList.GetTaiKhoanKetChuyenListByNguoiLap();
            taiKhoanKetChuyenListBindingSource.DataSource = _TaiKhoanKetChuyenList;            

            HeThongTaiKhoan1 heThongTaiKhoan = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
            HeThongTaiKhoan1List _HeThongTaiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List();
            _HeThongTaiKhoanList.Insert(0, heThongTaiKhoan);
            heThongTaiKhoan1ListBindingSource.DataSource = _HeThongTaiKhoanList;


            HeThongTaiKhoan1 heThongTaiKhoan1 = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
            HeThongTaiKhoan1List _HeThongTaiKhoanList1 = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List();
            _HeThongTaiKhoanList1.Insert(0, heThongTaiKhoan1);
            heThongTaiKhoan1ListBindingSource1.DataSource = _HeThongTaiKhoanList1;

            //Lấy dữ liệu cho loại kết chuyển
            LoaiKetChuyenList loaiKetChuyenList = LoaiKetChuyenList.GetLoaiKetChuyenList();
            LoaiKetChuyen_BindingSource.DataSource = loaiKetChuyenList;

            //Lấy bộ phận
            BoPhanList boPhanList = BoPhanList.GetBoPhanListBy_All();
            BoPhan boPhan_Insert = BoPhan.NewBoPhan(0, "Tất Cả");
            boPhanList.Insert(0, boPhan_Insert);
            BoPhan_BindingSource.DataSource = boPhanList;
        }
        #endregion

        #region Lưu Dữ Liệu

        private Boolean LuuDuLieu()
        {
            try
            {
                _TaiKhoanKetChuyenList.ApplyEdit();
                _TaiKhoanKetChuyenList.Save();
                BangCanDoiKeToan bangCanDoiKeToan = BangCanDoiKeToan.NewBangCanDoiKeToan();
                taiKhoanKetChuyenListBindingSource.DataSource = _TaiKhoanKetChuyenList;                
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
            if (num_SoThuTu.Value == null)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Số Thứ Tự", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                num_SoThuTu.Focus();
                kq = false;
            }
            //else if (txt_TenMucTK.Text == "")
            //{
            //    MessageBox.Show(this, "Vui Lòng Nhập Tên Mục", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txt_TenMucTK.Focus();
            //    kq = false;
            //}
            return kq;
        }

        private Boolean KiemTraDuLieu(TaiKhoanKetChuyen taiKhoanKetChuyen)
        {
            Boolean kq = true;
            if (taiKhoanKetChuyen.SoTT == 0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Số Thứ Tự", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                num_SoThuTu.Focus();
                kq = false;
            }
            //else if (taiKhoanKetChuyen.TenMucTaiKhoan == "")
            //{
            //    MessageBox.Show(this, "Vui Lòng Nhập Tên Mục", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txt_TenMucTK.Focus();
            //    kq = false;
            //}
            return kq;
        }
        #endregion 

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            if (_TaiKhoanKetChuyenList.Count == 0)
            {
                TaiKhoanKetChuyen taiKhoanKetChuyen= TaiKhoanKetChuyen.NewTaiKhoanKetChuyen(0);
                taiKhoanKetChuyen.MaNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                taiKhoanKetChuyen.SoTT = _TaiKhoanKetChuyenList.Count + 1;
                _TaiKhoanKetChuyenList.Add(taiKhoanKetChuyen);
                grdu_DanhSachTKKC.ActiveRow = grdu_DanhSachTKKC.Rows[_TaiKhoanKetChuyenList.Count - 1];
            }
            else
            {
                if (KiemTraDuLieu() == true)
                {
                    TaiKhoanKetChuyen taiKhoanKetChuyen = TaiKhoanKetChuyen.NewTaiKhoanKetChuyen(0);
                    taiKhoanKetChuyen.MaNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                    taiKhoanKetChuyen.SoTT = _TaiKhoanKetChuyenList.Count + 1;
                    _TaiKhoanKetChuyenList.Add(taiKhoanKetChuyen);                    
                    grdu_DanhSachTKKC.ActiveRow = grdu_DanhSachTKKC.Rows[_TaiKhoanKetChuyenList.Count - 1];
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

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (LuuDuLieu() == true)
            {
                MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "Cập Nhật Không Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        #endregion 

        #region tlslblUndo_Click
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _TaiKhoanKetChuyenList = TaiKhoanKetChuyenList.GetTaiKhoanKetChuyenListByNguoiLap();
            taiKhoanKetChuyenListBindingSource.DataSource = _TaiKhoanKetChuyenList;
        }
        #endregion

        #region grdu_DanhSachTKKC_InitializeLayout
        private void grdu_DanhSachTKKC_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.grdu_DanhSachTKKC.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DanhSachTKKC.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = false;
                //x =  //= System.Drawing.w;//RoyalBlue
            }

            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["MaTaiKhoanNhanKC"].Hidden = true;
            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["MaTaiKhoanKC"].Hidden = true;
            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["MaCongThucKC"].Hidden = true;
            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["SoHieuTaiKhoan"].Hidden = true;
            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["Check"].Hidden = true;
            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = true;
            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;

            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["SoTT"].Header.Caption = "Số Thứ Tự";
            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["SoTT"].Header.VisiblePosition = 1;
            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["SoTT"].Width = 75;

            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["MaLoaiKetChuyen"].EditorComponent = cbu_LoaiKetChuyen;
            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["MaLoaiKetChuyen"].Header.Caption = "Loại Kết Chuyển";
            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["MaLoaiKetChuyen"].Header.VisiblePosition = 2;
            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["MaLoaiKetChuyen"].Width = 200; //cbu_LoaiKetChuyen.Width;

            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["TenTaiKhoanKC"].Header.Caption = "Tên TK Kết Chuyển";
            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["TenTaiKhoanKC"].Header.VisiblePosition = 3;
            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["TenTaiKhoanKC"].Width = 120;

            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["TenTaiKhoanNhanKC"].Header.Caption = "Tên Tài Khoản Nhận";
            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["TenTaiKhoanNhanKC"].Header.VisiblePosition = 4;
            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["TenTaiKhoanNhanKC"].Width = 120;



            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["KetChuyenNoCo"].Header.Caption = "Kết Chuyển Nợ Có";
            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["KetChuyenNoCo"].Header.VisiblePosition = 5;
            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["KetChuyenNoCo"].EditorComponent = cbu_KetChuyenNoCo;
            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["KetChuyenNoCo"].Width = 100;

            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["MaBoPhan"].EditorComponent = cbu_BoPhan;
            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["MaBoPhan"].Header.Caption = "Bộ Phận";
            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["MaBoPhan"].Header.VisiblePosition = 6;
            grdu_DanhSachTKKC.DisplayLayout.Bands[0].Columns["MaBoPhan"].Width = cbu_BoPhan.Width;

        }
        #endregion 

        #region cbu_TKKetChuyen_InitializeLayout
        private void cbu_TKKetChuyen_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbu_TKKetChuyen.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbu_TKKetChuyen.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            cbu_TKKetChuyen.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            cbu_TKKetChuyen.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;

            cbu_TKKetChuyen.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            cbu_TKKetChuyen.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 100;
            cbu_TKKetChuyen.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;
            cbu_TKKetChuyen.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
        }
        #endregion 

        #region cbu_TaiKhoanNhanKC_InitializeLayout
        private void cbu_TaiKhoanNhanKC_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbu_TaiKhoanNhanKC.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbu_TaiKhoanNhanKC.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            cbu_TaiKhoanNhanKC.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            cbu_TaiKhoanNhanKC.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;

            cbu_TaiKhoanNhanKC.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            cbu_TaiKhoanNhanKC.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 100;
            cbu_TaiKhoanNhanKC.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;
            cbu_TaiKhoanNhanKC.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
        }
        #endregion        

        #region cbu_TKKetChuyen_Leave
        private void cbu_TKKetChuyen_Leave(object sender, EventArgs e)
        {
            if (cbu_TKKetChuyen.Value != null && Convert.ToInt32(cbu_TKKetChuyen.Value) != 0 && taiKhoanKetChuyenListBindingSource.Current!=null)
            {
                ((TaiKhoanKetChuyen)(taiKhoanKetChuyenListBindingSource.Current)).MaTaiKhoanKC = Convert.ToInt32(cbu_TKKetChuyen.Value);
                ((TaiKhoanKetChuyen)(taiKhoanKetChuyenListBindingSource.Current)).SoHieuTaiKhoan = cbu_TKKetChuyen.ActiveRow.Cells["SoHieuTK"].Value.ToString();
                ((TaiKhoanKetChuyen)(taiKhoanKetChuyenListBindingSource.Current)).TenTaiKhoanKC = cbu_TKKetChuyen.ActiveRow.Cells["TenTaiKhoan"].Value.ToString();
            }
        }
        #endregion 

        #region cbu_TaiKhoanNhanKC_Leave
        private void cbu_TaiKhoanNhanKC_Leave(object sender, EventArgs e)
        {
            if (cbu_TaiKhoanNhanKC.Value != null && Convert.ToInt32(cbu_TaiKhoanNhanKC.Value) != 0 && taiKhoanKetChuyenListBindingSource.Current != null)
            {
                ((TaiKhoanKetChuyen)(taiKhoanKetChuyenListBindingSource.Current)).MaTaiKhoanNhanKC = Convert.ToInt32(cbu_TaiKhoanNhanKC.Value);
                ((TaiKhoanKetChuyen)(taiKhoanKetChuyenListBindingSource.Current)).TenTaiKhoanNhanKC = cbu_TaiKhoanNhanKC.ActiveRow.Cells["TenTaiKhoan"].Value.ToString();
            }
        }
        #endregion 

        private void cbu_LoaiKetChuyen_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbu_LoaiKetChuyen.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbu_LoaiKetChuyen.DisplayLayout.Bands[0].Columns["TenLoaiKetChuyen"].Header.Caption = "Tên Loại Kết Chuyển";
            cbu_LoaiKetChuyen.DisplayLayout.Bands[0].Columns["TenLoaiKetChuyen"].Width = cbu_LoaiKetChuyen.Width;
            cbu_LoaiKetChuyen.DisplayLayout.Bands[0].Columns["TenLoaiKetChuyen"].Header.VisiblePosition = 1;
            cbu_LoaiKetChuyen.DisplayLayout.Bands[0].Columns["TenLoaiKetChuyen"].Hidden = false;
   
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_DanhSachTKKC.Selected.Rows.Count == 0)
            {
                MessageBox.Show("Chọn dòng cần xóa.","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            grdu_DanhSachTKKC.DeleteSelectedRows();
        }

        private void frmTaiKhoanKetChuyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                tlslblLuu_Click(sender,e);
            }
            if (e.Control && e.KeyCode == Keys.D)
            {
                tlslblXoa_Click(sender, e);
            }
            if (e.Alt && e.KeyCode == Keys.X)
            {
                tlslblLuu_Click(sender, e);
            }
            if (e.Alt && e.KeyCode == Keys.N)
            {
                tlslblThem_Click(sender, e);
            }
        }

        private void cbu_BoPhan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbu_BoPhan, "MaBoPhanQL");
            foreach (UltraGridColumn col in this.cbu_BoPhan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;

            cbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";

            cbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;

            cbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cbu_BoPhan.Width;
        }   
    }
}