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
using PSC_ERP_Business.Main.Predefined;
using PSC_ERPNew.Main.Reports;
using PSC_ERP_Common.Ado.Net;
using PSC_ERP_Business.Main;
using DevExpress.XtraEditors;
//
namespace PSC_ERPNew.Main
{
    public partial class frmDieuChuyenNgoaiTSCDCaBiet : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDieuChuyenNgoaiTSCDCaBiet singleton_ = null;
        public static frmDieuChuyenNgoaiTSCDCaBiet Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDieuChuyenNgoaiTSCDCaBiet();
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
        List<tblDanhMucTSCD> _tscdList = null;
        List<tblDuyetTSCD> _duyetTSCDList = null;
        ChungTuDieuChuyenNgoai_DerivedFactory _factory = null;
        tblChungTu _chungTu = null;
        IQueryable<tblTaiKhoan> _taiKhoanNoList = null;
        IQueryable<tblTaiKhoan> _taiKhoanCoList = null;

        tblNVThanhLyvaDieuChuyenNgoaiTSCD _nghiepVu = null;

        IQueryable<tblnsNhanVien> _nhanVienList = null;
        IQueryable<tblDoiTac> _doiTacList = null;
        IQueryable<tblBoPhanERPNew> _boPhanList = null;
        List<tblHopDong> _hopDongList = null;
        long _maChungTuCuCanXemLai = 0;
        tblChungTu _objFromAnotherFactory = null;
        Boolean _taoMoiChungTu = true;
        Boolean _daLoadXong = false;
        int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmDieuChuyenNgoaiTSCDCaBiet()
        {
            InitializeComponent();
        }

        public frmDieuChuyenNgoaiTSCDCaBiet(tblChungTu chungTu)
        {
            InitializeComponent();
            _taoMoiChungTu = false;
            _objFromAnotherFactory = chungTu;
            _maChungTuCuCanXemLai = chungTu.MaChungTu;


        }
        #endregion
        //Private Member Function
        #region Private Member Function
        private void XoaDanhSachChungTu_HopDong(List<Object> deleteList)
        {

            //xóa chứng từ hợp đồng
            ChungTu_HopDong_Factory.FullDelete(context: _factory.Context, deleteList: deleteList);
            //
            LayDanhSachHopDongCuaChungTu();
            //tính lại tổng tiền chứng từ
            this.CapNhatLaiTongTien();
        }
        private void XoaDanhSachChungTu_HoaDonTaiSan(List<Object> deleteList)
        {
            //xóa chứng từ hoa don tai san
            ChungTu_HoaDonTaiSan_Factory.FullDelete(context: _factory.Context, deleteList: deleteList);
        }
        private void XemLaiChungTuCu(long maChungTu)
        {
            //chưa load xong
            _daLoadXong = false;
            {
                //Khởi tạo factory
                _factory = ChungTuDieuChuyenNgoai_DerivedFactory.New();

                // Lấy chứng từ nghiệp vụ điều chuyển ngoài
                _chungTu = _factory.Get_ChungTu_ByMaChungTu(maChungTu);
                //
                try
                {
                    _nghiepVu = _chungTu.tblNVThanhLyvaDieuChuyenNgoaiTSCDs.First();
                }
                catch (System.Exception ex)
                {

                }
                //nếu khóa sổ sẽ không cho sửa ngày chứng từ
                if (Ky_Factory.New().DaKhoaSoTSCD(_chungTu.NgayLap.Value,_maCongTy))
                {
                    this.dteNgayLap.Properties.ReadOnly = true;
                }
                // Đưa dữ liệu vào bindingsource
                GanBindingSource();
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

                LayDanhSachHopDongCuaChungTu();

            }
            //đã load xong
            _daLoadXong = true;
        }
        private void LayDanhSachHopDongCuaChungTu()
        {
            //lây hợp đồng cua chung tu
            {
                List<Int64> danhSachMaHopDong = new List<Int64>();
                //duyet qua tung hop dong trong chung tu
                foreach (var item in _chungTu.tblChungTu_HopDong)
                {
                    danhSachMaHopDong.Add(item.MaHopDong ?? 0);
                }
                _hopDongList = HopDongTaiSan_DerivedFactory.New().GetListByMaHopDongList(danhSachMaHopDong).ToList();
            }
            tblHopDong hopDong_khongChon = new tblHopDong() { MaHopDong = 0, TenHopDong = "<<Không chọn>>" };
            hopDong_khongChon.tblHopDongMuaBan = new tblHopDongMuaBan() { SoHopDong = "<<Không chọn>>" };
            _hopDongList.Insert(0, hopDong_khongChon);
            tblHopDongBindingSource.DataSource = _hopDongList;

            //////gở bỏ hợp đồng gắn sai tren but toan
            foreach (var item in _chungTu.tblDinhKhoan.tblButToans)
            {
                //List<tblHopDong> hdList = tblHopDongBindingSource.DataSource as List<tblHopDong>;
                if (false == _hopDongList.Any(x => x.MaHopDong == (item.MaHopDong ?? 0)))
                    item.MaHopDong = null;
            }
        }
        private void TaoChungTuMoi()
        {
            //chưa load xong
            _daLoadXong = false;
            {
                //Khởi tạo factory
                _factory = ChungTuDieuChuyenNgoai_DerivedFactory.New();
                //Khởi tạo chứng từ
                _chungTu = _factory.NewChungTu();
                //
                _nghiepVu = _chungTu.tblNVThanhLyvaDieuChuyenNgoaiTSCDs.First();
                // Đưa dữ liệu vào bindingsource
                this.GanBindingSource();
            }
            //đã load xong
            _daLoadXong = true;
        }

