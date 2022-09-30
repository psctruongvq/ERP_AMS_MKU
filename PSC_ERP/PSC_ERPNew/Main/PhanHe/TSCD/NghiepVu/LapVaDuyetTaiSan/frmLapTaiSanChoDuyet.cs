using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Common;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Predefined;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERPNew.Main.Reports;
using PSC_ERP_Common.Ado.Net;
using PSC_ERP_Business.Main;
using PSC_ERP_Common.CustomDialog;
using DevExpress.XtraEditors;

namespace PSC_ERPNew.Main
{
    public partial class frmLapTaiSanChoDuyet : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmLapTaiSanChoDuyet singleton_ = null;
        public static frmLapTaiSanChoDuyet Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmLapTaiSanChoDuyet();
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

        List<tblBoPhanERPNew> _viTriList = null;
        List<tblnsBoPhan> _boPhanList = null;
        List<tblDanhMucTSCD> _tscdList = null;
        DuyetTSCD_Factory _duyetTSCD_Factory = null;
        List<tblTaiSanCoDinhCaBiet> _taiSanCoDinhCaBietList_TimDuyet = null;
        IQueryable<tblDuyetTSCD> _duyetTSCDList = null;
        List<tblDuyetTSCD> _duyetTSCDThemMoiList = null;

        #endregion

        //Member Constructor
        #region Member Constructor
        public frmLapTaiSanChoDuyet()
        {
            InitializeComponent();
        }
        #endregion

        //Private Member Function
        #region Private Member Function
        private void GanBindingSource()
        {
            tblBoPhanERPNewBindingSource.DataSource = _viTriList;
            tblBoPhanBindingSource.DataSource = _boPhanList;
            //
            tblDanhMucTSCDBindingSource.DataSource = _tscdList;
            //
            tblDuyetTSCDBindingSource.DataSource = _duyetTSCDList;
        }

        private Boolean DuocPhepLuu()
        {
            Boolean duocPhepLuu = true;
            return duocPhepLuu;
        }

        private void ChangeFocus()
        {
            this.txtBlackHole.Focus();
        }
        private bool Save()
        {
            this.ChangeFocus();
            //kiểm tra dữ liệu trước khi lưu
            if (DuocPhepLuu())
            {
                try
                {
                    //lưu lại duyệt tài sản cố định 
                    _duyetTSCD_Factory.SaveChangesWithoutTrackingLog();
                    //_duyetTSCD_Factory.SaveChanges(BusinessCodeEnum.TSCD_LapTaiSanChoDuyet.ToString());
                    DialogUtil.ShowSaveSuccessful();
                    return true;
                }
                catch (Exception ex)
                {
                    DialogUtil.ShowNotSaveSuccessful(ex.Message);                   
                }                
            }
            return false;
        }

        private void RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim()
        {
            foreach (tblDuyetTSCD duyet in _duyetTSCDThemMoiList)
            {
                tblTaiSanCoDinhCaBiet TSCDCaBietRemoveRaKhoiDanhSachTim = null;
                foreach (tblTaiSanCoDinhCaBiet taiSanCaBiet in _taiSanCoDinhCaBietList_TimDuyet)
                {
                    if (taiSanCaBiet.MaTSCDCaBiet == duyet.MaTSCDCaBiet)
                    {
                        TSCDCaBietRemoveRaKhoiDanhSachTim = taiSanCaBiet;
                        break;
                    }
                }
                if (TSCDCaBietRemoveRaKhoiDanhSachTim != null)
                {
                    tblTaiSanCoDinhCaBietBindingSource_TimDuyet.Remove(TSCDCaBietRemoveRaKhoiDanhSachTim);
                }
            }
        }
        private void TimTaiSanChoDuyet()
        {
            // Lấy mã phòng ban 
            Int32 maviTri = Convert.ToInt32(cbBoPhan.EditValue);
            Int32 maPhongBan = Convert.ToInt32(treeListLookUpEdit_BoPhan.EditValue.ToString()== "" ? 0 : treeListLookUpEdit_BoPhan.EditValue);

            // Lấy mã tài sản cố định cá biệt
            Int32 maTaiSanCDCB = Convert.ToInt32(cbTaiSanCD.EditValue);
            // Lấy loại nghiệp vụ
            Int32 loaiNghiepVu = Convert.ToInt32(radioHinhThucDuyet.EditValue);
            //Tìm kiếm dữ liệu
            _duyetTSCDList = _duyetTSCD_Factory.Get_DanhSachChoDuyetVaDaDuyetNhungChuaThucHienNghiepVuTheoPhongBanAndMaViTriAndMaTSCDAndLoaiNghiepVu(maPhongBan, maTaiSanCDCB, loaiNghiepVu, PSC_ERP_Global.Main.UserID);
            // Đưa dữ liệu vào bindingsource
            tblDuyetTSCDBindingSource.DataSource = _duyetTSCDList;
            // Thông báo khi không có dữ liệu
            if (_duyetTSCDList.Count() == 0)
            {
                DialogUtil.ShowOK("Không có dữ liệu");
            }
        }
        #endregion

