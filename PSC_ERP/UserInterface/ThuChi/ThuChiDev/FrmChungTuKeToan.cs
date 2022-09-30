using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using PSC_ERP_Common;
using System.Data.SqlClient;
using System.Threading;

namespace PSC_ERP
{
    public partial class FrmChungTuKeToan : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        public int LoaiChi = 0;
        int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;

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
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;

        //private int _selectIndexTabControl = 1;//1: xtraTabPage1(Chứng từ); 2:xtraTabPage2(Danh sách chứng từ)
        //private bool _selectedTabPage2 = false;


        private bool clickButtoan = false;
        private bool handlefocus = true;
        private bool _isCellValuechangeBT = true;

        private bool _lapChungTuBienLai = false;
        private BindingSource DoiTuongForChungTuHoaDonBindingSource = new BindingSource();

        private DinhKhoanTuDong _dinhKhoanTuDong = DinhKhoanTuDong.NewDinhKhoanTuDong();
        private BindingSource LoaiThueSuatListBindingSource = new BindingSource();
        #endregion Properties

        #region Functions
        private void TaoBingdingOfControls()
        {
            this.NguoiNhan_textEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblChungTuBindingSource_Single, "ChungTu_DiaChi.Ten", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txt_DiaChiDoiTuongNhan.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblChungTuBindingSource_Single, "ChungTu_DiaChi.DiaChi", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
        }

