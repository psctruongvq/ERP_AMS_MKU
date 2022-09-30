using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERP_Business.Main;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;
using PSC_ERP_Common.Ado.Net;
using PSC_ERPNew.Main.PhanHe.TSCD.UsefulDialog;
using PSC_ERPNew.Main.Reports;

namespace PSC_ERPNew.Main
{
    public partial class frmDieuChinhGiaTri : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDieuChinhGiaTri singleton_ = null;
        public static frmDieuChinhGiaTri Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDieuChinhGiaTri();
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

        // ///////////
        ChungTuDieuChinhGiaTriTaiSan_DerivedFactory _factory = null;

        tblChungTu _chungTu = null;
        tblDieuChinhGiaTri _nghiepVu = null;


        IQueryable<tblTaiKhoan> _taiKhoanNoList = null;
        IQueryable<tblTaiKhoan> _taiKhoanCoList = null;

        // /////////////
        Boolean _daLoadXong = false;
        Boolean _taoMoiChungTu = true;
        long _maChungTuCuCanXemLai = 0;
        tblChungTu _objFromAnotherFactory = null;
        DateTime? _ngayBanDau = DateTime.MinValue;
        int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmDieuChinhGiaTri()
        {
            InitializeComponent();
        }
        public frmDieuChinhGiaTri(tblChungTu chungTu)
        {
            InitializeComponent();
            _taoMoiChungTu = false;
            _objFromAnotherFactory = chungTu;
            _maChungTuCuCanXemLai = chungTu.MaChungTu;

        }
        #endregion

        //Private Member Function
        #region Private Member Function
        private bool Save()
        {
            txtBlackHole.Focus();
            //kiểm tra chứng từ trước khi lưu
            if (DuocPhepLuu())
                try
                {
                    using (DialogUtil.WaitForSave(this))
                    {
                        _factory.SaveChangesWithoutTrackingLog();
                        //_factory.SaveChanges(BusinessCodeEnum.TSCD_DieuChinhGiaTri.ToString());//lưu lại chứng từ
                    }
                    DialogUtil.ShowSaveSuccessful();
                    return true;
                }
                catch (Exception ex)
                {
                    DialogUtil.ShowNotSaveSuccessful();
                }
            return false;
        }
        private Boolean DuocPhepLuu()
        {
            //
            Ky_Factory ky_Factory = Ky_Factory.New();
            if (ky_Factory.DaKhoaSoTSCD(_chungTu.NgayLap.Value,_maCongTy))
            {
                //bật thông báo đã khóa sổ
                DialogUtil.ShowDaKhoaSoTSCD(_chungTu.NgayLap.Value);
                return false;
            }
            //kiểm tra nếu có tài khoản bị khóa sổ trong kỳ
            if (KiemTraCoTaiKhoanKhoaSo(_chungTu.NgayLap.Value) && dteNgayChungTu.Properties.ReadOnly == false)
            {
                DialogUtil.ShowError("Bạn đã nhập định khoản trước rồi thay đổi ngày trong kỳ có tài khoản khóa số!\nHệ thống sẽ tự động trả lại ngày ban đầu của chứng từ\n\nNếu muốn đổi ngày vui lòng xóa dòng định khoản có tài khoản không bị khóa trong kỳ bạn muốn đổi tới!", "Không lưu được");
                _chungTu.NgayLap = _ngayBanDau;
                return false;
            }
            //Kiểm tra mã chứng từ quản lý
            if (_factory.KiemTraTrungMaChungTuQL(_chungTu) == true)
            {
                txtMaChungTuQuanLy.Focus();
                DialogResult dlgResult = DialogUtil.ShowYesNo("Trùng mã chứng từ quản lý. Tự động phát sinh mã mới");
                if (dlgResult == DialogResult.Yes)
                {
                    _chungTu.MaChungTuQL = _factory.Get_NextMaChungTuQL_ByYear(_chungTu.NgayLap.Value.Year, PSC_ERP_Global.Main.UserID);
                    //đệ quy
                    return DuocPhepLuu();
                }
                else
                    return false;
            }
            //kiểm tra trùng số chứng từ
            if (_factory.KiemTraTrungSoChungTu(_chungTu) == true)
            {
                txtSoChungTu.Focus();
                DialogResult dlgResult = DialogUtil.ShowYesNo("Trùng số chứng từ. Tự động phát sinh số chứng từ mới");
                if (dlgResult == DialogResult.Yes)
                {
                    _chungTu.SoChungTu = _factory.Get_NextSoChungTuPhieuKeToanTaiSan(_chungTu.NgayLap.Value.Year, PSC_ERP_Global.Main.UserID);
                    //đệ quy
                    return DuocPhepLuu();
                }
                else
                    return false;
            }

            //kiểm tra định khoản
            //if (_chungTu.KiemTraDinhKhoan() == false)
            //    return false;
            return true;
        }
        private void GanBindingSourceChungTu()
        {  //
            tblChiTietDieuChinhGiaTriBindingSource.DataSource = _nghiepVu.tblChiTietDieuChinhGiaTris;

            //gán bindingSource
            {
                tblChungTuBindingSource_Single.DataSource = _chungTu;
                tblTienTeBindingSource_Single.DataSource = _chungTu.tblTienTe;
            }
            tblDieuChinhGiaTriBindingSource_Single.DataSource = _nghiepVu;
            tblChiTietDieuChinhGiaTriBindingSource.DataSource = _nghiepVu.tblChiTietDieuChinhGiaTris;//_chungTu.tblNghiepVuSuaChuaLons.First().tblCT_NghiepVuSuaChuaLon;
            {
                tblDinhKhoanBindingSource_Single.DataSource = _chungTu.tblDinhKhoan;
                tblButToanBindingSource.DataSource = _chungTu.tblDinhKhoan.tblButToans;

            }


        }
        private void KhoiTaoChungTuMoi()
        {

            //chưa load xong
            _daLoadXong = false;
            {
                //khởi tạo mới chứng từ factory
                _factory = ChungTuDieuChinhGiaTriTaiSan_DerivedFactory.New();

                //khởi tạo chứng từ mới 
                _chungTu = _factory.NewChungTu();
                //lấy nghiệp vụ từ chứng từ ra
                _nghiepVu = _chungTu.tblDieuChinhGiaTris.First();

                //gán bindingSource
                GanBindingSourceChungTu();
                //
                //cbTinhChatSoDuTaiKhoan.EditValue = (Int32)TinhChatSoDuTaiKhoanEnum.Co;
            }
            //đã load xong
            _daLoadXong = true;
        }
        private void LoadChungTuCu(long maChungTu)
        {
            //chưa load xong
            _daLoadXong = false;
            {
                //khởi tạo mới chứng từ factory
                _factory = ChungTuDieuChinhGiaTriTaiSan_DerivedFactory.New();
                //load chứng từ được quản lý bởi _factory
                _chungTu = _factory.Get_ChungTu_ByMaChungTu(maChungTu);
                //lấy nghiệp vụ từ chứng từ ra
                _nghiepVu = _chungTu.tblDieuChinhGiaTris.First();

                //nếu khóa sổ sẽ không cho sửa ngày chứng từ
                if (Ky_Factory.New().DaKhoaSoTSCD(_chungTu.NgayLap.Value,_maCongTy))
                {
                    this.dteNgayChungTu.Properties.ReadOnly = true;
                }
                //gán bindingSource
                GanBindingSourceChungTu();
                //
                //{
                //    //lấy bút toán đầu tiên trong danh sách
                //    tblButToan butToanDauTien = _chungTu.tblDinhKhoan.tblButToans.FirstOrDefault();
                //    if (_chungTu.tblDinhKhoan.LaMotNoNhieuCo == true)
                //    {
                //        if (butToanDauTien != null)
                //        {
                //            cbTaiKhoan.EditValue = butToanDauTien.NoTaiKhoan;
                //            cbTaiKhoan.Properties.DataSource = _taiKhoanNoList;
                //            cbDoiTuong1.EditValue = butToanDauTien.MaDoiTuongNo;
                //        }
                //        cbTinhChatSoDuTaiKhoan.EditValue = (Int32)TinhChatSoDuTaiKhoanEnum.No;
                //    }
                //    else
                //    {
                //        if (butToanDauTien != null)
                //        {
                //            cbTaiKhoan.EditValue = butToanDauTien.CoTaiKhoan;
                //            cbTaiKhoan.Properties.DataSource = _taiKhoanCoList; 
                //            cbDoiTuong1.EditValue = butToanDauTien.MaDoiTuongCo;
                //        }
                //        cbTinhChatSoDuTaiKhoan.EditValue = (Int32)TinhChatSoDuTaiKhoanEnum.Co;
                //    }
                //}

            }
            //đã load xong
            _daLoadXong = true;
        }
        private void LayDanhSachNoCoTaiKhoan()
        {
            IQueryable<tblTaiKhoan> taiKhoanList = TaiKhoan_Factory.New().GetAll();
            _taiKhoanNoList = taiKhoanList;//TaiKhoan_Factory.New().Get_DanhSachTaiKhoanNo();
            _taiKhoanCoList = taiKhoanList;//TaiKhoan_Factory.New().Get_DanhSachTaiKhoanCo();
            //tài khoản
            tblTaiKhoanBindingSource_No.DataSource = _taiKhoanNoList;
            tblTaiKhoanBindingSource_Co.DataSource = _taiKhoanCoList;
        }




