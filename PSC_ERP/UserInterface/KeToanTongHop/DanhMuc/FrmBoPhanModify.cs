using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.IO;
using System.Diagnostics;
using ERP_Library.Security;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using PSC_ERP_Business.Main;
using System.Linq;
using PSC_ERP_Common;
using System.Data.SqlClient;
using System.Data;

namespace PSC_ERP
{
    public partial class FrmBoPhanModify : XtraForm
    {
     
        BoPhanList _boPhanList = null;
        HeThongTaiKhoan1List _heThongTaiKhoanList1 = null;
        public string strStatus = "KHOA";
        PhanQuyenSuDungForm _phanQuyen = null;  
        int _MaCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        public FrmBoPhanModify()
        {
            InitializeComponent();              
            KhoiTao();          
        }
        private void FrmBoPhanModify_Load(object sender, EventArgs e)
        {
            treeList_BoPhan.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;           
            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            LoadData();
        }
        private void KhoiTao()
        {
            _boPhanList = BoPhanList.NewBoPhanList();
            BoPhanList_bindingSource.DataSource = _boPhanList;
            _heThongTaiKhoanList1 = HeThongTaiKhoan1List.NewHeThongTaiKhoan1List();
            TaiKhoan_bindingSource.DataSource = _heThongTaiKhoanList1;
        }
        private void LoadData()
        {
            _boPhanList = BoPhanList.GetBoPhanAll_ByMaCongTy();
            BoPhanList_bindingSource.DataSource = _boPhanList;
            _heThongTaiKhoanList1 = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List();
            TaiKhoan_bindingSource.DataSource = _heThongTaiKhoanList1;
        }
        private void PhanQuyenThemSuaXoa()
        {
            _phanQuyen = PhanQuyenSuDungForm.GetQuyenSuDungFormTheoUser(CurrentUser.Info.UserID, (this.GetType().Namespace + "." + this.Name));
            btnThemMoi.Enabled = _phanQuyen.Them;
            btnDongBoHRM.Enabled = _phanQuyen.Them;
            btnXoa.Enabled = _phanQuyen.Xoa;
            btnSua.Enabled = _phanQuyen.Sua;

        }
        private void ReadOnlyConTrolByStatus(string _strStatus)//treeList_BoPhan
        {
            if (_strStatus == "" || _strStatus == "THEM" || _strStatus == "SUA")
            {
                btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnDongBoHRM.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                treeList_BoPhan.OptionsBehavior.ReadOnly = false;
            }
            else if (_strStatus == "KHOA")
            {
                btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnDongBoHRM.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                treeList_BoPhan.OptionsBehavior.ReadOnly = true;
            }
            PhanQuyenThemSuaXoa();
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmBoPhanModifyEdit frm = new FrmBoPhanModifyEdit();
            if (frm.ShowDialog() != DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.strStatus = "SUA";
            ReadOnlyConTrolByStatus(this.strStatus);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var tenBoPhan = _boPhanList.ElementAt(BoPhanList_bindingSource.Position).TenBoPhan;
            DialogResult dlgResult =
            XtraMessageBox.Show($"Bạn Có Chắc Muốn Xóa Bộ Phận: <color=red > {_boPhanList.ElementAt(BoPhanList_bindingSource.Position).TenBoPhan}</color>"
                        , "Cảnh Báo !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, DevExpress.Utils.DefaultBoolean.True);
            if ( dlgResult == DialogResult.Yes)
            {
                try
                {
                    using (DialogUtil.WaitForDelete(this))
                    {
                        _boPhanList.BeginEdit();
                        treeList_BoPhan.BeginDelete();
                        treeList_BoPhan.DeleteSelectedNodes();
                        treeList_BoPhan.EndDelete();

                        _boPhanList.ApplyEdit();
                        _boPhanList.Save();

                    }
                    //thông báo đã xóa thành công
                    DialogUtil.ShowDeleteSuccessful();
                }
                catch (Exception ex)
                {
                    //thông báo không xóa được
                  XtraMessageBox.Show($"Bộ Phận: <color=red > {tenBoPhan.ToString()}</color> Đã Phát Sinh Dữ Liệu Liên Kết! \n Nên Không Thể Xóa "
                        , "Cảnh Báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning, DevExpress.Utils.DefaultBoolean.True);
                    
                    _boPhanList.CancelEdit();
                    _boPhanList = BoPhanList.GetBoPhanAll_ByMaCongTy();
                    BoPhanList_bindingSource.DataSource = _boPhanList;
                }
            }           
            treeList_BoPhan.ExpandAll();
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FocusDataGrid();
            try
            {
                BoPhanList_bindingSource.EndEdit();            
                _boPhanList.Save();
                this.strStatus = "KHOA";
                this.ReadOnlyConTrolByStatus(this.strStatus);
                MessageBox.Show("Lưu Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }

        private void btn_XuatRaExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //HamDungChung.ExportToExcelFromGridViewDev(gridView1);
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                treeList_BoPhan.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }
        private void treeList_BoPhan_DoubleClick(object sender, EventArgs e)
        {
            if (treeList_BoPhan.FocusedNode != null)
            {
                BoPhan bophan = treeList_BoPhan.GetDataRecordByNode(treeList_BoPhan.FocusedNode) as BoPhan;
                FrmBoPhanModifyEdit frm = new FrmBoPhanModifyEdit(bophan.MaBoPhan);

                if (frm.ShowDialog() != DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        public void FocusDataGrid()
        {    
            treeList_BoPhan.MoveNext();
        }
        private void treeList_BoPhan_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "MaBoPhanQL" && IsDuplicatedMaBoPhanQL( e.Value))
            {
                DuplicatedValueWarning(sender, e);
            }
          
        }
        private void DuplicatedValueWarning(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            var treeList = sender as TreeList;           
            XtraMessageBox.Show(String.Format($"Dữ Liệu <color=red>\"{e.Value.ToString()}\"</color> đã tồn tại !"), "Thông Báo ", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning,DevExpress.Utils.DefaultBoolean.True);

            try
            {
                treeList.CancelCurrentEdit();
                treeList.SetColumnError(e.Column, "Dữ liệu trùng lặp !");

            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
        }
        private Boolean IsDuplicatedMaBoPhanQL( object someValue)
        {
          var linq = (_boPhanList.Where(o => o.MaBoPhanQL == someValue.ToString())).Count(); 
          return linq > 1;
        }
        private Boolean IsDuplicatedTenBoPhan(object someValue)
        {
            var linq = (_boPhanList.Select(o => o.TenBoPhan == someValue.ToString())).Count();
            return linq > 1;
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void treeList_BoPhan_KeyDown(object sender, KeyEventArgs e)
        {
            if(_phanQuyen.Xoa && e.KeyCode == Keys.Delete)
            {
                btnXoa.PerformClick();
            }
        }

        private void btnDongBoHRM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {           
            using (SqlConnection cn = new SqlConnection(PSC_ERP_Business.Main.Database.NormalConnectionString))
            {
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 10 * 60;
                    cm.CommandText = "spd_DongBoBoPhanByMaCongTy";
                    cm.Parameters.AddWithValue("@MaCongTy ", _MaCongTy);
                }
            }
            LoadData();
        }
    }
}