        private void FormatForm()
        {
            if (_LoaiChungTu.MaLoaiCTQuanLy == "PT111")
            {
                this.Text = "Phiếu Thu";
                Tab1_xtraTabPage2.PageVisible = true;//DeNghi
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
                Tab1_xtraTabPage2.PageVisible = true;//DeNghi
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
                Tab1_xtraTabPage2.PageVisible = true;//DeNghi
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
                Tab1_xtraTabPage2.PageVisible = true;//DeNghi
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
                Tab1_xtraTabPage2.PageVisible = true;//DeNghi
                Tab1_xtraTabPage3.PageVisible = true;//HoaDon

                NguoiNhanLbCtrl.Text = "Người GD";
                DienGiaiLbCtrl.Text = "Diễn giải";
                NhanVienLbCtrl.Text = "Nhân viên";
                btnlapChungTuBienLai.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnLapHoaDonBanRa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
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
            hoatdongE.TenHoatDong = "<<None>>";
            hoatdonglist.Insert(0, hoatdongE);
            HoatDongList_bindingSource1.DataSource = hoatdonglist;
            //CauTrucKhoanMucChiPhiList
            CauTrucDoanhThuChiPhiList khoanmuclist = CauTrucDoanhThuChiPhiList.GetCauTrucDoanhThuChiPhiList(_maCongTy);
            CauTrucDoanhThuChiPhi khoanmucE = CauTrucDoanhThuChiPhi.NewCauTrucDoanhThuChiPhi();
            khoanmucE.Ten = "<<None>>";
            khoanmuclist.Insert(0, khoanmucE);
            CauTrucDoanhThuChiPhiList_bindingSource1.DataSource = khoanmuclist;
            //DonViList
            BoPhanList bophanlist = BoPhanList.GetBoPhanList();
            BoPhan bpEmpt = BoPhan.NewBoPhan("<<None>>");
            bophanlist.Insert(0, bpEmpt);
            DonViList_bindingSource1.DataSource = bophanlist;
            //Loai Thue VAT
            LoaiThueSuatListBindingSource.DataSource = LoaiThueSuatVAT.CreateListLoaiThueSuatVAT();
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
            tblDinhKhoanBindingSource_Single.DataSource = _ChungTu.DinhKhoan;
            tblButToanBindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;
            gridControl1.DataSource = tblButToanBindingSource;
            ChungTuHoaDon_bindingSource.DataSource = _ChungTu_HoaDonList;// _ButToanThue.ChungTu_HoaDonList;
            ChungTu_HoaDongridControl.DataSource = ChungTuHoaDon_bindingSource;
            LoadChungTuHoaDonByButToan();
            if (_LoaiChungTu.MaLoaiCTQuanLy == "PKT" || _LoaiChungTu.MaLoaiCTQuanLy == "PT111" || _LoaiChungTu.MaLoaiCTQuanLy == "PC112")//Bang Ke or PhieThu
                ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = _ChungTu.ChungTuDeNghiList;

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
                buttoan.NoTaiKhoan = _dinhKhoanTuDong.TKNo;
                buttoan.CoTaiKhoan = _dinhKhoanTuDong.TKCo;
            }
            else
            {
                buttoan.NoTaiKhoan = _LoaiChungTu.TKNo;
                buttoan.CoTaiKhoan = _LoaiChungTu.TKCo;
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
            HamDungChung.ShowFieldGridViewDev(gridView_ButToan, new string[] { "DienGiai", "NoTaiKhoan", "CoTaiKhoan", "SoTien", "DoiTuongNo", "DoiTuongCo", "MaDonVi", "IDKhoanMuc", "MaHopDong", "SoHoaDonThamChieu" },
                                new string[] { "Nội dung", "Nợ Tài Khoản", "Có Tài Khoản", "Số Tiền", "Đối tượng nợ", "Đối tượng có", "Đơn vị", "Thuộc khoản mục", "Số hợp đồng", "Số hóa đơn tham chiếu" },
                                             new int[] { 150, 80, 80, 90, 120, 120, 100, 100, 100, 100 });
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

            HamDungChung.AlignHeaderColumnGridViewDev(gridView_ButToan, new string[] { "DienGiai", "NoTaiKhoan", "CoTaiKhoan", "SoTien", "DoiTuongNo", "DoiTuongCo", "MaDonVi", "IDKhoanMuc", "MaHopDong", "SoHoaDonThamChieu" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_ButToan, new string[] { "SoTien" }, "#,###.##");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView_ButToan, new string[] { "SoTien" }, "{0:#,###.##}");
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
            //KhoanMucCol
            RepositoryItemGridLookUpEdit khoanMuc_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(khoanMuc_GrdLU, CauTrucDoanhThuChiPhiList_bindingSource1, "Ten", "Id", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(khoanMuc_GrdLU, new string[] { "Ten", "MaQL" }, new string[] { "Khoản mục", "Mã Ql" }, new int[] { 200, 100 }, false);
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
            btnInDVKhoanChi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            decimal sotien = Convert.ToDecimal(calcEdit_ThanhTien.EditValue);
            foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
            {
                if (sotien != bt.SoTien)
                    sotien -= bt.SoTien;
                else if (sotien == bt.SoTien)
                    sotien = 0;
            }

            if (sotien != 0 && gridView_ButToan.IsNewItemRow(rowhandle))
            {
                if (gridView_ButToan.GetRow(rowhandle) == null)
                    gridView_ButToan.AddNewRow();
            }
        }

        private void EventRowOrColumnGrdView_DinhKhoanChange(int rowhandle)
        {
            UnLockgrdView_DinhKhoan();
            if (gridView_ButToan.GetFocusedRow() != null)
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
                btnPrintA5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnDSChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnInDVKhoanChi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnPrintA4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnPrintA5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnDSChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnInDVKhoanChi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
                _ChungTu_HoaDonList = ChungTu_HoaDonList.NewChungTu_HoaDonList();
                //gán bindingSource
                GanBindingSource();
                DoiTuongGridLookUpEdit.Focus();
                btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            //đã load xong
            //_daLoadXong = true;
        }

        private void GanDuLieuChoTextDoiTac()
        {
            NguoiNhan_textEdit1.Text = _ChungTu.ChungTu_DiaChi.Ten;
            txt_DiaChiDoiTuongNhan.Text = _ChungTu.ChungTu_DiaChi.DiaChi; 
        }

        private void LoadChungTuCu(long maChungTu)
        {
            //chưa load xong
            //_daLoadXong = false;
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
            _ChungTu.DinhKhoan.LaMotNoNhieuCo = true;
            string soHoaDonThamChieu = "";
            if (_ChungTu.DinhKhoan.ButToan.Count == 1 && _LoaiChungTu.MaLoaiCTQuanLy == "PC111")
            {
                _ChungTu.DinhKhoan.LaMotNoNhieuCo = false;
                return true;
            }
            else if (_ChungTu.DinhKhoan.ButToan.Count > 1)
            {
                int[] noArry = new int[_ChungTu.DinhKhoan.ButToan.Count];
                int[] coArry = new int[_ChungTu.DinhKhoan.ButToan.Count];
                int n = 0;
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

                    noArry[n] = bt.NoTaiKhoan;
                    coArry[n] = bt.CoTaiKhoan;
                    n += 1;
                }
                if (
                    (ElementsInArryDifference(noArry) && ElementsInArryDifference(coArry))
                    )
                {
                    MessageBox.Show("Bút toán nhiều Nợ nhiều Có, không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (ElementsInArryDifference(noArry))
                {
                    _ChungTu.DinhKhoan.LaMotNoNhieuCo = false;
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
            else if (_ChungTu.Tien.SoTien == 0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Số Tiền Chứng Từ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                calcEdit_SoTien.Focus();
                return false;
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
                    DialogUtil.ShowNotSaveSuccessful();
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
                _hopDongList.Insert(0, HopDongMuaBan.NewHopDongMuaBan(0, "<<None>>"));
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
                DoiTuongAll doituong = DoiTuongAll.NewDoiTuongAll("<<None>>");//new sp_AllDoiTuong_Result() { MaDoiTuong = 0, TenDoiTuong = "<<None>>" };
                _DoiTuongThuChiList.Insert(0, doituong);
                AllDoiTuong_bindingSource.DataSource = _DoiTuongThuChiList;
                // NhanVien
                _NhanVienList = DoiTuongAllList.GetDoiTuongAllList_Tim_NhanVien("", _maCongTy);//_factory.Context.sp_AllDoiTuong(0, 0).Where(x => x.MaCongTy == _maCongTy).ToList();
                DoiTuongAll nhanvien = DoiTuongAll.NewDoiTuongAll("<<None>>");//new sp_AllDoiTuong_Result() { MaDoiTuong = 0, TenDoiTuong = "<<None>>" };
                _NhanVienList.Insert(0, nhanvien);
                NhanVienList_bindingSource.DataSource = _NhanVienList;
                //Load Doi Tuong No Co
                DoiTuongAllList doituongNoCoList = DoiTuongAllList.GetDoiTuongAllList_Tim("", 0); //_factory.Context.sp_AllDoiTuong(1, 0).Where(x => x.MaCongTy == _maCongTy).ToList();//Lấy đối tác
                DoiTuongAll doituongNCEmpty = DoiTuongAll.NewDoiTuongAll("<<None>>");//new sp_AllDoiTuong_Result() { MaDoiTuong = 0, TenDoiTuong = "<<None>>" };
                doituongNoCoList.Insert(0, doituongNCEmpty);
                DoiTuongNoList_BindingSource.DataSource = doituongNoCoList;
                DoiTuongCoList_BindingSource.DataSource = doituongNoCoList;
                //DoiTuongForChungTu_HoaDon
                DoiTuongForChungTuHoaDonBindingSource.DataSource = _DoiTuongThuChiList;

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
            FrmGetBienLaiFronOtherDB frm = new FrmGetBienLaiFronOtherDB(tendoituong, hinhthucthanhtoan, 1);
            if (frm.ShowDialog() != DialogResult.OK)
            {
                decimal tongtien = 0;
                StringBuilder diengiai = new StringBuilder("");
                List<ChiTietBienLaiFromOtherDB> chitietbienlailistSelected = frm.ChiTietBienLaiListSelected;//M
                if (chitietbienlailistSelected.Count != 0)//M
                {
                    if (KiemTraLapHoaDonTuBienLaiHopLe(chitietbienlailistSelected) == false) return;
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
                            CT_ChungTuBienLaiChild ct_chungtubienlai = CT_ChungTuBienLaiChild.NewCT_ChungTuBienLaiChild();
                            ct_chungtubienlai.OidMaBienLai = ctbienlai.MaBienLai;
                            ct_chungtubienlai.OidChiTietBienLai = ctbienlai.MaChiTiet;
                            ct_chungtubienlai.IDBienLai = ctbienlai.MaBienLaiInt;
                            ct_chungtubienlai.IDChiTietBienLai = ctbienlai.MaChiTietInt;
                            _ChungTu.CT_ChungTuBienLaiList.Add(ct_chungtubienlai);
                            #region ButToan
                            _dinhKhoanTuDong = DinhKhoanTuDong.NewDinhKhoanTuDong();
                            _dinhKhoanTuDong = DinhKhoanTuDong.GetDinhKhoanTuDong(ctbienlai.DienGiai, _LoaiChungTu.MaLoaiCT, ctbienlai.MaTruongHocSinh);
                            if (_dinhKhoanTuDong != null)
                            {
                                #region Modify
                                ButToan btadd = ButToan.NewButToan();
                                //Dien Giai=[loai thu]+ [tên hoc sinh]+ [lớp]+[mã học sinh]
                                btadd.DienGiai = ctbienlai.DienGiai + " - " + ctbienlai.TenDoiTuong + " - " + ctbienlai.TenLop + " - " + ctbienlai.MaQLDoiTuong;
                                btadd.NoTaiKhoan = _dinhKhoanTuDong.TKNo;
                                btadd.CoTaiKhoan = _dinhKhoanTuDong.TKCo;
                                btadd.SoTien = ctbienlai.SoTien;
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
                    _ChungTu.Tien.SoTien = tongtien;
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

        #endregion Functions

        #region Initialize
        public FrmChungTuKeToan()
        {
            InitializeComponent();
        }

        public FrmChungTuKeToan(ChungTu chungTu)
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
                if (KhoaButToanTheoTaiKhoan(currentButToan.NoTaiKhoan) || KhoaButToanTheoTaiKhoan(currentButToan.CoTaiKhoan))
                {
                    _isCellValuechangeBT = false;
                    MessageBox.Show(this, "Đã khóa sổ tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    currentButToan.NoTaiKhoan = 0;
                    currentButToan.CoTaiKhoan = 0;
                    _isCellValuechangeBT = true;
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
        }
        private void DeleteButToanList()
        {
            if (KiemTraButToanThueTruocKhiXoaButToan() == false) return;
            if (gridView_ButToan.RowCount > 0)
            {
                if (gridView_ButToan.GetSelectedRows().Length > 0)
                {
                    if (MessageBox.Show(String.Format("Bạn có muốn xóa {0} dòng được chọn không?", gridView_ButToan.GetSelectedRows().Length), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        gridView_ButToan.DeleteSelectedRows();
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

            decimal sotien = Convert.ToDecimal(calcEdit_ThanhTien.EditValue);


            #region New
            ButToan buttoan = this.gridView_ButToan.GetRow(e.RowHandle) as ButToan;
            if (buttoan != null)
            {
                foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
                {

                    if (sotien != bt.SoTien)
                        sotien -= bt.SoTien;
                    else if (sotien == bt.SoTien)
                        sotien = 0;
                }
                #region Modify
                if (sotien != 0)
                {
                    SetTaiKhoanDefaultForNewFirstButtoan(buttoan);
                    buttoan.SoTien = sotien;
                    buttoan.DienGiai = txt_DienGiai.EditValue.ToString();
                }
                #endregion//Modify
                #region Old
                //if (_ChungTu.DinhKhoan.ButToan.Count > 1 && sotien != 0)
                //{
                //    ButToan previousBt = _ChungTu.DinhKhoan.ButToan.LastOrDefault();
                //    buttoan.NoTaiKhoan = previousBt.NoTaiKhoan;
                //    buttoan.CoTaiKhoan = previousBt.CoTaiKhoan;
                //    buttoan.SoTien = sotien;
                //    buttoan.DoiTuongCo = previousBt.DoiTuongCo;
                //    buttoan.DoiTuongNo = previousBt.DoiTuongNo;
                //    buttoan.DienGiai = previousBt.DienGiai;
                //    buttoan.MaHopDong = previousBt.MaHopDong;
                //}
                //else if (sotien != 0)
                //{
                //    SetTaiKhoanDefaultForNewFirstButtoan(buttoan);
                //    buttoan.SoTien = sotien;
                //    buttoan.DienGiai = txt_DienGiai.EditValue.ToString();
                //} 
                #endregion //Old


            }
            //gridView_ButToan.UpdateCurrentRow();
            #endregion//New
            #region Old
            //tblButToan buttoan = tblButToanBindingSource.Current as tblButToan;
            //if (gridView_ButToan.RowCount == 0)
            //{
            //    SetTaiKhoanDefaultForNewFirstButtoan();
            //    buttoan.SoTien = sotien;
            //    buttoan.DienGiai = txt_DienGiai.EditValue.ToString();
            //}
            //else
            //{
            //    foreach (tblButToan bt in _ChungTu.tblDinhKhoan.tblButToans)
            //    {

            //        if (sotien != bt.SoTien)
            //            sotien -= bt.SoTien;
            //        else if (sotien == bt.SoTien)
            //            sotien = 0;
            //    }
            //    if (buttoan != null)
            //    {
            //        buttoan.SoTien = sotien;
            //        buttoan.DienGiai = txt_DienGiai.EditValue.ToString();
            //    }
            //}
            #endregion//Old

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
            if (e.KeyCode == Keys.Enter)
            {
                if (gridView_ButToan.FocusedColumn == gridView_ButToan.Columns.ColumnByName("colCT_ChiPhiSX"))
                {
                    //ClickChiPhiSX();
                }
                else if (gridView_ButToan.FocusedColumn == gridView_ButToan.Columns.ColumnByName("colCT_ChiPhiSX"))
                {
                    //ClickDSHoaDon();
                }
                //else if (KiemTraCoTKTamUng())
                //{
                //    //PSC_ERP.ThuChiEntity.frmTamUng _frmTamUng = new PSC_ERP.ThuChiEntity.frmTamUng(_factory.Context, _ChungTu);
                //    PSC_ERP.frmTamUng_Dev _frmTamUng = new PSC_ERP.frmTamUng_Dev(_ChungTu);
                //    _frmTamUng.Show(this);
                //}
                else
                {

                    gridView_ButToan.PostEditor();
                    gridView_ButToan.UpdateCurrentRow();
                    handlefocus = false;//
                    gridView_ButToan.FocusedColumn = gridView_ButToan.VisibleColumns[0];

                    decimal sotien = Convert.ToDecimal(calcEdit_ThanhTien.EditValue);
                    foreach (ButToan bt in _ChungTu.DinhKhoan.ButToan)
                    {

                        if (sotien != bt.SoTien)
                            sotien -= bt.SoTien;
                        else if (sotien == bt.SoTien)
                            sotien = 0;
                    }
                    if (sotien != 0)
                    {
                        //gridView_ButToan.FocusedRowHandle = GridControl.NewItemRowHandle;
                        if (gridView_ButToan.RowCount > 0)
                        {
                            gridView_ButToan.AddNewRow();
                        }
                    }
                }//End Else


            }
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
                currentCT_HD.HoaDon.LoaiHoaDon = 4;//Hoa Don Mua vao
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

        private void btnlapChungTuBienLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool duoclap = true;
            if (_ChungTu.IsNew == false)
            {
                if (MessageBox.Show("Việc này sẽ tạo Chứng từ mới. Bạn có muốn tiếp tục?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    duoclap = false;
                }
            }
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

        #endregion Events

        private void dtmp_Ngay_Leave(object sender, EventArgs e)
        {
            if (dtmp_Ngay.OldEditValue != dtmp_Ngay.EditValue)
            {
                _ChungTu.SoChungTu = PublicClass.SetSoChungTuByMaLoaiChungTu(_LoaiChungTu.MaLoaiCT, _ChungTu.NgayLap);
            }
        }

        #region event btnSua
        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.strStatus = "SUA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            HoatDong_gridLookUpEdit1.Focus();
        }
        public string strStatus = "";
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
                    if (c is DevExpress.XtraEditors.GridLookUpEdit)
                    {
                        ((DevExpress.XtraEditors.GridLookUpEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is DevExpress.XtraEditors.TextEdit)
                    {
                        ((DevExpress.XtraEditors.TextEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is DevExpress.XtraEditors.DateEdit)
                    {
                        ((DevExpress.XtraEditors.DateEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is DevExpress.XtraEditors.CalcEdit)
                    {
                        ((DevExpress.XtraEditors.CalcEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is DevExpress.XtraEditors.MemoEdit)
                    {
                        ((DevExpress.XtraEditors.MemoEdit)c).Properties.ReadOnly = false;
                    }
                }

                foreach (Control c in ThongTinChungTugroupControl.Controls)
                {
                    if (c is DevExpress.XtraEditors.GridLookUpEdit)
                    {
                        ((DevExpress.XtraEditors.GridLookUpEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is DevExpress.XtraEditors.TextEdit)
                    {
                        ((DevExpress.XtraEditors.TextEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is DevExpress.XtraEditors.DateEdit)
                    {
                        ((DevExpress.XtraEditors.DateEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is DevExpress.XtraEditors.CalcEdit)
                    {
                        ((DevExpress.XtraEditors.CalcEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is DevExpress.XtraEditors.MemoEdit)
                    {
                        ((DevExpress.XtraEditors.MemoEdit)c).Properties.ReadOnly = false;
                    }
                }


                btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnDuplicate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (_strStatus == "KHOA")
            {
                gridView_ButToan.OptionsBehavior.Editable = false;
                tblButToanBindingSource.AllowNew = false;

                gridView_DSDeNghi.OptionsBehavior.Editable = false;

                txt_TienBangChu.Properties.ReadOnly = true;

                foreach (Control c in ThongTinChunggroupControl2.Controls)
                {
                    if (c is DevExpress.XtraEditors.GridLookUpEdit)
                    {
                        ((DevExpress.XtraEditors.GridLookUpEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is DevExpress.XtraEditors.TextEdit)
                    {
                        ((DevExpress.XtraEditors.TextEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is DevExpress.XtraEditors.DateEdit)
                    {
                        ((DevExpress.XtraEditors.DateEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is DevExpress.XtraEditors.CalcEdit)
                    {
                        ((DevExpress.XtraEditors.CalcEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is DevExpress.XtraEditors.MemoEdit)
                    {
                        ((DevExpress.XtraEditors.MemoEdit)c).Properties.ReadOnly = true;
                    }
                }

                foreach (Control c in ThongTinChungTugroupControl.Controls)
                {
                    if (c is DevExpress.XtraEditors.GridLookUpEdit)
                    {
                        ((DevExpress.XtraEditors.GridLookUpEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is DevExpress.XtraEditors.TextEdit)
                    {
                        ((DevExpress.XtraEditors.TextEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is DevExpress.XtraEditors.DateEdit)
                    {
                        ((DevExpress.XtraEditors.DateEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is DevExpress.XtraEditors.CalcEdit)
                    {
                        ((DevExpress.XtraEditors.CalcEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is DevExpress.XtraEditors.MemoEdit)
                    {
                        ((DevExpress.XtraEditors.MemoEdit)c).Properties.ReadOnly = true;
                    }
                }

                btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnDuplicate.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }
        #endregion

        private void FrmChungTuKeToan_Load(object sender, EventArgs e)
        {
            this.ReadOnlyConTrolByStatus(this.strStatus);
        }

        #region copy - pass chung tu
        private void btnDuplicate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_ChungTu.MaChungTu == 0)
                return;

            DuplicateChungTu();
            this.strStatus = "THEM";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            _taoMoiChungTu = true;
            GanBindingSource();
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
    }
}