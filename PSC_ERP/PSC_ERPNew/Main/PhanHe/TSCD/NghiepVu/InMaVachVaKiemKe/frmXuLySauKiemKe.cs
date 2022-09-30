using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Common;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.Data;
using PSC_ERPNew.Main.Reports;
using PSC_ERP_Common.Ado.Net;
using PSC_ERP_Business.Main;
using DevExpress.XtraGrid.Columns;
using PSC_ERPNew.Main.PhanHe.TSCD.UsefulDialog;
using System.Data.Objects.DataClasses;

namespace PSC_ERPNew.Main
{
    public partial class frmXuLySauKiemKe : DevExpress.XtraEditors.XtraForm
    {

       
        internal List<tblBoPhanERPNew> _viTriList = new List<tblBoPhanERPNew>();
        internal int MaCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        internal KiemKeTaiSan_Factory _kiemKeTaiSan_Factory = KiemKeTaiSan_Factory.New();
        internal List<tblKiemKeTaiSan> _DSDaKiemKe = new List<tblKiemKeTaiSan>();
        internal List<tblKiemKeTaiSan> _DSChonXuLy = new List<tblKiemKeTaiSan>();
        internal List<spd_tblKiemKeTaiSan_DanhSachTSDuocKiemKeDenNgay_Result> _dsTaiSanDaKiemKeDenNgay
          = new List<spd_tblKiemKeTaiSan_DanhSachTSDuocKiemKeDenNgay_Result>();

        public frmXuLySauKiemKe()
        {
            InitializeComponent();
        }

        private void frmXuLySauKiemKe_Load(object sender, EventArgs e)
        {

            tblTaiSanCoDinhCaBiet_BindingSource.DataSource = KiemKeTaiSan_Factory.New().Context.tblTaiSanCoDinhCaBiets.Where(o=>o.MaCongTy == MaCongTy).ToList();
            _viTriList = BoPhanERPNew_Factory.New().GetAll().ToList();
            bindingSource_ViTri.DataSource = _viTriList;
            bindingSource_DSDaKiemKe.DataSource = _DSDaKiemKe;
            // bindingSource_DSChonXuLy.DataSource = _DSChonXuLy;

            _DSChonXuLy = KiemKeTaiSan_Factory.New().Get_TaiSanCoDinhCaBiet_TrongDanhSachXuLyKiemKe(MaCongTy).ToList();
            bindingSource_DSChonXuLy.DataSource = _DSChonXuLy;
            //đánh số thứ tự dòng trên gridView
            GridUtil.SetSTTForGridView(gridV_DaKiemKe);
            GridUtil.SetSTTForGridView(gridV_DSChonXuLy);
            cboLocDuLieu.SelectedIndex = 0; // 0 = Tất cả | 1 = Sai Vị Trí | 2 = Chưa Kiểm Kê | 3 = Đã Kiểm Kê
            cboLocDuLieuSauKiemKe.SelectedIndex = 0;// 0 = Tất cả | 1 = Đã XL| 2 = Chưa XL 
        }

        private void frmXuLySauKiemKe_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            if (_kiemKeTaiSan_Factory.IsDirty)
            {
                DialogResult dlgResult = DialogUtil.ShowSaveRequireOptionsOnFormClosing(this);
                if (DialogResult.Yes == dlgResult)
                {
                    btnLuu.PerformClick();
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

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void InBaoCaoKiemKeSauXuLy(int MaCongTy, string Flag)
        {
            frmDialogChonViTri dlg = new frmDialogChonViTri();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                int maViTri = dlg.MaViTri;
                string tieuDeTheoBaoCao = string.Empty;
                switch (Flag)
                {
                    case "ALL": tieuDeTheoBaoCao = "BÁO CÁO DANH SÁCH TỔNG KIỂM KÊ"; break;
                    case "CANXULY": tieuDeTheoBaoCao = "BÁO CÁO DANH SÁCH KIỂM KÊ CẦN XỬ LÝ"; break;
                    case "CHUAXULY": tieuDeTheoBaoCao = "BÁO CÁO DANH SÁCH KIỂM KÊ CHƯA XỬ LÝ"; break;
                    case "DAXULY": tieuDeTheoBaoCao = "BÁO CÁO DANH SÁCH KIỂM KÊ ĐÃ XỬ LÝ"; break;
                }
                ReportHelper.ShowReport("DanhSachTongKiemKe", () =>
                {
                    DataSet dataSet = new DataSet();
                    SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                    dataAccess.FillDataSet(ref dataSet
                                                , "MainData"
                                                , "spRpt_TSCD_DanhSachTaiSan_TongKiemKe"
                                                , "@MaCongTy,@flag,@MaViTri"
                                                , MaCongTy
                                                , Flag
                                                , maViTri
                                            ); //ALL; CANXULY; CHUAXULY; DAXULY
                                               //Tao Bang Ngay Lap
                DataTable SubInfo = new DataTable();
                    SubInfo.Columns.Add("NgayIn", typeof(DateTime));
                    SubInfo.Columns.Add("TieuDeTheoBaoCao", typeof(string));
                //Add dòng 1
                DataRow dr = SubInfo.NewRow();
                    dr["NgayIn"] = DateTime.Today.Date;
                    dr["TieuDeTheoBaoCao"] = tieuDeTheoBaoCao;
                    SubInfo.Rows.Add(dr);
                    SubInfo.TableName = "SubInfo";
                    dataSet.Tables.Add(SubInfo);
                    return dataSet;
                }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
            }
        }

        private void btnInBaoCaoTongKiemKe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InBaoCaoKiemKeSauXuLy(MaCongTy, "ALL");
        }

        private void btnInBaoCaoDSCanXL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InBaoCaoKiemKeSauXuLy(MaCongTy, "CANXULY");
        }

