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
    public partial class frmDieuChuyenChiTietTSCD : DevExpress.XtraEditors.XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDieuChuyenChiTietTSCD singleton_ = null;
        public static frmDieuChuyenChiTietTSCD Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDieuChuyenChiTietTSCD();
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
        List<tblDoiTac> _doiTacList = null;

        //mới thêm 22/12/2015
        List<tblChiTietTaiSanCaBiet> _chiTietTSCDCBList = null;

        List<tblChiTietTaiSanCaBiet> _chiTietTSCDCBListMoi = null;// new List<tblChiTietTaiSanCaBiet>();
        List<tblChiTietTaiSanCaBiet> _chiTietTSCDCBListCu = null;// new List<tblChiTietTaiSanCaBiet>();
        tblTaiSanCoDinhCaBiet _taiSanCoDinhCaBiet = null;

        tblChiTietTaiSanCaBiet _chiTietTaiSanCBCu = null;
        tblChiTietTaiSanCaBiet _chiTietTaiSanCBMoi = null;
        tblChiTietTaiSanCaBiet _chiTietTaiSanCBHienTai = null;

        tblCT_NghiepVuDieuChuyenChiTiet _chiTietNghiepVuDieuChuyenChiTiet = null;
        CT_NghiepVuDieuChuyenChiTietTaiSan_Factory _chiTietNVDieuChuyenChiTietTS_Factory = null;// CT_NghiepVuDieuChuyenChiTietTaiSan_Factory.New();

        ChiTietTaiSanCaBiet_Factory _chiTietTaiSanCaBiet_Factory = null;//ChiTietTaiSanCaBiet_Factory.New();

        NghiepVuDieuChuyenChiTietTaiSan_Factory _nghiepVuDieuChuyenChiTietTaiSan_Factory = null;
        tblNghiepVuDieuChuyenChiTiet _nghiepVuDieuChuyenChiTietTaiSan = null;

        List<tblCT_NghiepVuDieuChuyenChiTiet> _chiTietNghiepVuDieuChuyenChiTietTSList = null;// new List<tblCT_NghiepVuDieuChuyenChiTiet>();
        int _userID = PSC_ERP_Global.Main.UserID;
        int _maNghiepVuDieuChuyenChiTiet = 0;
        Boolean _xemLaiChungTuCu = false;
        int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmDieuChuyenChiTietTSCD()
        {
            InitializeComponent();
            _xemLaiChungTuCu = false;
            _maNghiepVuDieuChuyenChiTiet = 0;
        }

        public frmDieuChuyenChiTietTSCD(int maNghiepVuDieuChuyenChiTiet)
        {
            InitializeComponent();
            _xemLaiChungTuCu = true;
            // Lấy mã nghiệp vụ điều chuyển nội bộ
            _maNghiepVuDieuChuyenChiTiet = maNghiepVuDieuChuyenChiTiet;

        }
        #endregion
        //Private Member Function
        #region Private Member Function

        private void XemLaiChungTuCu(int maNghiepVuDieuChuyenChiTiet)
        {
            //Khởi tạo factory
            _nghiepVuDieuChuyenChiTietTaiSan_Factory = NghiepVuDieuChuyenChiTietTaiSan_Factory.New();

            // Lấy nghiệp vu điều chuyển chi tiết tài sản
            _nghiepVuDieuChuyenChiTietTaiSan = _nghiepVuDieuChuyenChiTietTaiSan_Factory.Get_NghiepVuDieuChuyenChiTietTaiSanTheoMaNghiepVuDieuChuyenChiTiet(maNghiepVuDieuChuyenChiTiet);
            //nếu khóa sổ sẽ không cho sửa ngày chứng từ
            if (Ky_Factory.New().DaKhoaSoTSCD(_nghiepVuDieuChuyenChiTietTaiSan.NgayTaoChungTu.Value,_maCongTy))
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
            tblNghiepVuDieuChuyenChiTiet_BindingSource.DataSource = _nghiepVuDieuChuyenChiTietTaiSan;
            //
            tblCTNghiepVuDieuChuyenChiTiet_BindingSource.DataSource = _nghiepVuDieuChuyenChiTietTaiSan.tblCT_NghiepVuDieuChuyenChiTiet;
            //
            tblDoiTacBindingSource.DataSource = _doiTacList;
        }

        private void ChangeFocus()
        {
            this.txtBlackHole.Focus();
        }

        private bool Save()
        {
            this.ChangeFocus();
            Boolean _luu = true;
            if (_chiTietNghiepVuDieuChuyenChiTietTSList.Count == 0 || _chiTietNghiepVuDieuChuyenChiTietTSList == null)
            {
                DialogUtil.ShowWarning("Không thể lưu chứng từ nghiệp vụ điều chuyển chi tiết rỗng! \nVui lòng nhập chi tiết nghiệp vụ điều chuyển chi tiết");
                _luu = false;
                return _luu;
            }

            //lưu cập nhật chi tiết cũ
            try
            {
                if (_chiTietTaiSanCaBiet_Factory.IsDirty)
                {
                    _chiTietTaiSanCaBiet_Factory.SaveChangesWithoutTrackingLog();
                }
                _luu = true;
            }
            catch (Exception ex)
            {
                DialogUtil.ShowError("Lỗi lưu chi tiết tài sản cố định: " + ex.Message);
                _luu = false;
                return _luu;
            }

            //lưu chứng từ điều chuyển chi tiết tài sản
            #region lưu nghiệp vụ điều chuyển chi tiết tài sản
            try
            {
                if (_nghiepVuDieuChuyenChiTietTaiSan_Factory.IsDirty)
                    _nghiepVuDieuChuyenChiTietTaiSan_Factory.SaveChangesWithoutTrackingLog();
                _luu = true;
            }
            catch (Exception ex)
            {
                DialogUtil.ShowError("Lỗi lưu chứng từ nghiệp vụ điều chuyển chi tiết tài sản: " + ex.Message);
                _luu = false;
                return _luu;
            }
            #endregion

            //lưu chi tiết chứng từ điều chuyển chi tiết tài sản
            #region lưu chi tiết nghiệp vụ điều chuyển
            foreach (tblCT_NghiepVuDieuChuyenChiTiet chiTietNV in _chiTietNghiepVuDieuChuyenChiTietTSList)
            {
                chiTietNV.MaNghiepVuDieuChuyenChiTiet = _nghiepVuDieuChuyenChiTietTaiSan.MaNghiepVuDieuChuyenChiTiet;
                //_chiTietNVDieuChuyenChiTietTS_Factory.AddObject(chiTietNV);
            }
            try
            {
                if (_chiTietNVDieuChuyenChiTietTS_Factory.IsDirty)
                    _chiTietNVDieuChuyenChiTietTS_Factory.SaveChangesWithoutTrackingLog();
                _luu = true;
            }
            catch (Exception ex)
            {
                DialogUtil.ShowError("Lỗi lưu chi tiết nghiệp vụ điều chuyển chi tiết tài sản: " + ex.Message);
                _luu = false;
                return _luu;
            }
            #endregion

            return _luu;
        }
        #endregion
        //Event Method
        #region Event Method
        private void frmDieuChuyenChiTietTSCD_Load(object sender, EventArgs e)
        {
            //đối tượng
            List<sp_AllDoiTuong_Result> doiTuongList = new List<sp_AllDoiTuong_Result>();
            doiTuongList = ChungTu_Factory.New().Context.sp_AllDoiTuong(0).ToList();
            sp_AllDoiTuong_Result khongChon = new sp_AllDoiTuong_Result() { MaDoiTuong = 0, MaQLDoiTuong = "<<Không chọn>>", TenDoiTuong = "<<Không chọn>>" };
            doiTuongList.Insert(0, khongChon);
            sp_AllDoiTuong_ResultBindingSource.DataSource = doiTuongList;


            //load đối tác
            _doiTacList = DoiTac_Factory.New().GetAll().ToList();

            _boPhanList = BoPhanERPNew_Factory.New().GetAll().ToList();

            //khởi tạo
            _nghiepVuDieuChuyenChiTietTaiSan_Factory = NghiepVuDieuChuyenChiTietTaiSan_Factory.New();
            _chiTietNVDieuChuyenChiTietTS_Factory = CT_NghiepVuDieuChuyenChiTietTaiSan_Factory.New();
            _chiTietTaiSanCaBiet_Factory = ChiTietTaiSanCaBiet_Factory.New();

            _chiTietTSCDCBListMoi = new List<tblChiTietTaiSanCaBiet>();
            _chiTietTSCDCBListCu = new List<tblChiTietTaiSanCaBiet>();
            _chiTietNghiepVuDieuChuyenChiTietTSList = new List<tblCT_NghiepVuDieuChuyenChiTiet>();

            //load lại chứng từ cũ
            if (_xemLaiChungTuCu == true && _maNghiepVuDieuChuyenChiTiet != 0)
            {
                XemLaiChungTuCu(_maNghiepVuDieuChuyenChiTiet);
                _chiTietNghiepVuDieuChuyenChiTietTSList = _nghiepVuDieuChuyenChiTietTaiSan.tblCT_NghiepVuDieuChuyenChiTiet.ToList();
                cbDoiTac.EditValue = _nghiepVuDieuChuyenChiTietTaiSan.tblDoiTac.MaDoiTac;
            }
            else
            {
                //tạo chứng từ mới
                _nghiepVuDieuChuyenChiTietTaiSan = _nghiepVuDieuChuyenChiTietTaiSan_Factory.CreateAloneObject();
                _nghiepVuDieuChuyenChiTietTaiSan.UserID = PSC_ERP_Global.Main.UserID;
                _nghiepVuDieuChuyenChiTietTaiSan = _nghiepVuDieuChuyenChiTietTaiSan_Factory.NewChungTu(_userID);
            }

            //Đưa checkbox lên lưới
            // PSC_ERP_Common.GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.grdViewTSCDCaBiet_DaDuyet, colChon);
            // Set số thứ tự cho lưới
            PSC_ERP_Common.GridUtil.SetSTTForGridView(grdViewTSCDCaBiet_DaDuyet);
            PSC_ERP_Common.GridUtil.SetSTTForGridView(gridView_CTDieuChuyenNoiBo);


            //Set ngày
            dteNgayChungTu.EditValue = app_users_Factory.New().SystemDate;//DateTime.Now.Date;

            //cài đặt delete helper
            //GridUtil.DeleteHelper.Setup_ManualType(gridView_CTDieuChuyenNoiBo, (GridView gridView, List<Object> deleteList) =>
            //{
            //    //xóa chi tiết nghiệp vụ điều chuyển nội bộ
            //    CT_NghiepVuDieuChuyenChiTietTaiSan_Factory.FullDeleteCT_NghiepVuDieuChuyenChiTietTaiSan(context: _nghiepVuDieuChuyenChiTietTaiSan_Factory.Context, deleteList: deleteList);
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
                DialogUtil.ShowSaveSuccessful();
                frmDieuChuyenChiTietTSCD_Load(sender, e);
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
            frmDanhSachDieuChuyenChiTietTSCDCaBiet.ShowSingleton(null, this.MdiParent);
        }
        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportHelper.ShowReport("NghiepVuDieuChuyenChiTietTaiSan_BienBanGiaoNhanChiTietTSCD", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_BienBanGiaoNhanChiTietTSCD_DCCTTS", "@MaNghiepVuDieuChuyenChiTietTS", _nghiepVuDieuChuyenChiTietTaiSan.MaNghiepVuDieuChuyenChiTiet);
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
        }

        private void frmDieuChuyenChiTietTSCD_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtBlackHole.Focus();

            if (_nghiepVuDieuChuyenChiTietTaiSan_Factory.IsDirty)
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
            PSC_ERPNew.Main.Sys.frmEntityTrackingLog.ShowSingleton(null, BusinessCodeEnum.TSCD_DieuChuyenChiTietTaiSan, this.MdiParent);
        }
        #endregion

        private void cbTaiSanCD_EditValueChanged(object sender, EventArgs e)
        {
            tblDanhMucTSCD _taiSanCoDinh = (tblDanhMucTSCD)cbTaiSanCD.GetSelectedDataRow();
            int maPhongBan = Convert.ToInt32(cbPhongBan.EditValue);
            List<tblTaiSanCoDinhCaBiet> _taiSanCDCBList = TaiSanCoDinhCaBiet_Factory.New().Get_DanhSachTSCDCaBietTheoPhongBanAndMaTSCD(maPhongBan, _taiSanCoDinh.ID).ToList();

            tblTaiSanCoDinhCaBiet_BindingSource.DataSource = _taiSanCDCBList;

        }

        private void cb_TaiSanCoDinhCaBiet_EditValueChanged(object sender, EventArgs e)
        {
            _taiSanCoDinhCaBiet = (tblTaiSanCoDinhCaBiet)cb_TaiSanCoDinhCaBiet.GetSelectedDataRow();
            _chiTietTSCDCBList = ChiTietTaiSanCaBiet_Factory.New().Context.spd_TSCD_LayChiTietTaiSanTheo_MaTaiSanCoDinh(_taiSanCoDinhCaBiet.MaTSCDCaBiet).ToList();
            if (_chiTietTSCDCBList.Count > 0)
                tblChiTietTaiSanCoDinh_BindingSource.DataSource = _chiTietTSCDCBList;
            else
            {
                DialogUtil.ShowWarning("Tài sản " + _taiSanCoDinhCaBiet.tblDanhMucTSCD.Ten + " - " + _taiSanCoDinhCaBiet.SoHieu + " bạn chọn khôn có chi tiết tài sản \nVui Lòng chọn tài sản khác!");
                tblChiTietTaiSanCoDinh_BindingSource.DataSource = null;
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
                _chiTietTaiSanCBHienTai = this.grdViewTSCDCaBiet_DaDuyet.GetRow(info.RowHandle) as tblChiTietTaiSanCaBiet;
                Boolean _kiemTraChiTietTSCDCB = true;
                if (_chiTietNghiepVuDieuChuyenChiTietTSList.Count > 0)
                {
                    foreach (tblCT_NghiepVuDieuChuyenChiTiet chiTietNVDieuChuyen in _chiTietNghiepVuDieuChuyenChiTietTSList)
                        if (chiTietNVDieuChuyen.MaChiTietCu == _chiTietTaiSanCBHienTai.MaChiTiet)
                        {
                            _kiemTraChiTietTSCDCB = false;
                            break;
                        }
                }
                //mở from nhập chi tiết tài sản
                if (_kiemTraChiTietTSCDCB)
                {
                    using (frmNhapChiTietTaiSan frm = new frmNhapChiTietTaiSan(_chiTietTaiSanCBHienTai, _taiSanCoDinhCaBiet, _chiTietTSCDCBListCu))
                    {
                        frm.Text = "Bạn đang nhập chi tiết mới thay cho chi tiết " + _chiTietTaiSanCBHienTai.TenChiTiet + " của tài sản " + _taiSanCoDinhCaBiet.tblDanhMucTSCD.Ten;
                        DialogResult dlgResult = frm.ShowDialog(this);
                        if (dlgResult == DialogResult.Yes)
                        {
                            //xử lý lưu quá trình chuyển đổi chi tiết tài sản  
                            _chiTietTaiSanCBMoi = new tblChiTietTaiSanCaBiet();// _chiTietTaiSanCaBiet_Factory.CreateManagedObject(); //
                            _chiTietTaiSanCBMoi = frm._chiTietTaiSanCBMoi;

                            foreach (tblTaiSanCoDinhCaBiet taiSanCoDinhCaBiet in frm._danhSachTaiSanCDCBApDung)
                            {
                                if (ChiTiet_NghiepVuDieuChuyenChiTietTaiSan(_chiTietTaiSanCBCu, _chiTietTaiSanCBMoi, taiSanCoDinhCaBiet))
                                {
                                    _chiTietTSCDCBListMoi.Add(_chiTietTaiSanCBMoi);
                                    _chiTietTSCDCBListCu.Add(_chiTietTaiSanCBCu);

                                    _chiTietNghiepVuDieuChuyenChiTietTSList.Add(_chiTietNghiepVuDieuChuyenChiTiet);
                                }
                            }

                            tblCTNghiepVuDieuChuyenChiTiet_BindingSource.DataSource = null;
                            tblCTNghiepVuDieuChuyenChiTiet_BindingSource.DataSource = _chiTietNghiepVuDieuChuyenChiTietTSList;
                            //focus về tab chứng tử
                            xtraTabControl1.SelectedTabPageIndex = 0;
                        }
                    }
                }
                else
                {
                    DialogUtil.ShowWarning("Chi tiết tài sản: " + _chiTietTaiSanCBHienTai.TenChiTiet + "\nModel: " + _chiTietTaiSanCBHienTai.Model + "\nSeria: " + _chiTietTaiSanCBHienTai.Serial + "\nSố hiệu: " + _chiTietTaiSanCBHienTai.SoHieu + " \nbạn chọn đã có trong chứng từ. Vui lòng xem lại!");
                }
                //frmDigitizing_PreViewFile.ShowFile(_currentBagForPreview_File, this);//không phải ShowDialog dùng hàm nay khi chạy from độc lập ở project khác

            }
        }

        //kiểm tra xem tài sản đã có phát sinh số hiệu chưa nếu có thì sẽ tiếp tục phát sinh thêm
        public int KiemTraSoChiTietCanThayCuaMotTaiSan(tblTaiSanCoDinhCaBiet taiSanCoDinhCaBiet)
        {
            int i = 0;
            if (_chiTietTSCDCBListMoi.Count > 0)
            {
                foreach (tblChiTietTaiSanCaBiet chiTietTaiSan in _chiTietTSCDCBListMoi)
                {
                    if (chiTietTaiSan.MaTSCDCaBiet == taiSanCoDinhCaBiet.MaTSCDCaBiet)
                        i++;
                }
            }
            return i;
        }

        //nghiệp vụ điều chuyển chi tiết tài sản
        public Boolean ChiTiet_NghiepVuDieuChuyenChiTietTaiSan(tblChiTietTaiSanCaBiet chiTietTSCu, tblChiTietTaiSanCaBiet chiTietTSMoi, tblTaiSanCoDinhCaBiet taiSanCoDinhCaBiet)
        {
            //lấy chi tiết tài sản cũ
            //chiTietTSCu = _chiTietTaiSanCaBiet_Factory.GetChiTietTaiSan_TheoMaTSCDCB_And_TenChiTiet(taiSanCoDinhCaBiet.MaTSCDCaBiet, _chiTietTaiSanCBHienTai.TenChiTiet);
            //sửa ngày 11/01/2016
            chiTietTSCu = _chiTietTaiSanCaBiet_Factory.GetChiTietTaiSan_TheoMaChiTietTSCDCB(_chiTietTaiSanCBHienTai.MaChiTiet);
            //cập nhật thông tin cho chi tiết mới     
            string soHieu = _chiTietTaiSanCaBiet_Factory.LaySoHieuSauCung_TheoMaTSCDCB(taiSanCoDinhCaBiet.MaTSCDCaBiet).SoHieu;
            int soLanPhatSinhSoHieuMoi = KiemTraSoChiTietCanThayCuaMotTaiSan(taiSanCoDinhCaBiet);
            if (soLanPhatSinhSoHieuMoi == 0)
            {
                chiTietTSMoi.SoHieu = ChiTietTaiSanCaBiet_Factory.IncreaseSoHieuChiTietTaiSanCaBiet(soHieu);
            }
            //trường hợp 1 tài sản thay nhiều chi tiết thì phải kiểm tra số lần phát sinh chi tiết để phát sinh số hiệu không bị trùng
            else
            {
                int sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoHieuChiTietTSCDCaBiet_IncreasePart;
                string leftPart = soHieu.Substring(0, soHieu.Length - sizeOfNumber);

                string soHieuMoi = "";//String.Format("{0}{1}1", leftPart, new String('0', sizeOfNumber - 1));

                int max = int.Parse(soHieu.Substring(soHieu.Length - sizeOfNumber, sizeOfNumber));
                int soMoi = max + 1 + soLanPhatSinhSoHieuMoi;
                string stringSoMoi = new String('0', sizeOfNumber - soMoi.ToString().Length) + soMoi.ToString();

                soHieuMoi = leftPart + stringSoMoi;
                chiTietTSMoi.SoHieu = soHieuMoi;
            }

            chiTietTSMoi.MaTSCDCaBiet = taiSanCoDinhCaBiet.MaTSCDCaBiet;

            chiTietTSMoi.MaDVT = chiTietTSCu.MaDVT;

            if (chiTietTSCu.SoLuong <= chiTietTSMoi.SoLuong)
            {
                //cập nhật lại trạng thái là ngưng hoạt động
                chiTietTSCu.NgungSuDung = true;
                //trường hợp này phát sinh nhiều chi tiết tài sản
                //lưu lại nguyên giá
                chiTietTSMoi.NguyenGia = chiTietTSCu.NguyenGia;
                chiTietTSCu.NguyenGia = 0;

                //lưu lại só lượng
                chiTietTSMoi.SoLuong = chiTietTSCu.SoLuong;
                chiTietTSCu.SoLuong = 0;
            }
            else
            {
                //cập nhật lại nguyên giá
                chiTietTSMoi.NguyenGia = (chiTietTSCu.NguyenGia / chiTietTSCu.SoLuong) * chiTietTSMoi.SoLuong;
                chiTietTSCu.NguyenGia -= chiTietTSMoi.NguyenGia;

                //cập nhật sô lượng cho chi tiết cũ
                chiTietTSCu.SoLuong -= chiTietTSMoi.SoLuong;
            }
            chiTietTSMoi.LaChiTietThayThe = true;

            //lưu lại thay đổi chi tiết luôn tý nếu hủy bỏ nghiệp vụ phải quay lại xóa bỏ thay đổi            
            //_chiTietTaiSanCaBiet_Factory.AddObject(chiTietTSMoi);
            //_chiTietTaiSanCaBiet_Factory.SaveChangesWithoutTrackingLog();

            //lưu chi tiết nghiệp vụ điều chuyển chi tiết
            _chiTietNghiepVuDieuChuyenChiTiet = _chiTietNVDieuChuyenChiTietTS_Factory.CreateManagedObject();
            _chiTietNghiepVuDieuChuyenChiTiet.MaChiTietCu = chiTietTSCu.MaChiTiet;
            _chiTietNghiepVuDieuChuyenChiTiet.TenChiTietCu = chiTietTSCu.TenChiTiet + " - Model: " + chiTietTSCu.Model + " - Số hiệu: " + chiTietTSCu.SoHieu;

            //_chiTietNghiepVuDieuChuyenChiTiet.MaChiTietMoi = chiTietTSMoi.MaChiTiet;
            _chiTietNghiepVuDieuChuyenChiTiet.tblChiTietTaiSanCaBiet1 = chiTietTSMoi;
            _chiTietNghiepVuDieuChuyenChiTiet.TenChiTietMoi = chiTietTSMoi.TenChiTiet + " - Model: " + chiTietTSMoi.Model + " - Số hiệu: " + chiTietTSMoi.SoHieu;

            _chiTietNghiepVuDieuChuyenChiTiet.SoLuong = chiTietTSMoi.SoLuong;
            _chiTietNghiepVuDieuChuyenChiTiet.MaTSCDCB = chiTietTSCu.MaTSCDCaBiet;//bằng mẵ chi tiết mới hay cũ cùng được vì cùng 1 tài sản

            //_chiTietNghiepVuDieuChuyenChiTiet.MaNghiepVuDieuChuyenChiTiet = nghiepVuDieuChuyenChiTietTS.MaNghiepVuDieuChuyenChiTiet;
            _chiTietNghiepVuDieuChuyenChiTiet.LyDoThay = _nghiepVuDieuChuyenChiTietTaiSan.LyDoDieuChuyen;
            _chiTietNghiepVuDieuChuyenChiTiet.NgayThay = _nghiepVuDieuChuyenChiTietTaiSan.NgayTaoChungTu;

            //_chiTietNghiepVuDieuChuyenChiTietTSList.Add(_chiTietNghiepVuDieuChuyenChiTiet);
            return true;
        }

        //xóa bỏ nghiệp vụ, hủy bỏ tác vụ
        public Boolean XoaNghiepVuDieuChuyenChiTietTaiSan(tblCT_NghiepVuDieuChuyenChiTiet chiTietNghiepVuDieuChuyenChiTiet)
        {
            tblChiTietTaiSanCaBiet chiTietTSCu = _chiTietTaiSanCaBiet_Factory.Get_ChiTietTaiSanCaBiet_BySoHieu(chiTietNghiepVuDieuChuyenChiTiet.tblChiTietTaiSanCaBiet.SoHieu);
            tblChiTietTaiSanCaBiet chiTietTSMoi = _chiTietTaiSanCaBiet_Factory.Get_ChiTietTaiSanCaBiet_BySoHieu(chiTietNghiepVuDieuChuyenChiTiet.tblChiTietTaiSanCaBiet1.SoHieu);

            //cập nhật lại thông tin ban đầu trước khi xóa
            if (chiTietTSCu.SoLuong == chiTietTSMoi.SoLuong)
            {
                chiTietTSCu.NguyenGia = chiTietTSMoi.NguyenGia;
                chiTietTSMoi.SoLuong = chiTietTSMoi.SoLuong;
            }
            //trường hợp không đổi hết chi tiết
            else
            {
                chiTietTSCu.NguyenGia += chiTietTSMoi.NguyenGia;
                chiTietTSCu.SoLuong += chiTietTSMoi.SoLuong;
            }
            chiTietTSCu.NgungSuDung = null;//hay bằng 0 cũng được
            _chiTietTaiSanCaBiet_Factory.DeleteObject(chiTietTSMoi);

            return true;
        }

        private void cbDoiTac_EditValueChanged(object sender, EventArgs e)
        {
            tblDoiTac doiTacHienTai = cbDoiTac.GetSelectedDataRow() as tblDoiTac;
            if (cbDoiTac.EditValue != null && cbDoiTac.EditValue != DBNull.Value && doiTacHienTai == null)
            {
                Int64 maDoiTac = Convert.ToInt64(cbDoiTac.EditValue);
                doiTacHienTai = DoiTac_Factory.New().Get_DoiTacByMaDoiTac(maDoiTac);
            }


            //đưa thông tin tên đối tác hiển thị lên texbox cạnh cbDoiTac
            if (doiTacHienTai != null)
            {
                txtTenDoiTac.Text = doiTacHienTai.TenDoiTac;
                _nghiepVuDieuChuyenChiTietTaiSan.MaDoiTac = doiTacHienTai.MaDoiTac;
            }
            else
                txtTenDoiTac.Text = "";
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtBlackHole.Focus();
            if (_nghiepVuDieuChuyenChiTietTaiSan == null)
            {
                DialogUtil.ShowWarning("Chứng từ rỗng.");
                return;
            }
            //
            if (Ky_Factory.New().DaKhoaSoTSCD(_nghiepVuDieuChuyenChiTietTaiSan.NgayTaoChungTu.Value,_maCongTy))
            {
                DialogUtil.ShowDaKhoaSoTSCD(_nghiepVuDieuChuyenChiTietTaiSan.NgayTaoChungTu.Value);
            }
            else
            {

                if (DialogResult.Yes == DialogUtil.ShowYesNo(String.Format("Bạn muốn xóa chứng từ [{0}]?", this.Text)))
                {
                    try
                    {
                        using (DialogUtil.WaitForDelete(this))
                        {
                            //cập nhật lại dữ liệu trước khi xóa nghiệp vụ                          
                            List<tblCT_NghiepVuDieuChuyenChiTiet> danhSachChiTietNghiepVuXoa = _nghiepVuDieuChuyenChiTietTaiSan.tblCT_NghiepVuDieuChuyenChiTiet.ToList<tblCT_NghiepVuDieuChuyenChiTiet>();
                            foreach (tblCT_NghiepVuDieuChuyenChiTiet chiTietNghiepVu in _nghiepVuDieuChuyenChiTietTaiSan.tblCT_NghiepVuDieuChuyenChiTiet)
                            {
                                XoaNghiepVuDieuChuyenChiTietTaiSan(chiTietNghiepVu);
                            }

                            //Xóa nghiệp vụ đổi chi tiết tài sản
                            _nghiepVuDieuChuyenChiTietTaiSan_Factory.FullDeleteNghiepVu(_nghiepVuDieuChuyenChiTietTaiSan);
                            _nghiepVuDieuChuyenChiTietTaiSan_Factory.SaveChangesWithoutTrackingLog();
                            //lưu xóa chi tiết sau không bị lỗi vì chưa xóa chi tiết nghiệp vụ điều chuyển
                            _chiTietTaiSanCaBiet_Factory.SaveChangesWithoutTrackingLog();
                        }
                        DialogUtil.ShowDeleteSuccessful();

                        // Cài đặt lại dữ liệu
                        //_nghiepVuDieuChuyenChiTietTaiSan_Factory = NghiepVuDieuChuyenChiTietTaiSan_Factory.New();
                        //_nghiepVuDieuChuyenChiTietTaiSan = _nghiepVuDieuChuyenChiTietTaiSan_Factory.CreateAloneObject();
                        //tblNghiepVuDieuChuyenChiTiet_BindingSource.Clear();
                        _xemLaiChungTuCu = false;
                        frmDieuChuyenChiTietTSCD_Load(sender, e);
                    }
                    catch (Exception)
                    {
                        DialogUtil.ShowNotDeleteSuccessful();
                    }
                }
            }
        }
    }
}
