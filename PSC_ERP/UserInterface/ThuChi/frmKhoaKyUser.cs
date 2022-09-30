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
    public partial class frmKhoaKyUser : Form
    {
        KyList kyList;
        Ky ky;
        ERP_Library.Security.UserList userList,userListChuaKhoaSo;
        KhoaSo_UserList _khoaSoList,ChuaKhoaSo_UserList;
        int maKy = 0;
        public frmKhoaKyUser()
        {
            InitializeComponent();
            this.bindingSource1_khoaSoUser.DataSource = typeof(ERP_Library.KhoaSo_UserList);
            this.bindingSource1_Ky.DataSource = typeof(ERP_Library.KyList);
        }
        public frmKhoaKyUser(int maKy)
        {
            InitializeComponent();
            this.bindingSource1_khoaSoUser.DataSource = typeof(ERP_Library.KhoaSo_UserList);
            this.bindingSource1_Ky.DataSource = typeof(ERP_Library.KyList);
             CapNhatDanhSachNhanVienKhoaSo(maKy);
             cbKy.Value = maKy;
        }
        private void frmKhoaKyUser_Load(object sender, EventArgs e)
        {
            _khoaSoList = KhoaSo_UserList.GetKhoaSo_UserList(maKy);
            this.bindingSource1_khoaSoUser.DataSource = _khoaSoList;
            kyList = KyList.GetKyList();
            this.bindingSource1_Ky.DataSource = kyList;
            userList = ERP_Library.Security.UserList.GetUserList();
        }

        private void cbNhanVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
          //  FilterCombo f = new FilterCombo(cbNhanVien, "TenNhanVien");
            foreach (UltraGridColumn col in this.cbKy.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbKy.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;
            cbKy.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";
            cbKy.DisplayLayout.Bands[0].Columns["TenKy"].Header.VisiblePosition = 0;
            
            cbKy.DisplayLayout.Bands[0].Columns["KhoaSo"].Hidden = false;
            cbKy.DisplayLayout.Bands[0].Columns["KhoaSo"].Header.Caption = "Khóa Sổ";
            cbKy.DisplayLayout.Bands[0].Columns["KhoaSo"].Header.VisiblePosition = 1;
            
            cbKy.DisplayLayout.Bands[0].Columns["NgayBatDau"].Hidden = false;
            cbKy.DisplayLayout.Bands[0].Columns["NgayBatDau"].Header.Caption = "Ngày Bắt Đầu";
            cbKy.DisplayLayout.Bands[0].Columns["NgayBatDau"].Header.VisiblePosition = 2;
            cbKy.DisplayLayout.Bands[0].Columns["NgayBatDau"].Format = "dd/MM/yyyy";

            cbKy.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Hidden = false;
            cbKy.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Header.Caption = "Ngày Kết Thúc";
            cbKy.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Header.VisiblePosition = 3;
            cbKy.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Format = "dd/MM/yyyy";
        }
        private void CapNhatDanhSachNhanVienKhoaSo(int maKy)
        {
            ky = Ky.GetKy(maKy);
            userListChuaKhoaSo = ERP_Library.Security.UserList.GetUserListChuaPhanQuyenKyKeToan(maKy);
            ChuaKhoaSo_UserList = KhoaSo_UserList.NewKhoaSo_UserList();
            KhoaSo_User _khoaSo_User;
            foreach (ERP_Library.Security.UserItem user in userListChuaKhoaSo)
            {
                _khoaSo_User = KhoaSo_User.NewKhoaSo_User();
                _khoaSo_User.UserID = user.UserID;
                _khoaSo_User.KhoaSo = ky.KhoaSo;
                _khoaSo_User.MaKy = ky.MaKy;
                ChuaKhoaSo_UserList.Add(_khoaSo_User);
            }
            ChuaKhoaSo_UserList.ApplyEdit();
            ChuaKhoaSo_UserList.Save();

            _khoaSoList = KhoaSo_UserList.GetKhoaSo_UserList(maKy);
            this.bindingSource1_khoaSoUser.DataSource = _khoaSoList;
        }
        private void cbNhanVien_ValueChanged(object sender, EventArgs e)
        {
            if (cbKy.ActiveRow != null)
            {
                maKy = Convert.ToInt32(cbKy.Value);
            }
            CapNhatDanhSachNhanVienKhoaSo(maKy);
        }

        private void grdData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            //  FilterCombo f = new FilterCombo(cbNhanVien, "TenNhanVien");
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                col.CellActivation = Activation.NoEdit;
            }
            grdData.DisplayLayout.Bands[0].Columns["TenDangNhap"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["TenDangNhap"].Header.Caption = "Tên Đăng Nhập";
            grdData.DisplayLayout.Bands[0].Columns["TenDangNhap"].Header.VisiblePosition = 0;

            grdData.DisplayLayout.Bands[0].Columns["NgayBatDau"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["NgayBatDau"].Header.Caption = "Ngày Bắt Đầu";
            grdData.DisplayLayout.Bands[0].Columns["NgayBatDau"].Header.VisiblePosition = 1;
            grdData.DisplayLayout.Bands[0].Columns["NgayBatDau"].Format = "dd/MM/yyyy";

            grdData.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Header.Caption = "Ngày Kết Thúc";
            grdData.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Header.VisiblePosition = 2;
            grdData.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Format = "dd/MM/yyyy";

            grdData.DisplayLayout.Bands[0].Columns["KhoaSo"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["KhoaSo"].Header.Caption = "Khóa Sổ";
            grdData.DisplayLayout.Bands[0].Columns["KhoaSo"].Header.VisiblePosition = 3;
            grdData.DisplayLayout.Bands[0].Columns["KhoaSo"].CellActivation = Activation.AllowEdit;
        }

        private void chkAlldanhsach_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlldanhsach.Checked == true)
            {
                for (int i = 0; i < grdData.Rows.Count; i++)
                {
                    if (!grdData.Rows[i].Hidden == true && grdData.Rows[i].IsFilteredOut == false)
                    {
                        grdData.Rows[i].Cells["KhoaSo"].Value = (object)true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < grdData.Rows.Count; i++)
                {
                    grdData.Rows[i].Cells["KhoaSo"].Value = (object)false;
                }
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {

            this.bindingSource1_khoaSoUser.EndEdit();
            this.grdData.UpdateData();
            _khoaSoList.ApplyEdit();
            _khoaSoList.Save();
            MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _khoaSoList = KhoaSo_UserList.GetKhoaSo_UserList(maKy);
            this.bindingSource1_khoaSoUser.DataSource = _khoaSoList;
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _khoaSoList = KhoaSo_UserList.GetKhoaSo_UserList(maKy);
            this.bindingSource1_khoaSoUser.DataSource = _khoaSoList;
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
