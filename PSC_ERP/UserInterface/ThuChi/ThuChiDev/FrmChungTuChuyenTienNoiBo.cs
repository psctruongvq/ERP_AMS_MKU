using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using PSC_ERP_Common;
using System.Data.SqlClient;
using ERP_Library.Security;

namespace PSC_ERP
{
    public partial class FrmChungTuChuyenTienNoiBo : XtraForm
    {
        #region Properties
        public int LoaiChi = 0;
        int _maCongTy = CurrentUser.Info.MaCongTy;
        PhanQuyenSuDungForm _phanQuyen = null;
        //
        private LoaiChungTuDev _LoaiChungTu;
        public LoaiChungTuDev LoaiChungtu
        {
            get
            {
                return _LoaiChungTu;
            }
        }
        public ChungTu _ChungTu = ChungTu.NewChungTu();
        private ButToan _ButToanThue = ButToan.NewButToan();
        private ButToan _ButToanThuePhaiNop = ButToan.NewButToan();
        private ChungTu_HoaDonList _ChungTu_HoaDonList = ChungTu_HoaDonList.NewChungTu_HoaDonList();
        LoaiTienList _LoaiTienList = LoaiTienList.NewLoaiTienList();
        HeThongTaiKhoan1List _HeThongTaiKhoan1ListCo, _HeThongTaiKhoan1ListNo;
        public static ChiThuLaoList _chiThuLaoList_DaChon = ChiThuLaoList.NewChiThuLaoList();

        static decimal TongTien = 0;
        static decimal soTien = 0;
        long soChungTu = 0;// dùng cho cập nhật các đề nghị thanh toán, chuyển khoản
        public long MaKhachHang = 0;

        //static int Phieu = 2; // PhieuThu = 2; PhieuChi = 3; UyNhiemChi = 6; UyNhiemThu = 7; PhieuChuyenKhoan = 8
        public bool flag = false;

        string SoChungTuTuDongTang = string.Empty;
        DateTime NgayLap = DateTime.Today;

        DoiTuongAll dtKhachHang = DoiTuongAll.NewDoiTuongAll(0);

        string SoCTMoiPS = "";
        //
        DoiTuongAllList _DoiTuongThuChiList;
        DoiTuongAllList _NhanVienList;
        //DoiTuongAllList _DoiTuongNoList, _DoiTuongCoList;

        //IQueryable<tblChungTu> _ChungTuList;
        //ChungTuList _ChungTuList;
        HopDongMuaBanList _hopDongList;

        //bool kiemTraTaiKhoan;

        Boolean _daLoadXong = false;
        Boolean _taoMoiChungTu = true;
        DateTime _ngayLapCu;
        long _maChungTuGhiTangCuCanXemLai = 0;

        DataSet dataSet = new DataSet();
        int UserId = CurrentUser.Info.UserID;
        //private int _selectIndexTabControl = 1;//1: xtraTabPage1(Chứng từ); 2:xtraTabPage2(Danh sách chứng từ)
        //private bool _selectedTabPage2 = false;

        private bool clickButtoan = false;
        private bool handlefocus = true;
        private bool _isCellValuechangeBT = true;

        private bool _lapChungTuBienLai = false;
        private BindingSource DoiTuongForChungTuHoaDonBindingSource = new BindingSource();

        private DinhKhoanTuDong _dinhKhoanTuDong = DinhKhoanTuDong.NewDinhKhoanTuDong();
        private BindingSource LoaiThueSuatListBindingSource = new BindingSource();

        private bool _InmauCoSan = false;
        private bool isLoadCboTienTe = false;
        #endregion Properties

        #region Functions
        private void TaoBingdingOfControls()
        {
        }

        private void FormatForm()
        {
            Tab1_xtraTabPage2.PageVisible = false;//DenNghi
            Tab1_xtraTabPage3.PageVisible = false;//HoaDon
            //if (_LoaiChungTu.MaLoaiCTQuanLy == "PT111")
            //{
            //    this.Text = "Phiếu Thu";
            //    //Tab1_xtraTabPage2.PageVisible = true;//DeNghi
            //    Tab1_xtraTabPage3.PageVisible = false;//HoaDon
            //    NguoiNhanLbCtrl.Text = "Người nộp";
            //    DienGiaiLbCtrl.Text = "Lý do nộp";
            //    NhanVienLbCtrl.Text = "Nhân viên thu";
            //    btnlapChungTuBienLai.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //    //btnLapHoaDonBanRa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            //    //checkBox_ThuLao.Text = "Không In Thuế";
            //    //lblPhieuChi.Visible = true;
            //    //gridLookUpEditMaChungTuPC.Visible = true;
            //    //KhoiTaoGridLookupEditMaChungTuPhieuChi();//--
            //}
            //else if (_LoaiChungTu.MaLoaiCTQuanLy == "PC111")
            //{
            //    this.Text = "Phiếu Chi";
            //    //Tab1_xtraTabPage2.PageVisible = true;//DeNghi
            //    Tab1_xtraTabPage3.PageVisible = true;//HoaDon
            //    NguoiNhanLbCtrl.Text = "Người nhận";
            //    DienGiaiLbCtrl.Text = "Lý do chi";
            //    NhanVienLbCtrl.Text = "Nhân viên";
            //    btnlapChungTuBienLai.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    //btnLapHoaDonBanRa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    //checkBox_ThuLao.Visible = false;
            //    //lblPhieuChi.Visible = false;
            //    //gridLookUpEditMaChungTuPC.Visible = false;
            //}
            //else if (_LoaiChungTu.MaLoaiCTQuanLy == "PT112")
            //{
            //    this.Text = "Phiếu Thu Tiền Gửi";
            //    //Tab1_xtraTabPage2.PageVisible = true;//DeNghi
            //    Tab1_xtraTabPage3.PageVisible = false;//HoaDon
            //    NguoiNhanLbCtrl.Text = "Người nộp";
            //    DienGiaiLbCtrl.Text = "Lý do nộp";
            //    NhanVienLbCtrl.Text = "Nhân viên thu";
            //    btnlapChungTuBienLai.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //    //btnLapHoaDonBanRa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //}
            //else if (_LoaiChungTu.MaLoaiCTQuanLy == "PC112")
            //{
            //    this.Text = "Phiếu Chi Tiền Gửi";
            //    //Tab1_xtraTabPage2.PageVisible = true;//DeNghi
            //    Tab1_xtraTabPage3.PageVisible = true;//HoaDon
            //    NguoiNhanLbCtrl.Text = "Người nhận";
            //    DienGiaiLbCtrl.Text = "Lý do chi";
            //    NhanVienLbCtrl.Text = "Nhân viên";
            //    btnlapChungTuBienLai.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    //btnLapHoaDonBanRa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //}
            //else if (_LoaiChungTu.MaLoaiCTQuanLy == "PKT")
            //{
            //    this.Text = "Chứng Từ Nghiệp Vụ Khác";
            //    //Tab1_xtraTabPage2.PageVisible = true;//DeNghi
            //    Tab1_xtraTabPage3.PageVisible = true;//HoaDon

            //    NguoiNhanLbCtrl.Text = "Người GD";
            //    DienGiaiLbCtrl.Text = "Diễn giải";
            //    NhanVienLbCtrl.Text = "Nhân viên";
            //    btnlapChungTuBienLai.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //    //btnLapHoaDonBanRa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //    //checkBox_ThuLao.Text = "Theo Dõi Thù Lao";
            //    //lblPhieuChi.Visible = false;
            //    //gridLookUpEditMaChungTuPC.Visible = false;
            //}
        }

        private void LoadDaTa()
        {
            _LoaiTienList = LoaiTienList.GetLoaiTienList();
            LoaiTien_bindingSource.DataSource = _LoaiTienList;
            // tai khoan
            //_HeThongTaiKhoan1ListCo = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
            _HeThongTaiKhoan1ListCo = HeThongTaiKhoan1List.GetTaiKhoanConListByCongTy();
            tblTaiKhoanBindingSource_No.DataSource = _HeThongTaiKhoan1ListCo;
            _HeThongTaiKhoan1ListNo = _HeThongTaiKhoan1ListCo;
            tblTaiKhoanBindingSource_Co.DataSource = _HeThongTaiKhoan1ListNo;
            //HoatDongList
            HoatDongDevList hoatdonglist = HoatDongDevList.GetHoatDongDevList(_maCongTy);
            HoatDongDev hoatdongE = HoatDongDev.NewHoatDongDev();
            hoatdongE.TenHoatDong = "";
            hoatdonglist.Insert(0, hoatdongE);
            HoatDongList_bindingSource1.DataSource = hoatdonglist;
            //CauTrucKhoanMucChiPhiList
            CauTrucDoanhThuChiPhiList khoanmuclist = CauTrucDoanhThuChiPhiList.GetCauTrucDoanhThuChiPhiList(_maCongTy);
            CauTrucDoanhThuChiPhi khoanmucE = CauTrucDoanhThuChiPhi.NewCauTrucDoanhThuChiPhi();
            khoanmucE.Ten = "";
            khoanmuclist.Insert(0, khoanmucE);
            CauTrucDoanhThuChiPhiList_bindingSource1.DataSource = khoanmuclist;
            //DonViList
            BoPhanList bophanlist = BoPhanList.GetBoPhanList();
            BoPhan bpEmpt = BoPhan.NewBoPhan("");
            bophanlist.Insert(0, bpEmpt);
            DonViList_bindingSource1.DataSource = bophanlist;
            //Loai Thue VAT
            LoaiThueSuatListBindingSource.DataSource = LoaiThueSuatVAT.CreateListLoaiThueSuatVAT();
            if (_taoMoiChungTu)
            {
                KhoiTaoChungTuMoi();
            }
            //TaiKhoanNganHangCongTy
            TKNganHangCongTyList_bindingSource1.DataSource = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList();
            //TaiKhoanNganHangDoCongTyGiaoDich
            ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList tkNganHangCongTyGiaoDichList = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList();
            ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild tknhgiaodichEmpty = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild.NewTaiKhoanNganHangCongTy("");
            //tkNganHangCongTyGiaoDichList.Insert(0, tknhgiaodichEmpty);
            TKNganHangCongTyGiaoDichbindingSource1.DataSource = tkNganHangCongTyGiaoDichList;

        }

        private void LoadDataAfterInitChungTu()
        {
            //Thread thr = new Thread(() =>
            //{
            //    if (this.InvokeRequired)
            //    {
            //        PSC_ERP_Common.Delegate.VoidDelegate dele = new PSC_ERP_Common.Delegate.VoidDelegate(this.LoadDoiTuongList);
            //        this.Invoke(dele);
            //    }
            //    else
            //    {
            //        this.LoadDoiTuongList();
            //    }
            //});
            //thr.Start();

            this.LoadDoiTuongList();
        }

        private void KhoiTao()
        {
            hoaDonListBindingSource.DataSource = typeof(HoaDonList);
            tblChungTuBindingSource_Single.DataSource = typeof(ChungTu);
            tblDinhKhoanBindingSource_Single.DataSource = typeof(DinhKhoan);
            tblButToanBindingSource.DataSource = typeof(ButToan);
            gridControl1.DataSource = tblButToanBindingSource;
            TienTe_bindingSource.DataSource = typeof(TienTe);
            BSChungTu_bindingSource.DataSource = typeof(BoSungChungTu);
            tblTaiKhoanBindingSource_No.DataSource = typeof(HeThongTaiKhoan1List);
            tblTaiKhoanBindingSource_Co.DataSource = typeof(HeThongTaiKhoan1List);
            AllDoiTuong_bindingSource.DataSource = typeof(DoiTuongAllList);
            HoatDongList_bindingSource1.DataSource = typeof(HoatDongDevList);
            CauTrucDoanhThuChiPhiList_bindingSource1.DataSource = typeof(CauTrucDoanhThuChiPhiList);
            NhanVienList_bindingSource.DataSource = typeof(DoiTuongAllList);
            LoaiTien_bindingSource.DataSource = typeof(LoaiTienList);
            ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = typeof(ChungTu_DeNghiChuyenKhoanChildList);
            ChungTuHoaDon_bindingSource.DataSource = typeof(ChungTu_HoaDonList);
            phuongThucThanhToanListBindingSource.DataSource = typeof(PhuongThucThanhToanList);
            //this.WindowState = FormWindowState.Maximized;
            DoiTuongForChungTuHoaDonBindingSource.DataSource = typeof(DoiTuongAllList);
            LoaiThueSuatListBindingSource.DataSource = typeof(LoaiThueSuatVAT);
            DonViList_bindingSource1.DataSource = typeof(BoPhanList);
            TKNganHangCongTyList_bindingSource1.DataSource = typeof(ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList);
            TKNganHangCongTyGiaoDichbindingSource1.DataSource = typeof(ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList);
            TaoBingdingOfControls();
            DesignGridControls();
        }

        private void LoadChungTuHoaDonByButToan()
        {
            foreach (ButToan buttoan in _ChungTu.DinhKhoan.ButToan)
            {
                if (IsTaiKhoanThueKhauTru(buttoan.NoTaiKhoan))
                {
                    //_ButToanThue = buttoan;
                    //ChungTuHoaDon_bindingSource.DataSource = _ButToanThue.ChungTu_HoaDonList;
                    //ChungTuHoaDon_bindingSource.DataSource = buttoan.ChungTu_HoaDonList;
                    _ChungTu_HoaDonList = buttoan.ChungTu_HoaDonList;

                    break;
                }
            }
            //ChungTuHoaDon_bindingSource.DataSource = _ChungTu.Chungtu_HoaDonList;
            ChungTuHoaDon_bindingSource.DataSource = _ChungTu_HoaDonList;
        }
        private void LuuChungTu_HoaDon()
        {
            ChungTuHoaDon_bindingSource.EndEdit();
            //_ButToanThue.ApplyEdit();
            foreach (ButToan buttoan in _ChungTu.DinhKhoan.ButToan)
            {
                if (IsTaiKhoanThueKhauTru(buttoan.NoTaiKhoan))
                {
                    //buttoan.ChungTu_HoaDonList = _ButToanThue.ChungTu_HoaDonList;
                    buttoan.ChungTu_HoaDonList = _ChungTu_HoaDonList;
                    _ChungTu.Chungtu_HoaDonList = _ChungTu_HoaDonList;
                    foreach (ChungTu_HoaDon ct_hd in buttoan.ChungTu_HoaDonList)
                    {
                        if (ct_hd.HoaDon.LoaiHoaDon == 0)
                        {
                            ct_hd.HoaDon.LoaiHoaDon = 4;//Hoa Don Mua Vao
                        }
                    }
                    buttoan.ApplyEdit();
                    break;
                }
            }
        }

        private void GanBindingSource()
        {
            tblChungTuBindingSource_Single.DataSource = _ChungTu;
            TienTe_bindingSource.DataSource = _ChungTu.Tien;
            BSChungTu_bindingSource.DataSource = _ChungTu.BoSungChungTuKT;
            tblDinhKhoanBindingSource_Single.DataSource = _ChungTu.DinhKhoan;
            tblButToanBindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;
            gridControl1.DataSource = tblButToanBindingSource;
            ChungTuHoaDon_bindingSource.DataSource = _ChungTu_HoaDonList;// _ButToanThue.ChungTu_HoaDonList;
            ChungTu_HoaDongridControl.DataSource = ChungTuHoaDon_bindingSource;
            LoadChungTuHoaDonByButToan();
            if (_LoaiChungTu.MaLoaiCTQuanLy == "PKT" || _LoaiChungTu.MaLoaiCTQuanLy == "PT111" || _LoaiChungTu.MaLoaiCTQuanLy == "PC112")//Bang Ke or PhieThu
                ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = _ChungTu.ChungTuDeNghiList;
            this.isLoadCboTienTe = true;
        }

        private void TaoBindingDeNghiChuyenKhoan()
        {
            #region MyRegion
            if (_ChungTu.LoaiChungTuDiKem == 1)
            {
                this.ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = typeof(ChungTu_DeNghiChuyenKhoanChildList);
                ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = _ChungTu.ChungTuDeNghiList;
            }
            else if (_ChungTu.LoaiChungTuDiKem == 2 || _ChungTu.LoaiChungTuDiKem == 6) //Giấy báo có & Phí Ngân hàng
            {
                this.ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = typeof(ChungTu_GiayBaoCoList);
                ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = _ChungTu.ChungTuGiayBaoCoList;
            }
            else if (_ChungTu.LoaiChungTuDiKem == 3)
            {
                this.ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = typeof(ChungTu_GiayBanNgoaiTeChildList);
                ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = _ChungTu.ChungTuGiayBanNgoaiTe;
            }
            else if (_ChungTu.LoaiChungTuDiKem == 4)
            {
                this.ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = typeof(ChungTu_LenhChuyenTienNNChildList);
                ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = _ChungTu.ChungTuLenhChuyenTienList;
            }
            else if (_ChungTu.LoaiChungTuDiKem == 5 || _ChungTu.LoaiChungTuDiKem == 8) //5: Ủy Nhiệm Chi cấp 1 || 8: Điều chuyển nội bộ
            {
                this.ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = typeof(ChungTu_UNCChildList);
                ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = _ChungTu.ChungTuUyNhiemChiList;
            }
            else if (_ChungTu.LoaiChungTuDiKem == 7) // Giấy rút tiền mặt ( Chú ý: Chỉ tồn tại trong phiếu thu không tồn tại trong bảng kê)
            {
                this.ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = typeof(ChungTu_GiayRutTienChildList);
                ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = _ChungTu.ChungTuGiayRutTienList;
            }
            #endregion
        }

        private int GetMaTaiKhoan(String soHieuTK)
        {
            foreach (HeThongTaiKhoan1 tk in _HeThongTaiKhoan1ListCo)
                if (tk.SoHieuTK == soHieuTK)
                    return tk.MaTaiKhoan;
            return 1;
        }

