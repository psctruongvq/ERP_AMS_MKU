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
using PSC_ERP_Common.CustomDialog;
using PSC_ERPNew.Main.Reports;
using PSC_ERP_Common.Ado.Net;
using PSC_ERP_Business.Main;
using DevExpress.XtraEditors;

namespace PSC_ERPNew.Main
{
    public partial class frmTaiSanChoDuyet : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmTaiSanChoDuyet singleton_ = null;
        public static frmTaiSanChoDuyet Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmTaiSanChoDuyet();
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
        IQueryable<tblDuyetTSCD> _duyetList = null;
        DuyetTSCD_Factory _duyetTSCD_Factory = null;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmTaiSanChoDuyet()
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
        }

        private Boolean DuocPhepLuu()
        {
            Boolean duocPhepLuu = true;
            return duocPhepLuu;
        }

        private bool Save()
        {
            this.ChangeFocus();
            //kiểm tra dữ liệu trước khi lưu
            if (DuocPhepLuu())
            {
                try
                {
                    _duyetTSCD_Factory.SaveChangesWithoutTrackingLog();
                    //_duyetTSCD_Factory.SaveChanges(BusinessCodeEnum.TSCD_DuyetTaiSan.ToString());

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

        private void ChangeFocus()
        {
            this.txtBlackHole.Focus();
        }
        #endregion

        //Event Method
        #region Event Method

        private void btnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Sys.frmEntityTrackingLog.ShowSingleton(null, BusinessCodeEnum.TSCD_DuyetTaiSan, this.MdiParent);
        }
        private void frmTaiSanChoDuyet_Load(object sender, EventArgs e)
        {
            _duyetTSCD_Factory = DuyetTSCD_Factory.New();
            // Lấy dữ bộ phận
            _viTriList = BoPhanERPNew_Factory.New().GetAll().ToList();
            tblBoPhanERPNew boPhan_chonTatCa_vitri = new tblBoPhanERPNew() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" };
            _viTriList.Insert(0, boPhan_chonTatCa_vitri);

            _boPhanList = BoPhan_Factory.New().GetBoPhanbyMaCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy).ToList();
            tblnsBoPhan boPhan_chonTatCa = new tblnsBoPhan() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" };
            _boPhanList.Insert(0, boPhan_chonTatCa);

            //Lấy tài sản cố định cá biệt
            _tscdList = DanhMucTSCD_Factory.New().Get_DanhSachTaiSanCoDinh_CoTSCDCaBietChuaThanhLy().ToList();
            tblDanhMucTSCD tscd_chonTatCa = new tblDanhMucTSCD() { ID = 0, MaQuanLy = "<<Tất cả>>", Ten = "<<Tất cả>>" };
            _tscdList.Insert(0, tscd_chonTatCa);
            //Đưa checkbox lên lưới
            GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.grdViewTSCDCaBiet_Duyet, colDuyet);
            // Set số thứ tự cho lưới
            GridUtil.SetSTTForGridView(grdViewTSCDCaBiet_Duyet);
            this.GanBindingSource();
            //cài đặt delete helper
            GridUtil.DeleteHelper.Setup_ManualType(grdViewTSCDCaBiet_Duyet, (GridView gridView, List<Object> deleteList) =>
            {
                //xóa duyệt tài sản cố định cá biệt
                DuyetTSCD_Factory.FullDelete(context: _duyetTSCD_Factory.Context, deleteList: deleteList);
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
            // Lấy mã phòng ban khi chọn
            Int32 maViTri = Convert.ToInt32(cbBoPhan.EditValue);
            if (treeListLookUpEdit_BoPhan.EditValue.ToString() == "")
            {
                DialogUtil.ShowWarning("Chưa chọn bộ phận!\nVui lòng chọn bộ phận!");
                return;
            }
            Int32 maPhongBan = Convert.ToInt32(treeListLookUpEdit_BoPhan.EditValue);
            //Lấy mã tài sản khi chọn
            Int32 maTaiSanCDCB = Convert.ToInt32(cbTaiSanCD.EditValue);
            //Lấy loại nghiệp vụ khi chọn
            Int32 loaiNghiepVu = Convert.ToInt32(radioHinhThucDuyet.EditValue);

            //Tìm kiếm
            _duyetList = _duyetTSCD_Factory.Get_DanhSachChoDuyetVaDaDuyetNhungChuaThucHienNghiepVuTheoPhongBanAndMaViTriAndMaTSCDAndLoaiNghiepVu(maPhongBan, maViTri, maTaiSanCDCB, loaiNghiepVu, 0);
            // Đưa dữ liệu vào bindingsource
            tblDuyetTSCDBindingSource.DataSource = _duyetList;
        }

        private void radioHinhThucDuyet_EditValueChanged(object sender, EventArgs e)
        {
            _duyetTSCD_Factory = DuyetTSCD_Factory.New();
            _duyetList = _duyetTSCD_Factory.Get_DanhSachChoDuyetRong();
            // Đưa dữ liệu vào bindingsource
            tblDuyetTSCDBindingSource.DataSource = _duyetList;
        }
        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime tuNgay;
            DateTime denNgay;
            int maViTri = Convert.ToInt32(cbBoPhan.EditValue);
            int maPhongBan = Convert.ToInt32(treeListLookUpEdit_BoPhan.EditValue.ToString() == "" ? 0 : treeListLookUpEdit_BoPhan.EditValue);
            int loaiNghiepVu = Convert.ToInt32(radioHinhThucDuyet.EditValue);

            frmDialogChonTuNgayDenNgayVaCheckChonInChiTiet dlgChonNgay = new frmDialogChonTuNgayDenNgayVaCheckChonInChiTiet();
            dlgChonNgay.ShowDialog(this);
            tuNgay = dlgChonNgay.TuNgay;
            denNgay = dlgChonNgay.DenNgay;

            ReportHelper.ShowReport("DanhSachTaiSanDuocDuyet", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_DanhSachTaiSanDuocDuyet", "@MaPhongBan,@LoaiNghiepVu,@TuNgay,@DenNgay,@InChiTiet", maPhongBan, loaiNghiepVu, tuNgay, denNgay, dlgChonNgay.CoChiTiet);
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

        private void frmTaiSanChoDuyet_FormClosing(object sender, FormClosingEventArgs e)
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