        private void btnInBaoCaoDSChuaXL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            InBaoCaoKiemKeSauXuLy(MaCongTy, "CHUAXULY");
        }

        private void btnInBaoCaoDSDaXL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InBaoCaoKiemKeSauXuLy(MaCongTy, "DAXULY");
        }
        private void btnInTheoViTri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDialogChonViTri dlg = new frmDialogChonViTri();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                int maViTri = dlg.MaViTri;
                ReportHelper.ShowReportCustomNameFile("BÁO CÁO DANH SÁCH KIỂM KÊ THEO VỊ TRÍ", "DanhSachTongKiemKeTheoViTri", () =>
                {
                    DataSet dataSet = new DataSet();
                    SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                    dataAccess.FillDataSet(ref dataSet
                                                , "MainData"
                                                , "spRpt_TSCD_DanhSachTaiSan_TongKiemKe"
                                                , "@MaCongTy,@flag,@MaViTri"
                                                , MaCongTy
                                                , "ALL"
                                                , maViTri
                                            ); //ALL; CANXULY; CHUAXULY; DAXULY
                                               //Tao Bang Ngay Lap
                    DataTable SubInfo = new DataTable();
                    SubInfo.Columns.Add("NgayIn", typeof(DateTime));
                    SubInfo.Columns.Add("TieuDeTheoBaoCao", typeof(string));
                    //Add dòng 1
                    DataRow dr = SubInfo.NewRow();
                    dr["NgayIn"] = DateTime.Today.Date;
                    dr["TieuDeTheoBaoCao"] = "BÁO CÁO DANH SÁCH KIỂM KÊ THEO VỊ TRÍ";
                    SubInfo.Rows.Add(dr);
                    SubInfo.TableName = "SubInfo";
                    dataSet.Tables.Add(SubInfo);
                    return dataSet;
                }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
            }
        }
        #region GridV_DaKiemKe
        private void btnLayDuLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LayDuLieu();
            tabC_XLSauKiemKe.SelectedTab = tabDSDaKiemKe;
        }
        private void LayDuLieu()
        {
            using (PSC_ERP_Common.DialogUtil.Wait(this))
            {
                _dsTaiSanDaKiemKeDenNgay = KiemKeTaiSan_Factory.New().Context
                    .spd_tblKiemKeTaiSan_DanhSachTSDuocKiemKeDenNgay(this.MaCongTy)
                    .ToList();
               
                if (_dsTaiSanDaKiemKeDenNgay.Count > 0)
                {
                    if (_DSChonXuLy.Count > 0)
                    {
                        foreach (tblKiemKeTaiSan trongdanhsachxuly in _DSChonXuLy)
                        {
                            _dsTaiSanDaKiemKeDenNgay.Remove(
                                    _dsTaiSanDaKiemKeDenNgay.Where(o=>o.ID == trongdanhsachxuly.ID).FirstOrDefault()
                                );
                        }
                    }
                    _DSDaKiemKe = convertListToTblKiemKeTaiSanEntities
                        ( 
                            _dsTaiSanDaKiemKeDenNgay.Where(o=>o.TrangthaiSauKiemKe!= "trongdanhsachxuly").ToList()
                        );
                    bindingSource_DSDaKiemKe.DataSource = _DSDaKiemKe;
                }
                else if (_dsTaiSanDaKiemKeDenNgay.Count == 0)
                {
                    XtraMessageBox.Show(this, "<b>Không có dữ liệu</b>"
                                        , "THÔNG BÁO", MessageBoxButtons.OK
                                        , MessageBoxIcon.Information
                                        , DevExpress.Utils.DefaultBoolean.True);
                }
                bindingSource_DSDaKiemKe.ResetBindings(true);
            }
        }
        private void btnDuaVaoDSXL_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean tsDuocChonFlag = false;
                using (DialogUtil.Wait())
                {
                    if (_DSDaKiemKe.Count > 0 && _DSDaKiemKe.Where(o => o.Chon == true).ToList().Count > 0)
                    {
                        tsDuocChonFlag = true;
                        if (_DSChonXuLy.Count == 0)
                            _DSChonXuLy = _DSDaKiemKe.Where(o => o.Chon == true).ToList();
                        else
                        {
                            _DSChonXuLy.AddRange(_DSDaKiemKe.Where(o => o.Chon == true).ToList()); 
                        }
                        bindingSource_DSChonXuLy.ResetBindings(true);
                        bindingSource_DSChonXuLy.DataSource = _DSChonXuLy;
                        gridC_DSChonXuLy.Refresh();
                        gridV_DSChonXuLy.RefreshData();
                        // Xóa dòng vừa chọn ra khỏi danh sách tìm
                        RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim();
                        tabC_XLSauKiemKe.SelectedTab = tabDSChonXuLy;
                    }
                }
                //thông báo người dùng nếu chưa chọn bất cứ dòng nào từ danh sách duyệt
                if (tsDuocChonFlag == false) { DialogUtil.ShowWarning("Chưa chọn dữ liệu."); return; }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, "<color=red>Lỗi:</color>" + ex.ToString()
                                        , "Lỗi"
                                        , MessageBoxButtons.OK
                                        , MessageBoxIcon.Error
                                        , DevExpress.Utils.DefaultBoolean.True);
            }

        }

        private void gridV_DaKiemKe_DataSourceChanged(object sender, EventArgs e)
        {
            gridV_DaKiemKe.RowStyle += GridV_DaKiemKe_RowStyle;
            gridV_DaKiemKe.RowCellStyle += GridV_DaKiemKe_RowCellStyle;
        }
        private static void ChangeColorRow_gridV_DaKiemKe(object e, GridView View, Color colorCheck, Color colorUnCheck)
        {
            if (e is RowCellStyleEventArgs)
            {
                if (View.GetRowCellDisplayText(((RowCellStyleEventArgs)e).RowHandle, "TaiSanThua") == "Checked")
                {
                    ((RowCellStyleEventArgs)e).Appearance.BackColor = Color.FromArgb(150, colorCheck);
                }
                if (View.GetRowCellDisplayText(((RowCellStyleEventArgs)e).RowHandle, "DaQuet") == "Unchecked")
                {
                    ((RowCellStyleEventArgs)e).Appearance.BackColor = Color.FromArgb(150, colorUnCheck);
                }
            }
            if (e is RowStyleEventArgs)
            {
                if (View.GetRowCellDisplayText(((RowStyleEventArgs)e).RowHandle, "TaiSanThua") == "Checked")
                {
                    ((RowStyleEventArgs)e).Appearance.BackColor = Color.FromArgb(150, colorCheck);
                }
                if (View.GetRowCellDisplayText(((RowStyleEventArgs)e).RowHandle, "DaQuet") == "Unchecked")
                {
                    ((RowStyleEventArgs)e).Appearance.BackColor = Color.FromArgb(150, colorUnCheck);
                }
            }
        }
        private void GridV_DaKiemKe_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (_DSDaKiemKe != null && _DSDaKiemKe.Count() > 0)
            {
                GridView View = sender as GridView;
                ChangeColorRow_gridV_DaKiemKe(e, View, Color.LightCoral, Color.LightGoldenrodYellow);
            }
        }

        private void GridV_DaKiemKe_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (_DSDaKiemKe != null && _DSDaKiemKe.Count > 0)
            {
                GridView View = sender as GridView;
                ChangeColorRow_gridV_DaKiemKe(e, View, Color.LightCoral, Color.LightGoldenrodYellow);
            }
        }

      
        private void gridV_DaKiemKe_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            int soTaiSanDaKK = 0, soTaiSanChuaKK = 0, soTaiSaiViTri = 0, tongTaiSan = 0;
            tongTaiSan = _DSDaKiemKe.Count;
            soTaiSaiViTri = _DSDaKiemKe.Count(o => o.TaiSanThua == true);
            soTaiSanChuaKK = _DSDaKiemKe.Count(o => o.DaQuet == false);
            soTaiSanDaKK = _DSDaKiemKe.Count(o => o.DaQuet == true);

            if (Convert.ToString((e.Item as GridSummaryItem).Tag) == "dakiemke")
            {
                e.TotalValue = $"{soTaiSanDaKK}/{tongTaiSan}";
            }
            if (Convert.ToString((e.Item as GridSummaryItem).Tag) == "chuakiemke")
            {
                e.TotalValue = $"{soTaiSanChuaKK}/{tongTaiSan}";
            }
            if (Convert.ToString((e.Item as GridSummaryItem).Tag) == "saivitri")
            {
                e.TotalValue = $"{soTaiSaiViTri}/{tongTaiSan}";
            }
            
        }//end Method
        private void RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim()
        {
            _DSDaKiemKe = _DSDaKiemKe.Where(o=>o.Chon!= true).ToList(); 
            bindingSource_DSDaKiemKe.DataSource = _DSDaKiemKe;
        }

        private void cboLocDuLieu_SelectedIndexChanged(object sender, EventArgs e)
        {// 0 = Tất cả | 1 = Sai Vị Trí | 2 = Chưa Kiểm Kê | 3 = Đã Kiểm Kê
                switch (cboLocDuLieu.SelectedIndex)
                {
                    case 0:
                        gridV_DaKiemKe.Columns["TaiSanThua"].ClearFilter();
                        gridV_DaKiemKe.Columns["colTaiSanThieu"].ClearFilter();
                        gridV_DaKiemKe.Columns["DaQuet"].ClearFilter();
                        break;
                    case 1:
                        gridV_DaKiemKe.Columns["colTaiSanThieu"].ClearFilter();
                        gridV_DaKiemKe.Columns["DaQuet"].ClearFilter();
                        gridV_DaKiemKe.Columns["TaiSanThua"].FilterInfo = new ColumnFilterInfo(ColumnFilterType.Value, null, "[TaiSanThua] = true");
                        break;
                    case 2:
                        gridV_DaKiemKe.Columns["TaiSanThua"].ClearFilter();
                        gridV_DaKiemKe.Columns["DaQuet"].ClearFilter();
                        gridV_DaKiemKe.Columns["colTaiSanThieu"].FilterInfo = new ColumnFilterInfo(ColumnFilterType.Value, null, "[colTaiSanThieu] = true");
                        break;
                    case 3:
                        gridV_DaKiemKe.Columns["TaiSanThua"].ClearFilter();
                        gridV_DaKiemKe.Columns["colTaiSanThieu"].ClearFilter();
                        gridV_DaKiemKe.Columns["DaQuet"].FilterInfo = new ColumnFilterInfo(ColumnFilterType.Value, null, "[DaQuet] = true");
                        break;
                } 
        }
        #endregion

        /// <summary>
        /// Chuyển đổi Object từ Store (dựa trên ngày hiện tại) sang TblKiemKeTaiSanEntities.
        /// </summary>
        /// <param name="convertList">The convertList<see cref="List{spd_tblKiemKeTaiSan_DanhSachTSDuocKiemKeDenNgay_Result}"/>.</param>
        /// <returns>The <see cref="List{tblKiemKeTaiSan}"/>.</returns>
        private List<tblKiemKeTaiSan> convertListToTblKiemKeTaiSanEntities(List<spd_tblKiemKeTaiSan_DanhSachTSDuocKiemKeDenNgay_Result> convertList)
        {
            var entityCollection = new List<tblKiemKeTaiSan>();
            foreach (var m in convertList)
            {
                tblKiemKeTaiSan entityObject = new tblKiemKeTaiSan();
                {
                    entityObject.ID = m.ID;
                    entityObject.MaPhongBan = m.MaPhongBan;
                    entityObject.SoHieuTSCDCaBiet = m.SoHieuTSCDCaBiet;
                    entityObject.MaPhongBanQL = m.MaPhongBanQL;
                    entityObject.NgayKiemKe = m.NgayKiemKe;
                    entityObject.FilePath = m.FilePath;
                    entityObject.UserID =m.UserID;
                    entityObject.MaTSCDCaBiet = m.MaTSCDCaBiet.Value;
                    entityObject.MaChiTietTSCDCaBiet = m.MaChiTietTSCDCaBiet;
                    entityObject.NgayQuet = m.NgayQuet;
                    entityObject.DaQuet = m.DaQuet;
                    entityObject.Ten = m.Ten;
                    entityObject.LaTaiSan = m.LaTaiSan.Value;
                    entityObject.NguyenGiaBanDau = m.NguyenGiaBanDau;
                    entityObject.GiaTriMoiNhat = m.GiaTriMoiNhat;
                    entityObject.GiaTriConLai = m.GiaTriConLai;
                    entityObject.NgaySuDung = m.NgaySuDung;
                    entityObject.SoSerial = m.SoSerial;
                    entityObject.TaiSanThua = m.TaiSanThua;
                    entityObject.MaViTri = m.MaViTri.Value;
                    entityObject.TenViTri = m.TenViTri;
                    entityObject.MaViTriQL = m.MaViTriQL;
                    entityObject.MaCongTy = m.MaCongTy;
                    entityObject.TinhTrang = m.TinhTrang;
                    entityObject.MaViTriKiemKe = m.MaViTriKiemKe;    
                    entityObject.GhiChuChung = m.GhiChuChung;
                    entityObject.GhiChu = m.GhiChu;
                    entityObject.SoHieuCu =  m.SoHieuCu;
                }
                entityCollection.Add(entityObject);
            }
            return entityCollection;
        }

        #region gridV_DSChonXuLy

        private static void ChangeColorRow_gridV_DSChonXuLy(object e, GridView View, Color colorCheck, Color colorUnCheck)
        {
            if (e is RowCellStyleEventArgs)
            {
                if (View.GetRowCellDisplayText(((RowCellStyleEventArgs)e).RowHandle, "isDaXuLy") == "Checked")
                {
                    ((RowCellStyleEventArgs)e).Appearance.BackColor = Color.FromArgb(150, colorCheck);
                }              
            }
            if (e is RowStyleEventArgs)
            {
                if (View.GetRowCellDisplayText(((RowStyleEventArgs)e).RowHandle, "isDaXuLy") == "Checked")
                {
                    ((RowStyleEventArgs)e).Appearance.BackColor = Color.FromArgb(150, colorCheck);
                }
            }
        }
       
      

        private void gridV_DSChonXuLy_DataSourceChanged(object sender, EventArgs e)
        {
            gridV_DSChonXuLy.RowStyle += GridV_DSChonXuLy_RowStyle;
            gridV_DSChonXuLy.RowCellStyle += GridV_DSChonXuLy_RowCellStyle;
        }

        private void GridV_DSChonXuLy_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (_DSChonXuLy != null && _DSChonXuLy.Count() > 0)
            {
                GridView View = sender as GridView;
                ChangeColorRow_gridV_DSChonXuLy(e, View, Color.LightGreen,Color.Black);//Color.LightCoral check -- Color.LightGoldenrodYellow uncheck
            }
        }

        private void GridV_DSChonXuLy_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (_DSChonXuLy != null && _DSChonXuLy.Count() > 0)
            {
                GridView View = sender as GridView;
                ChangeColorRow_gridV_DSChonXuLy(e, View,Color.LightGreen, Color.Black);
            }
        }

        private void btnLayDuLieuKK_Click(object sender, EventArgs e)
        {
            LayDuLieu();
        }

        private void btnLuuDuLieuSauKK_Click(object sender, EventArgs e)
        {
            if (_DSChonXuLy.Count > 0)
            {
                LuuDuLieuSauKK();
            }
            else
                XtraMessageBox.Show(this, "<b>Bạn Không Thể Lưu Danh Sách Rỗng!</b>"
                                        , "THÔNG BÁO", MessageBoxButtons.OK
                                        , MessageBoxIcon.Information
                                        , DevExpress.Utils.DefaultBoolean.True);

        }

        private void LuuDuLieuSauKK()
        {
           
           FocusDataGrid();
            try
            {
                using (DialogUtil.WaitForSave(this))
                {
                    KiemKeTaiSan_Factory _test_Factory = KiemKeTaiSan_Factory.New();
                    //lưu kiểm kê tài sản SauKK
                    foreach (var obj in _DSChonXuLy)
                    {
                        tblKiemKeTaiSan kkUpdate = _test_Factory.GetObjectBySingleKey("ID", obj.ID);
                        kkUpdate.TrangthaiSauKiemKe = "trongdanhsachxuly";
                        kkUpdate.isDaXuLy = obj.isDaXuLy;
                        kkUpdate.TinhTrangKiemKe = obj.TinhTrangKiemKe;
                        kkUpdate.DeXuatSauXuLy = obj.DeXuatSauXuLy;
                        kkUpdate.GhiChu = obj.GhiChu;

                    }
                    _test_Factory.SaveChanges();
                }
                DialogUtil.ShowSaveSuccessful();
            }
            catch (Exception ex)
            {
                DialogUtil.ShowNotSaveSuccessful(ex.Message);
            }
        }
        public void FocusDataGrid()
        {
            if (bindingSource_DSChonXuLy.Position == bindingSource_DSChonXuLy.Count - 1) // bindingSource1 trong form
                bindingSource_DSChonXuLy.MoveFirst();
            else
                bindingSource_DSChonXuLy.MoveNext();
        }

        private void btnLayDuLieuSauKK_Click(object sender, EventArgs e)
        {
            List<tblKiemKeTaiSan> _dsXuLySauKiemKe = KiemKeTaiSan_Factory.New().Get_TaiSanCoDinhCaBiet_TrongDanhSachXuLyKiemKe(MaCongTy).ToList();      
            //if(_dsXuLySauKiemKe.Count > 0)
            //{
                _DSChonXuLy = _dsXuLySauKiemKe;
                bindingSource_DSChonXuLy.DataSource = _DSChonXuLy;
            //}
            //else
            //    XtraMessageBox.Show(this, "<b>Không có tài sản cần xử lý!</b>"
            //                           , "THÔNG BÁO", MessageBoxButtons.OK
            //                           , MessageBoxIcon.Information
            //                           , DevExpress.Utils.DefaultBoolean.True);

            bindingSource_DSChonXuLy.ResetBindings(true);
            //gridC_DSChonXuLy.Refresh();
            //gridV_DSChonXuLy.RefreshData();
        }

        private void gridV_DSChonXuLy_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            int soTaiSanDaKK = 0, soTaiSanChuaKK = 0, soTaiSaiViTri = 0, tongTaiSan = 0,soTaiSanDaXuLy = 0;
            tongTaiSan = _DSChonXuLy.Count();
            soTaiSanDaXuLy = _DSChonXuLy.Where(o => o.isDaXuLy == true).Count();
            soTaiSaiViTri = _DSChonXuLy.Where(o => o.TaiSanThua == true).Count();
            soTaiSanChuaKK = _DSChonXuLy.Where(o => o.DaQuet == false).Count();
            soTaiSanDaKK = _DSChonXuLy.Where(o => o.DaQuet == true).Count();

            if (Convert.ToString((e.Item as GridSummaryItem).Tag) == "dakiemke")
            {
                e.TotalValue = $"{soTaiSanDaKK}/{tongTaiSan}";
            }
            if (Convert.ToString((e.Item as GridSummaryItem).Tag) == "chuakiemke")
            {
                e.TotalValue = $"{soTaiSanChuaKK}/{tongTaiSan}";
            }
            if (Convert.ToString((e.Item as GridSummaryItem).Tag) == "saivitri")
            {
                e.TotalValue = $"{soTaiSaiViTri}/{tongTaiSan}";
            }
            if (Convert.ToString((e.Item as GridSummaryItem).Tag) == "daxuly")
            {
                e.TotalValue = $"{soTaiSanDaXuLy}/{tongTaiSan}";
            }
        }

        #endregion //gridV_DSChonXuLy

        private void cboLocDuLieuSauKiemKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboLocDuLieuSauKiemKe.SelectedIndex)
            {
                case 0:
                    gridV_DSChonXuLy.Columns["isDaXuLy"].ClearFilter();
                    break;
                case 1:
                    gridV_DSChonXuLy.Columns["isDaXuLy"].ClearFilter();
                    gridV_DSChonXuLy.Columns["isDaXuLy"].FilterInfo = new ColumnFilterInfo(ColumnFilterType.Value, null, "[isDaXuLy] = true");
                    break;
                case 2:
                    gridV_DSChonXuLy.Columns["isDaXuLy"].ClearFilter();
                    gridV_DSChonXuLy.Columns["isDaXuLy"].FilterInfo = new ColumnFilterInfo(ColumnFilterType.Value, null, "[isDaXuLy] != true");
                    break;
            }
        }//end Method

       
    }
}