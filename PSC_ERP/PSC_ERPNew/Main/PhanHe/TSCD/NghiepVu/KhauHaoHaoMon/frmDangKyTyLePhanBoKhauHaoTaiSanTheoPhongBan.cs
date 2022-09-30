using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using System.Linq;
using PSC_ERP_Common;
using ERP_Library.Security;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace PSC_ERPNew.Main
{
    public partial class frmDangKyTyLePhanBoKhauHaoTaiSanTheoPhongBan : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDangKyTyLePhanBoKhauHaoTaiSanTheoPhongBan singleton_ = null;
        public static frmDangKyTyLePhanBoKhauHaoTaiSanTheoPhongBan Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDangKyTyLePhanBoKhauHaoTaiSanTheoPhongBan();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent = null)
        {
            FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }

        #endregion

        //Private Member field
        #region Private Member field
        IQueryable<app_users> _app_users = null;    
        List<tblTaiSanCoDinhCaBiet> _taiSanCoDinhCaBietList = null;
        int _maCongTy = CurrentUser.Info.MaCongTy;
        List<tblChungTuTyLePhanBoKhauHaoTSCD> chungTuPhanBoList = null;
        ChungTuTyLeKhauHaoTaiSanTheoBoPhan_Factory _chungTuTyLePhanBo_Factory = null;
        tblChungTuTyLePhanBoKhauHaoTSCD _chungTuTyLePhanBo = null;
        Boolean _xemLaiChungTuCu = false;
        long _maChungTu = 0;
        Boolean _daLoadXong = false;
        Int32 userID = BasicInfo.User.UserID;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmDangKyTyLePhanBoKhauHaoTaiSanTheoPhongBan()
        {
            InitializeComponent();
        }

        #endregion

        //Private Member Function
        #region Private Member Function
        private void LoadDanhSachChungTu()
        {
            _app_users = app_users_Factory.New().LayDanhSachUser_TheoMaCongTy(_maCongTy);
            chungTuPhanBoList = ChungTuTyLeKhauHaoTaiSanTheoBoPhan_Factory.New().Get_All().ToList();

            chungTuPhanBoList = chungTuPhanBoList.Where(x => (_app_users.Select(o => o.UserID).Contains(x.UserID.Value))).ToList();
            //Gán bindignSource
            tblChungTuTyLePhanBoKhauHaoTheoPhong_ListBanBindingSource.DataSource = chungTuPhanBoList;
        }
        private void LoadChungTu(long maChungTu)
        {
            //Khởi tạo factory mới
            _chungTuTyLePhanBo_Factory = ChungTuTyLeKhauHaoTaiSanTheoBoPhan_Factory.New();
            _chungTuTyLePhanBo = _chungTuTyLePhanBo_Factory.CreateAloneObject();
            _chungTuTyLePhanBo = _chungTuTyLePhanBo_Factory.Get_ChungTuDangKyTiLeKHHMByMaChungTu(_maChungTu);
            _xemLaiChungTuCu = true;
            GanBindingSource();
        }
        private void ThemMoiChungTu()
        {
            //Khởi tạo factory mới
            _chungTuTyLePhanBo_Factory = ChungTuTyLeKhauHaoTaiSanTheoBoPhan_Factory.New();
            _chungTuTyLePhanBo = _chungTuTyLePhanBo_Factory.CreateManagedObject();
            _xemLaiChungTuCu = false;
            GanBindingSource();         
            tblKy ky = Ky_Factory.New().XacDinhKy_ByNgay(app_users_Factory.New().SystemDate);
            cbKy.EditValue = ky.MaKy;
            _chungTuTyLePhanBo.UserID = userID;
            _chungTuTyLePhanBo.NgayHeThong = DateTime.Now;
            _chungTuTyLePhanBo.MaKy = ky.MaKy;
            cbKy.Enabled = !_xemLaiChungTuCu;
        }
       
        private void GanBindingSource()
        {
            //Đưa chứng từ vào list (Vì là trường hợp đặc biệt nên làm cách này)
            if (_chungTuTyLePhanBo == null)
                return;           
            tblChungTuTyLePhanBoKhauHaoTheoPhongBanBindingSource.DataSource = _chungTuTyLePhanBo;          
            //
            tblChiTietTyLePhanBoKhauHaoTaiSanTheoBoPhanBindingSource.DataSource = _chungTuTyLePhanBo.tblCT_ChungTyLePhanBoKhauHaoTSCD;
        }
        
        private Boolean DuocPhepLuuKHHM()
        {
            tblKy ky = Ky_Factory.New().Get_KyByMaKy( _chungTuTyLePhanBo.MaKy.Value);
            Boolean duocPhep = true;
            if (_chungTuTyLePhanBo != null)
            {
                if (_chungTuTyLePhanBo.tblCT_ChungTyLePhanBoKhauHaoTSCD.Count() == 0)
                {
                    DialogUtil.ShowError("Không thể lưu tỷ lệ phân bổ rỗng");
                    return false;
                }
            }
            else
            {
                DialogUtil.ShowError("Không thể lưu chứng từ rỗng");
                return false;
            }
            var checkBoPhan = _chungTuTyLePhanBo.tblCT_ChungTyLePhanBoKhauHaoTSCD.Where(x=>x.MaBoPhan.HasValue == false)
                                                                                 .Select(x=>x.tblTaiSanCoDinhCaBiet.MaTSCDCaBiet ).FirstOrDefault();
            if (checkBoPhan!=0)
            {
                DialogUtil.ShowError($"Không thể lưu mã quản lý bộ phận rỗng");
                return false;
            }
            var checkTyLe = _chungTuTyLePhanBo.tblCT_ChungTyLePhanBoKhauHaoTSCD.Where(x => x.TyLe.HasValue == false)
                                                                                .Select(x => x.tblTaiSanCoDinhCaBiet.MaTSCDCaBiet).FirstOrDefault();
            if (checkTyLe != 0)
            {
                DialogUtil.ShowError($"Không thể lưu tỷ lệ rỗng");
                return false;
            }
            var check = _chungTuTyLePhanBo.tblCT_ChungTyLePhanBoKhauHaoTSCD.GroupBy(x => x.MaTSCDCB)
                                                                           .Select(z => z.Sum(x => x.TyLe));
            foreach (int o in check.ToList())
            {
                if (o % 100 != 0) { duocPhep = false; }
            }
            if (duocPhep == false)
            {
                DialogUtil.ShowError($"Tổng tỷ lệ của một tài sản cố định cá biệt phải bằng 100%");
            }

            if (chungTuPhanBoList.Where(x => x.MaKy == _chungTuTyLePhanBo.MaKy).Select(x => x.MaChungTu).Count() >= 1 && _maChungTu == 0)
            {
                DialogUtil.ShowError($"Đã đăng ký tỷ lệ phân bổ {ky.TenKy} \n ");
                return false;
            }
            return duocPhep;
        }
        #endregion

        //Event Method
        #region Event Method
        private void frmDangKyTyLePhanBoKhauHaoTaiSanTheoPhongBan_Load(object sender, EventArgs e)
        {
            LoadDanhSachChungTu();
            //Tìm kiếm dữ liệu
            _taiSanCoDinhCaBietList = TaiSanCoDinhCaBiet_Factory.New().Context.spd_TSCD_LayDanhSachTaiSanCoDinhorCCDC(0,_maCongTy).ToList();//TaiSanCoDinhCaBiet_Factory.New().GetAll().ToList();

            // Đưa dữ liệu vào bindingsource
            tblTaiSanCoDinhCaBietBindingSource.DataSource = _taiSanCoDinhCaBietList;
            Ky_Factory ky_Factory = Ky_Factory.New();
            //lấy dư liệu và gán binding source
            tblKyBindingSource.DataSource = ky_Factory.GetAll();
            //Khởi tạo factory mới
            _chungTuTyLePhanBo_Factory = ChungTuTyLeKhauHaoTaiSanTheoBoPhan_Factory.New();
            //cài đặt delete helper
            GridUtil.DeleteHelper.Setup_ManualType(grdViewDangKyTyLeKhauHaoTSCDCBTheoBoPhan, (gridView, deleteList) =>
            {
                CT_PhanBoChiPhiCCDCChuyenTuTaiSan_Factory.FullDelete(context: _chungTuTyLePhanBo_Factory.Context, deleteList: deleteList);
            });
            ThemMoiChungTu();
            cbKy.Enabled = !_xemLaiChungTuCu;   
            tblKyBindingSource.DataSource = ky_Factory.Get_AllKy_OrderBy();
            //Lấy bộ phận
            {
                List<tblnsBoPhan> boPhanList = BoPhan_Factory.New().GetBoPhanbyMaCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy).ToList();
                tblnsBoPhan boPhan_chonTatCa = new tblnsBoPhan() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" };
                boPhanList.Insert(0, boPhan_chonTatCa);
                tblBoPhanBindingSource.DataSource = boPhanList;
            }          
            //set mặc định vài thứ
            Int32 maKyHienTai = ky_Factory.XacDinhMaKy_ByNgay(app_users_Factory.New().SystemDate);
            cbKy.EditValue = maKyHienTai;
        }
      
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
    
            //******lưu kết quả chạy KHHM         
            Save();
        }

        private bool Save()
        {
            txtBlackHole.Focus();
            //kiểm tra được phép lưu
            if (DuocPhepLuuKHHM())
            {   //khởi tạo mới factory
                try
                {
                    using (DialogUtil.WaitForSave(this))
                    {                      
                        _chungTuTyLePhanBo_Factory.SaveChangesWithoutTrackingLog();
                    }
                    //thông báo lưu thất bại
                    DialogUtil.ShowSaveSuccessful();
                    LoadDanhSachChungTu();
                    return true;
                }
                catch (Exception ex)
                {
                    //thông báo lưu thất bại
                    DialogUtil.ShowNotSaveSuccessful();
                }
            }
            return false;
        }
        private void btnXoaBangDangKyTyLe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Int32 maKy = Convert.ToInt32(cbKy.EditValue);
            tblKy ky = Ky_Factory.New().Get_KyByMaKy(maKy);
            if (DialogResult.Yes == DialogUtil.ShowYesNo("Bạn muốn xóa Bảng đăng ký tỷ lệ phân bổ khấu hao của " + ky.TenKy))
            {
                try
                {
                    ChungTuTyLeKhauHaoTaiSanTheoBoPhan_Factory.FullDelete(_chungTuTyLePhanBo_Factory.Context, _chungTuTyLePhanBo);
                    //Lưu dữ liệu
                    _chungTuTyLePhanBo_Factory.SaveChangesWithoutTrackingLog();
                    DialogUtil.ShowInfo("Xóa thành công bảng tỷ lệ phân bổ khấu hao của " + ky.TenKy);
                    this.DialogResult = DialogResult.No;
                    LoadDanhSachChungTu();
                    ThemMoiChungTu();
                  
                }
                catch (Exception ex)
                {
                    DialogUtil.ShowError("Không xóa được bảng tỷ lệ của phân bổ khấu hao của " + ky.TenKy + "\n" + ex.Message + "\n" + ex.InnerException);
                }
            }
        }      

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {          
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        #region Reports
       
       
        private void frmDangKyTyLePhanBoKhauHaoTaiSanTheoPhongBan_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtBlackHole.Focus();
            if (_chungTuTyLePhanBo_Factory.IsDirty)
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
        #endregion

        #endregion

        private void grdViewDanhSachChungTu_DoubleClick(object sender, EventArgs e)
        {
            tblChungTuTyLePhanBoKhauHaoTSCD chungTuPhanBo = grdViewDanhSachChungTu.GetFocusedRow() as tblChungTuTyLePhanBoKhauHaoTSCD;
            _maChungTu = chungTuPhanBo.MaChungTu;
            LoadChungTu(_maChungTu);
            xtraTabControl1.SelectedTabPageIndex = 0;
            cbKy.Enabled = !_xemLaiChungTuCu;
        }

        private void btn_ThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ThemMoiChungTu();
            xtraTabControl1.SelectedTabPageIndex = 0;
        }

        private void grdViewDangKyTyLeKhauHaoTSCDCBTheoBoPhan_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;  decimal? sum = decimal.Zero;
            GridColumn tyle = view.Columns["TyLe"];
            tblCT_ChungTyLePhanBoKhauHaoTSCD ctRow = this.grdViewDangKyTyLeKhauHaoTSCDCBTheoBoPhan.GetRow(e.RowHandle) as tblCT_ChungTyLePhanBoKhauHaoTSCD;

            if(ctRow !=null)
            {
                foreach (tblCT_ChungTyLePhanBoKhauHaoTSCD ct in _chungTuTyLePhanBo.tblCT_ChungTyLePhanBoKhauHaoTSCD)
                {
                   if (ct.MaTSCDCB == ctRow.MaTSCDCB)   
                    {
                           sum += ct.TyLe;
                        if (sum > repositoryItemSpinEdit_TyLe.MaxValue)
                        {
                            e.Valid = false;
                            //Set errors with specific descriptions for the columns
                            view.SetColumnError(tyle, $"Tổng tỷ lệ của TSCDCB {ctRow.tblTaiSanCoDinhCaBiet.SoHieu}  phải bằng 100%");
                        }
                    }
                }
             }

           
        }

        private void grdViewDangKyTyLeKhauHaoTSCDCBTheoBoPhan_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            tblCT_ChungTyLePhanBoKhauHaoTSCD ctRow = this.grdViewDangKyTyLeKhauHaoTSCDCBTheoBoPhan.GetRow(e.RowHandle) as tblCT_ChungTyLePhanBoKhauHaoTSCD;
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            MessageBox.Show($"Tổng tỷ lệ của TSCDCB {ctRow.tblTaiSanCoDinhCaBiet.SoHieu} phải bằng 100%", "Dữ liệu lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

       
    }
}