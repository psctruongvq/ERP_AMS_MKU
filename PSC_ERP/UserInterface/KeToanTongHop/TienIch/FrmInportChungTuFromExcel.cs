using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraEditors.Repository;
using System.IO;
using System.Diagnostics;
using System.Data.OleDb;

namespace PSC_ERP
{
    public partial class FrmInportChungTuFromExcel : DevExpress.XtraEditors.XtraForm
    {
        ChungTuImportFromExcelList _ChungTuImportFromExcelList = ChungTuImportFromExcelList.NewChungTuImportFromExcelList();
        CTNhapXuatImportFromExcelList _ctNhapXuatImportFromExcelList = CTNhapXuatImportFromExcelList.NewCTNhapXuatImportFromExcelList();
        ChungTuCustomizeList _chungtuCustomizeList = ChungTuCustomizeList.NewChungTuCustomizeList();
        DateTime _tuNgay;
        DateTime _denNgay;
        string _FileNameImport = "";

        private LoaiChungTuDevList _LoaiChungTuList = LoaiChungTuDevList.NewLoaiChungTuDevList();
        private HeThongTaiKhoan1List _hethongtaikhoanList = HeThongTaiKhoan1List.NewHeThongTaiKhoan1List();
        private DoiTuongAllList _DoiTuongList = DoiTuongAllList.NewDoiTuongAllList();
        ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList _TKNganHangCtyList;

        DataSet _dataSet = new DataSet();

        public FrmInportChungTuFromExcel()
        {
            InitializeComponent();
            KhoiTao();
            DesignGridControls();
            LoadData();
        }


        #region Function


        private void KhoiTao()
        {
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuuCTNhapXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            ChungTuImportFromExcelList_bindingSource.DataSource = typeof(ChungTuImportFromExcelList);
            CTNhapXuatImportFromExcelListbindingSource.DataSource = typeof(CTNhapXuatImportFromExcelList);
            ChungTuCustomizelistbindingSource.DataSource = typeof(ChungTuCustomizeList);
            ChungTuImportFromExcelList_bindingSource.DataSource = _ChungTuImportFromExcelList;
            gridControl1.DataSource = ChungTuImportFromExcelList_bindingSource;
            CTNhapXuatImportFromExcelListbindingSource.DataSource = _ctNhapXuatImportFromExcelList;
            gridControl2.DataSource = CTNhapXuatImportFromExcelListbindingSource;
            ChungTuCustomizelistbindingSource.DataSource = _chungtuCustomizeList;
            gridControl3.DataSource = ChungTuCustomizelistbindingSource;
            //gridControl1.ContextMenuStrip = contextMenuStrip1;
            dtEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            dtEdit_DenNgay.EditValue = (object)DateTime.Today.Date;

            _LoaiChungTuList = LoaiChungTuDevList.GetLoaiChungTuDevList();
            _hethongtaikhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            _DoiTuongList = DoiTuongAllList.GetDoiTuongAllList_Tim("", 0);
            _TKNganHangCtyList = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList();
            //=================
            //TKNganHangCongTyList_bindingSource1.DataSource = typeof(ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList);
            //TKNganHangCongTyGiaoDichbindingSource1.DataSource = typeof(ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList);
            //DoiTuongNoList_BindingSource.DataSource = typeof(DoiTuongAllList); ;
            //DoiTuongCoList_BindingSource.DataSource = typeof(DoiTuongAllList); ;
            //LoaiChungTuList_bindingSource1.DataSource = typeof(LoaiChungTuDevList);
            //Co_heThongTaiKhoan1ListBindingSource.DataSource = typeof(HeThongTaiKhoan1List);
            //No_heThongTaiKhoan1ListBindingSource1.DataSource = typeof(HeThongTaiKhoan1List);
            //LoaiChungTuList_bindingSource1.DataSource = LoaiChungTuDevList.GetLoaiChungTuDevList();
            //HeThongTaiKhoan1List _taiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            //Co_heThongTaiKhoan1ListBindingSource.DataSource = _taiKhoanList;
            //No_heThongTaiKhoan1ListBindingSource1.DataSource = _taiKhoanList;

            ////Load Doi Tuong No Co
            //DoiTuongAllList doituongNoCoList = DoiTuongAllList.GetDoiTuongAllList_Tim("", 0); //_factory.Context.sp_AllDoiTuong(1, 0).Where(x => x.MaCongTy == _maCongTy).ToList();//Lấy đối tác
            //DoiTuongAll doituongNCEmpty = DoiTuongAll.NewDoiTuongAll("<<None>>");//new sp_AllDoiTuong_Result() { MaDoiTuong = 0, TenDoiTuong = "<<None>>" };
            //doituongNoCoList.Insert(0, doituongNCEmpty);
            //DoiTuongNoList_BindingSource.DataSource = doituongNoCoList;
            //DoiTuongCoList_BindingSource.DataSource = doituongNoCoList;
            ////TaiKhoanNganHangCongTy
            ////TKNganHangCongTyList_bindingSource1.DataSource = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList();
            ////TaiKhoanNganHangDoCongTyGiaoDich
            //ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList tkNganHangCongTyGiaoDichList = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList();
            //ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild tknhgiaodichEmpty = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild.NewTaiKhoanNganHangCongTy("<<None>>");
            ////tkNganHangCongTyGiaoDichList.Insert(0, tknhgiaodichEmpty);
            //TKNganHangCongTyList_bindingSource1.DataSource = tkNganHangCongTyGiaoDichList;
            //TKNganHangCongTyGiaoDichbindingSource1.DataSource = tkNganHangCongTyGiaoDichList;
        }
        private void LoadData()
        {
            GetInformationSearch();
            _ChungTuImportFromExcelList = ChungTuImportFromExcelList.GetChungTuImportFromExcelList(_tuNgay, _denNgay);
            _ctNhapXuatImportFromExcelList = CTNhapXuatImportFromExcelList.GetCTNhapXuatImportFromExcelList(_tuNgay, _denNgay);
            BindingData();
            //if (_ChungTuImportFromExcelList.Count > 0)
            //{
            //    btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //}
        }

        private void LoadChungTuCustomizelist()
        {
            GetInformationSearch();
            _chungtuCustomizeList = ChungTuCustomizeList.GetChungTuCustomizeList(_tuNgay, _denNgay);
            ChungTuCustomizelistbindingSource.DataSource = _chungtuCustomizeList;
        }

        private void BindingData()
        {
            ChungTuImportFromExcelList_bindingSource.DataSource = _ChungTuImportFromExcelList;
            CTNhapXuatImportFromExcelListbindingSource.DataSource = _ctNhapXuatImportFromExcelList;
        }

        private void DesignGridView()
        {
            HamDungChung.InitGridViewDev(gridView1, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev2(gridView1, new string[] { "STT", "LoaiChungTu", "SoChungTu", "NgayChungTu", "NgayHachToan", "SoHoaDon", "NgayHoaDon", "TKNo", "TKCo", "LoaiTien", "SoTien", "QuyDoiSoTien", "MaVTHH", "TenVTHH", "SoLuong", "DonGia", "TyLeCK", "TienCK", "MaDoiTuongChung", "MaDoiTuongNo", "MaDoiTuongCo", "TaiKhoanNganHang", "TaiKhoanNganHangDen", "KhoanMucChiPhi", "DTTapHopCP", "MaThongKe", "DienGiaiChung", "DienGiaiChiTiet", "TinhTrangGhiSo", "TenDTChung", "TenDTCo", "TenDTNo", "MaKho", "MaDonVi", "SoHopDong", "FileImportName", "NgayImport" },
                                new string[] { "STT", "Loại chứng từ", "Số chứng từ", "Ngày chứng từ", "Ngày hạch toán", "Số hóa đơn", "Ngày hóa đơn", "TK Nợ", "TK Có", "Loại tiền", "Số tiền", "Quy đổi", "Mã VTHH", "Tên VTHH", "Số lượng", "Đơn giá", "Tỷ lệ CK", "Tiền CK", "Mã ĐT chung", "Mã ĐT nợ", "Mã ĐT có", "TK ngân hàng đi", "TK ngân hàng đến", "Khoản mục CP", "ĐT tập hợp CP", "Mã thống kê", "Diễn giải chung", "Diễn giải chi tiết", "TT Ghi sổ", "Mã ĐT chung", "Tên ĐT có", "Tên ĐT nợ", "Mã Kho", "Mã Đơn Vị", "Số Hợp Đồng", "Tên file import", "Ngày import" },
                                             new int[] { 50, 90, 90, 75, 75, 90, 75, 75, 75, 75, 90, 90, 90, 90, 80, 90, 80, 80, 75, 75, 90, 90, 90, 90, 90, 80, 150, 150, 90, 110, 110, 110, 80, 80, 80, 120, 75 }, false);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "STT", "LoaiChungTu", "SoChungTu", "NgayChungTu", "NgayHachToan", "SoHoaDon", "NgayHoaDon", "TKNo", "TKCo", "LoaiTien", "SoTien", "QuyDoiSoTien", "MaVTHH", "TenVTHH", "SoLuong", "DonGia", "TyLeCK", "TienCK", "MaDoiTuongChung", "MaDoiTuongNo", "MaDoiTuongCo", "TaiKhoanNganHang", "TaiKhoanNganHangDen", "KhoanMucChiPhi", "DTTapHopCP", "MaThongKe", "DienGiaiChung", "DienGiaiChiTiet", "TinhTrangGhiSo", "TenDTChung", "TenDTCo", "TenDTNo", "MaKho", "MaDonVi", "SoHopDong", "FileImportName", "NgayImport" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoTien", "QuyDoiSoTien", "SoLuong", "TienCK" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoTien", "QuyDoiSoTien", "SoLuong", "TienCK" }, "{0:#,###.#}");

