using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using ERP_Library.Security;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace PSC_ERP
{
    public partial class frmGiayBaoCo_Edit : Form
    {
        #region Properties
        private bool OK = false;
        private GiayBaoCo _data;
        private NganHangList _nganHangList;
        UserList _userList;
        private bool Loai;
        private bool IsEdit = false;
        #endregion

        #region Loads
        public frmGiayBaoCo_Edit()
        {
            InitializeComponent();
            Loai = true;
            Load_Form();
        }

        public frmGiayBaoCo_Edit(bool LoaiTruyen, bool isEdit)
        {
            InitializeComponent();
            Loai = LoaiTruyen;
            IsEdit = isEdit;
            if (Loai)
            {
                this.Text = "Phí ngân hàng";
                lblTaiKhoan.Text = "Tài khoản chuyển";
            }
            else
            {
                this.Text = "Giấy báo có";
                lblTaiKhoan.Text = "Tài khoản nhận";
            }
            Load_Form();
        }

        private void cmb_NganHang_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmb_DoiTac.DisplayLayout.Bands[0],
            new string[2] { "MaQLDoiTac", "TenDoiTac" },
            new string[2] { "Mã Đối Tác", "Tên Đối Tác" },
            new int[2] { 150, 350 },
            new Control[2] { null, null },
            new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[2] { false, false });

            //màu và font chữ
            foreach (UltraGridColumn col in this.cmb_DoiTac.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                //col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                col.CellAppearance.TextHAlign = HAlign.Left;
            }

            FilterCombo filter = new FilterCombo(cmb_DoiTac, "TenDoiTac");
        }

        private void cmb_NguoiLap_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmb_NguoiLap.DisplayLayout.Bands[0],
            new string[3] { "TenNhanVien", "TenDangNhap", "TenBoPhan" },
            new string[3] { "Nhân Viên", "Tên Đăng Nhập", "Bộ Phận" },
            new int[3] { 150, 250, 250 },
            new Control[3] { null, null, null },
            new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[3] { false, false, false });

            //màu và font chữ
            foreach (UltraGridColumn col in this.cmb_DoiTac.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                //col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                col.CellAppearance.TextHAlign = HAlign.Left;
            }

            FilterCombo filter = new FilterCombo(cmb_NguoiLap, "TenNhanVien");
        }
        #endregion

        #region Process
        private void Load_Form()
        {
            //DoiTacList doitacList = DoiTacList.GetDoiTacList(" ", false);
            DoiTacList doitacList = DoiTacList.GetDoiTacList(" ", 0);
            DoiTac _doiTac = DoiTac.NewDoiTac(0, "Chưa chọn");
            doitacList.Insert(0, _doiTac);
            DoiTac_bindingSource.DataSource = doitacList;

            _userList = UserList.GetUserList_GBC();
            UserItem _userItem = UserItem.NewUserItem("Không chọn");
            _userList.Insert(0, _userItem);
            NguoiLapListBindingSouce.DataSource = _userList;

            LoaiTienList loaiTienList = LoaiTienList.GetLoaiTienList();
            //LoaiTien loaiTien = LoaiTien.NewLoaiTien("Chưa chọn");
            //loaiTienList.Insert(0, loaiTien);
            loaiTienListBindingSource.DataSource = loaiTienList;

            cmbTaiKhoan.DataSource = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList();
        }

        public bool ShowEdit(GiayBaoCo data)
        {
            _data = data;
            bdData.DataSource = _data;

            //Nếu là chỉnh sửa
            if (Loai)
            {
                mnu_TyGia.Value = _data.TyGia;
            }

            this.ShowDialog();
            return OK;
        }
        #endregion

        #region Event
        private void btnDongY_Click(object sender, EventArgs e)
        {
            _data.TyGia = Convert.ToDecimal(mnu_TyGia.Value);
            bdData.EndEdit();
            if (txtDienGiai.Text == "")
            {
                MessageBox.Show("Diễn giải không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbTaiKhoan.Value == null || (int)cmbTaiKhoan.Value == 0)
            {
                MessageBox.Show("Ngân hàng nhận không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OK = true;
            this.Close();
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            OK = false;
            this.Close();
        }

        private void cmbTaiKhoan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbTaiKhoan.SelectedRow != null)
            {
                txtNganHang.Text = ((ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild)cmbTaiKhoan.SelectedRow.ListObject).TenNganHang;
            }
            else
                txtNganHang.Text = "";
        }
        #endregion        

        private void cmb_LoaiTien_ValueChanged(object sender, EventArgs e)
        {
            if (cmb_LoaiTien.ActiveRow != null && IsEdit == false)
            {
                mnu_TyGia.Value = Convert.ToDecimal(cmb_LoaiTien.ActiveRow.Cells["TiGiaQuyDoi"].Value);
            }
            if (IsEdit)
            {
                mnu_TyGia.Value = _data.TyGia;
            }
        }
    }
}