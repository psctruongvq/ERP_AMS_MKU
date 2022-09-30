using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Common;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERPNew.Main.Reports;
using PSC_ERP_Common.Ado.Net;
using PSC_ERP_Business.Main;
using PSC_ERP_Business.Main.Predefined;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Threading;

namespace PSC_ERPNew.Main
{
    public partial class frmDoiSoSerialTSCD : DevExpress.XtraEditors.XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDoiSoSerialTSCD singleton_ = null;
        public static frmDoiSoSerialTSCD Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDoiSoSerialTSCD();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent = null)
        {
            PSC_ERP_Common.FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }
        #endregion

        //Private Member field
        #region Private Member field

        List<tblBoPhanERPNew> _boPhanList = null;
        List<tblDanhMucTSCD> _tscdList = null;

        tblTaiSanCoDinhCaBiet _taiSanCoDinhCaBiet = null;

        tblSerialTaiSanCoDinhCaBiet _serialMoi = null;

        tblTaiSanCoDinhCaBiet _TSCDCBHienTai = null;

        tblCT_NghiepVuDieuChuyenChiTiet _chiTietNghiepVuDieuChuyenChiTiet = null;
        SerialTaiSanCoDinhCaBiet_Factory _chiTietNVDoiSerialTaiSan_Factory = null;

        TaiSanCoDinhCaBiet_Factory _taiSanCoDinhCaBiet_factory = TaiSanCoDinhCaBiet_Factory.New();
        int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;

        NghiepVuDoiSerialTaiSan_Factory _nghiepVuDoiSerialTaiSan_Factory = null;
        tblNghiepVuSuaSoSerialTSCDCB _nghiepVuDoiSerialTaiSan = null;

        List<tblSerialTaiSanCoDinhCaBiet> _chiTietNghiepVuDoiSerialTSList = new List<tblSerialTaiSanCoDinhCaBiet>();
        int _userID = PSC_ERP_Global.Main.UserID;
        int _maNghiepVu = 0;
        Boolean _xemLaiChungTuCu = false;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmDoiSoSerialTSCD()
        {
            InitializeComponent();
            _xemLaiChungTuCu = false;
            _maNghiepVu = 0;
        }

        public frmDoiSoSerialTSCD(int maNghiepVu)
        {
            InitializeComponent();
            _xemLaiChungTuCu = true;
            // Lấy mã nghiệp vụ điều chuyển nội bộ
            _maNghiepVu = maNghiepVu;

        }
        #endregion
        //Private Member Function
        #region Private Member Function

        private void XemLaiChungTuCu(int maNghiepVu)
        {
            //Khởi tạo factory
            //_nghiepVuDoiSerialTaiSan_Factory = NghiepVuDoiSerialTaiSan_Factory.New();

            // Lấy nghiệp vu điều chuyển chi tiết tài sản
            _nghiepVuDoiSerialTaiSan = _nghiepVuDoiSerialTaiSan_Factory.Get_NghiepVuDieuChuyenChiTietTaiSanTheoMaNghiepVuDieuChuyenChiTiet(maNghiepVu);
            //nếu khóa sổ sẽ không cho sửa ngày chứng từ
            if (Ky_Factory.New().DaKhoaSoTSCD(_nghiepVuDoiSerialTaiSan.NgayLap.Value,_maCongTy))
            {
                this.dteNgayChungTu.Properties.ReadOnly = true;
            }

            // Đưa dữ liệu vào bindingsource
            //GanBindingSource();
        }

        private void GanBindingSource()
        {
            tblBoPhanERPNewBindingSource.DataSource = _boPhanList;
            //
            if (_tscdList != null)
                tblDanhMucTSCDBindingSource.DataSource = _tscdList;
            //
            tblNghiepVuDoiSoSerial_BindingSource.DataSource = _nghiepVuDoiSerialTaiSan;
            //
            tblCTNghiepVuDoiSoSerial_BindingSource.DataSource = _chiTietNghiepVuDoiSerialTSList;// _nghiepVuDoiSerialTaiSan.tblSerialTaiSanCoDinhCaBiets;
            //
        }

        private void ChangeFocus()
        {
            this.txtBlackHole.Focus();
        }

        private bool Save()
        {
            this.ChangeFocus();
            Boolean _luu = true;
            if (_chiTietNghiepVuDoiSerialTSList.Count == 0 || _chiTietNghiepVuDoiSerialTSList == null)
            {
                DialogUtil.ShowWarning("Không thể lưu chứng từ rỗng! \nVui lòng nhập chi tiết nghiệp vụ đổi số serial tài sản");
                _luu = false;
                return _luu;
            }

            //lưu chứng từ đổi số serial tài sản (nghiệp vụ)
            #region lưu nghiệp vụ
            try
            {
                if (_nghiepVuDoiSerialTaiSan_Factory.IsDirty)
                {
                    _nghiepVuDoiSerialTaiSan_Factory.SaveChangesWithoutTrackingLog();
                    _luu = true;
                }
            }
            catch (Exception ex)
            {
                DialogUtil.ShowError("Lỗi lưu chứng từ nghiệp vụ đổi số serial tài sản: " + ex.Message);
                _luu = false;
                return _luu;
            }
            #endregion

            //lưu chi số serial tài sản mới (chi tiết nghiệp vụ)
            #region lưu chi tiết nghiệp vụ
            Boolean kiemTrung = false;
            foreach (tblSerialTaiSanCoDinhCaBiet chiTietNV in _chiTietNghiepVuDoiSerialTSList)
            {
                if (_xemLaiChungTuCu)
                {
                    tblSerialTaiSanCoDinhCaBiet serialDaco = _chiTietNVDoiSerialTaiSan_Factory.Get_ChiTietNghiepVu_ByMaTSCDCaBiet_And_MaChungTu(chiTietNV.MaTSCDCB.Value, _nghiepVuDoiSerialTaiSan.ID);
                    if (serialDaco == null)
                    {
                        kiemTrung = false;
                    }
                    else
                    {
                        kiemTrung = true;
                    }
                }
                else
                {
                    kiemTrung = false;
                }
                if (!kiemTrung)
                {
                    tblSerialTaiSanCoDinhCaBiet serialMoi = _chiTietNVDoiSerialTaiSan_Factory.CreateManagedObject();
                    serialMoi.MaTSCDCB = chiTietNV.MaTSCDCB;
                    serialMoi.SerialCu = chiTietNV.SerialCu;
                    serialMoi.SerialMoi = chiTietNV.SerialMoi;
                    serialMoi.MaChungTu = _nghiepVuDoiSerialTaiSan.ID;
                    serialMoi.NgayApDung = _nghiepVuDoiSerialTaiSan.NgayLap;
                }
            }
            try
            {
                if (_chiTietNVDoiSerialTaiSan_Factory.IsDirty)
                    _chiTietNVDoiSerialTaiSan_Factory.SaveChangesWithoutTrackingLog();
                _luu = true;
            }
            catch (Exception ex)
            {
                DialogUtil.ShowError("Lỗi lưu chi tiết chứng từ đổi số serial tài sản: " + ex.Message);
                _luu = false;
                return _luu;
            }
            #endregion

            //lưu lại số tài sản cố định cá biệt với số serial mới 
            #region lưu lại tài sản cố định cá biệt
            //TaiSanCoDinhCaBiet_Factory _taiSanCoDinhCaBiet_factory = TaiSanCoDinhCaBiet_Factory.New();
            foreach (tblSerialTaiSanCoDinhCaBiet chiTietNV in _chiTietNghiepVuDoiSerialTSList)
            {
                tblTaiSanCoDinhCaBiet _TSCDCB_Update = _taiSanCoDinhCaBiet_factory.Get_TaiSanCoDinhCaBiet_ByMaTSCDCaBiet(chiTietNV.MaTSCDCB.Value);
                _TSCDCB_Update.Serial = chiTietNV.SerialMoi;
            }
            try
            {
                if (_taiSanCoDinhCaBiet_factory.IsDirty)
                    _taiSanCoDinhCaBiet_factory.SaveChangesWithoutTrackingLog();
                _luu = true;
            }
            catch (Exception ex)
            {
                DialogUtil.ShowError("Lỗi lưu số serial tài sản cố định cá biệt : " + ex.Message);
                _luu = false;
                return _luu;
            }
            #endregion

            return _luu;
        }
        #endregion
        //Event Method
        #region Event Method
        private void frmDoiSoSerialTSCD_Load(object sender, EventArgs e)
        {
            _boPhanList = BoPhanERPNew_Factory.New().GetAll().ToList();

            //khởi tạo
            _nghiepVuDoiSerialTaiSan_Factory = NghiepVuDoiSerialTaiSan_Factory.New();
            _chiTietNVDoiSerialTaiSan_Factory = SerialTaiSanCoDinhCaBiet_Factory.New();

            _chiTietNghiepVuDoiSerialTSList = new List<tblSerialTaiSanCoDinhCaBiet>();

            //load lại chứng từ cũ
            if (_xemLaiChungTuCu == true && _maNghiepVu != 0)
            {
                XemLaiChungTuCu(_maNghiepVu);
                _chiTietNghiepVuDoiSerialTSList = _nghiepVuDoiSerialTaiSan.tblSerialTaiSanCoDinhCaBiets.ToList();
            }
            else
            {
                //tạo chứng từ mới
                _nghiepVuDoiSerialTaiSan = _nghiepVuDoiSerialTaiSan_Factory.CreateAloneObject();
                _nghiepVuDoiSerialTaiSan.UserID = PSC_ERP_Global.Main.UserID;
                _nghiepVuDoiSerialTaiSan = _nghiepVuDoiSerialTaiSan_Factory.NewChungTu();
            }

            //Đưa checkbox lên lưới
            // PSC_ERP_Common.GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.grdViewTSCDCaBiet_DaDuyet, colChon);
            // Set số thứ tự cho lưới
            PSC_ERP_Common.GridUtil.SetSTTForGridView(grdViewTSCDCaBiet_DaDuyet);
            PSC_ERP_Common.GridUtil.SetSTTForGridView(gridView_SerialTSCDCB);


            //Set ngày
            dteNgayChungTu.EditValue = app_users_Factory.New().SystemDate;//DateTime.Now.Date;

            //cài đặt delete helper
            //GridUtil.DeleteHelper.Setup_ManualType(gridView_SerialTSCDCB, (GridView gridView, List<Object> deleteList) =>
            //{
            //    //xóa chi tiết nghiệp vụ điều chuyển nội bộ
            //    CT_NghiepVuDieuChuyenChiTietTaiSan_Factory.FullDeleteCT_NghiepVuDieuChuyenChiTietTaiSan(context: _nghiepVuDoiSerialTaiSan_Factory.Context, deleteList: deleteList);
            //});

            //
            this.GanBindingSource();
        }


        private void cbPhongBan_EditValueChanged(object sender, EventArgs e)
        {
            int maPhongBan = Convert.ToInt32(cbPhongBan.EditValue);
            //lấy danh sách tên tài sản
            {
                _tscdList = DanhMucTSCD_Factory.New().Get_DanhSachTaiSanCoDinh_CoTSCB_CT_ConSuDung_ByMaPhongBan(maPhongBan).ToList();
                tblDanhMucTSCD tscd_chonTatCa = new tblDanhMucTSCD() { ID = 0, MaQuanLy = "<<Tất cả>>", Ten = "<<Tất cả>>" };
                _tscdList.Insert(0, tscd_chonTatCa);
            }

            GanBindingSource();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.Save())
            {
                if (_xemLaiChungTuCu)
                {
                    _xemLaiChungTuCu = false;
                    frmDoiSoSerialTSCD_Load(sender, e);
                }
                DialogUtil.ShowSaveSuccessful();
               
            }
            else
            {
                DialogUtil.ShowNotSaveSuccessful();
            }
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void dteNgayChungTu_EditValueChanged(object sender, EventArgs e)
        {
            DateTime ngayChungTu = dteNgayChungTu.DateTime.Date;
        }
        private void btnDanhSachChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDanhSachChungTuDoiSerialTSCDCB.ShowSingleton(null, this.MdiParent);
        }
        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ReportHelper.ShowReport("NghiepVuDieuChuyenChiTietTaiSan_BienBanGiaoNhanChiTietTSCD", () =>
            //{
            //    DataSet dataSet = new DataSet();
            //    SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
            //    dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_BienBanGiaoNhanChiTietTSCD_DCCTTS", "@MaNghiepVuDieuChuyenChiTietTS", _nghiepVuDoiSerialTaiSan.ID);
            //    return dataSet;
            //}, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
        }

        private void frmDoiSoSerialTSCD_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtBlackHole.Focus();

            if (_nghiepVuDoiSerialTaiSan_Factory.IsDirty)
            {
                DialogResult dlgResult = DialogUtil.ShowSaveRequireOptionsOnFormClosing(this);
                if (DialogResult.Yes == dlgResult)
                {
                    if (false == this.Save())
                        e.Cancel = true;
                }
                else if (DialogResult.No == dlgResult)
                {
                    return;
                }
                else if (DialogResult.Cancel == dlgResult)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PSC_ERPNew.Main.Sys.frmEntityTrackingLog.ShowSingleton(null, BusinessCodeEnum.TSCD_DoiSoSerialTaiSan, this.MdiParent);
        }
        #endregion

        private void cbTaiSanCD_EditValueChanged(object sender, EventArgs e)
        {
            using (DialogUtil.Wait("Vui lòng đợi", " Đang lấy dữ liệu"))
            {
                tblDanhMucTSCD _taiSanCoDinh = (tblDanhMucTSCD)cbTaiSanCD.GetSelectedDataRow();
                int maPhongBan = Convert.ToInt32(cbPhongBan.EditValue);
                List<tblTaiSanCoDinhCaBiet> _taiSanCDCBList = TaiSanCoDinhCaBiet_Factory.New().Get_DanhSachTSCDCaBietTheoPhongBanAndMaTSCD(maPhongBan, _taiSanCoDinh.ID).ToList();

                tblTaiSanCoDinhCaBiet_BindingSource.DataSource = _taiSanCDCBList;
            }
        }

        private void grdViewTSCDCaBiet_DaDuyet_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            DoRowDoubleClick(view, pt);
        }

        //xử lý quá trình chọn chi tiết tài sản cá biệt
        private void DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if ((info.InRow || info.InRowCell) && info.RowHandle >= 0)
            {
                _TSCDCBHienTai = this.grdViewTSCDCaBiet_DaDuyet.GetRow(info.RowHandle) as tblTaiSanCoDinhCaBiet;
                Boolean _kiemTraChiTietTSCDCB = true;
                if (_chiTietNghiepVuDoiSerialTSList.Count > 0)
                {
                    foreach (tblSerialTaiSanCoDinhCaBiet chiTietNghiepVu in _chiTietNghiepVuDoiSerialTSList)
                        if (chiTietNghiepVu.MaTSCDCB == _TSCDCBHienTai.MaTSCDCaBiet)
                        {
                            _kiemTraChiTietTSCDCB = false;
                            break;
                        }
                }
                //mở from nhập chi tiết tài sản
                if (_kiemTraChiTietTSCDCB)
                {
                    using (frmNhapSoSerialTaiSan frm = new frmNhapSoSerialTaiSan(_TSCDCBHienTai))
                    {
                        frm.Text = "Bạn đang nhập số serial mới cho tài sản " + _TSCDCBHienTai.tblDanhMucTSCD.Ten;
                        DialogResult dlgResult = frm.ShowDialog(this);
                        if (dlgResult == DialogResult.OK)
                        {
                            //            //xử lý lưu quá trình chuyển đổi chi tiết tài sản  
                            _serialMoi = new tblSerialTaiSanCoDinhCaBiet();
                            _serialMoi.MaTSCDCB = _TSCDCBHienTai.MaTSCDCaBiet;
                            _serialMoi.tblTaiSanCoDinhCaBiet = _TSCDCBHienTai;
                            _serialMoi.NgayApDung = _nghiepVuDoiSerialTaiSan.NgayLap;
                            if (_TSCDCBHienTai.SeriaSauCung_RefObj == null)
                            {
                                _serialMoi.SerialCu = _TSCDCBHienTai.Serial;
                            }
                            else
                            {
                                _serialMoi.SerialCu = _TSCDCBHienTai.SeriaSauCung_RefObj.SerialMoi;
                            }
                            _serialMoi.SerialMoi = frm.txt_Seria_Moi.Text;

                            _chiTietNghiepVuDoiSerialTSList.Add(_serialMoi);
                            //focus về tab chứng tử
                            xtraTabControl1.SelectedTabPageIndex = 0;
                            //refresh dữ liệu
                            tblCTNghiepVuDoiSoSerial_BindingSource.DataSource = null;
                            tblCTNghiepVuDoiSoSerial_BindingSource.DataSource = _chiTietNghiepVuDoiSerialTSList;// 
                            gridView_SerialTSCDCB.RefreshData();
                        }
                    }
                }
                else
                {
                    DialogUtil.ShowWarning("Tài sản: " + _TSCDCBHienTai.tblDanhMucTSCD.Ten + " \nbạn chọn đã có trong chứng từ. Vui lòng xem lại!");
                }
                ////frmDigitizing_PreViewFile.ShowFile(_currentBagForPreview_File, this);//không phải ShowDialog dùng hàm nay khi chạy from độc lập ở project khác

            }
        }

        //xóa bỏ nghiệp vụ, hủy bỏ tác vụ
        public void XoaNghiepVuDoiSerialTaiSan(tblSerialTaiSanCoDinhCaBiet chiTietNghiepVu)
        {
            //cập nhật số serial cũ trước khi xóa
            //TaiSanCoDinhCaBiet_Factory _TSCDCB_factory = TaiSanCoDinhCaBiet_Factory.New();
            tblTaiSanCoDinhCaBiet _TSCDCB_Update = _taiSanCoDinhCaBiet_factory.Get_TaiSanCoDinhCaBiet_ByMaTSCDCaBiet(chiTietNghiepVu.MaTSCDCB.Value);
            _TSCDCB_Update.Serial = chiTietNghiepVu.SerialCu;
            _taiSanCoDinhCaBiet_factory.SaveChangesWithoutTrackingLog();
            //return true;
        }


        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtBlackHole.Focus();
            if (_nghiepVuDoiSerialTaiSan == null)
            {
                DialogUtil.ShowWarning("Chứng từ rỗng.");
                return;
            }
            //
            if (Ky_Factory.New().DaKhoaSoTSCD(_nghiepVuDoiSerialTaiSan.NgayLap.Value,_maCongTy))
            {
                DialogUtil.ShowDaKhoaSoTSCD(_nghiepVuDoiSerialTaiSan.NgayLap.Value);
            }
            else
            {
                if (DialogResult.Yes == DialogUtil.ShowYesNo(String.Format("Bạn muốn xóa chứng từ [{0}]?", this.Text)))
                {
                    try
                    {
                        using (DialogUtil.WaitForDelete(this))
                        {
                            List<tblSerialTaiSanCoDinhCaBiet> danhSachChiTietNghiepVuXoa = _nghiepVuDoiSerialTaiSan.tblSerialTaiSanCoDinhCaBiets.ToList<tblSerialTaiSanCoDinhCaBiet>();
                            //cập nhật lại số serial cũ cho tài sản cố định khi xóa nghiệp vụ
                            foreach (tblSerialTaiSanCoDinhCaBiet chiTietNghiepVu in danhSachChiTietNghiepVuXoa)
                            {
                                XoaNghiepVuDoiSerialTaiSan(chiTietNghiepVu);
                            }
                            _chiTietNghiepVuDoiSerialTSList.Clear();
                            //Xóa nghiệp vụ đổi số serial - sau đó cập nhật lại
                            _nghiepVuDoiSerialTaiSan_Factory.FullDeleteNghiepVu(_nghiepVuDoiSerialTaiSan);
                        }
                        _nghiepVuDoiSerialTaiSan_Factory.SaveChangesWithoutTrackingLog();
                       
                        DialogUtil.ShowDeleteSuccessful();
                        // Cài đặt lại dữ liệu
                        _xemLaiChungTuCu = false;
                        frmDoiSoSerialTSCD_Load(sender, e);
                    }
                    catch (Exception ex)
                    {
                        DialogUtil.ShowNotDeleteSuccessful(ex.Message);
                    }
                }
            }
        }
    }
}