        private void CapNhatLaiTongTien()
        {
            //cập nhật lại tổng tiền chứng từ
            Decimal tongTien = 0;
            foreach (var item in _nghiepVu.tblChiTietDieuChinhGiaTris)
            {
                tongTien += (item.GiaTriTang == null ? 0 : item.GiaTriTang.Value) - (item.GiaTriGiam == null ? 0 : item.GiaTriGiam.Value);
            }
            _chungTu.tblTienTe.SoTien = tongTien;
        }
        #endregion

        //Public Member Function
        #region Public Member Function

        #endregion

        //Event Method
        #region Event Method
        private void frmDieuChinhGiaTri_Load(object sender, EventArgs e)
        {
            LayDanhSachNoCoTaiKhoan();
            //lấy danh sách nguồn
            tblNguonBindingSource.DataSource = Nguon_Factory.New().GetAll();
            //
            //tinhChatSoDuTaiKhoanBindingSource.DataSource = PSC_ERP_Business.Main.Predefined.TinhChatSoDuTaiKhoan.TinhChatSoDuTaiKhoanList;

            //ghi mục ngân sách
            ghiMucNganSachBindingSource.DataSource = CoKhong.CoKhongList;

            //lay danh sach doi tuong
            {
                List<sp_AllDoiTuong_Result> doiTuongList = new List<sp_AllDoiTuong_Result>();
                doiTuongList = ChungTu_Factory.New().Context.sp_AllDoiTuong(0).ToList();
                sp_AllDoiTuong_Result khongChon = new sp_AllDoiTuong_Result() { MaDoiTuong = 0, MaQLDoiTuong = "<<Không chọn>>", TenDoiTuong = "<<Không chọn>>" };
                doiTuongList.Insert(0, khongChon);
                sp_AllDoiTuong_ResultBindingSource.DataSource = doiTuongList;
            }
            if (_taoMoiChungTu)
            {
                KhoiTaoChungTuMoi();
            }
            else
            {

                LoadChungTuCu(_maChungTuCuCanXemLai);
            }
            _ngayBanDau = _chungTu.NgayLap.Value;
            // Cài đặt lưới
            GridUtil.SetSTTForGridView(new GridView[] { this.grdViewChiTietDieuChinhGiaTri
                , this.grdViewDinhKhoan_ButToan});
            //copy cell
            GridUtil.InitCopyCellForGridView(this.grdViewChiTietDieuChinhGiaTri
                , this.grdViewDinhKhoan_ButToan);
            //multi cell select
            GridUtil.InitMultiCellSelectForGridView(this.grdViewChiTietDieuChinhGiaTri, grdViewDinhKhoan_ButToan);


            //cài đặt master-details
            {
                GridUtil.InitDetailForGridView<tblChiTietDieuChinhGiaTri>(grdViewChiTietDieuChinhGiaTri, tblChiTietDieuChinhGiaTri.tblDieuChinhGiaChiTietTSCaBiets_EntityCollectionPropertyName, 0, 2);
                GridUtil.InitDetailForGridView<tblChiTietDieuChinhGiaTri>(grdViewChiTietDieuChinhGiaTri, tblChiTietDieuChinhGiaTri.tblDieuChinhGiaPhuTungTSCaBiets_EntityCollectionPropertyName, 1, 2);
            }
            //cài đặt delete helper
            GridUtil.DeleteHelper.Setup_ManualType(grdViewChiTietDieuChinhGiaTri, (gridView, deleteList) =>
                                                                                  {
                                                                                      //xóa chi tiết
                                                                                      ChiTietDieuChinhGiaTri_Factory.FullDelete(context: _factory.Context, deleteList: deleteList);
                                                                                  });
            GridUtil.DeleteHelper.Setup_ManualType(grdViewDinhKhoan_ButToan, (gridView, deleteList) =>
                                                                             {
                                                                                 //xóa bút toán
                                                                                 // ButToan_Factory.FullDelete(context: _factory.Context, deleteList: deleteList);
                                                                                 tblKy ky = Ky_Factory.New().XacDinhKy_ByNgay(_chungTu.NgayLap.Value);
                                                                                 ButToan_Factory.FullDeleteKiemTraKhoaTaiKhoan(_factory.Context, deleteList, PSC_ERP_Global.Main.UserID, ky.MaKy);
                                                                             });

        }