        private void GanBindingSource()
        {
            {
                tblChungTuBindingSource_Single.DataSource = _chungTu;
                tblTienTeBindingSource.DataSource = _chungTu.tblTienTe;
            }
            //
            try
            {
                tblNVThanhLyvaDieuChuyenNgoaiTSCDBindingSource.DataSource = _chungTu.tblNVThanhLyvaDieuChuyenNgoaiTSCDs;
                //
                tblCT_NVThanhLyvaDieuChuyenNgoaiTSCDBindingSource.DataSource = _nghiepVu.tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD;
            }
            catch (System.Exception ex)
            {

            }
            //
            {
                tblnsNhanVienGiaoBindingSource.DataSource = _nhanVienList;
                //
                tblnsDoiTacBindingSource.DataSource = _doiTacList;
                //
                tblBoPhanERPNewBindingSource.DataSource = _boPhanList;
                //
                if (_tscdList != null)
                    tblDanhMucTSCDBindingSource.DataSource = _tscdList;
            }
            //
            //
            {
                tblButToanBindingSource.DataSource = _chungTu.tblDinhKhoan.tblButToans;
                tblChungTuHopDongBindingSource.DataSource = _chungTu.tblChungTu_HopDong;
                tblChungTuHoaDonBindingSource.DataSource = _chungTu.tblChungTu_HoaDon;
                //new
                tblChungTuHoaDonTaiSanBindingSource.DataSource = _chungTu.tblChungTu_HoaDonTaiSan;
                //
                //tinhChatSoDuTaiKhoanBindingSource.DataSource = PSC_ERP_Business.Main.Predefined.TinhChatSoDuTaiKhoan.TinhChatSoDuTaiKhoanList;
                //tài khoản
                tblTaiKhoanBindingSource_No.DataSource = _taiKhoanNoList;
                tblTaiKhoanBindingSource_Co.DataSource = _taiKhoanCoList;
                //ghi mục ngân sách
                ghiMucNganSachBindingSource.DataSource = CoKhong.CoKhongList;
            }
        }
        private void LayDanhSachNoCoTaiKhoan()
        {
            IQueryable<tblTaiKhoan> taiKhoanList = TaiKhoan_Factory.New().GetAll();
            _taiKhoanNoList = taiKhoanList;//TaiKhoan_Factory.New().Get_DanhSachTaiKhoanNo();
            _taiKhoanCoList = taiKhoanList;// TaiKhoan_Factory.New().Get_DanhSachTaiKhoanCo();
        }

        private void ChangeFocus()
        {
            this.txtBlackHole.Focus();
        }

        private void RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim()
        {
            foreach (tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD chiTiet in _nghiepVu.tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD)
            {
                tblDuyetTSCD duyetTSCDCaBietRemoveRaKhoiDanhSachTim = null;
                foreach (tblDuyetTSCD duyetTSCDCaBiet in _duyetTSCDList)
                {
                    if (duyetTSCDCaBiet.MaTSCDCaBiet == chiTiet.MaTSCDCaBiet)
                    {
                        duyetTSCDCaBietRemoveRaKhoiDanhSachTim = duyetTSCDCaBiet;
                        break;
                    }
                }
                if (duyetTSCDCaBietRemoveRaKhoiDanhSachTim != null)
                {
                    tblDuyetTSCDBindingSource.Remove(duyetTSCDCaBietRemoveRaKhoiDanhSachTim);
                }
            }
        }