            HamDungChung.ReadOnlyColumnGridViewDev(gridView1);


            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            #region Xem Lai Do Load Cham
            //HamDungChung.AllowEditColumnChooseGridViewDev(gridView1, new string[] { "LoaiChungTu", "TKNo", "TKCo", "MaDoiTuongNo", "MaDoiTuongCo", "TaiKhoanNganHang", "TaiKhoanNganHangDen", "KhoanMucChiPhi" });
            ////Loai Chung Tu
            //RepositoryItemGridLookUpEdit LoaiChungTu_GrdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(LoaiChungTu_GrdLU, LoaiChungTuList_bindingSource1, "TenLoaiCT", "MaLoaiCT", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiChungTu_GrdLU, new string[] { "TenLoaiCT", "TienTo" }, new string[] { "Loại chứng từ", "Tiền tố chứng từ" }, new int[] { 100, 150 }, false);
            //HamDungChung.RegisterControlFieldGridViewDev(gridView1, "LoaiChungTu", LoaiChungTu_GrdLU);
            ////TK No
            //RepositoryItemGridLookUpEdit TaiKhoanNo_GrdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(TaiKhoanNo_GrdLU, No_heThongTaiKhoan1ListBindingSource1, "SoHieuTK", "MaTaiKhoan", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TaiKhoanNo_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu", "Tên tài khoản" }, new int[] { 100, 150 }, false);
            //HamDungChung.RegisterControlFieldGridViewDev(gridView1, "TKNo", TaiKhoanNo_GrdLU);

            ////TK Co
            //RepositoryItemGridLookUpEdit TaiKhoanCo_GrdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(TaiKhoanCo_GrdLU, Co_heThongTaiKhoan1ListBindingSource, "SoHieuTK", "MaTaiKhoan", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TaiKhoanCo_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu", "Tên tài khoản" }, new int[] { 100, 150 }, false);
            //HamDungChung.RegisterControlFieldGridViewDev(gridView1, "TKCo", TaiKhoanCo_GrdLU);
            ////DoiTuongNo
            //RepositoryItemGridLookUpEdit DoiTuongNo_grdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(DoiTuongNo_grdLU, DoiTuongCoList_BindingSource, "TenDoiTuong", "MaDoiTuong", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DoiTuongNo_grdLU, new string[] { "MaQLDoiTuong", "MaSoThue", "TenDoiTuong" }, new string[] { "Mã đối tượng", "Mã số thuế", "Tên đối tượng" }, new int[] { 90, 90, 200 }, false);
            //HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaDoiTuongNo", DoiTuongNo_grdLU);
            ////
            ////DoiTuongCo
            //RepositoryItemGridLookUpEdit DoiTuongCo_grdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(DoiTuongCo_grdLU, DoiTuongCoList_BindingSource, "TenDoiTuong", "MaDoiTuong", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DoiTuongCo_grdLU, new string[] { "MaQLDoiTuong", "MaSoThue", "TenDoiTuong" }, new string[] { "Mã đối tượng", "Mã số thuế", "Tên đối tượng" }, new int[] { 90, 90, 200 }, false);
            //HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaDoiTuongCo", DoiTuongCo_grdLU);
            ////
            ////TaiKhoan Ngan Hang Cong Ty
            //RepositoryItemGridLookUpEdit TKNganHangCty_grdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(TKNganHangCty_grdLU, TKNganHangCongTyList_bindingSource1, "SoTaiKhoan", "MaChiTiet", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TKNganHangCty_grdLU, new string[] { "SoTaiKhoan", "TenNganHang" }, new string[] { "Số tài khoản", "Ngân hàng" }, new int[] { 90, 120 }, false);
            //HamDungChung.RegisterControlFieldGridViewDev(gridView1, "TaiKhoanNganHang", TKNganHangCty_grdLU);
            ////TK Ngan Hang Giao Dich
            //RepositoryItemGridLookUpEdit TKNganHangCtyGiaoDich_grdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(TKNganHangCtyGiaoDich_grdLU, TKNganHangCongTyGiaoDichbindingSource1, "SoTaiKhoan", "MaChiTiet", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TKNganHangCtyGiaoDich_grdLU, new string[] { "SoTaiKhoan", "TenNganHang" }, new string[] { "Số tài khoản", "Ngân hàng" }, new int[] { 90, 120 }, false);

            #endregion//Xem Lai Do Load Cham
            gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
        }

