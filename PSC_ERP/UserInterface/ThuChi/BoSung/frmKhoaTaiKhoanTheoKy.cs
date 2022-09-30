using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.Diagnostics;
using System.IO;
//09/04/2013
namespace PSC_ERP
{
    public partial class frmKhoaTaiKhoanTheoKy : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        KyList _kyList;
        Ky _ky;
        ERP_Library.Security.UserList _userListChuaKhoaSo;
        KhoaSo_MaTaiKhoanRootList _khoaSo_MaTaiKhoanList;
        int _maKy = 0;
        int _maTaiKhoan=0;
        private bool _checkAll = false;
        private bool _execCheckAll = true;
        #endregion

        #region Function

        private void KhoiTaoForm()
        {
            bindingSource1_khoaSoUser.DataSource = typeof(ERP_Library.KhoaSo_MaTaiKhoanRootList);
            heThongTaiKhoan1ListBindingSource.DataSource = typeof(HeThongTaiKhoan1List);
            bindingSource1_Ky.DataSource = typeof(ERP_Library.KyList);
        }

        private void LoadBindingSource()
        {
            _kyList = KyList.GetKyList();
            bindingSource1_Ky.DataSource = _kyList;
            _khoaSo_MaTaiKhoanList = KhoaSo_MaTaiKhoanRootList.NewKhoaSo_MaTaiKhoanRootList();
            bindingSource1_khoaSoUser.DataSource = _khoaSo_MaTaiKhoanList;
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
        }
        private void BindingData()
        {
            //bindingSource1_khoaSoUser.DataSource = _khoaSo_MaTaiKhoanList;
            bdKhoaSo_MaTaiKhoan.DataSource = _khoaSo_MaTaiKhoanList;
        }

