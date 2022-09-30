using System;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using ERP_Library;
using System.Data.SqlClient;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using System.Data.OleDb;
using PSC_ERP_Common;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using System.Collections.Generic;
using ERP_Library.Security;

//22_09_2014
namespace PSC_ERP
{
    public partial class frmPhieuNhapVatTuHangHoa_New : XtraForm
    {
        #region Properties

        PhieuNhapXuat _phieuNhapXuat = PhieuNhapXuat.NewPhieuNhapXuat();
        HoaDonList _hoaDonList = HoaDonList.NewHoaDonList();
        DoiTuongAllList _doiTuongAllList = DoiTuongAllList.NewDoiTuongAllList();
        TieuMucNganSachList _tieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();
        //DoiTacList _DoiTacList;
        KhoBQ_VTList _khoBQ_VTList = KhoBQ_VTList.NewKhoBQ_VTList();
        //BoPhanList _boPhanList = BoPhanList.NewBoPhanList();
        ChungTu_HoaDonList _chungTu_HoaDonList = ChungTu_HoaDonList.NewChungTu_HoaDonList();
        //ADD 10/03/2021
        List<tblnsBoPhan> _boPhanList = null;
        IQueryable<tblDoiTac> _doiTacList = null;
        int _maCongTy = CurrentUser.Info.MaCongTy;
        //Add to 11012013
        DateTime _ngayLapCu;
        int _maKhoCu;
        //End Add to 11012013
        //Bien cho REPORT
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet;

        #region BS KhoaSoTK
        private bool _isCellValuechangeBT = true;
        private bool _coTKBiKhoa = false;
        #endregion//BS KhoaSoTK
        bool _edtiBophan = true;

        private BindingSource LoaiThueSuatListBindingSource = new BindingSource();

        private bool isThayDoiSoLieu = false;

        string _FileNameImport = "";
        DataSet _dataSet = new DataSet();
        private DataTable tblHangHoa;
        HangHoaBQ_VTList _hangHoaListFul;

        #endregion//Properties

        public frmPhieuNhapVatTuHangHoa_New()
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu();
            Event();
        }

