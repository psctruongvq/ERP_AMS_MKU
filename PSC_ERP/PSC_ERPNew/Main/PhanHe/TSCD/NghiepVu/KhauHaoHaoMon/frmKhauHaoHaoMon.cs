using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using System.Linq;
using PSC_ERP_Common;
using System.Transactions;
using ERP_Library.Security;
namespace PSC_ERPNew.Main
{
    public partial class frmKhauHaoHaoMon : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmKhauHaoHaoMon singleton_ = null;
        public static frmKhauHaoHaoMon Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmKhauHaoHaoMon();
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
        //List<sp_TSCD_ChayKHHM_Result> _kQKHHMList = null;
        List<sp_TSCD_ChayKHHM_New_Result> _kQKHHMList = null;
        List<spd_TSCD_ChayKHHM_2020_Result> _ketQuaChayKHPBList = null;
       // Boolean _requiredSaveOnFormClosing = false;
        List<spd_TongHopTrichKhauHao_TichHopFAST_Result> _tichHopFAST_Result = null;
        NghiepVuKhauHaoHaoMon_Factory _factory = null;
        ChungTuKhauHaoTSCDPhanBoCCDC_Factory _factory_ChungTu = null;
        int LoaiThoiGianSuDung = 0;
        //UserItem _user = UserItem.GetUserItem(CurrentUser.Info.UserID);
        UserInfo _user = ERP_Library.Security.CurrentUser.Info;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmKhauHaoHaoMon()
        {
            InitializeComponent();
        }

        #endregion

        //Private Member Function
        #region Private Member Function
        private Boolean DuocPhepChayKHHM(Int32 maKy)
        {
            Boolean duocPhep = true;
            Ky_Factory ky_Factory = Ky_Factory.New();
            tblKy ky = ky_Factory.Get_KyByMaKy(maKy);

            //kiểm tra kỳ đã chạy khhm hay chưa
            if (ky_Factory.DaChayKHHM(maKy, _user.MaCongTy))
            {
                DialogUtil.ShowWarning(ky.TenKy + " đã chạy KHHM");
                return false;
            }
            //kiểm tra kỳ trước đó đã chạy khhm nếu đã từng chạy KHHM
            if (ky_Factory.DaTungChayKHHM(_user.MaCongTy))
            {
                //lấy kỳ trước đó
                tblKy kyTruocDo = ky_Factory.XacDinhKy_ByNgay(ky.NgayBatDau.AddMonths(-1));
                if (kyTruocDo != null)
                {
                    if (ky_Factory.DaChayKHHM(kyTruocDo.MaKy, _user.MaCongTy) == false)
                    {
                        DialogUtil.ShowError(kyTruocDo.TenKy + " chưa chạy KHHM");
                        return false;
                    }
                }
            }
            // Duyệt hết chứng từ mới được chạy khấu hao của Ng/vụ:  Ghi Tăng, Sửa Chửa Lớn ,Điều Chuyển
            System.Data.Objects.ObjectParameter kQParamBool   = new System.Data.Objects.ObjectParameter("KQ", typeof(bool));
            ky_Factory.Context.spd_KiemTraSoLuongChungTuChuaDuyet(maKy: maKy,maCongTy: _user.MaCongTy,kQ: kQParamBool);
            if (!Convert.ToBoolean(kQParamBool.Value))
            {
                DialogUtil.ShowError($"Có Chứng từ chưa được duyệt trong kỳ {ky.TenKy}. \n Vui lòng duyệt hết chứng từ trước khi chạy khấu hao!");
                return Convert.ToBoolean(kQParamBool.Value);
            } 

            return duocPhep;
        }
        private Boolean DuocPhepLuuKHHM()
        {
            Boolean duocPhep = true;

            if (_kQKHHMList != null || _ketQuaChayKHPBList != null)
            {
                //if (_kQKHHMList.Count() > 0 || _ketQuaChayKHPBList.Count()>0)
                {
                    //Int32 maKy = _kQKHHMList.ElementAt(0).MaKy.Value;
                    Int32 maKy = Convert.ToInt32(cbKy.EditValue);
                    tblKy ky = Ky_Factory.New().Get_KyByMaKy(maKy);
                    //kiểm tra đã tồn tại dòng dư liệu của kỳ trong db
                    //nếu lưu rồi thì ko cho phép lưu nữa
                    if (Ky_Factory.New().DaChayKHHM(maKy, _user.MaCongTy))
                    {
                        DialogUtil.ShowWarning("KHHM của " + ky.TenKy + " đã được lưu trước đó");
                        return false;
                    }
                }
                //else
                //{
                //    DialogUtil.ShowError("Không thể lưu kết quả chạy KHHM rỗng");
                //    return false;
                //}
            }
            else
            {
                DialogUtil.ShowError("Không thể lưu kết quả chạy KHHM rỗng");
                return false;
            }

            return duocPhep;
        }
        #endregion