        private void DesignGridView()
        {
            gridControl1.DataSource = bindingSource1_khoaSoUser;
            HamDungChung.InitGridViewDev(grdVDanhSachUserKhoaThue, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev(grdVDanhSachUserKhoaThue, new string[] { "TenDangNhap", "NgayBatDau", "NgayKetThuc", "KhoaSo" },
                                new string[] { "Tên đăng nhập ", "Ngày bắt đầu", "Ngày kết thúc", "Khóa" },
                                             new int[] { 120, 90, 90, 90 });
            HamDungChung.AlignHeaderColumnGridViewDev(grdVDanhSachUserKhoaThue, new string[] { "TenDangNhap", "NgayBatDau", "NgayKetThuc", "KhoaSo" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.ReadOnlyColumnChoseGridViewDev(grdVDanhSachUserKhoaThue, new string[] { "TenDangNhap", "NgayBatDau", "NgayKetThuc" });

            Utils.GridUtils.SetSTTForGridView(grdVDanhSachUserKhoaThue, 50);//M
            this.grdVDanhSachUserKhoaThue.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdVDanhSachUserKhoaThue_CellValueChanged);
            //
            //RepositoryItemGridLookUpEdit LoaiTien_GrdLU = new RepositoryItemGridLookUpEdit();
            //LoaiTien_GrdLU.DataSource = loaiTienListBindingSource;
            //LoaiTien_GrdLU.DisplayMember = "MaLoaiQuanLy";
            //LoaiTien_GrdLU.ValueMember = "MaLoaiTien";
            //HamDungChung.InitRepositoryItemGridLookUpDev(LoaiTien_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiTien_GrdLU, new string[] { "MaLoaiQuanLy", "TenLoaiTien" }, new string[] { "Mã", "Loại tiền" }, new int[] { 100, 150 }, true);
            //HamDungChung.AddButtonForRepositoryItemGridLookUpDev(LoaiTien_GrdLU);
            //LoaiTien_GrdLU.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.GridLookUpEdit_MaDuAn_ButtonClick);

            //HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaLoaiTien", LoaiTien_GrdLU);
            ////
            //HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "#,###.#");
            //gridView1.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick);
        }

        private void LoadKhoaSoTaiKhoanList()
        {
            //if (KhoaSo_MaTaiKhoanRootList.KiemTraTonTaiKhoaSoTaiKhoanListtheoKy_MaTaiKhoan(_maKy,_maTaiKhoan))
            //{
            //    _khoaSo_MaTaiKhoanList = KhoaSo_MaTaiKhoanRootList.GetKhoaSo_MaTaiKhoanRootList(_maKy, _maTaiKhoan);
            //    BindingData();
            //}
            //else
            //{               
            //    _khoaSo_MaTaiKhoanList = KhoaSo_MaTaiKhoanRootList.NewKhoaSo_MaTaiKhoanRootList(_maKy,_maTaiKhoan);
               
            //    BindingData();
            //}
            _khoaSo_MaTaiKhoanList = KhoaSo_MaTaiKhoanRootList.GetKhoaSo_MaTaiKhoanListByMaKy(_maKy);
            BindingData();
            SetValueCheckAll();
        }

        private void SetValueCheckAll()
        {
            //KiemTraCheckKhoaTatCa();
            //_execCheckAll = false;
            //checkEditAll.Checked = _checkAll;
            //_execCheckAll = true;
        }

        private void LoadData()
        {
            //checkEditAll.Checked = false;
            GetThongTin();
            if (_maKy != 0)
            {
                LoadKhoaSoTaiKhoanList();
            }
        }

        private void GetThongTin()
        {
            if (Ky_GrLU.EditValue != null)
            {
                int maKy;
                if (int.TryParse(Ky_GrLU.EditValue.ToString(), out maKy))
                {
                    _maKy = maKy;
                }
                else _maKy = 0;
            }
            else _maKy = 0;

            if (TaiKhoanListgridLookUpEdit.EditValue != null)
            {
                int maTaiKhoanOut;
                if (int.TryParse(TaiKhoanListgridLookUpEdit.EditValue.ToString(), out maTaiKhoanOut))
                {
                    _maTaiKhoan = maTaiKhoanOut;
                }
                else _maTaiKhoan = 0;
            }
            else _maTaiKhoan = 0;
        }

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }

        private void KiemTraCheckKhoaTatCa()
        {
            if (_khoaSo_MaTaiKhoanList.Count == 0) _checkAll = false;
            else 
            {
                _checkAll = true;
                foreach (KhoaSo_MaTaiKhoan ks in _khoaSo_MaTaiKhoanList)
                {
                    if (ks.KhoaSo == false)
                    {
                        _checkAll = false;
                        return;
                    }
                }
            }
        }

        #endregion

        #region Event

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void Ky_GrLU_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();

        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChangeFocustextEdit.Focus();
            bindingSource1_khoaSoUser.EndEdit();
            try
            {
                _khoaSo_MaTaiKhoanList.ApplyEdit();
                _khoaSo_MaTaiKhoanList.Save();
                MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadData();
        }

        private void checkEditAll_CheckedChanged(object sender, EventArgs e)
        {
            //if (_execCheckAll == false) return;
            //if (checkEditAll.Checked == true)
            //{
            //    for (int i = 0; i < grdVDanhSachUserKhoaThue.RowCount; i++)
            //    {
            //        KhoaSo_MaTaiKhoan khoasoMaTK = grdVDanhSachUserKhoaThue.GetRow(i) as KhoaSo_MaTaiKhoan;
            //        khoasoMaTK.KhoaSo= true;
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < grdVDanhSachUserKhoaThue.RowCount; i++)
            //    {
            //        KhoaSo_MaTaiKhoan khoasoMaTK = grdVDanhSachUserKhoaThue.GetRow(i) as KhoaSo_MaTaiKhoan;
            //        khoasoMaTK.KhoaSo = false;
            //    }
            //}
            //gridControl1.Refresh();
            //grdVDanhSachUserKhoaThue.RefreshData();

            foreach (KhoaSo_MaTaiKhoan obj in _khoaSo_MaTaiKhoanList)
            {
                obj.KhoaSo = checkEditAll.Checked;
            }

        }