        private void SetTaiKhoanDefaultForNewFirstButtoan(ButToan buttoan)
        {
            if (_dinhKhoanTuDong.Id != 0)
            {
                //buttoan.NoTaiKhoan = _dinhKhoanTuDong.TKNo;
                //buttoan.CoTaiKhoan = _dinhKhoanTuDong.TKCo;
                if (KhoaButToanTheoTaiKhoan(_dinhKhoanTuDong.TKNo) == false)
                {
                    buttoan.NoTaiKhoan = _dinhKhoanTuDong.TKNo;
                }
                if (KhoaButToanTheoTaiKhoan(_dinhKhoanTuDong.TKCo) == false)
                {
                    buttoan.CoTaiKhoan = _dinhKhoanTuDong.TKCo;
                }
            }
            else
            {
                //buttoan.NoTaiKhoan = _LoaiChungTu.TKNo;
                //buttoan.CoTaiKhoan = _LoaiChungTu.TKCo;
                if (KhoaButToanTheoTaiKhoan(_LoaiChungTu.TKNo) == false)
                {
                    buttoan.NoTaiKhoan = _LoaiChungTu.TKNo;
                }
                if (KhoaButToanTheoTaiKhoan(_LoaiChungTu.TKCo) == false)
                {
                    buttoan.CoTaiKhoan = _LoaiChungTu.TKCo;
                }
            }

            #region Old
            //if (_LoaiChungTu.MaLoaiCTQuanLy != "PKT")
            //{
            //    buttoan.NoTaiKhoan = _LoaiChungTu.TKNo;
            //    buttoan.CoTaiKhoan = _LoaiChungTu.TKCo;
            //}
            //else if (_lapChungTuBienLai)
            //{
            //    buttoan.NoTaiKhoan = _LoaiChungTu.TKNo;
            //}
            ////if (_LoaiChungTu.MaLoaiCTQuanLy == "PKT")//Bang Ke
            ////{

            ////    buttoan.NoTaiKhoan = GetMaTaiKhoan("1121");
            ////}
            ////else if (_LoaiChungTu.MaLoaiCTQuanLy == "PT111")//Phieu Thu
            ////{
            ////    buttoan.NoTaiKhoan = GetMaTaiKhoan("1111");

            ////}
            ////else if (_LoaiChungTu.MaLoaiCTQuanLy == "PC111")//Phieu Chi
            ////{
            ////    buttoan.CoTaiKhoan = GetMaTaiKhoan("1111");
            ////} 
            #endregion//Old

        }

        private void DesignGrid_ButToan()
        {
            gridControl1.DataSource = tblButToanBindingSource;
            HamDungChung.InitGridViewDev(gridView_ButToan, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(gridView_ButToan, new string[] { "DienGiai", "NoTaiKhoan", "CoTaiKhoan", "SoTienNgoaiTe", "SoTien", "DoiTuongNo", "DoiTuongCo", "MaDonVi", "IDKhoanMuc", "MaHopDong", "SoHoaDonThamChieu" },
                                new string[] { "Nội dung", "Nợ Tài Khoản", "Có Tài Khoản", "Số tiền ngoại tệ", "Số Tiền", "Đối tượng nợ", "Đối tượng có", "Đơn vị", "Thuộc khoản mục", "Số hợp đồng", "Số hóa đơn tham chiếu" },
                                             new int[] { 150, 80, 80, 90, 90, 120, 120, 100, 100, 100,100 });
            #region btnCong Viec/ChuongTrinh
            ////Column Cong Viec/ChuongTrinh
            //RepositoryItemButtonEdit ButtonEdit_CongViec_CT = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            //((System.ComponentModel.ISupportInitialize)(ButtonEdit_CongViec_CT)).BeginInit();
            //ButtonEdit_CongViec_CT.AutoHeight = false;
            //ButtonEdit_CongViec_CT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            //new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Công việc/Chương trình", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), new DevExpress.Utils.SerializableAppearanceObject(), "", null, null, true)});
            //ButtonEdit_CongViec_CT.Name = "repositoryItemButtonEdit1";
            //ButtonEdit_CongViec_CT.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            ////add button colCT_ChiPhiSX
            //GridColumn colCT_ChiPhiSX = new GridColumn();
            //colCT_ChiPhiSX.Caption = "Công việc/Chương trình";
            //colCT_ChiPhiSX.ColumnEdit = ButtonEdit_CongViec_CT;
            //colCT_ChiPhiSX.Name = "colCT_ChiPhiSX";
            //colCT_ChiPhiSX.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //colCT_ChiPhiSX.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            //colCT_ChiPhiSX.Visible = true;
            //colCT_ChiPhiSX.VisibleIndex = 8;
            //this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ButtonEdit_CongViec_CT });
            //gridView_ButToan.Columns.Add(colCT_ChiPhiSX);
            //((System.ComponentModel.ISupportInitialize)(ButtonEdit_CongViec_CT)).EndInit();
            #endregion//btnCong Viec/ChuongTrinh

            HamDungChung.AlignHeaderColumnGridViewDev(gridView_ButToan, new string[] { "DienGiai", "NoTaiKhoan", "CoTaiKhoan", "SoTienNgoaiTe", "SoTien", "DoiTuongNo", "DoiTuongCo", "MaDonVi", "IDKhoanMuc", "MaHopDong", "SoHoaDonThamChieu" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_ButToan, new string[] { "SoTien" }, "#,###.##");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView_ButToan, new string[] { "SoTien" }, "{0:#,###.##}");

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_ButToan, new string[] { "SoTienNgoaiTe" }, "#,###.##");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView_ButToan, new string[] { "SoTienNgoaiTe" }, "{0:#,###.##}");
            HamDungChung.NewRowGridViewDev(gridView_ButToan, NewItemRowPosition.Bottom);

            Utils.GridUtils.SetSTTForGridView(gridView_ButToan, 50);//M
            //
            RepositoryItemGridLookUpEdit TaiKhoanNo_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(TaiKhoanNo_GrdLU, tblTaiKhoanBindingSource_No, "SoHieuTK", "MaTaiKhoan", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TaiKhoanNo_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu", "Tên tài khoản" }, new int[] { 100, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "NoTaiKhoan", TaiKhoanNo_GrdLU);
            //
            //
            RepositoryItemGridLookUpEdit TaiKhoanCo_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(TaiKhoanCo_GrdLU, tblTaiKhoanBindingSource_Co, "SoHieuTK", "MaTaiKhoan", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TaiKhoanCo_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu", "Tên tài khoản" }, new int[] { 100, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "CoTaiKhoan", TaiKhoanCo_GrdLU);
            //
            //
            RepositoryItemGridLookUpEdit DoiTuongNo_grdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(DoiTuongNo_grdLU, DoiTuongNoList_BindingSource, "TenDoiTuong", "MaDoiTuong", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DoiTuongNo_grdLU, new string[] { "MaQLDoiTuong", "MaSoThue", "TenDoiTuong", "TenCongTy" }, new string[] { "Mã đối tượng", "Mã số thuế", "Tên đối tượng", "Tên Công Ty" }, new int[] { 90, 90, 200, 120 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "DoiTuongNo", DoiTuongNo_grdLU);
            //
            //

            RepositoryItemGridLookUpEdit DoiTuongCo_grdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(DoiTuongCo_grdLU, DoiTuongCoList_BindingSource, "TenDoiTuong", "MaDoiTuong", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DoiTuongCo_grdLU, new string[] { "MaQLDoiTuong", "MaSoThue", "TenDoiTuong", "TenCongTy" }, new string[] { "Mã đối tượng", "Mã số thuế", "Tên đối tượng", "Tên Công Ty" }, new int[] { 90, 90, 200, 120 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "DoiTuongCo", DoiTuongCo_grdLU);
            //

            //

            RepositoryItemGridLookUpEdit HopDong_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(HopDong_GrdLU, HopDong_bindingSource, "SoHopDong", "MaHopDong", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(HopDong_GrdLU, new string[] { "SoHopDong", "TenHopDong" }, new string[] { "Số hợp đồng", "Nội dung" }, new int[] { 100, 200 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "MaHopDong", HopDong_GrdLU);
            //

            ////KhoanMucCol
            //RepositoryItemGridLookUpEdit khoanMuc_GrdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(khoanMuc_GrdLU, CauTrucDoanhThuChiPhiList_bindingSource1, "Ten", "Id", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(khoanMuc_GrdLU, new string[] { "MaQL", "Ten" }, new string[] { "Mã QL", "Khoản mục" }, new int[] { 100, 200 }, false);
            //HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "IDKhoanMuc", khoanMuc_GrdLU);

            //KhoanMucCol
            RepositoryItemTreeListLookUpEdit khoanMuc_GrdLU = new RepositoryItemTreeListLookUpEdit();
            HamDungChung.InitRepositoryItemTreeListLookUpEdit(khoanMuc_GrdLU, CauTrucDoanhThuChiPhiList_bindingSource1, "Ten", "Id", "ParentID", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemTreeListLookUpEdit(khoanMuc_GrdLU, new string[] { "MaQL", "Ten" }, new string[] { "Mã QL", "Khoản mục" }, new int[] { 100, 200 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "IDKhoanMuc", khoanMuc_GrdLU);

            //
            //DonViCol
            //KhoanMucCol
            RepositoryItemGridLookUpEdit donVi_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(donVi_GrdLU, DonViList_bindingSource1, "TenBoPhan", "MaBoPhan", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(donVi_GrdLU, new string[] { "TenBoPhan", "MaBoPhanQL" }, new string[] { "Đơn vị", "Mã đơn vị" }, new int[] { 200, 100 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "MaDonVi", donVi_GrdLU);
            //
            RepositoryItemCalcEdit repositoryItemCalcEditSoTien = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();

            repositoryItemCalcEditSoTien.AutoHeight = false;
            repositoryItemCalcEditSoTien.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditSoTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repositoryItemCalcEditSoTien.Name = "repositoryItemCalcEditSoTien";
            gridView_ButToan.Columns["SoTien"].ColumnEdit = repositoryItemCalcEditSoTien;
            //
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_ButToan, new string[] { "SoTien" }, "#,###.##");
            this.gridView_ButToan.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView_ButToan_RowCellClick);
            this.gridView_ButToan.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_ButToan_CellValueChanged);
            this.gridView_ButToan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_ButToan_KeyDown);
            this.gridView_ButToan.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView_ButToan_InitNewRow);
            //this.gridView_ButToan.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView_ButToan_RowClick);

            //this.gridView_ButToan.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gridView_ButToan_FocusedColumnChanged);

            this.gridControl1.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl1_ProcessGridKey);

            this.gridView_ButToan.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdView_DinhKhoan_FocusedRowChanged);

            this.gridControl1.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grd_DinhKhoan_ProcessGridKey);
            this.gridView_ButToan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grd_DinhKhoan_KeyPress);
        }

