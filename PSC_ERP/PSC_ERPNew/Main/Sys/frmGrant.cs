/*Công dụng:
*
*
*
*Người tạo: 
*Ngày tạo:
*Ngày cập nhât:
*/
using System;
using System.Linq;
using PSC_ERP_Common;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Factory;
using DevExpress.XtraEditors;

namespace PSC_ERPNew.Main.Sys
{
    public partial class frmGrant : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmGrant singleton_ = null;
        public static frmGrant Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmGrant();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner)
        {
            FormUtil.ShowForm_Helper(Singleton, owner);
        }
        #endregion

        //Private Member field
        #region Private Member field
        AppMenusRight_Factory _appMenusRight_Factory = null;
        IQueryable<app_users> _app_usersList = null;
        IQueryable<AppMenu> _appMenuList = null;
        app_users _userCurent = null;
        AppMenu _appMenuCurent = null;
        bool _formLoad = false;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmGrant()
        {
            InitializeComponent();
        }
        #endregion

        //Private Member Function
        #region Private Member Function
        private void GanBindingSource()
        {
            appMenuBindingSource.DataSource = _appMenuList;
            //
            appusersBindingSource.DataSource = _app_usersList;

            //Set bung các node của cây ra
            TreeList_DanhSachMenu.ExpandAll();
        }

        private Boolean DuocPhepLuu()
        {
            Boolean duocPhepLuu = true;
            if (_userCurent == null)
            {
                duocPhepLuu = false;
            }
            return duocPhepLuu;
        }

        private void ChangeFocus()
        {
            this.txtBlackHole.Focus();
        }


        private void SetupDaTa()
        {
            //Duyệt qua từng dòng menu
            foreach (AppMenu menu in _appMenuList)
            {
                //Lấy AppMenusRight theo menu và user hiện tại
                AppMenusRight appMenusRight = _appMenusRight_Factory.Get_AppMenusRightByMenuIDAndUserId(menu.ID, _userCurent.UserID);

                //if (menu.Chon == true && appMenusRight == null)//Phân quyền mới
                if (menu.Chon == true)//Phân quyền mới
                {
                    if (appMenusRight == null)//Phân quyền mới
                    {
                        //Khởi tạo đối tượng được quản lý bởi factory
                        appMenusRight = _appMenusRight_Factory.CreateManagedObject();
                        appMenusRight.MenuID = menu.ID;
                        appMenusRight.UserID = _userCurent.UserID;
                    }

                    if ((menu.FunctionID ?? 0) != 0)
                    {
                        //cập nhật lại quyền
                        appMenusRight.Them = menu.Them;
                        appMenusRight.Sua = menu.Sua;
                        appMenusRight.Xoa = menu.Xoa;
                    }
                }

                if (menu.Chon == false && appMenusRight != null)//Đã phân quyền
                {
                    //Tiến hành xóa dữ liệu 
                    if (appMenusRight != null)
                        _appMenusRight_Factory.DeleteObject(appMenusRight);
                }
            }
        }
        private void Save()
        {
            this.ChangeFocus();

            //kiểm tra dữ liệu trước khi lưu
            if (DuocPhepLuu())
            {
                try
                {
                    //Cài đặt dữ liệu trước khi lưu
                    SetupDaTa();

                    //Tiến hành lưu dữ liệu
                    _appMenusRight_Factory.SaveChangesWithoutTrackingLog();
                    //_appMenusRight_Factory.SaveChanges(BusinessCodeEnum.TSCD_PhanQuyenMenu.ToString());

                    DialogUtil.ShowSaveSuccessful();
                }
                catch (System.Exception ex)
                {
                    DialogUtil.ShowNotSaveSuccessful(ex.Message);
                    return;
                }
            }
        }

        private void CheckParent(int parentID)
        {
            foreach (AppMenu item in _appMenuList)
            {
                if (item.ID == parentID)
                {
                    item.Chon = true;
                    if (item.ParentID != null)
                        CheckParent(item.ParentID.Value);
                }
            }

        }
        private void CheckChild(int ID)
        {
            foreach (AppMenu item in _appMenuList)
            {
                if (item.ParentID == ID)
                {
                    item.Chon = true;
                    if (item.FunctionID != null)
                    {
                        item.Them = true;
                        item.Sua = true;
                        item.Xoa = true;
                    }
                    CheckChild(item.ID);
                }
            }

        }
        private void RemoveCheckChild(int ID)
        {
            foreach (AppMenu item in _appMenuList)
            {
                if (item.ParentID == ID)
                {
                    item.Chon = false;
                    if (item.FunctionID != null)
                    {
                        item.Them = false;
                        item.Sua = false;
                        item.Xoa = false;
                    }
                    RemoveCheckChild(item.ID);
                }
            }
        }
        #endregion
        //Event Method
        #region Event Method
        private void frmGrant_Load(object sender, EventArgs e)
        {
            _formLoad = true;
            //Khởi tạo factory
            _appMenusRight_Factory = AppMenusRight_Factory.New();

            //Lấy dữ liệu user
            _app_usersList = app_users_Factory.New().GetAll();
            _appMenuList = Menu_Factory.New().GetAll();

            //Gán bindingSource
            this.GanBindingSource();
            _formLoad = false;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Lưu dữ liệu
            Save();
        }
        private void appusersBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //Lấy user hiện tai
            _userCurent = appusersBindingSource.Current as app_users;

            if (_userCurent == null)
                return;
            //Lấy danh sách menu đã phân quyền by user
            //IQueryable<AppMenu> appMenuByUserList_DaPhanQuyen = Menu_Factory.New().Get_DanhSachAppMenuByUserID_DaPhanQuyen(_userCurent.UserID);
            IQueryable<AppMenusRight> appMenuByUserList_DaPhanQuyen = AppMenusRight_Factory.New().Get_DanhSachAppMenusRightByUserID(_userCurent.UserID);
            foreach (AppMenu menu in _appMenuList)//Duyệt qua từng dòng trong cây 
            {
                menu.Chon = false;
                menu.Them = false;
                menu.Sua = false;
                menu.Xoa = false;
                foreach (AppMenusRight menuByUser in appMenuByUserList_DaPhanQuyen)
                {
                    //  menu.Chon = true;//Check vào các menu đã phận quyền
                    if (menu.ID == menuByUser.MenuID)
                    {
                        menu.Chon = true;//Check vào các menu đã phận quyền
                        menu.Them = (menuByUser.Them ?? false);
                        menu.Sua = (menuByUser.Sua ?? false);
                        menu.Xoa = (menuByUser.Xoa ?? false);
                    }
                }
            }
            //Gán bindingsource
            this.GanBindingSource();
            if (!_formLoad)
                //Gán bindingsource
                this.GanBindingSource();
        }
        private void TreeList_DanhSachMenu_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            _appMenuCurent = null;
            if (Object.ReferenceEquals(e.Column, this.colChon))
            {
                //Lấy menu hiện tại
                _appMenuCurent = appMenuBindingSource.Current as AppMenu;
                if (_appMenuCurent == null)
                    return;

                foreach (AppMenu appMenu in _appMenuList)
                {
                    //----------------------------Bỏ check-------------------------------//
                    if (appMenu.ID == _appMenuCurent.ID && _appMenuCurent.Chon == true)
                    {
                        appMenu.Chon = false; //Bỏ check node hiện tại
                                              //Bỏ check tất cả nút con
                        if (appMenu.ID != 0)
                            RemoveCheckChild(appMenu.ID);

                        //Gán bindingSource
                        this.GanBindingSource();
                        TreeList_DanhSachMenu.Refresh();
                        return;
                    }

                    //-----------------------------Check---------------------------------//
                    if (appMenu.ID == _appMenuCurent.ID && _appMenuCurent.Chon == false)
                    {
                        appMenu.Chon = true; //Check node hiện tại
                                             //Check tất cả nút cha
                        if (appMenu.ParentID != null)
                            CheckParent(appMenu.ParentID.Value);

                        //Check tất cả nút con
                        if (appMenu.ID != 0)
                            CheckChild(appMenu.ID);

                        //Gán bindingSource
                        this.GanBindingSource();
                        TreeList_DanhSachMenu.Refresh();
                        return;
                    }
                }
            }

        }
        #endregion

        private void TreeList_DanhSachMenu_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {

            _appMenuCurent = appMenuBindingSource.Current as AppMenu;
            if (_appMenuCurent == null)
                return;

            if (Object.ReferenceEquals(e.Column, this.colThem))
            {              

                if (_appMenuCurent.Chon == false && _appMenuCurent.Them)
                    _appMenuCurent.Chon = _appMenuCurent.Them;
              
            }
            else if (Object.ReferenceEquals(e.Column, this.colSua))
            {               

                if (_appMenuCurent.Chon == false && _appMenuCurent.Sua)
                    _appMenuCurent.Chon = _appMenuCurent.Sua;
            }
            else if (Object.ReferenceEquals(e.Column, this.colXoa))
            {             

                if (_appMenuCurent.Chon == false && _appMenuCurent.Xoa)
                    _appMenuCurent.Chon = _appMenuCurent.Xoa;
            }

            TreeList_DanhSachMenu.Refresh();
        }
    }
}