        private void btnRefesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void btnXuatFileExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                grdVDanhSachUserKhoaThue.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }
        #endregion

        #region EventHandles
        private void grdVDanhSachUserKhoaThue_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (grdVDanhSachUserKhoaThue.FocusedColumn.FieldName == "KhoaSo")
            {
                grdVDanhSachUserKhoaThue.RefreshData();
                SetValueCheckAll();
            }
        }
        #endregion//EventHandles

        public frmKhoaTaiKhoanTheoKy()
        {
            InitializeComponent();
            KhoiTaoForm();
            LoadBindingSource();
            DesignGridView();

        }

        private void TaiKhoanListgridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            //LoadData();
        }

        private void tree_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            DevExpress.XtraTreeList.Nodes.TreeListNode node;
            node = e.Node;

            string maTaiKhoanCha = node.GetValue("MaTaiKhoanCha") + "";
            if (maTaiKhoanCha == "0")
            {
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        KhoaSo_MaTaiKhoan _KhoaSo_MaTaiKhoanCurent;
        private void tree_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            _KhoaSo_MaTaiKhoanCurent = null;

            DevExpress.XtraTreeList.Nodes.TreeListNode node = e.Node;

            if (node.GetType().Name == "TreeListAutoFilterNode")
                return;

            //Lấy menu hiện tại
            _KhoaSo_MaTaiKhoanCurent = bdKhoaSo_MaTaiKhoan.Current as KhoaSo_MaTaiKhoan;
            if (_KhoaSo_MaTaiKhoanCurent == null)
                return;

            foreach (KhoaSo_MaTaiKhoan appMenu in _khoaSo_MaTaiKhoanList)
            {
                //----------------------------Bỏ check-------------------------------//
                if (appMenu.MaTaiKhoan == _KhoaSo_MaTaiKhoanCurent.MaTaiKhoan && _KhoaSo_MaTaiKhoanCurent.KhoaSo == true)
                {
                    appMenu.KhoaSo = false; //Bỏ check node hiện tại

                    //Bỏ check tất cả nút con
                    if (appMenu.MaTaiKhoan != 0)
                        RemoveCheckChild(appMenu.MaTaiKhoan);

                    //Gán bindingSource

                    tree.Refresh();
                    return;
                }

                //-----------------------------Check---------------------------------//
                if (appMenu.MaTaiKhoan == _KhoaSo_MaTaiKhoanCurent.MaTaiKhoan && _KhoaSo_MaTaiKhoanCurent.KhoaSo == false)
                {
                    appMenu.KhoaSo = true; //Check node hiện tại

                    //Check tất cả nút cha
                    if (appMenu.MaTaiKhoanCha != null)
                        CheckParent(appMenu.MaTaiKhoanCha);

                    //Check tất cả nút con
                    if (appMenu.MaTaiKhoan != 0)
                        CheckChild(appMenu.MaTaiKhoan);

                    //Gán bindingSource

                    tree.Refresh();
                    return;
                }
            }
        }

        private void CheckParent(int parentID)
        {
            foreach (KhoaSo_MaTaiKhoan item in _khoaSo_MaTaiKhoanList)
            {
                if (item.MaTaiKhoan == parentID)
                {
                    item.KhoaSo = true;
                    if (item.MaTaiKhoanCha + "0" != "0")
                        CheckParent(item.MaTaiKhoanCha);
                }
            }

        }
        private void CheckChild(int ID)
        {
            foreach (KhoaSo_MaTaiKhoan item in _khoaSo_MaTaiKhoanList)
            {
                if (item.MaTaiKhoanCha == ID)
                {
                    item.KhoaSo = true;
                    if (item.MaTaiKhoan != null)
                        CheckChild(item.MaTaiKhoan);
                }
            }

        }
        private void RemoveCheckChild(int ID)
        {
            foreach (KhoaSo_MaTaiKhoan item in _khoaSo_MaTaiKhoanList)
            {
                if (item.MaTaiKhoanCha == ID)
                {
                    item.KhoaSo = false;
                    if (item.MaTaiKhoan != null)
                        RemoveCheckChild(item.MaTaiKhoan);
                }
            }
        }

        


    }
}