        //private void btnBoSungDCPTSuaChuaLonTheoSuaChuaLon_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    //lấy dòng chi tiết nghiệp vụ sửa chữa lớn hiện tại
        //    tblCT_NghiepVuSuaChuaLon chiTietNghiepVu = this.grdViewChiTietDieuChinhGiaTri.GetFocusedRow() as tblCT_NghiepVuSuaChuaLon;
        //    //show danh sách bổ sung dụng cụ phụ tùng theo chi tiết nghiệp vụ SCL
        //    frmDialogDanhSachBoSungDCPTvaChiTietTheoChiTietNghiepVuSuaChuaLon frm = new frmDialogDanhSachBoSungDCPTvaChiTietTheoChiTietNghiepVuSuaChuaLon(context: _factory.Context, chungTu: _chungTu, ct_NghiepVuSuaChuaLon: chiTietNghiepVu);
        //    frm.ShowDialog();
        //    //cập nhật lại tổng tiền
        //    this.CapNhatLaiTongTien();
        //}




        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dlgResult = DialogUtil.ShowSaveRequireOptions(this);
            if (dlgResult == DialogResult.Yes)
            {
                if (this.Save() == false)
                    return;
            }
            if (_objFromAnotherFactory != null)
                this._objFromAnotherFactory.CurrentForm_AddedObj = null;
            this.KhoiTaoChungTuMoi();
        }
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Save();
        }
        private void btnXoaChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            //yêu cầu người dùng xác nhận xóa
            if (KiemTraCoTaiKhoanKhoaSo(_chungTu.NgayLap.Value))
            {
                DialogUtil.ShowError("Có tài khoản khóa sổ không thể xóa chứng từ!");
            }
            else
            {
                DialogResult dlgResult = DialogUtil.ShowDelete(this);
                if (dlgResult == DialogResult.Yes)
                {
                    try
                    {
                        using (DialogUtil.WaitForDelete(this))
                        {
                            _factory.XoaChungTu(_chungTu);
                            //lưu lại thay đổi
                            _factory.SaveChangesWithoutTrackingLog();
                        }
                        //thông báo đã xóa thành công
                        DialogUtil.ShowDeleteSuccessful();
                        this.Close();
                    }
                    catch (Exception)
                    {
                        //thông báo không xóa được
                        DialogUtil.ShowNotDeleteSuccessful();
                    }
                }
            }
        }
        private void btnDanhSachChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDanhSachChungTu_DieuChinhGiaTri.ShowSingleton(null, this.MdiParent);
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #region các tab

        private void btnChonChungTuGhiTangTaiSan_Click(object sender, EventArgs e)
        {
            frmDialogTimChonChungTu_GhiTangTSCDCaBiet frm = new frmDialogTimChonChungTu_GhiTangTSCDCaBiet();
            DialogResult dlgResult = frm.ShowDialog(this);
            if (dlgResult == DialogResult.Yes)
            {
                //duyệt qua từng chứng từ ghi tăng được chọn
                foreach (tblChungTu chungTu in frm.ChungTuDuocChonList)
                {
                    IQueryable<tblTaiSanCoDinhCaBiet> danhSachTaiSanCuaChungTu = TaiSanCoDinhCaBiet_Factory.New().Get_DanhSach_TaiSanCoDinhCaBiet_ByMaChungTuGhiTang(chungTu.MaChungTu);
                    //duyệt qua từng tài sản cá biệt của chứng từ ghi tăng
                    foreach (var taiSanCaBiet in danhSachTaiSanCuaChungTu)//neu sd chungTu.tblTaiSanCoDinhCaBiets ko hieu vi sao ko lay duoc nen buoc phai thong qua danhSachTaiSanCuaChungTu (du lieu dc lay truc tiep tu TaiSanCoDinhCaBiet_Factory)
                    {

                        ThemTaiSanVaoDanhSach(taiSanCaBiet);

                    }//end foreach

                }//end foreach
            }//end if
        }
        private void btnChonChungTuGhiTangTruocNam2014_Click(object sender, EventArgs e)
        {
            frmDialogTimChonChungTu_GhiTangTSCDCaBietTruocNam2014 frm = new frmDialogTimChonChungTu_GhiTangTSCDCaBietTruocNam2014();
            DialogResult dlgResult = frm.ShowDialog(this);
            if (dlgResult == DialogResult.Yes)
            {


                //ChungTuGhiTangTaiSan_DerivedFactory chungTuGhiTang_Factory = new ChungTuGhiTangTaiSan_DerivedFactory();
                //chungTuGhiTang_Factory.Attach(frm.ChungTuDuocChonList);
                //duyệt qua từng chứng từ ghi tăng được chọn
                foreach (sp_TSCD_LayDanhSachChungTuGhiTangCuTruocNam2014_Result chungTu in frm.ChungTuDuocChonList)
                {
                    IQueryable<tblTaiSanCoDinhCaBiet> danhSachTaiSanCuaChungTu = TaiSanCoDinhCaBiet_Factory.New().Get_DanhSach_TaiSanCoDinhCaBiet_BySoChungTu(chungTu.SoChungTu);
                    //duyệt qua từng tài sản cá biệt của chứng từ ghi tăng
                    foreach (var taiSanCaBiet in danhSachTaiSanCuaChungTu)
                    {
                        ThemTaiSanVaoDanhSach(taiSanCaBiet);

                    }//end foreach

                }//end foreach
            }//end if
        }

        private void ThemTaiSanVaoDanhSach(tblTaiSanCoDinhCaBiet taiSanCaBiet)
        {
            if (_nghiepVu.tblChiTietDieuChinhGiaTris.Any(x => x.MaTSCDCaBiet == taiSanCaBiet.MaTSCDCaBiet) == false)
            {
                ChiTietDieuChinhGiaTri_Factory chiTietDieuChinhGiaTri_Factory = ChiTietDieuChinhGiaTri_Factory.New();
                DieuChinhGiaChiTietTSCaBiet_Factory dieuChinhGiaChiTietTSCaBiet_Factory = DieuChinhGiaChiTietTSCaBiet_Factory.New();
                DieuChinhGiaPhuTungTSCaBiet_Factory dieuChinhGiaPhuTungTSCaBiet_Factory = DieuChinhGiaPhuTungTSCaBiet_Factory.New();
                ChiTietNguyenGiaTSCD_Factory chiTietNguyenGiaTSCD_Factory = ChiTietNguyenGiaTSCD_Factory.New();

                //tạo mới chi tiết điều chỉnh giá trị
                tblChiTietDieuChinhGiaTri chiTiet = chiTietDieuChinhGiaTri_Factory.CreateAloneObject();
                //gán mã tài sản cá biệt
                chiTiet.MaTSCDCaBiet = taiSanCaBiet.MaTSCDCaBiet;
                chiTiet.GiaTriTang = 0;
                chiTiet.GiaTriGiam = 0;
                chiTiet.DonGia = 0;
                chiTiet.ChiPhi = 0;


                decimal nguyenGiaCu = ChiTietNguyenGiaTSCD_Factory.New().SumNguyenGiaDenNgay_ByMaTSCDCaBiet(_chungTu.NgayLap.Value, chiTiet.MaTSCDCaBiet.Value);
                //gán nguyên giá cũ
                chiTiet.NguyenGiaCu = nguyenGiaCu;//chiTietNguyenGiaDenNgay.SoTien;
                //gán nguyên giá mới
                chiTiet.NguyenGiaMoi = nguyenGiaCu;//chiTietNguyenGiaDenNgay.SoTien;
                //đưa vào danh sách
                _nghiepVu.tblChiTietDieuChinhGiaTris.Add(chiTiet);//tblChiTietDieuChinhGiaTriBindingSource.Add(chiTiet);

                //tạo mới chi tiết nguyên giá
                tblChiTietNguyenGiaTSCD chiTietNguyenGiaMoi = chiTietNguyenGiaTSCD_Factory.CreateAloneObject();


                chiTietNguyenGiaMoi.MaTSCDCaBiet = taiSanCaBiet.MaTSCDCaBiet;
                chiTietNguyenGiaMoi.SoTien = 0;
                chiTietNguyenGiaMoi.LuyKeKhauHao = TaiSanCoDinhCaBiet_Factory.New().LuyKeKhauHaoCuaTaiSanCaBietDenNgay(taiSanCaBiet.MaTSCDCaBiet, _chungTu.NgayLap.Value);//chiTietNguyenGiaDenNgay.LuyKeKhauHao;
                chiTietNguyenGiaMoi.LuyKeHaoMon = TaiSanCoDinhCaBiet_Factory.New().LuyKeHaoMonCuaTaiSanCaBietDenNgay(taiSanCaBiet.MaTSCDCaBiet, _chungTu.NgayLap.Value);//chiTietNguyenGiaDenNgay.LuyKeHaoMon;
                chiTietNguyenGiaMoi.NgayThucHien = (DateTime?)dteNgayChungTu.DateTime;
                chiTietNguyenGiaMoi.LoaiPhanBietNV = (Byte)ChiTietNguyenGiaTSCD_LoaiPhanBietNVEnum.DieuChinhGiaTriTaiSan;//điều chỉnh giá trị tài sản gốc
                //thêm chi tiết nguyên giá mới vào danh sách
                _chungTu.tblChiTietNguyenGiaTSCDs.Add(chiTietNguyenGiaMoi);
                chiTiet.tblChiTietNguyenGiaTSCDs.Add(chiTietNguyenGiaMoi);

                //đưa dụng cụ phụ tùng và chi tiết tài sản vào detail
                {
                    foreach (var item in chiTiet.tblTaiSanCoDinhCaBiet.tblChiTietTaiSanCaBiets)
                    {
                        tblDieuChinhGiaChiTietTSCaBiet dieuChinh = dieuChinhGiaChiTietTSCaBiet_Factory.CreateAloneObject();
                        dieuChinh.MaChiTietTaiSan = item.MaChiTiet;
                        //gán nguyên giá ban đầu
                        dieuChinh.NguyenGiaCTCu = item.NguyenGia;
                        dieuChinh.GiaTriTang = 0;
                        dieuChinh.GiaTriGiam = 0;
                        dieuChinh.DonGia = 0;
                        dieuChinh.ChiPhi = 0;
                        dieuChinh.NgayThucHien = _chungTu.NgayLap;
                        //
                        //thêm vào ds
                        chiTiet.tblDieuChinhGiaChiTietTSCaBiets.Add(dieuChinh);
                    }

                    foreach (var item in chiTiet.tblTaiSanCoDinhCaBiet.tblBoSungDungCuPhuTungs)
                    {
                        tblDieuChinhGiaPhuTungTSCaBiet dieuChinh = dieuChinhGiaPhuTungTSCaBiet_Factory.CreateAloneObject();
                        dieuChinh.MaDungCuPhuTung = item.MaDungCuPhuTung;
                        //gán nguyên giá ban đầu
                        dieuChinh.NguyenGiaDCPTCu = item.TongGiaTri;
                        dieuChinh.GiaTriTang = 0;
                        dieuChinh.GiaTriGiam = 0;

                        dieuChinh.NgayThucHien = _chungTu.NgayLap;
                        //
                        //thêm vào ds
                        chiTiet.tblDieuChinhGiaPhuTungTSCaBiets.Add(dieuChinh);
                    }

                }
            }
        }
        //private void btnButToanMucNganSach_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    if (this.grdViewDinhKhoan_ButToan.FocusedRowHandle >= 0)
        //    {
        //        //lấy bút toán hiện tại
        //        tblButToan currentButToan = this.grdViewDinhKhoan_ButToan.GetFocusedRow() as tblButToan;
        //        //show danh sách bút toán mục ngân sách theo bút toán
        //        frmDialogDanhSachGhiMucNganSachTheoButToan frm = new frmDialogDanhSachGhiMucNganSachTheoButToan(context: _factory.Context, chungTu: _chungTu, butToan: currentButToan, noTaiKhoanList: _taiKhoanNoList, coTaiKhoanList: _taiKhoanCoList);
        //        frm.ShowDialog();
        //    }
        //}
        private void btnCongViecChuongTrinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.grdViewDinhKhoan_ButToan.FocusedRowHandle >= 0)
            {
                //lấy bút toán hiện tại
                tblButToan currentButToan = this.grdViewDinhKhoan_ButToan.GetFocusedRow() as tblButToan;
                //show danh sách công việc chương trình
                using (frmDialogPhanLoaiChiPhi frm = new frmDialogPhanLoaiChiPhi(context: _factory.Context, chungTu: _chungTu, butToan: currentButToan))
                {
                    frm.ShowDialog();
                }
            }
        }
        private void grdViewDinhKhoan_ButToan_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            //lấy bút toán vừa tạo mới trên lưới
            tblButToan butToan = grdViewDinhKhoan_ButToan.GetRow(e.RowHandle) as tblButToan;
            //lấy diễn giải chứng từ
            butToan.DienGiai = _chungTu.DienGiai;
            if (butToan != null)
            {
                //số tiền bút toán trừ dần
                {
                    Decimal tongTienCacButToanKhac = 0;
                    foreach (var item in _chungTu.tblDinhKhoan.tblButToans)
                    {
                        if (!Object.ReferenceEquals(item, butToan))
                            tongTienCacButToanKhac += item.SoTien;
                    }
                    butToan.SoTien = (_chungTu.tblTienTe.ThanhTien != null ? _chungTu.tblTienTe.ThanhTien.Value : 0) - tongTienCacButToanKhac;
                }
                //lấy tính chất số dư được chọn
                //try
                //{
                //    TinhChatSoDuTaiKhoanEnum tinhChatSoDu = (TinhChatSoDuTaiKhoanEnum)((Int32)cbTinhChatSoDuTaiKhoan.EditValue);
                //    tblTaiKhoan taiKhoanDuocChon = cbTaiKhoan.GetSelectedDataRow() as tblTaiKhoan;
                //    sp_AllDoiTuong_Result doiTuongDuocChon = cbDoiTuong1.GetSelectedDataRow() as sp_AllDoiTuong_Result;
                //    if (taiKhoanDuocChon != null)
                //        //lấy tài khoản được chọn gán cho mặc định cho dòng định khoản mới tạo
                //        if (tinhChatSoDu == TinhChatSoDuTaiKhoanEnum.No)
                //        {
                //            butToan.NoTaiKhoan = taiKhoanDuocChon.MaTaiKhoan;
                //            butToan.MaDoiTuongNo = doiTuongDuocChon.MaDoiTuong;
                //        }
                //        else if (tinhChatSoDu == TinhChatSoDuTaiKhoanEnum.Co)
                //        {
                //            butToan.CoTaiKhoan = taiKhoanDuocChon.MaTaiKhoan;
                //            butToan.MaDoiTuongCo = doiTuongDuocChon.MaDoiTuong;
                //        }
                //}
                //catch (System.Exception ex) { }


            }
        }
        private void btnHoaDonButToan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //chứng từ điều chỉnh ko cần hóa đơn

            //if (this.grdViewDinhKhoan_ButToan.FocusedRowHandle >= 0)
            //{
            //    //lấy bút toán hiện tại
            //    tblButToan currentButToan = this.grdViewDinhKhoan_ButToan.GetFocusedRow() as tblButToan;
            //    //show danh sách bút toán hóa đơn
            //    frmDialogDanhSachHoaDonTheoButToan frm = new frmDialogDanhSachHoaDonTheoButToan(context: _factory.Context, chungTu: _chungTu, butToan: currentButToan, noTaiKhoanList: _taiKhoanNoList, coTaiKhoanList: _taiKhoanCoList);
            //    frm.ShowDialog();
            //}
        }

        //private void cbTinhChatSoDuTaiKhoan_EditValueChanged(object sender, EventArgs e)
        //{
        //    //lấy tính chất được chọn
        //    TinhChatSoDuTaiKhoanEnum tinhChat = (TinhChatSoDuTaiKhoanEnum)((Int32)(cbTinhChatSoDuTaiKhoan.EditValue));


        //    //lấy mã tài khoản được chọn trước đó
        //    Int32 maTaiKhoan = (Int32)(cbTaiKhoan.EditValue ?? 0);

        //    Boolean maTaiKhoanTuongThich = false;
        //    if (tinhChat == TinhChatSoDuTaiKhoanEnum.No)
        //    {
        //        cbTaiKhoan.Properties.DataSource = tblTaiKhoanBindingSource_No;
        //        //một nợ nhiều có = true
        //        _chungTu.tblDinhKhoan.LaMotNoNhieuCo = true;
        //        //khóa cột nợ
        //        colNoTaiKhoan.OptionsColumn.ReadOnly = true;
        //        colNoTaiKhoan.Visible = false;
        //        colDoiTuongNo.OptionsColumn.ReadOnly = true;
        //        colDoiTuongNo.Visible = false;
        //        //mở cột có
        //        colCoTaiKhoan.OptionsColumn.ReadOnly = false;
        //        colCoTaiKhoan.Visible = true;
        //        colDoiTuongCo.OptionsColumn.ReadOnly = false;
        //        colDoiTuongCo.Visible = true;
        //        //
        //        foreach (var item in _taiKhoanNoList)
        //        {
        //            if (maTaiKhoan == item.MaTaiKhoan)
        //            {
        //                maTaiKhoanTuongThich = true;
        //            }
        //        }
        //    }
        //    else if (tinhChat == TinhChatSoDuTaiKhoanEnum.Co)//cần set mặc định một có nhiều nợ
        //    {
        //        cbTaiKhoan.Properties.DataSource = tblTaiKhoanBindingSource_Co;
        //        //một nợ nhiều có = false = một có nhiều nợ
        //        _chungTu.tblDinhKhoan.LaMotNoNhieuCo = false;
        //        //khóa cột có
        //        colCoTaiKhoan.OptionsColumn.ReadOnly = true;
        //        colCoTaiKhoan.Visible = false;
        //        colDoiTuongCo.OptionsColumn.ReadOnly = true;
        //        colDoiTuongCo.Visible = false;
        //        //mở cột nợ
        //        colNoTaiKhoan.OptionsColumn.ReadOnly = false;
        //        colNoTaiKhoan.Visible = true;
        //        colDoiTuongNo.OptionsColumn.ReadOnly = false;
        //        colDoiTuongNo.Visible = true;
        //        //
        //        foreach (var item in _taiKhoanCoList)
        //        {
        //            if (maTaiKhoan == item.MaTaiKhoan)
        //            {
        //                maTaiKhoanTuongThich = true;
        //            }
        //        }


        //        if (cbTaiKhoan.EditValue == null)
        //        {
        //            //lấy tài khoản mặc định
        //            tblTaiKhoan taiKhoanMacDinh = TaiKhoan_Factory.New().Get_TaiKhoan_BySoHieu("3311");
        //            cbTaiKhoan.EditValue = taiKhoanMacDinh.MaTaiKhoan;
        //        }
        //    }
        //    //thay đổi nợ có các bút toán
        //    ThayDoiHangLoatNoHoacCoCuaButToan();

        //    //chọn lại tài khoản khác nếu tài khoản được chọn trước đó không có trong danh sách mới
        //    if (maTaiKhoanTuongThich == false)//nếu tài khoản ko tương thích
        //    {
        //        //this.cbTaiKhoan.EditValue = null;//set về null

        //        //if (cbTaiKhoan.Properties.DataSource != null)
        //        //{//lấy mã tài khoản đầu tiên trong danh sách gán cho cbTaiKhoan

        //        //    BindingSource currentBinding = cbTaiKhoan.Properties.DataSource as BindingSource;
        //        //    currentBinding.MoveFirst();
        //        //    tblTaiKhoan taiKhoanDauTien = currentBinding.Current as tblTaiKhoan;
        //        //    if (taiKhoanDauTien != null)
        //        //        this.cbTaiKhoan.EditValue = taiKhoanDauTien.MaTaiKhoan;

        //        //}
        //    }
        //}

        //private void cbTaiKhoan_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (_daLoadXong)
        //    {
        //        ThayDoiHangLoatNoHoacCoCuaButToan();
        //    }
        //}

        //private void cbDoiTuong1_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (_daLoadXong)
        //    {
        //        ThayDoiHangLoatNoHoacCoCuaButToan();
        //    }
        //}

        //private void ThayDoiHangLoatNoHoacCoCuaButToan()
        //{
        //    TinhChatSoDuTaiKhoanEnum tinhChat = (TinhChatSoDuTaiKhoanEnum)((Int32)(cbTinhChatSoDuTaiKhoan.EditValue));

        //    //chuyển hàng loạt cột nợ hoặc có chọn từ cbTaiKhoan
        //    foreach (var butToan in _chungTu.tblDinhKhoan.tblButToans)
        //    {
        //        if (tinhChat == TinhChatSoDuTaiKhoanEnum.No)
        //        {
        //            butToan.NoTaiKhoan = (Int32?)cbTaiKhoan.EditValue;
        //            butToan.MaDoiTuongNo = (Int64)cbDoiTuong1.EditValue;
        //        }
        //        else if (tinhChat == TinhChatSoDuTaiKhoanEnum.Co)
        //        {
        //            butToan.CoTaiKhoan = (Int32?)cbTaiKhoan.EditValue;
        //            butToan.MaDoiTuongCo = (Int64)cbDoiTuong1.EditValue;
        //        }
        //    }
        //}

        //private void cbGhiMucNganSach_EditValueChanged(object sender, EventArgs e)
        //{
        //    Boolean ghiMucNganSach = false;
        //    try
        //    {
        //        ghiMucNganSach = (Boolean)cbGhiMucNganSach.EditValue;

        //        if (_chungTu.tblDinhKhoan.GhiMucNganSach != ghiMucNganSach)
        //            //gán giá tri cho định khoản (rất quan trọng)
        //            _chungTu.tblDinhKhoan.GhiMucNganSach = ghiMucNganSach;

        //    }
        //    catch (System.Exception ex)
        //    {

        //    }
        //    //ẩn hiện cột ghi mục ngân sách trên lưới bút toán
        //    this.colButToanMucNganSach.Visible = ghiMucNganSach;
        //}
        #endregion

        #region Report
        private void InBienBan(Object button)
        {
            frmDialogChonPhongBan dlg = new frmDialogChonPhongBan(LayDanhSachBoPhanTrongDanhSachTaiSanCuaChungTu(), true);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                int maPhongBan = dlg.MaPhongBan;
                Boolean coChiTiet = false;
                if (Object.ReferenceEquals(btnInBienBanDieuChinhGia, button))
                {
                    //biên bản điều chỉnh giá ko chi tiết
                    coChiTiet = false;
                }
                else if (Object.ReferenceEquals(btnInBienBanDieuChinhGiaKemChiTietVaDCPT, button))
                {
                    //biên bản điều chỉnh giá có chi tiết
                    coChiTiet = true;
                }

                ReportHelper.ShowReport("NghiepVuDieuChinhGiaTri_BienBanDieuChinhGiaTri", () =>
                {
                    DataSet dataSet = new DataSet();
                    SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                    dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_BienBanDieuChinhGiaTriTaiSanCoDinh", "@MaChungTu,@MaPhongBan,@CoChiTiet", _chungTu.MaChungTu, maPhongBan, coChiTiet);
                    dataAccess.FillDataSet(ref dataSet, "NoTaiKhoan", "sp_TSCD_LayNoTaiKhoanCuaDSTaiSanTheoChungTuDieuChinhGiaTri", "@MaChungTu", _chungTu.MaChungTu);
                    dataAccess.FillDataSet(ref dataSet, "CoTaiKhoan", "sp_TSCD_LayCoTaiKhoanCuaDSTaiSanTheoChungTuDieuChinhGiaTri", "@MaChungTu", _chungTu.MaChungTu);
                    return dataSet;
                }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
            }
        }
        private void btnInBienBanDieuChinhGia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InBienBan(btnInBienBanDieuChinhGia);
        }


        private void btnInBienBanDieuChinhGiaKemChiTietVaDCPT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InBienBan(btnInBienBanDieuChinhGiaKemChiTietVaDCPT);
        }
        private void btnDanhSachTaiSanDieuChinhGia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportHelper.ShowReport("NghiepVuDieuChinhGiaTri_DSTaiSanDieuChinhGiaTri", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_DanhSachDieuChinhGiaTriTaiSanCoDinh", "@MaChungTu", _chungTu.MaChungTu);
                dataAccess.FillDataSet(ref dataSet, "NoTaiKhoan", "sp_TSCD_LayNoTaiKhoan", "@MaChungTu", _chungTu.MaChungTu);
                dataAccess.FillDataSet(ref dataSet, "CoTaiKhoan", "sp_TSCD_LayCoTaiKhoan", "@MaChungTu", _chungTu.MaChungTu);
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
        }
        private List<tblnsBoPhan> LayDanhSachBoPhanTrongDanhSachTaiSanCuaChungTu()
        {
            List<tblnsBoPhan> list = new List<tblnsBoPhan>();
            foreach (var item in _nghiepVu.tblChiTietDieuChinhGiaTris)
            {
                list.RemoveAll(x => x.MaBoPhan == item.tblTaiSanCoDinhCaBiet.PhanBoSauCung_RefObj.tblnsBoPhan.MaBoPhan);
                list.Add(item.tblTaiSanCoDinhCaBiet.PhanBoSauCung_RefObj.tblnsBoPhan);
            }

            return list;
        }

        private void btnInPhieuKeToan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportHelper.ShowReport("PhieuKeToanChungTuDieuChinhGiaTri", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_PhieuKeToanChungTu", "@MaChungTu", _chungTu.MaChungTu);
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
        }

        #endregion

        private void grdViewChiTietDieuChinhGiaTri_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (Object.ReferenceEquals(e.Column, colGiaTriTang) || Object.ReferenceEquals(e.Column, colGiaTriGiam))
            {
                tblChiTietDieuChinhGiaTri chiTiet = grdViewChiTietDieuChinhGiaTri.GetRow(e.RowHandle) as tblChiTietDieuChinhGiaTri;
                //GomGiaTriTangGiamTuDieuChinhGiaChiTietVaDieuChinhGiaPhuTungVeChiTietNghiepVu(chiTiet);

            }
        }

        private void dteNgayChungTu_EditValueChanged(object sender, EventArgs e)
        {
            //cập nhật lại ngày lập
            if (dteNgayChungTu.DateTime.Date != new DateTime(1, 1, 1) && dteNgayChungTu.DateTime.Date != _chungTu.NgayLap)
            {
                _chungTu.NgayLap = (DateTime?)dteNgayChungTu.DateTime.Date;
                //Phát sinh số chứng từ mới
                _chungTu.MaChungTuQL = _factory.Get_NextMaChungTuQL_ByYear(_chungTu.NgayLap.Value.Year, PSC_ERP_Global.Main.UserID);
                _chungTu.SoChungTu = _factory.Get_NextSoChungTuPhieuKeToanTaiSan(_chungTu.NgayLap.Value.Year, PSC_ERP_Global.Main.UserID);
            }
        }
        private void gridViewDieuChinhGiaChiTietTSCaBiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (Object.ReferenceEquals(this.colDcgChiTietTS_GiaTriTang, e.Column.na) || Object.ReferenceEquals(this.colDcgChiTietTS_GiaTriGiam, e.Column))
            if (this.colDcgChiTietTS_GiaTriTang.FieldName == e.Column.FieldName || this.colDcgChiTietTS_GiaTriGiam.FieldName == e.Column.FieldName)
            {
                ////tblDieuChinhGiaChiTietTSCaBiet dcgct = gridViewDieuChinhGiaChiTietTSCaBiet.GetRow(e.RowHandle) as tblDieuChinhGiaChiTietTSCaBiet;
                ////GomGiaTriTangGiamTuDieuChinhGiaChiTietVaDieuChinhGiaPhuTungVeChiTietNghiepVu(dcgct.tblChiTietDieuChinhGiaTri);

                //tblChiTietDieuChinhGiaTri chiTietDieuChinhGiaTri = grdViewChiTietDieuChinhGiaTri.GetFocusedRow() as tblChiTietDieuChinhGiaTri;
                //GomGiaTriTangGiamTuDieuChinhGiaChiTietVaDieuChinhGiaPhuTungVeChiTietNghiepVu(chiTietDieuChinhGiaTri);
            }
        }

        //private void GomGiaTriTangGiamTuDieuChinhGiaChiTietVaDieuChinhGiaPhuTungVeChiTietNghiepVu(tblChiTietDieuChinhGiaTri chiTietNghiepVu)
        //{
        //    //foreach (var chiTietNghiepVu in _nghiepVu.tblChiTietDieuChinhGiaTris)
        //    {
        //        decimal giaTriTang_dcgct = 0;
        //        decimal giaTriGiam_dcgct = 0;
        //        foreach (var dcgct in chiTietNghiepVu.tblDieuChinhGiaChiTietTSCaBiets)
        //        {
        //            giaTriTang_dcgct += (dcgct.GiaTriTang != null ? dcgct.GiaTriTang.Value : 0);
        //            giaTriGiam_dcgct += (dcgct.GiaTriGiam != null ? dcgct.GiaTriGiam.Value : 0);
        //        }

        //        decimal giaTriTang_dcgpt = 0;
        //        decimal giaTriGiam_dcgpt = 0;
        //        foreach (var dcgpt in chiTietNghiepVu.tblDieuChinhGiaPhuTungTSCaBiets)
        //        {
        //            giaTriTang_dcgpt += (dcgpt.GiaTriTang != null ? dcgpt.GiaTriTang.Value : 0);
        //            giaTriGiam_dcgpt += (dcgpt.GiaTriGiam != null ? dcgpt.GiaTriGiam.Value : 0);
        //        }

        //        //chỉ gôm giá trị nếu tồn tại một dòng điều chỉnh giá chi tiết tài sản hoặc điều chỉnh giá phụ tùng có giá trị >0
        //        if (giaTriTang_dcgct + giaTriTang_dcgpt > 0)
        //        {
        //            chiTietNghiepVu.GiaTriTang = giaTriTang_dcgct + giaTriTang_dcgpt;
        //        }
        //        if (giaTriGiam_dcgct + giaTriGiam_dcgpt > 0)
        //        {
        //            chiTietNghiepVu.GiaTriGiam = giaTriGiam_dcgct + giaTriGiam_dcgpt;
        //        }
        //    }
        //}
        private void gridViewDieuChinhGiaPhuTungTSCaBiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }
        private void frmDieuChinhGiaTri_FormClosing(object sender, FormClosingEventArgs e)
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
        private void btnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PSC_ERPNew.Main.Sys.frmEntityTrackingLog.ShowSingleton(null, BusinessCodeEnum.TSCD_DieuChinhGiaTri, this.MdiParent);
        }

        #endregion

        private void cbNoTaiKhoan_ForGrid_EditValueChanged(object sender, EventArgs e)
        {
            tblButToan currentButToan = grdViewDinhKhoan_ButToan.GetFocusedRow() as tblButToan;
            GridLookUpEdit gridLUED = sender as GridLookUpEdit;
            tblTaiKhoan taiKhoanNo = gridLUED.GetSelectedDataRow() as tblTaiKhoan;
            PSC_ERP.HamDungChung.KiemTraKhoaTaiKhoan(currentButToan, gridLUED, taiKhoanNo, _chungTu.NgayLap.Value, PSC_ERP_Global.Main.UserID, true);//là nợ
        }

        private void cbCoTaiKhoan_ForGrid_EditValueChanged(object sender, EventArgs e)
        {
            tblButToan currentButToan = grdViewDinhKhoan_ButToan.GetFocusedRow() as tblButToan;
            GridLookUpEdit gridLUED = sender as GridLookUpEdit;
            tblTaiKhoan taiKhoanCo = gridLUED.GetSelectedDataRow() as tblTaiKhoan;
            PSC_ERP.HamDungChung.KiemTraKhoaTaiKhoan(currentButToan, gridLUED, taiKhoanCo, _chungTu.NgayLap.Value, PSC_ERP_Global.Main.UserID, false);//là có
        }

        public bool KiemTraCoTaiKhoanKhoaSo(DateTime ngay)
        {
            if (_chungTu.tblDinhKhoan.tblButToans.Count() == 0)
                return false;
            foreach (tblButToan butToan in _chungTu.tblDinhKhoan.tblButToans)
            {
                tblKy ky = Ky_Factory.New().XacDinhKy_ByNgay(ngay);
                if (TaiKhoan_Factory.New().DaKhoaTaiKhoan(ky.MaKy, PSC_ERP_Global.Main.UserID, butToan.NoTaiKhoan ?? 0) || TaiKhoan_Factory.New().DaKhoaTaiKhoan(ky.MaKy, PSC_ERP_Global.Main.UserID, butToan.CoTaiKhoan ?? 0))
                {
                    return true;
                }
            }
            return false;
        }

        private void LockgrdView_DinhKhoan()
        {
            grdViewDinhKhoan_ButToan.Columns[0].OptionsColumn.AllowEdit = false;//"colNoTaiKhoan"
            grdViewDinhKhoan_ButToan.Columns[1].OptionsColumn.AllowEdit = false;//"colCoTaiKhoan"
            grdViewDinhKhoan_ButToan.Columns[2].OptionsColumn.AllowEdit = false;//"colSoTien"
            grdViewDinhKhoan_ButToan.Columns[3].OptionsColumn.AllowEdit = false;//"colDoiTuongNo"
            grdViewDinhKhoan_ButToan.Columns[4].OptionsColumn.AllowEdit = false;//"colDoiTuongCo"
            grdViewDinhKhoan_ButToan.Columns[5].OptionsColumn.AllowEdit = false;//"colHopDong"
            grdViewDinhKhoan_ButToan.Columns[6].OptionsColumn.AllowEdit = false;//"colDienGiai"
        }//Them

        private void UnLockgrdView_DinhKhoan()
        {
            grdViewDinhKhoan_ButToan.Columns[0].OptionsColumn.AllowEdit = true;//"colNoTaiKhoan"
            grdViewDinhKhoan_ButToan.Columns[1].OptionsColumn.AllowEdit = true;//"colCoTaiKhoan"
            grdViewDinhKhoan_ButToan.Columns[2].OptionsColumn.AllowEdit = true;//"colSoTien"
            grdViewDinhKhoan_ButToan.Columns[3].OptionsColumn.AllowEdit = true;//"colDoiTuongNo"
            grdViewDinhKhoan_ButToan.Columns[4].OptionsColumn.AllowEdit = true;//"colDoiTuongCo"
            grdViewDinhKhoan_ButToan.Columns[5].OptionsColumn.AllowEdit = true;//"colHopDong"
            grdViewDinhKhoan_ButToan.Columns[6].OptionsColumn.AllowEdit = true;//"colDienGiai"
        }//Them

        private void grdViewDinhKhoan_ButToan_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            tblButToan currentButToan = grdViewDinhKhoan_ButToan.GetRow(e.RowHandle) as tblButToan;
            tblKy ky = Ky_Factory.New().XacDinhKy_ByNgay(_chungTu.NgayLap.Value);
            if (currentButToan != null)
            {
                if (TaiKhoan_Factory.New().DaKhoaTaiKhoan(ky.MaKy, PSC_ERP_Global.Main.UserID, currentButToan.NoTaiKhoan ?? 0) || TaiKhoan_Factory.New().DaKhoaTaiKhoan(ky.MaKy, PSC_ERP_Global.Main.UserID, currentButToan.CoTaiKhoan ?? 0))
                {
                    //DialogUtil.ShowWarning("Tài khoản đã được khóa trong kỳ!\nBạn không thể thay đổi thông tin của tài khoản này\nVui lòng liên hệ người khóa tài khoản để thực hiện tiếp nghiệp vụ", "Cảnh báo");
                    LockgrdView_DinhKhoan();
                }
                else
                {
                    UnLockgrdView_DinhKhoan();
                }
            }
            else
            {
                UnLockgrdView_DinhKhoan();
            }
        }

    }
}