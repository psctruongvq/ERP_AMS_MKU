using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
namespace PSC_ERP
{
    public partial class frmTheoDoiDoiTuong : Form
    {
        DoiTuongAllList _doiTuongList;
        HeThongTaiKhoan1List _taiKhoanList;
        DoiTuongTheoDoiList _doiTuongTheoDoiList;
        bool childForm = false;
        int maTaiKhoan = 0;
        public frmTheoDoiDoiTuong()
        {
            InitializeComponent();
            _doiTuongTheoDoiList = DoiTuongTheoDoiList.GetDoiTuongTheoDoiList();
            this.bindingSource1_DoiTuongTheoDoi.DataSource = _doiTuongTheoDoiList;
            _doiTuongList = DoiTuongAllList.GetDoiTuongAllList();
            this.DoiTuong_BindingSource.DataSource = _doiTuongList;
            _taiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
            this.bindingSource1_TaiKhoan.DataSource = _taiKhoanList;
        }
        public frmTheoDoiDoiTuong(int maTaiKhoan)
        {
            childForm = true;
            InitializeComponent();
            this.maTaiKhoan = maTaiKhoan;
            _doiTuongTheoDoiList = DoiTuongTheoDoiList.GetDoiTuongTheoDoiListByTaiKhoan(maTaiKhoan);
            this.bindingSource1_DoiTuongTheoDoi.DataSource = _doiTuongTheoDoiList;
            _doiTuongList = DoiTuongAllList.GetDoiTuongAllList();
            this.DoiTuong_BindingSource.DataSource = _doiTuongList;
            _taiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
            this.bindingSource1_TaiKhoan.DataSource = _taiKhoanList;

        }
        public bool ThemORSua = false;
        private void frmTheoDoiDoiTuong_Load(object sender, EventArgs e)
        {
            // PHÂN QUYỀN TỪ FORM FRMTHEODOIDOITUONG
            if (!ThemORSua)
            {
                tlslblLuu.Enabled = false;
                tlslblXoa.Enabled = false;
                tlslblUndo.Enabled = false;
            }
        }
        
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
           grdData.UpdateData();
            bindingSource1_DoiTuongTheoDoi.EndEdit();
            foreach (DoiTuongTheoDoi dttd in _doiTuongTheoDoiList)
            {
                if (childForm == true)
                    dttd.MaTaiKhoan = maTaiKhoan;
                dttd.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                if (dttd.MaDoiTuong == 0 || dttd.MaTaiKhoan == 0)
                {
                    MessageBox.Show("Chọn Tài Khoản và Đối Tượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            _doiTuongTheoDoiList.ApplyEdit();
            _doiTuongTheoDoiList.Save();
            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            if (childForm == false)
            {
                grdData.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Hidden = false;
                grdData.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].EditorComponent = cbTaiKhoan;
                grdData.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Header.Caption = "Tài Khoản";
                grdData.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Header.VisiblePosition = 0;
                grdData.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Width = 250;
            }
            
            grdData.DisplayLayout.Bands[0].Columns["MaDoiTuong"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaDoiTuong"].EditorComponent = cbDoiTuong;
            grdData.DisplayLayout.Bands[0].Columns["MaDoiTuong"].Header.Caption = "Tên Đối Tượng";
            grdData.DisplayLayout.Bands[0].Columns["MaDoiTuong"].Header.VisiblePosition = 1;
            grdData.DisplayLayout.Bands[0].Columns["MaDoiTuong"].Width = 250;

           /// grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
           // grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
           // grdData.DisplayLayout.Bands[0].Columns["MaDoiTuong"].Header.VisiblePosition = 2;
        }

        private void cbDoiTuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(grdData, "MaDoiTuong", "TenDoiTuong");
            foreach (UltraGridColumn col in this.cbDoiTuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbDoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Hidden = false;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.Caption = "Tên Khách Hàng";
            cbDoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.VisiblePosition = 0;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Width = 250;

            cbDoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Hidden = false;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Header.Caption = "Địa Chỉ";
            cbDoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Header.VisiblePosition = 2;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Width = 250;

            cbDoiTuong.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Hidden = false;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Header.Caption = "Mã Quản Lý";
            cbDoiTuong.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Header.VisiblePosition = 1;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Width = 250;
        }

        private void cbTaiKhoan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(grdData, "MaTaiKhoan", "SoHieuTK");
            foreach (UltraGridColumn col in this.cbTaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            cbTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            cbTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 0;
            cbTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Width = 250;

            cbTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            cbTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            cbTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 1;
            cbTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 250;

        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            if (childForm == false)
                _doiTuongTheoDoiList = DoiTuongTheoDoiList.GetDoiTuongTheoDoiList();
            else
                _doiTuongTheoDoiList = DoiTuongTheoDoiList.GetDoiTuongTheoDoiListByTaiKhoan(maTaiKhoan);
            this.bindingSource1_DoiTuongTheoDoi.DataSource = _doiTuongTheoDoiList;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
