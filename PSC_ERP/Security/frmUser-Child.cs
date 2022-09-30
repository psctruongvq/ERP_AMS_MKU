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
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERP.Utils;

namespace PSC_ERP.Security
{
    public partial class frmUser_Child : Form
    {
       // private ERP_Library.Security.UserList _data;
       // private ERP_Library.Security.UserItem _item;
        private ERP_Library.Security.UserList _userCBList;
       // UserChildList _userChildList;
        //int userID = 0;
        public frmUser_Child()
        {
            InitializeComponent();
            GridUtils.SetSTTForGridView(gridV_UserChild);//STT
        }

        public string strStatus = "KHOA";
        PhanQuyenSuDungForm _phanQuyen = null;
       // private void PhanQuyenThemSuaXoa()
        //{
        //    _phanQuyen = PhanQuyenSuDungForm.GetQuyenSuDungFormTheoUser(CurrentUser.Info.UserID, (this.GetType().Namespace + "." + this.Name));
        //    itEdit.Enabled = _phanQuyen.Sua;
        //}

        //private void ReadOnlyConTrolByStatus(string _strStatus)
        //{
        //    if (_strStatus == "" || _strStatus == "THEM" || _strStatus == "SUA")
        //    {
        //        itEdit.Visible = false;
        //        itSave.Visible = true;
        //    }
        //    else if (_strStatus == "KHOA")
        //    {
        //        itEdit.Visible = true;
        //        itSave.Visible = false;
               
        //    }
        //    PhanQuyenThemSuaXoa();
        //}
        private void frmUser_Child_Load(object sender, EventArgs e)
        {
          //  this.ReadOnlyConTrolByStatus(this.strStatus);
            LoadData();
        }
        private void LoadData()
        {
            _userCBList = ERP_Library.Security.UserList.GetUserListChooseChild(boPhanChild: false, phuCapChild: false, thulaoChild: false, userChildListChild: true);
            bdData.DataSource = _userCBList;
            this.BindingSource_User.DataSource = _userCBList;
            this.bindingSource1_UserChild.DataSource = ((ERP_Library.Security.UserItem)(bdData).Current).UserChild;
        }
        private void bdData_CurrentItemChanged(object sender, EventArgs e)
        {
           this.bindingSource1_UserChild.DataSource = ((UserItem)_userCBList[bdData.Position]).UserChild;
        }

        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {               
                col.Hidden = true;
            }
            grdData.DisplayLayout.Bands[0].Columns["TenDangNhap"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["TenDangNhap"].Header.Caption = "Tên Đăng Nhập";
            grdData.DisplayLayout.Bands[0].Columns["TenDangNhap"].Width = 250;
        }

     
        private void itSave_Click(object sender, EventArgs e)
        {
                bindingSource1_UserChild.EndEdit();  
                _userCBList.ApplyEdit();      
                _userCBList.Save();
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.bindingSource1_UserChild.DataSource = ((UserItem)_userCBList[bdData.Position]).UserChild;
                //this.strStatus = "KHOA";
                //this.ReadOnlyConTrolByStatus(this.strStatus);
        }

        private void itDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void itUndo_Click(object sender, EventArgs e)
        {
            //this.strStatus = "KHOA";
            //this.ReadOnlyConTrolByStatus(this.strStatus);
            LoadData();
        }

        private void itEdit_Click(object sender, EventArgs e)
        {
            //this.strStatus = "SUA";
            //this.ReadOnlyConTrolByStatus(this.strStatus);
        }
        private void DuplicatedValueWarning(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
           
            XtraMessageBox.Show(String.Format($"Dữ Liệu <b>{Convert.ToString(_userCBList.Where(x => x.UserID == (int)e.Value).Select(x => x.TenDangNhap ).FirstOrDefault())}</b> đã tồn tại !")
                , "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning,DevExpress.Utils.DefaultBoolean.True);
        }
        private Boolean IsDuplicatedValue(object currentView, GridColumn currentColumn, int currentRow, object someValue)
        {
            int i = 0;
            while (i < (((GridView)currentView).DataRowCount ))
            {
                if (((GridView)currentView).GetRowCellValue(((GridView)currentView).GetRowHandle(i), currentColumn.FieldName).ToString()
                                                                                                                 == someValue.ToString())
                {
                    return true;
                }
                i++;
            }
            return false;
        }

        private void gridV_UserChild_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "User_Child" && IsDuplicatedValue(sender, e.Column, e.RowHandle, e.Value))
            {
                DuplicatedValueWarning(sender, e);
                try
                {
                    itUndo.PerformClick();
                }
                catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
            }
            
        }

       
    }
}