        //Event Method
        #region Event Method
        private void frmKhauHaoHaoMon_Load(object sender, EventArgs e)
        {
            _factory = NghiepVuKhauHaoHaoMon_Factory.New();
            Ky_Factory ky_Factory = Ky_Factory.New();
            //lấy dư liệu và gán binding source
            //tblKyBindingSource.DataSource = ky_Factory.GetAll();
            tblKyBindingSource.DataSource = ky_Factory.Get_AllKy_OrderBy();
            //Lấy bộ phận
            {
                List<tblnsBoPhan> boPhanList = BoPhan_Factory.New().GetBoPhanbyMaCongTy(_user.MaCongTy).ToList();
                tblnsBoPhan boPhan_chonTatCa = new tblnsBoPhan() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" };
                boPhanList.Insert(0, boPhan_chonTatCa);
                tblBoPhanBindingSource.DataSource = boPhanList;
            }
            //
            loaiBaoCaoKHHMBindingSource.DataSource = PSC_ERP_Business.Main.Predefined.LoaiBaoCaoKHHM.LoaiBaoCaoKHHMList;
            //set mặc định vài thứ
            Int32 maKyHienTai = ky_Factory.XacDinhMaKy_ByNgay(app_users_Factory.New().SystemDate);
            cbKy.EditValue = maKyHienTai;
            cbDenKy.EditValue = maKyHienTai;
            lblThongBaoTienTrinh.Caption = "";
            LoaiThoiGianSuDung = cbboxLoaiThoiGianSuDung.SelectedIndex = 0;
        }
        private void btnChayKHHM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region k xài
            //if (backgroundWorkerChayKHHM.IsBusy)
            //{
            //    marqueeProgressBar1.Stopped = true;
            //    backgroundWorkerChayKHHM.CancelAsync();
            //}
            //else
            //{
            //    //lấy mã kỳ hiện tại
            //    Int32 maKy = Convert.ToInt32(cbKy.EditValue);
            //    if (DuocPhepChayKHHM(maKy))
            //    {
            //        _requiredSaveOnFormClosing = true;
            //        //start marquee progress
            //        marqueeProgressBar1.Stopped = false;
            //        //note
            //        lblThongBaoTienTrinh.Caption = "Đang chạy khhm";
            //        //run DoWork
            //        backgroundWorkerChayKHHM.RunWorkerAsync();
            //    }
            //}
            #endregion
        }
        private void backgroundWorkerChayKHHM_DoWork(object sender, DoWorkEventArgs e)
        {
            //chạy khhm
            _factory_ChungTu = ChungTuKhauHaoTSCDPhanBoCCDC_Factory.New();
            tblChungTuKhauHaoTSCDPhanBoCCDC _chungTuKhauHaoTSCDPhanBoCCDC = _factory_ChungTu.CreateManagedObject();
           
            ChungTu_Factory tmpFactory = ChungTu_Factory.New();
            Int32 maPhongBan = Convert.ToInt32(cbPhongBan.EditValue);
            Int32 maKy = Convert.ToInt32(cbKy.EditValue);
            _chungTuKhauHaoTSCDPhanBoCCDC.UserID = _user.UserID;
            _chungTuKhauHaoTSCDPhanBoCCDC.MaKy = maKy;
            _chungTuKhauHaoTSCDPhanBoCCDC.NgayHeThong = DateTime.Now;
            decimal soTienToiThieuKHHM = Convert.ToDecimal(txtSoTienToiThieuKHHM.EditValue);
            //_kQKHHMList = tmpFactory.Context.sp_TSCD_ChayKHHM(maPhongBan: maPhongBan, maKy: maKy, soTienToiThieuKHHM: soTienToiThieuKHHM, userID: userID).ToList();
            _kQKHHMList = tmpFactory.Context.sp_TSCD_ChayKHHM_New(maPhongBan: maPhongBan, maKy: maKy, soTienToiThieuKHHM: soTienToiThieuKHHM, userID: _user.UserID).ToList();

            //khoi tao factory
            _factory = NghiepVuKhauHaoHaoMon_Factory.New();
            //đổ dữ liệu vào tblNghiepVuKhauHaoHaoMons
            foreach (var item in _kQKHHMList)
            {
                tblNghiepVuKhauHaoHaoMon khhm = _factory.CreateAloneObject();              
                khhm.LaKhhmSCL = (item.LaKhhmSCL == 1 ? true : false);
                khhm.LoaiKHHM = item.LoaiKHHM;
                khhm.LuyKeHaoMon = item.LuyKeHaoMon;
                khhm.LuyKeKhauHao = item.LuyKeKhauHao;
                khhm.MaChiTietNghiepVuSuaChuaLon = item.MaChiTietNghiepVuSuaChuaLon;
                khhm.MaKy = item.MaKy;
                khhm.MaPhongBan = item.MaPhongBan;
                khhm.MaTSCDCaBiet = item.MaTSCDCaBiet;
                khhm.NgayHeThong = item.NgayHeThong;
                khhm.NguyenGiaConLai = item.NguyenGiaConLai;
                khhm.SoThang = item.SoThang;
                khhm.SoTien = item.SoTien.Value;
                khhm.UserID = item.UserID;
                _chungTuKhauHaoTSCDPhanBoCCDC.tblNghiepVuKhauHaoHaoMons.Add(khhm);
            }
        }
       
        private void backgroundWorkerChayKHHM_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //stop marquee progress
            marqueeProgressBar1.Stopped = true;
            lblThongBaoTienTrinh.Caption = "";
            //spTSCDChayKHHMResultBindingSource.DataSource = _kQKHHMList;
            spTSCDChayKHHMNewResultBindingSource.DataSource = _kQKHHMList;
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
                       //count có data cho lưu và mơi hiện thông báo 
                        _factory_ChungTu.SaveChangesWithoutTrackingLog();
                    }
                    //thông báo lưu thất bại
                    DialogUtil.ShowSaveSuccessful();
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
        private void btnXoaKHHMCuaKy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Int32 maKy = Convert.ToInt32(cbKy.EditValue);
            tblKy ky = Ky_Factory.New().Get_KyByMaKy(maKy);
            int maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
            int userID = ERP_Library.Security.CurrentUser.Info.UserID;
            if (DialogResult.Yes == DialogUtil.ShowYesNo("Bạn muốn xóa KHHM của " + ky.TenKy))
            {
                try
                {
                    NghiepVuKhauHaoHaoMon_Factory tmpFactory = NghiepVuKhauHaoHaoMon_Factory.New();
                    //tmpFactory.XoaKHHMByMaKy(maKy);
                    //tmpFactory.SaveChanges();
                    using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required,
                                    TimeSpan.FromSeconds(1800)))
                    {
                        tmpFactory.Context.sp_TSCD_XoaKhauHaoHaoMonTheoKy(maKy,maCongTy,userID);
                        //hoàn tất giao tác
                        transaction.Complete();
                    }

                    if (_kQKHHMList != null)
                    {
                        _kQKHHMList.Clear();
                        //spTSCDChayKHHMResultBindingSource.DataSource = _kQKHHMList;
                        spTSCDChayKHHMNewResultBindingSource.DataSource = _kQKHHMList;
                        gridViewKetQuaKHHM.RefreshData();
                    }
                    DialogUtil.ShowInfo("Xóa thành công KHHM của " + ky.TenKy);
                }
                catch (Exception ex)
                {
                    DialogUtil.ShowError("Không xóa được KHHM của " + ky.TenKy);
                }
            }
        }
        private void cbKy_EditValueChanged(object sender, EventArgs e)
        {
            cbDenKy.EditValue = Convert.ToInt32(cbKy.EditValue);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if(xtraTabControl1.SelectedTabPageIndex==0)
            {
                GridUtil.ExportToExcelXlsx(gridView: this.gridViewKetQuaKHHM, showOpenFilePrompt: true);
            }
          
            else if (xtraTabControl1.SelectedTabPageIndex==1)
            {
                GridUtil.ExportToExcelXlsx(gridView: this.gridView_XuatData, showOpenFilePrompt: true);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        #region Reports
        private void btnInKHHMChiTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int maTuKy = (Int32)cbKy.EditValue;
            int maDenKy = (Int32)cbDenKy.EditValue;
            int maBoPhan = (Int32)cbPhongBan.EditValue;
            int loaiBaoCao = (Int32)radioGroupLoaiBaoCao.EditValue;
            PhanHe.TSCD.Reports.frmTSCDReportList.ShowBangTrichKhauHaoTSCD_BoPhan_SuDungChoReportListVaFormKHHM("BangTrichKhauHaoTSCD_BoPhan", maTuKy, maDenKy, maBoPhan, loaiBaoCao, _user.MaCongTy, LoaiThoiGianSuDung, false);
        }

        private void btnInKHHMChiTietTheoTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int maTuKy = (Int32)cbKy.EditValue;
            int maDenKy = (Int32)cbDenKy.EditValue;
            int maBoPhan = (Int32)cbPhongBan.EditValue;
            int loaiBaoCao = (Int32)radioGroupLoaiBaoCao.EditValue;
            PhanHe.TSCD.Reports.frmTSCDReportList.ShowBangTrichKhauHaoTSCD_TaiKhoan_SuDungChoReportListVaFormKHHM("BangTrichKhauHaoTSCD_TaiKhoan", maTuKy, maDenKy, maBoPhan, loaiBaoCao, _user.MaCongTy, LoaiThoiGianSuDung, false);

        }
        private void btnInTongHopKHHMTheoPhongBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int maTuKy = (Int32)cbKy.EditValue;
            int maDenKy = (Int32)cbDenKy.EditValue;
            int loaiBaoCao = (Int32)radioGroupLoaiBaoCao.EditValue;
            PhanHe.TSCD.Reports.frmTSCDReportList.ShowTongHopKhauHaoTheoDonVi_SuDungChoReportListVaFormKHHM("TongHopKhauHaoTheoDonVi", maTuKy, maDenKy, loaiBaoCao, _user.MaCongTy, LoaiThoiGianSuDung, false);
        }

        private void btnInTongHopKHHMTheoTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //TongHopKhauHaoTSCD_TaiKhoan
            int maTuKy = (Int32)cbKy.EditValue;
            int maDenKy = (Int32)cbDenKy.EditValue;
            int loaiBaoCao = (Int32)radioGroupLoaiBaoCao.EditValue;
            PhanHe.TSCD.Reports.frmTSCDReportList.ShowTongHopKhauHaoTSCD_TaiKhoan_SuDungChoReportListVaFormKHHM("TongHopKhauHaoTSCD_TaiKhoan", maTuKy, maDenKy, _user.MaCongTy,LoaiThoiGianSuDung, false);
        }
        private void barButtonItem_InChiTietKHHM_TSCD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int maTuKy = (Int32)cbKy.EditValue;
            int maDenKy = (Int32)cbDenKy.EditValue;
            int maBoPhan = (Int32)cbPhongBan.EditValue;
            int loaiBaoCao = (Int32)cbLoaiBaoCao.EditValue;
            PhanHe.TSCD.Reports.frmTSCDReportList.ShowBangTrichKhauHaoTSCD_SuDungChoReportListVaFormKHHM("BangTrichKhauHaoTSCD", maTuKy, maDenKy, maBoPhan, loaiBaoCao, _user.MaCongTy, LoaiThoiGianSuDung, false);
        }
        private void frmKhauHaoHaoMon_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtBlackHole.Focus();
            if (_factory.IsDirty)
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

        private void btn_LayDuLieuChayPhanBo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (DialogUtil.Wait("Đang lấy dữ liệu!","Vui lòng đợi!"))
            {
                //chạy khhm
                _factory_ChungTu = ChungTuKhauHaoTSCDPhanBoCCDC_Factory.New();
                tblChungTuKhauHaoTSCDPhanBoCCDC _chungTuKhauHaoTSCDPhanBoCCDC = _factory_ChungTu.CreateManagedObject();

                ChungTu_Factory tmpFactory = ChungTu_Factory.New();
                Int32 maPhongBan = Convert.ToInt32(cbPhongBan.EditValue);
                Int32 maKy = Convert.ToInt32(cbKy.EditValue);
                _chungTuKhauHaoTSCDPhanBoCCDC.UserID = _user.UserID;
                _chungTuKhauHaoTSCDPhanBoCCDC.MaKy = maKy;
                _chungTuKhauHaoTSCDPhanBoCCDC.NgayHeThong = DateTime.Now;
                decimal soTienToiThieuKHHM = Convert.ToDecimal(txtSoTienToiThieuKHHM.EditValue);
                //_kQKHHMList = tmpFactory.Context.sp_TSCD_ChayKHHM(maPhongBan: maPhongBan, maKy: maKy, soTienToiThieuKHHM: soTienToiThieuKHHM, userID: userID).ToList();
                _ketQuaChayKHPBList = tmpFactory.Context.spd_TSCD_ChayKHHM_2020(maPhongBan: maPhongBan, maKy: maKy, soTienToiThieuKHHM: soTienToiThieuKHHM, userID: _user.UserID, chay:false, loaiThoigianSuDung: LoaiThoiGianSuDung).ToList();
                spTSCDChayKHHM_2020ResultBindingSource.DataSource = _ketQuaChayKHPBList;
                //khoi tao factory
            }
        }

        private void btn_TinhKhauHaoPhanBo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Int32 maKy = Convert.ToInt32(cbKy.EditValue);
            if (DuocPhepChayKHHM(maKy))
            {
                using (DialogUtil.Wait("Đang chạy khấu hao và phân bổ!", "Vui lòng đợi!"))
                {
                    //chạy khhm
                    _factory_ChungTu = ChungTuKhauHaoTSCDPhanBoCCDC_Factory.New();
                    tblChungTuKhauHaoTSCDPhanBoCCDC _chungTuKhauHaoTSCDPhanBoCCDC = _factory_ChungTu.CreateManagedObject();
                    ChungTu_Factory tmpFactory = ChungTu_Factory.New();
                    Int32 maPhongBan = Convert.ToInt32(cbPhongBan.EditValue);              
                    _chungTuKhauHaoTSCDPhanBoCCDC.UserID = _user.UserID;
                    _chungTuKhauHaoTSCDPhanBoCCDC.MaKy = maKy;
                    _chungTuKhauHaoTSCDPhanBoCCDC.NgayHeThong = DateTime.Now;
                    decimal soTienToiThieuKHHM = Convert.ToDecimal(txtSoTienToiThieuKHHM.EditValue);
                    //_kQKHHMList = tmpFactory.Context.sp_TSCD_ChayKHHM(maPhongBan: maPhongBan, maKy: maKy, soTienToiThieuKHHM: soTienToiThieuKHHM, userID: userID).ToList();
                    _ketQuaChayKHPBList = tmpFactory.Context.spd_TSCD_ChayKHHM_2020(maPhongBan: maPhongBan, maKy: maKy, soTienToiThieuKHHM: soTienToiThieuKHHM, userID: _user.UserID, chay: true,loaiThoigianSuDung: LoaiThoiGianSuDung ).ToList();
                    spTSCDChayKHHM_2020ResultBindingSource.DataSource = _ketQuaChayKHPBList;
                    //khoi tao factory
                    _factory = NghiepVuKhauHaoHaoMon_Factory.New();
                    //đổ dữ liệu vào tblNghiepVuKhauHaoHaoMons
                    foreach (var item in _ketQuaChayKHPBList)
                    {
                        tblNghiepVuKhauHaoHaoMon khhm = _factory.CreateAloneObject();
                        khhm.LoaiKHHM = false;
                        khhm.LuyKeHaoMon = item.LyKeKHPB;
                        khhm.LuyKeKhauHao = item.LyKeKHPB;
                        khhm.MaKy = maKy;
                        khhm.MaPhongBan = item.MaBoPhan;
                        khhm.MaTSCDCaBiet = item.MaTSCDCaBiet.Value;
                        khhm.NgayHeThong = DateTime.Now.Date;
                        khhm.NguyenGiaConLai = item.GiaTriConLai;
                        khhm.MaChiPhiKeToan = item.MaChiPhiKeToan;
                        khhm.MaPhongBanQL = item.MaBoPhanQL;
                        khhm.TinhTrang = item.TinhTrang;
                        khhm.TinhTrangText = item.TrangThai;
                        khhm.SoHieuTKChiPhiPhanBo = item.SoHieuTKChiPhiPhanBo;
                        khhm.SoHieuTKKhauHaoLuyKe = item.SoHieuTKKhauHaoLuyKe;
                        khhm.SoHieuTKNguyenGia = item.SoHieuTKNguyenGia;
                        khhm.SoThang = item.SoThang;
                        khhm.SoTien = item.SoTienTrongKy.Value;
                        khhm.UserID = _user.UserID;
                        _chungTuKhauHaoTSCDPhanBoCCDC.tblNghiepVuKhauHaoHaoMons.Add(khhm);
                    }
                }
            }
        }

        private void cbboxLoaiThoiGianSuDung_SelectedIndexChanged(object sender, EventArgs e)
        {
          System.Windows.Forms.ComboBox cb = sender as System.Windows.Forms.ComboBox;
            LoaiThoiGianSuDung = cb.SelectedIndex;
        }

        private void btnTichHopFast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {//kiểm tra đã tính khấu hao của kỳ và đã lưu 
            if(_factory_ChungTu == null)
               _factory_ChungTu = ChungTuKhauHaoTSCDPhanBoCCDC_Factory.New();
           
            if (_factory_ChungTu.tblChungTuKhauHao_CheckHasData_ByMaKy((int)cbKy.EditValue))
            {
               
                _tichHopFAST_Result = _factory.Context.spd_TongHopTrichKhauHao_TichHopFAST(
                                                                                            flag: "view",
                                                                                            tuKy: (int)cbKy.EditValue,
                                                                                            maCongTy: _user.MaCongTy
                                                                                            ).ToList();
                using (frmTongHopTrichKhauHao_TichHopFAST frm = new frmTongHopTrichKhauHao_TichHopFAST(_tichHopFAST_Result, (int)cbKy.EditValue, _user.MaCongTy))
                {
                    frm.ShowDialog();
                }
            }
            else
            {

                XtraMessageBox.Show(this,
                                     $"Bạn phải tính khấu hao theo kỳ \n\n Và Lưu dữ liệu trước khi tích hợp",
                                     "Tích hợp dữ liệu với Fast!",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question,
                                     DevExpress.Utils.DefaultBoolean.True);
                
            }//end if
        }//end method
    }
}