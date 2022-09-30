using DevExpress.XtraEditors;
using ERP_Library;
using PSC_ERP_Common;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PSC_ERPNew.Main.Sys
{
    public partial class FormPhanQuyenTheoNhom  : XtraForm
    {

        app_groups _appGroup= app_groups.Newapp_groups();
        app_groupsList _appGroupList;
         
        public FormPhanQuyenTheoNhom()
        {
            InitializeComponent();
        }
     
        private void frmGrantGroup_Load(object sender, EventArgs e)
        {
            // load data
            LoadDuLieu();
            TreeList_DanhSachMenu.ExpandAll();
            
        }

        private void LoadDuLieu()
        {
            // lấy dữ liệu danh sách group 
            // fetch danh sách menu 
            using (DialogUtil.Wait())
            {
                _appGroupList = app_groupsList.Getapp_groupsList();
            }
            bding_Group.DataSource = _appGroupList;
            if (bding_Group.Position > -1)
                bding_appMenuList.DataSource = _appGroupList.ElementAt(bding_Group.Position).AppMenuGroupList;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                using (DialogUtil.WaitForSave())
                {
                    txtBlackHole.Focus();
                    ProcessTabKey(true);
                    _appGroupList.Save();
                }
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show("- Lỗi: " + ex.ToString(),"Lưu thất bại", MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }

        private void bding_Group_PositionChanged(object sender, EventArgs e)
        {
            if (bding_Group.Position > -1)
                bding_appMenuList.DataSource = _appGroupList.ElementAt(bding_Group.Position).AppMenuGroupList;
        }
        

        
        private void RemoveCheckChild(int ID,bool Chon=false , bool Them = false, bool Sua = false, bool Xoa = false)
        {
            foreach (AppMenuGroup item in _appGroupList.ElementAt(bding_Group.Position).AppMenuGroupList)
            {
                if (item.ParentID == ID)
                {
                    if(Chon) // cột chọn
                    {
                        item.Chon = false; item.Sua = false;
                        item.Them = false; item.Xoa = false;
                    }
                    if (Them) // cột thêm
                        item.Them = false;
                    if (Sua)  // cột sửa
                        item.Sua = false;
                    if (Xoa) // cột xóa
                        item.Xoa = false;
                    RemoveCheckChild(item.ID,Chon,Them, Sua, Xoa);
                }
            }
        }
        private void RemoveCheckParent(int parentID, bool Chon = false , bool Them = false, bool Sua = false, bool Xoa = false,int IDChon=0)
        {
            foreach (AppMenuGroup item in _appGroupList.ElementAt(bding_Group.Position).AppMenuGroupList)
            {
                if (item.ID == parentID)
                {
                    if (Chon)// check trên cột Xem
                    {
                        if( KiemTraCheckChild(item.ID, IDChon, true))// checkchild cột chọn
                            item.Chon = false;
                        if (KiemTraCheckChild(item.ID, IDChon, false, true)) // checkchild cột thêm
                            item.Them = false;
                        if (KiemTraCheckChild(item.ID, IDChon, false, false, true))// checkchild cột sửa
                            item.Sua = false;
                        if (KiemTraCheckChild(item.ID, IDChon, false, false, false, true))//checkchild cột xóa
                            item.Xoa = false;
                    }
                    if (Them && KiemTraCheckChild(item.ID,IDChon, false, true))// check trên cột Thêm
                        item.Them = false;
                    if (Sua && KiemTraCheckChild(item.ID,IDChon, false, false,true))// check trên cột sửa
                        item.Sua = false;
                    if (Xoa && KiemTraCheckChild(item.ID,IDChon, false, false, false, true))// check trên cột xóa
                        item.Xoa = false;
                    if (item.ParentID != null)
                        RemoveCheckParent(item.ParentID, Chon, Them, Sua, Xoa);
                }
            }
        }
        private bool KiemTraCheckChild(int ID,int IDChon=0,bool Chon=false, bool Them = false, bool Sua = false, bool Xoa = false)
        {
            bool kq = true;
            foreach (AppMenuGroup item in _appGroupList.ElementAt(bding_Group.Position).AppMenuGroupList)
            {
                if (item.ParentID == ID && item.ID!=IDChon)
                {
                    if (Chon && item.Chon){ kq = false; break;}
                    if (Them && item.Them){ kq = false; break;}
                    if (Sua && item.Sua){ kq = false; break;}
                    if (Xoa && item.Xoa){ kq = false; break;}
                }
            }
            return kq;
        }
        private void CheckParent(int parentID, bool Them= false, bool Sua = false, bool Xoa = false)
        {
            foreach (AppMenuGroup item in _appGroupList.ElementAt(bding_Group.Position).AppMenuGroupList)
            {
                if (item.ID == parentID)
                {
                    item.Chon = true;
                    if (Them)
                        item.Them = true;
                    if (Sua)
                        item.Sua = true;
                    if (Xoa)
                        item.Xoa = true;
                    if (item.ParentID != null)
                        CheckParent(item.ParentID,Them,Sua,Xoa);
                }
            }
        }
        private void CheckChild(int ID, bool Them = false, bool Sua = false, bool Xoa = false)
        {
            foreach (AppMenuGroup item in _appGroupList.ElementAt(bding_Group.Position).AppMenuGroupList)
            {
                if (item.ParentID == ID)
                {
                    item.Chon = true;
                    if (Them)
                        item.Them = true;
                    if (Sua)
                        item.Sua = true;
                    if (Xoa)
                        item.Xoa = true;
                    CheckChild(item.ID, Them, Sua, Xoa);
                }
            }

        }
        AppMenuGroupList __AppMenuGroupList; AppMenuGroup _AppMenuGroup;
        private void TreeList_DanhSachMenu_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            _AppMenuGroup = null;
            string NameColumn = "";
            NameColumn = e.Column.Name;
            switch (NameColumn)
            {
                case "colChon": 
                    //Lấy menu hiện tại
                    _AppMenuGroup = bding_appMenuList.Current as AppMenuGroup;//Lấy menu hiện tại dòng được chọn
                    if (_AppMenuGroup == null){break;}
                    //-----------------------------Check---------------------------------//
                    if (bool.Parse(e.Value.ToString()) == true)
                    {
                        if (_AppMenuGroup.ParentID != null) // Check tất cả node cha
                            CheckParent(_AppMenuGroup.ParentID);
                        if(_AppMenuGroup.ID!=0)             // Check tất cả node con 
                            CheckChild(_AppMenuGroup.ID);
                    }
                    //----------------------------Bỏ check-------------------------------//
                    if (bool.Parse(e.Value.ToString()) == false)
                    {
                        _AppMenuGroup.Them = false; _AppMenuGroup.Sua = false; _AppMenuGroup.Xoa = false;  // khi bỏ chọn quyền xem mặc định bỏ quyền thêm xóa sửa.
                        if (_AppMenuGroup.ID != 0)          // Bỏ check tất cả node con
                            RemoveCheckChild(_AppMenuGroup.ID,true);
                        if (_AppMenuGroup.ParentID != null) // Bỏ check tất cả node cha
                            RemoveCheckParent(_AppMenuGroup.ParentID,true,false,false,false,_AppMenuGroup.ID);
                    }
                    break;
                case "colThem":
                    _AppMenuGroup = bding_appMenuList.Current as AppMenuGroup;//Lấy menu hiện tại dòng được chọn
                    if (_AppMenuGroup == null) { break; }
                    //-----------------------------Check---------------------------------//
                    if (bool.Parse(e.Value.ToString()) == true)
                    {
                        _AppMenuGroup.Chon = true;  // khi chọn quyền thêm mặc định check quyền xem.
                        if (_AppMenuGroup.ParentID != null) // Check tất cả node cha
                            CheckParent(_AppMenuGroup.ParentID, true, false,false);
                        if (_AppMenuGroup.ID != 0)             // Check tất cả node con 
                            CheckChild(_AppMenuGroup.ID, true, false, false);
                    }
                    //----------------------------Bỏ check-------------------------------//
                    if (bool.Parse(e.Value.ToString()) == false)
                    {
                        if (_AppMenuGroup.ID != 0)          // Bỏ check tất cả node con
                            RemoveCheckChild(_AppMenuGroup.ID,false,true,false,false);
                        if (_AppMenuGroup.ParentID != null) // Bỏ check tất cả node cha
                            RemoveCheckParent(_AppMenuGroup.ParentID,false, true, false, false, _AppMenuGroup.ID);
                    }
                    break;
                case "colSua":
                    _AppMenuGroup = bding_appMenuList.Current as AppMenuGroup;//Lấy menu hiện tại dòng được chọn
                    if (_AppMenuGroup == null) { break; }
                    //-----------------------------Check---------------------------------//
                    if (bool.Parse(e.Value.ToString()) == true)
                    {
                        _AppMenuGroup.Chon = true;  // khi chọn quyền thêm mặc định check quyền xem.
                        if (_AppMenuGroup.ParentID != null) // Check tất cả node cha
                            CheckParent(_AppMenuGroup.ParentID, false, true, false);
                        if (_AppMenuGroup.ID != 0)             // Check tất cả node con 
                            CheckChild(_AppMenuGroup.ID, false, true, false);
                    }
                    //----------------------------Bỏ check-------------------------------//
                    if (bool.Parse(e.Value.ToString()) == false)
                    {
                        if (_AppMenuGroup.ID != 0)          // Bỏ check tất cả node con
                            RemoveCheckChild(_AppMenuGroup.ID, false, false, true, false);
                        if (_AppMenuGroup.ParentID != null) // Bỏ check tất cả node cha
                            RemoveCheckParent(_AppMenuGroup.ParentID, false, false, true, false, _AppMenuGroup.ID);
                    }
                    break;
                case "colXoa":
                    _AppMenuGroup = bding_appMenuList.Current as AppMenuGroup;//Lấy menu hiện tại dòng được chọn
                    if (_AppMenuGroup == null) { break; }
                    //-----------------------------Check---------------------------------//
                    if (bool.Parse(e.Value.ToString()) == true)
                    {
                        _AppMenuGroup.Chon = true;  // khi chọn quyền thêm mặc định check quyền xem.
                        if (_AppMenuGroup.ParentID != null) // Check tất cả node cha
                            CheckParent(_AppMenuGroup.ParentID, false, false, true);
                        if (_AppMenuGroup.ID != 0)             // Check tất cả node con 
                            CheckChild(_AppMenuGroup.ID, false, false, true);
                    }
                    //----------------------------Bỏ check-------------------------------//
                    if (bool.Parse(e.Value.ToString()) == false)
                    {
                        if (_AppMenuGroup.ID != 0)          // Bỏ check tất cả node con
                            RemoveCheckChild(_AppMenuGroup.ID, false, false, false, true);
                        if (_AppMenuGroup.ParentID != null) // Bỏ check tất cả node cha
                            RemoveCheckParent(_AppMenuGroup.ParentID, false, false, false, true, _AppMenuGroup.ID);
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