        private bool DuocPhepLuu()
        {


            Boolean duocPhepLuu = true;
            Ky_Factory ky_Factory = Ky_Factory.New();
            if (ky_Factory.DaKhoaSoTSCD(_chungTu.NgayLap.Value,_maCongTy))
            {

                //bật thông báo đã khóa sổ
                DialogUtil.ShowDaKhoaSoTSCD(_chungTu.NgayLap.Value);
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

            //kiểm tra nhân viên giao
            //if ((_nghiepVu.MaNhanVienGiao ?? 0) == 0)
            //{
            //    DialogUtil.ShowWarning("Chưa chọn nhân viên giao.");
            //    return false;
            //}
            //kiểm tra đối tác nhận
            //if ((_chungTu.MaDoiTuong ?? 0) == 0)
            //{
            //    DialogUtil.ShowWarning("Chưa chọn đối tác nhận.");
            //    return false;
            //}
            //
            if (_nghiepVu.tblTaiSanCoDinhCaBiets.Count == 0)
            {
                DialogUtil.ShowWarning("Không thể lưu chứng từ rỗng.");
                return false;
            }


            //kiểm tra định khoản
            if (_chungTu.KiemTraDinhKhoan(kiemTraSoTienChungTuBangSoTienButToan: false) == false)
                return false;

            if (_chungTu.KiemTraHoaDon() == false)
                return false;


            return duocPhepLuu;
        }

        private bool Save()
        {
            this.ChangeFocus();
            try
            {
                //Kiểm tra dữ liệu trước khi lưu
                if (this.DuocPhepLuu() == true)
                {
                    if (DialogResult.Yes == DialogUtil.ShowYesNo("Bạn muốn lưu dữu liệu không?"))
                    {
                        using (DialogUtil.WaitForSave(this))
                        {
                            // Lưu dữ liệu
                            _factory.SaveChanges(BusinessCodeEnum.TSCD_DieuChuyenNgoai.ToString());
                        }
                        DialogUtil.ShowSaveSuccessful();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                DialogUtil.ShowNotSaveSuccessful();
            }
            return false;
        }
        private void CapNhatLaiTongTien()
        {
            //cập nhật lại tổng tiền chứng từ
            Decimal tongTien = 0;
            //foreach (var item in _nghiepVu.tblTaiSanCoDinhCaBiets)
            //{
            //    tongTien += item.NguyenGiaMua.Value;
            //}
            foreach (var item in _chungTu.tblChungTu_HopDong)
            {
                tongTien += item.tblHopDong.tblHopDongMuaBan.TongTien.Value;
            }
            _chungTu.tblTienTe.SoTien = tongTien;
        }
        #endregion
        //Event Method
        #region Event Method

        private void btnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PSC_ERPNew.Main.Sys.frmEntityTrackingLog.ShowSingleton(null, BusinessCodeEnum.TSCD_DieuChuyenNgoai, this.MdiParent);
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            this.ChangeFocus();
            //lấy mã phòng ban đang chọn trong điều kiện tìm
            Int32 maPhongBanDangChon = Convert.ToInt32(cbPhongBan.EditValue);

            //lấy mã TSCD đang chọn trong điều kiện tìm
            Int32 maTSCDDangChon = Convert.ToInt32(cbTaiSanCD.EditValue);
            //Tìm kiếm
            _duyetTSCDList = DuyetTSCD_Factory.New().Get_DanhSachDuyetTSCDCaBietDaDuyet_PhucVuDieuChuyenNgoai(maPhongBanDangChon, maTSCDDangChon).ToList();
            // Đưa dữ liệu vào bindingsource
            tblDuyetTSCDBindingSource.DataSource = _duyetTSCDList;
            //remove những tài sản đã tồn tại trong chi tiết bên dưới ra khỏi danh sách tìm
            RemoveTaiSanCoDinhDaChonRaKhoiDanhSachTim();

            //thông báo nếu không tìm thấy
            if (_duyetTSCDList.Count() == 0)
            {
                DialogUtil.ShowOK("Không có dữ liệu");
            }
        }

        private void btnDuaTSVaoChungTu_Click(object sender, EventArgs e)
        {

            this.ChangeFocus();
            if (_duyetTSCDList != null && _duyetTSCDList.Count > 0)
            {
                Boolean coTaiSanCaBietDuocChonTuDanhSach = false;
                //lặp qua từng dòng tài sản tìm được
                foreach (tblDuyetTSCD duyetTSCD in _duyetTSCDList)
                {
                    //nếu tài sản được chọn
                    if (duyetTSCD.Chon == true)
                    {
                        coTaiSanCaBietDuocChonTuDanhSach = true;
                        //khởi tạo chi tiết nghiệp vụ ko dc quản lý
                        tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD chiTietNew = CT_NVThanhLyvaDieuChuyenNgoaiTSCD_Factory.New().CreateAloneObject();
                        //Đưa vào danh sách chi tiết
                        _nghiepVu.tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD.Add(chiTietNew);
                        //gán mã tài sản cá biệt
                        chiTietNew.MaTSCDCaBiet = duyetTSCD.MaTSCDCaBiet;
                        // Lấy mã chờ duyệt tài sản cố định 
                        chiTietNew.MaChoDuyetTSCD = duyetTSCD.MaChoDuyet;
                        //Cập nhật duyệt tài sản cố định cá biệt
                        chiTietNew.tblDuyetTSCD.DaThucHienNghiepVu = true;
                        //Định ngày thanh lý cho dòng tài sản cá biệt
                        chiTietNew.tblTaiSanCoDinhCaBiet.NgayThanhLy = _chungTu.NgayLap;
                        //Cập nhật thanh lý cho tài sản cá biệt
                        chiTietNew.tblTaiSanCoDinhCaBiet.ThanhLy = true;

                        //liên kết trực tiếp tài sản với nghiệp vụ thanh lý
                        _nghiepVu.tblTaiSanCoDinhCaBiets.Add(chiTietNew.tblTaiSanCoDinhCaBiet);


                        //cập nhật tổng tiền chứng từ
                        //this.CapNhatLaiTongTien();

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
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Ky_Factory.New().DaKhoaSoTSCD(_chungTu.NgayLap.Value,_maCongTy))
            {
                //bật thông báo đã khóa sổ
                DialogUtil.ShowDaKhoaSoTSCD(_chungTu.NgayLap.Value);

            }
            else
                if (DialogResult.Yes == DialogUtil.ShowYesNo(String.Format("Bạn muốn xóa chứng từ [{0}]?", this.Text)))
                {
                    try
                    {
                        // Cập nhật lại tài sản cố định cá biệt
                        //foreach (tblTaiSanCoDinhCaBiet taiSanCoDinhCaBiet in _taiSanCoDinhCaBietList)
                        //{
                        //    TaiSanCoDinhCaBiet_Factory.New().CapNhatTSCDCaBiet_PhucVuXoaTatCaDieuChuyenNgoaiAndThanhLy(taiSanCoDinhCaBiet.MaTSCDCaBiet);
                        //    DuyetTSCD_Factory.New().CapNhatChuaThucHienNghiepVuTrongDuyetTSCDCaBiet_PhucVuDieuChuyenNgoaiAndThanhLy(taiSanCoDinhCaBiet.MaTSCDCaBiet);
                        //}
                        using (DialogUtil.WaitForDelete(this))
                        {
                            //Xóa nghiệp vụ điều chuyển ngoài
                            _factory.FullDelete(_chungTu);
                            _factory.SaveChanges();
                        }
                        DialogUtil.ShowDeleteSuccessful();
                        // Tạo mới chứng từ
                        TaoChungTuMoi();
                        this.GanBindingSource();

                    }
                    catch (Exception ex)
                    {
                        DialogUtil.ShowNotDeleteSuccessful();
                    }
                }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Save();
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void frmDieuChuyenNgoaiTSCDCaBiet_Load(object sender, EventArgs e)
        {
            LayDanhSachNoCoTaiKhoan();
            //Lấy bộ phận
            _boPhanList = BoPhanERPNew_Factory.New().GetAll();
            // Lấy danh sách nhân viên 
            _nhanVienList = NhanVien_Factory.New().GetAll();
            //Lấy danh sách đối tác 
            _doiTacList = DoiTac_Factory.New().GetAll();

            //Đưa checkbox lên lưới
            PSC_ERP_Common.GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.grdViewDuyetTSCD, colChon);
            //lay danh sach doi tuong
            {
                List<sp_AllDoiTuong_Result> doiTuongList = new List<sp_AllDoiTuong_Result>();
                doiTuongList = ChungTu_Factory.New().Context.sp_AllDoiTuong(0).ToList();
                sp_AllDoiTuong_Result khongChon = new sp_AllDoiTuong_Result() { MaDoiTuong = 0, MaQLDoiTuong = "<<Không chọn>>", TenDoiTuong = "<<Không chọn>>" };
                doiTuongList.Insert(0, khongChon);
                sp_AllDoiTuong_ResultBindingSource.DataSource = doiTuongList;
            }

            if (_taoMoiChungTu == true)
            {
                TaoChungTuMoi();
            }
            else
            {
                XemLaiChungTuCu(_maChungTuCuCanXemLai);
            }
            //cài đặt master-details
            {
                PSC_ERP_Common.GridUtil.InitDetailForGridView<tblButToan>(grdViewDinhKhoan_ButToan, tblButToan.tblChungTu_HoaDon_EntityCollectionPropertyName, 0, 1);
            }

            // Cài đặt lưới
            // Set số thứ tự cho lưới
            PSC_ERP_Common.GridUtil.SetSTTForGridView(new GridView[] { this.grdViewDuyetTSCD
                , this.grdViewChiTietNghiepVu
                , this.grdViewDinhKhoan_ButToan
                , this.grdViewChungTu_HopDong 
                , this.gridViewHoaDon//new
                , this.gridView_ButToanHoaDon});

            //cài đặt delete helper
            GridUtil.DeleteHelper.Setup_ManualType(grdViewChiTietNghiepVu, (GridView gridView, List<Object> deleteList) =>
            {
                GoBoDanhSachTaiSan(deleteList);
            });
            //new
            GridUtil.DeleteHelper.Setup_ManualType(gridViewHoaDon, (GridView gridView, List<Object> deleteList) =>
            {
                //xóa chứng từ hóa đơn tai san
                XoaDanhSachChungTu_HoaDonTaiSan(deleteList);//ChungTu_HoaDon_Factory.FullDelete(context: _factory.Context, deleteList: deleteList);
            });
            GridUtil.DeleteHelper.Setup_ManualType(grdViewDinhKhoan_ButToan, (GridView gridView, List<Object> deleteList) =>
            {
                //xóa bút toán
                ButToan_Factory.FullDelete(context: _factory.Context, deleteList: deleteList);
            });
            GridUtil.DeleteHelper.Setup_ManualType(grdViewChungTu_HopDong, (GridView gridView, List<Object> deleteList) =>
            {
                //xóa chứng từ hợp đồng
                XoaDanhSachChungTu_HopDong(deleteList);
                //ChungTu_HopDong_Factory.FullDelete(context: _factory.Context, deleteList: deleteList);
            });
        }

        private void GoBoDanhSachTaiSan(List<Object> deleteList)
        {
            //chi tiết nghiệp vụ
            CT_NVThanhLyvaDieuChuyenNgoaiTSCD_Factory.FullDeleteCT_NVThanhLyvaDieuChuyenNgoaiTSCD_Factory(context: _factory.Context, deleteList: deleteList);
        }
        private void cbPhongBan_EditValueChanged(object sender, EventArgs e)
        {
            int maPhongBan = Convert.ToInt32(cbPhongBan.EditValue);
            //lấy danh sách tên tài sản
            {
                _tscdList = DanhMucTSCD_Factory.New().Get_DanhSachTaiSanCoDinh_NamTrongDanhSachDangDuyetTSCD_ByMaPhongBan_AndLoaiNghiepVu(maPhongBan, LoaiNghiepVuTaiSanEnum.DieuChuyenNgoai).ToList();
                tblDanhMucTSCD tscd_chonTatCa = new tblDanhMucTSCD() { ID = 0, MaQuanLy = "<<Tất cả>>", Ten = "<<Tất cả>>" };
                _tscdList.Insert(0, tscd_chonTatCa);
            }

            this.GanBindingSource();
        }
        private void btnDanhSachChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDanhSachChungTu_DieuChuyenNgoaiTSCDCaBiet.ShowSingleton(null, this.MdiParent);
        }
        private void dteNgayLap_EditValueChanged(object sender, EventArgs e)
        {
            //cập nhật lại ngày lập
            if (dteNgayLap.DateTime.Date != new DateTime(1, 1, 1) && dteNgayLap.DateTime.Date != _chungTu.NgayLap)
            {
                _chungTu.NgayLap = dteNgayLap.DateTime.Date;
                //Phát sinh số chứng từ mới
                _chungTu.MaChungTuQL = _factory.Get_NextMaChungTuQL_ByYear(_chungTu.NgayLap.Value.Year, PSC_ERP_Global.Main.UserID);
                _chungTu.SoChungTu = _factory.Get_NextSoChungTuPhieuKeToanTaiSan(_chungTu.NgayLap.Value.Year, PSC_ERP_Global.Main.UserID);
            }
            try
            {    //cập nhật lại ngày thanh lý cho dòng tài sản
                foreach (var item in _nghiepVu.tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD)
                {
                    item.tblTaiSanCoDinhCaBiet.NgayThanhLy = _chungTu.NgayLap;
                }
            }
            catch (System.Exception ex)
            {

            }

        }
        #region các tab


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

        private void btnHoaDonButToan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.grdViewDinhKhoan_ButToan.FocusedRowHandle >= 0)
            {
                //lấy bút toán hiện tại
                tblButToan currentButToan = this.grdViewDinhKhoan_ButToan.GetFocusedRow() as tblButToan;
                //show danh sách bút toán hóa đơn
                frmDialogDanhSachHoaDonTheoButToan frm = new frmDialogDanhSachHoaDonTheoButToan(context: _factory.Context, chungTu: _chungTu, butToan: currentButToan, noTaiKhoanList: _taiKhoanNoList, coTaiKhoanList: _taiKhoanCoList);
                frm.ShowDialog();
            }
        }
        private void btnButToanMucNganSach_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.grdViewDinhKhoan_ButToan.FocusedRowHandle >= 0)
            {
                //lấy bút toán hiện tại
                tblButToan currentButToan = this.grdViewDinhKhoan_ButToan.GetFocusedRow() as tblButToan;
                //show danh sách bút toán mục ngân sách theo bút toán
                frmDialogDanhSachGhiMucNganSachTheoButToan frm = new frmDialogDanhSachGhiMucNganSachTheoButToan(context: _factory.Context, chungTu: _chungTu, butToan: currentButToan, noTaiKhoanList: _taiKhoanNoList, coTaiKhoanList: _taiKhoanCoList);
                frm.ShowDialog();
            }
        }

        private void grdViewDinhKhoan_ButToan_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //lấy bút toán vừa tạo mới trên lưới
            tblButToan butToan = grdViewDinhKhoan_ButToan.GetRow(e.RowHandle) as tblButToan;

            if (butToan != null)
            {
                //lấy diễn giải chứng từ
                butToan.DienGiai = _chungTu.DienGiai;
                //new
                //lay ma hop dong dau tien
                {
                    tblChungTu_HopDong chungTuHopDongDauTien = _chungTu.tblChungTu_HopDong.FirstOrDefault();
                    if (chungTuHopDongDauTien != null)
                        butToan.MaHopDong = chungTuHopDongDauTien.MaHopDong;
                }
                //new
                //gan doi tuong
                butToan.MaDoiTuongCo = _chungTu.MaDoiTuong;
                butToan.MaDoiTuongNo = _chungTu.MaDoiTuong;
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
                //catch (System.Exception ex){}


            }
        }
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
        private void btnTimChonHoaDon_Click(object sender, EventArgs e)
        {
            frmDialogTimChonHoaDon frm = new frmDialogTimChonHoaDon(_chungTu, _chungTu.MaDoiTuong ?? 0);
            DialogResult dlgResult = frm.ShowDialog(this);
            if (dlgResult == DialogResult.Yes)
            {
                int count = 0;
                //duyệt qua từng hóa đơn được chọn
                foreach (tblHoaDon item in frm.HoaDonDuocChonList)
                {
                    tblChungTu_HoaDonTaiSan chungTu_HoaDonTaiSan = ChungTu_HoaDonTaiSan_Factory.New().CreateAloneObject();
                    chungTu_HoaDonTaiSan.MaHoaDon = item.MaHoaDon;
                    //đưa vào danh sách chứng từ hóa đơn tai san
                    tblChungTuHoaDonTaiSanBindingSource.Add(chungTu_HoaDonTaiSan);

                    foreach (tblButToan butToan in _chungTu.tblDinhKhoan.tblButToans)
                    {
                        tblTaiKhoan taiKhoanCo = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(butToan.CoTaiKhoan ?? 0);
                        tblTaiKhoan taiKhoanNo = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(butToan.NoTaiKhoan ?? 0);

                        if ((taiKhoanCo != null && (taiKhoanCo.SoHieuTK.StartsWith("3113") || taiKhoanCo.SoHieuTK.StartsWith("3337"))
                            )
                        || (taiKhoanNo != null && (taiKhoanNo.SoHieuTK.StartsWith("3113") || taiKhoanNo.SoHieuTK.StartsWith("3337"))
                            )
                       )
                        {
                            //butToan.tblChungTu_HoaDon.Clear();
                            if (butToan.tblChungTu_HoaDon.Any(x => x.MaHoaDon == item.MaHoaDon) == false)
                            {
                                tblChungTu_HoaDon chungTu_HoaDonNew = ChungTu_HoaDon_Factory.New().CreateAloneObject();
                                chungTu_HoaDonNew.MaHoaDon = item.MaHoaDon;
                                butToan.tblChungTu_HoaDon.Add(chungTu_HoaDonNew);
                                _chungTu.tblChungTu_HoaDon.Add(chungTu_HoaDonNew);
                                count++;
                            }

                        }

                    }//end foreach
                }//end foreach 
                /*
                if (count > 0)
                    DialogUtil.ShowInfo("Hệ thống vừa tự động gắn hóa đơn vào các bút toán thuế");
                 */
            }



        }
        private void btnTimChonHopDongTaiSan_Click(object sender, EventArgs e)
        {
            Int64 maDoiTac = 0;
            try
            {
                maDoiTac = (Int64)cbDoiTacNhan.EditValue;
            }
            catch (System.Exception ex) { }

            //if (maDoiTac == 0)
            //{
            //    DialogUtil.ShowWarning("Cần chọn đối tác trước");
            //    cbDoiTacNhan.Focus();
            //}
            //else
            {//
                frmDialogTimChonHopDongTaiSan frm = new frmDialogTimChonHopDongTaiSan(maDoiTac);
                DialogResult dlgResult = frm.ShowDialog(this);
                if (dlgResult == DialogResult.Yes)
                {

                    //duyệt qua từng hợp đồng được chọn
                    foreach (tblHopDong hd in frm.HopDongDuocChonList)
                    {
                        Boolean daTonTai = false;
                        foreach (tblChungTu_HopDong chungTu_HopDong in _chungTu.tblChungTu_HopDong)
                        {
                            if (hd.MaHopDong == chungTu_HopDong.MaHopDong)
                            {
                                daTonTai = true;
                                break;
                            }
                        }
                        //
                        if (daTonTai == false)
                        {
                            tblChungTu_HopDong chungTu_HopDong = ChungTu_HopDong_Factory.New().CreateAloneObject();
                            chungTu_HopDong.MaHopDong = hd.MaHopDong;
                            //đưa vào danh sách chứng từ hợp đồng
                            tblChungTuHopDongBindingSource.Add(chungTu_HopDong);
                            //lấy mã đối tác của hợp đồng gán cho chứng từ
                            _chungTu.MaDoiTuong = chungTu_HopDong.tblHopDong.MaDoiTac;
                        }
                    }
                    LayDanhSachHopDongCuaChungTu();
                    //tính lại tổng tiền chứng từ
                    this.CapNhatLaiTongTien();


                }
            }//
        }

        #endregion

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
            this.TaoChungTuMoi();
        }

        private void btnXoaChungTu_HopDong_Click(object sender, EventArgs e)
        {
            this.txtBlackHole.Focus();
            //yêu cầu người dùng xác nhận xóa
            DialogResult dlgResult = DialogUtil.ShowYesNo("Bạn muốn gở bỏ những dòng hợp đồng đang chọn?");
            if (dlgResult == DialogResult.Yes)
            {
                try
                {

                    Int32[] rowHandleList = this.grdViewChungTu_HopDong.GetSelectedRows();
                    if (rowHandleList.Count() > 0)
                    {
                        List<Object> deleteList = new List<Object>();
                        foreach (var index in rowHandleList)
                        {
                            deleteList.Add(this.grdViewChungTu_HopDong.GetRow(index));
                        }
                        //
                        XoaDanhSachChungTu_HopDong(deleteList);
                    }

                }
                catch (Exception ex)
                {
                    //thông báo không xóa được
                    DialogUtil.ShowError("Không thể gở bỏ những dòng hợp đồng đang chọn!");
                }
            }
        }
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
        private void frmDieuChuyenNgoaiTSCDCaBiet_FormClosing(object sender, FormClosingEventArgs e)
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
        private void btnGoBoHoaDon_Click(object sender, EventArgs e)
        {
            this.txtBlackHole.Focus();
            //yêu cầu người dùng xác nhận xóa
            DialogResult dlgResult = DialogUtil.ShowYesNo("Bạn muốn gở bỏ những dòng hóa đơn đang chọn?");
            if (dlgResult == DialogResult.Yes)
            {
                try
                {

                    Int32[] rowHandleList = this.gridViewHoaDon.GetSelectedRows();
                    if (rowHandleList.Count() > 0)
                    {
                        List<Object> deleteList = new List<Object>();
                        foreach (var index in rowHandleList)
                        {
                            deleteList.Add(this.gridViewHoaDon.GetRow(index));
                        }
                        //
                        XoaDanhSachChungTu_HoaDonTaiSan(deleteList);
                    }

                }
                catch (Exception ex)
                {
                    //thông báo không xóa được
                    DialogUtil.ShowError("Không thể gở bỏ những dòng hóa đơn đang chọn!");
                }
            }
        }
        private void btnXuatExcelDanhSachTaiSan_Click(object sender, EventArgs e)
        {
            //xuất excel danh sách tài sản cá biệt
            PSC_ERP_Common.GridUtil.ExportToExcelXlsx(gridView: this.grdViewChiTietNghiepVu, showOpenFilePrompt: true);
        }

        private void btnGoBoTaiSan_Click(object sender, EventArgs e)
        {
            this.txtBlackHole.Focus();
            //yêu cầu người dùng xác nhận xóa
            DialogResult dlgResult = DialogUtil.ShowYesNo("Bạn muốn gở bỏ những dòng tài sản đang chọn?");
            if (dlgResult == DialogResult.Yes)
            {
                try
                {

                    Int32[] rowHandleList = this.gridViewHoaDon.GetSelectedRows();
                    if (rowHandleList.Count() > 0)
                    {
                        List<Object> deleteList = new List<Object>();
                        foreach (var index in rowHandleList)
                        {
                            deleteList.Add(this.gridViewHoaDon.GetRow(index));
                        }
                        //
                        GoBoDanhSachTaiSan(deleteList);
                    }

                }
                catch (Exception ex)
                {
                    //thông báo không xóa được
                    DialogUtil.ShowError("Không thể gở bỏ những dòng tài sản đang chọn!");
                }
            }
        }
        #endregion
        #region Reports
        private void btnLenhGiaoHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_chungTu == null || _chungTu.MaChungTu == 0)
            {
                DialogUtil.ShowWarning("Chứng từ rỗng.");
                return;
            }

            ReportHelper.ShowReport("InLenhGiaoHang", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_LenhGiaoHang", "@MaChungTu", _chungTu.MaChungTu);
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
        }
        #endregion //Reports

        private void btnInPhieuKeToan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportHelper.ShowReport("PhieuKeToanChungTuDieuChuyenNgoaiTaiSan", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_PhieuKeToanChungTu", "@MaChungTu", _chungTu.MaChungTu);
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
        }

        private void grdViewDinhKhoan_ButToan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            tblButToan currentButToan = grdViewDinhKhoan_ButToan.GetRow(e.RowHandle) as tblButToan;
            if (Object.ReferenceEquals(e.Column, this.colNoTaiKhoan) || Object.ReferenceEquals(e.Column, this.colCoTaiKhoan))
            {
                int count = 0;
                //////duyệt qua từng hóa đơn
                foreach (tblChungTu_HoaDonTaiSan chungTu_HoaDonTaiSan in _chungTu.tblChungTu_HoaDonTaiSan)
                {


                    tblTaiKhoan taiKhoanCo = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(currentButToan.CoTaiKhoan ?? 0);
                    tblTaiKhoan taiKhoanNo = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(currentButToan.NoTaiKhoan ?? 0);

                    if ((taiKhoanCo != null && (taiKhoanCo.SoHieuTK.StartsWith("3113") || taiKhoanCo.SoHieuTK.StartsWith("3337"))
                            )
                        || (taiKhoanNo != null && (taiKhoanNo.SoHieuTK.StartsWith("3113") || taiKhoanNo.SoHieuTK.StartsWith("3337"))
                            )
                       )
                    {
                        if (currentButToan.tblChungTu_HoaDon.Any(x => x.MaHoaDon == chungTu_HoaDonTaiSan.MaHoaDon) == false)
                        {
                            tblChungTu_HoaDon chungTu_HoaDonNew = ChungTu_HoaDon_Factory.New().CreateAloneObject();
                            chungTu_HoaDonNew.MaHoaDon = chungTu_HoaDonTaiSan.MaHoaDon;
                            currentButToan.tblChungTu_HoaDon.Add(chungTu_HoaDonNew);
                            _chungTu.tblChungTu_HoaDon.Add(chungTu_HoaDonNew);
                            count++;
                        }
                    }

                }
                /*
                if (count > 0)
                    DialogUtil.ShowInfo(String.Format("Hệ thống vừa tự động gắn {0} hóa đơn vào bút toán thuế hiện tại", count));
                 */
            }
        }





    }
}
