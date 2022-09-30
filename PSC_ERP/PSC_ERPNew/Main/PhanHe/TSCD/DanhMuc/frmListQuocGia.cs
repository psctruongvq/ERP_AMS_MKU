using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Common;
using ERP_Library;

namespace PSC_ERPNew.Main
{
    public partial class frmListQuocGia : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmListQuocGia singleton_ = null;
        public static frmListQuocGia Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmListQuocGia();
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
        QuocGia_Factory _quocGia_Factory = QuocGia_Factory.New();
        IQueryable<tblQuocGia> _quocGiaList = null;
        Boolean _yeuCauTaoQuocGiarongKhiFormLoad = false;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmListQuocGia()
        {
            InitializeComponent();
            _yeuCauTaoQuocGiarongKhiFormLoad = false;
        }
        public frmListQuocGia(Boolean taoHopDongMoi)
        {
            InitializeComponent();
            _yeuCauTaoQuocGiarongKhiFormLoad = taoHopDongMoi;
        }

        #endregion

        //Private Member Function
        #region Private Member Function
        private void LoadData()
        {
            _quocGiaList = _quocGia_Factory.GetAll();
            // Cài đặt lưới
           GridUtil.SetSTTForGridView(this.grdViewQuocGia);
            GanBindingSource();
        }

        private void GanBindingSource()
        {
            tblQuocGiaBindingSource.DataSource = _quocGiaList;
        }
        private Boolean Save()
        {
            this.txtBlackHole.Focus();
            if (DuocPhepLuu())
                try
                {
                    _quocGia_Factory.SaveChangesWithoutTrackingLog();
                    //_quocGia_Factory.SaveChanges();//lưu lại
                    //
                    this.strStatus = "KHOA";
                    this.ReadOnlyConTrolByStatus(this.strStatus);
                    DialogUtil.ShowSaveSuccessful();
                    return true;
                }
                catch (System.Exception ex)
                {
                    DialogUtil.ShowNotSaveSuccessful();
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
        private void frmHopDongTaiSan_Load(object sender, EventArgs e)
        {
            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            LoadData();
            if (_yeuCauTaoQuocGiarongKhiFormLoad == true)
                this.btnThemMoi.PerformClick();//tạo mới hợp đồng
        }
        public string strStatus = "KHOA";
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.strStatus = "THEM";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            tblQuocGia qg = _quocGia_Factory.CreateManagedObject();
            tblQuocGiaBindingSource.Add(qg);
            tblQuocGiaBindingSource.MoveLast();
            GrDSQG.Enabled = false;
        }
        private void PhanQuyenThemSuaXoa()
        {
            PhanQuyenSuDungForm _phanQuyen = PhanQuyenSuDungForm.GetQuyenSuDungFormTheoUser(ERP_Library.Security.CurrentUser.Info.UserID, (this.GetType().Namespace + "." + this.Name));
            btnThemMoi.Enabled = _phanQuyen.Them;
            btnSua.Enabled = _phanQuyen.Sua;
            btnXoa.Enabled = _phanQuyen.Xoa;
        }
        private void ReadOnlyConTrolByStatus(string _strStatus)
        {
            if (_strStatus == "" || _strStatus == "THEM" || _strStatus == "SUA")
            {
                txtMaQL.ReadOnly = false;
                txtTenQuocGia.ReadOnly = false;
                txt_DienGiai.ReadOnly = false;
                txt_TenVietTat.ReadOnly = false;
                btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnTroVe.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else if (_strStatus == "KHOA")
            {
                txtMaQL.ReadOnly = true;
                txtTenQuocGia.ReadOnly = true;
                txt_DienGiai.ReadOnly = true;
                txt_TenVietTat.ReadOnly = true;
                btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnTroVe.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                GrDSQG.Enabled = true;
            }
            PhanQuyenThemSuaXoa();
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Save();
        }

        private void frmListDonViTinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtBlackHole.Focus();
            if (_quocGia_Factory.IsDirty)
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
            if (DialogResult.Yes== XtraMessageBox.Show("Bạn đồng ý xóa dòng được chọn và lưu lại??","THÔNG BÁO",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
            {
                try
                {
                    this.grdViewQuocGia.DeleteSelectedRows();
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

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.strStatus = "SUA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
        }

        private void btnTroVe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            GrDSQG.Enabled = true;
            using (DialogUtil.Wait(this))
                LoadData();
        }
    }
}