using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
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
    public partial class FrmChungTuKeToanCustomize : XtraForm
    {
        #region Properties
        public int LoaiChi = 0;
        int _maCongTy = CurrentUser.Info.MaCongTy;
        bool checkChonHoaDon = false;
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
        //private ChungTu_HoaDonThanhToanChildList _ChungTu_HoaDonThanhToanList = ChungTu_HoaDonThanhToanChildList.NewChungTu_HoaDonThanhToanChildList();
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

        string SoCTMoiPS = "";        //
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
        PhanBoChiPhiCCDC _phanBoChiPhiCCDC = PhanBoChiPhiCCDC.NewPhanBoChiPhiCCDC();

        private bool clickButtoan = false;
        private bool handlefocus = true;
        private bool _isCellValuechangeBT = true;

        private bool _lapChungTuBienLai = false;
        private BindingSource DoiTuongForChungTuHoaDonBindingSource = new BindingSource();

        private DinhKhoanTuDong _dinhKhoanTuDong = DinhKhoanTuDong.NewDinhKhoanTuDong();
        private BindingSource LoaiThueSuatListBindingSource = new BindingSource();
        //private BindingSource NhomHDDVMuaVaoBindingsource = new BindingSource();
        private long _maDoiTuongDeNghi = 0;
        private byte _RefType = 0;
        private bool isChonHoaDon = false;
        private bool isLoadCboTienTe = false;
        #endregion Properties

        #region Functions
        private void TaoBingdingOfControls()
        {
            this.NguoiNhan_textEdit1.DataBindings.Add(new Binding("EditValue", this.tblChungTuBindingSource_Single, "ChungTu_DiaChi.Ten", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txt_DiaChiDoiTuongNhan.DataBindings.Add(new Binding("EditValue", this.tblChungTuBindingSource_Single, "ChungTu_DiaChi.DiaChi", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
        }

        private void FormatForm()
        {
            Tab1_xtraTabPage2.PageVisible = true;//DeNghi
            if (_LoaiChungTu.MaLoaiCTQuanLy == "PT111")
            {
                this.Text = "Phiếu Thu";
                //Tab1_xtraTabPage2.PageVisible = true;//DeNghi
                Tab1_xtraTabPage3.PageVisible = false;//HoaDon
                NguoiNhanLbCtrl.Text = "Người nộp";
                DienGiaiLbCtrl.Text = "Lý do nộp";
                NhanVienLbCtrl.Text = "Nhân viên thu";
                btnlapChungTuBienLai.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnLapHoaDonBanRa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                //checkBox_ThuLao.Text = "Không In Thuế";
                //lblPhieuChi.Visible = true;
                //gridLookUpEditMaChungTuPC.Visible = true;
                //KhoiTaoGridLookupEditMaChungTuPhieuChi();//--
            }
            else if (_LoaiChungTu.MaLoaiCTQuanLy == "PC111")
            {
                this.Text = "Phiếu Chi";
                //Tab1_xtraTabPage2.PageVisible = true;//DeNghi
                Tab1_xtraTabPage3.PageVisible = true;//HoaDon
                NguoiNhanLbCtrl.Text = "Người nhận";
                DienGiaiLbCtrl.Text = "Lý do chi";
                NhanVienLbCtrl.Text = "Nhân viên";
                btnlapChungTuBienLai.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnLapHoaDonBanRa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //checkBox_ThuLao.Visible = false;
                //lblPhieuChi.Visible = false;
                //gridLookUpEditMaChungTuPC.Visible = false;
            }
            else if (_LoaiChungTu.MaLoaiCTQuanLy == "PT112")
            {
                this.Text = "Phiếu Thu Tiền Gửi";
                //Tab1_xtraTabPage2.PageVisible = true;//DeNghi
                Tab1_xtraTabPage3.PageVisible = false;//HoaDon
                NguoiNhanLbCtrl.Text = "Người nộp";
                DienGiaiLbCtrl.Text = "Lý do nộp";
                NhanVienLbCtrl.Text = "Nhân viên thu";
                btnlapChungTuBienLai.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnLapHoaDonBanRa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else if (_LoaiChungTu.MaLoaiCTQuanLy == "PC112")
            {
                this.Text = "Phiếu Chi Tiền Gửi";
                //Tab1_xtraTabPage2.PageVisible = true;//DeNghi
                Tab1_xtraTabPage3.PageVisible = true;//HoaDon
                NguoiNhanLbCtrl.Text = "Người nhận";
                DienGiaiLbCtrl.Text = "Lý do chi";
                NhanVienLbCtrl.Text = "Nhân viên";
                btnlapChungTuBienLai.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnLapHoaDonBanRa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (_LoaiChungTu.MaLoaiCTQuanLy == "PKT")
            {
                this.Text = "Chứng Từ Nghiệp Vụ Khác";
                //Tab1_xtraTabPage2.PageVisible = true;//DeNghi
                Tab1_xtraTabPage3.PageVisible = true;//HoaDon

                NguoiNhanLbCtrl.Text = "Người GD";
                DienGiaiLbCtrl.Text = "Diễn giải";
                NhanVienLbCtrl.Text = "Nhân viên";
                btnlapChungTuBienLai.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnLapHoaDonBanRa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //checkBox_ThuLao.Text = "Theo Dõi Thù Lao";
                //lblPhieuChi.Visible = false;
                //gridLookUpEditMaChungTuPC.Visible = false;
            }
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
            DanhMucMauHoaDonList danhMucMauHoaDonList = DanhMucMauHoaDonList.GetDanhMucMauHoaDonList();
            mauHDBindingSource.DataSource = danhMucMauHoaDonList;
            //NhomHDDVMuaVaoBindingsource.DataSource = NhomHHDVMuaVaoList.GetNhomHHDVMuaVaoList();
            if (_taoMoiChungTu)
            {
                KhoiTaoChungTuMoi();
            }
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
            ChungTuHoaDonThanhToan_bindingSource.DataSource = typeof(ChungTu_HoaDonThanhToanChildList);
            phuongThucThanhToanListBindingSource.DataSource = typeof(PhuongThucThanhToanList);
            //this.WindowState = FormWindowState.Maximized;
            DoiTuongForChungTuHoaDonBindingSource.DataSource = typeof(DoiTuongAllList);
            LoaiThueSuatListBindingSource.DataSource = typeof(LoaiThueSuatVAT);
            DonViList_bindingSource1.DataSource = typeof(BoPhanList);
            mauHDBindingSource.DataSource = typeof(DanhMucMauHoaDonList);
            //NhomHDDVMuaVaoBindingsource.DataSource = typeof(NhomHHDVMuaVao);
            ChungTu_ChungTuListbindingSource.DataSource = typeof(ChungTu_ChungTuChildList);
            TaoBingdingOfControls();
            DesignGridControls();
        }

        private void GanBindingSource()
        {
            tblChungTuBindingSource_Single.DataSource = _ChungTu;
            TienTe_bindingSource.DataSource = _ChungTu.Tien;
            BSChungTu_bindingSource.DataSource = _ChungTu.BoSungChungTuKT;
            tblDinhKhoanBindingSource_Single.DataSource = _ChungTu.DinhKhoan;
            tblButToanBindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;
            ChungTuHoaDonThanhToan_bindingSource.DataSource = _ChungTu.ChungTu_HoaDonThanhToanList;
            gridControl1.DataSource = tblButToanBindingSource;
            //ChungTuHoaDonThanhToan_bindingSource.DataSource = _ChungTu_HoaDonThanhToanList;// _ButToanThue.ChungTu_HoaDonList;
            ChungTu_HoaDonThanhToangridControl.DataSource = ChungTuHoaDonThanhToan_bindingSource;

            ChungTu_ChungTuListbindingSource.DataSource = _ChungTu.ChungTu_ChungList;
            ChungTu_DeNghigridControl.DataSource = ChungTu_ChungTuListbindingSource;
            //if (_LoaiChungTu.MaLoaiCTQuanLy == "PKT" || _LoaiChungTu.MaLoaiCTQuanLy == "PT111" || _LoaiChungTu.MaLoaiCTQuanLy == "PC112")//Bang Ke or PhieThu
            //    ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = _ChungTu.ChungTuDeNghiList;
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
            HamDungChung.InitGridViewDev(gridView_ButToan, false, true, GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(gridView_ButToan, new string[] { "DienGiai", "NoTaiKhoan", "CoTaiKhoan", "SoTienNgoaiTe", "SoTien", "DoiTuongNo", "DoiTuongCo", "MaDonVi", "IDKhoanMuc", "MaHopDong", "SoHoaDonThamChieu" },
                                new string[] { "Nội dung", "Nợ Tài Khoản", "Có Tài Khoản", "Số tiền ngoại tệ", "Số Tiền", "Đối tượng nợ", "Đối tượng có", "Đơn vị", "Thuộc khoản mục", "Số hợp đồng", "Số hóa đơn tham chiếu" },
                                             new int[] { 150, 80, 80, 90, 90, 120, 120, 100, 100, 100 ,100});
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
            RepositoryItemGridLookUpEdit donVi_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(donVi_GrdLU, DonViList_bindingSource1, "TenBoPhan", "MaBoPhan", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(donVi_GrdLU, new string[] { "TenBoPhan", "MaBoPhanQL" }, new string[] { "Đơn vị", "Mã đơn vị" }, new int[] { 200, 100 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "MaDonVi", donVi_GrdLU);
            //
            RepositoryItemCalcEdit repositoryItemCalcEditSoTien = new RepositoryItemCalcEdit();

            repositoryItemCalcEditSoTien.AutoHeight = false;
            repositoryItemCalcEditSoTien.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditSoTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repositoryItemCalcEditSoTien.Name = "repositoryItemCalcEditSoTien";
            gridView_ButToan.Columns["SoTien"].ColumnEdit = repositoryItemCalcEditSoTien;
            //
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_ButToan, new string[] { "SoTien" }, "#,###.##");
            this.gridView_ButToan.RowCellClick += new RowCellClickEventHandler(this.gridView_ButToan_RowCellClick);
            this.gridView_ButToan.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_ButToan_CellValueChanged);
            this.gridView_ButToan.KeyDown += new KeyEventHandler(this.gridView_ButToan_KeyDown);
            this.gridView_ButToan.InitNewRow += new InitNewRowEventHandler(this.gridView_ButToan_InitNewRow);
            //this.gridView_ButToan.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView_ButToan_RowClick);
            //this.gridView_ButToan.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gridView_ButToan_FocusedColumnChanged);

            this.gridControl1.ProcessGridKey += new KeyEventHandler(this.gridControl1_ProcessGridKey);
            this.gridView_ButToan.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdView_DinhKhoan_FocusedRowChanged);

            this.gridControl1.ProcessGridKey += new KeyEventHandler(this.grd_DinhKhoan_ProcessGridKey);
            this.gridView_ButToan.KeyPress += new KeyPressEventHandler(this.grd_DinhKhoan_KeyPress);
        }

        private void DesignGrid_DSDeNghiChuyenKhoan()
        {
            #region Old
            //HamDungChung.InitGridViewDev(gridView_DSDeNghi, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, false, true);
            //HamDungChung.ShowFieldGridViewDev(gridView_DSDeNghi, new string[] { "SoChungTu", "LyDo", "SoTien" },
            //                    new string[] { "Số chứng từ", "Lý do", "Số tiền" },
            //                                 new int[] { 100, 150, 100, });
            //HamDungChung.AlignHeaderColumnGridViewDev(gridView_DSDeNghi, new string[] { "SoChungTu", "LyDo", "SoTien" }, DevExpress.Utils.HorzAlignment.Center);

            //HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_DSDeNghi, new string[] { "SoTien" }, "#,###.##");
            //HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView_DSDeNghi, new string[] { "SoTien" }, "{0:#,###.##}");
            //HamDungChung.NewRowGridViewDev(gridView_DSDeNghi);

            //Utils.GridUtils.SetSTTForGridView(gridView_DSDeNghi, 50);//M
            //HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_DSDeNghi, new string[] { "SoTien" }, "#,###.##");
            //this.gridView_DSDeNghi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_DSDeNghi_KeyDown);
            #endregion Old

            #region Modify
            ChungTu_DeNghigridControl.DataSource = ChungTu_ChungTuListbindingSource;
            HamDungChung.InitGridViewDev(gridView_DSDeNghi, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(gridView_DSDeNghi, new string[] { "SoChungTuRef", "NgayCanTru", "TenDoiTuong", "NoiDung", "SoTien" },
                                new string[] { "Số chứng từ", "Ngày chứng từ", "Đối tượng", "Nội dung", "Số tiền" },
                                             new int[] { 100, 100, 120, 150, 100, });

            HamDungChung.AlignHeaderColumnGridViewDev(gridView_DSDeNghi, new string[] { "SoChungTuRef", "NgayCanTru", "TenDoiTuong", "NoiDung", "SoTien" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_DSDeNghi, new string[] { "SoTien" }, "#,###.##");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView_DSDeNghi, new string[] { "SoTien" }, "{0:#,###.##}");
            //HamDungChung.NewRowGridViewDev(gridView_DSDeNghi);
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView_DSDeNghi, new string[] { "SoChungTuRef", "NgayCanTru", "TenDoiTuong" });

            Utils.GridUtils.SetSTTForGridView(gridView_DSDeNghi, 50);//M
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_DSDeNghi, new string[] { "SoTien" }, "#,###.##");
            this.gridView_DSDeNghi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_DSDeNghi_KeyDown);
            this.gridView_DSDeNghi.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_DSDeNghi_CellValueChanged);
            #endregion Modify

        }

        private void DesignGrid_HoaDon()
        {
            #region Design ChungTu_HoaDon
            ChungTu_HoaDonThanhToangridControl.DataSource = ChungTuHoaDonThanhToan_bindingSource;

            HamDungChung.InitGridViewDev(ChungTu_HoaDonThanhToangridView, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, false, true);


            #region Co SoTienThanhToan
            //HamDungChung.ShowFieldGridViewDev_Modify(ChungTu_HoaDonThanhToangridView, new string[] { "HoaDon.GhiChu", "HoaDon.MauHoaDon", "HoaDon.KyHieuMauHoaDon", "HoaDon.SoHoaDon", "HoaDon.SoSerial", "HoaDon.NgayLap", "HoaDon.NhomHHDVMuaVao", "HoaDon.ThanhTien", "HoaDon.ThueSuatVAT", "HoaDon.ThueVAT", "HoaDon.TongTien", "SoTienThanhToan", "HoaDon.MaDoiTac", "HoaDon.TenDoiTac", "HoaDon.MaSoThue", "HoaDon.DiaChi" },
            //                        new string[] { "Diễn giải", "Mẫu hóa đơn", "Ký hiệu mẫu HĐ", "Số hóa đơn", "Số serial", "Ngày lập", "Nhóm hóa đơn", "Tiền trước thuế", "% thuế", "Tiền Thuế", "Tiền sau thuế", "Số tiền thanh toán", "Mã đối tượng", "Tên đối tượng", "Mã số thuế", "Địa chỉ" },
            //                                     new int[] { 120, 90, 100, 90, 90, 90, 120, 90, 80, 90, 90, 100, 95, 100, 90, 100 }, false);

            //HamDungChung.AlignHeaderColumnGridViewDev(ChungTu_HoaDonThanhToangridView, new string[] { "HoaDon.GhiChu", "HoaDon.MauHoaDon", "HoaDon.KyHieuMauHoaDon", "HoaDon.SoHoaDon", "HoaDon.SoSerial", "HoaDon.NgayLap", "HoaDon.NhomHHDVMuaVao", "HoaDon.ThanhTien", "HoaDon.ThueSuatVAT", "HoaDon.ThueVAT", "HoaDon.TongTien", "SoTienThanhToan", "HoaDon.MaDoiTac", "HoaDon.TenDoiTac", "HoaDon.MaSoThue", "HoaDon.DiaChi" }, DevExpress.Utils.HorzAlignment.Center);

            //HamDungChung.FormatNumberTypeofColumnGridViewDev2(ChungTu_HoaDonThanhToangridView, new string[] { "HoaDon.ThanhTien", "HoaDon.ThueVAT", "HoaDon.TongTien", "SoTienThanhToan" }, "#,###.#");
            //HamDungChung.ShowSummaryFooterofColumnGridViewDev2(ChungTu_HoaDonThanhToangridView, new string[] { "HoaDon.ThanhTien", "HoaDon.ThueVAT", "HoaDon.TongTien", "SoTienThanhToan" }, "{0:#,###.#}");

            #endregion Co SoTienThanhToan

            #region Khong SoTienThanhToan
            HamDungChung.ShowFieldGridViewDev_Modify(ChungTu_HoaDonThanhToangridView, new string[] { "HoaDon.GhiChu", "HoaDon.MauHoaDon", "HoaDon.KyHieuMauHoaDon", "HoaDon.SoHoaDon", "HoaDon.SoSerial", "HoaDon.NgayLap", "HoaDon.ThanhTien", "HoaDon.ThueSuatVAT", "HoaDon.ThueVAT", "HoaDon.TongTien", "HoaDon.MaDoiTac", "HoaDon.TenDoiTac", "HoaDon.MaSoThue", "HoaDon.DiaChi" },
                                    new string[] { "Diễn giải", "Mẫu hóa đơn", "Ký hiệu mẫu HĐ", "Số hóa đơn", "Số serial", "Ngày hóa đơn", "Tiền trước thuế", "% thuế", "Tiền Thuế", "Tiền sau thuế", "Mã đối tượng", "Tên đối tượng", "Mã số thuế", "Địa chỉ" },
                                                 new int[] { 120, 90, 100, 90, 90, 90, 120, 90, 80, 90, 90, 95, 100, 90, 100 }, false);

            HamDungChung.AlignHeaderColumnGridViewDev(ChungTu_HoaDonThanhToangridView, new string[] { "HoaDon.GhiChu", "HoaDon.MauHoaDon", "HoaDon.KyHieuMauHoaDon", "HoaDon.SoHoaDon", "HoaDon.SoSerial", "HoaDon.NgayLap", "HoaDon.ThanhTien", "HoaDon.ThueSuatVAT", "HoaDon.ThueVAT", "HoaDon.TongTien", "HoaDon.MaDoiTac", "HoaDon.TenDoiTac", "HoaDon.MaSoThue", "HoaDon.DiaChi" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(ChungTu_HoaDonThanhToangridView, new string[] { "HoaDon.ThanhTien", "HoaDon.ThueVAT", "HoaDon.TongTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(ChungTu_HoaDonThanhToangridView, new string[] { "HoaDon.ThanhTien", "HoaDon.ThueVAT", "HoaDon.TongTien" }, "{0:#,###.#}");

            #endregion Khong SoTienThanhToan

            HamDungChung.NewRowGridViewDev(ChungTu_HoaDonThanhToangridView);

            Utils.GridUtils.SetSTTForGridView(ChungTu_HoaDonThanhToangridView, 50);//M
            //Mau Hoa Don
            RepositoryItemGridLookUpEdit MauHoaDon_grdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(MauHoaDon_grdLU, mauHDBindingSource, "MaQuanLy", "MaQuanLy", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(MauHoaDon_grdLU, new string[] { "MaQuanLy", "TenLoaiHoaDon" }, new string[] { "Mẫu", "Mô tả" }, new int[] { 90, 200 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(ChungTu_HoaDonThanhToangridView, "HoaDon.MauHoaDon", MauHoaDon_grdLU);
            //DoiTuong
            RepositoryItemGridLookUpEdit DoiTuongBS_grdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(DoiTuongBS_grdLU, DoiTuongNoList_BindingSource, "MaQLDoiTuong", "MaDoiTuong", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DoiTuongBS_grdLU, new string[] { "MaQLDoiTuong", "MaSoThue", "TenDoiTuong" }, new string[] { "Mã đối tượng", "Mã số thuế", "Tên đối tượng" }, new int[] { 90, 90, 200 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(ChungTu_HoaDonThanhToangridView, "HoaDon.MaDoiTac", DoiTuongBS_grdLU);
            //
            //LoaiThueSuatVAT
            RepositoryItemGridLookUpEdit LoaiThueSuatVAT_grdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(LoaiThueSuatVAT_grdLU, LoaiThueSuatListBindingSource, "MoTa", "ThueSuat", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiThueSuatVAT_grdLU, new string[] { "MoTa" }, new string[] { "Thuế suất" }, new int[] { 90 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(ChungTu_HoaDonThanhToangridView, "HoaDon.ThueSuatVAT", LoaiThueSuatVAT_grdLU);
            ////
            ////NhomHDDVMuaVao
            //RepositoryItemGridLookUpEdit NhomHDDVMuaVao_grdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(NhomHDDVMuaVao_grdLU, NhomHDDVMuaVaoBindingsource, "TenNhomHHDVMuaVao", "Id", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(NhomHDDVMuaVao_grdLU, new string[] { "TenNhomHHDVMuaVao" }, new string[] { "Tên nhóm" }, new int[] { 300 }, false);
            //HamDungChung.RegisterControlFieldGridViewDev(ChungTu_HoaDonThanhToangridView, "HoaDon.NhomHHDVMuaVao", NhomHDDVMuaVao_grdLU);

            this.ChungTu_HoaDonThanhToangridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChungTu_HoaDonThanhToangridView_KeyDown);
            this.ChungTu_HoaDonThanhToangridView.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.ChungTu_HoaDonThanhToangridView_InitNewRow);
            //this.ChungTu_HoaDongridView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.ChungTu_HoaDongridView_RowCellClick);
            this.ChungTu_HoaDonThanhToangridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.ChungTu_HoaDonThanhToangridView_CellValueChanged);
            #endregion//Design ChungTu_HoaDon

            HamDungChung.NewRowGridViewDev(ChungTu_HoaDonThanhToangridView, NewItemRowPosition.Bottom);
        }

        private void DesignGridControls()
        {           
            DesignHoatDong_gridLookUpEdit1();
            DesignDoiTuongGridLookUpEdit();
            DesignNhanVien_gridLookUpEdit1();
            DesignGrid_ButToan();
            //if (_LoaiChungTu.MaLoaiCTQuanLy == "PKT" || _LoaiChungTu.MaLoaiCTQuanLy == "PT111")//Bang Ke or PhieThu
            //{
            //    if (_LoaiChungTu.MaLoaiCTQuanLy == "PKT")//BangKe
            //    {
            //        btnInDVKhoanChi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //    }

            //}
            DesignGrid_DSDeNghiChuyenKhoan();
            DesignGrid_HoaDon();
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
            //gridView_ButToan.Columns["DoiTuongCo"].OptionsColumn.AllowEdit = false;
            //gridView_ButToan.Columns["DoiTuongNo"].OptionsColumn.AllowEdit = false;//
            //gridView_ButToan.Columns["DienGiai"].OptionsColumn.AllowEdit = false;

        }//Them

        private void UnLockgrdView_DinhKhoan()
        {
            gridView_ButToan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit = true;
            gridView_ButToan.Columns["CoTaiKhoan"].OptionsColumn.AllowEdit = true;
            gridView_ButToan.Columns["SoTien"].OptionsColumn.AllowEdit = true;
            //gridView_ButToan.Columns["DoiTuongCo"].OptionsColumn.AllowEdit = true;
            //gridView_ButToan.Columns["DoiTuongNo"].OptionsColumn.AllowEdit = true;//
            //gridView_ButToan.Columns["DienGiai"].OptionsColumn.AllowEdit = true;
        }//Them

        private void LockgrdView_DinhKhoan_No()
        {
            gridView_ButToan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit = false;
            //gridView_ButToan.Columns["CoTaiKhoan"].OptionsColumn.AllowEdit = false;
            gridView_ButToan.Columns["SoTien"].OptionsColumn.AllowEdit = false;
            //gridView_ButToan.Columns["DoiTuongCo"].OptionsColumn.AllowEdit = false;
            //gridView_ButToan.Columns["DoiTuongNo"].OptionsColumn.AllowEdit = false;//
            //gridView_ButToan.Columns["DienGiai"].OptionsColumn.AllowEdit = false;

        }//Them

        private void LockgrdView_DinhKhoan_Co()
        {
            //gridView_ButToan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit = false;
            gridView_ButToan.Columns["CoTaiKhoan"].OptionsColumn.AllowEdit = false;
            gridView_ButToan.Columns["SoTien"].OptionsColumn.AllowEdit = false;
            //gridView_ButToan.Columns["SoTien"].AppearanceCell.BackColor = Color.LightCoral;
            //gridView_ButToan.Columns["DoiTuongCo"].OptionsColumn.AllowEdit = false;
            //gridView_ButToan.Columns["DoiTuongNo"].OptionsColumn.AllowEdit = false;//
            //gridView_ButToan.Columns["DienGiai"].OptionsColumn.AllowEdit = false;

        }//T

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

            if (this.strStatus == "KHOA")
                return;

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
                if (KhoaButToanTheoTaiKhoan(buttoan.NoTaiKhoan))
                {
                    if (buttoan.MaButToan == 0)
                    {
                        _isCellValuechangeBT = false;
                        MessageBox.Show(this, "Đã khóa sổ tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        buttoan.NoTaiKhoan = 0;
                        _isCellValuechangeBT = true;
                    }
                    else
                        LockgrdView_DinhKhoan_No();
                }

                if (KhoaButToanTheoTaiKhoan(buttoan.CoTaiKhoan))
                {
                    if (buttoan.MaButToan == 0)
                    {
                        _isCellValuechangeBT = false;
                        MessageBox.Show(this, "Đã khóa sổ tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        buttoan.CoTaiKhoan = 0;
                        _isCellValuechangeBT = true;
                    }
                    else
                        LockgrdView_DinhKhoan_Co();
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
                btnPrintA5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;             
            }
            else
            {
                btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnPrintA4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnPrintA5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
                        DialogUtil.ShowError("Xóa không thành công!\n" + ex.Message);
                        //throw ex;
                    }
                }
            }
            return false;
        }

        private void KhoiTaoChungTuMoi()
        {
            dtmp_Ngay.EditValue = (object)DateTime.Today.Date;
            //chưa load xong
            //_daLoadXong = false;
            {
                _ChungTu = ChungTu.NewChungTu(_LoaiChungTu.MaLoaiCT);
                _ChungTu.SoChungTu = PublicClass.SetSoChungTuByMaLoaiChungTu(_LoaiChungTu.MaLoaiCT, (Convert.ToDateTime(dtmp_Ngay.EditValue)).Date);//ChungTu.LaySoChungTuMax(_LoaiChungTu.MaLoaiCT, _ChungTu.NgayLap.Year);
                _ChungTu.SoChungTuKemTheo = 1;
                soTien = 0;
                TongTien = 0;
                _ngayLapCu = _ChungTu.NgayLap.Year > 1900 ? _ChungTu.NgayLap : _ChungTu.NgayThucHien;
                LoadDataAfterInitChungTu();
                //gán bindingSource
                GanBindingSource();
                DoiTuongGridLookUpEdit.Focus();
                btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                _maDoiTuongDeNghi = 0;
                _RefType = 0;
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
            NguoiNhan_textEdit1.Text = _ChungTu.ChungTu_DiaChi.Ten;
            txt_DiaChiDoiTuongNhan.Text = _ChungTu.ChungTu_DiaChi.DiaChi;
        }

        private void LoadChungTuCu(long maChungTu)
        {
            int i = 0;
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
                //load lại hoa don da gan vao
                foreach (ChungTu_HoaDonThanhToan cthdtt in _ChungTu.ChungTu_HoaDonThanhToanList)
                {
                    cthdtt.HoaDon.ThanhTien = cthdtt.SoTienThanhToan;
                    cthdtt.HoaDon.ThueVAT = cthdtt.TienThue;
                    cthdtt.HoaDon.MaDoiTac = cthdtt.MaDoiTac;
                    if (cthdtt.HoaDon.CT_HoaDonDichVuList.Count > 0)
                    {
                        cthdtt.HoaDon.GhiChu = cthdtt.HoaDon.CT_HoaDonDichVuList[i].TenHangHoaDichVu;
                        i++;
                    }
                    else
                        cthdtt.HoaDon.GhiChu = cthdtt.HoaDon.GhiChu;
                }
                //_ChungTu = _factory.Get_ChungTu_ByMaChungTu(maChungTu);
                if (_ChungTu.MaChungTu != 0)
                {
                    _LoaiChungTu = _ChungTu.LoaiChungTu;
                    GanBindingSource();
                    _ngayLapCu = _ChungTu.NgayLap.Year > 1900 ? _ChungTu.NgayLap : _ChungTu.NgayThucHien;
                    dtmp_Ngay.EditValue = _ChungTu.NgayLap;
                    LoadDataAfterInitChungTu();
                    if (_LoaiChungTu.MaLoaiCTQuanLy == "PKT" || _LoaiChungTu.MaLoaiCTQuanLy == "PT111" || _LoaiChungTu.MaLoaiCTQuanLy == "PC112")//Bang Ke or PhieThu
                        TaoBindingDeNghiChuyenKhoan();

                    GanDuLieuChoTextDoiTac();
                    soChungTu = _ChungTu.MaChungTu;
                    btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    TongTien = _ChungTu.Tien.ThanhTien;
                    soTien = _ChungTu.Tien.SoTien;

                    if (_ChungTu.DoiTuong != 0)
                        MaDoiTuongtextEdit1.Text = DoiTuongAll.GetDoiTuongAll(_ChungTu.DoiTuong).MaQLDoiTuong;
                    else
                        MaDoiTuongtextEdit1.Text = "";
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
                //if (IsTaiKhoanThueKhauTru(bt.NoTaiKhoan))
                //{
                //    if (bt.ChungTu_HoaDonList.Count == 0)
                //    {
                //        MessageBox.Show("Vui lòng nhập hóa đơn cho Bút toán thuế!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return false;
                //    }
                //    else
                //    {
                //        decimal tongTienThueHoaDon = 0;
                //        foreach (ChungTu_HoaDon ct_hd in bt.ChungTu_HoaDonList)
                //        {
                //            tongTienThueHoaDon += ct_hd.HoaDon.TienThue;
                //        }
                //        if (bt.SoTien != tongTienThueHoaDon)
                //        {
                //            MessageBox.Show("Tổng Tiền Thuế Hóa đơn và Số tiền bút toán thuế không bằng nhau!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //            return false;
                //        }
                //    }
                //}
                #endregion //ButToanThue

                #region KiemTraHoanUng
                decimal tongtienTU = 0;
                foreach (ChungTu_ChungTuChild itemctRef in _ChungTu.ChungTu_ChungList)
                {
                    if (itemctRef.RefType == 1 && IsTaiKhoanTamUng(bt.CoTaiKhoan) && bt.DoiTuongCo == itemctRef.MaDoiTuong)
                    {
                        tongtienTU += itemctRef.SoTien;
                    }
                }
                if (tongtienTU != 0 && bt.SoTien != tongtienTU)
                {
                    MessageBox.Show("Tổng tiền Hoàn ứng của chứng từ kèm theo khác Số Tiền bút toán hoàn ứng, Không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                #endregion KiemTraHoanUng
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

        private bool KiemTraHoanUngHopLe()
        {
            bool coHoanUng = false;
            bool hoanUngHopLe = false;
            foreach (ChungTu_ChungTuChild itemctRef in _ChungTu.ChungTu_ChungList)
            {
                if (itemctRef.RefType == 1)
                {
                    coHoanUng = true;
                    foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
                    {
                        if (IsTaiKhoanTamUng(bt.CoTaiKhoan) && bt.DoiTuongCo == itemctRef.MaDoiTuong)
                        {
                            hoanUngHopLe = true;
                        }
                    }
                }
                if (coHoanUng && hoanUngHopLe == false)
                {
                    MessageBox.Show("Vui lòng nhập bút toán hoàn ứng theo chứng từ hoàn ứng kèm theo!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
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

        private void CapNhatSoTienHoanUngButToan()
        {
            foreach (ButToan itemButToan in _ChungTu.DinhKhoan.ButToan)
            {
                if (IsTaiKhoanTamUng(itemButToan.CoTaiKhoan))
                {
                    decimal tongtienTU = 0;
                    foreach (ChungTu_ChungTuChild itemctRef in _ChungTu.ChungTu_ChungList)
                    {
                        if (itemctRef.RefType == 1 && itemButToan.DoiTuongCo == itemctRef.MaDoiTuong)
                        {
                            tongtienTU += itemctRef.SoTien;
                        }
                    }
                    itemButToan.SoTien = tongtienTU;
                }
            }
            tblButToanBindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;
            TinhSoTienChungTu();
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
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ChungTu.NgayLap.Year > 1900 ? _ChungTu.NgayLap : _ChungTu.NgayThucHien);
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
            if (KiemTraTamUng() == false)
            {
                return false;
            }
            //Be Kiem tra ChungTu Hoa Don Thanh Toan
            if (!checkChonHoaDon)
                if (KiemTraHoaDonTaoMoiHopLe() == false) return false;

            //decimal tongtienthanhtoan = 0;
            //foreach (ChungTu_HoaDonThanhToan itemct_hd in _ChungTu.ChungTu_HoaDonThanhToanList)
            //{
            //    if (itemct_hd.SoTienThanhToan == 0)
            //    {
            //        MessageBox.Show(this, "Vui lòng nhập số tiền thanh toán của Hóa đơn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return false;
            //    }
            //    tongtienthanhtoan += itemct_hd.SoTienThanhToan;
            //}
            //if (_ChungTu.ChungTu_HoaDonThanhToanList.Count>0 && _ChungTu.Tien.ThanhTien != tongtienthanhtoan)
            //{
            //    MessageBox.Show(this, "Giá trị Chứng từ không bằng tổng tiền thanh toán của Hóa đơn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    calcEdit_SoTien.Focus();
            //    return false;
            //}

            //End Kiem tra ChungTu Hoa Don Thanh Toan

            if (KiemTraButToanHopLe() == false)
                return false;

            if (KiemTraHoanUngHopLe() == false)
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
                        //foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
                        //{
                        //    foreach (ChungTu_ChiPhiSanXuat cpsx in bt.ChungTuChiPhiSanXuatList)
                        //    {
                        //        //ChiThuLao
                        //        foreach (ChiThuLao ctl in cpsx.ChiThuLaoList)
                        //        {
                        //            ctl.MaChungTu = _ChungTu.MaChungTu;
                        //            ctl.SoChungTu = _ChungTu.SoChungTu;
                        //        }
                        //        //ChiPhiThucHien
                        //        foreach (ChiPhiThucHien cpth in cpsx.ChiPhiThucHienList)
                        //        {
                        //            cpth.MaChungTu = _ChungTu.MaChungTu;
                        //            cpth.TenChungTu = _ChungTu.SoChungTu;
                        //        }

                        //    }
                        //}
                        #endregion //BS Chi ThuLa0
                        _ChungTu.ApplyEdit();
                        _ChungTu.Save();
                    }
                    _taoMoiChungTu = false;
                    _ngayLapCu = _ChungTu.NgayLap.Year > 1900 ? _ChungTu.NgayLap : _ChungTu.NgayThucHien;
                    //Tiến hành cập nhật lại mã chứng từ chí phí (nếu có)
                    //if (_chiThuLaoList_DaChon != null && _chiThuLaoList_DaChon.Count > 0)
                    //{
                    //    foreach (ButToan itemButToan in _ChungTu.DinhKhoan.ButToan)
                    //    {
                    //        foreach (ChungTu_ChiPhiSanXuat itemChungTu in itemButToan.ChungTuChiPhiSanXuatList)
                    //        {
                    //            foreach (ChiThuLao item in _chiThuLaoList_DaChon)
                    //            {
                    //                if (item.MaChuongTrinh == itemChungTu.MaChuongTrinh)
                    //                {
                    //                    CapNhatMaButToanChiPhiSanXuat(itemChungTu.MactChiphisanxuat, item.MaBoPhanGui, item.MaChuongTrinh, item.SoDNCK, item.LoaiNV);
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                    DialogUtil.ShowSaveSuccessful();
                    return true;

                }
                catch (Exception ex)
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
                    cm.CommandTimeout = 900;
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
        private void LoadDataControlLienQuanTheoDoiTuong(long maDoiTuong)
        {
            if (maDoiTuong != 0)
            {
                dtKhachHang = DoiTuongAll.GetDoiTuongAll(maDoiTuong);
                MaDoiTuongtextEdit1.Text = dtKhachHang.MaQLDoiTuong;
                if (_ChungTu != null && _ChungTu.ChungTu_DiaChi != null)
                {
                    //if (_ChungTu.ChungTu_DiaChi.DiaChi.Trim() == "")
                    txt_DiaChiDoiTuongNhan.Text = dtKhachHang.DiaChi;
                    //if (_ChungTu.ChungTu_DiaChi.Ten.Trim() == "")
                    NguoiNhan_textEdit1.Text = dtKhachHang.TenDoiTuong;
                }

                _hopDongList = HopDongMuaBanList.GetHopDongMuaBanList_TheoDoiTac(maDoiTuong);
                _hopDongList.Insert(0, HopDongMuaBan.NewHopDongMuaBan(0, ""));
                HopDong_bindingSource.DataSource = _hopDongList;

            }
        }

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


        private void DesignDoiTuongGridLookUpEdit()
        {
            HamDungChung.InitGridLookUpDev2(DoiTuongGridLookUpEdit, AllDoiTuong_bindingSource, "TenDoiTuong", "MaDoiTuong", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(DoiTuongGridLookUpEdit, new string[] { "TenDoiTuong", "MaQLDoiTuong", "TenCongTy", "Email", }, new string[] { "Tên đối tượng", "Mã đối tượng", "Tên Công Ty", "Email", }, new int[] { 120, 90, 120, 90 }, false);
            this.DoiTuongGridLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Thêm đối tượng", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None))});
            this.DoiTuongGridLookUpEdit.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.DoiTuongGridLookUpEdit_Properties_ButtonClick);
            //this.DoiTuongGridLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            //new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Thêm đối tượng", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Khác/Thêm", null, superToolTip5, true)});
            DoiTuongGridLookUpEdit.EditValueChanged += new System.EventHandler(this.DoiTuongGridLookUpEdit_EditValueChanged);
        }

        #endregion//DoiTuong

        #region NhanVien

        private void DesignNhanVien_gridLookUpEdit1()
        {
            HamDungChung.InitGridLookUpDev2(NhanVien_gridLookUpEdit1, NhanVienList_bindingSource, "TenDoiTuong", "MaDoiTuong", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(NhanVien_gridLookUpEdit1, new string[] { "TenDoiTuong", "MaQLDoiTuong", "TenCongTy", "Email", }, new string[] { "Nhân viên", "Mã QL", "Tên Công Ty", "Email", }, new int[] { 120, 90, 120, 90 }, false);
            NhanVien_gridLookUpEdit1.EditValueChanged += new System.EventHandler(this.NhanVien_gridLookUpEdit1_EditValueChanged);
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

        private bool KiemTraChungTuDeNghiHopLe(List<ChungTuReference> chungTuReferencelistSelected)
        {
            long madoituong = 0;
            if (_maDoiTuongDeNghi != 0)
            {
                madoituong = _maDoiTuongDeNghi;
            }
            else
            {
                madoituong = chungTuReferencelistSelected[0].MaDoiTuong;
            }
            foreach (ChungTuReference item in chungTuReferencelistSelected)
            {
                if (item.MaDoiTuong != madoituong)//Không Cùng Đối Tượng
                {
                    MessageBox.Show("Không cùng đối tượng lập!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }


        private void LapChungTuFromBienLai()
        {
            if (_ChungTu.IsNew == false)
            {
                KhoiTaoChungTuMoi();
                _taoMoiChungTu = true;//
            }
            string tendoituong = NguoiNhan_textEdit1.Text;
            int hinhthucthanhtoan = 0;
            if (_LoaiChungTu.MaLoaiCTQuanLy == "PT111")
            {
                hinhthucthanhtoan = 1;//TienMat
            }
            else if (_LoaiChungTu.MaLoaiCTQuanLy == "PKT" || _LoaiChungTu.MaLoaiCTQuanLy == "PT112")
            {
                hinhthucthanhtoan = 2;//ChuyenKhoan
            }
            #region Process
            FrmGetBienLaiFronOtherDB frm = new FrmGetBienLaiFronOtherDB(tendoituong, hinhthucthanhtoan, 6);
            if (frm.ShowDialog() != DialogResult.OK)
            {
                decimal tongtien = 0;
                StringBuilder diengiai = new StringBuilder("");
                List<ChiTietBienLaiFromOtherDB> chitietbienlailistSelected = frm.ChiTietBienLaiListSelected;//M
                if (chitietbienlailistSelected.Count != 0)//M
                {
                    if (KiemTraLapHoaDonTuBienLaiHopLe(chitietbienlailistSelected) == false) return;
                    _ChungTu.DoiTuong = chitietbienlailistSelected[0].MaDoiTuongInt;
                    _ChungTu.NgayThucHien = chitietbienlailistSelected[0].NgayLap.Date;
                    _ChungTu.NgayLap = _ChungTu.NgayThucHien;
                    _ChungTu.SoChungTu = PublicClass.SetSoChungTuByMaLoaiChungTu(_LoaiChungTu.MaLoaiCT, _ChungTu.NgayLap);

                    if (NguoiNhan_textEdit1.EditValue == null || NguoiNhan_textEdit1.Text == "")
                    {
                        NguoiNhan_textEdit1.EditValue = chitietbienlailistSelected[0].TenDoiTuong
                            + " - " + chitietbienlailistSelected[0].TenLop
                             + " - " + chitietbienlailistSelected[0].MaQLDoiTuong;
                    }

                    foreach (ChiTietBienLaiFromOtherDB ctbienlai in chitietbienlailistSelected)
                    {
                        bool insert = true;
                        if (_ChungTu.CT_ChungTuBienLaiList.Count > 0)
                        {
                            foreach (CT_ChungTuBienLaiChild item in _ChungTu.CT_ChungTuBienLaiList)
                            {
                                if (
                                    (ctbienlai.MaChiTiet != Guid.Empty && item.OidChiTietBienLai == ctbienlai.MaChiTiet)
                                     ||
                                     (ctbienlai.MaChiTietInt != 0 && item.IDChiTietBienLai == ctbienlai.MaChiTietInt)
                                    )
                                {
                                    insert = false;
                                    break;
                                }
                            }

                        }//grdViewCt_PhieuXuat.RowCount > 0

                        if (insert)
                        {
                            //Tao thanhTien
                            tongtien += ctbienlai.SoTien;
                            diengiai.Append(string.Format("{0},", ctbienlai.DienGiai));
                            //Tao CT_HoaDonBienLai
                            //CT_ChungTuBienLaiChild ct_chungtubienlai = CT_ChungTuBienLaiChild.NewCT_ChungTuBienLaiChild();
                            //ct_chungtubienlai.OidMaBienLai = ctbienlai.MaBienLai;
                            //ct_chungtubienlai.OidChiTietBienLai = ctbienlai.MaChiTiet;
                            //ct_chungtubienlai.IDBienLai = ctbienlai.MaBienLaiInt;
                            //ct_chungtubienlai.IDChiTietBienLai = ctbienlai.MaChiTietInt;
                            //_ChungTu.CT_ChungTuBienLaiList.Add(ct_chungtubienlai);
                            #region ButToan
                            _dinhKhoanTuDong = DinhKhoanTuDong.NewDinhKhoanTuDong();
                            _dinhKhoanTuDong = DinhKhoanTuDong.GetDinhKhoanTuDong(ctbienlai.DienGiai, _LoaiChungTu.MaLoaiCT, ctbienlai.MaTruongHocSinh);
                            if (_dinhKhoanTuDong != null)
                            {
                                #region Modify
                                ButToan btadd = ButToan.NewButToan();
                                //Dien Giai=[loai thu]+ [tên hoc sinh]+ [lớp]+[mã học sinh]
                                btadd.DienGiai = ctbienlai.NoiDungThu + " - " + ctbienlai.TenDoiTuong + " - " + ctbienlai.TenLop + " - " + ctbienlai.MaQLDoiTuong;
                                if (btadd.DienGiai.Contains(ctbienlai.NamHoc) == false)
                                {
                                    btadd.DienGiai = btadd.DienGiai + " - " + ctbienlai.NamHoc;
                                }
                                btadd.NoTaiKhoan = _dinhKhoanTuDong.TKNo;
                                btadd.CoTaiKhoan = _dinhKhoanTuDong.TKCo;
                                btadd.SoTien = ctbienlai.SoTien;
                                btadd.IDKhoanMuc = _dinhKhoanTuDong.IDKhoanMuc;

                                btadd.OidMaBienLai = ctbienlai.MaBienLai;
                                btadd.OidChiTietBienLai = ctbienlai.MaChiTiet;
                                btadd.IDBienLai = ctbienlai.MaBienLaiInt;
                                btadd.IDChiTietBienLai = ctbienlai.MaChiTietInt;
                                btadd.KieuThuPhi = ctbienlai.KieuThuPhiFNC;

                                if (ctbienlai.MaTruongHocSinh != "")
                                {
                                    BoPhan bp = BoPhan.GetBoPhan_MaBoPhanQL(ctbienlai.MaTruongHocSinh);
                                    btadd.MaDonVi = bp.MaBoPhan;
                                }

                                XuLyDoiTuongTheoDoi(btadd);

                                _ChungTu.DinhKhoan.ButToan.Add(btadd);
                                #endregion//Modify
                                #region Old
                                //bool insertButToan = false;
                                //if (_ChungTu.DinhKhoan.ButToan == null || _ChungTu.DinhKhoan.ButToan.Count == 0)
                                //{
                                //    insertButToan = true;
                                //}
                                //else
                                //{
                                //    foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
                                //    {
                                //        if (bt.NoTaiKhoan == _dinhKhoanTuDong.TKNo && bt.CoTaiKhoan == _dinhKhoanTuDong.TKCo)
                                //        {
                                //            bt.DienGiai = string.Format("{0},{1}", bt.DienGiai, ctbienlai.DienGiai);
                                //            bt.SoTien += ctbienlai.SoTien;
                                //            insertButToan = false;
                                //        }
                                //        else
                                //        {
                                //            insertButToan = true;
                                //        }
                                //    }
                                //}
                                //if (insertButToan)
                                //{
                                //    ButToan btadd = ButToan.NewButToan();
                                //    btadd.DienGiai = ctbienlai.DienGiai;
                                //    btadd.NoTaiKhoan = _dinhKhoanTuDong.TKNo;
                                //    btadd.CoTaiKhoan = _dinhKhoanTuDong.TKCo;
                                //    btadd.SoTien = ctbienlai.SoTien;
                                //    _ChungTu.DinhKhoan.ButToan.Add(btadd);
                                //}
                                #endregion//Old
                            }

                            #endregion//end  ButToan
                        }
                    }
                    //
                    _ChungTu.Tien.ThanhTien = tongtien;
                    if (diengiai.Length > 1)
                    {
                        diengiai.Remove(diengiai.Length - 1, 1);
                        _ChungTu.DienGiai = diengiai.ToString();
                    }
                }
            }
            #endregion//Process
            GanBindingSource();
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
                //currentButToan.DoiTuongNo = 0;
                if (taiKhoanNo.CoDoiTuongTheoDoi == true && currentButToan.DoiTuongNo == 0)
                {
                    if (_maDoiTuongDeNghi != 0)
                        currentButToan.DoiTuongNo = _maDoiTuongDeNghi;
                    else
                        currentButToan.DoiTuongNo = _ChungTu.DoiTuong;
                }


            }
            //Co
            if (taiKhoanCo.MaTaiKhoan != 0)
            {
                //currentButToan.DoiTuongCo = 0;
                if (taiKhoanCo.CoDoiTuongTheoDoi == true && currentButToan.DoiTuongCo == 0)
                {
                    if (_maDoiTuongDeNghi != 0)
                        currentButToan.DoiTuongCo = _maDoiTuongDeNghi;
                    else
                        currentButToan.DoiTuongCo = _ChungTu.DoiTuong;
                }
            }
            #endregion//Xu ly Doi Tuong No Co
        }

        private bool KiemTraButToanThueTruocKhiXoaButToan()
        {
            ////Kiem Tra có Chứng Từ Biên Lai - Không Thể Xóa
            //if (_ChungTu.CT_ChungTuBienLaiList != null && _ChungTu.CT_ChungTuBienLaiList.Count > 0)
            //{
            //    MessageBox.Show("Chứng từ này được lập từ biên lai, không thể xóa bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            //int[] deleteRows = gridView_ButToan.GetSelectedRows();
            //foreach (int deleteRow in deleteRows)
            //{
            //    ButToan buttoan = gridView_ButToan.GetRow(deleteRow) as ButToan;
            //    if (IsTaiKhoanThueKhauTru(buttoan.NoTaiKhoan))
            //    {
            //        if (_ChungTu_HoaDonThanhToanList.Count() > 0)
            //        {
            //            MessageBox.Show("Đã có Hóa đơn thuế, không thể xóa bút toán thuế", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }
            //    }
            //    if (IsTaiKhoanThuePhaiNop(buttoan.CoTaiKhoan))
            //    {
            //        if (PublicClass.KiemTraChungTuDaLapHoaDon(_ChungTu.MaChungTu, buttoan.MaButToan))
            //        {
            //            MessageBox.Show("Đã lập Hóa đơn bán ra, không thể xóa bút toán thuế", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }
            //    }

            //}
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
            #region Hoa Don Co Thue
            //LoadButToanThuePhaiNop();
            //if (_ButToanThuePhaiNop.MaButToan == 0)
            //{
            //    MessageBox.Show(this, "Vui lòng hạch toán tài khoản thuế phải nộp!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (PublicClass.KiemTraChungTuDaLapHoaDon(_ChungTu.MaChungTu, _ButToanThuePhaiNop.MaButToan))
            //{
            //    if (MessageBox.Show("Chứng từ đã lập hóa đơn, bạn có muốn xem lại hóa đơn?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        HoaDon _HoaDon = HoaDon.NewHoaDon();
            //        _HoaDon = HoaDon.GetHoaDonByButToanThuePhaiNop(_ButToanThuePhaiNop.MaButToan);
            //        frmHoaDonDichVuBanRa _frmHoaDonDichVu = new frmHoaDonDichVuBanRa(_HoaDon);
            //        _frmHoaDonDichVu.Show();
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            //else
            //{
            //    frmHoaDonDichVuBanRa frm = new frmHoaDonDichVuBanRa(_ButToanThuePhaiNop, _ChungTu.ChungTu_DiaChi.Ten, _ChungTu.Tien.ThanhTien, _ChungTu.MaPhuongThucThanhToan);
            //    frm.ShowDialog();
            //}
            #endregion//Hoa Don Co Thue

            #region Hoa Don K rang buoc Co Thue
            if (PublicClass.KiemTraChungTuDaLapHoaDon(_ChungTu.MaChungTu, 0))
            {
                if (MessageBox.Show("Chứng từ đã lập hóa đơn, bạn có muốn xem lại hóa đơn?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HoaDon _HoaDon = HoaDon.NewHoaDon();
                    _HoaDon = HoaDon.GetHoaDonBanRaByChungTu(_ChungTu.MaChungTu);
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
                frmHoaDonDichVuBanRa frm = new frmHoaDonDichVuBanRa(_ChungTu);
                frm.ShowDialog();
            }
            #endregion//Hoa Don K rang buoc  Co Thue
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
            XuLyTamUng();
        }

        private bool KiemTraHoaDonTaoMoiHopLe()
        {
            foreach (ChungTu_HoaDonThanhToan ct_hd in _ChungTu.ChungTu_HoaDonThanhToanList)
            {
                if (HoaDon.KiemTraTrungSoHoaDon(ct_hd.HoaDon.SoHoaDon, ct_hd.HoaDon.MauHoaDon, ct_hd.HoaDon.KyHieuMauHoaDon, ct_hd.HoaDon.MaHoaDon, ct_hd.HoaDon.NgayLap, ct_hd.HoaDon.SoSerial,_ChungTu.MaChungTu) > 0)
                {
                    MessageBox.Show("Trùng Ký hiệu mẫu hóa đơn và Số hóa đơn, không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void CreateChungTuFromHoaDon(HoaDon hoadon)
        {
            decimal tongtienbt = 0;
            _ChungTu.NgayLap = hoadon.NgayLap;
            _ChungTu.NgayThucHien = hoadon.NgayLap;
            _ChungTu.SoChungTu = PublicClass.SetSoChungTuByMaLoaiChungTu(_LoaiChungTu.MaLoaiCT, _ChungTu.NgayLap);
            _ChungTu.DoiTuong = hoadon.MaDoiTac;
            if (_ChungTu.DoiTuong == 0)
            {
                HoaDon_DoiTac hdDOitac = HoaDon_DoiTac.GetHoaDon_DoiTacByHoaDon(hoadon.MaHoaDon);
                _ChungTu.ChungTu_DiaChi.Ten = hdDOitac.TenDoiTac;
                _ChungTu.ChungTu_DiaChi.DiaChi = hdDOitac.DiaChi;
                //txt_DiaChiDoiTuongNhan.Text = hdDOitac.DiaChi;
                //NguoiNhan_textEdit1.Text = hdDOitac.TenDoiTac;
            }
            else
            {
                LoadDataControlLienQuanTheoDoiTuong(_ChungTu.DoiTuong);
            }
            _ChungTu.DienGiai = hoadon.GhiChu;
            //foreach (CT_HoaDonDichVu itemctHD in hoadon.CT_HoaDonDichVuList)
            //{
            //    ButToan btadd = ButToan.NewButToan();
            //    btadd.SoTien = itemctHD.ThanhTien;
            //    btadd.DienGiai = itemctHD.TenHangHoaDichVu;
            //    btadd.DoiTuongNo = itemctHD.MaDoiTac;
            //    _ChungTu.Tien.ThanhTien += itemctHD.ThanhTien;
            //    _ChungTu.DinhKhoan.ButToan.Add(btadd);

            //}
            if (hoadon.CT_HoaDonDichVuList.Count > 0)
            {
                foreach (CT_HoaDonDichVu cthddv in hoadon.CT_HoaDonDichVuList)
                {
                    ChungTu_HoaDonThanhToan item = ChungTu_HoaDonThanhToan.NewChungTu_HoaDonThanhToan();
                    item.MaHoaDon = cthddv.MaHoaDon;
                    item.MaDoiTac = cthddv.MaDoiTac;
                    item.TienThue = cthddv.TienThue;
                    item.DienGiai = cthddv.TenHangHoaDichVu;
                    item.SoTienThanhToan = cthddv.ThanhTien;

                    HoaDon hd = HoaDon.GetHoaDon(hoadon.MaHoaDon);
                    item.HoaDon = hd;
                    item.HoaDon.ThanhTien = cthddv.ThanhTien;
                    item.HoaDon.TongTien = item.HoaDon.ThanhTien + item.HoaDon.ThueVAT;
                    item.HoaDon.MaDoiTac = cthddv.MaDoiTac;
                    item.HoaDon.GhiChu = cthddv.TenHangHoaDichVu;

                    if (item.MaHoaDon == 0)
                        item.MaHoaDon = hoadon.MaHoaDon;
                    //gan hoa don de hien thi

                    _ChungTu.ChungTu_HoaDonThanhToanList.Add(item);
                    checkChonHoaDon = true;
                }
            }
            else
            {
                ChungTu_HoaDonThanhToan ct_hoadon = ChungTu_HoaDonThanhToan.NewChungTu_HoaDonThanhToan(hoadon);
                ct_hoadon.MaDoiTac = ct_hoadon.HoaDon.MaDoiTac;
                _ChungTu.ChungTu_HoaDonThanhToanList.Add(ct_hoadon);
                checkChonHoaDon = true;
            }
            //mac dinh tai khoan co la TK doanh thu
            //int TKco = LoaiChungTuDev.GetLoaiChungTuDev(_LoaiChungTu.MaLoaiCT).TKCo;
            int TKco = HeThongTaiKhoan1.LayMaTaiKhoan("5113");
            foreach (ChungTu_HoaDonThanhToan cthdtt in _ChungTu.ChungTu_HoaDonThanhToanList)
            {
                ButToan bt = ButToan.NewButToan();
                //bt.SoTien = cthdtt.SoTienThanhToan;
                bt.SoTien = cthdtt.HoaDon.ThanhTien + cthdtt.HoaDon.TienThue;
                bt.DoiTuongNo = cthdtt.MaDoiTac;
                bt.CoTaiKhoan = TKco;
                if (cthdtt.HoaDon.CT_HoaDonDichVuList.Count > 0)
                {
                    if (cthdtt.MaDoiTac != 0)
                    {
                        DoiTac doitac = DoiTac.GetDoiTac(cthdtt.MaDoiTac);
                        if (cthdtt.DienGiai.Contains(doitac.TenDoiTac + ""))
                            bt.DienGiai = cthdtt.DienGiai;
                        else
                            bt.DienGiai = cthdtt.DienGiai + " - " + doitac.TenDoiTac + " - " + doitac.MaQLDoiTac;
                    }
                }
                else
                    bt.DienGiai = cthdtt.HoaDon.GhiChu;
                tongtienbt += bt.SoTien;
                _ChungTu.DinhKhoan.ButToan.Add(bt);
            }
            _ChungTu.Tien.ThanhTien = tongtienbt;
            ChungTuHoaDonThanhToan_bindingSource.DataSource = _ChungTu.ChungTu_HoaDonThanhToanList;
            GanBindingSource();
        }

        #region Modify TamUng
        private void XuLyTamUng()
        {
            bool coTamUng = false;
            bool coDoiTuong = false;
            foreach (ButToan buttoan in _ChungTu.DinhKhoan.ButToan)
            {
                if (IsTaiKhoanTamUng(buttoan.NoTaiKhoan) || IsTaiKhoanTamUng(buttoan.CoTaiKhoan))
                {
                    coTamUng = true;
                    foreach (TamUng tu in _ChungTu.TamUngList)
                    {
                        if (tu.MaDoiTuong == buttoan.DoiTuongNo || tu.MaDoiTuong == buttoan.DoiTuongCo)
                        {
                            coDoiTuong = true;
                            tu.DienGiai = buttoan.DienGiai;
                            tu.SoTien = buttoan.SoTien;
                        }
                    }
                }
                if (coTamUng && coDoiTuong == false)
                {
                    CreateTamUng(buttoan);
                }

            }
            if (coTamUng == false)
            {
                _ChungTu.TamUngList.Clear();
            }
        }
        private void CreateTamUng(ButToan buttoan)
        {
            if (IsTaiKhoanTamUng(buttoan.NoTaiKhoan) && buttoan.DoiTuongNo != 0)
            {
                TamUng tu = TamUng.NewTamUng();
                tu.LoaiChungTu = _ChungTu.LoaiChungTu.MaLoaiCT; ;
                tu.MaDoiTuong = buttoan.DoiTuongNo;
                tu.DienGiai = buttoan.DienGiai;
                tu.NgayLap = _ChungTu.NgayLap;
                tu.SoTien = buttoan.SoTien;
                tu.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                _ChungTu.TamUngList.Add(tu);
            }
            else if (IsTaiKhoanTamUng(buttoan.CoTaiKhoan) && buttoan.DoiTuongCo != 0)
            {
                TamUng tu = TamUng.NewTamUng();
                tu.LoaiChungTu = _ChungTu.LoaiChungTu.MaLoaiCT; ;
                tu.MaDoiTuong = buttoan.DoiTuongCo;
                tu.DienGiai = buttoan.DienGiai;
                tu.NgayLap = _ChungTu.NgayLap;
                tu.SoTien = buttoan.SoTien;
                tu.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                _ChungTu.TamUngList.Add(tu);
            }
        }

        private bool KiemTraTamUng()
        {
            foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
            {
                if ((IsTaiKhoanTamUng(bt.NoTaiKhoan) && bt.DoiTuongNo == 0)
                    ||
                    (IsTaiKhoanTamUng(bt.CoTaiKhoan) && bt.DoiTuongCo == 0)
                    )
                {
                    MessageBox.Show("Vui lòng nhập đối tượng tạm ứng!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            foreach (TamUng tu in _ChungTu.TamUngList)
            {
                if (tu.MaDoiTuong == 0)
                {
                    MessageBox.Show("Vui lòng nhập đối tượng tạm ứng!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }
        #endregion Modify TamUng

        #endregion Functions

        #region Initialize

        public FrmChungTuKeToanCustomize(ChungTuCustomize chungtuCus)
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
                dtmp_Ngay.EditValue = _ChungTu.NgayLap;
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
            int i = 0;
            //load lại hoa don da gan vao
            foreach (ChungTu_HoaDonThanhToan cthdtt in _ChungTu.ChungTu_HoaDonThanhToanList)
            {
                cthdtt.HoaDon.ThanhTien = cthdtt.SoTienThanhToan;
                //cthdtt.HoaDon.ThueSuatVAT = cthdtt.HoaDon.ThueSuatVAT;
                //cthdtt.HoaDon.TienThue = cthdtt.HoaDon.ThanhTien * (decimal)(cthdtt.HoaDon.ThueSuatVAT / 100);
                cthdtt.HoaDon.ThueVAT = cthdtt.HoaDon.ThanhTien * (decimal)(cthdtt.HoaDon.ThueSuatVAT / 100);
                if (cthdtt.HoaDon.ThueSuatVAT == -1)
                    cthdtt.HoaDon.ThueVAT = 0;
                cthdtt.HoaDon.MaDoiTac = cthdtt.MaDoiTac;
                cthdtt.HoaDon.GhiChu = cthdtt.HoaDon.CT_HoaDonDichVuList[i].TenHangHoaDichVu;
                i++;
            }
            btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }


        public FrmChungTuKeToanCustomize()
        {
            InitializeComponent();
        }

        public FrmChungTuKeToanCustomize(PhanBoChiPhiCCDC phanBoChiPhiCCDC)
        {
            InitializeComponent();
            _LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDevByMaQuanLy("PKT");
            FormatForm();
            _taoMoiChungTu = true;
            KhoiTao();
            LoadDaTa();
            _phanBoChiPhiCCDC = phanBoChiPhiCCDC;
            decimal tongTien = 0;
            foreach (CT_PhanBoChiPhiCCDC ct in _phanBoChiPhiCCDC.CT_PhanBoChiPhiCCDCList)
            {
                tongTien += ct.SoTienPhanBo;
            }
            _ChungTu.Tien.ThanhTien = tongTien;
            _ChungTu.DienGiai = ((_phanBoChiPhiCCDC.DienGiai == null || _phanBoChiPhiCCDC.DienGiai == "" || _phanBoChiPhiCCDC.DienGiai == String.Empty) ? "Chi phí Phân bổ CCDC" : phanBoChiPhiCCDC.DienGiai);
            _ChungTu.SoChungTuKemTheo = 1;
            _ChungTu.ChungTuKemTheo = _phanBoChiPhiCCDC.SoChungTu;
            _ChungTu.MaChungTuQL = _phanBoChiPhiCCDC.SoChungTu;
            ButToan butToan = ButToan.NewButToan();
            butToan.NoTaiKhoan = HeThongTaiKhoan1.LayMaTaiKhoan("6423");
            butToan.CoTaiKhoan = HeThongTaiKhoan1.LayMaTaiKhoan("2421");
            butToan.SoTien = tongTien;
            butToan.DienGiai = ((_phanBoChiPhiCCDC.DienGiai == null || _phanBoChiPhiCCDC.DienGiai == "" || _phanBoChiPhiCCDC.DienGiai == String.Empty) ? "Chi phí Phân bổ CCDC" : phanBoChiPhiCCDC.DienGiai);
            _ChungTu.DinhKhoan.ButToan.Add(butToan);
        }

        public FrmChungTuKeToanCustomize(ChungTu chungTu)
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

        public FrmChungTuKeToanCustomize(HoaDon hoadon)
        {
            InitializeComponent();
            _LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDevByMaQuanLy("PKT");
            _taoMoiChungTu = true;
            FormatForm();
            KhoiTao();
            LoadDaTa();
            CreateChungTuFromHoaDon(hoadon);
        }

        //====goi tu report hoac form khac
        public FrmChungTuKeToanCustomize(long maChungTu)
        {
            InitializeComponent();

            ChungTuList ct = ChungTuList.GetChungTuListByMaChungTu_New(maChungTu);
            if (ct.Count > 0)
            {
                this._ChungTu = ct[0];
            }
            if (this._ChungTu.MaChungTu == 0) return;

            _ngayLapCu = _ChungTu.NgayLap.Year > 1900 ? _ChungTu.NgayLap : _ChungTu.NgayThucHien;
            _LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDevByMaQuanLy("PKT");
            _taoMoiChungTu = false;
            _maChungTuGhiTangCuCanXemLai = _ChungTu.MaChungTu;
            TongTien = _ChungTu.Tien.ThanhTien;
            soTien = _ChungTu.Tien.SoTien;
            KhoiTao();
            LoadDaTa();
            LoadDoiTuongList();
            btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            FormatForm();

            int i = 0;
            //load lại hoa don da gan vao
            foreach (ChungTu_HoaDonThanhToan cthdtt in _ChungTu.ChungTu_HoaDonThanhToanList)
            {
                cthdtt.HoaDon.ThanhTien = cthdtt.SoTienThanhToan;
                //cthdtt.HoaDon.ThueSuatVAT = cthdtt.HoaDon.ThueSuatVAT;
                //cthdtt.HoaDon.TienThue = cthdtt.HoaDon.ThanhTien * (decimal)(cthdtt.HoaDon.ThueSuatVAT / 100);
                cthdtt.HoaDon.ThueVAT = cthdtt.HoaDon.ThanhTien * (decimal)(cthdtt.HoaDon.ThueSuatVAT / 100);
                if (cthdtt.HoaDon.ThueSuatVAT == -1)
                    cthdtt.HoaDon.ThueVAT = 0;
                cthdtt.HoaDon.MaDoiTac = cthdtt.MaDoiTac;
                cthdtt.HoaDon.GhiChu = cthdtt.HoaDon.CT_HoaDonDichVuList[i].TenHangHoaDichVu;
                i++;
            }

            GanBindingSource();
            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);

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
                if (gridView_ButToan.FocusedColumn.Name == "colNoTaiKhoan")
                {
                    if (currentButToan != null && currentButToan.NoTaiKhoan != 0 && IsTaiKhoanTamUng(currentButToan.NoTaiKhoan) && currentButToan.DoiTuongNo == 0)
                    {
                        currentButToan.DoiTuongNo = _ChungTu.DoiTuong;
                        //LoadFormTamUng(currentButToan.NoTaiKhoan);
                    }
                }
                else if (gridView_ButToan.FocusedColumn.Name == "colCoTaiKhoan")
                {
                    if (currentButToan.CoTaiKhoan != 0 && IsTaiKhoanTamUng(currentButToan.CoTaiKhoan) && currentButToan.DoiTuongCo == 0)
                    {
                        currentButToan.DoiTuongCo = _ChungTu.DoiTuong;
                        //LoadFormTamUng(currentButToan.CoTaiKhoan);
                    }
                }
                #endregion Hết tạm ứng
            }
            else if (currentButToan != null && gridView_ButToan.FocusedColumn.FieldName == "SoTien")
            {
                TinhSoTienChungTu();
            }
            else if (currentButToan != null && gridView_ButToan.FocusedColumn.FieldName == "SoTienNgoaiTe")
            {
                currentButToan.SoTien = currentButToan.SoTienNgoaiTe * _ChungTu.Tien.TiGiaQuyDoi;
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
            else if (e.KeyCode == Keys.F8)
            {
                //if (gridView_ButToan.FocusedColumn.Name.ToLower() == "coldoituongno")
                //{
                    ButToan bt = (ButToan)tblButToanBindingSource.Current;
                    if (bt == null)
                        return;

                    DataSet ds = new DataSet();
                    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                    {
                        cn.Open();
                        //tao MainData
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandTimeout = 3000;
                            //cm.CommandText = "spd_BangCanDoiSoPhatSinh_DoiTuong_Modify";
                            DateTime tuNgay;
                            if (_ChungTu.NgayLap.Month >= 7)
                                tuNgay = new DateTime(_ChungTu.NgayLap.Year, 7, 1);
                            else
                                tuNgay = new DateTime(_ChungTu.NgayLap.Year -1 , 7, 1);

                            cm.CommandText = "spRpt_TongHopCongNoDoiTuong";
                            cm.Parameters.AddWithValue("@MaTaiKhoan", 0);
                            cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                            cm.Parameters.AddWithValue("@DenNgay", _ChungTu.NgayLap.Date);
                            cm.Parameters.AddWithValue("@MaBoPhan", 0);
                            cm.Parameters.AddWithValue("@MaDoiTuong", bt.DoiTuongNo);
                            cm.Parameters.AddWithValue("@UserId", UserId);
                            SqlDataAdapter da = new SqlDataAdapter(cm);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dt.TableName = "MainData";
                            ds.Tables.Add(dt);
                        }
                    }

                    frmShowReportForGrid frmGrid = new frmShowReportForGrid("Method_BangTongHopCongNoDoiDoiTuong", ds);
                    frmGrid.Show();
                    return;
                //}
            }
        }

        private void gridView_ButToan_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            #region Modify Method
            #region New
            decimal tongtienHoaDon = 0;
            if (_ChungTu.ChungTu_HoaDonThanhToanList.Count > 0)
            {
                foreach (ChungTu_HoaDonThanhToan ct_hd in _ChungTu.ChungTu_HoaDonThanhToanList)
                {
                    tongtienHoaDon += ct_hd.HoaDon.TongTien;
                }
            }
            ButToan buttoan = this.gridView_ButToan.GetRow(e.RowHandle) as ButToan;
            if (buttoan != null)
            {
                SetTaiKhoanDefaultForNewFirstButtoan(buttoan);
                buttoan.DienGiai = txt_DienGiai.EditValue.ToString();
                buttoan.SoTien = tongtienHoaDon;
                TinhSoTienChungTu();
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
            CapNhatSoTienHoanUngButToan();
        }

        private void gridView_DSDeNghi_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ChungTu_ChungTuChild currentCTRef = (ChungTu_ChungTuChild)ChungTu_ChungTuListbindingSource.Current;
            if (currentCTRef != null && currentCTRef.RefType == 1 && gridView_DSDeNghi.FocusedColumn.FieldName == "SoTien")
            {
                decimal chitamung = PublicClass.GetSoTienHoanUng(currentCTRef.IDChungTu, currentCTRef.IDChungTuRef, currentCTRef.MaDoiTuong);
                if (currentCTRef.SoTien > chitamung)
                {
                    MessageBox.Show("Hoàn ứng vượt quá sô tiền tạm ứng còn lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    currentCTRef.SoTien = chitamung;
                }
                CapNhatSoTienHoanUngButToan();

            }
        }
        #endregion//gridView_DSDeNghi

        #region ChungTu_HoaDon

        private void DeleteChungTu_HoaDonThanhToanList()
        {
            if (ChungTu_HoaDonThanhToangridView.RowCount > 0)
            {
                if (ChungTu_HoaDonThanhToangridView.GetSelectedRows().Length > 0)
                {
                    if (MessageBox.Show(String.Format("Bạn có muốn xóa {0} dòng được chọn không?", ChungTu_HoaDonThanhToangridView.GetSelectedRows().Length), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ChungTu_HoaDonThanhToangridView.DeleteSelectedRows();
                        this.isChonHoaDon = true;
                    }
                }
            }
        }

        private void ChungTu_HoaDonThanhToangridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (CheckCoTaiKhoanBiKhoaTrongButToan())
                {
                    MessageBox.Show(this, "Đã khóa sổ tài khoản, không thể thực hiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DeleteChungTu_HoaDonThanhToanList();

            }
        }

        private void ChungTu_HoaDonThanhToangridView_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            #region Rang Buoc TK Thue
            //LoadButToanThue();
            //if (IsTaiKhoanThueKhauTru(_ButToanThue.NoTaiKhoan) == false)
            //{
            //    MessageBox.Show(this, "Vui lòng chọn tài khoản thuế!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    GridView view = sender as GridView;
            //    BeginInvoke(new MethodInvoker(view.CancelUpdateCurrentRow));
            //}
            //else if (_ButToanThue.SoTien == 0)
            //{
            //    MessageBox.Show(this, "Vui lòng nhập số tiền của bút toán!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    GridView view = sender as GridView;
            //    BeginInvoke(new MethodInvoker(view.CancelUpdateCurrentRow));
            //}
            //else
            //{
            //    ChungTu_HoaDon currentCT_HD = (ChungTu_HoaDon)ChungTuHoaDonThanhToan_bindingSource.Current;
            //    currentCT_HD.HoaDon.MaDoiTac = _ChungTu.DoiTuong;
            //    //"HoaDon.ThanhTien", "HoaDon.ThueSuatVAT", "HoaDon.ThueVAT"
            //    currentCT_HD.HoaDon.ThanhTien = _ChungTu.Tien.ThanhTien - _ButToanThue.SoTien;
            //    if (_ButToanThue.SoTien > 0)
            //    {
            //        double thuesuat = 0;
            //        thuesuat = (double)((_ChungTu.Tien.ThanhTien - _ButToanThue.SoTien) / _ButToanThue.SoTien);
            //        if (thuesuat < 3)
            //        {
            //            currentCT_HD.HoaDon.ThueSuatVAT = 0;
            //        }
            //        else if (thuesuat < 8)
            //        {
            //            currentCT_HD.HoaDon.ThueSuatVAT = 5;
            //        }
            //        else
            //        {
            //            currentCT_HD.HoaDon.ThueSuatVAT = 10;
            //        }
            //        //currentCT_HD.HoaDon.ThueSuatVAT = (double)((_ChungTu.Tien.ThanhTien - _ButToanThue.SoTien) / _ButToanThue.SoTien);
            //    }
            //} 
            #endregion Rang Buoc TK Thue

            #region Khong Rang Buoc TK Thue
            ChungTu_HoaDonThanhToan currentCT_HD = (ChungTu_HoaDonThanhToan)ChungTuHoaDonThanhToan_bindingSource.Current;
            currentCT_HD.HoaDon.MaDoiTac = _ChungTu.DoiTuong;
            currentCT_HD.HoaDon.LoaiHoaDon = 4;//Hoa Don Mua vao
            ////"HoaDon.ThanhTien", "HoaDon.ThueSuatVAT", "HoaDon.ThueVAT"
            //decimal tongtienThanhToan = 0;
            //foreach (ChungTu_HoaDonThanhToan item in _ChungTu.ChungTu_HoaDonThanhToanList)
            //{
            //    tongtienThanhToan += item.SoTienThanhToan;
            //}
            //currentCT_HD.HoaDon.ThanhTien = _ChungTu.Tien.ThanhTien - tongtienThanhToan;
            //currentCT_HD.SoTienThanhToan = _ChungTu.Tien.ThanhTien - tongtienThanhToan;
            currentCT_HD.HoaDon.ThanhTien = _ChungTu.Tien.ThanhTien;

            #endregion Khong Rang Buoc TK Thue

            this.isChonHoaDon = true;
        }

        private void ChungTu_HoaDonThanhToangridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ChungTu_HoaDonThanhToan currentct_hd = (ChungTu_HoaDonThanhToan)ChungTuHoaDonThanhToan_bindingSource.Current;
            if (currentct_hd != null && ChungTu_HoaDonThanhToangridView.FocusedColumn.FieldName == "SoTienThanhToan")
            {
                //int hople = 0;
                //if (currentct_hd.MaHoaDon != 0)
                //{
                //    if (currentct_hd.SoTienThanhToan > HoaDon.GetSoTienConLaiHoaDon(currentct_hd.MaHoaDon, _ChungTu.MaChungTu))
                //    {
                //        hople = 1;
                //    }
                //}
                //else if (currentct_hd.SoTienThanhToan > currentct_hd.HoaDon.TongTien)
                //{
                //    hople = 2;
                //}
                //if (hople != 0)
                //{
                //    MessageBox.Show("Số tiền thanh toán vượt quá số tiền còn lại của hóa đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    if (hople == 1) currentct_hd.SoTienThanhToan = HoaDon.GetSoTienConLaiHoaDon(currentct_hd.MaHoaDon, _ChungTu.MaChungTu);
                //    else if (hople == 2) currentct_hd.SoTienThanhToan = currentct_hd.HoaDon.TongTien;
                //}
            }
            //HoaDon.MauHoaDon
            else if (currentct_hd != null && ChungTu_HoaDonThanhToangridView.FocusedColumn.FieldName == "HoaDon.MauHoaDon")
            {
                currentct_hd.HoaDon.KyHieuMauHoaDon = currentct_hd.HoaDon.MauHoaDon.Trim() + "/";
            }
            else if (currentct_hd != null && ChungTu_HoaDonThanhToangridView.FocusedColumn.FieldName == "HoaDon.SoHoaDon")
            {
                //currentct_hd.HoaDon.KyHieuMauHoaDon = currentct_hd.HoaDon.MauHoaDon.Trim() + "/";
                if (HoaDon.KiemTraTrungSoHoaDonTheoDoiTac(currentct_hd.HoaDon.SoHoaDon, currentct_hd.HoaDon.MaHoaDon, currentct_hd.HoaDon.MaDoiTac) > 0)
                {
                    MessageBox.Show("Lưu ý! Số hóa đơn " + currentct_hd.HoaDon.SoHoaDon + " của đối tác này đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            this.isChonHoaDon = true;
        }
        #endregion//ChungTu_HoaDon

        #region DoiTuongGridLookUpEdit

        private void DoiTuongGridLookUpEdit_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                frmKhachHangDoiTacCustomize frmKhachHang = new frmKhachHangDoiTacCustomize(true);
                if (frmKhachHang.ShowDialog(this) != DialogResult.OK)
                {
                    if (frmKhachHang.MaDoiTac != 0)
                    {
                        LoadDoiTuongList();
                        DoiTuongGridLookUpEdit.EditValue = frmKhachHang.MaDoiTac;
                    }
                }
            }
        }

        //DoiTuongGridLookUpEdit_EditValueChanged
        private void DoiTuongGridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (this.strStatus == "KHOA")
            {
                return;
            }
            if (DoiTuongGridLookUpEdit.EditValue != null)
            {
                int madoituongOut;
                if (int.TryParse(DoiTuongGridLookUpEdit.EditValue.ToString(), out madoituongOut))
                {
                    LoadDataControlLienQuanTheoDoiTuong(madoituongOut);

                    UpdateDoiTuongNoCo((long)madoituongOut);
                }
            }
        }
        #endregion//DoiTuongGridLookUpEdit

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

        #region NhanVien_gridLookUpEdit1
        private void NhanVien_gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (DoiTuongGridLookUpEdit.EditValue != null)
            {
                int madoituongOut;
                if (int.TryParse(DoiTuongGridLookUpEdit.EditValue.ToString(), out madoituongOut))
                {
                }
            }
        }
        #endregion//NhanVien_gridLookUpEdit1

        #endregion EventHandles

        #region Events
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.strStatus = "THEM";
            this.ReadOnlyConTrolByStatus(this.strStatus);

            _lapChungTuBienLai = false;
            KhoiTaoChungTuMoi();
            _taoMoiChungTu = true;//
            MaDoiTuongtextEdit1.Text = "";
            checkChonHoaDon = false;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textBoxFocus1.Focus();
            DoiTuongGridLookUpEdit.Focus();
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

        private void btnDSChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            frmTimChungTuNew f = new frmTimChungTuNew(_LoaiChungTu.MaLoaiCT);
            if (f.ShowDialog(this) != DialogResult.OK)
            {
                if (f.DaChon == true)
                {
                    this.strStatus = "KHOA";
                    this.ReadOnlyConTrolByStatus(this.strStatus);
                    LoadChungTuCu(f._ChungTu1.MaChungTu);
                    _taoMoiChungTu = false;//

                }
                else if (f.isCopyPassChungTu == true)
                {
                    _taoMoiChungTu = true;
                    this._ChungTu = ChungTu.NewChungTu();
                    this._ChungTu = f.chungTuMoi;
                    GanBindingSource();

                    this.strStatus = "THEM";
                    this.ReadOnlyConTrolByStatus(this.strStatus);
                }
            }

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void tlslblThemDN_Click(object sender, EventArgs e)
        {
            #region Old
            //if (_ChungTu.ChungTuDeNghiList.Count == 0 && _ChungTu.ChungTuGiayBaoCoList.Count == 0 && _ChungTu.ChungTuLenhChuyenTienList.Count == 0 && _ChungTu.ChungTuDeNghiList.Count == 0 && _ChungTu.ChungTuUyNhiemChiList.Count == 0 && _ChungTu.ChungTuGiayRutTienList.Count == 0)
            //{
            //    _ChungTu.LoaiChungTuDiKem = 0;
            //}
            //frmChonDeNghiChuyenKhoan frm = new frmChonDeNghiChuyenKhoan(_ChungTu);
            //frm.ShowDialog();
            //dtmp_Ngay.DateTime = _ChungTu.NgayLap;
            //TaoBindingDeNghiChuyenKhoan();
            #endregion Old

            #region Modify
            FrmGeChungTuReferenceList frm = new FrmGeChungTuReferenceList(_ChungTu.LoaiChungTu.MaLoaiCT, _ChungTu.DoiTuong, 0);
            if (frm.ShowDialog() != DialogResult.OK)
            {
                decimal tongtien = _ChungTu.Tien.ThanhTien;
                StringBuilder diengiai = new StringBuilder("");
                List<ChungTuReference> chungTuReferencelistSelected = frm.ChungTuRefListSelected;//M
                if (chungTuReferencelistSelected.Count != 0)//M
                {
                    StringBuilder soBienLaiStr = new StringBuilder("");
                    if (KiemTraChungTuDeNghiHopLe(chungTuReferencelistSelected) == false) return;
                    if (_maDoiTuongDeNghi == 0)
                    {
                        _maDoiTuongDeNghi = chungTuReferencelistSelected[0].MaDoiTuong;
                    }

                    foreach (ChungTuReference itemchungturef in chungTuReferencelistSelected)
                    {
                        bool insert = true;
                        if (_ChungTu.ChungTu_ChungList.Count > 0)
                        {
                            //foreach (CT_ChungTuBienLaiChild item in _ChungTu.CT_ChungTuBienLaiList)
                            foreach (ChungTu_ChungTuChild item in _ChungTu.ChungTu_ChungList)
                            {
                                if (item.IDChungTuRef == itemchungturef.MaChungTu)
                                {
                                    insert = false;
                                    break;
                                }
                            }

                        }//grdViewCt_PhieuXuat.RowCount > 0

                        if (insert)
                        {
                            //Tao thanhTien
                            tongtien += itemchungturef.ThanhTien;
                            diengiai.Append(string.Format("{0},", itemchungturef.NoiDung));
                            #region Tao ChungTu_ChungTuList
                            ChungTu_ChungTuChild chungTu_ChungTu = ChungTu_ChungTuChild.NewChungTu_ChungTuChild();
                            chungTu_ChungTu.IDChungTuRef = itemchungturef.MaChungTu;
                            chungTu_ChungTu.SoChungTuRef = itemchungturef.SoChungTu;
                            chungTu_ChungTu.NoiDung = itemchungturef.NoiDung;
                            chungTu_ChungTu.SoTien = itemchungturef.ThanhTien;
                            chungTu_ChungTu.MaDoiTuong = itemchungturef.MaDoiTuong;
                            chungTu_ChungTu.TenDoiTuong = itemchungturef.TenDoiTuong;
                            _ChungTu.ChungTu_ChungList.Add(chungTu_ChungTu);
                            #endregion Tao ChungTu_ChungTuList
                            #region ButToan
                            //_dinhKhoanTuDong = DinhKhoanTuDong.NewDinhKhoanTuDong();
                            //_dinhKhoanTuDong = DinhKhoanTuDong.GetDinhKhoanTuDong(itemchungturef.DienGiai, _LoaiChungTu.MaLoaiCT, itemchungturef.MaTruongHocSinh);
                            //if (_dinhKhoanTuDong != null)
                            //{
                            //    #region Modify
                            //    ButToan btadd = ButToan.NewButToan();
                            //    //Dien Giai=[loai thu]+ [tên hoc sinh]+ [lớp]+[mã học sinh]
                            //    btadd.DienGiai = itemchungturef.DienGiai + " - " + itemchungturef.TenDoiTuong + " - " + itemchungturef.TenLop + " - " + itemchungturef.MaQLDoiTuong;
                            //    btadd.NoTaiKhoan = _dinhKhoanTuDong.TKNo;
                            //    btadd.CoTaiKhoan = _dinhKhoanTuDong.TKCo;
                            //    btadd.SoTien = itemchungturef.SoTien;
                            //    //
                            //    btadd.OidMaBienLai = itemchungturef.MaBienLai;
                            //    btadd.OidChiTietBienLai = itemchungturef.MaChiTiet;
                            //    btadd.IDBienLai = itemchungturef.MaBienLaiInt;
                            //    btadd.IDChiTietBienLai = itemchungturef.MaChiTietInt;
                            //    btadd.KieuThuPhi = itemchungturef.KieuThuPhiFNC;

                            //    XuLyDoiTuongTheoDoi(btadd);
                            //    _ChungTu.DinhKhoan.ButToan.Add(btadd);
                            //    #endregion//Modify
                            //}

                            #endregion//end  ButToan
                        }
                    }
                    //
                    _ChungTu.Tien.ThanhTien = tongtien;
                    if (diengiai.Length > 1)
                    {
                        diengiai.Remove(diengiai.Length - 1, 1);
                        _ChungTu.BoSungChungTuKT.NDMucDichMuaNgoaiTe = diengiai.ToString();
                    }
                }
            }
            GanBindingSource();
            #endregion Modify
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
            DeleteChungTu_HoaDonThanhToanList();
        }

        private void tlSBtnThemCT_HoaDon_Click(object sender, EventArgs e)
        {
            #region Modify
            #region BatBuoc Co TK Thue
            //LoadButToanThue();
            //if (IsTaiKhoanThueKhauTru(_ButToanThue.NoTaiKhoan) == false)
            //{
            //    MessageBox.Show(this, "Vui lòng chọn tài khoản thuế!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //else if (_ButToanThue.SoTien == 0)
            //{
            //    MessageBox.Show(this, "Vui lòng nhập số tiền của bút toán!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //else
            //{
            //    FrmGetHoaDonToChungTu_HoaDon frm = new FrmGetHoaDonToChungTu_HoaDon(_ChungTu);
            //    if (frm.ShowDialog() != DialogResult.OK)
            //    {
            //        HoaDonList hoadonSelected = frm.HoanDonListSelected;//M
            //        if (hoadonSelected.Count != 0)//M
            //        {
            //            #region New
            //            foreach (HoaDon hoadon in hoadonSelected)
            //            {
            //                bool insert = true;
            //                if (ChungTu_HoaDongridView.RowCount > 0)
            //                {
            //                    for (int i = 0; i < ChungTu_HoaDongridView.RowCount; i++)
            //                    {
            //                        if (ChungTu_HoaDongridView.GetRow(i) != null)
            //                        {
            //                            ChungTu_HoaDon ct_hd_gv = (ChungTu_HoaDon)ChungTu_HoaDongridView.GetRow(i);
            //                            if (ct_hd_gv.MaHoaDon == hoadon.MaHoaDon)
            //                            {
            //                                insert = false;
            //                                break;
            //                            }
            //                        }
            //                    }

            //                }

            //                if (insert)
            //                {

            //                    ChungTu_HoaDon ct_hoadon = ChungTu_HoaDon.NewChungTu_HoaDon(hoadon);
            //                    _ButToanThue.ChungTu_HoaDonList.Add(ct_hoadon);
            //                }
            //            }
            //            #endregion //End New
            //        }
            //    }
            //    _ChungTu_HoaDonThanhToanList = _ButToanThue.ChungTu_HoaDonList;
            //    ChungTuHoaDonThanhToan_bindingSource.DataSource = _ChungTu_HoaDonThanhToanList;

            //}
            #endregion BatBuoc Co TK Thue

            #region Khong Rang Buoc
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
                        if (ChungTu_HoaDonThanhToangridView.RowCount > 0)
                        {
                            for (int i = 0; i < ChungTu_HoaDonThanhToangridView.RowCount; i++)
                            {
                                if (ChungTu_HoaDonThanhToangridView.GetRow(i) != null)
                                {
                                    ChungTu_HoaDonThanhToan ct_hd_gv = (ChungTu_HoaDonThanhToan)ChungTu_HoaDonThanhToangridView.GetRow(i);
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

                            ChungTu_HoaDonThanhToan ct_hoadon = ChungTu_HoaDonThanhToan.NewChungTu_HoaDonThanhToan(hoadon);
                            _ChungTu.ChungTu_HoaDonThanhToanList.Add(ct_hoadon);
                        }
                    }
                    #endregion //End New
                }
            }
            //_ChungTu_HoaDonThanhToanList = _ButToanThue.ChungTu_HoaDonList;
            ChungTuHoaDonThanhToan_bindingSource.DataSource = _ChungTu.ChungTu_HoaDonThanhToanList;
            #endregion Khong Rang Buoc

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

        private void btnlapChungTuBienLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool duoclap = true;

            btnThemMoi_ItemClick(sender, e);

            if (duoclap)
            {
                _lapChungTuBienLai = true;
                LapChungTuFromBienLai();
            }

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


        private void dtmp_Ngay_Leave(object sender, EventArgs e)
        {
            if (dtmp_Ngay.OldEditValue != dtmp_Ngay.EditValue)
            {
                _ChungTu.SoChungTu = PublicClass.SetSoChungTuByMaLoaiChungTu(_LoaiChungTu.MaLoaiCT, _ChungTu.NgayLap);
                _ChungTu.NgayThucHien = _ChungTu.NgayLap;
            }
        }

        private void btnHoanUng_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region Modify
            _RefType = 1;//Hoàn Ứng
            FrmGeChungTuReferenceList frm = new FrmGeChungTuReferenceList(_ChungTu.LoaiChungTu.MaLoaiCT, _ChungTu.DoiTuong, _RefType);
            if (frm.ShowDialog() != DialogResult.OK)
            {
                decimal tongtien = _ChungTu.Tien.ThanhTien;
                StringBuilder diengiai = new StringBuilder("");
                List<ChungTuReference> chungTuReferencelistSelected = frm.ChungTuRefListSelected;//M
                if (chungTuReferencelistSelected.Count != 0)//M
                {
                    StringBuilder diengiaiChungtu = new StringBuilder("");
                    //diengiaiChungtu.Append("Thu hoàn ứng: ");
                    string sDienGiaiChungTu = "Thu hoàn ứng ";
                    if (KiemTraChungTuDeNghiHopLe(chungTuReferencelistSelected) == false) return;
                    if (_maDoiTuongDeNghi == 0)
                    {
                        _maDoiTuongDeNghi = chungTuReferencelistSelected[0].MaDoiTuong;
                    }

                    foreach (ChungTuReference itemchungturef in chungTuReferencelistSelected)
                    {
                        bool insert = true;
                        if (_ChungTu.ChungTu_ChungList.Count > 0)
                        {
                            //foreach (CT_ChungTuBienLaiChild item in _ChungTu.CT_ChungTuBienLaiList)
                            foreach (ChungTu_ChungTuChild item in _ChungTu.ChungTu_ChungList)
                            {
                                if (item.IDChungTuRef == itemchungturef.MaChungTu)
                                {
                                    insert = false;
                                    break;
                                }
                            }

                        }//grdViewCt_PhieuXuat.RowCount > 0

                        if (insert)
                        {
                            //Tao thanhTien
                            tongtien += itemchungturef.ThanhTien;
                            //diengiai.Append(string.Format("{0},", itemchungturef.NoiDung));
                            //if (diengiaiChungtu.ToString().Contains(itemchungturef.SoChungTu) == false)
                            //{
                            //    diengiaiChungtu.Append(string.Format("{0},", itemchungturef.SoChungTu));
                            //}
                            if (sDienGiaiChungTu.Contains(itemchungturef.SoChungTu) == false)
                            {
                                sDienGiaiChungTu = sDienGiaiChungTu + itemchungturef.SoChungTu;
                                sDienGiaiChungTu = sDienGiaiChungTu + " ngày " + itemchungturef.NgayChungTu.ToString("dd/MM/yyyy");
                                sDienGiaiChungTu = sDienGiaiChungTu + " " + itemchungturef.NoiDung;
                            }
                            #region Tao ChungTu_ChungTuList
                            ChungTu_ChungTuChild chungTu_ChungTu = ChungTu_ChungTuChild.NewChungTu_ChungTuChild();
                            chungTu_ChungTu.RefType = _RefType;
                            chungTu_ChungTu.IDChungTuRef = itemchungturef.MaChungTu;
                            chungTu_ChungTu.SoChungTuRef = itemchungturef.SoChungTu;
                            chungTu_ChungTu.NoiDung = itemchungturef.NoiDung;
                            chungTu_ChungTu.SoTien = itemchungturef.ThanhTien;
                            chungTu_ChungTu.MaDoiTuong = itemchungturef.MaDoiTuong;
                            chungTu_ChungTu.TenDoiTuong = itemchungturef.TenDoiTuong;
                            chungTu_ChungTu.NgayCanTru = itemchungturef.NgayChungTu;
                            _ChungTu.ChungTu_ChungList.Add(chungTu_ChungTu);
                            #endregion Tao ChungTu_ChungTuList
                            #region ButToan
                            bool dacoDoiTuongTU = false;
                            foreach (ButToan itemButToan in _ChungTu.DinhKhoan.ButToan)
                            {
                                if (IsTaiKhoanTamUng(itemButToan.CoTaiKhoan) && itemButToan.DoiTuongCo == itemchungturef.MaDoiTuong)
                                {
                                    itemButToan.SoTien += itemchungturef.ThanhTien;
                                    if (itemButToan.DienGiai.Contains(itemchungturef.SoChungTu) == false)
                                    {
                                        itemButToan.DienGiai += ", " + itemchungturef.SoChungTu;
                                    }
                                    dacoDoiTuongTU = true;
                                }
                            }
                            if (dacoDoiTuongTU == false)
                            {
                                ButToan btadd = ButToan.NewButToan();
                                btadd.CoTaiKhoan = HeThongTaiKhoan.GetHeThongTaiKhoan(TaiKhoanThue.TaiKhoanThueList[0].SoHieuTKTamUng).MaTaiKhoan;
                                btadd.SoTien = itemchungturef.ThanhTien;
                                btadd.DoiTuongCo = itemchungturef.MaDoiTuong;
                                btadd.DienGiai = sDienGiaiChungTu;  //"Thu hoàn ứng " + itemchungturef.SoChungTu;// itemchungturef.TenDoiTuong;
                                _ChungTu.DinhKhoan.ButToan.Add(btadd);
                            }
                            //_dinhKhoanTuDong = DinhKhoanTuDong.NewDinhKhoanTuDong();
                            //_dinhKhoanTuDong = DinhKhoanTuDong.GetDinhKhoanTuDong(itemchungturef.DienGiai, _LoaiChungTu.MaLoaiCT, itemchungturef.MaTruongHocSinh);
                            //if (_dinhKhoanTuDong != null)
                            //{
                            //    #region Modify
                            //    ButToan btadd = ButToan.NewButToan();
                            //    //Dien Giai=[loai thu]+ [tên hoc sinh]+ [lớp]+[mã học sinh]
                            //    btadd.DienGiai = itemchungturef.DienGiai + " - " + itemchungturef.TenDoiTuong + " - " + itemchungturef.TenLop + " - " + itemchungturef.MaQLDoiTuong;
                            //    btadd.NoTaiKhoan = _dinhKhoanTuDong.TKNo;
                            //    btadd.CoTaiKhoan = _dinhKhoanTuDong.TKCo;
                            //    btadd.SoTien = itemchungturef.SoTien;
                            //    //
                            //    btadd.OidMaBienLai = itemchungturef.MaBienLai;
                            //    btadd.OidChiTietBienLai = itemchungturef.MaChiTiet;
                            //    btadd.IDBienLai = itemchungturef.MaBienLaiInt;
                            //    btadd.IDChiTietBienLai = itemchungturef.MaChiTietInt;
                            //    btadd.KieuThuPhi = itemchungturef.KieuThuPhiFNC;

                            //    XuLyDoiTuongTheoDoi(btadd);
                            //    _ChungTu.DinhKhoan.ButToan.Add(btadd);
                            //    #endregion//Modify
                            //}

                            #endregion//end  ButToan
                        }
                    }
                    //
                    _ChungTu.Tien.ThanhTien = tongtien;
                    _ChungTu.DoiTuong = _maDoiTuongDeNghi;
                    //_ChungTu.DienGiai = _ChungTu.DinhKhoan.ButToan[0].DienGiai;
                    //if (diengiaiChungtu.Length > 1)
                    //{
                    //    diengiaiChungtu.Remove(diengiaiChungtu.Length - 1, 1);
                    //    _ChungTu.DienGiai = diengiaiChungtu.ToString();
                    //}
                    if (sDienGiaiChungTu.Length > 1)
                    {
                        _ChungTu.DienGiai = sDienGiaiChungTu.ToString();
                    }
                    if (diengiai.Length > 1)
                    {
                        diengiai.Remove(diengiai.Length - 1, 1);
                        _ChungTu.BoSungChungTuKT.NDMucDichMuaNgoaiTe = diengiai.ToString();
                    }
                }
            }
            GanBindingSource();
            xtraTabControl2.SelectedTabPage = Tab1_xtraTabPage2;
            #endregion Modify
        }

        #endregion Events

        #region Event btnThamChieuGoiPhi
        private void btnThamChieuGoiPhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ThamChieuGoiPhiHocSinhThamGia();
        }

        private void ThamChieuGoiPhiHocSinhThamGia()
        {

            FrmGetGoiPhiHocSinhFromOtherDB frm = new FrmGetGoiPhiHocSinhFromOtherDB();
            if (frm.ShowDialog() != DialogResult.OK)
            {
                List<GoiPhiThamGiaHocSinhFromOtherDB> goiphithamgialistSelected = frm.GoiPhiThamGiaListSelected;//M
                if (goiphithamgialistSelected.Count != 0)//M
                {
                    bool codulieu = false;
                    //SoDuDauKyTheoDoiTuongList soDuDauKyListKiemTra = SoDuDauKyTheoDoiTuongList.NewSoDuDauKyTheoDoiTuongList();
                    foreach (GoiPhiThamGiaHocSinhFromOtherDB goiphiitem in goiphithamgialistSelected)
                    {
                        bool insert = true;
                        //foreach (SoDuDauKyTheoDoiTuong item in soDuDauKyListKiemTra)
                        foreach (ButToan item in this._ChungTu.DinhKhoan.ButToan)
                        {
                            if (item.DoiTuongCo == goiphiitem.MaDoiTuongInt && item.CoTaiKhoan == goiphiitem.MaTaiKhoan)
                            {
                                insert = false;
                                break;
                            }
                        }

                        if (insert)
                        {
                            ButToan buttoan = ButToan.NewButToan();
                            buttoan.DoiTuongCo = goiphiitem.MaDoiTuongInt;
                            buttoan.CoTaiKhoan = goiphiitem.MaTaiKhoan;
                            buttoan.SoTien = goiphiitem.SoTienCuaGoi;
                            this._ChungTu.DinhKhoan.ButToan.Add(buttoan);
                            codulieu = true;
                        }
                    }
                }
            }


        }
        #endregion

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

                gridView_DSDeNghi.OptionsBehavior.Editable = true;

                ChungTu_HoaDonThanhToangridView.OptionsBehavior.Editable = true;

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

                ChungTu_HoaDonThanhToangridView.OptionsBehavior.Editable = false;

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

        private void FrmChungTuKeToanCustomize_Load(object sender, EventArgs e)
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
            mauHDBindingSource.DataSource = danhMucMauHoaDonList;
            //NhomHDDVMuaVaoBindingsource.DataSource = NhomHHDVMuaVaoList.GetNhomHHDVMuaVaoList();

            checkChonHoaDon = false;
            this._daLoadXong = false;
            this.LoadDoiTuongList();
            this._daLoadXong = true;
        }

        private void xtraTabControl2_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if ((xtraTabControl2.SelectedTabPage.Name == Tab1_xtraTabPage1.Name) && (this.isChonHoaDon == true))
            {
                if (this.strStatus == "KHOA")
                    return;

                //mặc định số tiền định khoản = sum tiền hóa đơn ứng với mỗi nhà cung cấp
                this._ChungTu.DinhKhoan.ButToan.Clear();
                string strDoiTuong = "";
                string maDoiTuong = "";
                decimal soTien = 0;
                string dienGiai = "";
                decimal tongTien = 0;
                foreach (ChungTu_HoaDonThanhToan hd in this._ChungTu.ChungTu_HoaDonThanhToanList)
                {
                    soTien = 0;
                    maDoiTuong = hd.HoaDon.MaQLDoiTac;
                    tongTien = tongTien + hd.SoTienThanhToan;
                    dienGiai = "";
                    foreach (ChungTu_HoaDonThanhToan hoaDonThanhToan in this._ChungTu.ChungTu_HoaDonThanhToanList)
                    {
                        if (strDoiTuong.Contains(maDoiTuong + ","))
                        {
                            continue;
                        }

                        if (maDoiTuong == hoaDonThanhToan.HoaDon.MaQLDoiTac)
                        {
                            soTien = soTien + hoaDonThanhToan.SoTienThanhToan;
                            dienGiai = dienGiai + " " + hoaDonThanhToan.HoaDon.GhiChu;
                        }
                    }
                    strDoiTuong = strDoiTuong + maDoiTuong + ",";
                    //insert buttoan
                    if (soTien > 0)
                    {
                        ButToan bt = ButToan.NewButToan();
                        bt.SoTien = soTien;
                        bt.DienGiai = (_ChungTu.DienGiai + "") != "" ? _ChungTu.DienGiai : dienGiai;
                        if (_dinhKhoanTuDong.Id != 0)
                        {
                            bt.NoTaiKhoan = _dinhKhoanTuDong.TKNo;
                            bt.CoTaiKhoan = _dinhKhoanTuDong.TKCo;
                        }
                        else
                        {
                            bt.NoTaiKhoan = _LoaiChungTu.TKNo;
                            bt.CoTaiKhoan = _LoaiChungTu.TKCo;
                        }

                        this._ChungTu.DinhKhoan.ButToan.Add(bt);
                    }
                }
                this._ChungTu.Tien.ThanhTien = tongTien;
                this.isChonHoaDon = false;
            }
        }


        #region set doi tuong no co cho buttoan neu ko co hoa don
        private void UpdateDoiTuongNoCo(long madoituong)
        {
            //co hoa don, thi ko update
            if (_ChungTu.ChungTu_HoaDonThanhToanList.Count != 0)
                return;

            if (madoituong == 0)
                return;

            foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
            {
                if (bt.DoiTuongNo != 0)
                    bt.DoiTuongNo = madoituong;
                else
                {
                    if (bt.NoTaiKhoan != 0)
                    {
                        HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.NoTaiKhoan);
                        if (taiKhoanNo.CoDoiTuongTheoDoi == true)
                        {
                            bt.DoiTuongNo = madoituong;
                        }
                    }
                }

                if (bt.DoiTuongCo != 0)
                    bt.DoiTuongCo = madoituong;
                else
                {
                    if (bt.CoTaiKhoan != 0)
                    {
                        HeThongTaiKhoan1 taiKhoanCo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.CoTaiKhoan);
                        if (taiKhoanCo.CoDoiTuongTheoDoi == true)
                        {
                            bt.DoiTuongCo = madoituong;
                        }
                    }
                }
            }

        }
        #endregion

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
                            bt.SoTien = bt.SoTienNgoaiTe * _ChungTu.Tien.TiGiaQuyDoi;
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
                                bt.SoTien = bt.SoTienNgoaiTe * _ChungTu.Tien.TiGiaQuyDoi;
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

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Name == "tabThongTinPhieu")
            {
                btnTim.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnXuatExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                btnThamChieuGoiPhi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnHoanUng.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
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

                btnThamChieuGoiPhi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnHoanUng.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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

        private void menuItemF1_Click(object sender, EventArgs e)
        {
            bool duoclap = true;
            this.strStatus = "THEM";
            this.ReadOnlyConTrolByStatus(this.strStatus);

            _lapChungTuBienLai = false;
            KhoiTaoChungTuMoi();
            _taoMoiChungTu = true;//
            MaDoiTuongtextEdit1.Text = "";
            checkChonHoaDon = false;

            if (duoclap)
            {
                _lapChungTuBienLai = true;
                LapChungTuFromBienLai();
            }
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