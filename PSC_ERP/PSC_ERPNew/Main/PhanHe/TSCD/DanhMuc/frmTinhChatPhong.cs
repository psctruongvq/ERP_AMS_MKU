using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using ERP_Library.Security;
using PSC_ERP.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace PSC_ERPNew.Main
{
    public partial class frmTinhChatPhong : DevExpress.XtraEditors.XtraForm
    {
        TinhChatPhongList _tinhChatPhongList;
        PhanQuyenSuDungForm _phanQuyen = null;
        ERP_Library.Util util = new ERP_Library.Util();
        public string strStatus = "KHOA";
        public frmTinhChatPhong()
        {
            InitializeComponent();
            _tinhChatPhongList = TinhChatPhongList.NewTinhChatPhongList();
            GridUtils.SetSTTForGridView(gridV_TinhChatPhong);//M
        }
        public void LoadData()
        {
            _tinhChatPhongList = TinhChatPhongList.GetTinhChatPhongList();
            bindingSource_TinhChatPhong.DataSource = _tinhChatPhongList;
        }
        private void frmTinhChatPhong_Load(object sender, EventArgs e)
        {
            LoadData();
            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.strStatus = "THEM";
                this.ReadOnlyConTrolByStatus(this.strStatus);
                _tinhChatPhongList.AddNew();
                bindingSource_TinhChatPhong.DataSource = _tinhChatPhongList;
                bindingSource_TinhChatPhong.MoveLast();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message,"Lỗi",buttons: MessageBoxButtons.OK);
            }
            
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.strStatus = "SUA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           if(PSC_ERP.HamDungChung.DeleteSelectedRowsGridViewDev(gridV_TinhChatPhong) == true)
            {
                btnLuu.PerformClick();
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FocusDataGrid();
            if (_tinhChatPhongList.IsDirty && _tinhChatPhongList.IsValid ==true )
            {
                LuuData();
                bindingSource_TinhChatPhong.DataSource = _tinhChatPhongList.OrderBy(o => o.MaTinhChatPhongQL).ThenBy(o=>o.TenTinhChatPhong);
                this.strStatus = "KHOA";
                this.ReadOnlyConTrolByStatus(this.strStatus);
            }
        }
        private void btnXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PSC_ERP.HamDungChung.ExportToExcelFromGridViewDev(gridV_TinhChatPhong);
        }
        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            LoadData();
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void FrmTinhChatPhong_FormClosing(object sender, FormClosingEventArgs e)
        {
            FocusDataGrid();
            if (_tinhChatPhongList.IsDirty)
            {
                DialogResult dlgResult = PSC_ERP_Common.DialogUtil.ShowSaveRequireOptionsOnFormClosing(this);
                if (DialogResult.Yes == dlgResult)
                {
                    LuuData();    
                }
                else if (DialogResult.Cancel == dlgResult)
                {
                    e.Cancel = true;
                }
            }
        }

        private void gridC_TinhChatPhong_ProcessGridKey(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && _phanQuyen.Xoa)
            {
                if (PSC_ERP.HamDungChung.DeleteSelectedRowsGridViewDev(gridV_TinhChatPhong) == true)
                {
                    btnLuu.PerformClick();
                }
            }
        }
        private void gridV_TinhChatPhong_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "MaTinhChatPhongQL" && IsDuplicatedValue(sender, e.Column, e.RowHandle, e.Value))
            {
                DuplicatedValueWarning(sender, e);
            }
            else if (e.Column.FieldName == "TenTinhChatPhong" && IsDuplicatedValue(sender, e.Column, e.RowHandle, e.Value))
            {
                DuplicatedValueWarning(sender, e);
            }
        }
        private void DuplicatedValueWarning(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var gView = sender as GridView;
            XtraMessageBox.Show(String.Format($"Dữ Liệu {e.Value.ToString()} đã tồn tại !"), "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            try
            {
                gView.CancelUpdateCurrentRow();
                this.strStatus = "KHOA";
                this.ReadOnlyConTrolByStatus(this.strStatus);
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
        }
        private Boolean IsDuplicatedValue(object currentView, GridColumn currentColumn, int currentRow, object someValue)
        {
            int i = 0;
            while (i < (((GridView)currentView).DataRowCount -1))
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
        private void PhanQuyenThemSuaXoa()
        {
            _phanQuyen = PhanQuyenSuDungForm.GetQuyenSuDungFormTheoUser(CurrentUser.Info.UserID, (this.GetType().Namespace + "." + this.Name));
            btnThem.Enabled = _phanQuyen.Them;
            btnSua.Enabled = _phanQuyen.Sua;
            btnXoa.Enabled = _phanQuyen.Xoa;
        }
        private void ReadOnlyConTrolByStatus(string strStatus)
        {
            if (strStatus == "" || strStatus == "THEM" || strStatus == "SUA")
            {
                btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                foreach (GridColumn  column in gridV_TinhChatPhong.Columns)
                {
                    column.OptionsColumn.ReadOnly = false;
                }
            }
            else if (strStatus == "KHOA")
            {
                btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                foreach (GridColumn column in gridV_TinhChatPhong.Columns)
                {
                    column.OptionsColumn.ReadOnly = true;
                }
            }
            PhanQuyenThemSuaXoa();
        }

        public void FocusDataGrid()
        {
            if (bindingSource_TinhChatPhong.Position == bindingSource_TinhChatPhong.Count - 1) // bindingSource1 trong form
                bindingSource_TinhChatPhong.MoveFirst();
            else
                bindingSource_TinhChatPhong.MoveNext();
        }  
        public void LuuData()
        {
            try
            {
                _tinhChatPhongList.Save();
                MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, util.thatbai + "\n" + ex.Message.ToString(), util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }//end Method

       
    }
}