using System;
using System.Linq;
using System.Windows.Forms;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Common;
using ERP_Library;
using DevExpress.XtraEditors;

namespace PSC_ERPNew.Main
{
    public partial class frmListDonViTinh : DevExpress.XtraEditors.XtraForm
    {
        //Singleton
        #region Singleton
        private static frmListDonViTinh singleton_ = null;
        public static frmListDonViTinh Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmListDonViTinh();
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
        DonViTinh_Factory _dvt_Factory = DonViTinh_Factory.New();
        IQueryable<tblDonViTinh> _dvtList = null;
        Boolean _yeuCauTaoDVTrongKhiFormLoad = false;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmListDonViTinh()
        {
            InitializeComponent();
            _yeuCauTaoDVTrongKhiFormLoad = false;
        }
        public frmListDonViTinh(Boolean taoMoi)
        {
            InitializeComponent();
            _yeuCauTaoDVTrongKhiFormLoad = taoMoi;
        }

        #endregion

        //Private Member Function
        #region Private Member Function
        private void LoadData()
        {
            _dvtList = _dvt_Factory.GetAll();
            // Cài đặt lưới
            GridUtil.SetSTTForGridView(this.grdViewDonViTinh);
            GanBindingSource();
        }
       
        private void GanBindingSource()
        {
            tblDonViTinhBindingSource.DataSource = _dvtList;
        }
        private Boolean Save()
        {
            this.txtBlackHole.Focus();
            if (DuocPhepLuu())
                try
                {
                    _dvt_Factory.SaveChangesWithoutTrackingLog();
                    //_dvt_Factory.SaveChanges();//lưu lại
                    //
                    DialogUtil.ShowSaveSuccessful();
                    this.strStatus = "KHOA";
                    this.ReadOnlyConTrolByStatus(this.strStatus);
                    return true;
                }
                catch (Exception ex)
                {
                    //DialogUtil.ShowNotSaveSuccessful();
                    XtraMessageBox.Show("-Lỗi: "+ex+"");
                }
            return false;
        }
        private Boolean DuocPhepLuu()
        {
            Boolean duocPhepLuu = true;
            return duocPhepLuu;
        }
        #endregion

        //Event Method
        #region Event Method
        public string strStatus = "KHOA";
        private void frmHopDongTaiSan_Load(object sender, EventArgs e)
        {
            LoadData();
            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            if (_yeuCauTaoDVTrongKhiFormLoad == true)
                this.btnThemMoi.PerformClick();//tạo mới hợp đồng

        }

        private void PhanQuyenThemSuaXoa()
        {
            PhanQuyenSuDungForm _phanQuyen = PhanQuyenSuDungForm.GetQuyenSuDungFormTheoUser(ERP_Library.Security.CurrentUser.Info.UserID, (this.GetType().Namespace + "." + this.Name));
            btnThemMoi.Enabled = _phanQuyen.Them;
            btSua.Enabled = _phanQuyen.Sua;
            btnXoa.Enabled = _phanQuyen.Xoa;
        }
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.strStatus = "THEM";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            tblDonViTinh dvt = _dvt_Factory.CreateManagedObject();
            tblDonViTinhBindingSource.Add(dvt);
            tblDonViTinhBindingSource.MoveLast();
            GrDSDVT.Enabled = false;
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Save();
        }
        
        private void frmListDonViTinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.txtBlackHole.Focus();
            if (_dvt_Factory.IsDirty)
            {
                DialogResult dlgResult = DialogUtil.ShowSaveRequireOptionsOnFormClosing(this);
                if (DialogResult.Yes == dlgResult)
                {
                    if (false == this.Save())
                        e.Cancel = true;
                }
                else if (DialogResult.No == dlgResult)
                {
                    //không làm gì cả
                }
                else if (DialogResult.Cancel == dlgResult)
                {
                    e.Cancel = true;
                }
            }
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            if (DialogResult.Yes == XtraMessageBox.Show("Bạn có muốn xóa dòng được chọn và lưu lại???","THÔNG BÁO",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
            {
                try
                {
                    this.grdViewDonViTinh.DeleteSelectedRows();
                    btnLuu_ItemClick(sender, e);
                }
                catch (Exception)
                {
                    DialogUtil.ShowNotDeleteSuccessful();
                }
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        #endregion
        // Phân quyền thêm sửa xóa 
        private void ReadOnlyConTrolByStatus(string _strStatus)
        {
            if (_strStatus == "" || _strStatus == "THEM" || _strStatus == "SUA")
            {
                txtMaQL.ReadOnly = false;
                txtTenDVT.ReadOnly = false;
                txt_DienGiai.ReadOnly = false;
                btSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btTroVe.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else if (_strStatus == "KHOA")
            {
                txtMaQL.ReadOnly = true;
                txtTenDVT.ReadOnly = true;
                txt_DienGiai.ReadOnly = true;
                btSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btTroVe.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                GrDSDVT.Enabled = true;
            }
            PhanQuyenThemSuaXoa();
        }

        private void btSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.strStatus = "SUA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
        }

        private void btTroVe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            GrDSDVT.Enabled = true;
            using (DialogUtil.Wait(this))
                LoadData();
        }

        private void btRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            GrDSDVT.Enabled = true;
            using (DialogUtil.Wait(this))
                LoadData();
        }
    }
}