        #region frmPhieuNhapVatTuHangHoa(PhieuNhapXuat phieuNhapXuat)
        public frmPhieuNhapVatTuHangHoa_New(PhieuNhapXuat phieuNhapXuat)
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu(phieuNhapXuat);
            Event();
        }
        #endregion

        #region frmPhieuNhapVatTuHangHoa(PhieuNhapXuat phieuNhapXuat)

        public frmPhieuNhapVatTuHangHoa_New(long maChungTu)
        {
            InitializeComponent();
            PhieuNhapXuat phieuNhapXuat = PhieuNhapXuat.GetPhieuNhapXuat(maChungTu);
            KhoiTao();
            KhoiTaoPhieu(phieuNhapXuat);
            Event();
        }
        #endregion

        private void Event()
        {
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            linkLabel4.LinkClicked += linkLabel4_LinkClicked;
            linkLabel5.LinkClicked += linkLabel5_LinkClicked;
            linkLabel6.LinkClicked += linkLabel6_LinkClicked;
            linkLabel7.LinkClicked += linkLabel7_LinkClicked;
            linkLabel8.LinkClicked += linkLabel8_LinkClicked;
            linkLabel9.LinkClicked += linkLabel9_LinkClicked;
        }

        #region Function

        private void DesignGrid_grdViewCt_PhieuNhap()
        {//grdViewCt_PhieuNhap
            grdCT_PhieuNhap.DataSource = cTPhieuNhapListBindingSource;
            HamDungChung.InitGridViewDev(grdViewCt_PhieuNhap, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(grdViewCt_PhieuNhap, new string[] { "MaDonViTinh", "MoTaTenCCDC", "SoLuong", "DonGiaGoc", "ThanhTienGoc", "TyLeCK", "TienChietKhau", "ChiPhiMuaHang", "ThueSuatVAT", "TienThue", "ThanhTien", "DienGiai"/*, "MaBoPhan"*/ },
                                new string[] { "ĐVT", "Quy cách", "Số lượng", "Đơn giá", "Thành tiền", "Tỷ lệ CK(%)", "Tiền chiết khấu", "Chi phí mua hàng", "% thuế VAT", "Tiền thuế VAT", "Tổng tiền", "Ghi chú"/*, "Mã Bộ Phận" */},
                                             new int[] { 80, 90, 90, 100, 110, 90, 100, 100, 90, 100, 100, 150/*, 100 */});


            HamDungChung.AlignHeaderColumnGridViewDev(grdViewCt_PhieuNhap, new string[] { "MaDonViTinh", "MoTaTenCCDC", "SoLuong", "DonGiaGoc", "ThanhTienGoc", "TyLeCK", "TienChietKhau", "ChiPhiMuaHang", "ThueSuatVAT", "TienThue", "ThanhTien", "DienGiai"/*, "MaBoPhan"*/ }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdViewCt_PhieuNhap, new string[] { "SoLuong", "DonGiaGoc", "ThanhTienGoc", "TyLeCK", "TienChietKhau", "ChiPhiMuaHang", "TienThue", "ThanhTien" }, "#,###.##");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdViewCt_PhieuNhap, new string[] { "SoLuong", "DonGiaGoc", "ThanhTienGoc", "TyLeCK", "TienChietKhau", "ChiPhiMuaHang", "TienThue", "ThanhTien" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(grdViewCt_PhieuNhap, NewItemRowPosition.Bottom);

            Utils.GridUtils.SetSTTForGridView(grdViewCt_PhieuNhap, 50);//M
            //Hang Hoa
            //RepositoryItemGridLookUpEdit HangHoa_GrdLU = new RepositoryItemGridLookUpEdit();
            //HangHoa_GrdLU.ExportMode = ExportMode.DisplayText;
            //HamDungChung.InitRepositoryItemGridLookUpDev2(HangHoa_GrdLU, hangHoaBQVTListBindingSource, "TenHangHoa", "MaHangHoa", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(HangHoa_GrdLU, new string[] { "MaQuanLy", "TenHangHoa" }, new string[] { "Mã HH", "Tên HH" }, new int[] { 100, 200 }, false);
            //HamDungChung.RegisterControlFieldGridViewDev(grdViewCt_PhieuNhap, "MaHangHoa", HangHoa_GrdLU);

            //Hang Hoa mã           
            GridColumn columnMaHangHoa = new GridColumn();
            columnMaHangHoa.Caption = "Mã VTHH";
            columnMaHangHoa.FieldName = "MaHangHoa";
            columnMaHangHoa.Width = 80;
            columnMaHangHoa.OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuNhap.Columns.Add(columnMaHangHoa);
            RepositoryItemGridLookUpEdit HangHoa_GrdLU_Ma = new RepositoryItemGridLookUpEdit();
            HangHoa_GrdLU_Ma.ExportMode = ExportMode.DisplayText;
            HamDungChung.InitRepositoryItemGridLookUpDev2(HangHoa_GrdLU_Ma, hangHoaBQVTListBindingSource, "MaQuanLy", "MaHangHoa", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(HangHoa_GrdLU_Ma, new string[] { "MaQuanLy", "TenHangHoa" }, new string[] { "Mã HH", "Tên HH" }, new int[] { 100, 200 }, false);
            columnMaHangHoa.ColumnEdit = HangHoa_GrdLU_Ma;
            //Hang Hoa tên
            GridColumn columnTenHangHoa = new GridColumn();
            columnTenHangHoa.Caption = "Tên VTHH";
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

            //DonViTinh
            RepositoryItemGridLookUpEdit DVT_GrdLU = new RepositoryItemGridLookUpEdit();
            DVT_GrdLU.ExportMode = ExportMode.DisplayText;
            HamDungChung.InitRepositoryItemGridLookUpDev2(DVT_GrdLU, donViTinhListBindingSource, "MaQuanLy", "MaDonViTinh", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DVT_GrdLU, new string[] { "MaQuanLy", "TenDonViTinh" }, new string[] { "Mã ĐVT", "Tên ĐVT" }, new int[] { 100, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(grdViewCt_PhieuNhap, "MaDonViTinh", DVT_GrdLU);
            //
            //LoaiThueSuatVAT
            RepositoryItemGridLookUpEdit LoaiThueSuatVAT_grdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(LoaiThueSuatVAT_grdLU, LoaiThueSuatListBindingSource, "MoTa", "ThueSuat", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiThueSuatVAT_grdLU, new string[] { "MoTa" }, new string[] { "Thuế suất" }, new int[] { 90 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(grdViewCt_PhieuNhap, "ThueSuatVAT", LoaiThueSuatVAT_grdLU);

            //BoPhan
            RepositoryItemGridLookUpEdit BoPhan_GrdLU = new RepositoryItemGridLookUpEdit();
            BoPhan_GrdLU.ExportMode = ExportMode.DisplayText;
            HamDungChung.InitRepositoryItemGridLookUpDev2(BoPhan_GrdLU, boPhanListBindingSource, "TenBoPhan", "MaBoPhan", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(BoPhan_GrdLU, new string[] { "MaBoPhanQL", "TenBoPhan" }, new string[] { "Mã QL", "Tên Bộ Phận" }, new int[] { 100, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(grdViewCt_PhieuNhap, "MaBoPhan", BoPhan_GrdLU);

            #region Dinh Dang Danh So
            //Dinh Dang Danh So
            //"DonGia", "ThanhTien", "ChiPhiMuaHang"
            RepositoryItemCalcEdit repositoryItemCalcEditDonGia = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            repositoryItemCalcEditDonGia.AutoHeight = false;
            repositoryItemCalcEditDonGia.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditDonGia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repositoryItemCalcEditDonGia.Name = "repositoryItemCalcEditSoTien";
            grdViewCt_PhieuNhap.Columns["DonGiaGoc"].ColumnEdit = repositoryItemCalcEditDonGia;
            //ThanhTien
            RepositoryItemCalcEdit repositoryItemCalcEditThanhTien = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            repositoryItemCalcEditThanhTien.AutoHeight = false;
            repositoryItemCalcEditThanhTien.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditThanhTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repositoryItemCalcEditThanhTien.Name = "repositoryItemCalcEditSoTien";
            grdViewCt_PhieuNhap.Columns["ThanhTienGoc"].ColumnEdit = repositoryItemCalcEditThanhTien;
            //ChiPhiMuaHang
            RepositoryItemCalcEdit repositoryItemCalcEditChiPhiMuaHang = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            repositoryItemCalcEditChiPhiMuaHang.AutoHeight = false;
            repositoryItemCalcEditChiPhiMuaHang.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditChiPhiMuaHang.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repositoryItemCalcEditChiPhiMuaHang.Name = "repositoryItemCalcEditSoTien";
            grdViewCt_PhieuNhap.Columns["ChiPhiMuaHang"].ColumnEdit = repositoryItemCalcEditChiPhiMuaHang;
            #endregion Dinh Dang Danh So
            //
            this.grdViewCt_PhieuNhap.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdViewCt_PhieuNhap_CellValueChanged);
            this.grdViewCt_PhieuNhap.KeyDown += new KeyEventHandler(this.grdViewCt_PhieuNhap_KeyDown);
            this.grdViewCt_PhieuNhap.InitNewRow += new InitNewRowEventHandler(this.grdViewCt_PhieuNhap_InitNewRow);

            this.grdCT_PhieuNhap.ContextMenuStrip = this.contextMenuStrip_HangHoa;

            columnMaHangHoa.VisibleIndex = 0;
            columnTenHangHoa.VisibleIndex = 1;
            grdViewCt_PhieuNhap.Columns["MaDonViTinh"].VisibleIndex = 2;
            grdViewCt_PhieuNhap.Columns["MoTaTenCCDC"].VisibleIndex = 3;
            grdViewCt_PhieuNhap.Columns["SoLuong"].VisibleIndex = 4;
            grdViewCt_PhieuNhap.Columns["DonGiaGoc"].VisibleIndex = 5;
            grdViewCt_PhieuNhap.Columns["ThanhTienGoc"].VisibleIndex = 6;
            grdViewCt_PhieuNhap.Columns["TyLeCK"].VisibleIndex = 7;
            grdViewCt_PhieuNhap.Columns["TienChietKhau"].VisibleIndex = 8;
            grdViewCt_PhieuNhap.Columns["ChiPhiMuaHang"].VisibleIndex = 9;
            grdViewCt_PhieuNhap.Columns["ThueSuatVAT"].VisibleIndex = 10;
            grdViewCt_PhieuNhap.Columns["TienThue"].VisibleIndex = 11;
            grdViewCt_PhieuNhap.Columns["ThanhTien"].VisibleIndex = 12;
            //grdViewCt_PhieuNhap.Columns["ThoiLuong"].VisibleIndex = 13;
            grdViewCt_PhieuNhap.Columns["DienGiai"].VisibleIndex = 14;
            //grdViewCt_PhieuNhap.Columns["MaBoPhan"].VisibleIndex = 15;
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

        #region KhoiTaoPhieu()
        private void KhoiTaoPhieu()
        {
            _phieuNhapXuat = PhieuNhapXuat.NewPhieuNhapXuat();
            _phieuNhapXuat.Loai = 2;
            cTPhieuNhapListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuNhapList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;
            // hoaDon_NhapXuatbindingSource.DataSource = _phieuNhapXuat.HoaDon_NhapXuatList;

            _phieuNhapXuat.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;
            _phieuNhapXuat.LaNhap = true;
            _phieuNhapXuat.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuNhapXuat.Loai, _phieuNhapXuat.LaNhap, _phieuNhapXuat.NgayNX);
            if (_khoBQ_VTList.Count != 0)
                _phieuNhapXuat.MaKho = _khoBQ_VTList[0].MaKho;
            if (_boPhanList.Count != 0)
                _phieuNhapXuat.MaPhongBan = _boPhanList[0].MaBoPhan;
            //
            CheckPhieuNhap();
            btnImportCT.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }
        #endregion

        #region KhoiTaoPhieu(PhieuNhapXuat phieuNhapXuat)
        private void KhoiTaoPhieu(PhieuNhapXuat phieuNhapXuat)
        {
            _phieuNhapXuat = phieuNhapXuat;
            cTPhieuNhapListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuNhapList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;
            // hoaDon_NhapXuatbindingSource.DataSource = _phieuNhapXuat.HoaDon_NhapXuatList;

            _phieuNhapXuat.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;
            _phieuNhapXuat.LaNhap = true;
            //Add to 11012013
            _ngayLapCu = _phieuNhapXuat.NgayNX;
            _maKhoCu = _phieuNhapXuat.MaKho;
            _coTKBiKhoa = CheckCoTaiKhoanBiKhoaTrongButToan();
            //End Add to 11012013
            int flag = 0;

            foreach (ButToanPhieuNhapXuat _butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                #region Modify TKThue
                if (IsTaiKhoanThueKhauTru(_butToan.NoTaiKhoan))
                {
                    foreach (ChungTu_HoaDon ct_hd in _butToan.ChungTu_HoaDonList)
                        _chungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));
                    flag = 1;
                }
                #endregion Modify TKThue

                #region Old TKThue
                //HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                //if (taiKhoan.SoHieuTK.StartsWith("3113"))
                //{
                //    foreach (ChungTu_HoaDon ct_hd in _butToan.ChungTu_HoaDonList)
                //        _chungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));
                //    flag = 1;
                //} 
                #endregion Old TKThue
            }
            if (flag == 0)
            {
                foreach (HoaDon_NhapXuat hoaDon_NhapXuat in _phieuNhapXuat.HoaDon_NhapXuatList)
                {
                    ChungTu_HoaDonList ct_hd = ChungTu_HoaDonList.GetChungTu_HoaDonByMaHoaDonList(hoaDon_NhapXuat.MaHoaDon);
                    if (ct_hd.Count == 0)
                    {
                        HoaDon hoaDon = HoaDon.GetHoaDon(hoaDon_NhapXuat.MaHoaDon);
                        _chungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(hoaDon));
                    }
                }
            }

            btnImportCT.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        #endregion

        #region KhoiTao()
        private void LoadBoPhanList()
        {
            #region old
            //_boPhanList = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
            //BoPhan bpEmpt = BoPhan.NewBoPhan("<<Tất cả>>");
            //_boPhanList.Insert(0, bpEmpt);
            #endregion old
            // 10/03/2021 Load danh sách bộ phận theo Mã công ty
            _boPhanList = BoPhan_Factory.New().GetBoPhanbyMaCongTy(_maCongTy).ToList();
            tblnsBoPhan boPhan_chonTatCa = new tblnsBoPhan() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" };
            _boPhanList.Insert(0, boPhan_chonTatCa);

            boPhanListBindingSource.DataSource = _boPhanList;
        }

        private void KhoiTao()
        {
            cTPhieuNhapListBindingSource.DataSource = typeof(CT_PhieuNhapList);

            //PhieuNhapXuatList_bindingSource.DataSource = PhieuNhapXuatList.GetPhieuNhapXuatList();
            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaVatTuHangHoaList();
            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            //heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            //heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetTaiKhoanConListByCongTy();
            heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetTaiKhoanConListByCongTy();
            //doiTacListBindingSource1.DataSource = DoiTacList.GetDoiTacListByTen(0);
            doiTacListBindingSource1.DataSource = DoiTac_Factory.New().GetAll();

            //doiTuongAllListBindingSource.DataSource = DoiTuongAllList.GetDoiTuongAllList();            
            //_boPhanList = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
            //boPhanListBindingSource.DataSource = _boPhanList;
            LoadBoPhanList();
            //LoadDataForthongTinNhanVienTongHopListBindingSource(0);
            _khoBQ_VTList = KhoBQ_VTList.GetKhoVatTuList();
            khoBQVTListBindingSource.DataSource = _khoBQ_VTList;
            //10/03/2021
            //_DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            //DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Không Chọn");
            //_DoiTacList.Insert(0, _DoiTac);
            _doiTacList = DoiTac_Factory.New().GetAll();
            doiTacListBindingSource.DataSource = _doiTacList;
            doiTacNoListBindingSource.DataSource = _doiTacList;
            //lookUpEdit_DoiTac.Properties.View.Columns["gridColumn4"].FieldName = 

            _tieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList();
            TieuMucNganSach _tieuMucNganSach = TieuMucNganSach.NewTieuMucNganSach("Không Chọn", "Không Chọn");
            _tieuMucNganSachList.Insert(0, _tieuMucNganSach);
            tieuMucNganSachListBindingSource.DataSource = _tieuMucNganSachList;
            Init_lookUpEdit_PhongBan();

            //Loai Thue VAT
            LoaiThueSuatListBindingSource.DataSource = LoaiThueSuatVAT.CreateListLoaiThueSuatVAT();

            DesignGrid_grdViewCt_PhieuNhap();
        }
        #endregion

        private bool KiemTraChiTiet()
        {
            foreach (CT_PhieuNhap ct_phieuNhap in _phieuNhapXuat.CT_PhieuNhapList)
            {
                if (ct_phieuNhap.MaHangHoa == 0)
                {
                    MessageBox.Show(this, "Vui lòng nhập Tên Vật tư - Hàng hóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (ct_phieuNhap.SoLuong == 0)
                {
                    MessageBox.Show(this, "Vui lòng nhập vào số lượng chi tiết!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private bool KiemTraDuLieu()
        {
            bool kq = false;
            if (_phieuNhapXuat.MaDoiTac == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn đối tác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEdit_DoiTac.Focus();
            }
            else if (_phieuNhapXuat.MaPhongBan == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn phòng ban", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEdit_PhongBan.Focus();
            }
            //else if (_phieuNhapXuat.MaNguoiNhapXuat == 0)
            //{
            //    MessageBox.Show(this, "Vui lòng chọn nhân viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    lookUpEdit_NhanVien.Focus();
            //}
            else if (_phieuNhapXuat.MaKho == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn kho nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEdit_KhoNhan.Focus();
            }
            else if (_phieuNhapXuat.CT_PhieuNhapList.Count == 0)
                MessageBox.Show(this, "Vui lòng nhập chi tiết phiếu nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (KiemTraChiTiet() == false)
                return false;
            //MessageBox.Show(this, "Vui lòng nhập số lượng chi tiết phiếu nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (KiemTraButToanHoaDon() == false)
            {
                kq = false;
            }
            else kq = true;
            return kq;
        }

        private bool KiemTraButToanHoaDon()
        {
            foreach (ButToanPhieuNhapXuat butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                if (butToan.NoTaiKhoan == 0 || butToan.NoTaiKhoan == null || butToan.CoTaiKhoan == 0 || butToan.CoTaiKhoan == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin Nợ Có của Định Khoản", "Yêu Cầu");
                    return false;
                }
                if (butToan.SoTien == 0)
                {
                    MessageBox.Show("Vui lòng nhập Số tiền của Định Khoản", "Yêu Cầu");
                    return false;
                }
                HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(butToan.NoTaiKhoan);
                HeThongTaiKhoan1 taiKhoanCo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(butToan.CoTaiKhoan);
                #region Old TKThue
                //string noTK = taiKhoanNo.SoHieuTK;
                //string CoTK = taiKhoanCo.SoHieuTK;
                //#region Kiểm tra  hóa đơn
                //if (taiKhoanNo.SoHieuTK.StartsWith("3113"))
                //{
                //    if (butToan.ChungTu_HoaDonList.Count == 0)
                //    {
                //        MessageBox.Show(this, "Vui lòng chọn hóa đơn cho bút toán!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return false;
                //    }
                //    else
                //    {

                //        decimal tongTienHoaDon = 0;
                //        foreach (ChungTu_HoaDon ct_hd in butToan.ChungTu_HoaDonList)
                //        {
                //            tongTienHoaDon += ct_hd.SoTien;
                //        }
                //        if (tongTienHoaDon != butToan.SoTien)
                //        {
                //            MessageBox.Show(this, "Gía trị hạch toán tài khoản thuế không bằng tổng giá trị các hóa đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //            return false;
                //        }
                //    }
                //}
                #endregion Old TKThue

                #region Modify TKThue
                #region Kiểm tra  hóa đơn
                if (IsTaiKhoanThueKhauTru(butToan.NoTaiKhoan))
                {
                    if (butToan.ChungTu_HoaDonList.Count == 0)
                    {
                        MessageBox.Show(this, "Vui lòng chọn hóa đơn cho bút toán!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {

                        decimal tongTienHoaDon = 0;
                        foreach (ChungTu_HoaDon ct_hd in butToan.ChungTu_HoaDonList)
                        {
                            tongTienHoaDon += ct_hd.SoTien;
                        }
                        if (tongTienHoaDon != butToan.SoTien)
                        {
                            MessageBox.Show(this, "Gía trị hạch toán tài khoản thuế không bằng tổng giá trị các hóa đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
                #endregion//Kiểm tra  hóa đơn
                #endregion Modify TKThue

                #region Kiểm Tra chi phí sản xuất

                //if (noTK == "1551" || noTK == "1552" || CoTK == "1551" || CoTK == "1552" || noTK.StartsWith("631") || noTK.StartsWith("4314"))
                //{
                //    if (butToan.ChungTu_ChiPhiSanXuatList.Count == 0)
                //    {
                //        MessageBox.Show(this, "Bạn phải chọn công việc/chương trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return false;
                //    }
                //    else
                //    {
                //        foreach (ChungTu_ChiPhiSanXuat cp in butToan.ChungTu_ChiPhiSanXuatList)
                //        {
                //            if (cp.ButtoanMucNganSachList.Count == 0 && (noTK.StartsWith("631") || noTK.StartsWith("4314")))
                //            {
                //                MessageBox.Show(this, "Vui lòng nhập mục ngân sách", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //                return false;
                //            }
                //        }
                //    }
                //}

                //if (butToan.ChungTu_ChiPhiSanXuatList.Count > 0)
                //{

                //    decimal sotienCTu = 0;
                //    foreach (ChungTu_ChiPhiSanXuat ct_cp in butToan.ChungTu_ChiPhiSanXuatList)
                //    {
                //        sotienCTu += ct_cp.SoTien;
                //    }
                //    if (butToan.SoTien != sotienCTu)
                //    {
                //        MessageBox.Show(this, "Tổng số tiền Công việc/Chương trình không bằng số tiền bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return false; ;
                //    }
                //}
                #endregion

                #region Kiểm Tra đối tượng theo dõi
                if (taiKhoanNo.CoDoiTuongTheoDoi == true)
                {
                    if (butToan.MaDoiTuongNo == 0)
                    {
                        MessageBox.Show(this, "Vui lòng chọn đối tượng nợ ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (taiKhoanCo.CoDoiTuongTheoDoi == true)
                {
                    if (butToan.MaDoiTuongCo == 0)
                    {
                        MessageBox.Show(this, "Vui lòng chọn đối tượng Có ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                #endregion//Kiểm Tra đối tượng theo dõi

            }
            return true;
        }

        private void formatGridview()
        {
            this.grdViewCt_PhieuNhap.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            this.grdView_DinhKhoan.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
        }

        private void LockData()
        {
            //grdViewCt_PhieuNhap.OptionsBehavior.OptionsBehavior.Editable = false;
            grdViewCt_PhieuNhap.Columns["SoLuong"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns["DonGia"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns["ThanhTien"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns["MaHangHoa"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns["DonGiaGoc"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns["ThanhTienGoc"].OptionsColumn.AllowEdit = false;

            grdViewCt_PhieuNhap.Columns["TyLeCK"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns["TienChietKhau"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns["ThueSuatVAT"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns["TienThue"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns["ThanhTien"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns["MaBoPhan"].OptionsColumn.AllowEdit = false;
            gridLookUpEdit_KhoNhan.Properties.ReadOnly = true;
            lookUpEdit_PPNXKho.Properties.ReadOnly = true;
            //btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            grdViewCt_PhieuNhap.Columns[26].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns[27].OptionsColumn.AllowEdit = false;
        }

        private void UnLockData()
        {
            //grdViewCt_PhieuNhap.OptionsBehavior.Editable = true;
            grdViewCt_PhieuNhap.Columns["SoLuong"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuNhap.Columns["DonGia"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuNhap.Columns["ThanhTien"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuNhap.Columns["MaHangHoa"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuNhap.Columns["DonGiaGoc"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuNhap.Columns["ThanhTienGoc"].OptionsColumn.AllowEdit = true;

            grdViewCt_PhieuNhap.Columns["TyLeCK"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuNhap.Columns["TienChietKhau"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuNhap.Columns["ThueSuatVAT"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuNhap.Columns["TienThue"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuNhap.Columns["ThanhTien"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuNhap.Columns["MaBoPhan"].OptionsColumn.AllowEdit = true;

            gridLookUpEdit_KhoNhan.Properties.ReadOnly = false;
            lookUpEdit_PPNXKho.Properties.ReadOnly = false;
            //btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            grdViewCt_PhieuNhap.Columns[26].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuNhap.Columns[27].OptionsColumn.AllowEdit = true;
        }

        private void AllowDelete()
        {
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        private void NotAllowDelete()
        {
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void CheckPhieuNhap()
        {
            if (_phieuNhapXuat != null)
                if (PhieuNhapXuat.KiemTraPhieuNhapDaXuatThang(_phieuNhapXuat.MaPhieuNhapXuat))
                {
                    // grdViewCt_PhieuNhap.OptionsBehavior.Editable = false;
                    LockData();
                    NotAllowDelete();
                }
                else
                {
                    //grdViewCt_PhieuNhap.OptionsBehavior.Editable = true;
                    UnLockData();
                    AllowDelete();
                }
        }

        private void Show_colMaDoiTuongNo()
        {
            this.colMaDoiTuongNo.Visible = true;
            this.colMaDoiTuongNo.VisibleIndex = 3;
            this.colMaDoiTuongNo.Width = 190;
        }

        #region BoSung KhoaSoThue
        private void FormatFormTheoKhoaSoThue()
        {
            //if (KhoaSoThue())
            //{
            //    btn_HoaDon.Enabled = false;
            //    if (_phieuNhapXuat.IsNew)
            //    {
            //        _phieuNhapXuat.HoaDon_NhapXuatList.Clear();
            //    }
            //}
            //else
            //{
            //    btn_HoaDon.Enabled = true;
            //}
        }//Them
        private bool CheckCoTaiKhoanThueTrongButToan()
        {
            foreach (ButToanPhieuNhapXuat buttoan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                #region Old TkThue
                //HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.NoTaiKhoan);
                //if (tk.SoHieuTK.StartsWith("3113"))
                //{
                //    return true;
                //}
                #endregion Old TkThue

                #region Modify TkThue
                if (IsTaiKhoanThueKhauTru(buttoan.NoTaiKhoan))
                {
                    return true;
                }
                #endregion Modify TkThue
            }
            return false;
        }//Them
        private bool KhoaSoThue()
        {
            bool khoasothue = false;
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_phieuNhapXuat.NgayNX);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSoThue == true)
                {
                    khoasothue = true;
                }
            }
            //
            if (khoasothue == false && _phieuNhapXuat.IsNew == false && _ngayLapCu != DateTime.MinValue)
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
        private bool CheckValidKhoaSoThueWhenChangeNgayNX()//Them
        {
            if (_phieuNhapXuat.IsNew == false && _ngayLapCu != DateTime.MinValue)
            {
                bool khoasotheoNgaylapcu = false;
                bool khoasotheoNgayNX = false;
                //duyet  theo ngay lap cu
                KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ngayLapCu);
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSoThue == true)
                    {
                        khoasotheoNgaylapcu = true;
                    }
                }

                if (khoasotheoNgaylapcu)
                {
                    foreach (ButToanPhieuNhapXuat buttoan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
                    {
                        #region Old TKThue
                        //HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.NoTaiKhoan);
                        //if (tk.SoHieuTK.StartsWith("3113"))
                        //{
                        //    MessageBox.Show("Ngày lập phiếu đã Khóa sổ Thuế, không thể thay đổi", "Thông Báo");
                        //    _phieuNhapXuat.NgayNX = _ngayLapCu;
                        //    dateEdit_NgayLap.EditValue = _ngayLapCu as object;
                        //    return false;
                        //}
                        #endregion Old TKThue
                        #region Modify TKThue
                        if (IsTaiKhoanThueKhauTru(buttoan.NoTaiKhoan))
                        {
                            MessageBox.Show("Ngày lập phiếu đã Khóa sổ Thuế, không thể thay đổi", "Thông Báo");
                            _phieuNhapXuat.NgayNX = _ngayLapCu;
                            dateEdit_NgayLap.EditValue = _ngayLapCu as object;
                            return false;
                        }
                        #endregion Modify TKThue
                    }
                }
                else
                {
                    //duyet  theo ngay nhap xuat
                    KhoaSo_UserList khoa_NgayNX = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_phieuNhapXuat.NgayNX);
                    if (khoa_NgayNX.Count > 0)
                    {
                        if (khoa_NgayNX[0].KhoaSoThue == true)
                        {
                            khoasotheoNgayNX = true;
                        }
                    }

                    if (khoasotheoNgayNX)
                    {
                        foreach (ButToanPhieuNhapXuat buttoan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
                        {
                            #region Old TKThue
                            //HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.NoTaiKhoan);
                            //if (tk.SoHieuTK.StartsWith("3113"))
                            //{
                            //    MessageBox.Show("Ngày thay đổi rơi vào ngày Khóa sổ Thuế, không thể thực hiện", "Thông Báo");
                            //    _phieuNhapXuat.NgayNX = _ngayLapCu;
                            //    dateEdit_NgayLap.EditValue = _ngayLapCu as object;
                            //    return false;
                            //}
                            #endregion Old TKThue
                            #region Modify TKThue
                            if (IsTaiKhoanThueKhauTru(buttoan.NoTaiKhoan))
                            {
                                MessageBox.Show("Ngày thay đổi rơi vào ngày Khóa sổ Thuế, không thể thực hiện", "Thông Báo");
                                _phieuNhapXuat.NgayNX = _ngayLapCu;
                                dateEdit_NgayLap.EditValue = _ngayLapCu as object;
                                return false;
                            }
                            #endregion Modify TKThue
                        }
                    }

                }
            }

            return true;
        }
        #endregion//BoSung KhoaSoThue

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
            foreach (ButToanPhieuNhapXuat buttoan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
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
                _phieuNhapXuat.NgayNX = _ngayLapCu;
                dateEdit_NgayLap.EditValue = _ngayLapCu as object;
                return false;
            }
            return true;
        }

        private bool KhoaButToanTheoTaiKhoan(int mataiKhoan)
        {

            bool khoataiKhoan = false;
            KhoaSo_MaTaiKhoanRootList khoa = KhoaSo_MaTaiKhoanRootList.GetKhoaSo_MaTaiKhoanRootList(UserId, mataiKhoan, _phieuNhapXuat.NgayNX);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    khoataiKhoan = true;
                }
            }

            if (khoataiKhoan == false && _phieuNhapXuat.IsNew == false && _ngayLapCu != DateTime.MinValue)
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
                ButToanPhieuNhapXuat buttoan = (ButToanPhieuNhapXuat)grdView_DinhKhoan.GetFocusedRow();
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

        private void DuyetButToanToShowDoiTuong_ButToan()
        {
            foreach (ButToanPhieuNhapXuat _butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                HeThongTaiKhoan1 httkNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                if (httkNo.CoDoiTuongTheoDoi)
                {
                    Show_colMaDoiTuongNo();
                    break;

                }
            }
        }

        private void CheckShow_colMaDoiTuongNo_LoadPhieu()
        {
            if (!_phieuNhapXuat.IsNew)
            {
                if (_phieuNhapXuat.ButToanPhieuNhapXuatList.Count > 0)
                {
                    DuyetButToanToShowDoiTuong_ButToan();
                }
            }
        }

        private void CheckHideShowDoiTuong_ButToan()
        {
            ButToanPhieuNhapXuat _butToan = ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current);
            HeThongTaiKhoan1 httkNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
            if (httkNo.CoDoiTuongTheoDoi)
            {
                Show_colMaDoiTuongNo();
                //((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).MaDoiTuongNo = _phieuNhapXuat.MaDoiTac;

            }
            else
            {
                this.colMaDoiTuongNo.Visible = false;
                ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).MaDoiTuongNo = 0;
                DuyetButToanToShowDoiTuong_ButToan();
            }
        }

        private bool KhoaSo()
        {
            bool khoaso = false;
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_phieuNhapXuat.NgayNX);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    khoaso = true;
                }
            }
            //
            if (khoaso == false && _phieuNhapXuat.IsNew == false && _ngayLapCu != DateTime.MinValue)
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



        private bool DaKetChuyen()
        {
            bool daKC = false;
            daKC = KyKetChuyenTonKho.KiemTraKetChuyetVatTu_PhucVuNXvaHuyKetChuyen(_phieuNhapXuat.NgayNX, _phieuNhapXuat.MaKho);
            if (daKC == false && _phieuNhapXuat.IsNew == false && _ngayLapCu != DateTime.MinValue)
            {
                daKC = KyKetChuyenTonKho.KiemTraKetChuyetVatTu_PhucVuNXvaHuyKetChuyen(_ngayLapCu, _maKhoCu);
            }

            if (daKC)
            {
                MessageBox.Show("Kỳ này đã kết chuyển, không thể cập nhật phiếu!");
            }
            return daKC;
        }

        #region KiemTraCT_PhieuNhapsKhongTrung

        /*
        private bool KiemTraCT_PhieuNhapsKhongTrung()
        {
            CT_PhieuNhap ctCapNhat = grdViewCt_PhieuNhap.GetFocusedRow() as CT_PhieuNhap;
            int indexCapNhat = grdViewCt_PhieuNhap.FocusedRowHandle;
            if (ctCapNhat != null)
            {
                if (_phieuNhapXuat.PhuongPhapNX == 1 && ctCapNhat.MaHangHoa != 0)
                {
                    for (int i = 0; i < grdViewCt_PhieuNhap.RowCount; i++)
                    {
                        if (grdViewCt_PhieuNhap.GetRow(i) != null)
                        {
                            if (i == indexCapNhat) continue;
                            CT_PhieuNhap ct_pn_gv = (CT_PhieuNhap)grdViewCt_PhieuNhap.GetRow(i);
                            if (ct_pn_gv.MaHangHoa == ctCapNhat.MaHangHoa
                                )
                            {
                                MessageBox.Show("Không nhập " + HangHoaBQ_VT.GetHangHoaBQ_VT(ctCapNhat.MaHangHoa).TenHangHoa + " nhiều dòng trên cùng 1 phiếu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                }
                else if (_phieuNhapXuat.PhuongPhapNX==2 && ctCapNhat.MaHangHoa != 0 && ctCapNhat.DonGia != 0)
                {
                    for (int i = 0; i < grdViewCt_PhieuNhap.RowCount; i++)
                    {
                        if (grdViewCt_PhieuNhap.GetRow(i) != null)
                        {
                            if (i == indexCapNhat) continue;
                            CT_PhieuNhap ct_pn_gv = (CT_PhieuNhap)grdViewCt_PhieuNhap.GetRow(i);
                            if (ct_pn_gv.MaHangHoa == ctCapNhat.MaHangHoa
                                && ct_pn_gv.DonGia == ctCapNhat.DonGia//New 19112013
                                )
                            {
                                MessageBox.Show("Không nhập " + HangHoaBQ_VT.GetHangHoaBQ_VT(ctCapNhat.MaHangHoa).TenHangHoa + " nhiều dòng trên cùng 1 phiếu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                }

            }//grdViewCt_PhieuXuat.RowCount > 0
            return true;
        }
        */
        private bool KiemTraCT_PhieuNhapsKhongTrung()
        {
            CT_PhieuNhap ctCapNhat = grdViewCt_PhieuNhap.GetFocusedRow() as CT_PhieuNhap;
            int indexCapNhat = grdViewCt_PhieuNhap.FocusedRowHandle;
            if (ctCapNhat != null)
            {
                if (ctCapNhat.MaHangHoa != 0 && ctCapNhat.DonGia != 0)
                {
                    for (int i = 0; i < grdViewCt_PhieuNhap.RowCount; i++)
                    {
                        if (grdViewCt_PhieuNhap.GetRow(i) != null)
                        {
                            if (i == indexCapNhat) continue;
                            CT_PhieuNhap ct_pn_gv = (CT_PhieuNhap)grdViewCt_PhieuNhap.GetRow(i);
                            if (ct_pn_gv.MaHangHoa == ctCapNhat.MaHangHoa
                                && ct_pn_gv.DonGia == ctCapNhat.DonGia//New 19112013
                                )
                            {
                                MessageBox.Show("Không nhập " + HangHoaBQ_VT.GetHangHoaBQ_VT(ctCapNhat.MaHangHoa).TenHangHoa + " nhiều dòng trên cùng 1 phiếu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                }

            }//grdViewCt_PhieuXuat.RowCount > 0
            return true;
        }

        #endregion//KiemTraCT_PhieuNhapsKhongTrung

        private void CapNhatLaiTongGiaTriPhieu()
        {
            Decimal tongTien = 0;
            foreach (CT_PhieuNhap ct_PhieuNhap in _phieuNhapXuat.CT_PhieuNhapList)
            {
                tongTien += Math.Round(ct_PhieuNhap.ThanhTien, 0, MidpointRounding.AwayFromZero);   //--bi sai so khi nhieu dong thue
                //tongTien += (ct_PhieuNhap.ThanhTienGoc - ct_PhieuNhap.TienChietKhau) + ((ct_PhieuNhap.ThanhTienGoc - ct_PhieuNhap.TienChietKhau) * (decimal)ct_PhieuNhap.ThueSuatVAT / 100);
            }
            _phieuNhapXuat.GiaTriKho = tongTien;
        }

        private void SetDefaultValueButToan(ButToanPhieuNhapXuat butToan)
        {
            decimal tongtienCP = 0;
            decimal tongtienThue = 0;
            if (butToan != null)
            {
                foreach (CT_PhieuNhap ct_PhieuNhap in _phieuNhapXuat.CT_PhieuNhapList)
                {
                    tongtienCP += ct_PhieuNhap.ThanhTien;
                    tongtienThue += ct_PhieuNhap.TienThue;
                }
                foreach (ButToanPhieuNhapXuat buttoanphieu in _phieuNhapXuat.ButToanPhieuNhapXuatList)
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
                butToan.MaDoiTuongCo = _phieuNhapXuat.MaDoiTac;
                butToan.DienGiai = _phieuNhapXuat.DienGiai;
            }
        }
        #endregion//Function

        #region EventHandles
        private void grdViewCt_PhieuNhap_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{
            //    foreach (int i in grdViewCt_PhieuNhap.GetSelectedRows())
            //    {
            //        grdViewCt_PhieuNhap.DeleteRow(i);
            //    }
            //}
            //
            //HamDungChung.CopyCell(grdViewCt_PhieuNhap, e);
        }


        private void grdViewCt_PhieuNhap_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            CT_PhieuNhap ct_phieuNhap = (CT_PhieuNhap)cTPhieuNhapListBindingSource.Current;
            ct_phieuNhap.DienGiai = _phieuNhapXuat.DienGiai;

            if (grdViewCt_PhieuNhap.RowCount > 1)
            {
                CT_PhieuNhap dongtren = grdViewCt_PhieuNhap.GetRow(0) as CT_PhieuNhap;
                ct_phieuNhap.ThueSuatVAT = dongtren.ThueSuatVAT;
            }
        }
        #region grdViewCt_PhieuNhap_CellValueChanged
        private void grdViewCt_PhieuNhap_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            CT_PhieuNhap ct_phieuNhap = (CT_PhieuNhap)cTPhieuNhapListBindingSource.Current;
            //if (grdViewCt_PhieuNhap.FocusedColumn.FieldName == "SoLuong" || grdViewCt_PhieuNhap.FocusedColumn.FieldName == "DonGia")
            //{
            //    grdCT_PhieuNhap.Update();
            //    ct_phieuNhap.ThanhTien = Math.Round(ct_phieuNhap.DonGia * ct_phieuNhap.SoLuong, 0, MidpointRounding.AwayFromZero);
            //}
            //else 
            if (grdViewCt_PhieuNhap.FocusedColumn.FieldName == "MaHangHoa")
            {
                HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_phieuNhap.MaHangHoa);
                ct_phieuNhap.MaDonViTinh = hangHoa.MaDonViTinh;
                ct_phieuNhap.ThoiLuong = hangHoa.ThoiLuong;

                decimal DonGiaGoc = PublicClass.LayGiaNhapGanNhat(ct_phieuNhap.MaHangHoa, this._phieuNhapXuat.NgayNX);
                ct_phieuNhap.DonGiaGoc = DonGiaGoc;
                //grdViewCt_PhieuNhap.RefreshData();

            }
            if (grdViewCt_PhieuNhap.FocusedColumn.FieldName == "MaHangHoa" || grdViewCt_PhieuNhap.FocusedColumn.Name == "DonGia")
            {
                if (!KiemTraCT_PhieuNhapsKhongTrung())
                {
                    ((CT_PhieuNhap)cTPhieuNhapListBindingSource.Current).MaHangHoa = 0;
                }

            }
            CapNhatLaiTongGiaTriPhieu();
            this.isThayDoiSoLieu = true;

        }
        #endregion

        #endregion EventHandles

        #region Event

        #region lookUpEdit_PPNXKho_EditValueChanged
        private void lookUpEdit_PPNXKho_EditValueChanged(object sender, EventArgs e)
        {
            byte ppnhapxuatOut = 0;
            if (byte.TryParse(lookUpEdit_PPNXKho.EditValue.ToString(), out ppnhapxuatOut))
            {
                //ppnhapxuatOut =(byte) lookUpEdit_PPNXKho.EditValue;
            }
            if (ppnhapxuatOut == 2)
            {
                barBt_LapPhieuXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                barBt_LapPhieuXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

        }
        #endregion

        #region btn_HoaDon_ItemClick
        private void btn_HoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            phieuNhapXuatBindingSource.EndEdit();
            #region Modify
            frmChonHoaDonLapPhieu frm = new frmChonHoaDonLapPhieu(_phieuNhapXuat);
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                if (frm.TrangThai == true)
                {
                    _phieuNhapXuat.HoaDon_NhapXuatList = frm.HoaDon_NhapXuatList;
                    _chungTu_HoaDonList = frm.ChungTu_HoaDonList;
                    foreach (ButToanPhieuNhapXuat _butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
                    {
                        #region Old TKThue
                        //HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                        //if (taiKhoan.SoHieuTK.StartsWith("3113") && !(KhoaSoThue()))
                        //{
                        //    _butToan.ChungTu_HoaDonList.Clear();
                        //    foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
                        //        _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));

                        //} 
                        #endregion Old TKThue

                        #region Modify TKThue
                        if (IsTaiKhoanThueKhauTru(_butToan.NoTaiKhoan))
                        {
                            _butToan.ChungTu_HoaDonList.Clear();
                            foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
                                _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));

                        }
                        #endregion Modify TKThue
                    }
                    _phieuNhapXuat.ApplyEdit();
                    _phieuNhapXuat.Save();
                }
            }
            #endregion Modify
            #region Old
            //if (_phieuNhapXuat.IsNew || _phieuNhapXuat.HoaDon_NhapXuatList.Count == 0)
            //{
            //    frmChonHoaDonLapPhieu frm = new frmChonHoaDonLapPhieu(_phieuNhapXuat.MaDoiTac);
            //    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            //    {
            //        if (frm.TrangThai == true)
            //        {
            //            _phieuNhapXuat.HoaDon_NhapXuatList = frm.HoaDon_NhapXuatList;
            //            _chungTu_HoaDonList = frm.ChungTu_HoaDonList;
            //            foreach (ButToanPhieuNhapXuat _butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            //            {
            //                #region Old TKThue
            //                //HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
            //                //if (taiKhoan.SoHieuTK.StartsWith("3113") && !(KhoaSoThue()))
            //                //{
            //                //    _butToan.ChungTu_HoaDonList.Clear();
            //                //    foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
            //                //        _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));

            //                //} 
            //                #endregion Old TKThue
            //                #region Modify TKThue
            //                HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
            //                if (IsTaiKhoanThueKhauTru(_butToan.NoTaiKhoan))
            //                {
            //                    _butToan.ChungTu_HoaDonList.Clear();
            //                    foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
            //                        _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));

            //                }
            //                #endregion Modify TKThue

            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    frmChonHoaDonLapPhieu frm = new frmChonHoaDonLapPhieu(_phieuNhapXuat);
            //    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            //    {
            //        if (frm.TrangThai == true)
            //        {
            //            _phieuNhapXuat.HoaDon_NhapXuatList = frm.HoaDon_NhapXuatList;
            //            _chungTu_HoaDonList = frm.ChungTu_HoaDonList;
            //            foreach (ButToanPhieuNhapXuat _butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            //            {
            //                #region Old TKThue
            //                //HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
            //                //if (taiKhoan.SoHieuTK.StartsWith("3113") && !(KhoaSoThue()))
            //                //{
            //                //    _butToan.ChungTu_HoaDonList.Clear();
            //                //    foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
            //                //        _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));

            //                //} 
            //                #endregion Old TKThue

            //                #region Modify TKThue
            //                if (IsTaiKhoanThueKhauTru(_butToan.NoTaiKhoan))
            //                {
            //                    _butToan.ChungTu_HoaDonList.Clear();
            //                    foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
            //                        _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));

            //                }
            //                #endregion Modify TKThue
            //            }
            //            _phieuNhapXuat.ApplyEdit();
            //            _phieuNhapXuat.Save();
            //        }
            //    }
            //}
            #endregion Old
        }
        #endregion

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textEdit_Focus.Focus();
            textEdit_Focus1.Focus();
            if (_coTKBiKhoa || CheckCoTaiKhoanBiKhoaTrongButToan())
            {
                MessageBox.Show("Tài khoản đã bị khóa, không thể lưu", "Thông Báo");
                return;
            }
            if (KhoaSo())
            {
                MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //End Add to 11012013
            //Add to 18012013
            if (_phieuNhapXuat.XacNhan == true)
            {
                MessageBox.Show(this, "Thủ kho đã xác nhận, xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!DaKetChuyen())
            {
                //XuLy Luu Phieu
                //End Add to 18012013
                if (txt_SoPhieu.EditValue != null)//IF 1
                {
                    string _soPhieu = txt_SoPhieu.EditValue.ToString();
                    int _stt;
                    //if (int.TryParse(_soPhieu.Substring(0, 4), out _stt))//IF 2
                    //{
                    bool ktphieutrung = true;
                    if (_phieuNhapXuat.IsNew)
                    {
                        ktphieutrung = PhieuNhapXuat.CheckSoPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat, _phieuNhapXuat.SoPhieu, true);
                    }
                    else//k phai IS NEW
                    {
                        ktphieutrung = PhieuNhapXuat.CheckSoPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat, _phieuNhapXuat.SoPhieu, false);
                    }

                    if (PhieuNhapXuat.KiemTraNgayNhap(_phieuNhapXuat.MaPhieuNhapXuat, _phieuNhapXuat.NgayNX) == true)
                    {
                        MessageBox.Show("Ngày nhập không thể lớn hơn ngày phiếu đã xuất!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (_phieuNhapXuat.ButToanPhieuNhapXuatList.Count == 0)
                    {
                        MessageBox.Show("Chứng từ chưa được hạch toán, bạn vui lòng hạch toán!");
                        return;
                        //if (MessageBox.Show("Chứng từ chưa được hạch toán, bạn có muốn tiếp tục lưu!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                        //{
                        //    return;
                        //}
                    }

                    if (ktphieutrung)//IF 5
                    {
                        //GH
                        phieuNhapXuatBindingSource.EndEdit();
                        try
                        {
                            if (KiemTraDuLieu() == true)
                            {
                                _phieuNhapXuat.ApplyEdit();
                                _phieuNhapXuat.Save();
                                //Add to 11012013
                                _ngayLapCu = _phieuNhapXuat.NgayNX;
                                _maKhoCu = _phieuNhapXuat.MaKho;
                                //End Add to 11012013
                                MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (_phieuNhapXuat.PhuongPhapNX == 2)
                                {
                                    long giaTri = PhieuNhapXuat.KiemTraPhieu(_phieuNhapXuat.MaPhieuNhapXuat);
                                    if (giaTri == 0)
                                    {
                                        if (MessageBox.Show("Bạn Có Muốn Lập Phiếu Xuất?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                        {
                                            FrmPhieuXuatVatTuHangHoa_New frm = new FrmPhieuXuatVatTuHangHoa_New(_phieuNhapXuat, 2, true);
                                            //frm.ShowDialog();//(1)
                                            if (frm.ShowDialog() != DialogResult.OK)
                                            {
                                                CheckPhieuNhap();
                                                LoadInfoByMaPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat);
                                            }//replace (1)
                                        }
                                    }
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Cập Nhật Thất Bại!\n"+ ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                        }
                        //
                    }//END IF 5
                    else
                    {
                        MessageBox.Show("Trùng Số Phiếu! Không Thể Lưu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_SoPhieu.Focus();
                    }
                    //}//END IF 2
                    //else
                    //{
                    //    MessageBox.Show("Số Phiếu Không Hợp Lệ! 4 ký tự đầu phải là số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    txt_SoPhieu.Focus();
                    //}

                }//END IF 4
                //XuLy Luu Phieu
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _coTKBiKhoa = false;
            KhoiTaoPhieu();
        }

        private void grdView_DinhKhoan_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            // Gan tien cho but toan
            ButToanPhieuNhapXuat butToan = (ButToanPhieuNhapXuat)(butToanPhieuNhapXuatListBindingSource.Current);
            SetDefaultValueButToan(butToan);
            #region Old
            //decimal soTienConLai = _phieuNhapXuat.GiaTriKho;
            //foreach (ButToanPhieuNhapXuat buttoanphieu in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            //{
            //    soTienConLai = soTienConLai - buttoanphieu.SoTien;
            //}
            //butToan.SoTien = soTienConLai;
            //butToan.MaDoiTuongCo = _phieuNhapXuat.MaDoiTac;
            //butToan.DienGiai = _phieuNhapXuat.DienGiai;
            #endregion Old
        }


        private void grdView_DinhKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{
            //    grdView_DinhKhoan.DeleteSelectedRows();
            //}
            //
            //HamDungChung.CopyCell(grdView_DinhKhoan, e);
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ////Rpt_PhieuNhapVatTu rpt = new Rpt_PhieuNhapVatTu(_phieuNhapXuat.MaPhieuNhapXuat, _phieuNhapXuat.NgayNX);
            ////FrmHienThiReportBQVT frm = new FrmHienThiReportBQVT(rpt);
            ////frm.WindowState = FormWindowState.Maximized;
            ////frm.ShowDialog();
            ////
            ////BEGIN

            //ReportTemplate _report;
            //#region Old phân biệt 2 mẫu: Bình quân và NXT
            ////if (_phieuNhapXuat.PhuongPhapNX == 2)//IF la XuatThang
            ////{
            ////    _report = ReportTemplate.GetReportTemplate("PhieuNhapVatTu_XuatThang");
            ////}
            ////else//IF la Xuat Binh Quan
            ////{
            ////    _report = ReportTemplate.GetReportTemplate("PhieuNhapVatTu");
            ////}
            //#endregion//Old phân biệt 2 mẫu: Bình quân và NXT

            //#region Modify Chỉ dùng 1 mẫu
            //_report = ReportTemplate.GetReportTemplate("PhieuNhapVatTu");
            //#endregion//Modify Chỉ dùng 1 mẫu
            //if (_report != null)
            //{
            //    DateTime dtDenNgay = DateTime.Today;
            //    frmReport frm = new frmReport();

            //    ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
            //    if (_reportTemplate.Id == string.Empty)
            //    {
            //        _reportTemplate.Id = _report.Id;
            //        _reportTemplate.UserID = UserId;
            //        _reportTemplate.DenNgay = dtDenNgay;
            //    }
            //    if (_report.TenPhuongThuc != "")
            //    {
            //        this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
            //    }

            //    frm.HienThiReport(_reportTemplate, dataSet);
            //    frm.ShowDialog();
            //}
            ////END
        }

        #region barBt_LapPhieuXuat_ItemClick
        private void barBt_LapPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_phieuNhapXuat.IsNew)
            {
                MessageBox.Show("Vui Lòng Cập Nhật Phiếu Nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                long giaTri = PhieuNhapXuat.KiemTraPhieu(_phieuNhapXuat.MaPhieuNhapXuat);
                if (giaTri != 0)
                {
                    PhieuNhapXuat phieuNhapXuat = PhieuNhapXuat.GetPhieuNhapXuat(giaTri);
                    FrmPhieuXuatVatTuHangHoa_New frm = new FrmPhieuXuatVatTuHangHoa_New(phieuNhapXuat, 1, true);
                    //frm.ShowDialog();//(1)
                    if (frm.ShowDialog() != DialogResult.OK)
                    {
                        CheckPhieuNhap();
                        LoadInfoByMaPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat);
                    }//replace (1)
                }
                else
                {
                    FrmPhieuXuatVatTuHangHoa_New frm = new FrmPhieuXuatVatTuHangHoa_New(_phieuNhapXuat, 2, true);
                    //frm.ShowDialog();//(1)
                    if (frm.ShowDialog() != DialogResult.OK)
                    {
                        CheckPhieuNhap();//replace (1)
                        LoadInfoByMaPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat);
                    }
                }
            }
        }
        #endregion

        //Sua
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1")
            {
                grdViewCt_PhieuNhap.DeleteSelectedRows();//Xoa nhieu dong
                CapNhatLaiTongGiaTriPhieu();

            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2")
            {
                bool chophepxoa = true;
                int[] deleteRows = grdView_DinhKhoan.GetSelectedRows();
                foreach (int deleteRow in deleteRows)
                {
                    ButToanPhieuNhapXuat buttoan = (ButToanPhieuNhapXuat)grdView_DinhKhoan.GetRow(deleteRow);
                    #region Old TKThue
                    //HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.NoTaiKhoan);
                    //if (tk.SoHieuTK.StartsWith("3113"))
                    //{
                    //    if (KhoaSoThue())
                    //    {
                    //        chophepxoa = false;
                    //        break;
                    //    }
                    //} 
                    #endregion Old TKThue
                    #region Modify TKThue
                    HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.NoTaiKhoan);
                    if (IsTaiKhoanThueKhauTru(buttoan.NoTaiKhoan))
                    {
                        if (KhoaSoThue())
                        {
                            chophepxoa = false;
                            break;
                        }
                    }
                    #endregion Modify TKThue

                }
                if (chophepxoa)
                    grdView_DinhKhoan.DeleteSelectedRows();
                else
                {
                    MessageBox.Show("Đã Khóa sổ Thuế, không thể Xóa Định khoản Thuế!");
                }
            }
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XtraFrm_HangHoa dlg = new XtraFrm_HangHoa(0);
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                if (dlg.MaHangHoaChon != 0)
                {
                    hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaVatTuHangHoaList();
                    if (cTPhieuNhapListBindingSource.Current == null || grdViewCt_PhieuNhap.GetFocusedRow() == null)
                        grdViewCt_PhieuNhap.AddNewRow();
                    CT_PhieuNhap ct_phieuNhap = (CT_PhieuNhap)cTPhieuNhapListBindingSource.Current;
                    ct_phieuNhap.MaHangHoa = dlg.MaHangHoaChon;
                    HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_phieuNhap.MaHangHoa);
                    ct_phieuNhap.MaDonViTinh = hangHoa.MaDonViTinh;
                    grdViewCt_PhieuNhap.RefreshData();
                }
            }
        }

        private void gridLookUpEdit_KhoNhan_EditValueChanged(object sender, EventArgs e)
        {
            //_phieuNhapXuat.MaKho = (int)gridLookUpEdit_KhoNhan.EditValue;
        }

        //Sua
        private void frmPhieuNhapVatTuHangHoa_Load(object sender, EventArgs e)
        {
            formatGridview();
            CheckPhieuNhap();
            FormatFormTheoKhoaSoThue();
            //CheckShow_colMaDoiTuongNo_LoadPhieu();//tam thoi k hien
            //Tang STT cho CT
            Utils.GridUtils.SetSTTForGridView(grdViewCt_PhieuNhap, 35);
            grdView_DinhKhoan.OptionsView.ShowFooter = true;
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdView_DinhKhoan, new string[] { "SoTien" }, "{0:#,###.##}");

            // 10/03/2021 
            //boPhanListBindingSource1.DataSource = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
            //doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacListByTen(0);

            thongTinNhanVienTongHopListBindingSource1.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopAll();
            khoBQVTListBindingSource1.DataSource = KhoBQ_VTList.GetKhoBQ_VTList();


            Init_lookUpEdit_PPNXKho();
            Utils.GridUtils.SetSTTForGridView(grdv_DanhSachPhieuNhapXuat, 35);
        }

        private void lookUpEdit_DoiTac_EditValueChanged(object sender, EventArgs e)
        {
            //_phieuNhapXuat.MaDoiTac = (long)lookUpEdit_DoiTac.EditValue;
        }

        private void ButtonEdit_HoaDon_Click(object sender, EventArgs e)
        {
            //HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).NoTaiKhoan);
            //if (tk.SoHieuTK.Contains("3113"))
            //{
            //    frmDanhSachHoaDonDichVuPhieuXuat _frm = new frmDanhSachHoaDonDichVuPhieuXuat(_phieuNhapXuat, _chungTu_HoaDonList, (ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current);
            //    _frm.Show();
            //}
        }

        //Sua
        private void grdView_DinhKhoan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (grdView_DinhKhoan.FocusedColumn.Name == "colNoTaiKhoan")
            {
                #region Old TKThue
                //HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).NoTaiKhoan);
                //ButToanPhieuNhapXuat butToan = ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current);

                //if (tk.SoHieuTK.StartsWith("3113"))
                //{
                //    if (KhoaSoThue())
                //    {
                //        MessageBox.Show("Đã khóa sổ thuế, không cập thể cập nhật thêm tài khoản thuế vào!");
                //        butToan.NoTaiKhoan = 0;
                //    }
                //    else
                //    {
                //        butToan.ChungTu_HoaDonList.Clear();
                //        foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
                //            butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));
                //    }
                //}
                //CheckHideShowDoiTuong_ButToan(); 
                #endregion Old TKThue

                #region Modify TKThue
                ButToanPhieuNhapXuat butToan = ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current);
                if (IsTaiKhoanThueKhauTru(butToan.NoTaiKhoan))
                {
                    if (KhoaSoThue())
                    {
                        MessageBox.Show("Đã khóa sổ thuế, không cập thể cập nhật thêm tài khoản thuế vào!");
                        butToan.NoTaiKhoan = 0;
                    }
                    else
                    {
                        #region BS
                        decimal tongtienThue = 0;
                        if (butToan != null && butToan.SoTien == 0)
                        {
                            foreach (CT_PhieuNhap ct_PhieuNhap in _phieuNhapXuat.CT_PhieuNhapList)
                            {
                                tongtienThue = tongtienThue + ct_PhieuNhap.TienThue;
                            }
                            foreach (ButToanPhieuNhapXuat buttoanphieu in _phieuNhapXuat.ButToanPhieuNhapXuatList)
                            {
                                if (IsTaiKhoanThueKhauTru(buttoanphieu.NoTaiKhoan))
                                {
                                    tongtienThue = tongtienThue - buttoanphieu.SoTien;
                                }
                            }
                            butToan.SoTien = tongtienThue;
                        }
                        #endregion BS
                        butToan.ChungTu_HoaDonList.Clear();
                        foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
                            butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));
                    }
                }
                CheckHideShowDoiTuong_ButToan();
                #endregion Modify TKThue
            }
        }

        //Sua
        private void grdView_DinhKhoan_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (grdView_DinhKhoan.FocusedColumn.Name == "colHoaDon" && !(KhoaSoThue()))
            {
                #region Old TKThue
                //HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).NoTaiKhoan);
                //if (tk.SoHieuTK.StartsWith("3113"))
                //{
                //    frmDanhSachHoaDonDichVuPhieuXuat _frm = new frmDanhSachHoaDonDichVuPhieuXuat(_phieuNhapXuat, _chungTu_HoaDonList, (ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current);
                //    _frm.ShowDialog();
                //} 
                #endregion Old TKThue

                #region Modify TKThue
                if (IsTaiKhoanThueKhauTru(((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).NoTaiKhoan))
                {
                    frmDanhSachHoaDonDichVuPhieuXuat _frm = new frmDanhSachHoaDonDichVuPhieuXuat(_phieuNhapXuat, _chungTu_HoaDonList, (ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current);
                    _frm.ShowDialog();
                }
                #endregion Modify TKThue
            }
            #region New
            if (grdView_DinhKhoan.FocusedColumn.Name == "col_btn")
            {
                if (((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current) != null)
                {
                    //Xu ly Tai day
                    ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).BeginEdit();
                    ButToanPhieuNhapXuat bt = (ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current;
                    #region Edit bug
                    ChungTu_ChiPhiSanXuatList cpList = ChungTu_ChiPhiSanXuatList.NewChungTu_ChiPhiSanXuatList();
                    foreach (ChungTu_ChiPhiSanXuat chungTu_ChiPhiSanXuat in ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList)
                    {
                        cpList.Add(chungTu_ChiPhiSanXuat);
                    }
                    //ChungTu_ChiPhiSanXuatList cpList = ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList;
                    #endregion//Edit bug

                    cpList.BeginEdit();
                    frmChiPhiSanXuatChuongTrinh_New f = new frmChiPhiSanXuatChuongTrinh_New(cpList, bt.SoTien, _phieuNhapXuat.NgayNX, bt.DienGiai, bt.MaButToan);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        if (f.IsSave == true)
                        {
                            ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList = f._ChungTu_ChiPhiSXList;
                            ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList.ApplyEdit();
                        }
                        else
                        {
                            cpList.CancelEdit();
                        }
                    }
                    //
                }
            }
            #endregion

        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2")
            {
                AllowDelete();

                if (this.isThayDoiSoLieu == true || this._phieuNhapXuat.ButToanPhieuNhapXuatList.Count == 0)
                {
                    //if (this._phieuNhapXuat.ButToanPhieuNhapXuatList.Count == 0)
                    //{
                    ButToanPhieuNhapXuat bt = ButToanPhieuNhapXuat.NewButToanPhieuNhapXuat();
                    int tkNo = HeThongTaiKhoan1.LayMaTaiKhoan("1532");//sửa lại theo yêu cầu chị Trang 01/07/2019
                    int tkCo = HeThongTaiKhoan1.LayMaTaiKhoan("331");
                    bt.NoTaiKhoan = tkNo;
                    bt.CoTaiKhoan = tkCo;
                    bt.MaDoiTuongCo = this._phieuNhapXuat.MaDoiTac;
                    bt.SoTien = this._phieuNhapXuat.GiaTriKho;
                    bt.DienGiai = textEdit_DienGiai.Text;
                    this._phieuNhapXuat.ButToanPhieuNhapXuatList.Add(bt);
                    //butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;
                    //}
                    this.isThayDoiSoLieu = false;
                }
            }
            else if (PhieuNhapXuat.KiemTraPhieuNhapDaXuatThang(_phieuNhapXuat.MaPhieuNhapXuat))
            {
                NotAllowDelete();
            }
        }

        //Sua
        private void btnXoaPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //B
            PhieuNhapXuat pnx = _phieuNhapXuat;
            if (pnx != null)
            {
                if (_coTKBiKhoa || CheckCoTaiKhoanBiKhoaTrongButToan())
                {
                    MessageBox.Show("Tài khoản đã bị khóa, k thể lưu", "Thông Báo");
                    return;
                }
                if (KhoaSo())
                {
                    MessageBox.Show(this, "Đã khóa sổ, xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (KhoaSoThue())
                {
                    if (CheckCoTaiKhoanThueTrongButToan())
                    {
                        MessageBox.Show(this, "Đã khóa sổ thuế, không thể xóa phiếu, xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (DaKetChuyen()) return;


                if (pnx.XacNhan == true)//Kiem Tra Thu Kho Xac Nhan
                {
                    MessageBox.Show(this, "Thủ kho đã xác nhận,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //
                if (PhieuNhapXuat.KiemTraPhieuNhapDaXuatThang(pnx.MaPhieuNhapXuat))//Kiem Tra Phieu Nhap Thang da Xuat
                {
                    MessageBox.Show("Phiếu Nhập đã Xuất!\n Vui lòng xóa Phiếu Xuất trước khi xóa Phiếu Nhập!");
                    return;
                }
                //Delete Phieu
                if (MessageBox.Show(this, "Bạn muốn xóa Phiếu này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        PhieuNhapXuat.DeletePhieuNhapXuat(_phieuNhapXuat);
                        MessageBox.Show(this, "Xóa Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnThemMoi.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "Cập Nhật Thất Bại!\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }//End Delete Phieu
            }
            //E
        }

        #region lookUpEdit_PhongBan_EditValueChanged
        private void lookUpEdit_PhongBan_EditValueChanged(object sender, EventArgs e)
        {
            if (_edtiBophan && lookUpEdit_PhongBan.EditValue != null)
            {
                int mabophabout;
                if (int.TryParse(lookUpEdit_PhongBan.EditValue.ToString(), out mabophabout))
                {
                    LoadDataForthongTinNhanVienTongHopListBindingSource(mabophabout);
                }
            }
            //_phieuNhapXuat.MaPhongBan = (int)lookUpEdit_PhongBan.EditValue;
        }
        private void LoadDataForthongTinNhanVienTongHopListBindingSource(int maboPHan)
        {
            ThongTinNhanVienTongHopList thongtinnhanvienlist = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_ByBophan(maboPHan);
            ThongTinNhanVienTongHop ttnv = ThongTinNhanVienTongHop.NewThongTinNhanVienTongHop(0, "<<None>>");
            thongtinnhanvienlist.Insert(0, ttnv);
            thongTinNhanVienTongHopListBindingSource.DataSource = thongtinnhanvienlist;
        }
        #endregion

        private void Init_lookUpEdit_PhongBan()
        {
            DataTable _dataTable = new DataTable();

            _dataTable.Columns.Add("Ma", typeof(byte));
            _dataTable.Columns.Add("Ten", typeof(string));

            _dataTable.Rows.Add(1, "Bình Quân");
            _dataTable.Rows.Add(2, "Thực tế đích danh");

            phuongPhapNXbindingSource.DataSource = _dataTable;
            lookUpEdit_PPNXKho.Properties.DataSource = phuongPhapNXbindingSource;
            this.lookUpEdit_PPNXKho.Properties.ValueMember = "Ma";
            this.lookUpEdit_PPNXKho.Properties.DisplayMember = "Ten";
            lookUpEdit_PPNXKho.Properties.NullText = "Không Chọn";
            lookUpEdit_PPNXKho.EditValue = 2;
        }

        private void dateEdit_NgayLap_Leave(object sender, EventArgs e)
        {
            if (dateEdit_NgayLap.OldEditValue != dateEdit_NgayLap.EditValue)
            {
                CheckValidKhoaTaiKhoanWhenChangeNgayCT();
                //CheckValidKhoaSoThueWhenChangeNgayNX();
                //FormatFormTheoKhoaSoThue();
                if (_phieuNhapXuat.MaPhieuNhapXuat == 0)
                {
                    _phieuNhapXuat.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuNhapXuat.Loai, _phieuNhapXuat.LaNhap, _phieuNhapXuat.NgayNX);
                }
            }
        }//Them

        //Them
        private void grd_DinhKhoan_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (grdView_DinhKhoan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit == false)
                e.Handled = true;
        }

        //Them
        private void grd_DinhKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdView_DinhKhoan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit == false)
                e.Handled = true;
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
                        _phieuNhapXuat.MaPhongBan = nv.MaBoPhan;
                    }
                }
            }
            _edtiBophan = true;
        }

        private void frmPhieuNhapVatTuHangHoa_New_FormClosing(object sender, FormClosingEventArgs e)
        {
            //textEdit_Focus.Focus();
            //textEdit_Focus1.Focus();
            //if (_phieuNhapXuat.IsDirty)
            //{
            //    DialogResult kq = MessageBox.Show("Bạn có muốn lưu sự chuyển đổi?", "Hộp Thoại Xác Nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            //    if (kq == DialogResult.Yes)
            //    {
            //        btnLuu.PerformClick();
            //    }
            //    else
            //        if (kq == DialogResult.Cancel)
            //        {
            //            e.Cancel = true;
            //        }
            //}
        }

        #endregion //Event

        #region Cac Phuong Thuc Report

        public void Spd_PhieuNhapVatTu()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao bang_PhieuNhapVatTu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_PhieuNhapVatTu";
                    cm.Parameters.AddWithValue("@MaPhieuNhap", _phieuNhapXuat.MaPhieuNhapXuat);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_PhieuNhapVatTu;1";
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


        #endregion//Cac Phuong Thuc Report

        void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            FrmPhieuXuatVatTuHangHoa_New a = new FrmPhieuXuatVatTuHangHoa_New(_pnx);

            a.ShowDialog();
            txt_SoPhieu_EditValueChanged(sender, e);
            LoadInfoByMaPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat);
        }

        void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            FrmPhieuXuatVatTuHangHoa_New a = new FrmPhieuXuatVatTuHangHoa_New(_pnx);

            a.ShowDialog();
            txt_SoPhieu_EditValueChanged(sender, e);
            LoadInfoByMaPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat);
        }

        void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            FrmPhieuXuatVatTuHangHoa_New a = new FrmPhieuXuatVatTuHangHoa_New(_pnx);

            a.ShowDialog();
            txt_SoPhieu_EditValueChanged(sender, e);
            LoadInfoByMaPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat);
        }

        void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            FrmPhieuXuatVatTuHangHoa_New a = new FrmPhieuXuatVatTuHangHoa_New(_pnx);

            a.ShowDialog();
            txt_SoPhieu_EditValueChanged(sender, e);
            LoadInfoByMaPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat);
        }

        void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            FrmPhieuXuatVatTuHangHoa_New a = new FrmPhieuXuatVatTuHangHoa_New(_pnx);

            a.ShowDialog();
            txt_SoPhieu_EditValueChanged(sender, e);
            LoadInfoByMaPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat);
        }

        void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            FrmPhieuXuatVatTuHangHoa_New a = new FrmPhieuXuatVatTuHangHoa_New(_pnx);

            a.ShowDialog();
            txt_SoPhieu_EditValueChanged(sender, e);
            LoadInfoByMaPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat);
        }

        void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            FrmPhieuXuatVatTuHangHoa_New a = new FrmPhieuXuatVatTuHangHoa_New(_pnx);

            a.ShowDialog();
            txt_SoPhieu_EditValueChanged(sender, e);
            LoadInfoByMaPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat);
        }

        void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            FrmPhieuXuatVatTuHangHoa_New a = new FrmPhieuXuatVatTuHangHoa_New(_pnx);

            a.ShowDialog();
            txt_SoPhieu_EditValueChanged(sender, e);
            LoadInfoByMaPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat);
        }

        void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            FrmPhieuXuatVatTuHangHoa_New a = new FrmPhieuXuatVatTuHangHoa_New(_pnx);

            a.ShowDialog();
            txt_SoPhieu_EditValueChanged(sender, e);
            LoadInfoByMaPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat);
        }

        private void txt_SoPhieu_EditValueChanged(object sender, EventArgs e)
        {
            int MaPhieu = PhieuNhapXuatList.GetMaPhieuBySoPhieu(txt_SoPhieu.EditValue.ToString());

            LoadLinkLabel(MaPhieu);
            //DataTable dt = PhieuNhapXuatList.GetPhieuXuatByPhieuNhap(MaPhieu, 1);
            //int i = 0;
            ////int _loca = 30;
            //linkLabel1.Visible = false;
            //linkLabel2.Visible = false;
            //linkLabel3.Visible = false;
            //linkLabel4.Visible = false;
            //linkLabel5.Visible = false;
            //linkLabel6.Visible = false;
            //linkLabel7.Visible = false;
            //linkLabel8.Visible = false;
            //linkLabel9.Visible = false;
            //for (int j = 1; j <= dt.Rows.Count; j++)
            //{
            //    if (j == 1)
            //        linkLabel1.Visible = true;
            //    else if (j == 2)
            //        linkLabel2.Visible = true;
            //    else if (j == 3)
            //        linkLabel3.Visible = true;
            //    else if (j == 4)
            //        linkLabel4.Visible = true;
            //    else if (j == 5)
            //        linkLabel5.Visible = true;
            //    else if (j == 6)
            //        linkLabel6.Visible = true;
            //    else if (j == 7)
            //        linkLabel7.Visible = true;
            //    else if (j == 8)
            //        linkLabel8.Visible = true;
            //    else if (j == 9)
            //        linkLabel9.Visible = true;
            //}

            //foreach (DataRow dr in dt.Rows)
            //{
            //    ////i++;
            //    int index = i + 1;
            //    //_loca += 74;
            //    //LinkLabel lb1 = new LinkLabel();
            //    //lb1 = new System.Windows.Forms.LinkLabel();
            //    //this.gr_ThongTinPhieu.Controls.Add(lb1);
            //    ////string aa = "";

            //    //lb1.Location = new System.Drawing.Point(_loca, 116);
            //    //lb1.Name = "linklabel" + index.ToString();
            //    ////lb1.Name = dr["MaPhieuNhapXuat"].ToString();
            //    //lb1.Size = new System.Drawing.Size(53, 13);
            //    //lb1.TabIndex = 14 + i;
            //    //lb1.TabStop = true;
            //    //lb1.Text = dr["SoPhieuXuat"].ToString();
            //    //_maPNX = Convert.ToInt32(dr["MaPhieuNhapXuat"].ToString());
            //    //lb1.LinkClicked += lb1_LinkClicked;
            //    //i++;
            //    if (index == 1)
            //    {
            //        linkLabel1.Text = dr["SoPhieuXuat"].ToString();
            //        linkLabel1.Links.RemoveAt(0);
            //        LinkLabel.Link link = new LinkLabel.Link();
            //        link.LinkData = dr["MaPhieuNhapXuat"].ToString();
            //        linkLabel1.Links.Add(link);
            //    }
            //    else if (index == 2)
            //    {
            //        linkLabel2.Text = dr["SoPhieuXuat"].ToString();
            //        linkLabel2.Links.RemoveAt(0);
            //        LinkLabel.Link link = new LinkLabel.Link();
            //        link.LinkData = dr["MaPhieuNhapXuat"].ToString();
            //        linkLabel2.Links.Add(link);
            //    }
            //    else if (index == 3)
            //    {
            //        linkLabel3.Text = dr["SoPhieuXuat"].ToString();
            //        linkLabel3.Links.RemoveAt(0);
            //        LinkLabel.Link link = new LinkLabel.Link();
            //        link.LinkData = dr["MaPhieuNhapXuat"].ToString();
            //        linkLabel3.Links.Add(link);
            //    }
            //    else if (index == 4)
            //    {
            //        linkLabel4.Text = dr["SoPhieuXuat"].ToString();
            //        linkLabel4.Links.RemoveAt(0);
            //        LinkLabel.Link link = new LinkLabel.Link();
            //        link.LinkData = dr["MaPhieuNhapXuat"].ToString();
            //        linkLabel4.Links.Add(link);
            //    }
            //    else if (index == 5)
            //    {
            //        linkLabel5.Text = dr["SoPhieuXuat"].ToString();
            //        linkLabel5.Links.RemoveAt(0);
            //        LinkLabel.Link link = new LinkLabel.Link();
            //        link.LinkData = dr["MaPhieuNhapXuat"].ToString();
            //        linkLabel5.Links.Add(link);
            //    }
            //    else if (index == 6)
            //    {
            //        linkLabel6.Text = dr["SoPhieuXuat"].ToString();
            //        linkLabel6.Links.RemoveAt(0);
            //        LinkLabel.Link link = new LinkLabel.Link();
            //        link.LinkData = dr["MaPhieuNhapXuat"].ToString();
            //        linkLabel6.Links.Add(link);
            //    }
            //    else if (index == 7)
            //    {
            //        linkLabel7.Text = dr["SoPhieuXuat"].ToString();
            //        linkLabel7.Links.RemoveAt(0);
            //        LinkLabel.Link link = new LinkLabel.Link();
            //        link.LinkData = dr["MaPhieuNhapXuat"].ToString();
            //        linkLabel7.Links.Add(link);
            //    }
            //    else if (index == 8)
            //    {
            //        linkLabel8.Text = dr["SoPhieuXuat"].ToString();
            //        linkLabel8.Links.RemoveAt(0);
            //        LinkLabel.Link link = new LinkLabel.Link();
            //        link.LinkData = dr["MaPhieuNhapXuat"].ToString();
            //        linkLabel8.Links.Add(link);
            //    }
            //    else if (index == 9)
            //    {
            //        linkLabel9.Text = dr["SoPhieuXuat"].ToString();
            //        linkLabel9.Links.RemoveAt(0);
            //        LinkLabel.Link link = new LinkLabel.Link();
            //        link.LinkData = dr["MaPhieuNhapXuat"].ToString();
            //        linkLabel9.Links.Add(link);
            //    }
            //    i++;
            //}
        }

        private void btnPrintEng_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportTemplate _report;
            #region Old phân biệt 2 mẫu: Bình quân và NXT
            //if (_phieuNhapXuat.PhuongPhapNX == 2)//IF la XuatThang
            //{
            //    _report = ReportTemplate.GetReportTemplate("PhieuNhapVatTu_XuatThang");
            //}
            //else//IF la Xuat Binh Quan
            //{
            //    _report = ReportTemplate.GetReportTemplate("PhieuNhapVatTu");
            //}
            #endregion//Old phân biệt 2 mẫu: Bình quân và NXT

            #region Modify Chỉ dùng 1 mẫu
            _report = ReportTemplate.GetReportTemplate("IDReport_PhieuNhapVatTu");
            #endregion//Modify Chỉ dùng 1 mẫu
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

        private void btnInVie_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportTemplate _report;
            #region Old phân biệt 2 mẫu: Bình quân và NXT
            //if (_phieuNhapXuat.PhuongPhapNX == 2)//IF la XuatThang
            //{
            //    _report = ReportTemplate.GetReportTemplate("PhieuNhapVatTu_XuatThang");
            //}
            //else//IF la Xuat Binh Quan
            //{
            //    _report = ReportTemplate.GetReportTemplate("PhieuNhapVatTu");
            //}
            #endregion//Old phân biệt 2 mẫu: Bình quân và NXT

            #region Modify Chỉ dùng 1 mẫu
            _report = ReportTemplate.GetReportTemplate("PhieuNhapVatTu");
            #endregion//Modify Chỉ dùng 1 mẫu
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

        #region danh sach phieu
        PhieuNhapXuatList _phieuNhapXuatList;
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (checkEdit_Ngay.Checked == true)
            {
                _phieuNhapXuatList = PhieuNhapXuatList.GetPhieuNhapXuatList_Tim("SearchByDate", Convert.ToInt32(cboKhoNhan.EditValue), (long)0, Convert.ToInt64(gridLookUpEdit3.EditValue), Convert.ToInt32(gridLookUpEdit1.EditValue), Convert.ToByte(cboPPXK.EditValue), (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, true, 2, UserId);
            }
            else
            {
                _phieuNhapXuatList = PhieuNhapXuatList.GetPhieuNhapXuatList_Tim("SearchAll", Convert.ToInt32(cboKhoNhan.EditValue), (long)0, Convert.ToInt64(gridLookUpEdit3.EditValue), Convert.ToInt32(gridLookUpEdit1.EditValue), Convert.ToByte(cboPPXK.EditValue), (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, true, 2, UserId);
            }

            phieuNhapXuatListBindingSource.DataSource = _phieuNhapXuatList;
            if (_phieuNhapXuatList.Count == 0)//M
                MessageBox.Show("Danh Sách Phiếu rỗng!");
        }

        private void Init_lookUpEdit_PPNXKho()
        {
            DataTable _dataTable = new DataTable();
            _dataTable.Columns.Add("Ma", typeof(byte));
            _dataTable.Columns.Add("Ten", typeof(string));

            _dataTable.Rows.Add(0, "<<None>>");
            _dataTable.Rows.Add(1, "Bình Quân");
            _dataTable.Rows.Add(2, "Nhập Xuất Thẳng");

            phuongPhapNXbindingSource.DataSource = _dataTable;
            cboPPXK.Properties.DataSource = phuongPhapNXbindingSource;
            this.cboPPXK.Properties.ValueMember = "Ma";
            this.cboPPXK.Properties.DisplayMember = "Ten";
            cboPPXK.Properties.NullText = "<<None>>";
        }

        #endregion

        private void grd_DanhSachPhieuXuat_DoubleClick(object sender, EventArgs e)
        {
            PhieuNhapXuat phieuNhapXuat = grdv_DanhSachPhieuNhapXuat.GetFocusedRow() as PhieuNhapXuat;
            LoadInfoByMaPhieuNhapXuat(phieuNhapXuat.MaPhieuNhapXuat);
            //_phieuNhapXuat = PhieuNhapXuat.GetPhieuNhapXuat(phieuNhapXuat.MaPhieuNhapXuat);
            //KhoiTaoPhieu(_phieuNhapXuat);
            //xtraTabControl2.SelectedTabPageIndex = 0;
            //CheckPhieuNhap();
            //LoadLinkLabel((int)_phieuNhapXuat.MaPhieuNhapXuat);
        }

        private void LoadInfoByMaPhieuNhapXuat(long maPhieu)
        {
            _phieuNhapXuat = PhieuNhapXuat.GetPhieuNhapXuat(maPhieu);
            KhoiTaoPhieu(_phieuNhapXuat);
            xtraTabControl2.SelectedTabPageIndex = 0;
            CheckPhieuNhap();
            LoadLinkLabel((int)maPhieu);
        }

        private void LoadLinkLabel(int _maPhieuNhap)
        {
            int MaPhieu = _maPhieuNhap;
            DataTable dt = PhieuNhapXuatList.GetPhieuXuatByPhieuNhap(MaPhieu, 1);
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
                    linkLabel1.Text = dr["SoPhieuXuat"].ToString();
                    linkLabel1.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["MaPhieuNhapXuat"].ToString();
                    linkLabel1.Links.Add(link);
                }
                else if (index == 2)
                {
                    linkLabel2.Text = dr["SoPhieuXuat"].ToString();
                    linkLabel2.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["MaPhieuNhapXuat"].ToString();
                    linkLabel2.Links.Add(link);
                }
                else if (index == 3)
                {
                    linkLabel3.Text = dr["SoPhieuXuat"].ToString();
                    linkLabel3.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["MaPhieuNhapXuat"].ToString();
                    linkLabel3.Links.Add(link);
                }
                else if (index == 4)
                {
                    linkLabel4.Text = dr["SoPhieuXuat"].ToString();
                    linkLabel4.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["MaPhieuNhapXuat"].ToString();
                    linkLabel4.Links.Add(link);
                }
                else if (index == 5)
                {
                    linkLabel5.Text = dr["SoPhieuXuat"].ToString();
                    linkLabel5.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["MaPhieuNhapXuat"].ToString();
                    linkLabel5.Links.Add(link);
                }
                else if (index == 6)
                {
                    linkLabel6.Text = dr["SoPhieuXuat"].ToString();
                    linkLabel6.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["MaPhieuNhapXuat"].ToString();
                    linkLabel6.Links.Add(link);
                }
                else if (index == 7)
                {
                    linkLabel7.Text = dr["SoPhieuXuat"].ToString();
                    linkLabel7.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["MaPhieuNhapXuat"].ToString();
                    linkLabel7.Links.Add(link);
                }
                else if (index == 8)
                {
                    linkLabel8.Text = dr["SoPhieuXuat"].ToString();
                    linkLabel8.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["MaPhieuNhapXuat"].ToString();
                    linkLabel8.Links.Add(link);
                }
                else if (index == 9)
                {
                    linkLabel9.Text = dr["SoPhieuXuat"].ToString();
                    linkLabel9.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["MaPhieuNhapXuat"].ToString();
                    linkLabel9.Links.Add(link);
                }
                i++;

            }
        }

        private DataSet ImportExcelXLSToDataset(string FileName, bool hasHeaders)
        {
            string HDR = hasHeaders ? "Yes" : "No";
            string strConn;
            if (FileName.Substring(FileName.LastIndexOf('.')).ToLower() == ".xlsx")
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
            else
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";

            _dataSet = new DataSet();
            DataTable outputTable = new DataTable();
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();

                DataTable schemaTable = conn.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                foreach (DataRow schemaRow in schemaTable.Rows)
                {
                    string sheet = schemaRow["TABLE_NAME"].ToString();

                    if (sheet == "Sheet1$" && !sheet.EndsWith("_"))
                    {
                        try
                        {
                            outputTable = new DataTable();
                            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "A1:O]", conn);
                            cmd.CommandType = CommandType.Text;

                            outputTable = new DataTable(sheet);
                            outputTable.TableName = "HangHoa";
                            new OleDbDataAdapter(cmd).Fill(outputTable);
                            _dataSet.Tables.Add(outputTable);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message + string.Format("Sheet:{0}.File:F{1}", sheet, FileName), ex);
                        }
                    }
                }
            }
            return _dataSet;
        }

        private void btnImportCT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                _FileNameImport = "";
                OpenFileDialog oFD = new OpenFileDialog();
                oFD.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                oFD.ShowDialog();
                string path = oFD.FileName;
                string p = System.IO.Path.GetFileName(path);
                _FileNameImport = p;
                DataSet dsRerult = ImportExcelXLSToDataset(path, true);
                ImportToHangHoaFromDataSet(dsRerult);
            }
            catch
            {
                MessageBox.Show("Không thể đọc file!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int KiemTraTonTaiHangHoa(string MaQLHangHoa)
        {
            _hangHoaListFul = HangHoaBQ_VTList.GetHangHoaBQ_VTList();
            foreach (HangHoaBQ_VT item in _hangHoaListFul)
            {
                if (item.MaQuanLy.ToUpper() == MaQLHangHoa.ToUpper())
                {
                    return item.MaHangHoa;
                }
            }
            return 0;
        }

        private int KiemTraTonTaiBoPhan(string MaQLBoPhan)
        {
            foreach (BoPhan boPhan in BoPhanList.GetBoPhanListKeCaBoPhanMoRong())
            {
                if (boPhan.MaBoPhanQL.ToUpper() == MaQLBoPhan.ToUpper())
                {
                    return boPhan.MaBoPhan;
                }
            }
            return 0;
        }

        private void ImportToHangHoaFromDataSet(DataSet dsresult)
        {
            _phieuNhapXuat.CT_PhieuNhapList.Clear();
            StringBuilder mainLog = new StringBuilder();
            int STT = 0, STTLoi = 0, soLuong;
            decimal donGia, thanhTien, tyLeCK, tienCK, chiPhiMuaHang, thueVat, tienThueVat, tongTien;
            String mota = "", ghiChu;
            if (dsresult.Tables.Count == 0) return;
            tblHangHoa = new DataTable();
            tblHangHoa = dsresult.Tables["HangHoa"];
            if (tblHangHoa.Rows.Count > 0)
            {
                foreach (DataRow rowhd in tblHangHoa.Rows)
                {
                    STT++;
                    int maHangHoa = 0, maBoPhan = 0;
                    donGia = 0; thanhTien = 0; soLuong = 0;
                    tyLeCK = 0; tienCK = 0; chiPhiMuaHang = 0; thueVat = 0; tienThueVat = 0; tongTien = 0;
                    mota = null; ghiChu = null;
                    StringBuilder errorLog = new StringBuilder();
                    if (rowhd[0].ToString().Trim().Length == 0)
                    {
                        errorLog.AppendLine("Mã hàng hóa, vật tư, công cụ dụng cụ không được để trống!");
                    }
                    else
                    {
                        maHangHoa = KiemTraTonTaiHangHoa(rowhd[0].ToString().Trim());
                        if (maHangHoa == 0)
                        {
                            errorLog.AppendLine("Mã hàng hóa, vật tư, công cụ dụng cụ Chưa có trong phần mềm!\nVui lòng tạo mã hàng hóa, vật tư, công cụ dụng cụ trong phần mềm!");
                        }
                    }
                    if (rowhd[4].ToString().Trim().Length == 0)//số lượng
                    {
                        errorLog.AppendLine("Số lượng hàng hóa, vật tư, công cụ dụng cụ không được để trống!");
                    }
                    else
                    {
                        bool kq = int.TryParse(rowhd[4].ToString().Trim(), out soLuong);
                        if (kq == false)
                            errorLog.AppendLine("Số lượng không đúng định dạng!");
                    }
                    if (rowhd[5].ToString().Trim().Length != 0)//đơn giá
                    {
                        bool kq = decimal.TryParse(rowhd[5].ToString().Trim(), out donGia);
                        if (kq == false)
                            errorLog.AppendLine("Đơn giá không đúng định dạng!");
                    }
                    //else
                    //{
                    //    errorLog.AppendLine("Đơn giá hàng hóa, vật tư, công cụ dụng cụ không được để trống!");
                    //}
                    if (rowhd[6].ToString().Trim().Length != 0)//thành tiền
                    {
                        bool kq = decimal.TryParse(rowhd[6].ToString().Trim(), out thanhTien);
                        if (kq == false)
                            errorLog.AppendLine("Thành tiền không đúng định dạng!");
                    }
                    //else
                    //{
                    //    errorLog.AppendLine("Thành tiền hàng hóa, vật tư, công cụ dụng cụ không được để trống!");
                    //}

                    if (rowhd[7].ToString().Trim().Length != 0)//tỷ lệ chiết khấu
                    {
                        bool kq = decimal.TryParse(rowhd[7].ToString().Trim(), out tyLeCK);
                        if (kq == false)
                            errorLog.AppendLine("Tỷ lệ chiết khấu không đúng định dạng!");
                    }
                    //else
                    //{
                    //    errorLog.AppendLine("Tỷ lệ chiết khấu hàng hóa, vật tư, công cụ dụng cụ không được để trống!");
                    //}

                    if (rowhd[8].ToString().Trim().Length != 0)//tiền chiết khấu
                    {
                        bool kq = decimal.TryParse(rowhd[8].ToString().Trim(), out tienCK);
                        if (kq == false)
                            errorLog.AppendLine("Tiền chiết khấu không đúng định dạng!");
                    }
                    //else
                    //{
                    //    errorLog.AppendLine("Tiền chiết khấu hàng hóa, vật tư, công cụ dụng cụ không được để trống!");
                    //}

                    if (rowhd[9].ToString().Trim().Length != 0)//chi phí mua hàng
                    {
                        bool kq = decimal.TryParse(rowhd[9].ToString().Trim(), out chiPhiMuaHang);
                        if (kq == false)
                            errorLog.AppendLine("Chi phí mua hàng không đúng định dạng!");
                    }
                    //else
                    //{
                    //    errorLog.AppendLine("Chi phí mua hàng hàng hóa, vật tư, công cụ dụng cụ không được để trống!");
                    //}

                    if (rowhd[10].ToString().Trim().Length != 0)//thuế Vat
                    {
                        bool kq = decimal.TryParse(rowhd[10].ToString().Trim(), out thueVat);
                        if (kq == false)
                            errorLog.AppendLine("Thuế VAT không đúng định dạng!");
                    }
                    //else
                    //{
                    //    errorLog.AppendLine("Thuế VAT hàng hóa, vật tư, công cụ dụng cụ không được để trống!");
                    //}

                    if (rowhd[11].ToString().Trim().Length != 0)//tiền thuế Vat
                    {
                        bool kq = decimal.TryParse(rowhd[11].ToString().Trim(), out tienThueVat);
                        if (kq == false)
                            errorLog.AppendLine("Tiền thuế VAT không đúng định dạng!");
                    }
                    //else
                    //{
                    //    errorLog.AppendLine("Tiền thuế VAT hàng hóa, vật tư, công cụ dụng cụ không được để trống!");
                    //}

                    if (rowhd[12].ToString().Trim().Length != 0)//tổng tiền = thành tiền
                    {
                        bool kq = decimal.TryParse(rowhd[12].ToString().Trim(), out tongTien);
                        if (kq == false)
                            errorLog.AppendLine("Tổng tiền không đúng định dạng!");
                    }
                    //else
                    //{
                    //    errorLog.AppendLine("Tổng tiền hàng hóa, vật tư, công cụ dụng cụ không được để trống!");
                    //}

                    if (rowhd[14].ToString().Trim().Length != 0)//bộ phận
                    {
                        maBoPhan = KiemTraTonTaiBoPhan(rowhd[14].ToString().Trim());
                        if (maBoPhan == 0)
                            errorLog.AppendLine("Không tồn tại mã phòng ban trong phần mềm!");
                    }
                    mota = rowhd[3].ToString();
                    ghiChu = rowhd[13].ToString().Trim();
                    if (errorLog.Length > 0)
                    {
                        STTLoi++;
                        mainLog.AppendLine(STTLoi + ") -------------------------------");
                        mainLog.AppendLine("- STT: " + STT + " có mã :" + rowhd[0].ToString().Trim());
                        mainLog.AppendLine(errorLog.ToString());
                    }
                    else
                    {
                        grdViewCt_PhieuNhap.AddNewRow();
                        CT_PhieuNhap ct_phieuNhap = (CT_PhieuNhap)cTPhieuNhapListBindingSource.Current;
                        ct_phieuNhap.MaHangHoa = maHangHoa;
                        ct_phieuNhap.MaDonViTinh = DonViTinh.GetDonViTinh(HangHoaBQ_VT.GetHangHoaBQ_VT(maHangHoa).MaDonViTinh).MaDonViTinh;
                        ct_phieuNhap.MoTaTenCCDC = mota;
                        ct_phieuNhap.DienGiai = rowhd[1].ToString().Trim() + ghiChu;
                        ct_phieuNhap.SoLuong = soLuong;
                        ct_phieuNhap.DonGiaGoc = Math.Round(donGia, 0, MidpointRounding.AwayFromZero);
                        ct_phieuNhap.ThanhTienGoc = Math.Round(thanhTien, 0, MidpointRounding.AwayFromZero);
                        ct_phieuNhap.TyLeCK = (double)tyLeCK;
                        ct_phieuNhap.TienChietKhau = tienCK;
                        ct_phieuNhap.ChiPhiMuaHang = chiPhiMuaHang;
                        ct_phieuNhap.ThueSuatVAT = (double)thueVat;
                        ct_phieuNhap.TienThue = Math.Round(tienThueVat, 0, MidpointRounding.AwayFromZero);
                        ct_phieuNhap.ThanhTien = Math.Round(tongTien, 0, MidpointRounding.AwayFromZero);
                        if (maBoPhan != 0)
                            ct_phieuNhap.MaBoPhan = maBoPhan;
                    }
                }//end forech
                if (mainLog.Length > 0)
                {
                    _phieuNhapXuat.CT_PhieuNhapList.Clear();
                    const string tenFile = "Import_Log.txt";
                    //FileStream fileStream = File.Open(tenFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                    StreamWriter writer = new StreamWriter(tenFile);
                    writer.WriteLine(mainLog.ToString());
                    writer.Flush();
                    writer.Close();
                    writer.Dispose();
                    //mở file log
                    System.Diagnostics.Process.Start(tenFile);
                }
            }
            txt_SoPhieu.Focus();
            CapNhatLaiTongGiaTriPhieu();
        }

        private void btnExportCT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridUtil.ExportToExcel(gridView: this.grdViewCt_PhieuNhap, showOpenFilePrompt: true);
        }

        private void btnExportDanhSach_Click(object sender, EventArgs e)
        {
            GridUtil.ExportToExcel(gridView: this.grdv_DanhSachPhieuNhapXuat, showOpenFilePrompt: true);
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (_edtiBophan && lookUpEdit_PhongBan.EditValue != null)
            {
                int mabophabout;
                if (int.TryParse(lookUpEdit_PhongBan.EditValue.ToString(), out mabophabout))
                {
                    LoadDataForthongTinNhanVienTongHopListBindingSource(mabophabout);
                }
            }
        }
    }
}