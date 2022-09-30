using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraTreeList.Nodes;
using PSC_ERP_Common;
using ERP_Library.Security;

namespace PSC_ERP
{
    public partial class frmHeThongTaiKhoanE : XtraForm
    {
        #region Properties    
        PhanQuyenSuDungForm _phanQuyen = null;
        HeThongTaiKhoan1 _HeThongTaiKhoan1;
        HeThongTaiKhoan1List _HeThongTaiKhoan1List;
        HeThongTaiKhoan1List _HeThongTaiKhoan1ListCha;
        LoaiTaiKhoanList _LoaiTaiKhoanList;
        CongTyList _congTyLits;
        public string strStatus = "KHOA";
        #endregion //Properties

        #region ConTructors
        public frmHeThongTaiKhoanE()
        {
            InitializeComponent();          
            LoadData();
            treeList_HeThongTaiKhoan.ExpandAll();
        }
        #endregion//ConTructors

        #region Methods
        private void LoadData()
        {
            ReadOnlyConTrolByStatus(strStatus);
            LoadTaiKhoanList();
        }     
        private void LoadTaiKhoanList()
        {         
            _HeThongTaiKhoan1List = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            HeThongTaiKhoan_BindingSource.DataSource = _HeThongTaiKhoan1List;
            treeList_HeThongTaiKhoan.DataSource = HeThongTaiKhoan_BindingSource;

            _HeThongTaiKhoan1ListCha = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListCha();
            HeThongTaiKhoan1 _taiKhoanCha_KhongChon = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
            _taiKhoanCha_KhongChon.SoHieuTK = "Không chọn";
            _taiKhoanCha_KhongChon.TenTaiKhoan = "Không chọn";
            _HeThongTaiKhoan1ListCha.Insert(0, _taiKhoanCha_KhongChon);
            HeThongTaiKhoanCha_BindingSource.DataSource = _HeThongTaiKhoan1ListCha;

            _LoaiTaiKhoanList = LoaiTaiKhoanList.GetLoaiTaiKhoanList();
            LoaiTaiKhoan_BindingSource.DataSource = _LoaiTaiKhoanList;

            _congTyLits = CongTyList.GetCongTyList();
            bdCongTy.DataSource = _congTyLits;          
        }

        #endregion//Methods
        private void PhanQuyenThemSuaXoa()
        {
            _phanQuyen = PhanQuyenSuDungForm.GetQuyenSuDungFormTheoUser(CurrentUser.Info.UserID, (this.GetType().Namespace + "." + this.Name));

            btnThemMoi.Enabled = _phanQuyen.Them;
            btnSua.Enabled = _phanQuyen.Sua;
            btnXoa.Enabled = _phanQuyen.Xoa;
        }
  
        private void ReadOnlyConTrolByStatus(string strStatus)
        {
            if (strStatus == "" || strStatus == "THEM" || strStatus == "SUA")
            {
                foreach (Control c in ThongTinChunggroupControl.Controls)
                {
                    if (c is GridLookUpEdit)
                    {
                        ((GridLookUpEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is TextEdit)
                    {
                        ((TextEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is DateEdit)
                    {
                        ((DateEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is CalcEdit)
                    {
                        ((CalcEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is MemoEdit)
                    {
                        ((MemoEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is CheckEdit)
                    {
                        ((CheckEdit)c).Enabled = true;
                    }
                }

                btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;              
                btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (strStatus == "KHOA")
            {
                //gridView_ChiTietHoaDon.OptionsBehavior.Editable = false;
                //bdChiTietHoaDon.AllowNew = false;
                foreach (Control c in ThongTinChunggroupControl.Controls)
                {
                    if (c is GridLookUpEdit)
                    {
                        ((GridLookUpEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is TextEdit)
                    {
                        ((TextEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is DateEdit)
                    {
                        ((DateEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is CalcEdit)
                    {
                        ((CalcEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is MemoEdit)
                    {
                        ((MemoEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is CheckEdit)
                    {
                        ((CheckEdit)c).Enabled = false;
                    }
                }
                btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;             
                btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            PhanQuyenThemSuaXoa();
        }
        #region Events
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                _HeThongTaiKhoan1List.ApplyEdit();
                HeThongTaiKhoan_BindingSource.EndEdit();
                _HeThongTaiKhoan1List.Save();
                LoadData();
                MessageBox.Show(this, "Đã lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                strStatus = "KHOA";
                ReadOnlyConTrolByStatus(strStatus);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lưu!\n"+ ex.Message);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #endregion//Events

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            TreeListNode focusedNode = treeList_HeThongTaiKhoan.FocusedNode;//C        
            HeThongTaiKhoan1 currentObject = treeList_HeThongTaiKhoan.GetDataRecordByNode(focusedNode) as HeThongTaiKhoan1;
            _HeThongTaiKhoan1 = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
            _HeThongTaiKhoan1.MaTaiKhoanCha = currentObject.MaTaiKhoan;
            _HeThongTaiKhoan1.CapTaiKhoan = (byte)((Int32)currentObject.CapTaiKhoan + 1);
            HeThongTaiKhoan_BindingSource.Add(_HeThongTaiKhoan1);
            //focus tới vị trí vừa thêm vào
            HeThongTaiKhoan_BindingSource.Position = HeThongTaiKhoan_BindingSource.IndexOf(_HeThongTaiKhoan1);
            strStatus = "THEM";
            ReadOnlyConTrolByStatus(strStatus);

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode focusedNode = treeList_HeThongTaiKhoan.FocusedNode;//C        
            HeThongTaiKhoan1 currentObject = treeList_HeThongTaiKhoan.GetDataRecordByNode(focusedNode) as HeThongTaiKhoan1;          
            HeThongTaiKhoan_BindingSource.Remove(currentObject);
        }

        private void btn_Refesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void btn_ExportTree_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            treeList_HeThongTaiKhoan.ExpandAll();
            //xuất excel cây danh mục
            TreeUtils.ExportToExcel(treeList: treeList_HeThongTaiKhoan, showOpenFilePrompt: true);
        }
    }
}