        //Event Method
        #region Event Method
        private void btnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Sys.frmEntityTrackingLog.ShowSingleton(null, BusinessCodeEnum.TSCD_LapTaiSanChoDuyet, this.MdiParent);
        }
        private void frmLapTaiSanChoDuyet_Load(object sender, EventArgs e)
        {
            //khởi tạo dữ liệu 
            _duyetTSCD_Factory = DuyetTSCD_Factory.New();
            //Lấy bộ phận
            _viTriList = BoPhanERPNew_Factory.New().GetAll().ToList();
            tblBoPhanERPNew boPhan_vitri_chonTatCa = new tblBoPhanERPNew() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" };
            _viTriList.Insert(0, boPhan_vitri_chonTatCa);

            //Lấy bộ phận
            _boPhanList = BoPhan_Factory.New().GetBoPhanbyMaCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy).ToList();
            tblnsBoPhan boPhan_chonTatCa = new tblnsBoPhan() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" };
            _boPhanList.Insert(0, boPhan_chonTatCa);
            //Lấy tài sản cá biệt phòng ban
            _tscdList = DanhMucTSCD_Factory.New().Get_DanhSachTaiSanCoDinh_CoTSCDCaBietChuaThanhLy().ToList();
            tblDanhMucTSCD tscd_chonTatCa = new tblDanhMucTSCD() { ID = 0, MaQuanLy = "<<Tất cả>>", Ten = "<<Tất cả>>" };
            _tscdList.Insert(0, tscd_chonTatCa);

            // Đưa checkbox lên lưới
            GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.grdViewTSCDCaBiet, colChon);
            // Set số thứ tự cho lưới
            GridUtil.SetSTTForGridView(grdViewTSCDCaBiet);
            //gan nghiep vu mac dinh la dieu chuyen noi bo
            radioHinhThucDuyet.EditValue = (Int32)LoaiNghiepVuTaiSanEnum.DieuChuyenNoiBo;
            // Đưa dữ liệu vào bindingsource
            this.GanBindingSource();
            //cài đặt delete helper
            GridUtil.DeleteHelper.Setup_ManualType(grdViewDuyetTSCD, (GridView gridView, List<Object> deleteList) =>
            {
                //xóa duyệt tài sản cố định cá biệt
                DuyetTSCD_Factory.FullDelete(context: _duyetTSCD_Factory.Context, deleteList: deleteList);
                // Xóa duyệt tài sản cố định trong danh sách duyệt thêm mới
                foreach (tblDuyetTSCD item in deleteList)
                {
                    _duyetTSCDThemMoiList.Remove(item);
                }
            });
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //Khởi tạo lại duyệt tài sản 
            //_duyetTSCDList =  ;
            // Lấy mã phòng ban 
            Int32 maViTri = Convert.ToInt32(cbBoPhan.EditValue);
            Int32 maPhongBan = Convert.ToInt32(treeListLookUpEdit_BoPhan.EditValue.ToString() == "" ? 0 : treeListLookUpEdit_BoPhan.EditValue);

            // Lấy mã tài sản cố định cá biệt
            Int32 maTaiSanCDCB = Convert.ToInt32(cbTaiSanCD.EditValue);
            // Lấy loại nghiệp vụ
            Int32 loaiNghiepVu = Convert.ToInt32(radioHinhThucDuyet.EditValue);
            //Tìm kiếm dữ liệu
            _taiSanCoDinhCaBietList_TimDuyet = TaiSanCoDinhCaBiet_Factory.New().Get_DanhSachTSCDCaBietTheoPhongBanAndMaTruongAndMaTSCD_PhucVuLapDanhSachTSChoDuyet(maPhongBan, maViTri, maTaiSanCDCB, loaiNghiepVu).ToList();

            // Đưa dữ liệu vào bindingsource
            tblTaiSanCoDinhCaBietBindingSource_TimDuyet.DataSource = _taiSanCoDinhCaBietList_TimDuyet;
            // Xóa duyệt tài sản cố định cá biệt vừa chọn ra khỏi danh sách tìm
            RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim();
            // Thông báo khi không có dữ liệu
            if (_taiSanCoDinhCaBietList_TimDuyet.Count() == 0)
            {
                DialogUtil.ShowOK("Không có dữ liệu");
            }
        }
        private void btnDuaXuongDanhSach_Click(object sender, EventArgs e)
        {
            this.ChangeFocus();
            Boolean coTaiSanCaBietDuocChonTuDanhSach = false;
            if (_taiSanCoDinhCaBietList_TimDuyet == null)
            {
                DialogUtil.ShowWarning("Chọn tài sản cần lập chờ duyệt.");
                return;
            }
            //lặp qua từng dòng tài sản tìm được
            foreach (tblTaiSanCoDinhCaBiet taiSanCaBiet in _taiSanCoDinhCaBietList_TimDuyet)
            {
                //nếu tài sản được chọn
                if (taiSanCaBiet.Chon == true)
                {
                    coTaiSanCaBietDuocChonTuDanhSach = true;
                    //khởi tạo duyệt tài sản cố định
                    tblDuyetTSCD duyetTSCDNew = _duyetTSCD_Factory.CreateManagedObject();
                    duyetTSCDNew.MaTSCDCaBiet = taiSanCaBiet.MaTSCDCaBiet;
                    duyetTSCDNew.NgayLapDS = app_users_Factory.New().SystemDate;
                    duyetTSCDNew.UserLap = PSC_ERP_Global.Main.UserID;
                    duyetTSCDNew.LoaiNghiepVu = Convert.ToInt32(radioHinhThucDuyet.EditValue);
                    // Thêm vào bindingsource
                    tblDuyetTSCDBindingSource.Add(duyetTSCDNew);
                    _duyetTSCDThemMoiList.Add(duyetTSCDNew);
                }
            }
            //thông báo người dùng nếu chưa chọn bất cứ dòng nào từ danh sách duyệt
            if (coTaiSanCaBietDuocChonTuDanhSach == false)
            {
                DialogUtil.ShowWarning("Chưa chọn dữ liệu.");
                return;
            }
            // Xóa duyệt tài sản cố định cá biệt vừa chọn ra khỏi danh sách tìm
            RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim();
        }

        private void btnTimTaiSanChoDuyet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TimTaiSanChoDuyet();
        }
        private void radioHinhThucDuyet_EditValueChanged(object sender, EventArgs e)
        {
            TaoDanhChoDuyetSachRong_LienKetVoiFactory();
        }

        private void TaoDanhChoDuyetSachRong_LienKetVoiFactory()
        {
            _duyetTSCD_Factory = DuyetTSCD_Factory.New();
            //tao danh sach rong co lien ket voi factory
            _duyetTSCDList = _duyetTSCD_Factory.Get_DanhSachChoDuyetRong();
            //Gán bindingsource
            tblDuyetTSCDBindingSource.DataSource = _duyetTSCDList;
            ////xóa các item ra khỏi context
            //if (_duyetTSCDThemMoiList != null)
            //    DuyetTSCD_Factory.FullDeleteDuyetTSCDCaBiet(_duyetTSCD_Factory.Context, _duyetTSCDThemMoiList.ToList<Object>());
            //tao moi danh sach duyet duoc them moi
            _duyetTSCDThemMoiList = new List<tblDuyetTSCD>();
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Lấy dòng tài sản hiện tại đã chọn trên lưới
            tblDuyetTSCD duyetTSCDCurrent = tblDuyetTSCDBindingSource.Current as tblDuyetTSCD;
            if (duyetTSCDCurrent == null)
            {
                DialogUtil.ShowWarning("Chọn dòng cần xóa.");
                return;
            }
            //Xóa trong factory
            _duyetTSCD_Factory.DeleteObject(duyetTSCDCurrent);
            //Xóa trong bindingSource
            tblDuyetTSCDBindingSource.Remove(duyetTSCDCurrent);
        }
        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int nam = 0;
            int maViTri = Convert.ToInt32(cbBoPhan.EditValue);
            int maPhongBan = Convert.ToInt32(treeListLookUpEdit_BoPhan.EditValue);
            int loaiNghiepVu = Convert.ToInt32(radioHinhThucDuyet.EditValue);

            frmDialogChonNamVaCheckChonInChiTiet dlgChonNam = new frmDialogChonNamVaCheckChonInChiTiet();
            dlgChonNam.ShowDialog(this);
            nam = dlgChonNam.Nam;

            ReportHelper.ShowReport("DanhSachTaiSanChoDuyet", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_DanhSachTaiSanChoDuyet", "@MaPhongBan,@LoaiNghiepVu,@Nam,@InChiTiet", maPhongBan, loaiNghiepVu, nam, dlgChonNam.CoChiTiet);
                #region Extend table
                //Tao Bang Ngay Lap
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("NgayLap", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["NgayLap"] = DateTime.Now.Date;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "SubInfo";
                dataSet.Tables.Add(dtngay);
                #endregion
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
        }
        #endregion

        private void frmLapTaiSanChoDuyet_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtBlackHole.Focus();
            if (_duyetTSCD_Factory.IsDirty)
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
    }
}
