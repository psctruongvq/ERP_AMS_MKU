using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ERP_Library;
using ERP_Library.Security;
using Infragistics.Win;
using DevExpress.XtraEditors;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP.Security
{
    public partial class frmUsers : Form
    {

        private ERP_Library.Security.UserList _data;

        private UserItem user;
        //private bool ischeck = true;
        public frmUsers()
        {
            InitializeComponent();
        }
        public string strStatus = "KHOA";
        PhanQuyenSuDungForm _phanQuyen = null;
        private void PhanQuyenThemSuaXoa()
        {
            _phanQuyen = PhanQuyenSuDungForm.GetQuyenSuDungFormTheoUser(CurrentUser.Info.UserID, (this.GetType().Namespace + "." + this.Name));
            itNew.Enabled = _phanQuyen.Them;
            itEdit.Enabled = _phanQuyen.Sua;
        }

        private void ReadOnlyConTrolByStatus(string _strStatus)
        {
            if (_strStatus == "" || _strStatus == "THEM" || _strStatus == "SUA")
            {
                itEdit.Visible = false;
                itSave.Visible = true;
                itNew.Visible = false;
                foreach (Control c in groupBox1.Controls)
                {

                    if (c is UltraTextEditor)
                    {
                        ((UltraTextEditor)c).ReadOnly = false;
                    }
                    else if (c is UltraCombo)
                    {
                        ((UltraCombo)c).ReadOnly = false;
                                           }
                    else if (c is MemoExEdit)
                    {
                        ((MemoExEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is CheckBox)
                    {
                        ((CheckBox)c).Enabled = true;
                    }

                }
                foreach (Control c in groupBox2.Controls)
                {
                    if (c is UltraTextEditor)
                    {
                        ((UltraTextEditor)c).ReadOnly = false;
                    }
                }
            }
            else if (_strStatus == "KHOA")
            {
                itEdit.Visible = true;
                itSave.Visible = false;
                itNew.Visible = true;
                foreach (Control c in groupBox1.Controls)
                {

                    if (c is UltraTextEditor)
                    {
                        ((UltraTextEditor)c).ReadOnly = true;
                    }
                    else if (c is UltraCombo)
                    {
                        ((UltraCombo)c).ReadOnly = true;
                    //  ((UltraCombo)c).DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
                    }
                    else if (c is MemoExEdit)
                    {
                        ((MemoExEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is CheckBox)
                    {
                        ((CheckBox)c).Enabled = false;
                    }


                }
                foreach (Control c in groupBox2.Controls)
                {
                    if (c is UltraTextEditor)
                    {
                        ((UltraTextEditor)c).ReadOnly = true;
                    }
                }
            }
            PhanQuyenThemSuaXoa();
        }

        private void itDong_Click(object sender, EventArgs e)
        {
            if(_data.IsValid) //phải Lưu trước khi Thoát vì phải EnCrypt 
                _data.Save();
            this.Close();
        }

        private void LoadData()
        {
            bdGroup.DataSource = ERP_Library.Security.GroupList.GetGroupList();
            bdCongTy.DataSource= ERP_Library.CongTyList.GetCongTyListChooseChild(
                congTy_DienThoai_FaxListChild: false,
                diaChi_CongTyListChild: false,
                congTy_Website_EmailListChild: false,
                congTy_NganHangListChild: false);
            cmbCongTy.DataSource = bdCongTy;

            bdBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanAll_ByMaCongTy();

            cmbBoPhan.SetDataBinding(bdBoPhan, "");
            HamDungChung.VisibleColumn(cmbCongTy.DisplayLayout.Bands[0], "MaCongTyQuanLy", "TenCongTy");
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");

            _data = ERP_Library.Security.UserList.GetUserListChooseChild(boPhanChild: false, phuCapChild: false, thulaoChild: false, userChildListChild: true);
            bdData.DataSource = _data;
        }

        private void SaveData()
        {
            try
            {
                bdData.EndEdit();
                //kiểm tra có 1 user admin
                if (!_data.KiemTra1Admin())
                {
                    MessageBox.Show("Bạn phải có ít nhất 1 user thuộc nhóm Admin", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                List<UserItem> userNewList = _data.Where(o => o.IsNew).ToList();
                _data.Save();
                AuToAdd_AppUserChild(userNewList);
                MessageBox.Show("Dữ liệu đã lưu thành công", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
            }
        }

        private void AuToAdd_AppUserChild(List<UserItem> userNewList)
        {
            if (userNewList == null) return;
            foreach (var user in userNewList)
            {
                if(user.GroupID == 38)
                {//chung Group -thi các user kế toán có thể nhìn thấy chứng từ của nhau
                    foreach (var adminItem in _data.Where(o => o.GroupID == 38 && o.MaCongTy == user.MaCongTy && o.UserID != user.UserID).ToList())
                    {   //user khác
                        var _user_Other = UserChild.NewUserChild();
                        _user_Other.UserID_Parent = adminItem.UserID;
                        _user_Other.User_Child = user.UserID;
                        if (adminItem.UserID != user.UserID)
                            adminItem.UserChild.Add(_user_Other);
                        //user mới
                        var _user_New = UserChild.NewUserChild();
                        _user_New.UserID_Parent = user.UserID;
                        _user_New.User_Child = adminItem.UserID;
                        if (adminItem.UserID != user.UserID)
                            user.UserChild.Add(_user_New);
                    }
                    //khác group - chỉ có group kế toán được thấy chứng từ của user mua hàng
                    foreach (var muaHangUser in _data.Where(o => (o.GroupID == 1002) && o.MaCongTy == user.MaCongTy).ToList())
                    {
                        var _user_Child = UserChild.NewUserChild();
                        _user_Child.UserID_Parent = user.UserID;
                        _user_Child.User_Child = muaHangUser.UserID;
                        user.UserChild.Add(_user_Child);
                    }
                }
                else if (user.GroupID == 1002)
                {//Nếu user mới thuộc group mua hàng các user kế toán thấy chứng từ của user đó
                    foreach (var adminItem in _data.Where(o => o.GroupID == 38 && o.MaCongTy == user.MaCongTy && o.UserID != user.UserID).ToList())
                    {   //user khác
                        var _user_Other = UserChild.NewUserChild();
                        _user_Other.UserID_Parent = adminItem.UserID;
                        _user_Other.User_Child = user.UserID;
                        if (adminItem.UserID != user.UserID)
                            adminItem.UserChild.Add(_user_Other);
                    }
                }
                _data.Save();
            }
        }
        private void itUndo_Click(object sender, EventArgs e)
        {
            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            LoadData();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            LoadData();
        }
        private bool validData()
        {
            bool kq = true;
            if (txtTenDangNhap.Text.Length == 0)
            {
                kq = false;
                MessageBox.Show("Tên Đăng Nhập Không Để Trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenDangNhap.Focus();
            }
          else if (txtMatKhau.Text.Length == 0)
            {
                kq = false;
                MessageBox.Show("Mật Khẩu Không Để Trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Focus();
            }
           else if (txtMaQL.Text.Length == 0)
            {
                kq = false;
                MessageBox.Show("Mã Quản Lý Không Để Trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaQL.Focus();
            }
            else if ((int)cmbNhom.Value == 0)
            {
                kq = false;
                MessageBox.Show("Nhóm Không Để Trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbNhom.Focus();
            }
            else if ((int?)cmbCongTy.Value == null)
            {
                kq = false;
                MessageBox.Show("Công Ty Không Để Trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCongTy.Focus();
            }
           

            memoExEdit_EmailDenTang.Text = Regex.Replace(memoExEdit_EmailDenTang.Text, @"\n+|\r+|\t+|\s+|^s+$", "");
            memoExEdit_EmailHRM.Text = Regex.Replace(memoExEdit_EmailHRM.Text, @"\n+|\r+|\t+|\s+|^s+$", "");

            return kq;
        }
        private void itSave_Click(object sender, EventArgs e)
        {
            if(validData())
                 SaveData();
            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
        }

        private void frmUsers_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_data != null && _data.IsDirty)
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaveData();
                }
        }

        private void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa người sử dụng này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

      
        private void cmbCongTy_ValueChanged(object sender, EventArgs e)
        {
            if (cmbCongTy.Value != null)
                cmbBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanListByMaCongTy((int)cmbCongTy.Value);
        }

        private void itNew_Click(object sender, EventArgs e)
        {
            this.strStatus = "THEM";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            bdData.AddNew();
        }

        private void itEdit_Click(object sender, EventArgs e)
        {
            this.strStatus = "SUA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            PSC_ERP.HamDungChung.ExportToExcelFromGridViewDev(grdViewData1);
        }
    }
}