        private void DesignGrid_DSDeNghiChuyenKhoan()
        {

            HamDungChung.InitGridViewDev(gridView_DSDeNghi, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(gridView_DSDeNghi, new string[] { "SoChungTu", "LyDo", "SoTien" },
                                new string[] { "Số chứng từ", "Lý do", "Số tiền" },
                                             new int[] { 100, 150, 100, });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView_DSDeNghi, new string[] { "SoChungTu", "LyDo", "SoTien" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_DSDeNghi, new string[] { "SoTien" }, "#,###.##");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView_DSDeNghi, new string[] { "SoTien" }, "{0:#,###.##}");
            HamDungChung.NewRowGridViewDev(gridView_DSDeNghi);

            Utils.GridUtils.SetSTTForGridView(gridView_DSDeNghi, 50);//M
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_DSDeNghi, new string[] { "SoTien" }, "#,###.##");
            this.gridView_DSDeNghi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_DSDeNghi_KeyDown);
        }

        private void DesignGrid_HoaDon()
        {
            #region Design ChungTu_HoaDon
            ChungTu_HoaDongridControl.DataSource = ChungTuHoaDon_bindingSource;

            HamDungChung.InitGridViewDev(ChungTu_HoaDongridView, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, false, true);


            //HamDungChung.ShowFieldGridViewDev_Modify(ChungTu_HoaDongridView, new string[] { "SoHoaDon", "SoSerial", "NgayLapHoaDon", "GhiChu", "MauHoaDon", "KyHieuMauHoaDon", "ThueVAT" },
            //                    new string[] { "Số hóa đơn", "Số Serial", "Ngày Lập", "Nội dung", "Mẫu hóa đơn", "Ký hiệu", "Tiền Thuế" },
            //                                 new int[] { 100, 100, 80, 150, 90, 90, 100, 100 }, true);

            //            GhiChu,MauHoaDon,SoHoaDon, KyHieuMauHoaDon, ThanhTien,thueSuatVAT, thueVAT
            //MaDoiTuong, TenDoiTuong, MaSoThue, DiaChi
            HamDungChung.ShowFieldGridViewDev_Modify(ChungTu_HoaDongridView, new string[] { "HoaDon.GhiChu", "HoaDon.MauHoaDon", "HoaDon.KyHieuMauHoaDon", "HoaDon.SoHoaDon", "HoaDon.NgayLap", "HoaDon.ThanhTien", "HoaDon.ThueSuatVAT", "HoaDon.ThueVAT", "HoaDon.TongTien", "HoaDon.MaDoiTac", "HoaDon.TenDoiTac", "HoaDon.MaSoThue", "HoaDon.DiaChi" },
                                new string[] { "Diễn giải", "Mẫu hóa đơn", "Ký hiệu", "Số hóa đơn", "Ngày hóa đơn", "Tiền trước thuế", "% thuế", "Tiền Thuế", "Tiền sau thuế", "Mã đối tượng", "Tên đối tượng", "Mã số thuế", "Địa chỉ" },
                                             new int[] { 120, 90, 90, 90, 90, 90, 80, 90, 90, 95, 100, 90, 100 }, true);

            HamDungChung.AlignHeaderColumnGridViewDev(ChungTu_HoaDongridView, new string[] { "HoaDon.GhiChu", "HoaDon.MauHoaDon", "HoaDon.KyHieuMauHoaDon", "HoaDon.SoHoaDon", "HoaDon.NgayLap", "HoaDon.ThanhTien", "HoaDon.ThueSuatVAT", "HoaDon.ThueVAT", "HoaDon.TongTien", "HoaDon.MaDoiTac", "HoaDon.TenDoiTac", "HoaDon.MaSoThue", "HoaDon.DiaChi" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(ChungTu_HoaDongridView, new string[] { "HoaDon.ThanhTien", "HoaDon.ThueVAT", "HoaDon.TongTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(ChungTu_HoaDongridView, new string[] { "HoaDon.ThanhTien", "HoaDon.ThueVAT", "HoaDon.TongTien" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(ChungTu_HoaDongridView);
            //HamDungChung.ReadOnlyColumnGridViewDev(ChungTu_HoaDongridView);

            Utils.GridUtils.SetSTTForGridView(ChungTu_HoaDongridView, 50);//M
            //DoiTuong
            RepositoryItemGridLookUpEdit DoiTuongBS_grdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(DoiTuongBS_grdLU, DoiTuongNoList_BindingSource, "TenDoiTuong", "MaDoiTuong", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DoiTuongBS_grdLU, new string[] { "MaQLDoiTuong", "MaSoThue", "TenDoiTuong" }, new string[] { "Mã đối tượng", "Mã số thuế", "Tên đối tượng" }, new int[] { 90, 90, 200 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(ChungTu_HoaDongridView, "HoaDon.MaDoiTac", DoiTuongBS_grdLU);
            //
            //LoaiThueSuatVAT
            RepositoryItemGridLookUpEdit LoaiThueSuatVAT_grdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(LoaiThueSuatVAT_grdLU, LoaiThueSuatListBindingSource, "ThueSuat", "ThueSuat", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiThueSuatVAT_grdLU, new string[] { "ThueSuat" }, new string[] { "Thuế suất" }, new int[] { 90 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(ChungTu_HoaDongridView, "HoaDon.ThueSuatVAT", LoaiThueSuatVAT_grdLU);
            //

            this.ChungTu_HoaDongridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChungTu_HoaDongridView_KeyDown);
            this.ChungTu_HoaDongridView.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.ChungTu_HoaDongridView_InitNewRow);
            //this.ChungTu_HoaDongridView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.ChungTu_HoaDongridView_RowCellClick);
            #endregion//Design ChungTu_HoaDon

        }

        private void DesignGridControls()
        {
            DesignHoatDong_gridLookUpEdit1();
            DesignNhanVien_gridLookUpEdit1();
            DesignGrid_ButToan();
            DesignGrid_DSDeNghiChuyenKhoan();
            DesignGrid_HoaDon();
            DesignMaTaiKhoanNHgridLookUpEdit();
            DesignMaTaiKhoanNHGiaoDichgridLookUpEdit();

        }

        private bool KiemTraCoTKTamUng()
        {
            ButToan currentButToan = (ButToan)tblButToanBindingSource.Current;
            if (currentButToan == null) return false;
            if (gridView_ButToan.FocusedColumn.Name == "colNoTaiKhoan")
            {
                if (currentButToan.NoTaiKhoan == 0) return false;
                if (IsTaiKhoanTamUng(currentButToan.NoTaiKhoan))
                {
                    return true;

                }
            }
            else if (gridView_ButToan.FocusedColumn.Name == "colCoTaiKhoan")
            {
                if (currentButToan.CoTaiKhoan == 0) return false;
                if (IsTaiKhoanTamUng(currentButToan.CoTaiKhoan))
                {
                    return true;

                }
            }
            return false;

        }

        private void UpdateDienGiaiButToan()
        {
            if (_taoMoiChungTu == false) return;
            foreach (ButToan buttoan in _ChungTu.DinhKhoan.ButToan)
            {
                buttoan.DienGiai = txt_DienGiai.Text;

            }
        }

        private bool CheckCoTaiKhoanBiKhoaTrongButToan()
        {
            foreach (ButToan buttoan in _ChungTu.DinhKhoan.ButToan)
            {
                if (KhoaButToanTheoTaiKhoan(buttoan.NoTaiKhoan) || KhoaButToanTheoTaiKhoan(buttoan.CoTaiKhoan))
                {
                    return true;
                }
            }
            return false;
        }

        private bool KhoaButToanTheoTaiKhoan(int mataiKhoan)
        {
            bool khoataiKhoan = false;
            KhoaSo_MaTaiKhoanRootList khoa = KhoaSo_MaTaiKhoanRootList.GetKhoaSo_MaTaiKhoanRootList(UserId, mataiKhoan, _ChungTu.NgayLap.Year > 1900 ? _ChungTu.NgayLap : _ChungTu.NgayThucHien);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    khoataiKhoan = true;
                }
            }


            if (khoataiKhoan == false && _taoMoiChungTu == false)
            {
                khoa = KhoaSo_MaTaiKhoanRootList.GetKhoaSo_MaTaiKhoanRootList(UserId, mataiKhoan, _ngayLapCu);
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSo == true)
                    {
                        khoataiKhoan = true;
                    }
                }
            }
            return khoataiKhoan;
        }//Them
        private void LockgrdView_DinhKhoan()
        {

            gridView_ButToan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit = false;
            gridView_ButToan.Columns["CoTaiKhoan"].OptionsColumn.AllowEdit = false;
            gridView_ButToan.Columns["SoTien"].OptionsColumn.AllowEdit = false;
            gridView_ButToan.Columns["DoiTuongCo"].OptionsColumn.AllowEdit = false;
            gridView_ButToan.Columns["DoiTuongNo"].OptionsColumn.AllowEdit = false;//
            //gridView_ButToan.Columns["DienGiai"].OptionsColumn.AllowEdit = false;

        }//Them

        private void UnLockgrdView_DinhKhoan()
        {

            gridView_ButToan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit = true;
            gridView_ButToan.Columns["CoTaiKhoan"].OptionsColumn.AllowEdit = true;
            gridView_ButToan.Columns["SoTien"].OptionsColumn.AllowEdit = true;
            gridView_ButToan.Columns["DoiTuongCo"].OptionsColumn.AllowEdit = true;
            gridView_ButToan.Columns["DoiTuongNo"].OptionsColumn.AllowEdit = true;//
            //gridView_ButToan.Columns["DienGiai"].OptionsColumn.AllowEdit = true;
        }//Them

        private void AddNewRowhandleGridviewButToan(int rowhandle)
        {
            #region Modify Method
            if (gridView_ButToan.RowCount == 1 && gridView_ButToan.IsNewItemRow(rowhandle))
            {
                if (gridView_ButToan.GetRow(rowhandle) == null)
                    gridView_ButToan.AddNewRow();
            }
            #endregion//Modify Method

            #region Old Method
            //decimal sotien = Convert.ToDecimal(calcEdit_ThanhTien.EditValue);
            //foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
            //{

            //    if (sotien != bt.SoTien)
            //        sotien -= bt.SoTien;
            //    else if (sotien == bt.SoTien)
            //        sotien = 0;
            //}

            //if (sotien != 0 && gridView_ButToan.IsNewItemRow(rowhandle))
            //{
            //    if (gridView_ButToan.GetRow(rowhandle) == null)
            //        gridView_ButToan.AddNewRow();
            //}
            #endregion//Old Method


        }

        private void EventRowOrColumnGrdView_DinhKhoanChange(int rowhandle)
        {
            if (isXoaDongButToan == true)
            {
                isXoaDongButToan = false;
                return;
            }

            UnLockgrdView_DinhKhoan();
            if (gridView_ButToan.IsNewItemRow(rowhandle))
            {
                if (gridView_ButToan.GetRow(rowhandle) == null)
                    gridView_ButToan.AddNewRow();
                gridView_ButToan.FocusedColumn = gridView_ButToan.VisibleColumns[0];
            }
            else if (gridView_ButToan.GetFocusedRow() != null)
            {
                ButToan buttoan = (ButToan)gridView_ButToan.GetFocusedRow();
                if (KhoaButToanTheoTaiKhoan(buttoan.NoTaiKhoan) || KhoaButToanTheoTaiKhoan(buttoan.CoTaiKhoan))
                {
                    if (buttoan.MaButToan == 0)
                    {
                        _isCellValuechangeBT = false;
                        MessageBox.Show(this, "Đã khóa sổ tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        buttoan.NoTaiKhoan = 0;
                        buttoan.CoTaiKhoan = 0;
                        _isCellValuechangeBT = true;
                    }
                    else
                        LockgrdView_DinhKhoan();
                }
            }

        }//Them 

        private void ShoworHideButtonMenu(bool isShow)
        {
            if (isShow)
            {
                btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnPrintA4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;               
                btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;               
            }
            else
            {
                btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnPrintA4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;              
                btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;               
            }
        }


        private void SetSoChungTuMoiPS(int LoaiChungTu)
        {
            int loaitien = 1;
            if (grdLU_LoaiTien.EditValue != DBNull.Value)
            {
                loaitien = Convert.ToInt32(grdLU_LoaiTien.EditValue);
            }
            else
            {
                loaitien = 1;
            }
            _ChungTu.SoChungTu = PublicClass.SetSoChungTuByMaLoaiChungTu(_LoaiChungTu.MaLoaiCT, (Convert.ToDateTime(dtmp_Ngay.EditValue)).Date);//ChungTu.LaySoChungTuMax(_LoaiChungTu.MaLoaiCT, (Convert.ToDateTime(dtmp_Ngay.EditValue)).Date.Year);
            txtSoChungTu.Text = _ChungTu.SoChungTu;
        }

        private bool KiemTraTruocKhiXoaChungTuHopLe()
        {
            if (KhoaSo())
            {
                MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_taoMoiChungTu == false && _LoaiChungTu.MaLoaiCTQuanLy != "PKT" && KiemTraSoQuy() == false)
            {
                return false;
            }
            if (CheckCoTaiKhoanBiKhoaTrongButToan())
            {
                MessageBox.Show(this, "Đã khóa sổ Tài Khoản,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (ButToan buttoan in _ChungTu.DinhKhoan.ButToan)
            {
                if (IsTaiKhoanThuePhaiNop(buttoan.CoTaiKhoan))
                {
                    if (PublicClass.KiemTraChungTuDaLapHoaDon(_ChungTu.MaChungTu, buttoan.MaButToan))
                    {
                        MessageBox.Show("Đã lập Hóa đơn bán ra, không thể xóa bút toán thuế", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

            }
            return true;
        }


        private bool DeleteChungTu()
        {
            if (KiemTraTruocKhiXoaChungTuHopLe() == false)
                return false;
            if (_ChungTu.MaChungTu != 0)
            {

                if (MessageBox.Show("Bạn Có Muốn Xóa Chứng Từ Số " + _ChungTu.SoChungTu + " ?", "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        ChungTu.DeleteChungTu(_ChungTu);
                        MessageBox.Show(this, "Xóa Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                        //tlslblThem_Click(sender, e);
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }

                }
            }

            return false;
        }

        private void KhoiTaoChungTuMoi()
        {
            //dtmp_Ngay.EditValue = (object)DateTime.Today.Date;
            dtmp_Ngay.EditValue = null;
            //chưa load xong
            //_daLoadXong = false;
            {

                _ChungTu = ChungTu.NewChungTu(_LoaiChungTu.MaLoaiCT);
                //_ChungTu.SoChungTu = PublicClass.SetSoChungTuByMaLoaiChungTu(_LoaiChungTu.MaLoaiCT, (Convert.ToDateTime(dtmp_Ngay.EditValue)).Date);//ChungTu.LaySoChungTuMax(_LoaiChungTu.MaLoaiCT, _ChungTu.NgayLap.Year);
                _ChungTu.SoChungTu = PublicClass.SetSoChungTuByMaLoaiChungTu(_LoaiChungTu.MaLoaiCT, _ChungTu.NgayThucHien);//ChungTu.LaySoChungTuMax(_LoaiChungTu.MaLoaiCT, _ChungTu.NgayLap.Year);
                _ChungTu.SoChungTuKemTheo = 1;
                soTien = 0;
                TongTien = 0;
                _ngayLapCu = _ChungTu.NgayLap.Year > 1900 ? _ChungTu.NgayLap : _ChungTu.NgayThucHien;
                _ChungTu.NgayLapString = "";
                LoadDataAfterInitChungTu();
                _ChungTu_HoaDonList = ChungTu_HoaDonList.NewChungTu_HoaDonList();
                //gán bindingSource
                GanBindingSource();
                btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            //đã load xong
            //_daLoadXong = true;
            CauTrucDoanhThuChiPhiList khoanmuclist = CauTrucDoanhThuChiPhiList.GetCauTrucDoanhThuChiPhiDangSuDungList(_maCongTy);
            CauTrucDoanhThuChiPhi khoanmucE = CauTrucDoanhThuChiPhi.NewCauTrucDoanhThuChiPhi();
            khoanmucE.Ten = "";
            khoanmuclist.Insert(0, khoanmucE);
            CauTrucDoanhThuChiPhiList_bindingSource1.DataSource = khoanmuclist;

            _DoiTuongThuChiList = DoiTuongAllList.GetDoiTuongAllList_DangSuDung("", _maCongTy, 0);//_factory.Context.sp_AllDoiTuong(0, 0).Where(x => x.MaCongTy == _maCongTy).ToList();           
            DoiTuongAll doituong = DoiTuongAll.NewDoiTuongAll("");//new sp_AllDoiTuong_Result() { MaDoiTuong = 0, TenDoiTuong = "" };
            _DoiTuongThuChiList.Insert(0, doituong);
            AllDoiTuong_bindingSource.DataSource = _DoiTuongThuChiList;

            DoiTuongNoList_BindingSource.DataSource = _DoiTuongThuChiList;
            DoiTuongCoList_BindingSource.DataSource = _DoiTuongThuChiList;
            bindingSource_DoiTuongTim.DataSource = _DoiTuongThuChiList;
            //DoiTuongForChungTu_HoaDon
            DoiTuongForChungTuHoaDonBindingSource.DataSource = _DoiTuongThuChiList;
        }

        private void GanDuLieuChoTextDoiTac()
        {

        }

        private void LoadChungTuCu(long maChungTu)
        {
            //chưa load xong
            //_daLoadXong = false;
            CauTrucDoanhThuChiPhiList khoanmuclist = CauTrucDoanhThuChiPhiList.GetCauTrucDoanhThuChiPhiList(_maCongTy);
            CauTrucDoanhThuChiPhi khoanmucE = CauTrucDoanhThuChiPhi.NewCauTrucDoanhThuChiPhi();
            khoanmucE.Ten = "";
            khoanmuclist.Insert(0, khoanmucE);
            CauTrucDoanhThuChiPhiList_bindingSource1.DataSource = khoanmuclist;

            _DoiTuongThuChiList = DoiTuongAllList.GetDoiTuongAllList_TimDoiTac("", _maCongTy, 0);//_factory.Context.sp_AllDoiTuong(0, 0).Where(x => x.MaCongTy == _maCongTy).ToList();           
            DoiTuongAll doituong = DoiTuongAll.NewDoiTuongAll("");//new sp_AllDoiTuong_Result() { MaDoiTuong = 0, TenDoiTuong = "" };
            _DoiTuongThuChiList.Insert(0, doituong);
            AllDoiTuong_bindingSource.DataSource = _DoiTuongThuChiList;

            DoiTuongNoList_BindingSource.DataSource = _DoiTuongThuChiList;
            DoiTuongCoList_BindingSource.DataSource = _DoiTuongThuChiList;
            bindingSource_DoiTuongTim.DataSource = _DoiTuongThuChiList;
            //DoiTuongForChungTu_HoaDon
            DoiTuongForChungTuHoaDonBindingSource.DataSource = _DoiTuongThuChiList;

            {
                ChungTuList ct = ChungTuList.GetChungTuListByMaChungTu_New(maChungTu);
                if (ct.Count > 0)
                {
                    _ChungTu = ct[0];
                }
                //_ChungTu = _factory.Get_ChungTu_ByMaChungTu(maChungTu);
                if (_ChungTu.MaChungTu != 0)
                {
                    _LoaiChungTu = _ChungTu.LoaiChungTu;
                    GanBindingSource();
                    NgayHT_dateEdit1.EditValue = _ChungTu.NgayThucHien;

                    if (_ChungTu.NgayLap.Year > 1900)
                    {
                        dtmp_Ngay.EditValue = _ChungTu.NgayLap;
                    }
                    else
                    {
                        dtmp_Ngay.EditValue = null;
                    }
                    //_ngayLapCu = _ChungTu.NgayLap.Year > 1900 ? _ChungTu.NgayLap : _ChungTu.NgayThucHien;
                    //dtmp_Ngay.EditValue = _ChungTu.NgayLap;
                    LoadDataAfterInitChungTu();
                    if (_LoaiChungTu.MaLoaiCTQuanLy == "PKT" || _LoaiChungTu.MaLoaiCTQuanLy == "PT111" || _LoaiChungTu.MaLoaiCTQuanLy == "PC112")//Bang Ke or PhieThu
                        TaoBindingDeNghiChuyenKhoan();

                    GanDuLieuChoTextDoiTac();
                    soChungTu = _ChungTu.MaChungTu;
                    btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    TongTien = _ChungTu.Tien.ThanhTien;
                    soTien = _ChungTu.Tien.SoTien;

                }

            }
            //đã load xong
            //_daLoadXong = true;
        }

        private bool ElementsInArryDifference(int[] compareAr)
        {
            int n = compareAr.Count();
            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    if (compareAr[j] != compareAr[i])
                    {
                        return true;
                    }
            return false;
        }

        private bool ElementsInArryEqual(int[] compareAr)
        {
            int n = compareAr.Count();
            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    if (compareAr[j] == compareAr[i])
                    {
                        return true;
                    }
            return false;
        }

        private bool KiemTraButToanHopLe()
        {
            #region Modify Method
            decimal tongtienButToan = 0;
            string soHoaDonThamChieu = "";
            foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
            {
                if (bt.NoTaiKhoan == 0 || bt.CoTaiKhoan == 0)
                {
                    MessageBox.Show(this, "Chưa chọn đầy đủ tài khoản của bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                #region KiemTraDoiTuongTheoDoi
                HeThongTaiKhoan1 httkno = HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.NoTaiKhoan);
                HeThongTaiKhoan1 httkco = HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.CoTaiKhoan);
                if (httkno.CoDoiTuongTheoDoi == true)
                {
                    if (bt.DoiTuongNo == 0)
                    {
                        MessageBox.Show(this, "Vui lòng chọn đối tượng Nợ cho bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (httkco.CoDoiTuongTheoDoi == true)
                {
                    if (bt.DoiTuongCo == 0)
                    {
                        MessageBox.Show(this, "Vui lòng chọn đối tượng Có cho bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                //Khoan Muc Chi Phi
                if (httkno.CoTheoDoiKhoanMucChiPhi == true || httkco.CoTheoDoiKhoanMucChiPhi == true)
                {
                    if (bt.IDKhoanMuc == 0)
                    {
                        MessageBox.Show(this, "Vui lòng chọn khoản mục CP cho bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                //Don Vi
                if (httkno.CoDonViTheoDoi == true || httkco.CoDonViTheoDoi == true)
                {
                    if (bt.MaDonVi == 0)
                    {
                        if (MessageBox.Show("Đơn vị đang để trống cho tài khoản có theo dõi đơn vị, bạn có muốn tiếp tục lưu?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            return false;
                        }
                    }
                }
                soHoaDonThamChieu = bt.SoHoaDonThamChieu + "";
                if (soHoaDonThamChieu != "")
                {
                    bool isSoHoaDonHopLe = false;
                    foreach (ChungTu_HoaDonThanhToan cthd in _ChungTu.ChungTu_HoaDonThanhToanList)
                    {
                        if (soHoaDonThamChieu == cthd.HoaDon.SoHoaDon)
                            isSoHoaDonHopLe = true;
                    }

                    if (isSoHoaDonHopLe == false)
                    {
                        MessageBox.Show("Số hóa đơn bên định khoản không có trong danh sách hóa đơn tham chiếu!", "Thông báo");
                        return false;
                    }
                }
                #endregion KiemTraDoiTuongTheoDoi

                tongtienButToan += bt.SoTien;

                #region ButToanThue
                if (IsTaiKhoanThueKhauTru(bt.NoTaiKhoan))
                {
                    if (bt.ChungTu_HoaDonList.Count == 0)
                    {
                        MessageBox.Show("Vui lòng nhập hóa đơn cho Bút toán thuế!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        decimal tongTienThueHoaDon = 0;
                        foreach (ChungTu_HoaDon ct_hd in bt.ChungTu_HoaDonList)
                        {
                            tongTienThueHoaDon += ct_hd.HoaDon.TienThue;
                        }
                        if (bt.SoTien != tongTienThueHoaDon)
                        {
                            MessageBox.Show("Tổng Tiền Thuế Hóa đơn và Số tiền bút toán thuế không bằng nhau!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
                #endregion //ButToanThue
            }
            if (_ChungTu.Tien.ThanhTien != tongtienButToan)
            {
                MessageBox.Show("Tổng tiền bút toán và Số tiền Chứng từ không bằng nhau, không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //if (_ChungTu.Tien.SoTien != tongtienButToan)
            //{
            //    MessageBox.Show("Tổng tiền bút toán và Số tiền Chứng từ không bằng nhau, không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            #endregion//Modify Method

            #region Old Method
            //_ChungTu.DinhKhoan.LaMotNoNhieuCo = true;
            //if (_ChungTu.DinhKhoan.ButToan.Count == 1 && _LoaiChungTu.MaLoaiCTQuanLy == "PC111")
            //{
            //    _ChungTu.DinhKhoan.LaMotNoNhieuCo = false;
            //    return true;
            //}
            //else if (_ChungTu.DinhKhoan.ButToan.Count > 1)
            //{
            //    decimal tongtienButToan = 0;
            //    int[] noArry = new int[_ChungTu.DinhKhoan.ButToan.Count];
            //    int[] coArry = new int[_ChungTu.DinhKhoan.ButToan.Count];
            //    int n = 0;
            //    foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
            //    {
            //        if (bt.NoTaiKhoan == 0 || bt.CoTaiKhoan == 0)
            //        {
            //            MessageBox.Show(this, "Chưa chọn đầy đủ tài khoản của bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }
            //        tongtienButToan += bt.SoTien;

            //        #region ButToanThue
            //        if (IsTaiKhoanThueKhauTru(bt.NoTaiKhoan))
            //        {
            //            if (bt.ChungTu_HoaDonList.Count == 0)
            //            {
            //                MessageBox.Show("Vui lòng nhập hóa đơn cho Bút toán thuế!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return false;
            //            }
            //            else
            //            {
            //                decimal tongTienThueHoaDon = 0;
            //                foreach (ChungTu_HoaDon ct_hd in bt.ChungTu_HoaDonList)
            //                {
            //                    tongTienThueHoaDon += ct_hd.HoaDon.TienThue;
            //                }
            //                if (bt.SoTien != tongTienThueHoaDon)
            //                {
            //                    MessageBox.Show("Tổng Tiền Thuế Hóa đơn và Số tiền bút toán thuế không bằng nhau!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                    return false;
            //                }
            //            }
            //        }
            //        #endregion //ButToanThue

            //        noArry[n] = bt.NoTaiKhoan;
            //        coArry[n] = bt.CoTaiKhoan;
            //        n += 1;
            //    }
            //    if (_ChungTu.Tien.SoTien != tongtienButToan)
            //    {
            //        MessageBox.Show("Tổng tiền bút toán và Số tiền Chứng từ không bằng nhau, không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return false;
            //    }
            //    if (
            //        (ElementsInArryDifference(noArry) && ElementsInArryDifference(coArry))
            //        )
            //    {
            //        MessageBox.Show("Bút toán nhiều Nợ nhiều Có, không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return false;
            //    }
            //    else if (ElementsInArryDifference(noArry))
            //    {
            //        _ChungTu.DinhKhoan.LaMotNoNhieuCo = false;
            //    }
            //}
            #endregion//Old Method

            return true;
        }

        private bool KiemTraSoChungTu(string soct)
        {
            if (soct.Length < 5)
                return false;
            string[] mang = new string[4];
            for (int i = 0; i < 4; i++)
            {
                mang[i] = soct.Substring(i, 1);
            }
            // kiem tra so
            for (int j = 0; j < 4; j++)
            {
                try
                {
                    int.Parse(mang[j]);
                }
                catch
                {

                    return false;
                }
            }
            return true;
        }

        #region XuLy Thue
        private bool IsTaiKhoanThueKhauTru(int mataikhoan)
        {
            if (mataikhoan == null || mataikhoan == 0) return false;
            HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(mataikhoan);
            if (PublicClass.KiemTraLaTaiKhoanThueKhauTru(tk.SoHieuTK))
            {
                return true;
            }
            return false;
        }
        private bool IsTaiKhoanThuePhaiNop(int mataikhoan)
        {
            if (mataikhoan == null || mataikhoan == 0) return false;
            HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(mataikhoan);
            if (PublicClass.KiemTraLaTaiKhoanThuePhaiNop(tk.SoHieuTK))
            {
                return true;
            }
            return false;
        }
        private bool IsTaiKhoanTamUng(int mataikhoan)
        {
            if (mataikhoan == null || mataikhoan == 0) return false;
            HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(mataikhoan);
            if (PublicClass.KiemTraLaTaiKhoanTamUng(tk.SoHieuTK))
            {
                return true;
            }
            return false;
        }

        private void LoadFormTamUng(int maTaiKhoan)
        {
            //if (IsTaiKhoanTamUng(maTaiKhoan))
            //{
            //    if (_ChungTu.DoiTuong != 0)
            //    {
            //        PSC_ERP.frmTamUng_Dev _frmTamUng = new PSC_ERP.frmTamUng_Dev(_ChungTu);
            //        _frmTamUng.Show(this);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Vui lòng nhập đối tượng tạm ứng!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
        }

        private bool KhoaSoThue()
        {
            bool khoasothue = false;
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ChungTu.NgayLap);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSoThue == true)
                {
                    khoasothue = true;
                }
            }
            //
            if (khoasothue == false && _ChungTu.IsNew == false)
            {
                khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ngayLapCu);
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSoThue == true)
                    {
                        khoasothue = true;
                    }
                }
            }
            return khoasothue;
        }//Them
        #endregion//XuLy Thue

        private bool KhoaSo()
        {
            bool khoaso = false;
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ChungTu.NgayLap.Year > 1900 ? _ChungTu.NgayLap : _ChungTu.NgayThucHien);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    khoaso = true;
                }
            }

            if (khoaso == false && _taoMoiChungTu == false)
            {
                khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ngayLapCu);
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSo == true)
                    {
                        khoaso = true;
                    }
                }
            }
            return khoaso;
        }

        private Boolean DuocPhepLuu()
        {
            Boolean duocPhepLuu = true;

            if (KhoaSo())
            {
                MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtSoChungTu.Text.Trim() == "")
            {
                MessageBox.Show(this, "Vui lòng nhập số chứng từ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (_ChungTu.MaChungTu == 0)
                    txtSoChungTu.Text = SoCTMoiPS;
                else
                    txtSoChungTu.Text = _ChungTu.SoChungTu;
                txtSoChungTu.Focus();
                return false;
            }
            //kiểm tra trùng số chứng từ
            if (ChungTu.KiemTraSoChungTu(txtSoChungTu.Text, _ChungTu) == true)
            {
                txtSoChungTu.Focus();
                DialogResult dlgResult = MessageBox.Show(this, "Trùng số chứng từ. Tự động phát sinh số chứng từ mới", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dlgResult == DialogResult.Yes)
                {
                    _ChungTu.SoChungTu = PublicClass.SetSoChungTuByMaLoaiChungTu(_LoaiChungTu.MaLoaiCT, (Convert.ToDateTime(dtmp_Ngay.EditValue)).Date);//ChungTu.LaySoChungTuMax(_LoaiChungTu.MaLoaiCT, _ChungTu.NgayLap.Year);
                    //đệ quy
                    return DuocPhepLuu();
                }
                else
                    return false;
            }
            else if (_ChungTu.Tien.ThanhTien == 0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Số Tiền Chứng Từ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                calcEdit_ThanhTien.Focus();
                return false;
            }
            //else if (_ChungTu.Tien.SoTien == 0)
            //{
            //    MessageBox.Show(this, "Vui Lòng Nhập Số Tiền Chứng Từ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    calcEdit_SoTien.Focus();
            //    return false;
            //}
            if (_LoaiChungTu.MaLoaiCTQuanLy == "PC112")
            {
                if (_ChungTu.BoSungChungTuKT.MaTaiKhoanNH == 0)
                {
                    MessageBox.Show(this, "Vui lòng nhập số tài khoản chi!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MaTaiKhoanNHgridLookUpEdit.Focus();
                    return false;
                }
            }

            #region BS ChungTu_HoaDon
            LuuChungTu_HoaDon();
            #endregion //BS ChungTu_HoaDon

            if (KiemTraButToanHopLe() == false)
                return false;
            //if (_ChungTu.KiemTraDinhKhoanBangKe() == false)
            //    return false;

            //if (_ChungTu.KiemTraHoaDonThuChi() == false)
            //    return false;



            return duocPhepLuu;
        }

        private bool Save()
        {
            XuLyTruocKhiLuu();
            //kiểm tra chứng từ trước khi lưu
            if (DuocPhepLuu())
            {
                try
                {
                    using (DialogUtil.WaitForSave(this))
                    {

                        #region BS ChiThuLao
                        foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
                        {
                            foreach (ChungTu_ChiPhiSanXuat cpsx in bt.ChungTuChiPhiSanXuatList)
                            {
                                //ChiThuLao
                                foreach (ChiThuLao ctl in cpsx.ChiThuLaoList)
                                {
                                    ctl.MaChungTu = _ChungTu.MaChungTu;
                                    ctl.SoChungTu = _ChungTu.SoChungTu;
                                }
                                //ChiPhiThucHien
                                foreach (ChiPhiThucHien cpth in cpsx.ChiPhiThucHienList)
                                {
                                    cpth.MaChungTu = _ChungTu.MaChungTu;
                                    cpth.TenChungTu = _ChungTu.SoChungTu;
                                }

                            }
                        }
                        #endregion //BS Chi ThuLa0

                        if (dtmp_Ngay.Text == "")
                        {
                            _ChungTu.NgayLapString = "";  //cho NgayLap ve trong
                        }
                        else
                        {
                            _ChungTu.NgayLap = ((DateTime)dtmp_Ngay.EditValue).Date;
                        }
                        _ChungTu.ApplyEdit();
                        _ChungTu.Save();
                    }
                    _taoMoiChungTu = false;
                    _ngayLapCu = _ChungTu.NgayLap.Year > 1900 ? _ChungTu.NgayLap : _ChungTu.NgayThucHien;
                    //Tiến hành cập nhật lại mã chứng từ chí phí (nếu có)
                    if (_chiThuLaoList_DaChon != null && _chiThuLaoList_DaChon.Count > 0)
                    {
                        foreach (ButToan itemButToan in _ChungTu.DinhKhoan.ButToan)
                        {
                            foreach (ChungTu_ChiPhiSanXuat itemChungTu in itemButToan.ChungTuChiPhiSanXuatList)
                            {
                                foreach (ChiThuLao item in _chiThuLaoList_DaChon)
                                {
                                    if (item.MaChuongTrinh == itemChungTu.MaChuongTrinh)
                                    {
                                        CapNhatMaButToanChiPhiSanXuat(itemChungTu.MactChiphisanxuat, item.MaBoPhanGui, item.MaChuongTrinh, item.SoDNCK, item.LoaiNV);
                                    }
                                }
                            }
                        }
                    }
                    DialogUtil.ShowSaveSuccessful();
                    return true;

                }
                catch (System.Exception ex)
                {
                    //DialogUtil.ShowNotSaveSuccessful();
                    MessageBox.Show("Lưu không thành công " + ex.ToString());
                }
            }
            return false;
        }

        private void CapNhatMaButToanChiPhiSanXuat(long maButToanChiPhiSanXuat, int maBoPhan, int maChuongTrinh, string soDeNghi, bool loaiNV)
        {

            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_CapNhatMaButToanChiPhiSanXuat";
                    cm.Parameters.AddWithValue("@MaButToanChiPhiSanXuat", maButToanChiPhiSanXuat);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    cm.Parameters.AddWithValue("@SoDeNghi", soDeNghi);
                    cm.Parameters.AddWithValue("@LoaiNV", loaiNV);

                    cm.ExecuteNonQuery();
                }
            }//using
        }

        #region HoatDong
        private void DesignHoatDong_gridLookUpEdit1()
        {
            HamDungChung.InitGridLookUpDev2(HoatDong_gridLookUpEdit1, HoatDongList_bindingSource1, "TenHoatDong", "MaHoatDong", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(HoatDong_gridLookUpEdit1, new string[] { "TenHoatDong", "MaQLHoatDong" }, new string[] { "Hoạt động", "Mã QL" }, new int[] { 120, 100 }, false);
            //HoatDong_gridLookUpEdit1.EditValueChanged += new System.EventHandler(this.HoatDong_gridLookUpEdit1_EditValueChanged);
        }
        #endregion//HoatDong

        #region DoiTuong
        private void LoadDoiTuongList()
        {
            try
            {
                if (_daLoadXong == true) return;

                // doi tuong
                if (_LoaiChungTu.MaLoaiCTQuanLy.StartsWith("PT111"))
                {
                    _DoiTuongThuChiList = DoiTuongAllList.GetDoiTuongAllList_TimDoiTac("", _maCongTy, 4);//Chỉ Load Khách Hàng,vừa là Khách hàng vừa là NCC
                }
                else if (_LoaiChungTu.MaLoaiCTQuanLy.StartsWith("PC111"))
                {
                    _DoiTuongThuChiList = DoiTuongAllList.GetDoiTuongAllList_TimDoiTac("", _maCongTy, 7);//Chỉ Load Nhà cung cấp,vừa là Khách hàng vừa là NCC
                }
                else
                {
                    _DoiTuongThuChiList = DoiTuongAllList.GetDoiTuongAllList_TimDoiTac("", _maCongTy, 0);//_factory.Context.sp_AllDoiTuong(0, 0).Where(x => x.MaCongTy == _maCongTy).ToList();
                }
                DoiTuongAll doituong = DoiTuongAll.NewDoiTuongAll("");//new sp_AllDoiTuong_Result() { MaDoiTuong = 0, TenDoiTuong = "" };
                _DoiTuongThuChiList.Insert(0, doituong);
                AllDoiTuong_bindingSource.DataSource = _DoiTuongThuChiList;
                // NhanVien
                _NhanVienList = DoiTuongAllList.GetDoiTuongAllList_Tim_NhanVien("", _maCongTy);//_factory.Context.sp_AllDoiTuong(0, 0).Where(x => x.MaCongTy == _maCongTy).ToList();
                DoiTuongAll nhanvien = DoiTuongAll.NewDoiTuongAll("");//new sp_AllDoiTuong_Result() { MaDoiTuong = 0, TenDoiTuong = "" };
                _NhanVienList.Insert(0, nhanvien);
                NhanVienList_bindingSource.DataSource = _NhanVienList;
                //Load Doi Tuong No Co
                DoiTuongAllList doituongNoCoList = DoiTuongAllList.GetDoiTuongAllList_Tim("", 0); //_factory.Context.sp_AllDoiTuong(1, 0).Where(x => x.MaCongTy == _maCongTy).ToList();//Lấy đối tác
                DoiTuongAll doituongNCEmpty = DoiTuongAll.NewDoiTuongAll("");//new sp_AllDoiTuong_Result() { MaDoiTuong = 0, TenDoiTuong = "" };
                doituongNoCoList.Insert(0, doituongNCEmpty);
                DoiTuongNoList_BindingSource.DataSource = doituongNoCoList;
                DoiTuongCoList_BindingSource.DataSource = doituongNoCoList;
                //DoiTuongForChungTu_HoaDon
                DoiTuongForChungTuHoaDonBindingSource.DataSource = _DoiTuongThuChiList;
                bindingSource_DoiTuongTim.DataSource = doituongNoCoList;
                _daLoadXong = true;
            }
            catch
            {

            }
        }
        #endregion//DoiTuong

        #region TaiKhoanNganHangCongTy
        private void LoadDataControlLienQuanTheoTaiKhoanNgangHangCongTy(int machitiet)
        {
            if (machitiet != 0)
            {
                ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild tknh = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild.GetTaiKhoanNganHangCongTyChild(machitiet);
                TenNganHangNopVaotextEdit.Text = tknh.TenNganHang;
            }
        }

        private void DesignMaTaiKhoanNHgridLookUpEdit()
        {
            HamDungChung.InitGridLookUpDev2(MaTaiKhoanNHgridLookUpEdit, TKNganHangCongTyList_bindingSource1, "SoTaiKhoan", "MaChiTiet", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(MaTaiKhoanNHgridLookUpEdit, new string[] { "SoTaiKhoan", "TenNganHang" }, new string[] { "Số tài khoản", "Ngân hàng" }, new int[] { 90, 120 }, false);
            MaTaiKhoanNHgridLookUpEdit.EditValueChanged += new System.EventHandler(this.MaTaiKhoanNHgridLookUpEdit_EditValueChanged);
        }
        #endregion TaiKhoanNganHangCongTy

        #region TaiKhoanNganHangDoiTuong
        private void LoadDataControlLienQuanTheoTaiKhoanNgangHangCongTyGiaoDich(int machitiet)
        {
            if (machitiet != 0)
            {
                ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild tknhgiaodich = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild.GetTaiKhoanNganHangCongTyChild(machitiet);
                TenNganHangDentextEdit.Text = tknhgiaodich.TenNganHang;
            }
        }
        private void DesignMaTaiKhoanNHGiaoDichgridLookUpEdit()
        {
            HamDungChung.InitGridLookUpDev2(MaTaiKhoanNHGiaoDichgridLookUpEdit, TKNganHangCongTyGiaoDichbindingSource1, "SoTaiKhoan", "MaChiTiet", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(MaTaiKhoanNHGiaoDichgridLookUpEdit, new string[] { "SoTaiKhoan", "TenNganHang" }, new string[] { "Số tài khoản", "Ngân hàng" }, new int[] { 90, 120 }, false);
            MaTaiKhoanNHGiaoDichgridLookUpEdit.EditValueChanged += new System.EventHandler(this.MaTaiKhoanNHGiaoDichgridLookUpEdit_EditValueChanged);
        }
        #endregion //TaiKhoanNganHangDoiTuong

        #region NhanVien

        private void DesignNhanVien_gridLookUpEdit1()
        {
            HamDungChung.InitGridLookUpDev2(NhanVien_gridLookUpEdit1, NhanVienList_bindingSource, "TenDoiTuong", "MaDoiTuong", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(NhanVien_gridLookUpEdit1, new string[] { "TenDoiTuong", "MaQLDoiTuong", "Email", "TenCongTy" }, new string[] { "Nhân viên", "Mã QL", "Email", "Tên Công Ty" }, new int[] { 120, 90, 90, 120 }, false);
        }

        #endregion//NhanVien    NhanVien_gridLookUpEdit1

        #region tblChungTu_TheoDoi
        private void UpdateChungTu_TheoDoifromChungTu()
        {

        }

        private bool KiemTraSoQuy()
        {
            if (_taoMoiChungTu == false && _LoaiChungTu.MaLoaiCTQuanLy != "PKT" && _ChungTu.KiemTraSoQuy(_ChungTu.MaChungTu) != 0)
            {
                MessageBox.Show(this, "Chứng từ này đã thu chi thực tế, vui lòng liên hệ Thủ Quỹ ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        #endregion//tblChungTu_TheoDoi

        #region Methods Report

        public bool PhieuChi()//[dbo].[spd_ChuoiHachToan], [dbo].[spd_CongNo_PhieuChi]
        {

            int soChungTuKemTheo = 0;
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao spd_ChuoiHachToan
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ChuoiHachToan";
                    cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dataSet);
                    dataSet.Tables[0].TableName = "spd_ChuoiHachToan";
                    dataSet.Tables[1].TableName = "spd_ChuoiTien";

                }
                //tao spd_CongNo_PhieuChi
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_CongNo_PhieuChi";
                    cm.Parameters.AddWithValue("@MaPhieuChi", _ChungTu.MaChungTu);
                    cm.Parameters.AddWithValue("@SoCTKemTheo ", soChungTuKemTheo);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_CongNo_PhieuChi";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }
            }//us 
            return true;
        }

        public bool PhieuKeToan()//[dbo].[spd_BaoCaoChungTuGhiSo] 
        {

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao spd_BaoCaoChungTuGhiSo
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BaoCaoChungTuGhiSo";
                    cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_BaoCaoChungTuGhiSo";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }
            }//us 
            return true;
        }

        public bool Inspd_CongNo_PhieuThu() //Thang
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ChuoiHachToan";
                    cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dataSet);
                    dataSet.Tables[0].TableName = "spd_ChuoiHachToan";
                    dataSet.Tables[1].TableName = "spd_ChuoiTien";

                }
                //tao Inspd_CongNo_PhieuThu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_CongNo_PhieuThu";
                    cm.Parameters.AddWithValue("@MaPhieuThu", _ChungTu.MaChungTu);
                    cm.Parameters.AddWithValue("@SoCTKemTheo", 0);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_CongNo_PhieuThu";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 



                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }
            }//us 
            return true;
        }

        #region Vietcombank
        private void InUNC_Vietcombank()
        {
            ReportTemplate _report;
            //BEGIN
            if (_InmauCoSan)
            {
                _report = ReportTemplate.GetReportTemplate("ID_Report_UNC_VCB_MauCoSan");
            }
            else
            {
                _report = ReportTemplate.GetReportTemplate("ID_Report_UNC_VCB");
            }
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);

                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
                    _reportTemplate.DenNgay = dtDenNgay;
                }

                if (_report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(_reportTemplate, dataSet);
                frm.ShowDialog();
            }
            //END
        }
        public void Method_Report_UNC_VCB()
        {
            ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);

            string SoTienBangChu = HamDungChung.DocTien(_ChungTu.Tien.ThanhTien);
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapBanQuyen
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Report_UyNhiemChi_Modify";
                    cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                    cm.Parameters.AddWithValue("@SoTienBangChu", SoTienBangChu);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_Report_UyNhiemChi";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua Parameters of Report
                DataTable dtParameters = new DataTable();
                dtParameters.Columns.Add("TenBoPhan", typeof(string));
                dtParameters.Columns.Add("TenNguoiLap", typeof(string));
                dtParameters.Columns.Add("TenThuTruong", typeof(string));
                //Add dòng 1
                DataRow dr = dtParameters.NewRow();
                dr["TenBoPhan"] = nguoiky.ThuTruongTen;
                dr["TenNguoiLap"] = ERP_Library.Security.CurrentUser.Info.TenNguoiLap;
                dr["TenThuTruong"] = nguoiky.TenTongGiamDoc;
                dtParameters.Rows.Add(dr);
                dtParameters.TableName = "dtParameters";
                dataSet.Tables.Add(dtParameters);
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

            }//us  
        }
        #endregion//Vietcombank

        #region ACB
        private void InUNC_ACB()
        {
            //BEGIN
            ReportTemplate _report;
            if (_InmauCoSan)
            {
                _report = ReportTemplate.GetReportTemplate("ID_Report_UNC_ACB_MauCoSan");
            }
            else
            {
                _report = ReportTemplate.GetReportTemplate("ID_Report_UNC_ACB");
            }
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);

                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
                    _reportTemplate.DenNgay = dtDenNgay;
                }

                if (_report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(_reportTemplate, dataSet);
                frm.ShowDialog();
            }
            //END
        }
        public void Method_Report_UNC_ACB()
        {
            ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);

            string SoTienBangChu = HamDungChung.DocTien(_ChungTu.Tien.ThanhTien);
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapBanQuyen
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Report_UyNhiemChi_Modify";
                    cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                    cm.Parameters.AddWithValue("@SoTienBangChu", SoTienBangChu);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_Report_UyNhiemChi";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua Parameters of Report
                DataTable dtParameters = new DataTable();
                dtParameters.Columns.Add("TenBoPhan", typeof(string));
                dtParameters.Columns.Add("TenNguoiLap", typeof(string));
                dtParameters.Columns.Add("TenThuTruong", typeof(string));
                //Add dòng 1
                DataRow dr = dtParameters.NewRow();
                dr["TenBoPhan"] = nguoiky.ThuTruongTen;
                dr["TenNguoiLap"] = ERP_Library.Security.CurrentUser.Info.TenNguoiLap;
                dr["TenThuTruong"] = nguoiky.TenTongGiamDoc;
                dtParameters.Rows.Add(dr);
                dtParameters.TableName = "dtParameters";
                dataSet.Tables.Add(dtParameters);
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

            }//us  
        }
        #endregion//ACB

        #region VietinBank
        private void InUNC_VietinBank()
        {
            //BEGIN
            ReportTemplate _report = ReportTemplate.GetReportTemplate("ID_Report_UNC_VietinBank");
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);

                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
                    _reportTemplate.DenNgay = dtDenNgay;
                }

                if (_report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(_reportTemplate, dataSet);
                frm.ShowDialog();
            }
            //END
        }
        public void Method_Report_UNC_VietinBank()
        {
            ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);

            string SoTienBangChu = HamDungChung.DocTien(_ChungTu.Tien.ThanhTien);
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapBanQuyen
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Report_UyNhiemChi_Modify";
                    cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                    cm.Parameters.AddWithValue("@SoTienBangChu", SoTienBangChu);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_Report_UyNhiemChi";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua Parameters of Report
                DataTable dtParameters = new DataTable();
                dtParameters.Columns.Add("TenBoPhan", typeof(string));
                dtParameters.Columns.Add("TenNguoiLap", typeof(string));
                dtParameters.Columns.Add("TenThuTruong", typeof(string));
                //Add dòng 1
                DataRow dr = dtParameters.NewRow();
                dr["TenBoPhan"] = nguoiky.ThuTruongTen;
                dr["TenNguoiLap"] = ERP_Library.Security.CurrentUser.Info.TenNguoiLap;
                dr["TenThuTruong"] = nguoiky.TenTongGiamDoc;
                dtParameters.Rows.Add(dr);
                dtParameters.TableName = "dtParameters";
                dataSet.Tables.Add(dtParameters);
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

            }//us 
        }
        #endregion//VietinBank


        #region Agribank
        private void InUNC_Agribank()
        {
            //BEGIN
            ReportTemplate _report = ReportTemplate.GetReportTemplate("ID_Report_UNC_Agribank");
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);

                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
                    _reportTemplate.DenNgay = dtDenNgay;
                }

                if (_report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(_reportTemplate, dataSet);
                frm.ShowDialog();
            }
            //END
        }
        public void Method_Report_UNC_Agribank()
        {
            ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);

            string SoTienBangChu = HamDungChung.DocTien(_ChungTu.Tien.ThanhTien);
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapBanQuyen
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Report_UyNhiemChi_Modify";
                    cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                    cm.Parameters.AddWithValue("@SoTienBangChu", SoTienBangChu);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_Report_UyNhiemChi";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua Parameters of Report
                DataTable dtParameters = new DataTable();
                dtParameters.Columns.Add("TenBoPhan", typeof(string));
                dtParameters.Columns.Add("TenNguoiLap", typeof(string));
                dtParameters.Columns.Add("TenThuTruong", typeof(string));
                //Add dòng 1
                DataRow dr = dtParameters.NewRow();
                dr["TenBoPhan"] = nguoiky.ThuTruongTen;
                dr["TenNguoiLap"] = ERP_Library.Security.CurrentUser.Info.TenNguoiLap;
                dr["TenThuTruong"] = nguoiky.TenTongGiamDoc;
                dtParameters.Rows.Add(dr);
                dtParameters.TableName = "dtParameters";
                dataSet.Tables.Add(dtParameters);
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

            }//us 
        }
        #endregion//Agribank

        #region BIDV
        private void InUNC_BIDV()
        {
            //BEGIN
            ReportTemplate _report = ReportTemplate.GetReportTemplate("ID_Report_UNC_BIDV");
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);

                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
                    _reportTemplate.DenNgay = dtDenNgay;
                }

                if (_report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(_reportTemplate, dataSet);
                frm.ShowDialog();
            }
            //END
        }
        public void Method_Report_UNC_BIDV()
        {
            ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);

            string SoTienBangChu = HamDungChung.DocTien(_ChungTu.Tien.ThanhTien);
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapBanQuyen
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Report_UyNhiemChi_Modify";
                    cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                    cm.Parameters.AddWithValue("@SoTienBangChu", SoTienBangChu);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_Report_UyNhiemChi";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua Parameters of Report
                DataTable dtParameters = new DataTable();
                dtParameters.Columns.Add("TenBoPhan", typeof(string));
                dtParameters.Columns.Add("TenNguoiLap", typeof(string));
                dtParameters.Columns.Add("TenThuTruong", typeof(string));
                //Add dòng 1
                DataRow dr = dtParameters.NewRow();
                dr["TenBoPhan"] = nguoiky.ThuTruongTen;
                dr["TenNguoiLap"] = ERP_Library.Security.CurrentUser.Info.TenNguoiLap;
                dr["TenThuTruong"] = nguoiky.TenTongGiamDoc;
                dtParameters.Rows.Add(dr);
                dtParameters.TableName = "dtParameters";
                dataSet.Tables.Add(dtParameters);
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

            }//us 
        }
        #endregion//BIDV

        #endregion//Methods Report

        private bool KiemTraLapHoaDonTuBienLaiHopLe(List<ChiTietBienLaiFromOtherDB> chitietbienlailistSelected)
        {
            string maQLDoiTuong = chitietbienlailistSelected[0].MaQLDoiTuong;
            int hinhthucthanhtoan = chitietbienlailistSelected[0].HinhThucThanhToan;
            foreach (ChiTietBienLaiFromOtherDB ctbienlai in chitietbienlailistSelected)
            {
                if (ctbienlai.MaQLDoiTuong != maQLDoiTuong)//Không Cùng Đối Tượng
                {
                    MessageBox.Show("Không cùng đối tượng khi thu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (ctbienlai.HinhThucThanhToan != hinhthucthanhtoan)//Kiem Tra cung Hinh Thuc Thanh Toan
                {
                    MessageBox.Show("Thu theo hình thức thanh toán không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void LoadButToanThue()
        {
            if ((KhoaSoThue())) return;
            _ButToanThue = ButToan.NewButToan();
            foreach (ButToan buttoan in _ChungTu.DinhKhoan.ButToan)
            {
                if (IsTaiKhoanThueKhauTru(buttoan.NoTaiKhoan))
                {
                    _ButToanThue = buttoan;
                    break;
                }
            }
        }

        private void XuLyDoiTuongTheoDoi(ButToan currentButToan)
        {
            HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(currentButToan.NoTaiKhoan);
            HeThongTaiKhoan1 taiKhoanCo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(currentButToan.CoTaiKhoan);

            #region Xu ly Doi Tuong No Co
            //No
            if (taiKhoanNo.MaTaiKhoan != 0)
            {
                currentButToan.DoiTuongNo = 0;
                if (taiKhoanNo.CoDoiTuongTheoDoi == true)
                {
                    currentButToan.DoiTuongNo = _ChungTu.DoiTuong;
                }


            }
            //Co
            if (taiKhoanCo.MaTaiKhoan != 0)
            {
                currentButToan.DoiTuongCo = 0;
                if (taiKhoanCo.CoDoiTuongTheoDoi == true)
                {
                    currentButToan.DoiTuongCo = _ChungTu.DoiTuong;
                }
            }
            #endregion//Xu ly Doi Tuong No Co
        }

        private bool KiemTraButToanThueTruocKhiXoaButToan()
        {
            //Kiem Tra có Chứng Từ Biên Lai - Không Thể Xóa
            if (_ChungTu.CT_ChungTuBienLaiList != null && _ChungTu.CT_ChungTuBienLaiList.Count > 0)
            {
                MessageBox.Show("Chứng từ này được lập từ biên lai, không thể xóa bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            int[] deleteRows = gridView_ButToan.GetSelectedRows();
            foreach (int deleteRow in deleteRows)
            {
                ButToan buttoan = gridView_ButToan.GetRow(deleteRow) as ButToan;
                if (IsTaiKhoanThueKhauTru(buttoan.NoTaiKhoan))
                {
                    if (_ChungTu_HoaDonList.Count() > 0)
                    {
                        MessageBox.Show("Đã có Hóa đơn thuế, không thể xóa bút toán thuế", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (IsTaiKhoanThuePhaiNop(buttoan.CoTaiKhoan))
                {
                    if (PublicClass.KiemTraChungTuDaLapHoaDon(_ChungTu.MaChungTu, buttoan.MaButToan))
                    {
                        MessageBox.Show("Đã lập Hóa đơn bán ra, không thể xóa bút toán thuế", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

            }
            return true;
        }


        private void LoadButToanThuePhaiNop()
        {
            if ((KhoaSoThue())) return;
            _ButToanThuePhaiNop = ButToan.NewButToan();
            foreach (ButToan buttoan in _ChungTu.DinhKhoan.ButToan)
            {
                if (IsTaiKhoanThuePhaiNop(buttoan.CoTaiKhoan))
                {
                    _ButToanThuePhaiNop = buttoan;
                    break;
                }
            }
        }

        private void LapHoaDonBanRa()
        {
            LoadButToanThuePhaiNop();
            if (_ButToanThuePhaiNop.MaButToan == 0)
            {
                MessageBox.Show(this, "Vui lòng hạch toán tài khoản thuế phải nộp!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (PublicClass.KiemTraChungTuDaLapHoaDon(_ChungTu.MaChungTu, _ButToanThuePhaiNop.MaButToan))
            {
                if (MessageBox.Show("Chứng từ đã lập hóa đơn, bạn có muốn xem lại hóa đơn?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HoaDon _HoaDon = HoaDon.NewHoaDon();
                    //_HoaDon = HoaDon.GetHoaDonByButToanThuePhaiNop(_ButToanThuePhaiNop.MaButToan);
                    frmHoaDonDichVuBanRa _frmHoaDonDichVu = new frmHoaDonDichVuBanRa(_HoaDon);
                    _frmHoaDonDichVu.Show();
                }
                else
                {
                    return;
                }
            }
            else
            {
                frmHoaDonDichVuBanRa frm = new frmHoaDonDichVuBanRa(_ButToanThuePhaiNop, _ChungTu.ChungTu_DiaChi.Ten, _ChungTu.Tien.ThanhTien, _ChungTu.MaPhuongThucThanhToan);
                frm.ShowDialog();
            }
        }

        private void TinhSoTienChungTu()
        {
            decimal sotienTong = 0;
            decimal soTienNgoaiTe = 0;
            foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
            {
                sotienTong += bt.SoTien;
                soTienNgoaiTe += bt.SoTienNgoaiTe;
            }
            _ChungTu.Tien.SoTien = soTienNgoaiTe;
            _ChungTu.Tien.ThanhTien = sotienTong;
            TienTe_bindingSource.DataSource = _ChungTu.Tien;
        }

        private void XuLyTruocKhiLuu()
        {
            for (int i = 0; i < gridView_ButToan.RowCount; i++)
            {
                int currentRowHandle = gridView_ButToan.GetVisibleRowHandle(i);
                object obj = gridView_ButToan.GetRow(currentRowHandle);
                decimal sotien;
                bool hople = true;
                if (obj != null && decimal.TryParse(((ButToan)obj).SoTien.ToString(), out sotien))
                {
                    if (sotien == 0)
                    {
                        hople = false;
                    }
                }
                else hople = true;
                if (hople == false)
                {
                    ButToan butToan = (ButToan)gridView_ButToan.GetRow(currentRowHandle);
                    gridView_ButToan.DeleteRow(currentRowHandle);
                    i -= 1;
                }
            }
            //if (_taoMoiChungTu) _ChungTu.GhiSoCai = true;

        }

        private void inUyNhiemChi(string UNCNganHang)
        {
            if (_ChungTu.IsNew == false)
            {
                ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);
                //Kiểm tra UNC Đang chọn có đúng với ngân hàng cần in không
                int iMaNganHang; //Convert.ToInt32(grdData.Selected.Rows[0].Cells["MaNganHang"].Value);
                iMaNganHang = CongTy_NganHang.GetCongTy_NganHang(_ChungTu.BoSungChungTuKT.MaTaiKhoanNH).MaNganHang;
                long lNhomNganHang = NganHang.GetNganHang(iMaNganHang).MaNhomNganHang;
                string strTenNganHang = NhomNganHang.GetNhomNganHang(lNhomNganHang).TenNhomNganHang;
                string strUNCNganHang = UNCNganHang.Replace("A4", "");//Mốt có A khác nữa nhớ bỏ thêm vô loại trừ hết lấy chữ Eximbank thôi
                strUNCNganHang = UNCNganHang.Replace("New", "");//Mốt có A khác nữa nhớ bỏ thêm vô loại trừ hết lấy chữ Eximbank thôi
                bool bTrung = strTenNganHang.ToUpper().Contains(strUNCNganHang.Trim().ToUpper());
                if (!bTrung)
                {
                    MessageBox.Show(this, "Mẫu in Ủy Nhiệm Chi không cùng thông tin ngân hàng của Ủy Nhiệm Chi đang chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                switch (UNCNganHang)
                {
                    case "VietinBank":
                        InUNC_VietinBank();
                        break;
                    case "Vietcombank":
                        InUNC_Vietcombank();
                        break;
                    case "ACB":
                        InUNC_ACB();
                        break;
                    case "Agribank":
                        InUNC_Agribank();
                        break;
                    case "BIDV":
                        InUNC_BIDV();
                        break;

                }
            }
        }

        #endregion Functions

        #region Initialize

        public FrmChungTuChuyenTienNoiBo(ChungTuCustomize chungtuCus)
        {
            InitializeComponent();
            _LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDevByMaQuanLy(chungtuCus.MaLoaiChungTuQL);
            _taoMoiChungTu = false;
            FormatForm();
            KhoiTao();
            LoadDaTa();
            ChungTuList ct = ChungTuList.GetChungTuListByMaChungTu_New(chungtuCus.Id);
            _ChungTu = ct[0];
            _maChungTuGhiTangCuCanXemLai = _ChungTu.MaChungTu;
            if (_ChungTu.MaChungTu != 0)
            {
                _LoaiChungTu = _ChungTu.LoaiChungTu;
                _ngayLapCu = _ChungTu.NgayLap.Year > 1900 ? _ChungTu.NgayLap : _ChungTu.NgayThucHien;
                GanBindingSource();
                dtmp_Ngay.EditValue = _ChungTu.NgayThucHien;
                //dtmp_Ngay.EditValue = _ChungTu.NgayLap;
                //LoadDataAfterInitChungTu();
                this.LoadDoiTuongList();
                if (_LoaiChungTu.MaLoaiCTQuanLy == "PKT" || _LoaiChungTu.MaLoaiCTQuanLy == "PT111" || _LoaiChungTu.MaLoaiCTQuanLy == "PC112")//Bang Ke or PhieThu
                    TaoBindingDeNghiChuyenKhoan();

                GanDuLieuChoTextDoiTac();
                soChungTu = _ChungTu.MaChungTu;
                btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                TongTien = _ChungTu.Tien.ThanhTien;
                soTien = _ChungTu.Tien.SoTien;
            }
            btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        public FrmChungTuChuyenTienNoiBo()
        {
            InitializeComponent();
        }

        public FrmChungTuChuyenTienNoiBo(ChungTu chungTu)
        {
            _LoaiChungTu = chungTu.LoaiChungTu;
            InitializeComponent();
            //xtraTabPage2.PageVisible = false;//Ẩn Tab Danh Sách Chứng Từ
            _taoMoiChungTu = false;
            _maChungTuGhiTangCuCanXemLai = chungTu.MaChungTu;
            KhoiTao();
            LoadDaTa();
            btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        //====goi tu report hoac form khac
        public FrmChungTuChuyenTienNoiBo(long maChungTu)
        {
            InitializeComponent();

            ChungTuList ct = ChungTuList.GetChungTuListByMaChungTu_New(maChungTu);
            if (ct.Count > 0)
            {
                this._ChungTu = ct[0];
            }
            if (this._ChungTu.MaChungTu == 0) return;

            if (_ChungTu.NgayLap.Year > 1900)
            {
                dtmp_Ngay.EditValue = _ChungTu.NgayLap;
            }
            else
            {
                dtmp_Ngay.EditValue = null;
            }

            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);

            _ngayLapCu = _ChungTu.NgayLap.Year > 1900 ? _ChungTu.NgayLap : _ChungTu.NgayThucHien;
            _LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDevByMaQuanLy("CTNB");
            _taoMoiChungTu = false;
            _maChungTuGhiTangCuCanXemLai = _ChungTu.MaChungTu;
            TongTien = _ChungTu.Tien.ThanhTien;
            soTien = _ChungTu.Tien.SoTien;
            KhoiTao();
            LoadDaTa();
            LoadDoiTuongList();
            btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            FormatForm();
            GanBindingSource();
        }

        public void ShowBangKe()
        {
            //_maLoaiChungTu = 16;//Bảng kê
            _LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDevByMaQuanLy("PKT");
            FormatForm();
            _taoMoiChungTu = true;
            KhoiTao();
            LoadDaTa();
            this.Show();
        }

        public void ShowPhieuThu()
        {
            //_maLoaiChungTu = 2;//Phiếu Thu
            _LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDevByMaQuanLy("PT111");
            FormatForm();
            _taoMoiChungTu = true;
            KhoiTao();
            LoadDaTa();
            this.Show();
        }

        public void ShowPhieuChi()
        {
            //_maLoaiChungTu = 3;//Phiếu Chi
            _LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDevByMaQuanLy("PC111");
            FormatForm();
            _taoMoiChungTu = true;
            KhoiTao();
            LoadDaTa();
            this.Show();
        }

        public void ShowPhieuThuTienGui()
        {
            //_maLoaiChungTu = 20;//Phiếu Thu Tiền gửi
            _LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDevByMaQuanLy("PT112");
            FormatForm();
            _taoMoiChungTu = true;
            KhoiTao();
            LoadDaTa();
            this.Show();
        }

        public void ShowPhieuChiTienGui()
        {
            //_maLoaiChungTu = 21;//Phiếu Chi Tiền Gửi
            _LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDevByMaQuanLy("PC112");
            FormatForm();
            _taoMoiChungTu = true;
            KhoiTao();
            LoadDaTa();
            this.Show();
        }

        public void ShowChuyenTienNoiBo()
        {
            _LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDevByMaQuanLy("CTNB");
            FormatForm();
            _taoMoiChungTu = true;
            KhoiTao();
            LoadDaTa();
            this.Show();
        }

        #endregion Initialize

        #region EventHandles
        #region gridView_ButToan

        private void gridView_ButToan_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            EventRowOrColumnGrdView_DinhKhoanChange(e.RowHandle);
            clickButtoan = true;
            //if (gridView_ButToan.IsNewItemRow(e.RowHandle))
            //{
            //    if (gridView_ButToan.GetRow(e.RowHandle) == null)
            //        gridView_ButToan.AddNewRow();
            //}
            AddNewRowhandleGridviewButToan(e.RowHandle);

            handlefocus = true;
        }

        private void gridView_ButToan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (_isCellValuechangeBT == false) return;
            ButToan currentButToan = (ButToan)tblButToanBindingSource.Current;
            if (currentButToan != null && gridView_ButToan.FocusedColumn.Name == "colNoTaiKhoan" || gridView_ButToan.FocusedColumn.Name == "colCoTaiKhoan")
            {
                #region BS Kiem Tra Khoa So TaiKhoan
                //
                if (currentButToan.IsNew == true)
                {
                    if (KhoaButToanTheoTaiKhoan(currentButToan.NoTaiKhoan))
                    {
                        _isCellValuechangeBT = false;
                        MessageBox.Show(this, "Đã khóa sổ tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        currentButToan.NoTaiKhoan = 0;
                        _isCellValuechangeBT = true;
                    }
                    if (KhoaButToanTheoTaiKhoan(currentButToan.CoTaiKhoan))
                    {
                        _isCellValuechangeBT = false;
                        MessageBox.Show(this, "Đã khóa sổ tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        currentButToan.CoTaiKhoan = 0;
                        _isCellValuechangeBT = true;
                    }
                }
                // 
                #endregion//BS Kiem Tra Khoa So TaiKhoan

                XuLyDoiTuongTheoDoi(currentButToan);
                //HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
                //HeThongTaiKhoan1 taiKhoanCo = HeThongTaiKhoan1.NewHeThongTaiKhoan1();


                ////Xu Ly Dien Giai
                //if (NocoThue || CocoThue)
                //{
                //    currentButToan.DienGiai = "Thuế GTGT Được Khấu Trừ Của Hàng Hóa, Dịch Vụ";
                //}
                #region Xu ly Doi Tuong No Co
                ////Xu ly Doi Tuong No Co
                //if (taiKhoanNo.MaTaiKhoan != 0)
                //{
                //    currentButToan.DoiTuongNo = 0;
                //    if (taiKhoanNo.CoDoiTuongTheoDoi == true)
                //    {
                //        loadDoiTuongNoTheoTaiKhoan(currentButToan.NoTaiKhoan);
                //        if (KiemTraDoiTuongNoTrongDoiTuongTheoDoi(_ChungTu.DoiTuong))
                //        {
                //            currentButToan.DoiTuongNo = _ChungTu.DoiTuong;
                //        }
                //    }
                //    else
                //    {
                //        _DoiTuongNoList = DoiTuongAllList.NewDoiTuongAllList(); //_DoiTuongThuChiList;
                //        DoiTuongNoList_BindingSource.DataSource = _DoiTuongNoList;
                //    }


                //}

                //if (taiKhoanCo.MaTaiKhoan != 0)
                //{
                //    currentButToan.DoiTuongCo = 0;
                //    if (taiKhoanCo.CoDoiTuongTheoDoi == true)
                //    {
                //        loadDoiTuongCoTheoTaiKhoan(currentButToan.CoTaiKhoan);
                //        if (KiemTraDoiTuongCoTrongDoiTuongTheoDoi(_ChungTu.DoiTuong))
                //        {
                //            currentButToan.DoiTuongCo = _ChungTu.DoiTuong;
                //        }
                //    }
                //    else
                //    {
                //        _DoiTuongCoList = DoiTuongAllList.NewDoiTuongAllList(); ;//_DoiTuongThuChiList;
                //        DoiTuongCoList_BindingSource.DataSource = _DoiTuongCoList;//_DoiTuongCoList;
                //    }
                //}
                #endregion//Xu ly Doi Tuong No Co

                #region Tạm ứng
                //if (gridView_ButToan.FocusedColumn.Name == "colNoTaiKhoan")
                //{
                //    if (currentButToan != null && currentButToan.NoTaiKhoan != 0)
                //    {
                //        LoadFormTamUng(currentButToan.NoTaiKhoan);
                //    }
                //}
                //else if (gridView_ButToan.FocusedColumn.Name == "colCoTaiKhoan")
                //{
                //    if (currentButToan.CoTaiKhoan != 0)
                //    {
                //        LoadFormTamUng(currentButToan.CoTaiKhoan);
                //    }
                //}
                #endregion Hết tạm ứng
            }
            else if (currentButToan != null && gridView_ButToan.FocusedColumn.FieldName == "SoTien")
            {
                TinhSoTienChungTu();
            }
            else if (currentButToan != null && gridView_ButToan.FocusedColumn.FieldName == "SoTienNgoaiTe")
            {
                currentButToan.SoTien = Math.Round(currentButToan.SoTienNgoaiTe * _ChungTu.Tien.TiGiaQuyDoi, 0, MidpointRounding.AwayFromZero);
                TinhSoTienChungTu();
            }
        }

        bool isXoaDongButToan = false;
        private void DeleteButToanList()
        {
            if (KiemTraButToanThueTruocKhiXoaButToan() == false) return;
            if (gridView_ButToan.RowCount > 0)
            {
                if (gridView_ButToan.GetSelectedRows().Length > 0)
                {
                    if (MessageBox.Show(String.Format("Bạn có muốn xóa {0} dòng được chọn không?", gridView_ButToan.GetSelectedRows().Length), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        isXoaDongButToan = true;
                        gridView_ButToan.DeleteSelectedRows();
                        TinhSoTienChungTu();
                    }
                }
            }
        }
        private void gridView_ButToan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteButToanList();
            }

        }

        private void gridView_ButToan_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            #region Modify Method
            #region New
            ButToan buttoan = this.gridView_ButToan.GetRow(e.RowHandle) as ButToan;
            if (buttoan != null)
            {
                SetTaiKhoanDefaultForNewFirstButtoan(buttoan);
                buttoan.DienGiai = txt_DienGiai.EditValue.ToString();
            }
            //gridView_ButToan.UpdateCurrentRow();
            #endregion//New

            #endregion//Modify Method

            #region Old Method
            //decimal sotien = Convert.ToDecimal(calcEdit_ThanhTien.EditValue);


            //#region New
            //ButToan buttoan = this.gridView_ButToan.GetRow(e.RowHandle) as ButToan;
            //if (buttoan != null)
            //{
            //    foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
            //    {

            //        if (sotien != bt.SoTien)
            //            sotien -= bt.SoTien;
            //        else if (sotien == bt.SoTien)
            //            sotien = 0;
            //    }
            //    #region Modify
            //    if (sotien != 0)
            //    {
            //        SetTaiKhoanDefaultForNewFirstButtoan(buttoan);
            //        buttoan.SoTien = sotien;
            //        buttoan.DienGiai = txt_DienGiai.EditValue.ToString();
            //    }
            //    #endregion//Modify
            //    #region Old
            //    //if (_ChungTu.DinhKhoan.ButToan.Count > 1 && sotien != 0)
            //    //{
            //    //    ButToan previousBt = _ChungTu.DinhKhoan.ButToan.LastOrDefault();
            //    //    buttoan.NoTaiKhoan = previousBt.NoTaiKhoan;
            //    //    buttoan.CoTaiKhoan = previousBt.CoTaiKhoan;
            //    //    buttoan.SoTien = sotien;
            //    //    buttoan.DoiTuongCo = previousBt.DoiTuongCo;
            //    //    buttoan.DoiTuongNo = previousBt.DoiTuongNo;
            //    //    buttoan.DienGiai = previousBt.DienGiai;
            //    //    buttoan.MaHopDong = previousBt.MaHopDong;
            //    //}
            //    //else if (sotien != 0)
            //    //{
            //    //    SetTaiKhoanDefaultForNewFirstButtoan(buttoan);
            //    //    buttoan.SoTien = sotien;
            //    //    buttoan.DienGiai = txt_DienGiai.EditValue.ToString();
            //    //} 
            //    #endregion //Old


            //}
            ////gridView_ButToan.UpdateCurrentRow();
            //#endregion//New

            //#region Old
            ////tblButToan buttoan = tblButToanBindingSource.Current as tblButToan;
            ////if (gridView_ButToan.RowCount == 0)
            ////{
            ////    SetTaiKhoanDefaultForNewFirstButtoan();
            ////    buttoan.SoTien = sotien;
            ////    buttoan.DienGiai = txt_DienGiai.EditValue.ToString();
            ////}
            ////else
            ////{
            ////    foreach (tblButToan bt in _ChungTu.tblDinhKhoan.tblButToans)
            ////    {

            ////        if (sotien != bt.SoTien)
            ////            sotien -= bt.SoTien;
            ////        else if (sotien == bt.SoTien)
            ////            sotien = 0;
            ////    }
            ////    if (buttoan != null)
            ////    {
            ////        buttoan.SoTien = sotien;
            ////        buttoan.DienGiai = txt_DienGiai.EditValue.ToString();
            ////    }
            ////}
            //#endregion//Old

            #endregion//Old Method
        }

        private void gridView_ButToan_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //if (gridView_ButToan.IsNewItemRow(e.RowHandle))
            //{
            //    if (gridView_ButToan.GetRow(e.RowHandle) == null)
            //        gridView_ButToan.AddNewRow();
            //}
            AddNewRowhandleGridviewButToan(e.RowHandle);
        }

        private void gridView_ButToan_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (clickButtoan)
            {
                if (e.FocusedColumn.FieldName == "NoTaiKhoan"
                    || e.FocusedColumn.FieldName == "CoTaiKhoan"
                    || e.FocusedColumn.FieldName == "DoiTuongNo"
                    || e.FocusedColumn.FieldName == "DoiTuongCo"
                    || e.FocusedColumn.FieldName == "MaHopDong"
                    )
                {
                    if (
                            (
                                e.FocusedColumn.FieldName == "NoTaiKhoan"
                                || e.FocusedColumn.FieldName == "CoTaiKhoan"
                            )
                            && KiemTraCoTKTamUng()
                        )
                    {
                        return;
                    }
                    else
                    {
                        if (handlefocus && gridView_ButToan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit == true)
                        {
                            gridView_ButToan.ShowEditor();
                            ((GridLookUpEdit)gridView_ButToan.ActiveEditor).ShowPopup();
                        }
                    }
                }
            }
            handlefocus = true;
        }

        private void grdView_DinhKhoan_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            EventRowOrColumnGrdView_DinhKhoanChange(e.FocusedRowHandle);
        }

        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            #region Modify Method
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (KiemTraCoTKTamUng())
            //    {
            //        PSC_ERP.frmTamUng_Dev _frmTamUng = new PSC_ERP.frmTamUng_Dev(_ChungTu);
            //        _frmTamUng.Show(this);
            //    }
            //    //else
            //    //{
            //    //    gridView_ButToan.PostEditor();
            //    //    gridView_ButToan.UpdateCurrentRow();
            //    //    handlefocus = false;//
            //    //    gridView_ButToan.FocusedColumn = gridView_ButToan.VisibleColumns[0];

            //    //    if (gridView_ButToan.RowCount > 0)
            //    //    {
            //    //        gridView_ButToan.AddNewRow();
            //    //    }
            //    //}//End Else


            //}
            #endregion//Modify Method
        }

        //Them
        private void grd_DinhKhoan_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (gridView_ButToan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit == false)
                e.Handled = true;
        }

        //Them
        private void grd_DinhKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (gridView_ButToan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit == false)
                e.Handled = true;
        }
        #endregion//gridView_ButToan

        #region gridView_DSDeNghi
        private void gridView_DSDeNghi_KeyDown(object sender, KeyEventArgs e)
        {
            HamDungChung.DeleteSelectedRowsGridViewDev(gridView_DSDeNghi, e);

        }
        #endregion//gridView_DSDeNghi

        #region ChungTu_HoaDon

        private void DeleteChungTu_HoaDonList()
        {
            if (ChungTu_HoaDongridView.RowCount > 0)
            {
                if (ChungTu_HoaDongridView.GetSelectedRows().Length > 0)
                {
                    if (MessageBox.Show(String.Format("Bạn có muốn xóa {0} dòng được chọn không?", ChungTu_HoaDongridView.GetSelectedRows().Length), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ChungTu_HoaDongridView.DeleteSelectedRows();
                    }
                }
            }
        }

        private void ChungTu_HoaDongridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (CheckCoTaiKhoanBiKhoaTrongButToan())
                {
                    MessageBox.Show(this, "Đã khóa sổ tài khoản, không thể thực hiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DeleteChungTu_HoaDonList();
            }
        }

        private void ChungTu_HoaDongridView_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            LoadButToanThue();
            if (IsTaiKhoanThueKhauTru(_ButToanThue.NoTaiKhoan) == false)
            {
                MessageBox.Show(this, "Vui lòng chọn tài khoản thuế!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GridView view = sender as GridView;
                BeginInvoke(new MethodInvoker(view.CancelUpdateCurrentRow));
            }
            else if (_ButToanThue.SoTien == 0)
            {
                MessageBox.Show(this, "Vui lòng nhập số tiền của bút toán!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GridView view = sender as GridView;
                BeginInvoke(new MethodInvoker(view.CancelUpdateCurrentRow));
            }
            else
            {
                ChungTu_HoaDon currentCT_HD = (ChungTu_HoaDon)ChungTuHoaDon_bindingSource.Current;
                currentCT_HD.HoaDon.MaDoiTac = _ChungTu.DoiTuong;
                //"HoaDon.ThanhTien", "HoaDon.ThueSuatVAT", "HoaDon.ThueVAT"
                currentCT_HD.HoaDon.ThanhTien = _ChungTu.Tien.ThanhTien - _ButToanThue.SoTien;
                if (_ButToanThue.SoTien > 0)
                {
                    double thuesuat = 0;
                    thuesuat = (double)((_ChungTu.Tien.ThanhTien - _ButToanThue.SoTien) / _ButToanThue.SoTien);
                    if (thuesuat < 3)
                    {
                        currentCT_HD.HoaDon.ThueSuatVAT = 0;
                    }
                    else if (thuesuat < 8)
                    {
                        currentCT_HD.HoaDon.ThueSuatVAT = 5;
                    }
                    else
                    {
                        currentCT_HD.HoaDon.ThueSuatVAT = 10;
                    }
                    //currentCT_HD.HoaDon.ThueSuatVAT = (double)((_ChungTu.Tien.ThanhTien - _ButToanThue.SoTien) / _ButToanThue.SoTien);
                }
            }
            #region Can Xem Lai phan Hoa Don
            //#region MyRegion
            ////if (CheckCoTaiKhoanThueTrongButToan() == 0)
            ////{
            ////    MessageBox.Show(this, "Vui lòng chọn tài khoản thuế 3113 hay 3337....", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ////    return;
            ////}
            ////else if (CheckCoTaiKhoanBiKhoaTrongButToan())
            ////{
            ////    MessageBox.Show(this, "Đã khóa sổ tài khoản, không thể thực hiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ////    return;
            ////}
            ////else if (CheckCoTaiKhoanThueTrongButToan() == 1)
            ////{
            ////    ChungTu chungtuforHD = ChungTu.NewChungTu();
            ////    chungtuforHD.SoChungTu = _ChungTu.SoChungTu;
            ////    chungtuforHD.NgayLap = _ChungTu.NgayLap;
            ////    chungtuforHD.SoTien = _ChungTu.SoTien;

            ////    foreach (ButToan tblbt in _ChungTu.ButToanList)
            ////    {
            ////        if (IsTaiKhoanThue(tblbt.NoTaiKhoan))
            ////        {
            ////            ButToan buttoan = ButToan.NewButToan(tblbt.NoTaiKhoan.Value, tblbt.CoTaiKhoan.Value, tblbt.SoTien, tblbt.DienGiai, tblbt.MaDoiTuongNo.Value, tblbt.MaDoiTuongCo.Value);
            ////            foreach (tblChungTu_HoaDon cthd in tblbt.tblChungTu_HoaDon)
            ////            {
            ////                ChungTu_HoaDon chungtuHoaDon = ChungTu_HoaDon.NewChungTu_HoaDon();
            ////                chungtuHoaDon.MaHoaDon = cthd.MaHoaDon;
            ////                chungtuHoaDon.MaPhieuNhapXuat = cthd.MaPhieuNhapXuat.Value;
            ////                chungtuHoaDon.SoTien = cthd.SoTien;
            ////                chungtuHoaDon.NgayLap = cthd.NgayLap.Value;
            ////                buttoan.ChungTu_HoaDonList.Add(chungtuHoaDon);
            ////            }
            ////            chungtuforHD.DinhKhoan.ButToan.Add(buttoan);
            ////            frmDanhSachHoaDonDichVu frm = new frmDanhSachHoaDonDichVu(chungtuforHD, buttoan, true);
            ////            if (frm.ShowDialog() != DialogResult.OK)
            ////            {
            ////                if (frm.Luu)
            ////                {
            ////                    TaoChungTuHoaDonForButToan(frm._bt.ChungTu_HoaDonList, tblbt);
            ////                }
            ////            }
            ////            //frm.ShowDialog();
            ////        }
            ////    }

            ////}
            ////else if (CheckCoTaiKhoanThueTrongButToan() == 2)
            ////{
            ////    ChungTu chungtuforHD = ChungTu.NewChungTu();
            ////    chungtuforHD.SoChungTu = _ChungTu.SoChungTu;
            ////    chungtuforHD.NgayLap = _ChungTu.NgayLap.Value;
            ////    chungtuforHD.SoTien = _ChungTu.SoTien;

            ////    foreach (tblButToan tblbt in _ChungTu.tblDinhKhoan.tblButToans)
            ////    {
            ////        if (IsTaiKhoanThue(tblbt.NoTaiKhoan) || IsTaiKhoanThue(tblbt.CoTaiKhoan))
            ////        {
            ////            ButToan buttoan = ButToan.NewButToan(tblbt.NoTaiKhoan.Value, tblbt.CoTaiKhoan.Value, tblbt.SoTien, tblbt.DienGiai, tblbt.MaDoiTuongNo.Value, tblbt.MaDoiTuongCo.Value);
            ////            foreach (tblChungTu_HoaDon cthd in tblbt.tblChungTu_HoaDon)
            ////            {
            ////                ChungTu_HoaDon chungtuHoaDon = ChungTu_HoaDon.NewChungTu_HoaDon();
            ////                chungtuHoaDon.MaHoaDon = cthd.MaHoaDon;
            ////                chungtuHoaDon.MaPhieuNhapXuat = cthd.MaPhieuNhapXuat.Value;
            ////                chungtuHoaDon.SoTien = cthd.SoTien;
            ////                chungtuHoaDon.NgayLap = cthd.NgayLap.Value;
            ////                buttoan.ChungTu_HoaDonList.Add(chungtuHoaDon);
            ////            }
            ////            chungtuforHD.DinhKhoan.ButToan.Add(buttoan);
            ////            frmDanhSachHoaDonDichVu frm = new frmDanhSachHoaDonDichVu(chungtuforHD, buttoan.ChungTu_HoaDonList, buttoan, true, true);
            ////            if (frm.ShowDialog() != DialogResult.OK)
            ////            {
            ////                if (frm.Luu)
            ////                {
            ////                    TaoChungTuHoaDonForButToan(frm._bt.ChungTu_HoaDonList, tblbt);
            ////                }
            ////            }
            ////            //frm.ShowDialog();
            ////        }
            ////    }
            ////} 
            //#endregion

            ////frmDanhSachHoaDonDichVu frm = new frmDanhSachHoaDonDichVu(chungtuforHD, buttoan.ChungTu_HoaDonList, buttoan, true, true);
            //frmDanhSachHoaDonDichVu frm = new frmDanhSachHoaDonDichVu(_ChungTu, _ChungTu.ChungTu_HoaDonList, true);
            //if (frm.ShowDialog() != DialogResult.OK)
            //{
            //    if (frm.Luu)
            //    {
            //        TaoChungTuHoaDonForButToan(frm._bt.ChungTu_HoaDonList);
            //    }
            //} 
            #endregion//Can Xem Lai phan Hoa Don

        }
        #endregion//ChungTu_HoaDon


        #region MaTaiKhoanNHgridLookUpEdit
        private void MaTaiKhoanNHgridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (MaTaiKhoanNHgridLookUpEdit.EditValue != null)
            {
                int machitietOut;
                if (int.TryParse(MaTaiKhoanNHgridLookUpEdit.EditValue.ToString(), out machitietOut))
                {
                    LoadDataControlLienQuanTheoTaiKhoanNgangHangCongTy(machitietOut);
                }
            }
        }
        #endregion//MaTaiKhoanNHgridLookUpEdit

        #region MaTaiKhoanNHGiaoDichgridLookUpEdit
        private void MaTaiKhoanNHGiaoDichgridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (MaTaiKhoanNHGiaoDichgridLookUpEdit.EditValue != null)
            {
                int machitietOut;
                if (int.TryParse(MaTaiKhoanNHGiaoDichgridLookUpEdit.EditValue.ToString(), out machitietOut))
                {
                    LoadDataControlLienQuanTheoTaiKhoanNgangHangCongTyGiaoDich(machitietOut);
                }
            }
        }
        #endregion //MaTaiKhoanNHGiaoDichgridLookUpEdit



        #region HoatDong_gridLookUpEdit1
        private void HoatDong_gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //if (DoiTuongGridLookUpEdit.EditValue != null)
            //{
            //    int madoituongOut;
            //    if (int.TryParse(DoiTuongGridLookUpEdit.EditValue.ToString(), out madoituongOut))
            //    {

            //    }
            //}
        }
        #endregion//HoatDong_gridLookUpEdit1


        #endregion EventHandles

        #region Events
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.strStatus = "THEM";
            this.ReadOnlyConTrolByStatus(this.strStatus);

            _lapChungTuBienLai = false;
            KhoiTaoChungTuMoi();
            _taoMoiChungTu = true;//           
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textBoxFocus1.Focus();
            if (_taoMoiChungTu == false && _LoaiChungTu.MaLoaiCTQuanLy != "PKT" && KiemTraSoQuy() == false)
            {
                return;
            }
            if (_taoMoiChungTu == true && CheckCoTaiKhoanBiKhoaTrongButToan())
            {
                MessageBox.Show(this, "Đã khóa sổ tài khoản, không thể lưu ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.Save())
            {
                btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                this.strStatus = "KHOA";
                this.ReadOnlyConTrolByStatus(this.strStatus);
            }
        }

        #region InDVKhoanChiTheoMauCu_BangKe
        //private void InDVKhoanChiTheoMauCu_BangKe(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    frmXemIn f = new frmXemIn();


        //    Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;

        //    rpt.ReportEmbeddedResource = "PSC_ERP.Report.CongNo.rpBangKe.rdlc";
        //    BangKeList bangkelist = ERP_Library.BangKeList.GetBangKeList(_ChungTu.MaChungTu);

        //    rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_BangKeList", bangkelist));

        //    f.SetParameter("TenBoPhan", BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);

        //    f.SetParameter("TieuDeReport", "PHIẾU KẾ TOÁN ");
        //    ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);

        //    //string ngay ="";// "Tp.HCM, Ngày " + _ChungTu.NgayLap.Day+ " tháng " + _ChungTu.NgayLap.Month.ToString() + " năm " + _ChungTu.NgayLap.Year.ToString();
        //    //f.SetParameter("Ngay", ngay);
        //    if (ERP_Library.Security.CurrentUser.Info.MaCongTy != 1)
        //    {
        //        f.SetNguoiKyTongHopBangKe(2, _ChungTu.NgayLap);
        //    }
        //    else if (ERP_Library.Security.CurrentUser.Info.MaCongTy == 1 & ERP_Library.Security.CurrentUser.Info.MaBoPhan != 9)
        //    {
        //        f.SetNguoiKyTongHopBangKe(10, _ChungTu.NgayLap);
        //    }
        //    else
        //    {
        //        f.SetNguoiKyTongHop(3);
        //    }

        //    f.Show(this);
        //    return;
        //}
        #endregion//InDVKhoanChiTheoMauCu_BangKe

        private void btnPrintA4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region Devexpress
            if (_LoaiChungTu.MaLoaiCTQuanLy == "PKT")//Bảng Kê
            {
                ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuKeToanA4");//PhieuNhapVatTu//
                if (_report != null)
                {
                    DateTime dtDenNgay = DateTime.Today;
                    frmReport frm = new frmReport();

                    ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
                    if (_reportTemplate.Id == string.Empty)
                    {
                        _reportTemplate.Id = _report.Id;
                        _reportTemplate.UserID = UserId;
                        _reportTemplate.DenNgay = dtDenNgay;
                    }
                    if (_report.TenPhuongThuc != "")
                    {
                        this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                    }

                    frm.HienThiReport(_reportTemplate, dataSet);
                    frm.Show();
                }
            }
            else if (_LoaiChungTu.MaLoaiCTQuanLy == "PT111" || _LoaiChungTu.MaLoaiCTQuanLy == "PT112")//Phiếu Thu
            {
                ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuThuA4_2");//PhieuNhapVatTu//
                if (_report != null)
                {
                    DateTime dtDenNgay = DateTime.Today;
                    frmReport frm = new frmReport();

                    ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
                    if (_reportTemplate.Id == string.Empty)
                    {
                        _reportTemplate.Id = _report.Id;
                        _reportTemplate.UserID = UserId;
                        _reportTemplate.DenNgay = dtDenNgay;
                    }
                    if (_report.TenPhuongThuc != "")
                    {
                        this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                    }

                    frm.HienThiReport(_reportTemplate, dataSet);
                    frm.Show();
                }
            }
            else if (_LoaiChungTu.MaLoaiCTQuanLy == "PC111" || _LoaiChungTu.MaLoaiCTQuanLy == "PC112")//Phiếu Chi
            {
                ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuChi1A4");//PhieuNhapVatTu//
                if (_report != null)
                {
                    DateTime dtDenNgay = DateTime.Today;
                    frmReport frm = new frmReport();

                    ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
                    if (_reportTemplate.Id == string.Empty)
                    {
                        _reportTemplate.Id = _report.Id;
                        _reportTemplate.UserID = UserId;
                        _reportTemplate.DenNgay = dtDenNgay;
                    }
                    if (_report.TenPhuongThuc != "")
                    {
                        this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                    }

                    frm.HienThiReport(_reportTemplate, dataSet);
                    frm.Show();
                }
            }
            #endregion//Devexpress
        }

        private void btnPrintA5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            #region Devexpress
            if (_LoaiChungTu.MaLoaiCTQuanLy == "PKT")//Bảng Kê
            {
                ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuKeToanA5");//PhieuNhapVatTu//
                if (_report != null)
                {
                    DateTime dtDenNgay = DateTime.Today;
                    frmReport frm = new frmReport();

                    ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
                    if (_reportTemplate.Id == string.Empty)
                    {
                        _reportTemplate.Id = _report.Id;
                        _reportTemplate.UserID = UserId;
                        _reportTemplate.DenNgay = dtDenNgay;
                    }
                    if (_report.TenPhuongThuc != "")
                    {
                        this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                    }

                    frm.HienThiReport(_reportTemplate, dataSet);
                    frm.Show();
                }
            }
            else if (_LoaiChungTu.MaLoaiCTQuanLy == "PT111" || _LoaiChungTu.MaLoaiCTQuanLy == "PT112")//Phiếu Thu
            {
                ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuThuA5_2");//PhieuNhapVatTu//
                if (_report != null)
                {
                    DateTime dtDenNgay = DateTime.Today;
                    frmReport frm = new frmReport();

                    ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
                    if (_reportTemplate.Id == string.Empty)
                    {
                        _reportTemplate.Id = _report.Id;
                        _reportTemplate.UserID = UserId;
                        _reportTemplate.DenNgay = dtDenNgay;
                    }
                    if (_report.TenPhuongThuc != "")
                    {
                        this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                    }

                    frm.HienThiReport(_reportTemplate, dataSet);
                    frm.Show();
                }
            }
            else if (_LoaiChungTu.MaLoaiCTQuanLy == "PC111" || _LoaiChungTu.MaLoaiCTQuanLy == "PC112")//Phiếu Chi
            {
                ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuChi1A5");//PhieuNhapVatTu//
                if (_report != null)
                {
                    DateTime dtDenNgay = DateTime.Today;
                    frmReport frm = new frmReport();

                    ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
                    if (_reportTemplate.Id == string.Empty)
                    {
                        _reportTemplate.Id = _report.Id;
                        _reportTemplate.UserID = UserId;
                        _reportTemplate.DenNgay = dtDenNgay;
                    }
                    if (_report.TenPhuongThuc != "")
                    {
                        this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                    }

                    frm.HienThiReport(_reportTemplate, dataSet);
                    frm.Show();
                }
            }
            #endregion//Devexpress
        }


        private void btnXoaChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DeleteChungTu())
            {
                btnThemMoi.PerformClick();
            }
        }       

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void tlslblThemDN_Click(object sender, EventArgs e)
        {
            if (_ChungTu.ChungTuDeNghiList.Count == 0 && _ChungTu.ChungTuGiayBaoCoList.Count == 0 && _ChungTu.ChungTuLenhChuyenTienList.Count == 0 && _ChungTu.ChungTuDeNghiList.Count == 0 && _ChungTu.ChungTuUyNhiemChiList.Count == 0 && _ChungTu.ChungTuGiayRutTienList.Count == 0)
            {
                _ChungTu.LoaiChungTuDiKem = 0;
            }
            frmChonDeNghiChuyenKhoan frm = new frmChonDeNghiChuyenKhoan(_ChungTu);
            frm.ShowDialog();
            dtmp_Ngay.DateTime = _ChungTu.NgayLap;
            TaoBindingDeNghiChuyenKhoan();
        }

        private void tlslblXoaDN_Click(object sender, EventArgs e)
        {
            if (gridView_DSDeNghi.RowCount > 0)
            {
                if (gridView_DSDeNghi.GetSelectedRows().Length > 0)
                {
                    if (XtraMessageBox.Show(String.Format("Bạn có chắc muốn xóa {0} dòng đang chọn ?", gridView_DSDeNghi.GetSelectedRows().Length), "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        gridView_DSDeNghi.DeleteSelectedRows();
                    }
                }
            }
        }

        private void tlSbtnXoaCT_HoaDon_Click(object sender, EventArgs e)
        {
            if (CheckCoTaiKhoanBiKhoaTrongButToan())
            {
                MessageBox.Show(this, "Đã khóa sổ tài khoản, không thể thực hiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DeleteChungTu_HoaDonList();
        }

        private void tlSBtnThemCT_HoaDon_Click(object sender, EventArgs e)
        {
            #region Modify
            LoadButToanThue();
            if (IsTaiKhoanThueKhauTru(_ButToanThue.NoTaiKhoan) == false)
            {
                MessageBox.Show(this, "Vui lòng chọn tài khoản thuế!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (_ButToanThue.SoTien == 0)
            {
                MessageBox.Show(this, "Vui lòng nhập số tiền của bút toán!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                FrmGetHoaDonToChungTu_HoaDon frm = new FrmGetHoaDonToChungTu_HoaDon(_ChungTu);
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    HoaDonList hoadonSelected = frm.HoanDonListSelected;//M
                    if (hoadonSelected.Count != 0)//M
                    {
                        #region New
                        foreach (HoaDon hoadon in hoadonSelected)
                        {
                            bool insert = true;
                            if (ChungTu_HoaDongridView.RowCount > 0)
                            {
                                for (int i = 0; i < ChungTu_HoaDongridView.RowCount; i++)
                                {
                                    if (ChungTu_HoaDongridView.GetRow(i) != null)
                                    {
                                        ChungTu_HoaDon ct_hd_gv = (ChungTu_HoaDon)ChungTu_HoaDongridView.GetRow(i);
                                        if (ct_hd_gv.MaHoaDon == hoadon.MaHoaDon)
                                        {
                                            insert = false;
                                            break;
                                        }
                                    }
                                }

                            }

                            if (insert)
                            {

                                ChungTu_HoaDon ct_hoadon = ChungTu_HoaDon.NewChungTu_HoaDon(hoadon);
                                _ButToanThue.ChungTu_HoaDonList.Add(ct_hoadon);
                            }
                        }
                        #endregion //End New
                    }
                }
                _ChungTu_HoaDonList = _ButToanThue.ChungTu_HoaDonList;
                ChungTuHoaDon_bindingSource.DataSource = _ChungTu_HoaDonList;

            }

            #endregion Modify

            #region Old
            //if ((KhoaSoThue())) return;
            //bool coTKThue = false;
            //foreach (ButToan buttoan in _ChungTu.DinhKhoan.ButToan)
            //{
            //    if (IsTaiKhoanThueKhauTru(buttoan.NoTaiKhoan))
            //    {
            //        FrmGetHoaDonToChungTu_HoaDon frm = new FrmGetHoaDonToChungTu_HoaDon(_ChungTu);
            //        if (frm.ShowDialog() != DialogResult.OK)
            //        {
            //            HoaDonList hoadonSelected = frm.HoanDonListSelected;//M
            //            if (hoadonSelected.Count != 0)//M
            //            {
            //                #region New
            //                foreach (HoaDon hoadon in hoadonSelected)
            //                {
            //                    bool insert = true;
            //                    if (ChungTu_HoaDongridView.RowCount > 0)
            //                    {
            //                        for (int i = 0; i < ChungTu_HoaDongridView.RowCount; i++)
            //                        {
            //                            if (ChungTu_HoaDongridView.GetRow(i) != null)
            //                            {
            //                                ChungTu_HoaDon ct_hd_gv = (ChungTu_HoaDon)ChungTu_HoaDongridView.GetRow(i);
            //                                if (ct_hd_gv.MaHoaDon == hoadon.MaHoaDon)
            //                                {
            //                                    insert = false;
            //                                    break;
            //                                }
            //                            }
            //                        }

            //                    }//grdViewCt_PhieuXuat.RowCount > 0

            //                    if (insert)
            //                    {

            //                        ChungTu_HoaDon ct_hoadon = ChungTu_HoaDon.NewChungTu_HoaDon(hoadon);
            //                        buttoan.ChungTu_HoaDonList.Add(ct_hoadon);
            //                        //_ChungTu.Chungtu_HoaDonList.Add(ct_hoadon);
            //                    }
            //                }
            //                #endregion //End New
            //            }
            //        }
            //        ChungTuHoaDon_bindingSource.DataSource = buttoan.ChungTu_HoaDonList;
            //        coTKThue = true;
            //        break;
            //    }
            //}
            //if (coTKThue == false)
            //{
            //    MessageBox.Show(this, "Vui lòng chọn tài khoản thuế!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //} 
            #endregion//Old
        }


        private void btnLapHoaDonBanRa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_ChungTu.IsNew == true)
            {
                MessageBox.Show("Vui lòng cập nhật Chứng từ trước khi lập Hóa đơn?", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LapHoaDonBanRa();
        }

        private void UNCVietcombankbarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _InmauCoSan = false;
            inUyNhiemChi("Vietcombank");
        }

        private void UNCVietcombank_MauCoSanbarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _InmauCoSan = true;
            inUyNhiemChi("Vietcombank");
        }

        private void UNCACBbarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _InmauCoSan = false;
            inUyNhiemChi("ACB");
        }

        private void UNCACB_MauCoSanbarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _InmauCoSan = true;
            inUyNhiemChi("ACB");
        }




        #endregion Events

        private void dtmp_Ngay_Leave(object sender, EventArgs e)
        {
            if (dtmp_Ngay.OldEditValue != dtmp_Ngay.EditValue && _ChungTu.IsNew && dtmp_Ngay.Text != "")
            {
                NgayHT_dateEdit1.EditValue = dtmp_Ngay.EditValue;
                _ChungTu.NgayThucHien = (DateTime)dtmp_Ngay.EditValue;
                _ChungTu.SoChungTu = PublicClass.SetSoChungTuByMaLoaiChungTu(_LoaiChungTu.MaLoaiCT, _ChungTu.NgayThucHien);

            }
            else if (dtmp_Ngay.OldEditValue != dtmp_Ngay.EditValue && dtmp_Ngay.Text != "")
            {
                if (_ChungTu.NgayThucHien.Month != dtmp_Ngay.DateTime.Month)
                {
                    _ChungTu.SoChungTu = PublicClass.SetSoChungTuByMaLoaiChungTu(_LoaiChungTu.MaLoaiCT, dtmp_Ngay.DateTime);
                }
                NgayHT_dateEdit1.EditValue = dtmp_Ngay.EditValue;
                _ChungTu.NgayThucHien = (DateTime)dtmp_Ngay.EditValue;
            }

            //if (dtmp_Ngay.OldEditValue != dtmp_Ngay.EditValue)
            //{
            //    _ChungTu.SoChungTu = PublicClass.SetSoChungTuByMaLoaiChungTu(_LoaiChungTu.MaLoaiCT, _ChungTu.NgayLap);
            //    _ChungTu.NgayThucHien = _ChungTu.NgayLap;
            //}
            //else if (dtmp_Ngay.OldEditValue != dtmp_Ngay.EditValue)
            //{
            //    if (_ChungTu.NgayThucHien.Month != dtmp_Ngay.DateTime.Month)
            //    {
            //        _ChungTu.SoChungTu = PublicClass.SetSoChungTuByMaLoaiChungTu(_LoaiChungTu.MaLoaiCT, dtmp_Ngay.DateTime);
            //    }
            //    NgayHT_dateEdit1.EditValue = dtmp_Ngay.EditValue;
            //    _ChungTu.NgayThucHien = (DateTime)dtmp_Ngay.EditValue;
            //}
        }

        #region event btnSua
        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.strStatus = "SUA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            HoatDong_gridLookUpEdit1.Focus();
        }
        private void PhanQuyenThemSuaXoa()
        {
            _phanQuyen = PhanQuyenSuDungForm.GetQuyenSuDungFormTheoUser(CurrentUser.Info.UserID, (this.GetType().Namespace + "." + this.Name));

            btnThemMoi.Enabled = _phanQuyen.Them;
            btnSua.Enabled = _phanQuyen.Sua;
            btnXoaChungTu.Enabled = _phanQuyen.Xoa;
        }
        public string strStatus = "KHOA";
        private void ReadOnlyConTrolByStatus(string _strStatus)
        {
            if (_strStatus == "" || _strStatus == "THEM" || _strStatus == "SUA")
            {
                gridView_ButToan.OptionsBehavior.Editable = true;
                tblButToanBindingSource.AllowNew = true;
                gridView_DSDeNghi.OptionsBehavior.Editable = false;

                txt_TienBangChu.Properties.ReadOnly = false;

                foreach (Control c in ThongTinChunggroupControl2.Controls)
                {
                    if (c is GridLookUpEdit)
                    {
                        ((GridLookUpEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is TextEdit)
                    {
                        ((TextEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is DateEdit)
                    {
                        ((DateEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is CalcEdit)
                    {
                        ((CalcEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is MemoEdit)
                    {
                        ((MemoEdit)c).Properties.ReadOnly = false;
                    }
                }

                foreach (Control c in ThongTinChungTugroupControl.Controls)
                {
                    if (c is GridLookUpEdit)
                    {
                        ((GridLookUpEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is TextEdit)
                    {
                        ((TextEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is DateEdit)
                    {
                        ((DateEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is CalcEdit)
                    {
                        ((CalcEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is MemoEdit)
                    {
                        ((MemoEdit)c).Properties.ReadOnly = false;
                    }
                }
                btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnDuplicate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (_strStatus == "KHOA")
            {
                gridView_ButToan.OptionsBehavior.Editable = false;
                tblButToanBindingSource.AllowNew = false;
                gridView_DSDeNghi.OptionsBehavior.Editable = false;

                txt_TienBangChu.Properties.ReadOnly = true;

                foreach (Control c in ThongTinChunggroupControl2.Controls)
                {
                    if (c is GridLookUpEdit)
                    {
                        ((GridLookUpEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is TextEdit)
                    {
                        ((TextEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is DateEdit)
                    {
                        ((DateEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is CalcEdit)
                    {
                        ((CalcEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is MemoEdit)
                    {
                        ((MemoEdit)c).Properties.ReadOnly = true;
                    }
                }

                foreach (Control c in ThongTinChungTugroupControl.Controls)
                {
                    if (c is GridLookUpEdit)
                    {
                        ((GridLookUpEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is TextEdit)
                    {
                        ((TextEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is DateEdit)
                    {
                        ((DateEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is CalcEdit)
                    {
                        ((CalcEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is MemoEdit)
                    {
                        ((MemoEdit)c).Properties.ReadOnly = true;
                    }
                }

                btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnDuplicate.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            PhanQuyenThemSuaXoa();
        }
        #endregion

        private void FrmChungTuChuyenTienNoiBo_Load(object sender, EventArgs e)
        {
            this.ReadOnlyConTrolByStatus(this.strStatus);

            DateTime _tuNgay = DateTime.Today.Month > 6 ? new DateTime(DateTime.Today.Year, 7, 1) : new DateTime(DateTime.Today.Year - 1, 7, 1);
            DateTime _denNgay = DateTime.Today.Month > 6 ? new DateTime(DateTime.Today.Year + 1, 6, 30) : new DateTime(DateTime.Today.Year, 6, 30);
            dtEdit_DenNgay.DateTime = _denNgay;
            dtEdit_TuNgay.DateTime = _tuNgay;
            btnTim.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXuatExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                RefreshList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void RefreshList()
        {
            _LoaiTienList = LoaiTienList.GetLoaiTienList();
            LoaiTien_bindingSource.DataSource = _LoaiTienList;
            // tai khoan
            //_HeThongTaiKhoan1ListCo = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
            _HeThongTaiKhoan1ListCo = HeThongTaiKhoan1List.GetTaiKhoanConListByCongTy();
            tblTaiKhoanBindingSource_No.DataSource = _HeThongTaiKhoan1ListCo;
            _HeThongTaiKhoan1ListNo = _HeThongTaiKhoan1ListCo;
            tblTaiKhoanBindingSource_Co.DataSource = _HeThongTaiKhoan1ListNo;
            //HoatDongList
            HoatDongDevList hoatdonglist = HoatDongDevList.GetHoatDongDevList(_maCongTy);
            HoatDongDev hoatdongE = HoatDongDev.NewHoatDongDev();
            hoatdongE.TenHoatDong = "";
            hoatdonglist.Insert(0, hoatdongE);
            HoatDongList_bindingSource1.DataSource = hoatdonglist;
            //CauTrucKhoanMucChiPhiList
            CauTrucDoanhThuChiPhiList khoanmuclist = CauTrucDoanhThuChiPhiList.GetCauTrucDoanhThuChiPhiList(_maCongTy);
            CauTrucDoanhThuChiPhi khoanmucE = CauTrucDoanhThuChiPhi.NewCauTrucDoanhThuChiPhi();
            khoanmucE.Ten = "";
            khoanmuclist.Insert(0, khoanmucE);
            CauTrucDoanhThuChiPhiList_bindingSource1.DataSource = khoanmuclist;
            //DonViList
            BoPhanList bophanlist = BoPhanList.GetBoPhanList();
            BoPhan bpEmpt = BoPhan.NewBoPhan("");
            bophanlist.Insert(0, bpEmpt);
            DonViList_bindingSource1.DataSource = bophanlist;
            //Loai Thue VAT
            LoaiThueSuatListBindingSource.DataSource = LoaiThueSuatVAT.CreateListLoaiThueSuatVAT();
            DanhMucMauHoaDonList danhMucMauHoaDonList = DanhMucMauHoaDonList.GetDanhMucMauHoaDonList();
            //mauHDBindingSource.DataSource = danhMucMauHoaDonList;
            //NhomHDDVMuaVaoBindingsource.DataSource = NhomHHDVMuaVao.CreateListNhomHHDVMuaVao();

            this._daLoadXong = false;
            this.LoadDoiTuongList();
            this._daLoadXong = true;
        }

        #region copy - pass chung tu
        private void btnDuplicate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_ChungTu.MaChungTu == 0)
                return;
            if (_phanQuyen.Them)
            {
                DuplicateChungTu();
            this.strStatus = "THEM";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            _taoMoiChungTu = true;
            dtmp_Ngay.EditValue = null;
            GanBindingSource();
            }
            else
            {
                DialogUtil.ShowWarning("Bạn không có quyền thêm chứng từ!");
            }
        }
        private void DuplicateChungTu()
        {
            ChungTu _chungTuCanDeCopy = ChungTu.NewChungTu();
            ChungTuList ct = ChungTuList.GetChungTuListByMaChungTu_New(_ChungTu.MaChungTu);
            if (ct.Count > 0)
            {
                _chungTuCanDeCopy = ct[0];
            }
            _ChungTu = ChungTu.DuplicateChungTu(_chungTuCanDeCopy, this._LoaiChungTu.MaLoaiCT);
        }
        #endregion

        private void grdLU_LoaiTien_EditValueChanged(object sender, EventArgs e)
        {
            if (this.isLoadCboTienTe)
            {
                if ((int)grdLU_LoaiTien.EditValue == 1)
                {
                    gridView_ButToan.Columns["SoTienNgoaiTe"].Visible = false;
                }
                else
                {
                    gridView_ButToan.Columns["SoTienNgoaiTe"].Visible = true;

                }
                if (this.strStatus != "KHOA")
                {
                    _ChungTu.Tien.MaLoaiTien = (int)grdLU_LoaiTien.EditValue;
                    _ChungTu.Tien.TiGiaQuyDoi = (decimal)LoaiTien.GetLoaiTien((int)(grdLU_LoaiTien.EditValue)).TiGiaQuyDoi;
                    foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
                    {
                        if (bt.SoTienNgoaiTe != 0)
                        {
                            bt.SoTien = Math.Round(bt.SoTienNgoaiTe * _ChungTu.Tien.TiGiaQuyDoi, 0, MidpointRounding.AwayFromZero);
                        }
                    }
                    TinhSoTienChungTu();
                }
            }
        }

        private void txt_TiGia_Validated(object sender, EventArgs e)
        {
            if (this.isLoadCboTienTe)
            {
                if ((int)grdLU_LoaiTien.EditValue != 1)
                {
                    if (this.strStatus != "KHOA")
                    {
                        foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
                        {
                            if (bt.SoTienNgoaiTe != 0)
                            {
                                bt.SoTien = Math.Round(bt.SoTienNgoaiTe * _ChungTu.Tien.TiGiaQuyDoi, 0, MidpointRounding.AwayFromZero);
                            }
                        }
                        TinhSoTienChungTu();
                    }

                }

            }
        }

        #region Danh sach chung tu
        private void DesignGridTim()
        {
            string _MaLoaiCTQL = LoaiChungTuDev.GetLoaiChungTuDev(_LoaiChungTu.MaLoaiCT).MaLoaiCTQuanLy;
            if (_MaLoaiCTQL == "PC112" || _MaLoaiCTQL == "LCTNN" || _MaLoaiCTQL == "GBNT" || _MaLoaiCTQL == "PT112")
            {
                gridView_Tim.Columns["SoTaiKhoan"].Visible = true;
                gridView_Tim.Columns["SoTienNgoaiTe"].Visible = true;
                gridView_Tim.Columns["SoTaiKhoan"].Caption = "TK Ngân Hàng";
                gridView_Tim.Columns["SoTienNgoaiTe"].Caption = "Tiền ngoại tệ";
                gridView_Tim.Columns["SoTienNgoaiTe"].VisibleIndex = 5;
                gridView_Tim.Columns["SoTaiKhoan"].VisibleIndex = 7;
            }
            else if (_MaLoaiCTQL == "MuaChuaThanhToan")
            {
                gridView_Tim.Columns["NgayHoaDon"].Visible = true;
                gridView_Tim.Columns["SoHoaDon"].Visible = true;
                gridView_Tim.Columns["SoTienHoaDon"].Visible = true;
                gridView_Tim.Columns["NgayHoaDon"].Caption = "Ngày Hóa Đơn";
                gridView_Tim.Columns["SoHoaDon"].Caption = "Số Hóa Đơn";
                gridView_Tim.Columns["SoTienHoaDon"].Caption = "Tiền Hóa Đơn";
            }

            //STT grid_tim
            Utils.GridUtils.SetSTTForGridView(gridView_Tim, 50);//M
        }
        ChungTuRutGonList _ChungTuTimList;
        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ChungTuTimList = ChungTuRutGonList.GetChungTuList_1(_LoaiChungTu.MaLoaiCT, (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date);
            this.bindingSource_DanhSachChungTuTim.DataSource = _ChungTuTimList;
            if (_ChungTuTimList.Count == 0)//M
            {
                MessageBox.Show("Danh Sách Phiếu rỗng!");
                return;
            }
            DesignGridTim();
        }

        #endregion

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Name == "tabThongTinPhieu")
            {
                btnTim.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnXuatExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                InUNC_barSubItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnPrintA4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                if (strStatus == "" || strStatus == "THEM" || strStatus == "SUA")
                {
                    btnDuplicate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else
                {
                    btnDuplicate.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
            }
            else
            {
                btnTim.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnXuatExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                InUNC_barSubItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnPrintA4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnDuplicate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                if (gridView_Tim.RowCount == 0)
                {
                    btnTim.PerformClick();
                }
            }
        }

        private void btnXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gridControl_Tim.ExportToXls(dlg.FileName);
                MessageBox.Show("Đã xuất dữ liệu thành công", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(dlg.FileName);
            }
        }

        private void gridControl_Tim_DoubleClick(object sender, EventArgs e)
        {
            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            xtraTabControl1.SelectedTabPageIndex = 0;
            ChungTuRutGon ChungTuRG = (ChungTuRutGon)bindingSource_DanhSachChungTuTim.Current;
            LoadChungTuCu(ChungTuRG.MaChungTu);
            _taoMoiChungTu = false;//          
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            xtraTabControl1.SelectedTabPageIndex = 0;
            ChungTuRutGon ChungTuRG = (ChungTuRutGon)bindingSource_DanhSachChungTuTim.Current;
            LoadChungTuCu(ChungTuRG.MaChungTu);
            _taoMoiChungTu = false;//          
        }

        private void btnIn_UNC_VCB_NgoaiTe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _InmauCoSan = true;
            inUyNhiemChi_NgoaiTe("Vietcombank");
        }

        private void inUyNhiemChi_NgoaiTe(string UNCNganHang)
        {
            if (_ChungTu.IsNew == false)
            {
                ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);
                //Kiểm tra UNC Đang chọn có đúng với ngân hàng cần in không
                int iMaNganHang; //Convert.ToInt32(grdData.Selected.Rows[0].Cells["MaNganHang"].Value);
                iMaNganHang = CongTy_NganHang.GetCongTy_NganHang(_ChungTu.BoSungChungTuKT.MaTaiKhoanNH).MaNganHang;
                long lNhomNganHang = NganHang.GetNganHang(iMaNganHang).MaNhomNganHang;
                string strTenNganHang = NhomNganHang.GetNhomNganHang(lNhomNganHang).TenNhomNganHang;
                string strUNCNganHang = UNCNganHang.Replace("A4", "");//Mốt có A khác nữa nhớ bỏ thêm vô loại trừ hết lấy chữ Eximbank thôi
                strUNCNganHang = UNCNganHang.Replace("New", "");//Mốt có A khác nữa nhớ bỏ thêm vô loại trừ hết lấy chữ Eximbank thôi
                bool bTrung = strTenNganHang.ToUpper().Contains(strUNCNganHang.Trim().ToUpper());
                if (!bTrung)
                {
                    MessageBox.Show(this, "Mẫu in Ủy Nhiệm Chi không cùng thông tin ngân hàng của Ủy Nhiệm Chi đang chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                    UNCNganHang = "Vietcombank";
                }
                switch (UNCNganHang)
                {
                    //case "VietinBank":
                    //    InUNC_VietinBank();
                    //    break;
                    case "Vietcombank":
                        InUNC_Vietcombank_NgoaiTe();
                        break;
                    //case "ACB":
                    //    InUNC_ACB();
                    //    break;
                    //case "Agribank":
                    //    InUNC_Agribank();
                    //    break;
                    //case "BIDV":
                    //    InUNC_BIDV();
                    //    break;

                }
            }
        }
        private void InUNC_Vietcombank_NgoaiTe()
        {
            ReportTemplate _report;
            //BEGIN
            if (_InmauCoSan)
            {
                _report = ReportTemplate.GetReportTemplate("ID_Report_UNC_VCB_MauCoSan_NgoaiTe");
            }
            else
            {
                _report = ReportTemplate.GetReportTemplate("ID_Report_UNC_VCB");
            }
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);

                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
                    _reportTemplate.DenNgay = dtDenNgay;
                }

                if (_report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(_reportTemplate, dataSet);
                frm.ShowDialog();
            }
            //END
        }

        public void Method_Report_UNC_VCB_NgoaiTe()
        {
            ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);

            //string SoTienBangChu = HamDungChung.DocTien(_ChungTu.Tien.ThanhTien);
            LoaiTien loaitien = LoaiTien.GetLoaiTien(_ChungTu.Tien.MaLoaiTien);

            string SoTienBangChu = ERP_Library.HamDungChung.DocTienNgoaiTe(_ChungTu.Tien.SoTien, loaitien.TienChan, loaitien.TienLe);

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapBanQuyen
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spRpt_UyNhiemChi_NgoaiTe";
                    cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                    cm.Parameters.AddWithValue("@SoTienBangChu", SoTienBangChu);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_Report_UyNhiemChi";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua Parameters of Report
                DataTable dtParameters = new DataTable();
                dtParameters.Columns.Add("TenBoPhan", typeof(string));
                dtParameters.Columns.Add("TenNguoiLap", typeof(string));
                dtParameters.Columns.Add("TenThuTruong", typeof(string));
                //Add dòng 1
                DataRow dr = dtParameters.NewRow();
                dr["TenBoPhan"] = nguoiky.ThuTruongTen;
                dr["TenNguoiLap"] = ERP_Library.Security.CurrentUser.Info.TenNguoiLap;
                dr["TenThuTruong"] = nguoiky.TenTongGiamDoc;
                dtParameters.Rows.Add(dr);
                dtParameters.TableName = "dtParameters";
                dataSet.Tables.Add(dtParameters);
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

            }//us  
        }

        private void menuItemInsertRow_Click(object sender, EventArgs e)
        {
            //ButToan bt = (ButToan)tblButToanBindingSource.Current;   
            ButToan bt = ButToan.NewButToan();
            int i = gridView_ButToan.GetSelectedRows()[0];
            _ChungTu.DinhKhoan.ButToan.Insert(i, bt);
            //MessageBox.Show(i+"");
        }



    }
}