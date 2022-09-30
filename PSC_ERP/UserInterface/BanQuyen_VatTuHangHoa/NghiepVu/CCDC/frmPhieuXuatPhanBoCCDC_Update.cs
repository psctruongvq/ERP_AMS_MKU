using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using PSC_ERP_Common;
using DevExpress.XtraGrid.Columns;
//19/11/2013
namespace PSC_ERP
{
    public partial class frmPhieuXuatPhanBoCCDC_Update : XtraForm
    {
        /// /////
        KhoBQ_VTList _khoBQ_VTList = null;
        PhieuNhapXuatCCDC _phieuXuat = PhieuNhapXuatCCDC.NewPhieuNhapXuat();
        HoaDonList _hoaDonList = HoaDonList.NewHoaDonList();
        DoiTuongAllList _doiTuongAllList = DoiTuongAllList.NewDoiTuongAllList();
        TieuMucNganSachList _tieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();
        DoiTacList _DoiTacList;
        //Bien cho REPORT
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet;
        byte _loai = 0;
        DateTime _ngayLapCu;
        private byte _cachIn = 0;//1: In NXT MaVatTu; 2: In NXT MaCCDC CaBiet; 3: In CCDCQuanLy
        private bool _CheckAllCCDCQuanLy = true;
        bool isLoadCboNhanVien = false, _edtiBophan = false;
        private bool isThayDoiSoLieu = false;
        PhieuNhapXuatCCDCList _phieuNhapXuatList = PhieuNhapXuatCCDCList.NewPhieuNhapXuatList();
        BoPhanList _dsTruong = BoPhanList.NewBoPhanList();
        #region BS KhoaSoTK
        private bool _isCellValuechangeBT = true;
        private bool _coTKBiKhoa = false;
        #endregion//BS KhoaSoTK

        private BindingSource LoaiThueSuatListBindingSource = new BindingSource();
        //
        public frmPhieuXuatPhanBoCCDC_Update()
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu();
        }

        #region frmPhieuXuatPhanBoCCDC(PhieuNhapXuat phieuNhapXuat)
        public frmPhieuXuatPhanBoCCDC_Update(PhieuNhapXuatCCDC phieuNhapXuat, byte loai)
        {
            InitializeComponent();
            lookUpEdit_PPNXKho.Enabled = false;
            _loai = loai;
            KhoiTao();
            KhoiTaoPhieu(phieuNhapXuat);

            //
            if (_phieuXuat.IsNew)
            {
                XuLyThem();
            }
            //this.TinhTongTienChoPhieuXuat();
        }
        #endregion

        public frmPhieuXuatPhanBoCCDC_Update(long maPhieuXuat)
        {
            InitializeComponent();
            lookUpEdit_PPNXKho.Enabled = false;
            KhoiTao();
            PhieuNhapXuatCCDC phieuXuatCCDC = PhieuNhapXuatCCDC.GetPhieuNhapXuat(maPhieuXuat);
            KhoiTaoPhieu(phieuXuatCCDC);
        }