        private void DesignChiTietNhapXuatGridView()
        {
            HamDungChung.InitGridViewDev(gridView4, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev2(gridView4, new string[] { "Stt", "SoChungTu", "MaVTHH", "TenVTHH", "SoLuong", "DonGia", "ThanhTien", "GhiChu", "FileImportName" },
                                new string[] { "Stt", "Số chứng từ", "Mã VTHH", "Tên VTHH", "Số lượng", "Đơn giá", "Thành tiền", "Ghi chú", "FileImportName" },
                                             new int[] { 50, 90, 90, 120, 90, 100, 100, 120, 100 }, true);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView4, new string[] { "Stt", "SoChungTu", "MaVTHH", "TenVTHH", "SoLuong", "DonGia", "ThanhTien", "GhiChu", "FileImportName" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView4, new string[] { "SoLuong", "DonGia", "ThanhTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView4, new string[] { "SoLuong", "ThanhTien" }, "{0:#,###.#}");

            HamDungChung.ReadOnlyColumnGridViewDev(gridView4);


            Utils.GridUtils.SetSTTForGridView(gridView4, 50);//M
            //gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
        }

        private void DesignGridViewChungTuDaImport()
        {
            //, "SoTien", "LoaiTien", "QuyDoiSoTien"
            //, "SoHoaDon", "NgayHoaDon"
            //"LoaiChungTu","SoChungTu" ,"NgayChungTu", "NgayHachToan", "SoHoaDon","NgayHoaDon","TKNo ","TKCo", "LoaiTien", "SoTien","QuyDoiSoTien","MaDoiTuongChung","TenDTChung","MaDoiTuongNo","MaDoiTuongCo"," DienGiaiChung","DienGiaiChiTiet","TinhTrangGhiSo","TenDTCo","TenDTNo","MaCongTy","UserImport","TenDoiTuongNgoai"
            HamDungChung.InitGridViewDev(gridView6, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev2(gridView6, new string[] { "LoaiChungTu", "SoChungTu", "NgayChungTu", "MaDoiTuongChung", "TenDTChung", "TenDoiTuongNgoai", "TKNo", "TKCo", "SoTienButToan", "TenDTNo", "TenDTCo", "DienGiaiChung", "DienGiaiChiTiet", "TinhTrangGhiSo" },
                                new string[] { "Loại chứng từ", "Số chứng từ", "Ngày chứng từ", "Mã đối tượng trong", "Đối tượng trong", "Đối tượng ngoài", "TK Nợ ", "TK Có", "Số tiền bút toán", "Đối tượng nợ", "Đối tượng có", " Diễn giải chung", "Diễn giải chi tiết", "Ghi sổ" },
                                             new int[] { 120, 90, 80, 100, 120, 120, 80, 80, 100, 120, 120, 120, 120, 80 }, false);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView6, new string[] { "LoaiChungTu", "SoChungTu", "NgayChungTu", "MaDoiTuongChung", "TenDTChung", "TenDoiTuongNgoai", "TKNo", "TKCo", "SoTienButToan", "TenDTNo", "TenDTCo", "DienGiaiChung", "DienGiaiChiTiet", "TinhTrangGhiSo" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView6, new string[] { "SoTienButToan" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView6, new string[] { "SoTienButToan" }, "{0:#,###.#}");

            HamDungChung.ReadOnlyColumnGridViewDev(gridView6);


            Utils.GridUtils.SetSTTForGridView(gridView6, 50);//M
            this.gridView6.DoubleClick += new System.EventHandler(this.gridView6_DoubleClick);
        }

        private void DesignGridControls()
        {
            DesignGridView();
            DesignChiTietNhapXuatGridView();
            DesignGridViewChungTuDaImport();
        }

        private bool TestBeforeDelete()
        {
            int[] deleteRows = gridView1.GetSelectedRows();
            foreach (int deleteRow in deleteRows)
            {
                ChungTuImportFromExcel ctimp = gridView1.GetRow(deleteRow) as ChungTuImportFromExcel;
                if (ChungTuImportFromExcel.KiemTraChungTuDaDuocImportVaoData(ctimp.SoChungTu))
                {
                    MessageBox.Show("Chứng từ đã được import vào dữ liệu chính, không thể xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void DeleteObject()
        {
            if (TestBeforeDelete())
            {
                HamDungChung.DeleteSelectedRowsGridViewDev(gridView1);
            }
        }

        private void GetInformationSearch()
        {
            _tuNgay = Convert.ToDateTime(dtEdit_TuNgay.EditValue);
            _denNgay = Convert.ToDateTime(dtEdit_DenNgay.EditValue);
        }


        #region Import From Excel

        private DataSet ImportExcelXLSToDataset(string FileName, bool hasHeaders)
        {

            #region Old
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

                    if (sheet == "ChiTietNhapXuat$" && !sheet.EndsWith("_"))
                    {
                        try
                        {
                            outputTable = new DataTable();
                            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "A5:H]", conn);
                            cmd.CommandType = CommandType.Text;

                            outputTable = new DataTable(sheet);
                            outputTable.TableName = "ChiTietNhapXuat";
                            new OleDbDataAdapter(cmd).Fill(outputTable);
                            _dataSet.Tables.Add(outputTable);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message + string.Format("Sheet:{0}.File:F{1}", sheet, FileName), ex);
                        }
                    }
                    //---
                    if (sheet == "DSButToanChungTu$" && !sheet.EndsWith("_"))
                    {
                        try
                        {
                            outputTable = new DataTable();
                            //OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "A5:AI]", conn);
                            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "A5:AO]", conn);
                            cmd.CommandType = CommandType.Text;

                            outputTable = new DataTable(sheet);
                            outputTable.TableName = "DSButToanChungTu";
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
            #endregion//Old
        }

        private DataTable ImportExcelXLS(string FileName, bool hasHeaders)
        {

            #region Old
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

                    if (sheet == "DSButToanChungTu$" && !sheet.EndsWith("_"))
                    {
                        try
                        {
                            //OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "A5:AG]", conn);
                            cmd.CommandType = CommandType.Text;

                            outputTable = new DataTable(sheet);
                            new OleDbDataAdapter(cmd).Fill(outputTable);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message + string.Format("Sheet:{0}.File:F{1}", sheet, FileName), ex);
                        }
                    }
                    if (outputTable.TableName != "")
                    {
                        break;
                    }
                }
            }
            return outputTable;
            #endregion//Old

            #region Modify
            //string HDR = hasHeaders ? "Yes" : "No";
            //string strConn;
            //if (FileName.Substring(FileName.LastIndexOf('.')).ToLower() == ".xlsx")
            //    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
            //else
            //    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";


            //DataTable outputTable = new DataTable();
            //using (OleDbConnection conn = new OleDbConnection(strConn))
            //{
            //    conn.Open();

            //    DataTable schemaTable = conn.GetOleDbSchemaTable(
            //        OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

            //    DataRow schemaRow = schemaTable.Rows[1];
            //    //foreach (DataRow schemaRow in schemaTable.Rows)
            //    //{
            //        string sheet = schemaRow["TABLE_NAME"].ToString();

            //        if (!sheet.EndsWith("_"))
            //        {
            //            try
            //            {
            //                //OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
            //                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "A5:AG]", conn);
            //                cmd.CommandType = CommandType.Text;

            //                outputTable = new DataTable(sheet);
            //                new OleDbDataAdapter(cmd).Fill(outputTable);
            //            }
            //            catch (Exception ex)
            //            {
            //                throw new Exception(ex.Message + string.Format("Sheet:{0}.File:F{1}", sheet, FileName), ex);
            //            }
            //        }
            //    //}
            //}
            //return outputTable;
            #endregion//Modify
        }

        private void ImportToTable(DataTable tblresult)
        {
            #region Old
            //if (tblresult.Rows.Count > 0)
            //{
            //    foreach (DataRow rowhd in tblresult.Rows)
            //    {
            //        //Ngay lap
            //        DateTime ngaylap = DateTime.Today.Date;
            //        DateTime ngaylapOut;
            //        if (DateTime.TryParse(rowhd[5].ToString(), out ngaylapOut))
            //        {
            //            ngaylap = ngaylapOut;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Ngày lập hóa đơn không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }
            //        //MaDoiTac
            //        long madoitac = 0;
            //        DoiTac dtac = DoiTac.GetDoiTacWithoutChildbyTenKhachHang(rowhd[6].ToString());
            //        if (dtac != null) madoitac = dtac.MaDoiTac;
            //        //ThanhTien
            //        decimal thanhtien;
            //        decimal thanhtienOut;
            //        if (decimal.TryParse(rowhd[8].ToString(), out thanhtienOut))
            //        {
            //            thanhtien = thanhtienOut;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Tiền trước thuế không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }

            //        //ThueSuatVAT
            //        double thuesuatVAT;
            //        double thuesuatVATOut;
            //        if (double.TryParse(rowhd[9].ToString(), out thuesuatVATOut))
            //        {
            //            thuesuatVAT = thuesuatVATOut;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Thuế suất VAT không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }
            //        //maHinhThucTT
            //        int mahinhthuctt = 1;
            //        if (rowhd[13].ToString() == "chuyển khoản")
            //        {
            //            mahinhthuctt = 2;
            //        }
            //        //KhauTruThue
            //        bool khautruthue = false;
            //        bool khautruthueOut;
            //        if (bool.TryParse(rowhd[14].ToString(), out khautruthueOut))
            //        {
            //            khautruthue = khautruthueOut;
            //        }
            //        else
            //        {
            //            MessageBox.Show("HĐ khấu trừ thuế không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }

            //        UltraGridRow rownew = grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].AddNew();

            //        rownew.Cells["SoHoaDon"].Value = rowhd[2].ToString();
            //        rownew.Cells["SoSerial"].Value = rowhd[1].ToString();
            //        rownew.Cells["MauHoaDon"].Value = rowhd[3].ToString();
            //        rownew.Cells["KyHieuMauHoaDon"].Value = rowhd[4].ToString();
            //        rownew.Cells["NgayLap"].Value = ngaylap;
            //        rownew.Cells["MaDoiTac"].Value = madoitac;
            //        rownew.Cells["GhiChu"].Value = rowhd[7].ToString();
            //        rownew.Cells["ThanhTien"].Value = thanhtien;
            //        rownew.Cells["ThueSuatVAT"].Value = thuesuatVAT;
            //        rownew.Cells["maHinhThucTT"].Value = mahinhthuctt;
            //        rownew.Cells["KhauTruThue"].Value = khautruthue;

            //        rownew.Cells["TenKhachHangNgoai"].Value = rowhd[15].ToString();
            //        rownew.Cells["MSThueNgoai"].Value = rowhd[16].ToString(); ;
            //        rownew.Cells["NguoiLienLacNgoai"].Value = rowhd[17].ToString();
            //        rownew.Cells["diachiNgoai"].Value = rowhd[18].ToString(); ;
            //        rownew.Cells["DTNgoai"].Value = rowhd[19].ToString();

            //        //grdu_DSHoaDon.Rows.Move(rownew, grdu_DSHoaDon.Rows.Count - 1);
            //        rownew.ParentCollection.Move(rownew, grdu_DSHoaDon.Rows.Count - 1);
            //        this.grdu_DSHoaDon.ActiveRowScrollRegion.ScrollRowIntoView(rownew);
            //    }
            //    //UltraGridRow rowtemp = grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].AddNew();
            //    //grdu_DSHoaDon.Rows[rowtemp.Index].Delete();
            //    //grdu_DSHoaDon.Rows.Refresh(Infragistics.Win.UltraWinGrid.RefreshRow.ReloadData);
            //    grdu_DSHoaDon.UpdateData();
            //    _HoaDonList.ApplyEdit();
            //    DSHoaDonDichVu_BindingSource.EndEdit();
            //    //cbChungTu.Focus();
            //} 
            #endregion//Old

                      #region New
            if (tblresult.Rows.Count > 0)
            {
                foreach (DataRow rowhd in tblresult.Rows)
                {
                    if (rowhd[1].ToString().Trim().Length == 0 && rowhd[2].ToString().Trim().Length == 0)//LoaiHoaDon và SoChungTu = rong
                    {
                        return;
                    }
                    //STT
                    double sTT = 0;
                    double sTTOut;
                    if (double.TryParse(rowhd[0].ToString(), out sTTOut))
                    {
                        sTT = sTTOut;
                    }
                    //STT	(1)LoaiChungTu	(2)SoChungTu	(3)NgayChungTu	(4)NgayHachToan	
                    //(5)SoHoaDon	(6)NgayHoaDon	(7)TKNo	(8)TKCo	(9)LoaiTien	(10)SoTien	
                    //(11)QuyDoiSoTien	(12)MaVTHH	(13)TenVTHH	(14)SoLuong	(15)DonGia	
                    //(16)TyLeCK	(17)TienCK	(18)DoiTuongNo	(19)DoiTuongCo	
                    //(20)TaiKhoanNganHang, (21) TaiKhoanNganHangDen	(22)KhoanMucChiPhi	(23)DTTapHopCP	
                    //(24)MaThongKe	(25)DienGiaiChung	(26)DienGiaiChiTiet	
                    //(27)TinhTrangGhiSo	(28)TenDTCo	(29)TenDTNo


                    //LoaiChungTu
                    if (KiemTraTonTaiLoaiChungTu(rowhd[1].ToString().Trim()) == false)
                    {
                        MessageBox.Show(string.Format("Loại chứng từ không hợp lệ của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RefreshData();
                        return;
                    }
                    //TKNo, TK Co
                    if (KiemTraTonTaiTKNo(rowhd[7].ToString().Trim()) == false)
                    {
                        MessageBox.Show(string.Format("TK Nợ không hợp lệ của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RefreshData();
                        return;
                    }
                    if (KiemTraTonTaiTKCo(rowhd[8].ToString().Trim()) == false)
                    {
                        MessageBox.Show(string.Format("TK Có không hợp lệ của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RefreshData();
                        return;
                    }
                    //Doi Tuong No, Doi Tuong Co
                    //if (rowhd[18].ToString().Trim().Length != 0)
                    //{
                    //    if (KiemTraTonTaiMaDoiTuongNo(rowhd[18].ToString().Trim()) == false)
                    //    {
                    //        if (MessageBox.Show(string.Format("Mã Đối tượng Nợ không có trong danh mục Đối tượng của chứng từ {0}, số TT {1}, Bạn có muốn bỏ qua đối tượng này và tiếp tục!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    //        {
                    //            RefreshData();
                    //            //MessageBox.Show(string.Format("Mã Đối tượng Nợ không có trong danh mục Đối tượng của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //            return;
                    //        }
                    //    }

                    //}
                    //if (rowhd[19].ToString().Trim().Length != 0)
                    //{
                    //    if (KiemTraTonTaiMaDoiTuongCo(rowhd[19].ToString().Trim()) == false)
                    //    {
                    //        if (MessageBox.Show(string.Format("Mã Đối tượng Có không có trong danh mục Đối tượng của chứng từ {0}, số TT {1}, Bạn có muốn bỏ qua đối tượng này và tiếp tục!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    //        {
                    //            RefreshData();
                    //            //MessageBox.Show(string.Format("Mã Đối tượng Có không có trong danh mục Đối tượng của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //            return;
                    //        }
                    //    }
                    //}
                    ////TaiKhoanNganHangDi, TaiKhoanNganHangDen
                    //if (rowhd[20].ToString().Trim().Length != 0)
                    //{
                    //    if (KiemTraTonTaiTkNganHangCongtyDi(rowhd[20].ToString().Trim()) == false)
                    //    {
                    //        if (MessageBox.Show(string.Format("Tài khoản ngân hàng đi không có trong danh mục Tài khoản của chứng từ {0}, số TT {1}, Bạn có muốn bỏ qua đối tượng này và tiếp tục!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    //        {
                    //            RefreshData();
                    //            //MessageBox.Show(string.Format("Tài khoản ngân hàng đi không có trong danh mục Tài khoản của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //            return;
                    //        }
                    //    }
                    //}
                    //if (rowhd[21].ToString().Trim().Length != 0)
                    //{
                    //    if (KiemTraTonTaiTkNganHangCongtyDen(rowhd[21].ToString().Trim()) == false)
                    //    {
                    //        if (MessageBox.Show(string.Format("Tài khoản ngân hàng đến không có trong danh mục Tài khoản của chứng từ {0}, số TT {1}, Bạn có muốn bỏ qua đối tượng này và tiếp tục!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    //        {
                    //            RefreshData();
                    //            //MessageBox.Show(string.Format("Tài khoản ngân hàng đến không có trong danh mục Tài khoản của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //            return;
                    //        }
                    //    }
                    //}

                    //Ngay Chung Tu
                    DateTime ngayChungTu = DateTime.Today.Date;
                    DateTime ngaychungtuOut;
                    if (DateTime.TryParse(rowhd[3].ToString(), out ngaychungtuOut))
                    {
                        ngayChungTu = ngaychungtuOut;
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Ngày chứng từ không hợp lệ của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RefreshData();
                        return;
                    }
                    //NgayHoachToan
                    DateTime ngayHoachToan = DateTime.Today.Date;
                    if (rowhd[4].ToString() != "")
                    {
                        DateTime ngayHoachToanOut;
                        if (DateTime.TryParse(rowhd[4].ToString(), out ngayHoachToanOut))
                        {
                            ngayHoachToan = ngayHoachToanOut;
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Ngày hoạch toán không hợp lệ của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            RefreshData();
                            return;
                        }
                    }
                    //NgayHoaDon
                    DateTime ngayhoadon = DateTime.Today.Date;
                    if (rowhd[6].ToString() != "")
                    {
                        DateTime ngayhoadonOut;
                        if (DateTime.TryParse(rowhd[6].ToString(), out ngayhoadonOut))
                        {
                            ngayhoadon = ngayhoadonOut;
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Ngày hóa đơn không hợp lệ của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            RefreshData();
                            return;
                        }
                    }
                    #region BatBuoc Nhap TKNo, TK Co
                    //(7)TKNo	
                    if (rowhd[7].ToString() == "")
                    {
                        MessageBox.Show(string.Format("Vui lòng hoạch toán TK Nợ của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RefreshData();
                        return;
                    }
                    //(8)TKCo
                    if (rowhd[8].ToString() == "")
                    {
                        MessageBox.Show(string.Format("Vui lòng hoạch toán TK Có của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RefreshData();
                        return;
                    }
                    #endregion//BatBuoc Nhap TKNo, TK Co
                    //So Tien
                    decimal soTien = 0;
                    decimal soTienOut;
                    if (decimal.TryParse(rowhd[10].ToString(), out soTienOut))
                    {
                        soTien = soTienOut;
                    }
                    else if (soTien == 0)
                    {
                        MessageBox.Show(string.Format("Số tiền của chứng từ {0}, số TT {1} không hợp lệ!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RefreshData();
                        return;
                    }
                    //So Tien Quy Doi
                    decimal soTienQuyDoi = 0;
                    decimal soTienQuyDoiOut;
                    if (decimal.TryParse(rowhd[11].ToString(), out soTienQuyDoiOut))
                    {
                        soTienQuyDoi = soTienQuyDoiOut;
                    }
                    else if (soTienQuyDoi == 0)
                    {
                        MessageBox.Show(string.Format("Số tiền quy đổi của chứng từ {0}, số TT {1} không hợp lệ!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RefreshData();
                        return;
                    }
                    //(14)SoLuong
                    decimal soLuong = 0;
                    if (rowhd[14].ToString() != "")
                    {
                        decimal soLuongOut;
                        if (decimal.TryParse(rowhd[14].ToString(), out soLuongOut))
                        {
                            soLuong = soLuongOut;
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Số lượng của chứng từ {0}, số TT {1} không hợp lệ!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            RefreshData();
                            return;
                        }
                    }
                    //(15)DonGia	
                    decimal dongia = 0;
                    if (rowhd[15].ToString() != "")
                    {
                        decimal dongiaOut;
                        if (decimal.TryParse(rowhd[15].ToString(), out dongiaOut))
                        {
                            dongia = dongiaOut;
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Đơn giá của chứng từ {0}, số TT {1} không hợp lệ!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            RefreshData();
                            return;
                        }
                    }
                    //(16)TyLeCK	
                    decimal tyLeCK = 0;
                    if (rowhd[16].ToString() != "")
                    {
                        decimal tyLeCKOut;
                        if (decimal.TryParse(rowhd[16].ToString(), out tyLeCKOut))
                        {
                            tyLeCK = tyLeCKOut;
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Tỷ lệ CK của chứng từ {0}, số TT {1} không hợp lệ!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            RefreshData();
                            return;
                        }
                    }
                    //(17)TienCK
                    decimal tienCK = 0;
                    if (rowhd[17].ToString() != "")
                    {
                        decimal tienCKOut;
                        if (decimal.TryParse(rowhd[17].ToString(), out tienCKOut))
                        {
                            tienCK = tienCKOut;
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Tiền CK của chứng từ {0}, số TT {1} không hợp lệ!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            RefreshData();
                            return;
                        }
                    }


                    //
                    ChungTuImportFromExcel chungtuImportNew = ChungTuImportFromExcel.NewChungTuImportFromExcel();
                    chungtuImportNew.STT = sTT;
                    chungtuImportNew.LoaiChungTu = rowhd[1].ToString();
                    chungtuImportNew.SoChungTu = rowhd[2].ToString();
                    chungtuImportNew.NgayChungTu = ngayChungTu;
                    chungtuImportNew.NgayHachToan = ngayHoachToan;
                    chungtuImportNew.SoHoaDon = rowhd[5].ToString();
                    chungtuImportNew.NgayHoaDon = ngayhoadon;
                    chungtuImportNew.TKNo = rowhd[7].ToString();
                    chungtuImportNew.TKCo = rowhd[8].ToString();
                    chungtuImportNew.LoaiTien = rowhd[9].ToString();
                    chungtuImportNew.SoTien = soTien;
                    chungtuImportNew.QuyDoiSoTien = soTienQuyDoi;
                    chungtuImportNew.MaVTHH = rowhd[12].ToString();
                    chungtuImportNew.TenVTHH = rowhd[13].ToString();
                    chungtuImportNew.SoLuong = soLuong;
                    chungtuImportNew.DonGia = dongia;
                    chungtuImportNew.TyLeCK = tyLeCK;
                    chungtuImportNew.TienCK = tienCK;
                    chungtuImportNew.MaDoiTuongChung = rowhd[18].ToString();
                    chungtuImportNew.MaDoiTuongNo = rowhd[19].ToString();

                    chungtuImportNew.MaDoiTuongCo = rowhd[20].ToString();
                    chungtuImportNew.TaiKhoanNganHang = rowhd[21].ToString();
                    chungtuImportNew.TaiKhoanNganHangDen = rowhd[22].ToString();
                    chungtuImportNew.KhoanMucChiPhi = rowhd[23].ToString();
                    chungtuImportNew.DTTapHopCP = rowhd[24].ToString();
                    chungtuImportNew.MaThongKe = rowhd[25].ToString();
                    chungtuImportNew.DienGiaiChung = rowhd[26].ToString();
                    chungtuImportNew.DienGiaiChiTiet = rowhd[27].ToString();
                    chungtuImportNew.TinhTrangGhiSo = rowhd[28].ToString();
                    chungtuImportNew.TenDTChung = rowhd[29].ToString();
                    chungtuImportNew.TenDTCo = rowhd[30].ToString();
                    chungtuImportNew.TenDTNo = rowhd[31].ToString();
                    chungtuImportNew.FileImportName = _FileNameImport;


                    _ChungTuImportFromExcelList.Add(chungtuImportNew);
                    //
                }
                ChungTuImportFromExcelList_bindingSource.DataSource = _ChungTuImportFromExcelList;
                if (_ChungTuImportFromExcelList.Count > 0)
                {
                    btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }

            }
            #endregion//New

        }

        private void ImportToChungTuFromDataSet(DataSet dsresult)
        {
            #region New
            if (dsresult.Tables.Count == 0) return;
            DataTable tblChungTu = new DataTable();
            tblChungTu = dsresult.Tables["DSButToanChungTu"];
            //Chung Tu

            bool isImportThanhCong = true;

            #region ChungTu
            if (tblChungTu.Rows.Count > 0)
            {
                foreach (DataRow rowhd in tblChungTu.Rows)
                {
                    if (rowhd[1].ToString().Trim().Length == 0 && rowhd[2].ToString().Trim().Length == 0)//LoaiHoaDon và SoChungTu = rong
                    {
                        //return;                        
                        isImportThanhCong = false;
                        continue;
                    }
                    //STT
                    double sTT = 0;
                    double sTTOut;
                    if (double.TryParse(rowhd[0].ToString(), out sTTOut))
                    {
                        sTT = sTTOut;
                    }
                    //STT	(1)LoaiChungTu	(2)SoChungTu	(3)NgayChungTu	(4)NgayHachToan	
                    //(5)SoHoaDon	(6)NgayHoaDon	(7)TKNo	(8)TKCo	(9)LoaiTien	(10)SoTien	
                    //(11)QuyDoiSoTien	(12)MaVTHH	(13)TenVTHH	(14)SoLuong	(15)DonGia	
                    //(16)TyLeCK	(17)TienCK	(18)DoiTuongNo	(19)DoiTuongCo	
                    //(20)TaiKhoanNganHang, (21) TaiKhoanNganHangDen	(22)KhoanMucChiPhi	(23)DTTapHopCP	
                    //(24)MaThongKe	(25)DienGiaiChung	(26)DienGiaiChiTiet	
                    //(27)TinhTrangGhiSo	(28)TenDTCo	(29)TenDTNo

                    string TKno = "";
                    string TKco = "";

                    TKno = rowhd[7].ToString().Trim();
                    TKco = rowhd[8].ToString().Trim();

                    //LoaiChungTu
                    if (KiemTraTonTaiLoaiChungTu(rowhd[1].ToString().Trim()) == false)
                    {
                        //MessageBox.Show(string.Format("Loại chứng từ không hợp lệ của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //RefreshData();
                        //return;
                        GhiDanhSachChungTuKhongHopLe(this.strFilePath, string.Format("Loại chứng từ không hợp lệ của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()));
                        isImportThanhCong = false;
                    }
                    //TKNo, TK Co
                    if (TKno != "")
                    {
                        if (KiemTraTonTaiTKNo(rowhd[7].ToString().Trim()) == false)
                        {
                            //MessageBox.Show(string.Format("TK Nợ không hợp lệ của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //RefreshData();
                            //return;
                            GhiDanhSachChungTuKhongHopLe(this.strFilePath, string.Format("TK Nợ không hợp lệ của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()));
                            isImportThanhCong = false;
                        }
                    }

                    if (TKco != "")
                    {
                        if (KiemTraTonTaiTKCo(rowhd[8].ToString().Trim()) == false)
                        {
                            //MessageBox.Show(string.Format("TK Có không hợp lệ của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //RefreshData();
                            //return;
                            GhiDanhSachChungTuKhongHopLe(this.strFilePath, string.Format("TK Có không hợp lệ của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()));
                            isImportThanhCong = false;
                        }
                    }

                    //Doi Tuong No, Doi Tuong Co
                    //if (rowhd[18].ToString().Trim().Length != 0)
                    //{
                    //    if (KiemTraTonTaiMaDoiTuongNo(rowhd[18].ToString().Trim()) == false)
                    //    {
                    //        if (MessageBox.Show(string.Format("Mã Đối tượng Nợ không có trong danh mục Đối tượng của chứng từ {0}, số TT {1}, Bạn có muốn bỏ qua đối tượng này và tiếp tục!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    //        {
                    //            RefreshData();
                    //            //MessageBox.Show(string.Format("Mã Đối tượng Nợ không có trong danh mục Đối tượng của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //            return;
                    //        }
                    //    }

                    //}
                    //if (rowhd[19].ToString().Trim().Length != 0)
                    //{
                    //    if (KiemTraTonTaiMaDoiTuongCo(rowhd[19].ToString().Trim()) == false)
                    //    {
                    //        if (MessageBox.Show(string.Format("Mã Đối tượng Có không có trong danh mục Đối tượng của chứng từ {0}, số TT {1}, Bạn có muốn bỏ qua đối tượng này và tiếp tục!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    //        {
                    //            RefreshData();
                    //            //MessageBox.Show(string.Format("Mã Đối tượng Có không có trong danh mục Đối tượng của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //            return;
                    //        }
                    //    }
                    //}
                    ////TaiKhoanNganHangDi, TaiKhoanNganHangDen
                    //if (rowhd[20].ToString().Trim().Length != 0)
                    //{
                    //    if (KiemTraTonTaiTkNganHangCongtyDi(rowhd[20].ToString().Trim()) == false)
                    //    {
                    //        if (MessageBox.Show(string.Format("Tài khoản ngân hàng đi không có trong danh mục Tài khoản của chứng từ {0}, số TT {1}, Bạn có muốn bỏ qua đối tượng này và tiếp tục!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    //        {
                    //            RefreshData();
                    //            //MessageBox.Show(string.Format("Tài khoản ngân hàng đi không có trong danh mục Tài khoản của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //            return;
                    //        }
                    //    }
                    //}
                    //if (rowhd[21].ToString().Trim().Length != 0)
                    //{
                    //    if (KiemTraTonTaiTkNganHangCongtyDen(rowhd[21].ToString().Trim()) == false)
                    //    {
                    //        if (MessageBox.Show(string.Format("Tài khoản ngân hàng đến không có trong danh mục Tài khoản của chứng từ {0}, số TT {1}, Bạn có muốn bỏ qua đối tượng này và tiếp tục!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    //        {
                    //            RefreshData();
                    //            //MessageBox.Show(string.Format("Tài khoản ngân hàng đến không có trong danh mục Tài khoản của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //            return;
                    //        }
                    //    }
                    //}

                    //Ngay Chung Tu
                    DateTime ngayChungTu = DateTime.Today.Date;
                    DateTime ngaychungtuOut;
                    if (DateTime.TryParse(rowhd[3].ToString(), out ngaychungtuOut))
                    {
                        ngayChungTu = ngaychungtuOut;
                    }
                    else
                    {
                        //MessageBox.Show(string.Format("Ngày chứng từ không hợp lệ của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //RefreshData();
                        //return;
                        GhiDanhSachChungTuKhongHopLe(this.strFilePath, string.Format("Ngày chứng từ không hợp lệ của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()));
                        isImportThanhCong = false;
                    }
                    //NgayHoachToan
                    DateTime ngayHoachToan = DateTime.MinValue;
                    if (rowhd[4].ToString() != "")
                    {
                        DateTime ngayHoachToanOut;
                        if (DateTime.TryParse(rowhd[4].ToString(), out ngayHoachToanOut))
                        {
                            ngayHoachToan = ngayHoachToanOut;
                        }
                        else
                        {
                            //MessageBox.Show(string.Format("Ngày hoạch toán không hợp lệ của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //RefreshData();
                            //return;
                            GhiDanhSachChungTuKhongHopLe(this.strFilePath, string.Format("Ngày hoạch toán không hợp lệ của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()));
                            isImportThanhCong = false;
                        }
                    }
                    //NgayHoaDon
                    DateTime ngayhoadon = DateTime.MinValue;
                    if (rowhd[6].ToString() != "")
                    {
                        DateTime ngayhoadonOut;
                        if (DateTime.TryParse(rowhd[6].ToString(), out ngayhoadonOut))
                        {
                            ngayhoadon = ngayhoadonOut;
                        }
                        else
                        {
                            //MessageBox.Show(string.Format("Ngày hóa đơn không hợp lệ của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //RefreshData();
                            //return;
                            GhiDanhSachChungTuKhongHopLe(this.strFilePath, string.Format("Ngày hóa đơn không hợp lệ của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()));
                            isImportThanhCong = false;
                        }
                    }
                    
                    #region BatBuoc Nhap TKNo, TK Co
                    /*
                    //(7)TKNo	
                    if (rowhd[7].ToString() == "")
                    {
                        MessageBox.Show(string.Format("Vui lòng hoạch toán TK Nợ của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RefreshData();
                        return;
                    }
                    //(8)TKCo
                    if (rowhd[8].ToString() == "")
                    {
                        MessageBox.Show(string.Format("Vui lòng hoạch toán TK Có của chứng từ {0}, số TT {1}!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RefreshData();
                        return;
                    }
                     */
                    #endregion//BatBuoc Nhap TKNo, TK Co
                     
                    //So Tien
                    decimal soTien = 0;
                    decimal soTienOut;
                    if (decimal.TryParse(rowhd[10].ToString(), out soTienOut))
                    {
                        soTien = soTienOut;
                    }
                    else if (soTien == 0)
                    {
                        //MessageBox.Show(string.Format("Số tiền của chứng từ {0}, số TT {1} không hợp lệ!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //RefreshData();
                        //return;
                        GhiDanhSachChungTuKhongHopLe(this.strFilePath, string.Format("Số tiền của chứng từ {0}, số TT {1} không hợp lệ!", rowhd[2].ToString(), rowhd[0].ToString()));
                        isImportThanhCong = false;
                    }
                    //So Tien Quy Doi
                    decimal soTienQuyDoi = 0;
                    decimal soTienQuyDoiOut;
                    if (decimal.TryParse(rowhd[11].ToString(), out soTienQuyDoiOut))
                    {
                        soTienQuyDoi = soTienQuyDoiOut;
                    }
                    else if (soTienQuyDoi == 0)
                    {
                        //MessageBox.Show(string.Format("Số tiền quy đổi của chứng từ {0}, số TT {1} không hợp lệ!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //RefreshData();
                        //return;
                        GhiDanhSachChungTuKhongHopLe(this.strFilePath, string.Format("Số tiền quy đổi của chứng từ {0}, số TT {1} không hợp lệ!", rowhd[2].ToString(), rowhd[0].ToString()));
                        isImportThanhCong = false;
                    }
                    //(14)SoLuong
                    decimal soLuong = 0;
                    if (rowhd[14].ToString() != "")
                    {
                        decimal soLuongOut;
                        if (decimal.TryParse(rowhd[14].ToString(), out soLuongOut))
                        {
                            soLuong = soLuongOut;
                        }
                        else
                        {
                            //MessageBox.Show(string.Format("Số lượng của chứng từ {0}, số TT {1} không hợp lệ!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //RefreshData();
                            //return;
                            GhiDanhSachChungTuKhongHopLe(this.strFilePath, string.Format("Số lượng của chứng từ {0}, số TT {1} không hợp lệ!", rowhd[2].ToString(), rowhd[0].ToString()));
                            isImportThanhCong = false;
                        }
                    }
                    //(15)DonGia	
                    decimal dongia = 0;
                    if (rowhd[15].ToString() != "")
                    {
                        decimal dongiaOut;
                        if (decimal.TryParse(rowhd[15].ToString(), out dongiaOut))
                        {
                            dongia = dongiaOut;
                        }
                        else
                        {
                            //MessageBox.Show(string.Format("Đơn giá của chứng từ {0}, số TT {1} không hợp lệ!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //RefreshData();
                            //return;
                            GhiDanhSachChungTuKhongHopLe(this.strFilePath, string.Format("Đơn giá của chứng từ {0}, số TT {1} không hợp lệ!", rowhd[2].ToString(), rowhd[0].ToString()));
                            isImportThanhCong = false;
                        }
                    }
                    //(16)TyLeCK	
                    decimal tyLeCK = 0;
                    if (rowhd[16].ToString() != "")
                    {
                        decimal tyLeCKOut;
                        if (decimal.TryParse(rowhd[16].ToString(), out tyLeCKOut))
                        {
                            tyLeCK = tyLeCKOut;
                        }
                        else
                        {
                            //MessageBox.Show(string.Format("Tỷ lệ CK của chứng từ {0}, số TT {1} không hợp lệ!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //RefreshData();
                            //return;
                            GhiDanhSachChungTuKhongHopLe(this.strFilePath, string.Format("Tỷ lệ CK của chứng từ {0}, số TT {1} không hợp lệ!", rowhd[2].ToString(), rowhd[0].ToString()));
                            isImportThanhCong = false;
                        }
                    }
                    //(17)TienCK
                    decimal tienCK = 0;
                    if (rowhd[17].ToString() != "")
                    {
                        decimal tienCKOut;
                        if (decimal.TryParse(rowhd[17].ToString(), out tienCKOut))
                        {
                            tienCK = tienCKOut;
                        }
                        else
                        {
                            //MessageBox.Show(string.Format("Tiền CK của chứng từ {0}, số TT {1} không hợp lệ!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //RefreshData();
                            //return;
                            GhiDanhSachChungTuKhongHopLe(this.strFilePath, string.Format("Tiền CK của chứng từ {0}, số TT {1} không hợp lệ!", rowhd[2].ToString(), rowhd[0].ToString()));
                            isImportThanhCong = false;
                        }
                    }

                    //Doi tuong no
                    if (rowhd[19].ToString().Trim().Length != 0)
                    {
                        if (KiemTraTonTaiMaDoiTuongNo(rowhd[19].ToString().Trim()) == false)
                        {
                            //if (MessageBox.Show(string.Format("Mã Đối tượng Nợ không có trong danh mục Đối tượng của chứng từ {0}, số TT {1}, Bạn có muốn bỏ qua đối tượng này và tiếp tục!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            //{
                            GhiDanhSachChungTuKhongHopLe(this.strFilePath, string.Format("Mã Đối tượng Nợ {0} không có trong danh mục Đối tượng của chứng từ {1}, số TT {2}!", rowhd[19].ToString(), rowhd[2].ToString(), rowhd[0].ToString()));
                                isImportThanhCong = false;
                            //}
                        }
                    }

                    //Doi tuong co
                    if (rowhd[20].ToString().Trim().Length != 0)
                    {
                        if (KiemTraTonTaiMaDoiTuongNo(rowhd[20].ToString().Trim()) == false)
                        {
                            //if (MessageBox.Show(string.Format("Mã Đối tượng Nợ không có trong danh mục Đối tượng của chứng từ {0}, số TT {1}, Bạn có muốn bỏ qua đối tượng này và tiếp tục!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            //{
                            GhiDanhSachChungTuKhongHopLe(this.strFilePath, string.Format("Mã Đối tượng Có {0} không có trong danh mục Đối tượng của chứng từ {1}, số TT {2}!", rowhd[20].ToString(), rowhd[2].ToString(), rowhd[0].ToString()));
                            isImportThanhCong = false;
                            //}
                        }
                    }

                    //(36)thueSuat
                    decimal thueSuat = 0;
                    if (rowhd[36].ToString() != "")
                    {
                        decimal thueSuatOut;
                        if (decimal.TryParse(rowhd[36].ToString(), out thueSuatOut))
                        {
                            thueSuat = thueSuatOut;
                        }
                        else
                        {
                            //MessageBox.Show(string.Format("Tiền CK của chứng từ {0}, số TT {1} không hợp lệ!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //RefreshData();
                            //return;
                            GhiDanhSachChungTuKhongHopLe(this.strFilePath, string.Format("Thuế suất VAT của chứng từ {0}, số TT {1} không hợp lệ!", rowhd[2].ToString(), rowhd[0].ToString()));
                            isImportThanhCong = false;
                        }
                    }

                    //(37)tienThue
                    decimal tienThue = 0;
                    if (rowhd[37].ToString() != "")
                    {
                        decimal tienThueOut;
                        if (decimal.TryParse(rowhd[37].ToString(), out tienThueOut))
                        {
                            tienThue = tienThueOut;
                        }
                        else
                        {
                            //MessageBox.Show(string.Format("Tiền CK của chứng từ {0}, số TT {1} không hợp lệ!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //RefreshData();
                            //return;
                            GhiDanhSachChungTuKhongHopLe(this.strFilePath, string.Format("Tiền thuế của chứng từ {0}, số TT {1} không hợp lệ!", rowhd[2].ToString(), rowhd[0].ToString()));
                            isImportThanhCong = false;
                        }
                    }

                    //
                    ChungTuImportFromExcel chungtuImportNew = ChungTuImportFromExcel.NewChungTuImportFromExcel();
                    chungtuImportNew.STT = sTT;
                    chungtuImportNew.LoaiChungTu = rowhd[1].ToString();
                    chungtuImportNew.SoChungTu = rowhd[2].ToString();
                    chungtuImportNew.NgayChungTu = ngayChungTu;
                    chungtuImportNew.NgayHachToan = ngayHoachToan;
                    chungtuImportNew.SoHoaDon = rowhd[5].ToString();
                    chungtuImportNew.NgayHoaDon = ngayhoadon;
                    chungtuImportNew.TKNo = rowhd[7].ToString();
                    chungtuImportNew.TKCo = rowhd[8].ToString();
                    chungtuImportNew.LoaiTien = rowhd[9].ToString();
                    chungtuImportNew.SoTien = soTien;
                    chungtuImportNew.QuyDoiSoTien = soTienQuyDoi;
                    chungtuImportNew.MaVTHH = rowhd[12].ToString();
                    chungtuImportNew.TenVTHH = rowhd[13].ToString();
                    chungtuImportNew.SoLuong = soLuong;
                    chungtuImportNew.DonGia = dongia;
                    chungtuImportNew.TyLeCK = tyLeCK;
                    chungtuImportNew.TienCK = tienCK;
                    chungtuImportNew.MaDoiTuongChung = rowhd[18].ToString();
                    chungtuImportNew.MaDoiTuongNo = rowhd[19].ToString();

                    chungtuImportNew.MaDoiTuongCo = rowhd[20].ToString();
                    chungtuImportNew.TaiKhoanNganHang = rowhd[21].ToString();
                    chungtuImportNew.TaiKhoanNganHangDen = rowhd[22].ToString();
                    chungtuImportNew.KhoanMucChiPhi = rowhd[23].ToString();
                    chungtuImportNew.DTTapHopCP = rowhd[24].ToString();
                    chungtuImportNew.MaThongKe = rowhd[25].ToString();
                    chungtuImportNew.DienGiaiChung = rowhd[26].ToString();
                    chungtuImportNew.DienGiaiChiTiet = rowhd[27].ToString();
                    chungtuImportNew.TinhTrangGhiSo = rowhd[28].ToString();
                    chungtuImportNew.TenDTChung = rowhd[29].ToString();
                    chungtuImportNew.TenDTCo = rowhd[30].ToString();
                    chungtuImportNew.TenDTNo = rowhd[31].ToString();
                    chungtuImportNew.MaKho = rowhd[32].ToString();
                    chungtuImportNew.MaDonVi = rowhd[33].ToString();
                    chungtuImportNew.SoHopDong = rowhd[34].ToString();
                    chungtuImportNew.SoSeri = rowhd[35].ToString();
                    chungtuImportNew.ThueSuat = thueSuat;
                    chungtuImportNew.TienThue = tienThue;
                    chungtuImportNew.SoPhieuNhapXuatThamChieu = rowhd[38].ToString();
                    chungtuImportNew.TenNhanVienNhapXuat = rowhd[39].ToString();
                    chungtuImportNew.FileImportName = _FileNameImport;


                    _ChungTuImportFromExcelList.Add(chungtuImportNew);
                    //
                }

                if (isImportThanhCong == false && strFilePath!="")
                {                    
                    RefreshData();
                    Process.Start(strFilePath);
                    return;
                }

                ChungTuImportFromExcelList_bindingSource.DataSource = _ChungTuImportFromExcelList;
                if (_ChungTuImportFromExcelList.Count > 0)
                {
                    btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }

            }
            #endregion

            #endregion//New

        }

        #region ghi cac chung tu khong hop le
        string strFilePath = "";
        private void GhiDanhSachChungTuKhongHopLe(string filepath, string info)
        {
            if (filepath == "")
            {
                MessageBox.Show("Chọn nơi lưu file chứa các chứng từ chưa hợp lệ !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.AddExtension = true;
                dlg.Filter = "Text File|*.txt";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //tạo file template
                    FileStream fsa = new FileStream(dlg.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    fsa.Close();
                }
                this.strFilePath = dlg.FileName;
                //String filepath = "E:\\test.txt";// đường dẫn của file muốn tạo

                FileStream fs = new FileStream(strFilePath, FileMode.Create);//Tạo file mới tên là test.txt)//fs là 1 FileStream 

                StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);
                sWriter.WriteLine(info);
                //Ghi và đóng file
                sWriter.Flush();

                fs.Close();
            }
            else
            {
                System.IO.StreamWriter str = System.IO.File.AppendText(filepath);
                str.WriteLine(info);
                str.Close();
            }
        }
        #endregion

        private void ImportToChiTietNhapXuatFromDataSet(DataSet dsresult)
        {
            #region New
            if (dsresult.Tables.Count == 0) return;
            DataTable tblCTNX = new DataTable();
            tblCTNX = dsresult.Tables["ChiTietNhapXuat"];

            #region Chi Tiet Nhap Xuat
            if (tblCTNX.Rows.Count > 0)
            {
                foreach (DataRow rowhd in tblCTNX.Rows)
                {
                    if (rowhd[1].ToString().Trim().Length == 0 && rowhd[2].ToString().Trim().Length == 0)//LoaiHoaDon và SoChungTu = rong
                    {
                        return;
                    }
                    //STT
                    int sTT1 = 0;
                    int sTTOut1;
                    if (int.TryParse(rowhd[0].ToString(), out sTTOut1))
                    {
                        sTT1 = sTTOut1;
                    }

                    if (rowhd[3].ToString().Trim().Length == 0)
                    {
                        MessageBox.Show(string.Format("Vui lòng nhập tên VTHH của chứng từ {0}, số TT {1}!", rowhd[1].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RefreshData();
                        return;
                    }
                    if (rowhd[6].ToString().Trim().Length == 0)
                    {
                        MessageBox.Show(string.Format("Vui lòng nhập Thành tiền của chứng từ {0}, số TT {1}!", rowhd[1].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RefreshData();
                        return;
                    }
                    //SoLuong
                    decimal soluong = 0;
                    decimal soluongOut;
                    if (decimal.TryParse(rowhd[4].ToString(), out soluongOut))
                    {
                        soluong = soluongOut;
                    }
                    //Don Gia
                    decimal dongia = 0;
                    decimal dongiaOut;
                    if (decimal.TryParse(rowhd[5].ToString(), out dongiaOut))
                    {
                        dongia = dongiaOut;
                    }
                    //ThanhTien
                    decimal thanhtien = 0;
                    decimal thanhtienOut;
                    if (decimal.TryParse(rowhd[6].ToString(), out thanhtienOut))
                    {
                        thanhtien = thanhtienOut;
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Thành tiền của chứng từ {0}, số TT {1} không hợp lệ!", rowhd[1].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RefreshData();
                        return;
                    }
                    //
                    //STT(0)	Số Chứng Từ (*)(1)	Mã VTHH (*)(2)	Tên VTHH (*)(3)	Số Lượng(4)	Đơn Giá(5)	Thành Tiền (*)(6)	Ghi chú(7)
                    CTNhapXuatImportFromExcel ctnxImportNew = CTNhapXuatImportFromExcel.NewCTNhapXuatImportFromExcel();
                    ctnxImportNew.Stt = sTT1;
                    ctnxImportNew.SoChungTu = rowhd[1].ToString();
                    ctnxImportNew.MaVTHH = rowhd[2].ToString();
                    ctnxImportNew.TenVTHH = rowhd[3].ToString();
                    ctnxImportNew.SoLuong = soluong;
                    ctnxImportNew.DonGia = dongia;
                    ctnxImportNew.ThanhTien = thanhtien;
                    ctnxImportNew.GhiChu = rowhd[7].ToString();
                    ctnxImportNew.FileImportName = _FileNameImport;
                    _ctNhapXuatImportFromExcelList.Add(ctnxImportNew);
                }
                CTNhapXuatImportFromExcelListbindingSource.DataSource = _ctNhapXuatImportFromExcelList;
                if (_ctNhapXuatImportFromExcelList.Count > 0)
                {
                    btnLuuCTNhapXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
            }
            #endregion Chi Tiet Nhap Xuat


            #endregion//New

        }

        #endregion//Import From Excel

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }

        private bool KiemTraTonTaiLoaiChungTu(string LoaiChungTu)
        {
            foreach (LoaiChungTuDev item in _LoaiChungTuList)
            {
                if (item.TenLoaiCT.ToLower() == LoaiChungTu.ToLower())
                    return true;
            }
            return false;
        }

        private bool KiemTraTonTaiTKNo(string TKno)
        {
            foreach (HeThongTaiKhoan1 item in _hethongtaikhoanList)
            {
                if (item.SoHieuTK == TKno.Replace(" ", ""))
                    return true;
            }
            return false;
        }
        private bool KiemTraTonTaiTKCo(string TKco)
        {
            foreach (HeThongTaiKhoan1 item in _hethongtaikhoanList)
            {
                if (item.SoHieuTK == TKco.Replace(" ", ""))
                    return true;
            }
            return false;
        }
        private bool KiemTraTonTaiMaDoiTuongNo(string madtNo)
        {
            foreach (DoiTuongAll item in _DoiTuongList)
            {
                if (item.MaQLDoiTuong.ToUpper() == madtNo.ToUpper())
                    return true;
            }
            return false;
        }
        private bool KiemTraTonTaiMaDoiTuongCo(string madtCo)
        {
            foreach (DoiTuongAll item in _DoiTuongList)
            {
                if (item.MaQLDoiTuong.ToUpper() == madtCo.ToUpper())
                    return true;
            }
            return false;
        }

        private bool KiemTraTonTaiTkNganHangCongtyDi(string sotkDi)
        {
            foreach (ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild item in _TKNganHangCtyList)
            {
                if (item.SoTaiKhoan.ToUpper() == sotkDi.ToUpper())
                    return true;
            }
            return false;
        }

        private bool KiemTraTonTaiTkNganHangCongtyDen(string sotkDen)
        {
            foreach (ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild item in _TKNganHangCtyList)
            {
                if (item.SoTaiKhoan.ToUpper() == sotkDen.ToUpper())
                    return true;
            }
            return false;
        }

        private void RefreshData()
        {
            _ChungTuImportFromExcelList = ChungTuImportFromExcelList.NewChungTuImportFromExcelList();
            ChungTuImportFromExcelList_bindingSource.DataSource = _ChungTuImportFromExcelList;
            _ctNhapXuatImportFromExcelList = CTNhapXuatImportFromExcelList.NewCTNhapXuatImportFromExcelList();
            CTNhapXuatImportFromExcelListbindingSource.DataSource = _ctNhapXuatImportFromExcelList;
        }

        #endregion

        #region Event
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btn_XuatRaExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //HamDungChung.ExportToExcelFromGridViewDev(gridView1);
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gridView1.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {               
                ChungTuImportFromExcelList_bindingSource.EndEdit();
                _ChungTuImportFromExcelList.ApplyEdit();
                _ChungTuImportFromExcelList.Save();
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                MessageBox.Show("Lưu Chứng Từ Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadChungTuCustomizelist();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật Chứng từ thất bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ///////////

        }

        private void btnLuuCTNhapXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                CTNhapXuatImportFromExcelListbindingSource.EndEdit();
                _ctNhapXuatImportFromExcelList.ApplyEdit();
                _ctNhapXuatImportFromExcelList.Save();
                btnLuuCTNhapXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                MessageBox.Show("Lưu Chi Tiết Nhập Xuất Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Cập nhật Chi Tiết Nhập Xuất thất bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
            LoadChungTuCustomizelist();
        }

        private void btnImportdata_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.strFilePath = "";
                _FileNameImport = "";
                //isimportfromExcel = true;
                #region Old
                OpenFileDialog oFD = new OpenFileDialog();
                oFD.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
                oFD.ShowDialog();
                string path = oFD.FileName;
                string p = System.IO.Path.GetFileName(path);
                _FileNameImport = p;
                //DataTable tblResult = ImportExcelXLS(path, true);
                //ImportToTable(tblResult);
                DataSet dsRerult = ImportExcelXLSToDataset(path, true);
                ImportToChungTuFromDataSet(dsRerult);
                ImportToChiTietNhapXuatFromDataSet(dsRerult);
                BindingData();
                if (_ChungTuImportFromExcelList.Count > 0)
                {
                    btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                if (_ChungTuImportFromExcelList.Count > 0)
                {
                    btnLuuCTNhapXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                #endregion//Old

                //isimportfromExcel = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Không thể đọc file! " + ex.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExportMauNhapLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //HamDungChung.ExportToExcel(grdu_DSHoaDon);
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.Filter = "Excel|*.xls|All file|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //tạo file template
                FileStream fs = new FileStream(dlg.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                fs.Write(Properties.Resources.ImportChungTu_Template, 0, Properties.Resources.ImportChungTu_Template.Length);
                fs.Close();




                MessageBox.Show("Đã xuất dữ liệu thành công", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(dlg.FileName);
            }
        }

        private void btnImportNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshData();
        }

        #endregion

        #region eventHandles
        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteObject();
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }

        }

        private void GrdView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() != null)
            {

            }
        }

        private void gridView6_DoubleClick(object sender, EventArgs e)
        {
            if (gridView6.GetFocusedRow() != null)
            {
                ChungTuCustomize chungtuCus = gridView6.GetFocusedRow() as ChungTuCustomize;
                if (chungtuCus.MaLoaiChungTuQL == "PT111")//--ThuTienMat
                {
                    FrmChungTuThuTienMat f = new FrmChungTuThuTienMat(chungtuCus);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        LoadChungTuCustomizelist();
                    }
                }
                else if (chungtuCus.MaLoaiChungTuQL == "PC111")//--ChiTienMat
                {
                    FrmChungTuChiTienMat f = new FrmChungTuChiTienMat(chungtuCus);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        LoadChungTuCustomizelist();
                    }
                }
                else if (chungtuCus.MaLoaiChungTuQL == "PT112")//--ThuTienGui
                {
                    FrmChungTuThuTienGui f = new FrmChungTuThuTienGui(chungtuCus);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        LoadChungTuCustomizelist();
                    }
                }
                else if (chungtuCus.MaLoaiChungTuQL == "PC112")//--ChiTienGui
                {
                    FrmChungTuChiTienGui f = new FrmChungTuChiTienGui(chungtuCus);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        LoadChungTuCustomizelist();
                    }
                }
                else if (chungtuCus.MaLoaiChungTuQL == "CTNB")//--ChuyenTienNoiBo
                {
                    FrmChungTuChuyenTienNoiBo f = new FrmChungTuChuyenTienNoiBo(chungtuCus);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        LoadChungTuCustomizelist();
                    }
                }
                else if (chungtuCus.MaLoaiChungTuQL == "GNN")//--GiayNhanNo
                {
                    FrmChungTuGiayNhanNo f = new FrmChungTuGiayNhanNo(chungtuCus);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        LoadChungTuCustomizelist();
                    }
                }
                else if (chungtuCus.MaLoaiChungTuQL == "MuaChuaThanhToan")//--ChungTu Mua Chua Thanh Toan
                {
                    FrmChungTuMuaChuaThanhToan f = new FrmChungTuMuaChuaThanhToan(chungtuCus);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        LoadChungTuCustomizelist();
                    }
                }
                else if (chungtuCus.MaLoaiChungTuQL == "PKT")//--ChungTu KeToan
                {
                    FrmChungTuKeToanCustomize f = new FrmChungTuKeToanCustomize(chungtuCus);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        LoadChungTuCustomizelist();
                    }
                }

            }
        }
        #endregion eventHandles




    }
}