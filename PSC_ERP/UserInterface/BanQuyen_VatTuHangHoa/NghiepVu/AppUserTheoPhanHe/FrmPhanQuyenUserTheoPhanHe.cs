using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraEditors.Repository;
using System.IO;
using System.Diagnostics;
using ERP_Library.Security;

namespace PSC_ERP
{
    public partial class FrmPhanQuyenUserTheoPhanHe : DevExpress.XtraEditors.XtraForm
    {
        app_UserPhanHeEditableRootList _appUserPhanHeList = app_UserPhanHeEditableRootList.Newapp_UserPhanHeEditableRootList();
        string _description;
        int _userid;
        int _maPhanHe;

        public FrmPhanQuyenUserTheoPhanHe()
        {
            InitializeComponent();

        }

        public void ShowPhanHeVatTuHangHoa()
        {
            _description = "Phân Hệ Vật Tư Hàng Hóa";
            _maPhanHe = 1;//Đây là phân hệ vật tư
            KhoiTao();
            DesignGridView_VatTuHangHoa();
            this.Text = "Phân Quyền User Thuộc Phân Hệ Vật Tư Hàng Hóa";
            this.WindowState = FormWindowState.Normal;
            this.Show();

        }

        public void ShowPhanHeBanQuyen()
        {
            _description = "Phân Hệ Bản Quyền";
            _maPhanHe = 2;//Đây là phân hệ Bản Quyền
            KhoiTao();
            DesignGridView_VatTuHangHoa();
            this.Text = "Phân Quyền User Thuộc Phân Hệ Bản Quyền";
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void KhoiTao()
        {
            bsAppUserPhanHeList.DataSource = typeof(app_UserPhanHeEditableRootList);
            bsUserList.DataSource = typeof(UserList);
            bsUserListForGrid.DataSource = typeof(UserList);

            UserList userList = UserList.GetUserList_GBC();//UserList.GetUserList();
            UserItem user = UserItem.NewUserItem("<Không chọn>");
            userList.Insert(0, user);
            bsUserList.DataSource = userList;

            bsUserListForGrid.DataSource = userList;

            //UserList userListForGrid = UserList.GetUserList();
            //UserItem userforGrid = UserItem.NewUserItem("<Không chọn>");
            //userListForGrid.Insert(0, userforGrid);
            //bsUserListForGrid.DataSource = userList;


            bsAppUserPhanHeList.DataSource = _appUserPhanHeList;
            gridControl1.DataSource = bsAppUserPhanHeList;
        }
        #region Function
        private void GetThongTin()
        {
            if (grdLu_UserID.EditValue != null)
            {
                int userID;
                if (int.TryParse(grdLu_UserID.EditValue.ToString(), out userID))
                {
                    _userid = userID;
                }
                else
                {
                   _userid = 0;  
                }
            }
            else
            {
                _userid = 0;
            }
        }

        private void LoadData()
        {
            GetThongTin();
            _appUserPhanHeList = app_UserPhanHeEditableRootList.Getapp_UserPhanHeEditableRootList(_maPhanHe, _userid);
            
            bsAppUserPhanHeList.DataSource = _appUserPhanHeList;
        }

        private void DesignGridView_VatTuHangHoa()
        {

            HamDungChung.InitGridViewDev(gridView1, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, true, true, false);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "NguoiLap" },
                                new string[] { "Người lập" },
                                             new int[] { 150 });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "NguoiLap" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.NewRowGridViewDev(gridView1);

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            //
            RepositoryItemGridLookUpEdit userList_GrdLU = new RepositoryItemGridLookUpEdit();
            userList_GrdLU.DataSource = bsUserListForGrid;
            userList_GrdLU.DisplayMember = "TenDangNhap";
            userList_GrdLU.ValueMember = "UserID";
            HamDungChung.InitRepositoryItemGridLookUpDev(userList_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(userList_GrdLU, new string[] { "TenDangNhap" }, new string[] { "Tên đăng nhập" }, new int[] { 150 }, true);
            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "NguoiLap", userList_GrdLU);
            gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            gridView1.GroupPanelText = "Danh Sách Người Lập Được Quản Lý";
            
            //gridView1.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick);
        }

        private bool KiemTraDuLieuTruocKhiLuu()
        {
            
            if(_appUserPhanHeList.Count>0)
            {
                foreach (app_UserPhanHeEditableSwitchable item in _appUserPhanHeList)
                {
                    if(item.NguoiLap==0)
                    {
                        MessageBox.Show("Vui lòng nhập vào thông người lập được quản lý bởi User trên", "Thông Báo");
                        return false;
                    }
                }
                if (_maPhanHe == 0)
                {
                    MessageBox.Show("Form hiển thị không đúng, không thể thực hiện", "Thông Báo");
                    return false;
                }
                GetThongTin();
                if (_userid == 0)
                {
                    MessageBox.Show("Vui lòng chọn thông tin User cần phân quyền", "Thông Báo");
                    return false;
                }
                _description = txtE_Description.Text;
            }
            return true;
        }



        #endregion

        #region Event

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                    HamDungChung.DeleteSelectedRowsGridViewDev(gridView1, e);
        }
        private void FrmPhanQuyenUserTheoPhanHe_Load(object sender, EventArgs e)
        {
            txtE_Description.Text = _description;
        }
        #endregion

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtEFocus.Focus();
            if(KiemTraDuLieuTruocKhiLuu())
            {
                foreach (app_UserPhanHeEditableSwitchable item in _appUserPhanHeList)
                {
                    item.MaPhanHe = _maPhanHe;
                    item.UserID = _userid;
                    item.Description = _description;
                }

                try
                {
                    _appUserPhanHeList.ApplyEdit();
                    _appUserPhanHeList.Save();
                    MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void grdLu_UserID_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        
    }
}