        #region Functions
        private void DesignGrid_grdViewCt_PhieuNhap()
        {//grdViewCt_PhieuNhap
            grdCT_PhieuNhap.DataSource = cTPhieuXuatListBindingSource;
            HamDungChung.InitGridViewDev(grdViewCt_PhieuNhap, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(grdViewCt_PhieuNhap, new string[] { "MoTaTenCCDC", "MaDonViTinh", "SoLuong", "DonGia", "ThanhTien", "ThoiLuong", "DienGiai", "MaTruong" },
                                new string[] { "Mô tả CCDC(Model)", "ĐVT", "Số lượng", "Đơn giá", "Thành tiền", "TGPB (tháng)", "Ghi chú", "Mã trường" },
                                             new int[] { 90, 80, 90, 100, 110, 100, 150, 100 });

            HamDungChung.AlignHeaderColumnGridViewDev(grdViewCt_PhieuNhap, new string[] { "MoTaTenCCDC", "MaDonViTinh", "SoLuong", "DonGia", "ThanhTien", "TyLeCK", "TienChietKhau", "ChiPhiMuaHang", "ThueSuatVAT", "TienThue", "ThoiLuong", "DienGiai","MaTruong" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdViewCt_PhieuNhap, new string[] { "SoLuong", "DonGia", "ThanhTien", "ThoiLuong" }, "#,###.##");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdViewCt_PhieuNhap, new string[] { "SoLuong", "ThanhTienGoc", "ThanhTien" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(grdViewCt_PhieuNhap, NewItemRowPosition.Bottom);

            Utils.GridUtils.SetSTTForGridView(grdViewCt_PhieuNhap, 50);//M
            //Hang Hoa mã           
            GridColumn columnMaHangHoa = new GridColumn();
            columnMaHangHoa.Caption = "Mã CCDC";
            columnMaHangHoa.FieldName = "MaHangHoa";
            columnMaHangHoa.Width = 80;
            columnMaHangHoa.OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuNhap.Columns.Add(columnMaHangHoa);
            RepositoryItemGridLookUpEdit HangHoa_GrdLU_Ma = new RepositoryItemGridLookUpEdit();
            HangHoa_GrdLU_Ma.ExportMode = ExportMode.DisplayText;
            HamDungChung.InitRepositoryItemGridLookUpDev2(HangHoa_GrdLU_Ma, hangHoaBQVTListBindingSource, "MaQuanLy", "MaHangHoa", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(HangHoa_GrdLU_Ma, new string[] { "MaQuanLy", "TenHangHoa" }, new string[] { "Mã HH", "Tên HH" }, new int[] { 100, 200 }, false);
            columnMaHangHoa.ColumnEdit = HangHoa_GrdLU_Ma;
            //Hang Hoa
            GridColumn columnTenHangHoa = new GridColumn();
            columnTenHangHoa.Caption = "Công cụ dụng cụ";
            columnTenHangHoa.FieldName = "MaHangHoa";
            columnTenHangHoa.Width = 120;
            columnTenHangHoa.OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuNhap.Columns.Add(columnTenHangHoa);
            RepositoryItemGridLookUpEdit HangHoa_GrdLU = new RepositoryItemGridLookUpEdit();
            HangHoa_GrdLU.ExportMode = ExportMode.DisplayText;
            HamDungChung.InitRepositoryItemGridLookUpDev2(HangHoa_GrdLU, hangHoaBQVTListBindingSource, "TenHangHoa", "MaHangHoa", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(HangHoa_GrdLU, new string[] { "MaQuanLy", "TenHangHoa" }, new string[] { "Mã HH", "Tên HH" }, new int[] { 100, 200 }, false);
            //HamDungChung.RegisterControlFieldGridViewDev(grdViewCt_PhieuNhap, "MaHangHoa", HangHoa_GrdLU);
            columnTenHangHoa.ColumnEdit = HangHoa_GrdLU;
            //
            columnMaHangHoa.VisibleIndex = 0;
            columnTenHangHoa.VisibleIndex = 1;
            grdViewCt_PhieuNhap.Columns["MoTaTenCCDC"].VisibleIndex = 2;
            grdViewCt_PhieuNhap.Columns["MaDonViTinh"].VisibleIndex = 3;
            grdViewCt_PhieuNhap.Columns["SoLuong"].VisibleIndex = 4;
            grdViewCt_PhieuNhap.Columns["DonGia"].VisibleIndex = 5;
            grdViewCt_PhieuNhap.Columns["ThanhTien"].VisibleIndex = 6;
            grdViewCt_PhieuNhap.Columns["ThoiLuong"].VisibleIndex = 7;
            grdViewCt_PhieuNhap.Columns["DienGiai"].VisibleIndex = 8;
            grdViewCt_PhieuNhap.Columns["MaTruong"].VisibleIndex = 9;
            //DonViTinh
            RepositoryItemGridLookUpEdit DVT_GrdLU = new RepositoryItemGridLookUpEdit();
            DVT_GrdLU.ExportMode = ExportMode.DisplayText;
            HamDungChung.InitRepositoryItemGridLookUpDev2(DVT_GrdLU, donViTinhListBindingSource, "MaQuanLy", "MaDonViTinh", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DVT_GrdLU, new string[] { "MaQuanLy", "TenDonViTinh" }, new string[] { "Mã ĐVT", "Tên ĐVT" }, new int[] { 100, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(grdViewCt_PhieuNhap, "MaDonViTinh", DVT_GrdLU);
            //

            //MaTruong
            RepositoryItemGridLookUpEdit MaTruong_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(MaTruong_GrdLU, bdMaTruong, "TenBoPhan", "MaBoPhan", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(MaTruong_GrdLU, new string[] { "MaBoPhanQL", "TenBoPhan" }, new string[] { "Mã Trường", "Tên Trường" }, new int[] { 100, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(grdViewCt_PhieuNhap, "MaTruong", MaTruong_GrdLU);

            ////LoaiThueSuatVAT
            //RepositoryItemGridLookUpEdit LoaiThueSuatVAT_grdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(LoaiThueSuatVAT_grdLU, LoaiThueSuatListBindingSource, "MoTa", "ThueSuat", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiThueSuatVAT_grdLU, new string[] { "MoTa" }, new string[] { "Thuế suất" }, new int[] { 90 }, false);
            //HamDungChung.RegisterControlFieldGridViewDev(grdViewCt_PhieuNhap, "ThueSuatVAT", LoaiThueSuatVAT_grdLU);
            #region Dinh Dang Danh So
            //Dinh Dang Danh So
            //"DonGia", "ThanhTien", "ChiPhiMuaHang"
            RepositoryItemCalcEdit repositoryItemCalcEditDonGia = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            repositoryItemCalcEditDonGia.AutoHeight = false;
            repositoryItemCalcEditDonGia.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditDonGia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repositoryItemCalcEditDonGia.Name = "repositoryItemCalcEditSoTien";
            grdViewCt_PhieuNhap.Columns["DonGia"].ColumnEdit = repositoryItemCalcEditDonGia;
            //ThanhTien
            RepositoryItemCalcEdit repositoryItemCalcEditThanhTien = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            repositoryItemCalcEditThanhTien.AutoHeight = false;
            repositoryItemCalcEditThanhTien.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditThanhTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repositoryItemCalcEditThanhTien.Name = "repositoryItemCalcEditThanhTien";
            grdViewCt_PhieuNhap.Columns["ThanhTien"].ColumnEdit = repositoryItemCalcEditThanhTien;
            //thời gian phân bổ
            RepositoryItemCalcEdit repositoryItemCalcEditThoiGianPB = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            repositoryItemCalcEditThoiGianPB.AutoHeight = false;
            repositoryItemCalcEditThoiGianPB.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditThoiGianPB.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repositoryItemCalcEditThoiGianPB.Name = "repositoryItemCalcEditThoiGianPB";
            grdViewCt_PhieuNhap.Columns["ThoiLuong"].ColumnEdit = repositoryItemCalcEditThoiGianPB;
            #endregion Dinh Dang Danh So
            //
            this.grdViewCt_PhieuNhap.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdViewCt_PhieuNhap_CellValueChanged);
            this.grdViewCt_PhieuNhap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdViewCt_PhieuNhap_KeyDown);
            this.grdViewCt_PhieuNhap.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdViewCt_PhieuNhap_InitNewRow);
            //this.grdCT_PhieuNhap.ContextMenuStrip = this.contextMenuStrip_HangHoa;
        }

        private void LoadDataForthongTinNhanVienTongHopListBindingSource(int maboPHan)
        {
            ThongTinNhanVienTongHopList thongtinnhanvienlist = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListKeCaNVBoPhanMoRong_ByMaBoPhan(maboPHan);
            ThongTinNhanVienTongHop ttnv = ThongTinNhanVienTongHop.NewThongTinNhanVienTongHop(0, "<<None>>");
            thongtinnhanvienlist.Insert(0, ttnv);
            thongTinNhanVienTongHopListBindingSource.DataSource = thongtinnhanvienlist;
        }

        private void LoadAllNhanVien()
        {
            isLoadCboNhanVien = false;
            ThongTinNhanVienTongHopList thongtinnhanvienlist = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListKeCaNVBoPhanMoRong_ByMaBoPhan(0);
            ThongTinNhanVienTongHop ttnv = ThongTinNhanVienTongHop.NewThongTinNhanVienTongHop(0, "<<None>>");
            thongtinnhanvienlist.Insert(0, ttnv);
            thongTinNhanVienTongHopListBindingSource.DataSource = thongtinnhanvienlist;
            isLoadCboNhanVien = true;
        }
        private void LoadDSTruong()
        {
            _dsTruong = BoPhanList.GetDSTruong();
            BoPhan bpEmpt = BoPhan.NewBoPhan("<<Không chọn>>");
            _dsTruong.Insert(0, bpEmpt);
            bdMaTruong.DataSource = _dsTruong;
        }
        void AllowDelete()
        {
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        void NotAllowDelete()
        {
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

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

        private void LoadInfoByMaPhieuNhapXuat(long maPhieu)
        {
            PhieuNhapXuatCCDC phieuxuat = PhieuNhapXuatCCDC.GetPhieuNhapXuat(maPhieu);
            KhoiTaoPhieu(phieuxuat);
            xtraTabControl1.SelectedTabPageIndex = 0;
            //CheckPhieuNhap();
            LoadLinkLabel((int)maPhieu);
        }

        private void SetDefaultValueButToan(ButToanPhieuNhapXuatCCDC butToan)
        {
            decimal tongtienCP = 0;
            decimal tongtienThue = 0;
            if (butToan != null)
            {
                foreach (CT_PhieuXuatCCDC ct_PhieuXuat in _phieuXuat.CT_PhieuXuatList)
                {
                    tongtienCP += ct_PhieuXuat.ThanhTien;
                    tongtienThue = tongtienThue + ct_PhieuXuat.TienThue;
                }
                foreach (ButToanPhieuNhapXuatCCDC buttoanphieu in _phieuXuat.ButToanPhieuNhapXuatList)
                {
                    if (IsTaiKhoanThueKhauTru(buttoanphieu.NoTaiKhoan))
                    {
                        tongtienThue = tongtienThue - buttoanphieu.SoTien;
                    }
                    else
                    {
                        tongtienCP = tongtienCP - buttoanphieu.SoTien;
                    }
                }
                if (IsTaiKhoanThueKhauTru(butToan.NoTaiKhoan))
                {
                    butToan.SoTien = tongtienThue;
                }
                else
                {
                    butToan.SoTien = tongtienCP;
                }
                butToan.DienGiai = _phieuXuat.DienGiai;
            }
        }
        private void Init_lookUpEdit_PPNXKho()
        {
            DataTable _dataTable = new DataTable();
            _dataTable.Columns.Add("Ma", typeof(byte));
            _dataTable.Columns.Add("Ten", typeof(string));

            _dataTable.Rows.Add(0, "<<Không chọn>>");
            _dataTable.Rows.Add(2, "Nhập Xuất Thẳng");
            _dataTable.Rows.Add(3, "CCDC quản lý");

            phuongPhapNXbindingSource_TimKiem.DataSource = _dataTable;
            lookUpEdit_PPNXKho_TimKiem.Properties.DataSource = phuongPhapNXbindingSource_TimKiem;
            this.lookUpEdit_PPNXKho_TimKiem.Properties.ValueMember = "Ma";
            this.lookUpEdit_PPNXKho_TimKiem.Properties.DisplayMember = "Ten";
            lookUpEdit_PPNXKho_TimKiem.Properties.NullText = "Không Chọn";
        }
        private void KhoiTaoThongTinTimKiem()
        {
            BoPhanERPNewList _BoPhanERPList = BoPhanERPNewList.GetBoPhanERPNewListAll();          
           bindingSource_BoPhanERPNew_Truong.DataSource = _BoPhanERPList;

            // BoPhanList _BoPhanList = BoPhanList.GetBoPhanList();
            BoPhanList _BoPhanList = BoPhanList.GetBoPhanListBy_All();
            BoPhan _BoPhan = BoPhan.NewBoPhan(0, "Không Chọn");
            _BoPhanList.Insert(0, _BoPhan);
            boPhanListBindingSource_TimKiem.DataSource = _BoPhanList;

            KhoBQ_VTList _KhoBQ_VTList = KhoBQ_VTList.GetKhoBQ_VTList();
            KhoBQ_VT _KhoBQ_VT = KhoBQ_VT.NewKhoBQ_VT();
            _KhoBQ_VT.TenKho = "Không Chọn";
            _KhoBQ_VTList.Insert(0, _KhoBQ_VT);
            khoBQVTListBindingSource_TimKiem.DataSource = _KhoBQ_VTList;

            Init_lookUpEdit_PPNXKho();

            phieuNhapXuatListBindingSource.DataSource = _phieuNhapXuatList;

            thongTinNhanVienTongHopListBindingSource_TimKiem.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopAll();
            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacListByTen(0);
            //
            boPhanListBindingSource1.DataSource = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
            thongTinNhanVienTongHopListBindingSource1.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopAll();
            khoBQVTListBindingSource1.DataSource = KhoBQ_VTList.GetKhoBQ_VTList();

            //CauTrucKhoanMucChiPhiList
            CauTrucDoanhThuChiPhiList khoanmuclist = CauTrucDoanhThuChiPhiList.GetCauTrucDoanhThuChiPhiList(ERP_Library.Security.CurrentUser.Info.MaCongTy);
            CauTrucDoanhThuChiPhi khoanmucE = CauTrucDoanhThuChiPhi.NewCauTrucDoanhThuChiPhi();
            khoanmucE.Ten = "";
            khoanmuclist.Insert(0, khoanmucE);
            CauTrucDoanhThuChiPhiList_bindingSource1.DataSource = khoanmuclist;
            //DonViList
            BoPhanList bophanlist = BoPhanList.GetBoPhanList();
            BoPhan bpEmpt = BoPhan.NewBoPhan("");
            bophanlist.Insert(0, bpEmpt);
            DonViList_bindingSource1.DataSource = bophanlist;

            //Load Doi Tuong No Co
            DoiTuongAllList doituongNoCoList = DoiTuongAllList.GetDoiTuongAllList_Tim("", 0); //_factory.Context.sp_AllDoiTuong(1, 0).Where(x => x.MaCongTy == _maCongTy).ToList();//Lấy đối tác
            DoiTuongAll doituongNCEmpty = DoiTuongAll.NewDoiTuongAll("");//new sp_AllDoiTuong_Result() { MaDoiTuong = 0, TenDoiTuong = "" };
            doituongNoCoList.Insert(0, doituongNCEmpty);
            DoiTuongNoList_BindingSource.DataSource = doituongNoCoList;
            DoiTuongCoList_BindingSource.DataSource = doituongNoCoList;

        }

        #endregion Functions

        #region EventHandles

        private void grdViewCt_PhieuNhap_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            CT_PhieuXuatCCDC ct_PhieuXuat = (CT_PhieuXuatCCDC)(cTPhieuXuatListBindingSource.Current);
            #region Customize
            bool coHieu = true;
            if (Object.ReferenceEquals(e.Column, grdViewCt_PhieuNhap.Columns["MaHangHoa"]) || Object.ReferenceEquals(e.Column, grdViewCt_PhieuNhap.Columns["SoLuong"]))//|| Object.ReferenceEquals(e.Column, grdViewCt_PhieuNhap.Columns["MaTruong"])) //(grdViewCt_PhieuNhap.FocusedColumn.Name == "colMaHangHoa" || grdViewCt_PhieuNhap.FocusedColumn.Name == "colSoLuong")
            {
                if (Object.ReferenceEquals(e.Column, grdViewCt_PhieuNhap.Columns["SoLuong"]))//(grdViewCt_PhieuNhap.FocusedColumn.Name == "colSoLuong")
                {
                    decimal _soLuongHienCo = HangHoaBQ_VT.GetSoLuongHangHoaNXT(_phieuXuat.MaPhieuNhapXuat, ct_PhieuXuat.MaPhieuNhap, ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime, ct_PhieuXuat.DonGia, ct_PhieuXuat.MaChiTietPhieuNhap, ct_PhieuXuat.MaCT_KetChuyen, ct_PhieuXuat.MaCT_KetChuyenCCDC);//New 19112013
                    if ((decimal)e.Value > _soLuongHienCo)
                    {
                        MessageBox.Show(String.Format("Không đủ {0}. Số lượng chỉ còn {1}.", e.Value.ToString(), _soLuongHienCo.ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        grdViewCt_PhieuNhap.SetRowCellValue(e.RowHandle, "SoLuong", _soLuongHienCo as object);//grdViewCt_PhieuNhap.SetRowCellValue(e.RowHandle, "SoLuong", (object)_soLuongHienCo); //# _ct_PhieuXuat.SoLuong = _soLuongHienCo;
                        coHieu = false;
                        return;
                    }
                }
                ////tinh thanh tien cho chi tiet
                //ct_PhieuXuat.ThanhTien = CT_PhieuXuat.TinhThanhTien(ct_PhieuXuat.SoLuong, ct_PhieuXuat.DonGia);
                if (coHieu)
                {
                    int maHangHoa = 0;
                    for (int j = 0; j < grdv_CongCuDungCu.RowCount; j++)//duyet qua tung ccdc
                    {
                        CCDC congCuDungCu = grdv_CongCuDungCu.GetRow(j) as CCDC;
                        int flag = 0;
                        if (maHangHoa == 0)
                        {
                            foreach (CT_PhieuXuatCCDC ct in _phieuXuat.CT_PhieuXuatList)
                            {
                                if (congCuDungCu.MaHangHoa == ct.MaHangHoa && congCuDungCu.MoTaTenCCDC == ct.MoTaTenCCDC)
                                {
                                    flag++;
                                    break;
                                }
                            }
                            //
                            if (flag == 0)
                            {
                                maHangHoa = congCuDungCu.MaHangHoa;
                                grdv_CongCuDungCu.DeleteRow(j);
                                j--;
                            }
                            else if (ct_PhieuXuat.MaHangHoa == congCuDungCu.MaHangHoa && congCuDungCu.MoTaTenCCDC == ct_PhieuXuat.MoTaTenCCDC)
                            {
                                grdv_CongCuDungCu.DeleteRow(j);
                                j--;
                            }
                        }
                        else if ((congCuDungCu.MaHangHoa == maHangHoa || ct_PhieuXuat.MaHangHoa == congCuDungCu.MaHangHoa)
                            && congCuDungCu.MoTaTenCCDC == ct_PhieuXuat.MoTaTenCCDC)
                        {
                            grdv_CongCuDungCu.DeleteRow(j);
                            j--;
                        }
                    }
                    //tao cac ccdc ca biet
                    int maTruong = 0;
                    if (ct_PhieuXuat.MaTruong != 0)
                    {
                        ////BoPhanERPNew truong = BoPhanERPNew.GetBoPhanERPNew_MaBoPhanQL(BoPhan.GetBoPhan(ct_PhieuXuat.MaTruong).MaBoPhanQL);
                        //if (truong != null)
                        //    maTruong = truong.MaBoPhan;
                    }
                    TaoCCDCCaBiet(ct_PhieuXuat, Convert.ToInt32(lookUpEdit_PhongBan.EditValue), maTruong, null);
                }

                #endregion//Customize

                #region Old
                //kiem tra so luong ton con du de xuat hay ko
                //tinh lai thanh tien cho tung ccdc
                //if (Object.ReferenceEquals(e.Column, this.colSoLuong))//(grdViewCt_PhieuNhap.FocusedColumn.Name == "colSoLuong")
                //{
                //    if (_phieuXuat.PhuongPhapNX == 2)//
                //    {
                //        decimal _soLuongHienCo = HangHoaBQ_VT.GetSoLuongHangHoaNXT(_phieuXuat.MaPhieuNhapXuat, ct_PhieuXuat.MaPhieuNhap, ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime, ct_PhieuXuat.DonGia);//New 19112013
                //        if ((decimal)e.Value > _soLuongHienCo)
                //        {
                //            MessageBox.Show(String.Format("Không đủ {0}. Số lượng chỉ còn {1}.", e.Value.ToString(), _soLuongHienCo.ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            grdViewCt_PhieuNhap.SetRowCellValue(e.RowHandle, "SoLuong", _soLuongHienCo as object);//grdViewCt_PhieuNhap.SetRowCellValue(e.RowHandle, "SoLuong", (object)_soLuongHienCo); //# _ct_PhieuXuat.SoLuong = _soLuongHienCo;
                //        }
                //        else if ((decimal)e.Value == _soLuongHienCo)
                //        {
                //            grdCT_PhieuNhap.Update();
                //            ct_PhieuXuat.ThanhTien = HangHoaBQ_VT.GetGiaTriHangHoaNXT(_phieuXuat.MaPhieuNhapXuat, ct_PhieuXuat.MaPhieuNhap, ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime, ct_PhieuXuat.DonGia);//New 19112013
                //        }
                //    }
                //    else
                //    {
                //        decimal _soLuongHienCo = HangHoaBQ_VT.GetSoLuongHangHoaBinhQuan(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaKho, ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                //        if ((decimal)e.Value > _soLuongHienCo)
                //        {
                //            MessageBox.Show(String.Format("Không đủ {0}. Số lượng chỉ còn {1}.", e.Value.ToString(), _soLuongHienCo.ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            grdViewCt_PhieuNhap.SetRowCellValue(e.RowHandle, this.colSoLuong, 0);//grdViewCt_PhieuNhap.SetRowCellValue(e.RowHandle, "SoLuong", (object)_soLuongHienCo); //# _ct_PhieuXuat.SoLuong = _soLuongHienCo;
                //        }
                //        else if ((decimal)e.Value == _soLuongHienCo)
                //        {
                //            grdCT_PhieuNhap.Update();
                //            ct_PhieuXuat.ThanhTien = HangHoaBQ_VT.GetGiaTriHangHoaBinhQuan(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaKho, ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                //        }
                //    }
                //}

                ////---------------------------------
                //if (Object.ReferenceEquals(e.Column, this.colMaHangHoa) || Object.ReferenceEquals(e.Column, this.colSoLuong)) //(grdViewCt_PhieuNhap.FocusedColumn.Name == "colMaHangHoa" || grdViewCt_PhieuNhap.FocusedColumn.Name == "colSoLuong")
                //{

                //    if (_phieuXuat.PhuongPhapNX == 1)//
                //    {
                //        ct_PhieuXuat.DonGia = HangHoaBQ_VT.GetGiaTriBinhQuanHangHoa(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaKho, ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                //    }
                //    //tinh thanh tien cho chi tiet
                //    ct_PhieuXuat.ThanhTien = CT_PhieuXuat.TinhThanhTien(ct_PhieuXuat.SoLuong, ct_PhieuXuat.DonGia);

                //    int maHangHoa = 0;
                //    for (int j = 0; j < grdv_CongCuDungCu.RowCount; j++)//duyet qua tung ccdc
                //    {
                //        CCDC congCuDungCu = grdv_CongCuDungCu.GetRow(j) as CCDC;
                //        int flag = 0;
                //        if (maHangHoa == 0)
                //        {
                //            foreach (CT_PhieuXuatCCDC ct in _phieuXuat.CT_PhieuXuatList)
                //            {
                //                if (congCuDungCu.MaHangHoa == ct.MaHangHoa && congCuDungCu.NguyenGia == ct.DonGia)
                //                {
                //                    flag++;
                //                    break;
                //                }
                //            }
                //            //
                //            if (flag == 0)
                //            {
                //                maHangHoa = congCuDungCu.MaHangHoa;
                //                grdv_CongCuDungCu.DeleteRow(j);
                //                j--;
                //            }
                //            else if (ct_PhieuXuat.MaHangHoa == congCuDungCu.MaHangHoa && congCuDungCu.NguyenGia == ct_PhieuXuat.DonGia)
                //            {
                //                grdv_CongCuDungCu.DeleteRow(j);
                //                j--;
                //            }
                //        }
                //        else if ((congCuDungCu.MaHangHoa == maHangHoa || ct_PhieuXuat.MaHangHoa == congCuDungCu.MaHangHoa)
                //            && congCuDungCu.NguyenGia == ct_PhieuXuat.DonGia)
                //        {
                //            grdv_CongCuDungCu.DeleteRow(j);
                //            j--;
                //        }
                //    }

                //    //tao cac ccdc ca biet

                //    TaoCCDCCaBiet(ct_PhieuXuat, Convert.ToInt32(lookUpEdit_PhongBan.EditValue), null);
                //}
                //else if (grdViewCt_PhieuNhap.FocusedColumn.Name == "colDonGia")
                //{
                //    foreach (CCDC congCuDungCu in _phieuXuat.CongCuDungCuList)
                //    {
                //        if (congCuDungCu.MaHangHoa == ct_PhieuXuat.MaHangHoa)
                //        {
                //            congCuDungCu.NguyenGia = ct_PhieuXuat.DonGia;
                //        }
                //    }
                //}
                ////--------------------------- 
                #endregion//Old
                //----------------------------
                congCuDungCuListBindingSource.EndEdit();
                grdv_CongCuDungCu.RefreshData();
                //--------------------------------
                //tính lai tong tien cua phieu xuat
                if (Object.ReferenceEquals(e.Column, grdViewCt_PhieuNhap.Columns["SoLuong"]) || Object.ReferenceEquals(e.Column, grdViewCt_PhieuNhap.Columns["DonGia"]))//(grdViewCt_PhieuNhap.FocusedColumn.Name == "colSoLuong" || grdViewCt_PhieuNhap.FocusedColumn.Name == "colDonGia")
                {
                    TinhTongTienChoPhieuXuat();
                    this.isThayDoiSoLieu = true;
                }
            }
        }

        private void grdViewCt_PhieuNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (!CheckValidWhenChangeNgayNX()) return;
                if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa các dòng chi tiết phiếu xuất đang chọn trên lưới?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    foreach (int i in grdViewCt_PhieuNhap.GetSelectedRows())
                    {
                        CT_PhieuXuatCCDC ct_Phieu = _phieuXuat.CT_PhieuXuatList[i];
                        for (int j = 0; j < grdv_CongCuDungCu.RowCount; j++)
                        {
                            CCDC congCu = grdv_CongCuDungCu.GetRow(j) as CCDC;
                            if (congCu.MaHangHoa == ct_Phieu.MaHangHoa && congCu.MoTaTenCCDC == ct_Phieu.MoTaTenCCDC)
                            {
                                grdv_CongCuDungCu.DeleteRow(j);
                                j--;
                            }
                        }
                        //_phieuXuat.GiaTriKho = _phieuXuat.GiaTriKho - ct_Phieu.ThanhTien-ct_Phieu.TienChietKhau;
                        grdViewCt_PhieuNhap.DeleteRow(i);
                    }
                    TinhTongTienChoPhieuXuat();
                }
                //else if (e.KeyCode == Keys.Tab)
                //{
                //    if (grdViewCt_PhieuNhap.FocusedRowHandle < 0)
                //    {
                //        grdViewCt_PhieuNhap.MoveFirst();
                //    }
                //}
            }
        }

        private void grdViewCt_PhieuNhap_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            if (_phieuXuat.PhuongPhapNX == 2 || _phieuXuat.PhuongPhapNX == 3)//xuat thang
            {
                this.grdViewCt_PhieuNhap.DeleteRow(e.RowHandle);
            }
            else if (_phieuXuat.PhuongPhapNX == 1)
            {
                CT_PhieuXuatCCDC ct = this.cTPhieuXuatListBindingSource.Current as CT_PhieuXuatCCDC;
                ct.DienGiai = this.txtDienGiai.Text;
            }
        }

        #endregion EventHandles

        #region KhoiTaoPhieu()
        private void KhoiTaoPhieu()
        {
            //calcEdit_phantramphanbo.EditValue = 100;
            _phieuXuat = PhieuNhapXuatCCDC.NewPhieuNhapXuat();
            _phieuXuat.Loai = 3;
            _phieuXuat.PhuongPhapNX = 3;
            _phieuXuat.LaNhap = false;
            //_phieuNhapXuat.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuNhapXuat.Loai, _phieuNhapXuat.LaNhap, _phieuNhapXuat.NgayNX);
            TaoSoPhieu();
            //mac dinh kho dau tien trong danh sach
            if (this.khoBQVTListBindingSource.Count != 0)
                _phieuXuat.MaKho = _khoBQ_VTList[0].MaKho;
            //
            _phieuXuat.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            BindingDataSource();

            formatGridviewDinhKhoan();
        }

        private void TaoSoPhieu()
        {
            //_phieuXuat.SoPhieu = PhieuNhapXuatCCDC.Get_NextSoChungTuNhapXuatCongCuDungCu(laNhap: _phieuXuat.LaNhap
            //                , maBoPhan: ERP_Library.Security.CurrentUser.Info.MaBoPhan
            //                , maQLUser: ERP_Library.Security.CurrentUser.Info.MaQLUser
            //                , year: _phieuXuat.NgayNX.Year, size: 4);
            _phieuXuat.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuXuat.Loai, _phieuXuat.LaNhap, _phieuXuat.NgayNX);
        }
        #endregion

        #region KhoiTaoPhieu(PhieuNhapXuat phieuNhapXuat)
        private void KhoiTaoPhieu(PhieuNhapXuatCCDC phieuNhapXuat)
        {
            if (_loai == 0)//truong phieu xuat da ton tai(phieu nhap xuat goi vao la phieu xuat)
            {
                _phieuXuat = phieuNhapXuat;
                _ngayLapCu = _phieuXuat.NgayNX;
                _coTKBiKhoa = CheckCoTaiKhoanBiKhoaTrongButToan();
                if (_phieuXuat.CongCuDungCuList.Count != 0)
                {
                    textEditThoiGianSuDung.EditValue = _phieuXuat.CongCuDungCuList[0].ThoiGianSuDung;
                }
            }
            else if (_loai == 1)//phieu xuat chua ton tai, can tao phieu xuat moi(phieu nhap xuat goi vao la phieu nhap)
            {
                textEditThoiGianSuDung.EditValue = _phieuXuat.PhuongPhapNX == 2 ? 0 : 12;
                //_phieuXuat = PhieuNhapXuat.NewPhieuNhapXuat(phieuNhapXuat);
                _phieuXuat = PhieuNhapXuatCCDC.NewPhieuNhapXuat(phieuNhapXuat, 3);
                _phieuXuat.Loai = 3;
                _phieuXuat.LaNhap = false;
                this.TaoSoPhieu();
                _phieuXuat.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            }
            //
            BindingDataSource();
            tabControl_CCDC.SelectedTabPage = tabControl_CCDC.TabPages[1];
        }

        private void BindingDataSource()
        {
            cTPhieuXuatListBindingSource.DataSource = _phieuXuat.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuat.ButToanPhieuNhapXuatList;
            congCuDungCuListBindingSource.DataSource = _phieuXuat.CongCuDungCuList;
            phieuNhapXuatBindingSource.DataSource = _phieuXuat;
            grdCT_PhieuNhap.DataSource = cTPhieuXuatListBindingSource;
            grd_CongCuDungCu.DataSource = congCuDungCuListBindingSource;
            grdv_CongCuDungCu.RefreshData();
            grd_CongCuDungCu.Refresh();
            grd_DinhKhoan.DataSource = butToanPhieuNhapXuatListBindingSource;
        }
        #endregion

        #region KhoiTao()
        private void KhoiTao()
        {
            phieuNhapXuatBindingSource.DataSource = typeof(PhieuNhapXuatCCDC);
            cTPhieuXuatListBindingSource.DataSource = typeof(CT_PhieuXuatCCDC);
            butToanPhieuNhapXuatListBindingSource.DataSource = typeof(ButToanPhieuNhapXuatCCDCList);
            congCuDungCuListBindingSource.DataSource = typeof(CCDCList);

            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(3);
            hangHoaBQVTListBindingSource1.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(3);
            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            doiTacListBindingSource1.DataSource = DoiTacList.GetDoiTacListByTen(0);

            //doiTuongAllListBindingSource.DataSource = DoiTuongAllList.GetDoiTuongAllList();            
            boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
            //
            _khoBQ_VTList = KhoBQ_VTList.GetKhoBQ_VTList(3);
            khoBQVTListBindingSource.DataSource = _khoBQ_VTList;

            LoadAllNhanVien();
            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Không Chọn");
            _DoiTacList.Insert(0, _DoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;

            _tieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList();
            TieuMucNganSach _tieuMucNganSach = TieuMucNganSach.NewTieuMucNganSach("Không Chọn", "Không Chọn");
            _tieuMucNganSachList.Insert(0, _tieuMucNganSach);
            tieuMucNganSachListBindingSource.DataSource = _tieuMucNganSachList;
            Init_lookUpEdit_PhongBan();
            //Loai Thue VAT
            LoaiThueSuatListBindingSource.DataSource = LoaiThueSuatVAT.CreateListLoaiThueSuatVAT();

            LoadDSTruong();

            DesignGrid_grdViewCt_PhieuNhap();
        }
        #endregion

        #region KhoaSoTaiKhoan

        private void LockgrdView_DinhKhoan()
        {

            grdView_DinhKhoan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit = false;
            grdView_DinhKhoan.Columns["CoTaiKhoan"].OptionsColumn.AllowEdit = false;
            grdView_DinhKhoan.Columns["SoTien"].OptionsColumn.AllowEdit = false;
            //grdView_DinhKhoan.Columns["MaDoiTuongCo"].OptionsColumn.AllowEdit = false;
            //grdView_DinhKhoan.Columns["MaDoiTuongNo"].OptionsColumn.AllowEdit = false;//
            //grdView_DinhKhoan.Columns["DienGiai"].OptionsColumn.AllowEdit = false;

        }//Them

        private void UnLockgrdView_DinhKhoan()
        {

            grdView_DinhKhoan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit = true;
            grdView_DinhKhoan.Columns["CoTaiKhoan"].OptionsColumn.AllowEdit = true;
            grdView_DinhKhoan.Columns["SoTien"].OptionsColumn.AllowEdit = true;
            //grdView_DinhKhoan.Columns["MaDoiTuongCo"].OptionsColumn.AllowEdit = true;
            //grdView_DinhKhoan.Columns["MaDoiTuongNo"].OptionsColumn.AllowEdit = true;//
            //grdView_DinhKhoan.Columns["DienGiai"].OptionsColumn.AllowEdit = true;
        }//Them

        private bool CheckCoTaiKhoanBiKhoaTrongButToan()
        {
            foreach (ButToanPhieuNhapXuatCCDC buttoan in _phieuXuat.ButToanPhieuNhapXuatList)
            {
                //tblTaiKhoan tk = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(buttoan.NoTaiKhoan ?? 0);
                //tblTaiKhoan tkco = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(buttoan.CoTaiKhoan ?? 0);
                if (KhoaButToanTheoTaiKhoan(buttoan.NoTaiKhoan) || KhoaButToanTheoTaiKhoan(buttoan.CoTaiKhoan))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckValidKhoaTaiKhoanWhenChangeNgayCT()//Them
        {
            if (CheckCoTaiKhoanBiKhoaTrongButToan())
            {
                MessageBox.Show("Ngày thay đổi rơi vào ngày Khóa Tài khoản, không thể thực hiện", "Thông Báo");
                _phieuXuat.NgayNX = _ngayLapCu;
                dateEdit_NgayLap.EditValue = _ngayLapCu as object;
                return false;
            }
            return true;
        }

        private bool KhoaButToanTheoTaiKhoan(int mataiKhoan)
        {

            bool khoataiKhoan = false;
            KhoaSo_MaTaiKhoanRootList khoa = KhoaSo_MaTaiKhoanRootList.GetKhoaSo_MaTaiKhoanRootList(UserId, mataiKhoan, _phieuXuat.NgayNX);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    khoataiKhoan = true;
                }
            }

            if (khoataiKhoan == false && _phieuXuat.IsNew == false)
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
        private void EventRowOrColumnGrdView_DinhKhoanChange()
        {
            UnLockgrdView_DinhKhoan();
            if (grdView_DinhKhoan.GetFocusedRow() != null)
            {
                ButToanPhieuNhapXuatCCDC buttoan = (ButToanPhieuNhapXuatCCDC)grdView_DinhKhoan.GetFocusedRow();
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

            #region KhoaSoThue
            //if (KhoaSoThue())
            //{
            //    if (grdView_DinhKhoan.GetFocusedRow() != null)
            //    {
            //        ButToanPhieuNhapXuat buttoan = (ButToanPhieuNhapXuat)grdView_DinhKhoan.GetFocusedRow();
            //        HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.NoTaiKhoan);
            //        if (tk.SoHieuTK.StartsWith("3113"))
            //        {
            //            LockgrdView_DinhKhoan();
            //        }
            //        else
            //        {
            //            UnLockgrdView_DinhKhoan();
            //        }
            //    }
            //}
            //else
            //{
            //    UnLockgrdView_DinhKhoan();
            //}
            #endregion//KhoaSoThue


        }//Them

        #endregion //KhoaSoTaiKhoan

        private bool CheckValidWhenChangeNgayNX()//Them
        {
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_phieuXuat.NgayNX);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    MessageBox.Show("Đã khóa sổ, không thể thực hiện!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (!CCDC.KiemTraThaoTacCCDCHopLe(_phieuXuat.NgayNX))
            {
                MessageBox.Show(string.Format("Đã thực hiện kết chuyển sang năm {0}, không thể thực hiện!", (_phieuXuat.NgayNX.Year + 1).ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_phieuXuat.IsNew == false)
            {
                khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ngayLapCu);
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSo == true)
                    {
                        MessageBox.Show("Đã khóa sổ, không thể thực hiện!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (!CCDC.KiemTraThaoTacCCDCHopLe(_ngayLapCu))
                {
                    MessageBox.Show(string.Format("Đã thực hiện kết chuyển sang năm {0}, không thể thực hiện!", (_ngayLapCu.Year + 1).ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private bool KiemTraChiTiet()
        {
            bool kq = true;
            foreach (CT_PhieuXuatCCDC ct_phieuXuat in _phieuXuat.CT_PhieuXuatList)
            {
                if (ct_phieuXuat.MaHangHoa == 0)
                {
                    kq = false;
                    MessageBox.Show(this, "Vui lòng nhập hàng hóa cho chi tiết", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                else if (ct_phieuXuat.SoLuong == 0)
                {
                    kq = false;
                    MessageBox.Show(this, "Vui lòng nhập số lượng cho chi tiết", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }

            //Kiem tra but toan
            foreach (ButToanPhieuNhapXuatCCDC bt in _phieuXuat.ButToanPhieuNhapXuatList)
            {
                #region Kiểm Tra chi phí sản xuất

                HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.NoTaiKhoan);
                HeThongTaiKhoan1 taiKhoanCo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.CoTaiKhoan);
                string noTK = taiKhoanNo.SoHieuTK;
                string CoTK = taiKhoanCo.SoHieuTK;


                if (taiKhoanNo.CoTheoDoiKhoanMucChiPhi == true || taiKhoanCo.CoTheoDoiKhoanMucChiPhi == true)
                {
                    if (bt.IDKhoanMuc == 0)
                    {
                        MessageBox.Show(this, "Vui lòng chọn khoản mục CP cho bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                //if (noTK == "1551" || noTK == "1552" || CoTK == "1551" || CoTK == "1552" || noTK.StartsWith("631") || noTK.StartsWith("4314"))
                //{
                //    if (bt.ChungTu_ChiPhiSanXuatList.Count == 0)
                //    {
                //        MessageBox.Show(this, "Bạn phải chọn công việc/chương trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return false;
                //    }
                //    else
                //    {
                //        foreach (ChungTu_ChiPhiSanXuat cp in bt.ChungTu_ChiPhiSanXuatList)
                //        {
                //            if (cp.ButtoanMucNganSachList.Count == 0 && (noTK.StartsWith("631") || noTK.StartsWith("4314")))
                //            {
                //                MessageBox.Show(this, "Vui lòng nhập mục ngân sách", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //                return false;
                //            }
                //        }
                //    }
                //}

                //if (bt.ChungTu_ChiPhiSanXuatList.Count > 0)
                //{
                //    decimal sotienCTu = 0;
                //    foreach (ChungTu_ChiPhiSanXuat ct_cp in bt.ChungTu_ChiPhiSanXuatList)
                //    {
                //        sotienCTu += ct_cp.SoTien;
                //    }
                //    if (bt.SoTien != sotienCTu)
                //    {
                //        MessageBox.Show(this, "Tổng số tiền Công việc/Chương trình không bằng số tiền bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return false; ;
                //    }
                //}
                #endregion//Kiểm Tra chi phí sản xuất
            }

            return kq;
        }

        private bool KiemTraHopLeDuLieu()
        {
            if (!CheckValidWhenChangeNgayNX()) return false;
            if (_phieuXuat.XacNhan == true)//Kiem Tra Thu Kho Xac Nhan
            {
                MessageBox.Show(this, "Thủ kho đã xác nhận,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //kiem tra trung so phieu
            if (PhieuNhapXuatCCDC.KiemTraTrungSoChungTuNhapXuat(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.SoPhieu))
            {
                if (DialogResult.Yes == MessageBox.Show(this, "Số phiếu " + _phieuXuat.SoPhieu + " đã trùng. Chọn Yes để tự động sinh số phiếu mới", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    this.TaoSoPhieu();
                }
                else
                {
                    this.txtSoPhieu.Focus();
                    return false;
                }
            }

            if (_phieuXuat.MaPhongBan == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn phòng ban", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEdit_PhongBan.Focus();
                return false;
            }
            //if (_phieuXuat.MaNguoiNhapXuat == 0)
            //{
            //    MessageBox.Show(this, "Vui lòng chọn nhân viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    lookUpEdit_NhanVien.Focus();
            //    return false;
            //}
            if (_phieuXuat.MaKho == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn kho xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEdit_KhoNhan.Focus();
                return false;
            }
            if (_phieuXuat.CT_PhieuXuatList.Count == 0)
            {
                MessageBox.Show(this, "Vui lòng nhập chi tiết phiếu xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (KiemTraChiTiet() == false)
            {
                grdViewCt_PhieuNhap.Focus();
                return false;
            }

            return true;
        }

        private void CheclValidCCDCQuanLy_CheckBox()
        {
            bool check = true;
            foreach (CCDC cc in _phieuXuat.CongCuDungCuList)
            {
                if (cc.HasManage == false)
                {
                    check = false;
                    break;
                }
            }
            CCDCQuanLy_checkBox.Checked = check;
        }

        #region Vat Tu_Ban Quyen
        private void anHiencottheoyeucau()
        {
            //this.ColMaTieuMuc.Visible = false;
            //this.col_btn.Visible = true;
        }
        private void formatGridviewDinhKhoan()
        {
            if (!_phieuXuat.IsNew)
            {
                if (_phieuXuat.ButToanPhieuNhapXuatList.Count > 0)
                {
                    foreach (ButToanPhieuNhapXuatCCDC bt in _phieuXuat.ButToanPhieuNhapXuatList)
                    {
                        if (bt.ButToan_MucNganSach.MaCT_ChiPhiSanXuat == 0)
                        {
                            this.ColMaTieuMuc.Visible = true;
                            this.col_btn.Visible = false;
                        }
                        else
                        {
                            anHiencottheoyeucau();
                        }
                    }
                }
                else
                {
                    anHiencottheoyeucau();
                }
            }
            else
            {
                anHiencottheoyeucau();
            }
        }
        #endregion//Vat Tu_Ban Quyen

        #region lookUpEdit_PhongBan_EditValueChanged
        private void lookUpEdit_PhongBan_EditValueChanged(object sender, EventArgs e)
        {
            //if (lookUpEdit_PhongBan.EditValue != null && _edtiBophan)
            //{
            //    int mabophabout;
            //    if (int.TryParse(lookUpEdit_PhongBan.EditValue.ToString(), out mabophabout))
            //    {
            //        LoadDataForthongTinNhanVienTongHopListBindingSource(mabophabout);
            //    }
            //    foreach (CCDC ccdc in _phieuXuat.CongCuDungCuList)
            //    {
            //        ccdc.CongCuDungCu_PhongBan.MaBoPhan = Convert.ToInt32(lookUpEdit_PhongBan.EditValue);
            //    }
            //}
        }
        #endregion

        private void Init_lookUpEdit_PhongBan()
        {
            DataTable _dataTable = new DataTable();

            _dataTable.Columns.Add("Ma", typeof(byte));
            _dataTable.Columns.Add("Ten", typeof(string));

            _dataTable.Rows.Add(2, "Nhập xuất thẳng");
            _dataTable.Rows.Add(3, "CCDC quản lý");

            phuongPhapNXbindingSource.DataSource = _dataTable;
            lookUpEdit_PPNXKho.Properties.DataSource = phuongPhapNXbindingSource;
            this.lookUpEdit_PPNXKho.Properties.ValueMember = "Ma";
            this.lookUpEdit_PPNXKho.Properties.DisplayMember = "Ten";
            lookUpEdit_PPNXKho.Properties.NullText = "<<chọn PPNX>>";
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_coTKBiKhoa || CheckCoTaiKhoanBiKhoaTrongButToan())
            {
                MessageBox.Show("Tài khoản đã bị khóa, k thể lưu", "Thông Báo");
                return;
            }
            Save();
        }

        private bool Save()
        {
            bool result = true;
            this.txtBlackHole.Focus();
            txtCCDCFocus.Focus();
            txtDKFocus.Focus();
            try
            {
                if (KiemTraHopLeDuLieu() == true)
                {
                    if (_phieuXuat.ButToanPhieuNhapXuatList.Count == 0 && _phieuXuat.GiaTriKho != 0)
                    {
                        MessageBox.Show("Chứng từ chưa được hạch toán, bạn vui lòng hạch toán!");
                        return false;
                        //if (System.Windows.Forms.DialogResult.Yes != MessageBox.Show("Chưa nhập định khoản! Bạn có muốn lưu phiếu với định khoản rỗng?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        //{
                        //    result = false;//khong chap nhan luu trong khi dinh khoan chua nhap
                        //}
                    }

                    if (result == true)
                    {
                        phieuNhapXuatBindingSource.EndEdit();
                        _phieuXuat.ApplyEdit();
                        _phieuXuat.Save();
                        _ngayLapCu = _phieuXuat.NgayNX;
                        MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập Nhật Thất Bại!\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }
            return result;
        }

        #region lookUpEdit_PPNXKho_EditValueChanged
        private void lookUpEdit_PPNXKho_EditValueChanged(object sender, EventArgs e)
        {
            byte ppnx = 0;
            byte.TryParse(lookUpEdit_PPNXKho.EditValue.ToString(), out ppnx);
            ////
            if ((byte)(ppnx) == 3)//binh quan
            {
                textEditThoiGianSuDung.EditValue = 12;
                //calcEdit_phantramphanbo.EditValue = 0;
                //this.btnChonPhieuNhapThang.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;//an
            }
            else if ((byte)(ppnx) == 2)//thang
            {
                textEditThoiGianSuDung.EditValue = 0;
                //calcEdit_phantramphanbo.EditValue = 100;
                //this.btnChonPhieuNhapThang.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;//hien
            }
        }
        #endregion

        private void TinhTongTienChoPhieuXuat()
        {
            Decimal tongTien = 0;
            foreach (CT_PhieuXuatCCDC ct in _phieuXuat.CT_PhieuXuatList)
            {
                tongTien += ct.ThanhTien;
            }
            _phieuXuat.GiaTriKho = tongTien;
        }

        private CCDC TaoCCDCCaBiet(CT_PhieuXuatCCDC ct_PhieuXuat, int maPhongBan, int maTruong, CCDC ccdc)
        {
            _CheckAllCCDCQuanLy = false;
            CCDCQuanLy_checkBox.Checked = true;
            #region Old
            //String maxSoHieu = "";
            //if (ct_PhieuXuat.SoLuong != 0)
            //{
            //    int thuTuMaQuanLyCCDC;
            //    string maQuanLyCCDC = "";

            //    HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_PhieuXuat.MaHangHoa);
            //    ct_PhieuXuat.MaDonViTinh = hangHoa.MaDonViTinh;

            //    if (ccdc == null)
            //    {
            //        //lay cong cu dung cu sau cung thuoc hang hoa
            //        ccdc = CongCuDungCu.GetCongCuDungCuByMaHangHoa(hangHoa.MaHangHoa);

            //    }
            //    maxSoHieu = ccdc.MaQuanLy;


            //    if (String.IsNullOrWhiteSpace(maxSoHieu) == false)
            //    {
            //        thuTuMaQuanLyCCDC = Convert.ToInt32(maxSoHieu.Substring(maxSoHieu.Length - 4)) + 1;//tang len 1 don vi
            //    }
            //    else
            //    {
            //        thuTuMaQuanLyCCDC = 1;//cong cu dau tien thuoc hang hoa
            //    }
            //    Int32 size = 4;

            //    for (int i = 0; i < ct_PhieuXuat.SoLuong; i++)
            //    {
            //        String phanTangStr = new String('0', size - thuTuMaQuanLyCCDC.ToString().Length) + thuTuMaQuanLyCCDC.ToString();
            //        maQuanLyCCDC = hangHoa.MaQuanLy + phanTangStr;


            //        /*
            //        if (thuTuMaQuanLyCCDC < 10)
            //            maQuanLyCCDC = hangHoa.MaQuanLy + "000" + thuTuMaQuanLyCCDC.ToString();
            //        else if (thuTuMaQuanLyCCDC < 100)
            //            maQuanLyCCDC = hangHoa.MaQuanLy + "00" + thuTuMaQuanLyCCDC.ToString();
            //        else if (thuTuMaQuanLyCCDC < 1000)
            //            maQuanLyCCDC = hangHoa.MaQuanLy + "0" + thuTuMaQuanLyCCDC.ToString();
            //        else if (thuTuMaQuanLyCCDC < 10000)
            //            maQuanLyCCDC = hangHoa.MaQuanLy + thuTuMaQuanLyCCDC.ToString();
            //        */
            //        CongCuDungCu cc = CongCuDungCu.NewCongCuDungCu(maQuanLyCCDC, "", maPhongBan, hangHoa.MaHangHoa, ct_PhieuXuat.DonGia, Convert.ToDateTime(dateEdit_NgayLap.EditValue), Convert.ToDecimal(txt_PhanTramPhanBo.EditValue));
            //        cc.NgayNhan = DateTime.Now.Date;
            //        _phieuXuat.CongCuDungCuList.Add(cc);
            //        thuTuMaQuanLyCCDC = thuTuMaQuanLyCCDC + 1;//tang len 1 don vi
            //        ccdc = cc;
            //    }
            //}
            //return ccdc;
            #endregion

            #region New
            String maxSoHieu = "";
            if (ct_PhieuXuat != null && ct_PhieuXuat.SoLuong != 0)
            {
                int thuTuMaQuanLyCCDC;
                string maQuanLyCCDC = "";
                string maQuanLy = "";
                string nam = _phieuXuat.NgayNX.Year.ToString().Substring(2, 2);

                HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_PhieuXuat.MaHangHoa);
                ct_PhieuXuat.MaDonViTinh = hangHoa.MaDonViTinh;

                if (ccdc == null)
                {
                    //lay cong cu dung cu sau cung thuoc hang hoa
                    ccdc = CCDC.GetCongCuDungCuByMaHangHoa(hangHoa.MaHangHoa);
                }
                if (ccdc != null)
                    maxSoHieu = ccdc.MaQuanLy;
                if (String.IsNullOrWhiteSpace(maxSoHieu) == false)
                {
                    thuTuMaQuanLyCCDC = Convert.ToInt32(maxSoHieu.Substring(maxSoHieu.Length - 4)) + 1;//tang len 1 don vi
                    //maQuanLy = nam + ccdc.MaQuanLy.Substring(0, ccdc.MaQuanLy.Length - 4).Substring(2, ccdc.MaQuanLy.Length - 6);
                    //maQuanLy = nam + '.' + hangHoa.MaQuanLy.Substring(0, 7) + '.';//congCu.MaQuanLy.Substring(0, congCu.MaQuanLy.Length - 4).Substring(2, congCu.MaQuanLy.Length - 6);
                }
                else
                {
                    thuTuMaQuanLyCCDC = 1;//cong cu dau tien thuoc hang hoa
                    //maQuanLy = nam + '.' + (NhomHangHoaBQ_VT.GetNhomHangHoaBQ_VT(hangHoa.MaNhomHangHoa)).MaQuanLy + '.';
                    //maQuanLy = nam + '.' + hangHoa.MaQuanLy + '.';
                    //maQuanLy = nam + '.' + hangHoa.MaQuanLy.Substring(0, 7) + '.';
                }
                maQuanLy = hangHoa.MaQuanLy;

                Int32 size = 4;
                decimal _phanTram = 0;
                //if (calcEdit_phantramphanbo.EditValue != null)
                //{
                //    _phanTram = Convert.ToDecimal(calcEdit_phantramphanbo.EditValue.ToString());// Convert.ToDecimal("50,6"); //
                //}
                decimal nguyengia = 0;
                for (int i = 0; i < ct_PhieuXuat.SoLuong; i++)
                {
                    //Tinh Nguyen Gia
                    nguyengia = Math.Floor(ct_PhieuXuat.ThanhTien / ct_PhieuXuat.SoLuong);
                    if ((ct_PhieuXuat.ThanhTien % ct_PhieuXuat.SoLuong) != 0)
                    {
                        if (i == (ct_PhieuXuat.SoLuong - 1))
                        {
                            nguyengia = nguyengia + (ct_PhieuXuat.ThanhTien % ct_PhieuXuat.SoLuong);
                        }
                    }

                    String phanTangStr = new String('0', size - thuTuMaQuanLyCCDC.ToString().Length) + thuTuMaQuanLyCCDC.ToString();
                    maQuanLyCCDC = maQuanLy + phanTangStr;
                    CCDC cc = CCDC.NewCongCuDungCu(maQuanLyCCDC, "", maPhongBan, maTruong,hangHoa.MaHangHoa, nguyengia, _phieuXuat.NgayNX, _phanTram);
                    //cc.ThoiGianSuDung = _phieuXuat.PhuongPhapNX == 2 ? 0 : 3;
                    cc.ThoiGianSuDung = (Int32)ct_PhieuXuat.ThoiLuong;
                    if (_phieuXuat.PhuongPhapNX == 2)
                    {
                        cc.PhanTramPBLanDau = 100;
                        cc.ChiPhiPBLanDau = cc.NguyenGia;
                    }
                    cc.NgayNhan = _phieuXuat.NgayNX; //DateTime.Now.Date;
                    cc.HasManage = true;//-- (_phieuXuat.PhuongPhapNX == 3 ? true : false);
                    cc.MoTaTenCCDC = ct_PhieuXuat.MoTaTenCCDC;
                    _phieuXuat.CongCuDungCuList.Add(cc);
                    thuTuMaQuanLyCCDC = thuTuMaQuanLyCCDC + 1;//tang len 1 don vi
                    ccdc = cc;
                }
            }
            return ccdc;
            #endregion
        }

        #region btn_HoaDon_ItemClick
        private void btn_HoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region Phieu Xuat khong co Hoa Don
            //if (_phieuXuat.IsNew || _phieuXuat.HoaDon_NhapXuatList.Count == 0)
            //{
            //    frmChonHoaDonLapPhieu frm = new frmChonHoaDonLapPhieu(_phieuXuat.MaDoiTac);
            //    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            //    {
            //        if (frm.TrangThai == true)
            //        {
            //            _phieuXuat.HoaDon_NhapXuatList = frm.HoaDon_NhapXuatList;
            //        }
            //    }
            //}
            //else
            //{
            //    frmChonHoaDonLapPhieu frm = new frmChonHoaDonLapPhieu(_phieuXuat);
            //    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            //    {
            //        if (frm.TrangThai == true)
            //        {
            //            _phieuXuat.HoaDon_NhapXuatList = frm.HoaDon_NhapXuatList;
            //            _phieuXuat.ApplyEdit();
            //            _phieuXuat.Save();
            //        }
            //    }
            //}
            #endregion
        }
        #endregion

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _coTKBiKhoa = false;
            lookUpEdit_PPNXKho.Enabled = true;
            KhoiTaoPhieu();
        }

        private void grdView_DinhKhoan_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            // Gan tien cho but toan
            ButToanPhieuNhapXuatCCDC butToan = (ButToanPhieuNhapXuatCCDC)(butToanPhieuNhapXuatListBindingSource.Current);
            SetDefaultValueButToan(butToan);
            #region Old
            //decimal soTienConLai = _phieuXuat.GiaTriKho;
            //foreach (ButToanPhieuNhapXuatCCDC buttoanphieu in _phieuXuat.ButToanPhieuNhapXuatList)
            //{
            //    soTienConLai = soTienConLai - buttoanphieu.SoTien;
            //}
            //butToan.SoTien = soTienConLai;
            //butToan.MaDoiTuongCo = _phieuXuat.MaDoiTac;

            ////
            //butToan.DienGiai = this.txtDienGiai.Text;
            #endregion Old
        }

        private void grdView_DinhKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (!CheckValidWhenChangeNgayNX()) return;
                if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa các bút toán định khoản đang chọn trên lưới?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    foreach (int i in grdView_DinhKhoan.GetSelectedRows())
                    {
                        grdView_DinhKhoan.DeleteRow(i);
                    }
                }
            }
            //else if (e.KeyCode == Keys.Tab)
            //{
            //    if (grdView_DinhKhoan.FocusedRowHandle < 0)
            //    {
            //        grdView_DinhKhoan.MoveFirst();
            //    }
            //}
        }

        #region barBt_LapPhieuXuat_ItemClick
        private void barBt_LapPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        #endregion

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            if (_phieuXuat.XacNhan == true)//Kiem Tra Thu Kho Xac Nhan
            {
                MessageBox.Show(this, "Thủ kho đã xác nhận,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CheckValidWhenChangeNgayNX())
            {
                if (tabControl_CCDC.SelectedTabPage.Name == "xtraTabPage1")//CT_PhieuNhap
                {
                    foreach (int i in grdViewCt_PhieuNhap.GetSelectedRows())
                    {
                        CT_PhieuXuatCCDC ct_Phieu = _phieuXuat.CT_PhieuXuatList[i];
                        for (int j = 0; j < grdv_CongCuDungCu.RowCount; j++)
                        {
                            CCDC congCu = grdv_CongCuDungCu.GetRow(j) as CCDC;
                            if (congCu.MaHangHoa == ct_Phieu.MaHangHoa && congCu.MoTaTenCCDC == ct_Phieu.MoTaTenCCDC)
                            {
                                grdv_CongCuDungCu.DeleteRow(j);
                                j--;
                            }
                        }
                        grdViewCt_PhieuNhap.DeleteRow(i);
                    }//
                }
                if (tabControl_CCDC.SelectedTabPage.Name == "xtraTabPage2")//DinhKhoan
                {
                    if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa các bút toán định khoản đang chọn trên lưới?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        foreach (int i in grdView_DinhKhoan.GetSelectedRows())
                        {
                            grdView_DinhKhoan.DeleteRow(i);
                        }
                    }
                }
            }
        }

        private void btnPrint_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //BEGIN
            ReportTemplate _report = ReportTemplate.GetReportTemplate("BienBanGiaoNhanCongCuDungCu");
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

        #region Cac Ham cho RePort
        ///
        public void Spd_BienBanGiaoNhanCongCuDungCu()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapVatTu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_BienBanGiaoNhanCongCuDungCu";
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _phieuXuat.MaPhieuNhapXuat);
                    cm.Parameters.AddWithValue("@MaPhongBan", _phieuXuat.MaPhongBan);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BienBanGiaoNhanCongCuDungCu;1";
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
                    dt.TableName = "spd_ReportHeaderAndFooter;1";
                    dataSet.Tables.Add(dt);
                }

            }//us 
        }

        public void Spd_PhieuXuatVatTu()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuXuatVatTu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    if (_cachIn == 1)
                    {
                        cm.CommandText = "Spd_PhieuXuatVatTu";
                        cm.Parameters.AddWithValue("@MaPhieuXuatVTHH", _phieuXuat.MaPhieuNhapXuat);
                    }
                    else
                    {
                        cm.CommandText = "Spd_PhieuXuatVatTu_InMaCCDCCaBiet";
                        cm.Parameters.AddWithValue("@MaPhieuXuatVTHH", _phieuXuat.MaPhieuNhapXuat);
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_PhieuXuatVatTu;1";
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
                    dt.TableName = "spd_ReportHeaderAndFooter;1";
                    dataSet.Tables.Add(dt);
                }

            }//us 
        }//END Spd_PhieuXuatVatTu

        #endregion//END Cac Ham cho RePort
        private void frmPhieuXuatPhanBoCCDC_Load(object sender, EventArgs e)
        {
            if (_phieuXuat.IsNew == false)
                lookUpEdit_PPNXKho.Enabled = false;

            Utils.GridUtils.ConfigGridView(grdViewCt_PhieuNhap
                     , setSTT: true//
                     , initCopyCell: true//
                     , multiSelectCell: true//
                     , multiSelectRow: false
                     , initNewRowOnTop: false);//
            Utils.GridUtils.ConfigGridView(grdv_CongCuDungCu
            , setSTT: true//
            , initCopyCell: true//
            , multiSelectCell: true//
            , multiSelectRow: false
            , initNewRowOnTop: false);
            Utils.GridUtils.ConfigGridView(grdView_DinhKhoan
             , setSTT: true//
             , initCopyCell: true//
             , multiSelectCell: true//
             , multiSelectRow: false
             , initNewRowOnTop: false);//

            formatGridviewDinhKhoan();
            KhoiTaoThongTinTimKiem();
        }

        private void btnChonPhieuNhapThang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            if (_phieuXuat.MaKho != 0)
            {
                CT_PhieuXuatCCDCList ct_phieuxuatListNew = CT_PhieuXuatCCDCList.NewCT_PhieuXuatList();//--BS

                frmDialogDSPhieuNhapCCDC frm = new frmDialogDSPhieuNhapCCDC(_phieuXuat);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CT_PhieuNhapList dsPhieuNhap = frm.DSChiTietPhieuNhapDaChon;
                    foreach (CT_PhieuNhap ct_PhieuNhap in dsPhieuNhap)
                    {
                        #region Old
                        ////CT_PhieuXuat ctPhieuXuat = new CT_PhieuXuat(ct_PhieuNhap, _phieuXuat.MaKho, _phieuXuat.NgayNX);
                        //CT_PhieuXuat ctPhieuXuat = new CT_PhieuXuat(ct_PhieuNhap, _phieuXuat.NgayNX);
                        //ctPhieuXuat.DienGiai = this.txtDienGiai.Text;
                        //_phieuXuat.CT_PhieuXuatList.Add(ctPhieuXuat);
                        #endregion//Old
                        #region New
                        if (ct_PhieuNhap.SoLuong > ct_PhieuNhap.SoLuongXuat)
                        {
                            CT_PhieuXuatCCDC ct_PhieuXuat = new CT_PhieuXuatCCDC(ct_PhieuNhap, _phieuXuat.NgayNX);
                            bool insert = true;
                            if (grdViewCt_PhieuNhap.RowCount > 0)
                            {
                                for (int i = 0; i < grdViewCt_PhieuNhap.RowCount; i++)
                                {
                                    if (grdViewCt_PhieuNhap.GetRow(i) != null)
                                    {
                                        CT_PhieuXuatCCDC ct_px_gv = (CT_PhieuXuatCCDC)grdViewCt_PhieuNhap.GetRow(i);
                                        if (ct_px_gv.MaHangHoa == ct_PhieuXuat.MaHangHoa
                                            && ct_px_gv.MoTaTenCCDC == ct_PhieuXuat.MoTaTenCCDC
                                            && ct_px_gv.MaPhieuNhap == ct_PhieuXuat.MaPhieuNhap
                                            )
                                        {
                                            insert = false;
                                            break;
                                        }
                                    }
                                }

                            }//grdViewCt_PhieuNhap.RowCount > 0

                            if (insert)
                            {
                                ct_PhieuXuat.DienGiai = this.txtDienGiai.Text;
                                _phieuXuat.CT_PhieuXuatList.Add(ct_PhieuXuat);
                                ct_phieuxuatListNew.Add(ct_PhieuXuat);//--BS
                            }
                        }
                        #endregion//New
                    }
                    //XuLyThem();
                    XuLyTaoCCDCCaBiet(ct_phieuxuatListNew);
                    this.TinhTongTienChoPhieuXuat();
                    tabControl_CCDC.SelectedTabPage = tabControl_CCDC.TabPages[1];
                }
            }
            else
            {
                MessageBox.Show("Cần chọn kho trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void XuLyTaoCCDCCaBiet(CT_PhieuXuatCCDCList list)
        {
            foreach (CT_PhieuXuatCCDC item in list)//(CT_PhieuXuat item in _phieuXuat.CT_PhieuXuatList)
            {
                CCDC ccdc = null;
                ccdc = TaoCCDCCaBiet(item, _phieuXuat.MaPhongBan,0, ccdc);
            }
        }

        private void XuLyThem()
        {
            CCDC ccdc = null;
            int preMaHangHoa = 0;
            Queue<int> maHangHoaQueueDistinct = new Queue<int>();
            Queue<CT_PhieuXuatCCDC> chiTietPhieuXuatSortedQueue = new Queue<CT_PhieuXuatCCDC>();
            foreach (CT_PhieuXuatCCDC item in _phieuXuat.CT_PhieuXuatList)
            {
                if (maHangHoaQueueDistinct.Contains(item.MaHangHoa) == false)
                {
                    maHangHoaQueueDistinct.Enqueue(item.MaHangHoa);
                    foreach (CT_PhieuXuatCCDC x in _phieuXuat.CT_PhieuXuatList)
                    {
                        if (x.MaHangHoa == item.MaHangHoa)
                            chiTietPhieuXuatSortedQueue.Enqueue(x);
                    }
                }
            }

            foreach (CT_PhieuXuatCCDC item in chiTietPhieuXuatSortedQueue)//(CT_PhieuXuat item in _phieuXuat.CT_PhieuXuatList)
            {
                //decimal soLuongTheoMaHangHoa = 0;
                //foreach (CT_PhieuXuat x in _phieuXuat.CT_PhieuXuatList)
                //{
                //    if (x.MaHangHoa == item.MaHangHoa)
                //        soLuongTheoMaHangHoa += x.SoLuong;
                //}
                if (item.MaHangHoa != preMaHangHoa)
                    ccdc = null;

                ccdc = TaoCCDCCaBiet(item, _phieuXuat.MaPhongBan, 0,ccdc);
                preMaHangHoa = item.MaHangHoa;
            }
        }


        private void grdViewCt_PhieuNhap_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //CT_PhieuXuat ct_px = this.cTPhieuXuatListBindingSource.Current as CT_PhieuXuat;
            //if (e.RowHandle >= 0 && ct_px.IsNew != true)
            //{
            //    if (false == Object.ReferenceEquals(e.Column, this.colDienGiai))
            //    {
            //        SendKeys.Send("{ESC}");//khong cho edit
            //    }
            //}
        }

        //private void grdViewCt_PhieuNhap_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        //{
        //BaseEdit edit = (sender as GridView).ActiveEditor;
        //object oldValue = edit.OldEditValue;
        //object newValue = e.Value;

        //}

        //private void lookUpEdit_PPNXKho_Validating(object sender, CancelEventArgs e)
        //{
        //for (int i = 0; i < _phieuXuat.CT_PhieuXuatList.Count; i++)
        //{
        //    CT_PhieuXuatCCDC ct_Phieu = _phieuXuat.CT_PhieuXuatList[i];
        //    for (int j = 0; j < grdv_CongCuDungCu.RowCount; j++)
        //    {
        //        CCDC congCu = grdv_CongCuDungCu.GetRow(j) as CCDC;
        //        if (congCu.MaHangHoa == ct_Phieu.MaHangHoa)
        //        {

        //            grdv_CongCuDungCu.DeleteRow(j);
        //            j--;
        //        }

        //    }

        //    grdViewCt_PhieuNhap.DeleteRow(i);
        //}
        //}

        private void grdv_CongCuDungCu_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (object.ReferenceEquals(e.Column, this.colPhanTramPBLanDau))//A
                {
                    //MessageBox.Show("Test");
                    decimal nguyenGia = (decimal)grdv_CongCuDungCu.GetRowCellValue(e.RowHandle, this.colNguyenGia);
                    decimal phanTram = (decimal)e.Value;
                    decimal soTienPhanBo = TinhSoTienPhanBo(phanTram, nguyenGia);
                    if (soTienPhanBo > nguyenGia)
                    {
                        soTienPhanBo = nguyenGia;
                    }
                    //khi so tien phan bo duoc gan vao luoi
                    //phan tram phan bo se duoc tinh toan lai o //B
                    grdv_CongCuDungCu.SetRowCellValue(e.RowHandle, this.colChiPhiPBLanDau, soTienPhanBo);
                }
                else if (object.ReferenceEquals(e.Column, this.colChiPhiPBLanDau))//B
                {
                    decimal nguyenGia = (decimal)grdv_CongCuDungCu.GetRowCellValue(e.RowHandle, this.colNguyenGia);
                    decimal soTienPhanBo = (decimal)e.Value;
                    decimal phanTramMoi = TinhPhanTram(nguyenGia, soTienPhanBo);
                    decimal phanTramCu = (decimal)grdv_CongCuDungCu.GetRowCellValue(e.RowHandle, this.colPhanTramPBLanDau);
                    if (phanTramMoi != phanTramCu)//tranh vong lap vo tan
                    {
                        grdv_CongCuDungCu.SetRowCellValue(e.RowHandle, colPhanTramPBLanDau, phanTramMoi);
                    }
                }
                else if (object.ReferenceEquals(e.Column, this.gridColumn10))//col HasManage
                {
                    _CheckAllCCDCQuanLy = false;
                    CheckValidWhenChangeNgayNX();
                }
            }
        }
        private decimal TinhSoTienPhanBo(decimal phanTram, decimal nguyenGia)
        {
            decimal returnValue = Math.Round(phanTram * nguyenGia / 100);
            return returnValue;
        }
        private decimal TinhPhanTram(decimal nguyenGia, decimal soTienPhanBo)
        {
            decimal returnValue = Math.Round(soTienPhanBo / (nguyenGia / 100), 2);
            return returnValue;
        }

        private void frmPhieuXuatPhanBoCCDC_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_phieuXuat != null && (_phieuXuat.IsDirty || _phieuXuat.IsNew))
            {
                DialogResult result = MessageBox.Show("Bạn có muốn lưu trước khi thoát?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {
                    if (this.Save() == false)
                        e.Cancel = true;
                }
                else if (DialogResult.No == result)
                {
                }
                else if (DialogResult.Cancel == result)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnXoaPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //B
            PhieuNhapXuatCCDC pnx = _phieuXuat;
            if (pnx != null)
            {
                if (_coTKBiKhoa || CheckCoTaiKhoanBiKhoaTrongButToan())
                {
                    MessageBox.Show("Tài khoản đã bị khóa, k thể lưu", "Thông Báo");
                    return;
                }

                if (!CheckValidWhenChangeNgayNX()) return;

                if (pnx.XacNhan == true)//Kiem Tra Thu Kho Xac Nhan
                {
                    MessageBox.Show(this, "Thủ kho đã xác nhận,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //
                if (PhieuNhapXuatCCDC.KiemTraPhieuNhapDaXuatThang(pnx.MaPhieuNhapXuat))//Kiem Tra Phieu Nhap Thang da Xuat
                {
                    MessageBox.Show("Phiếu Nhập đã Xuất!\n Vui lòng xóa Phiếu Xuất trước khi xóa Phiếu Nhập!");
                    return;
                }
                //Delete Phieu
                if (MessageBox.Show(this, "Bạn muốn xóa Phiếu này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        PhieuNhapXuatCCDC.DeletePhieuNhapXuat(_phieuXuat);
                        MessageBox.Show(this, "Xóa Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnThemMoi.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "Cập Nhật Thất Bại!\n"+ ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }//End Delete Phieu
            }
            //E
        }

        private void grdView_DinhKhoan_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (grdView_DinhKhoan.FocusedColumn.Name == "col_btn")
            {
                if (((ButToanPhieuNhapXuatCCDC)butToanPhieuNhapXuatListBindingSource.Current) != null)
                {
                    //Xu ly Tai day
                    ((ButToanPhieuNhapXuatCCDC)butToanPhieuNhapXuatListBindingSource.Current).BeginEdit();
                    ButToanPhieuNhapXuatCCDC bt = (ButToanPhieuNhapXuatCCDC)butToanPhieuNhapXuatListBindingSource.Current;
                    ChungTu_ChiPhiSanXuatList cpList = ((ButToanPhieuNhapXuatCCDC)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList;
                    cpList.BeginEdit();
                    frmChiPhiSanXuatChuongTrinh_New f = new frmChiPhiSanXuatChuongTrinh_New(cpList, bt.SoTien, _phieuXuat.NgayNX, bt.DienGiai, bt.MaButToan);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        if (f.IsSave == true)
                        {
                            ((ButToanPhieuNhapXuatCCDC)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList = f._ChungTu_ChiPhiSXList;
                            ((ButToanPhieuNhapXuatCCDC)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList.ApplyEdit();
                        }
                        else
                        {
                            cpList.CancelEdit();
                        }
                    }
                    //
                }
            }
        }

        private void grdv_CongCuDungCu_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (grdv_CongCuDungCu.FocusedColumn.Name == "grdCol_ChiTiet")
            {
                if (((CCDC)congCuDungCuListBindingSource.Current) != null)
                {
                    //Xu ly Tai day
                    //((CongCuDungCu)congCuDungCuListBindingSource.Current).BeginEdit();
                    CCDC cc = (CCDC)congCuDungCuListBindingSource.Current;
                    frmChiTietCCDCList frm = new frmChiTietCCDCList(cc);
                    frm.ShowDialog();
                    //
                }
            }
        }

        private void dateEdit_NgayLap_Leave(object sender, EventArgs e)
        {
            if (dateEdit_NgayLap.OldEditValue != dateEdit_NgayLap.EditValue)
            {
                if (!CheckValidWhenChangeNgayNX())
                {
                    _phieuXuat.NgayNX = _ngayLapCu;
                    dateEdit_NgayLap.EditValue = _ngayLapCu as object;
                }
                else
                {
                    foreach (CCDC cc in _phieuXuat.CongCuDungCuList)
                    {
                        cc.NgayNhan = (DateTime)dateEdit_NgayLap.EditValue;
                    }
                }
            }
        }

        private void calcEdit_phantramphanbo_Leave(object sender, EventArgs e)
        {
            //if (calcEdit_phantramphanbo.OldEditValue != calcEdit_phantramphanbo.EditValue)
            //{
            //    decimal _phanTram = 0;

            //    if (calcEdit_phantramphanbo.EditValue != null)
            //    {
            //        _phanTram = Convert.ToDecimal(calcEdit_phantramphanbo.EditValue.ToString());// Convert.ToDecimal("50,6"); //
            //    }
            //    for (int i = 0; i < grdv_CongCuDungCu.RowCount; i++)
            //    {
            //        grdv_CongCuDungCu.SetRowCellValue(i, "PhanTramPBLanDau", _phanTram);
            //    }
            //    grdv_CongCuDungCu.RefreshData();
            //}
        }

        private void barBtnItemInNXT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _cachIn = 1;
            ReportTemplate _report;
            //_report = ReportTemplate.GetReportTemplate("PhieuXuatVatTu_XuatThang");
            _report = ReportTemplate.GetReportTemplate("PheuXuatVatTu");
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
            //END
        }

        private void barBtnItemInCCDCQuanLy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //BEGIN
            ReportTemplate _report = ReportTemplate.GetReportTemplate("BienBanGiaoNhanCongCuDungCu");
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
            //END
        }

        private void textEditThoiGianSuDung_Leave(object sender, EventArgs e)
        {
            //if (textEditThoiGianSuDung.OldEditValue != textEditThoiGianSuDung.EditValue)
            //{
            //    int thoigianSD = 0;

            //    if (textEditThoiGianSuDung.EditValue != null)
            //    {
            //        thoigianSD = Convert.ToInt32(textEditThoiGianSuDung.EditValue.ToString());
            //    }
            //    for (int i = 0; i < grdv_CongCuDungCu.RowCount; i++)
            //    {
            //        grdv_CongCuDungCu.SetRowCellValue(i, "ThoiGianSuDung", thoigianSD);
            //    }
            //    grdv_CongCuDungCu.RefreshData();
            //}
        }

        private void CCDCQuanLy_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_CheckAllCCDCQuanLy)
            {
                foreach (CCDC cc in _phieuXuat.CongCuDungCuList)
                {
                    cc.HasManage = CCDCQuanLy_checkBox.Checked;
                }
                grdv_CongCuDungCu.RefreshData();
            }
            else _CheckAllCCDCQuanLy = true;
        }

        private void btnMauXuatThangMau2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _cachIn = 2;// In Mau NXT Mã CCDC Ca Biet
            ReportTemplate _report;
            _report = ReportTemplate.GetReportTemplate("PhieuXuatVatTu_XuatThang");
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
            //END
        }

        private void lookUpEdit_NhanVien_Leave(object sender, EventArgs e)
        {
            _edtiBophan = false;
            if (lookUpEdit_NhanVien.EditValue != lookUpEdit_NhanVien.OldEditValue)
            {
                if (lookUpEdit_NhanVien.EditValue != null)
                {
                    long manvOut;
                    if (long.TryParse(lookUpEdit_NhanVien.EditValue.ToString(), out manvOut))
                    {
                        ThongTinNhanVienTongHop nv = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(manvOut);
                        _phieuXuat.MaPhongBan = nv.MaBoPhan;
                    }
                }
            }
            _edtiBophan = true;
        }
        public void LoadLinkLabel(int MaPhieuLink)
        {
            DataTable dt = PhieuNhapXuatList.GetPhieuXuatByPhieuNhap(MaPhieuLink, 2);
            int i = 0;
            //int _loca = 30;
            linkLabel1.Visible = false;
            linkLabel2.Visible = false;
            linkLabel3.Visible = false;
            linkLabel4.Visible = false;
            linkLabel5.Visible = false;
            linkLabel6.Visible = false;
            linkLabel7.Visible = false;
            linkLabel8.Visible = false;
            linkLabel9.Visible = false;
            for (int j = 1; j <= dt.Rows.Count; j++)
            {
                if (j == 1)
                    linkLabel1.Visible = true;
                else if (j == 2)
                    linkLabel2.Visible = true;
                else if (j == 3)
                    linkLabel3.Visible = true;
                else if (j == 4)
                    linkLabel4.Visible = true;
                else if (j == 5)
                    linkLabel5.Visible = true;
                else if (j == 6)
                    linkLabel6.Visible = true;
                else if (j == 7)
                    linkLabel7.Visible = true;
                else if (j == 8)
                    linkLabel8.Visible = true;
                else if (j == 9)
                    linkLabel9.Visible = true;
            }

            foreach (DataRow dr in dt.Rows)
            {
                int index = i + 1;
                if (index == 1)
                {
                    linkLabel1.Text = dr["SoPhieuNhap"].ToString();
                    linkLabel1.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["mapn"].ToString();
                    linkLabel1.Links.Add(link);
                }
                else if (index == 2)
                {
                    linkLabel2.Text = dr["SoPhieuNhap"].ToString();
                    linkLabel2.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["mapn"].ToString();
                    linkLabel2.Links.Add(link);
                }
                else if (index == 3)
                {
                    linkLabel3.Text = dr["SoPhieuNhap"].ToString();
                    linkLabel3.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["mapn"].ToString();
                    linkLabel3.Links.Add(link);
                }
                else if (index == 4)
                {
                    linkLabel4.Text = dr["SoPhieuNhap"].ToString();
                    linkLabel4.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["mapn"].ToString();
                    linkLabel4.Links.Add(link);
                }
                else if (index == 5)
                {
                    linkLabel5.Text = dr["SoPhieuNhap"].ToString();
                    linkLabel5.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["mapn"].ToString();
                    linkLabel5.Links.Add(link);
                }
                else if (index == 6)
                {
                    linkLabel6.Text = dr["SoPhieuNhap"].ToString();
                    linkLabel6.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["mapn"].ToString();
                    linkLabel6.Links.Add(link);
                }
                else if (index == 7)
                {
                    linkLabel7.Text = dr["SoPhieuNhap"].ToString();
                    linkLabel7.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["mapn"].ToString();
                    linkLabel7.Links.Add(link);
                }
                else if (index == 8)
                {
                    linkLabel8.Text = dr["SoPhieuNhap"].ToString();
                    linkLabel8.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["mapn"].ToString();
                    linkLabel8.Links.Add(link);
                }
                else if (index == 9)
                {
                    linkLabel9.Text = dr["SoPhieuNhap"].ToString();
                    linkLabel9.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["mapn"].ToString();
                    linkLabel9.Links.Add(link);
                }
                i++;
            }
        }

        private void txtSoPhieu_EditValueChanged(object sender, EventArgs e)
        {
            int MaPhieu = PhieuNhapXuatList.GetMaPhieuBySoPhieu(txtSoPhieu.EditValue.ToString());
            LoadLinkLabel(MaPhieu);
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            frmPhieuNhapCongCuDungCu_Update a = new frmPhieuNhapCongCuDungCu_Update(_pnx);
            a.ShowDialog();
            txtSoPhieu_EditValueChanged(sender, e);
        }

        private void tabControl_CCDC_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tabControl_CCDC.SelectedTabPage.Name == "xtraTabPage2")
            {
                AllowDelete();

                if (this.isThayDoiSoLieu == true || this._phieuXuat.ButToanPhieuNhapXuatList.Count == 0)
                {
                    //if (this._phieuXuatVTHH.ButToanPhieuNhapXuatList.Count == 0)
                    //{
                    ButToanPhieuNhapXuatCCDC bt = ButToanPhieuNhapXuatCCDC.NewButToanPhieuNhapXuat();
                    int tkNo = HeThongTaiKhoan1.LayMaTaiKhoan("2421");
                    int tkCo = HeThongTaiKhoan1.LayMaTaiKhoan("1531");//sửa lại theo yêu cầu chị Trang từ ngày 01/07/2019
                    bt.NoTaiKhoan = tkNo;
                    bt.CoTaiKhoan = tkCo;
                    bt.SoTien = this._phieuXuat.GiaTriKho;
                    bt.DienGiai = txtDienGiai.Text;
                    this._phieuXuat.ButToanPhieuNhapXuatList.Add(bt);
                    //butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;
                    //}
                    this.isThayDoiSoLieu = false;
                }
            }
            else if (PhieuNhapXuat.KiemTraPhieuXuatTuDSPhieuDeNghiLinh(_phieuXuat.MaPhieuNhapXuat))
            {
                NotAllowDelete();
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (checkEdit_Ngay.Checked == true)
            {
                _phieuNhapXuatList = PhieuNhapXuatCCDCList.GetPhieuNhapXuatList(Convert.ToInt32(gridLookUpEdit_KhoNhan_TimKiem.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien_TimKiem.EditValue), Convert.ToInt32(lookUpEdit_PhongBan_TimKiem.EditValue), Convert.ToByte(lookUpEdit_PPNXKho_TimKiem.EditValue), (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, false, 3, UserId);
            }
            else
            {
                _phieuNhapXuatList = PhieuNhapXuatCCDCList.GetPhieuNhapXuatList(Convert.ToInt32(gridLookUpEdit_KhoNhan_TimKiem.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien_TimKiem.EditValue), Convert.ToInt32(lookUpEdit_PhongBan_TimKiem.EditValue), Convert.ToByte(lookUpEdit_PPNXKho_TimKiem.EditValue), false, 3, UserId);
            }
            phieuNhapXuatListBindingSource.DataSource = _phieuNhapXuatList;
            if (_phieuNhapXuatList.Count == 0)//M
                MessageBox.Show("Danh Sách Phiếu rỗng!");
        }

        private void grdv_DanhSachPhieuNhapXuat_DoubleClick(object sender, EventArgs e)
        {
            PhieuNhapXuatCCDC phieuNhapXuat = grdv_DanhSachPhieuNhapXuat.GetFocusedRow() as PhieuNhapXuatCCDC;
            LoadInfoByMaPhieuNhapXuat(phieuNhapXuat.MaPhieuNhapXuat);
        }

        private void btn_ExportExcelDS_Click(object sender, EventArgs e)
        {
            GridUtil.ExportToExcel(gridView: this.grdv_DanhSachPhieuNhapXuat, showOpenFilePrompt: true);
        }

        private void btn_ExportChiTietPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridUtil.ExportToExcel(gridView: this.grdViewCt_PhieuNhap, showOpenFilePrompt: true);
        }

        private void btn_ExportDSCCDC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridUtil.ExportToExcel(gridView: this.grdv_CongCuDungCu, showOpenFilePrompt: true);
        }

    }
}