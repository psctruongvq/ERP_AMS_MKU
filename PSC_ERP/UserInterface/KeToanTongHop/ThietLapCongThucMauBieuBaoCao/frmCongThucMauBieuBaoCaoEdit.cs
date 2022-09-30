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
using DevExpress.XtraGrid.Views.Grid;

namespace PSC_ERP
{
    public partial class frmCongThucMauBieuBaoCaoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        CongThucMauBieuBaoCao _CongThucMauBieuBC = CongThucMauBieuBaoCao.NewCongThucMauBieuBaoCao();
        int _MaCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        int _userID = ERP_Library.Security.CurrentUser.Info.UserID;
        //--
        private CongThucMauBieuBaoCaoList _congThucMauBieuBCParentList = CongThucMauBieuBaoCaoList.NewCongThucMauBieuBaoCaoList();

        private byte _loaiMauBaoCao = 0;
        private int _maThongTu = 0;

        BindingSource heThongTaiKhoanList_bindingSource = new BindingSource();
        BindingSource heThongTaiKhoanDoiUngList_bindingSource = new BindingSource();
        BindingSource mucLienQuanForCTCongThucMuaBieuBC_bindingSource = new BindingSource();
        BindingSource HoatDongList_bindingSource1 = new BindingSource();
        BindingSource CauTrucDoanhThuChiPhiList_bindingSource1 = new BindingSource();

        BindingSource nguonKinhPhiListBindingSource = new BindingSource();
        BindingSource chuongListBindingSource = new BindingSource();
        BindingSource loaiKhoanListBindingSource = new BindingSource();
        BindingSource tieuMucNganSachListBindingSource = new BindingSource();
        List<CongTruNhanChia> _CongTruNhanChialist;
        List<PhuongThucLaySo> _PhuongThucLaySoList;
        List<NoorCo> _noCoList;
        List<LoaiMucCongThuc> _loaiMucCongThucList;
        #endregion

        #region Constructors
        public frmCongThucMauBieuBaoCaoEdit(byte loaiMauBC, int maThongTu)
        {
            InitializeComponent();
            _loaiMauBaoCao = loaiMauBC;
            _maThongTu = maThongTu;
            KhoiTao();
            KhoiTaoCongThucMauBieuBaoCao();
        }
        public frmCongThucMauBieuBaoCaoEdit(CongThucMauBieuBaoCao congthuc, byte loaiMauBC, int maThongTu)
        {
            InitializeComponent();
            _loaiMauBaoCao = loaiMauBC;
            _maThongTu = maThongTu;
            KhoiTao();
            KhoiTaoCongThucMauBieuBaoCao(congthuc);
        }

        public frmCongThucMauBieuBaoCaoEdit(CongThucMauBieuBaoCao congthuc, byte loaiMauBC, int maThongTu, bool isAddChild)
        {
            InitializeComponent();
            _loaiMauBaoCao = loaiMauBC;
            _maThongTu = maThongTu;
            KhoiTao();
            if (isAddChild)
                KhoiTaoCongThucMauBieuBaoCao_MucCon(congthuc);
            else KhoiTaoCongThucMauBieuBaoCao(congthuc);
        }
        #endregion Constructors

        #region Function


        private void DesignMucLienQuangridLookUpEdit()
        {
            HamDungChung.InitGridLookUpDev2(MucLienQuangridLookUpEdit, MucLienQuanList_bindingSource, "TenMuc", "MaMuc", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(MucLienQuangridLookUpEdit, new string[] { "TenMuc", "MaSo" }, new string[] { "Mục", "Mã số" }, new int[] { 300, 100 }, false);
        }

        private void DesignlueLoaiMuc()
        {
            HamDungChung.InitGridLookUpDev2(lueLoaiMuc, _loaiMucCongThucList, "Ten", "Ma", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(lueLoaiMuc, new string[] { "Ten" }, new string[] { "Loại mục" }, new int[] { 300 }, false);
            //lueLoaiMuc.EditValueChanged += new System.EventHandler(this.lueLoaiMuc_EditValueChanged);
        }


        private void DesignCTCongThucMauBieuBCgridView()
        {
            #region MyRegion 2
            CTCongThucMauBieuBCgridControl.DataSource = CT_CongThucMauBieuBaoCaobindingSource;
            HamDungChung.InitGridViewDev(CTCongThucMauBieuBCgridView, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, true, false, true);
            HamDungChung.ShowFieldGridViewDev2(CTCongThucMauBieuBCgridView, new string[] { "MaTaiKhoan", "MaMucLienQuan", "CongTru", "MaTaiKhoanDoiUng", "MaHoatDong", "Loai", "NoCo","GiaTriMacDinh", "TTCot" },
                                new string[] { "Tài khoản", "Mục liên quan", "Cộng/trừ", "TK đối ứng", "Thuộc hoạt động", "Loại", "Nợ/Có", "Giá trị mặc định", "Thứ tự cột" },
                                             new int[] { 90, 150, 80, 90, 100, 75, 75,90, 90}, true);
            HamDungChung.AlignHeaderColumnGridViewDev(CTCongThucMauBieuBCgridView, new string[] { "MaTaiKhoan", "MaMucLienQuan", "CongTru", "MaTaiKhoanDoiUng", "MaHoatDong", "Loai", "NoCo", "GiaTriMacDinh", "TTCot" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(CTCongThucMauBieuBCgridView, new string[] { "GiaTriMacDinh" }, "#,###.##");
            //HamDungChung.ShowSummaryFooterofColumnGridViewDev2(CTCongThucMauBieuBCgridView, new string[] { "SoTien" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(CTCongThucMauBieuBCgridView);

            Utils.GridUtils.SetSTTForGridView(CTCongThucMauBieuBCgridView, 30);//M

            //TaiKhoan
            RepositoryItemGridLookUpEdit TaiKhoan_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(TaiKhoan_GrdLU, heThongTaiKhoanList_bindingSource, "SoHieuTK", "MaTaiKhoan", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TaiKhoan_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu", "Tên tài khoản" }, new int[] { 100, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(CTCongThucMauBieuBCgridView, "MaTaiKhoan", TaiKhoan_GrdLU);
            //MaMucLienQuan
            RepositoryItemGridLookUpEdit MucLienQuan_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(MucLienQuan_GrdLU, mucLienQuanForCTCongThucMuaBieuBC_bindingSource, "TenMuc", "MaMuc", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(MucLienQuan_GrdLU, new string[] { "TenMuc", "MaSo" }, new string[] { "Mục", "Mã số" }, new int[] { 300, 100 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(CTCongThucMauBieuBCgridView, "MaMucLienQuan", MucLienQuan_GrdLU);
            //TaiKhoanDoiUng
            RepositoryItemGridLookUpEdit TaiKhoanDU_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(TaiKhoanDU_GrdLU, heThongTaiKhoanDoiUngList_bindingSource, "SoHieuTK", "MaTaiKhoan", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TaiKhoanDU_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu", "Tên tài khoản" }, new int[] { 100, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(CTCongThucMauBieuBCgridView, "MaTaiKhoanDoiUng", TaiKhoanDU_GrdLU);
            //

            //CongTru
            RepositoryItemGridLookUpEdit CongTruNhanChia_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(CongTruNhanChia_GrdLU, _CongTruNhanChialist, "Ten", "Ma", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(CongTruNhanChia_GrdLU, new string[] { "Ten" }, new string[] { "" }, new int[] { 300 }, true);
            HamDungChung.RegisterControlFieldGridViewDev(CTCongThucMauBieuBCgridView, "CongTru", CongTruNhanChia_GrdLU);
            //
            //Loai
            RepositoryItemGridLookUpEdit PhuongThucLaySo_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(PhuongThucLaySo_GrdLU, _PhuongThucLaySoList, "Ten", "Ma", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(PhuongThucLaySo_GrdLU, new string[] { "Ten" }, new string[] { "" }, new int[] { 300 }, true);
            HamDungChung.RegisterControlFieldGridViewDev(CTCongThucMauBieuBCgridView, "Loai", PhuongThucLaySo_GrdLU);
            //HoatDong
            RepositoryItemGridLookUpEdit HoatDong_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(HoatDong_GrdLU, HoatDongList_bindingSource1, "TenHoatDong", "MaHoatDong", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(HoatDong_GrdLU, new string[] { "TenHoatDong", "MaQLHoatDong" }, new string[] { "Hoạt động", "Mã QL" }, new int[] { 120, 100 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(CTCongThucMauBieuBCgridView, "MaHoatDong", HoatDong_GrdLU);

            //NoCo
            RepositoryItemGridLookUpEdit NoorCo_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(NoorCo_GrdLU, _noCoList, "Ten", "Ma", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(NoorCo_GrdLU, new string[] { "Ten" }, new string[] { "" }, new int[] { 300 }, true);
            HamDungChung.RegisterControlFieldGridViewDev(CTCongThucMauBieuBCgridView, "NoCo", NoorCo_GrdLU);

            //"MaTaiKhoan", "MaMucLienQuan", "CongTru", "MaTaiKhoanDoiUng", "MaHoatDong", "Loai", "NoCo", "LoaiHoatDong", "MaNguon", "MaLoaiKhoan", "MaTieuMuc"
            //LoaiHoatDong
            RepositoryItemGridLookUpEdit KhoanMuc_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(KhoanMuc_GrdLU, _noCoList, "Ten", "Id", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(KhoanMuc_GrdLU, new string[] { "Ten", "MaQL" }, new string[] { "Khoản mục", "Mã QL" }, new int[] { 120, 100 }, true);
            HamDungChung.RegisterControlFieldGridViewDev(CTCongThucMauBieuBCgridView, "LoaiHoatDong", KhoanMuc_GrdLU);
            //NguonKinhPhi
            RepositoryItemGridLookUpEdit NguonKinhPhi_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(NguonKinhPhi_GrdLU, nguonKinhPhiListBindingSource, "TenNguonKinhPhi", "MaNguonKinhPhi", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(NguonKinhPhi_GrdLU, new string[] { "MaNguonKinhPhiQuanLy", "TenNguonKinhPhi" }, new string[] { "Mã nguồn KP", "Tên nguồn KP " }, new int[] { 100, 300 }, true);
            HamDungChung.RegisterControlFieldGridViewDev(CTCongThucMauBieuBCgridView, "MaNguon", NguonKinhPhi_GrdLU);
            //TieuMucNganSach
            RepositoryItemGridLookUpEdit TieuMucNganSach_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(TieuMucNganSach_GrdLU, tieuMucNganSachListBindingSource, "MaQuanLy", "MaTieuMuc", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TieuMucNganSach_GrdLU, new string[] { "MaQuanLy", "TenTieuMuc" }, new string[] { "Mã", "Tên" }, new int[] { 100, 300 }, true);
            HamDungChung.RegisterControlFieldGridViewDev(CTCongThucMauBieuBCgridView, "MaTieuMuc", TieuMucNganSach_GrdLU);
            //loại khoản
            RepositoryItemGridLookUpEdit loaiKhoan_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(loaiKhoan_GrdLU, loaiKhoanListBindingSource, "MaLoaiKhoanQuanLy", "MaLoaiKhoan", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(loaiKhoan_GrdLU, new string[] { "MaLoaiKhoanQuanLy", "TenLoaiKhoan" }, new string[] { "Mã", "Tên khoản" }, new int[] { 300, 100 }, true);
            HamDungChung.RegisterControlFieldGridViewDev(CTCongThucMauBieuBCgridView, "MaLoaiKhoan", loaiKhoan_GrdLU);



            ////this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            //this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.CTCongThucMauBieuBCgridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CTCongThucMauBieuBCgridView_KeyDown);
            this.CTCongThucMauBieuBCgridView.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.CTCongThucMauBieuBCgridView_InitNewRow);
            //this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);

            //this.gridView1.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gridView1_FocusedColumnChanged);

            //this.gridControl1.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl1_ProcessGridKey); 
            CTCongThucMauBieuBCgridView.GroupPanelText = "Thiết Lập Công Thức Lấy Số"; 
            #endregion
            #region MyRegion
            //CTCongThucMauBieuBCgridControl.DataSource = CT_CongThucMauBieuBaoCaobindingSource;
            //HamDungChung.InitGridViewDev(CTCongThucMauBieuBCgridView, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, true, false, true);
            //HamDungChung.ShowFieldGridViewDev(CTCongThucMauBieuBCgridView, new string[] { "MaTaiKhoan", "MaMucLienQuan", "CongTru", "MaTaiKhoanDoiUng", "MaHoatDong", "Loai", "NoCo", "TTCot", "LoaiHoatDong", "MaNguon", "MaLoaiKhoan", "MaTieuMuc" },
            //                    new string[] { "Tài khoản", "Mục liên quan", "Cộng/trừ", "TK đối ứng", "Thuộc hoạt động", "Loại", "Nợ/Có", "Thứ tự cột", "Thuộc khoản mục", "Nguồn", "Mã ngành KT", "Nội dung KT" },
            //                                 new int[] { 90, 150, 80, 90, 100, 75, 75, 90, 90, 90, 90, 90 });


            //HamDungChung.AlignHeaderColumnGridViewDev(CTCongThucMauBieuBCgridView, new string[] { "MaTaiKhoan", "MaMucLienQuan", "CongTru", "MaTaiKhoanDoiUng", "MaHoatDong", "Loai", "NoCo", "TTCot", "LoaiHoatDong", "MaNguon", "MaLoaiKhoan", "MaTieuMuc" }, DevExpress.Utils.HorzAlignment.Center);

            //HamDungChung.NewRowGridViewDev(CTCongThucMauBieuBCgridView, NewItemRowPosition.Bottom);

            //Utils.GridUtils.SetSTTForGridView(CTCongThucMauBieuBCgridView, 50);//M
            ////TaiKhoan
            //RepositoryItemGridLookUpEdit TaiKhoan_GrdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(TaiKhoan_GrdLU, heThongTaiKhoanList_bindingSource, "SoHieuTK", "MaTaiKhoan", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TaiKhoan_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu", "Tên tài khoản" }, new int[] { 100, 150 }, false);
            //HamDungChung.RegisterControlFieldGridViewDev(CTCongThucMauBieuBCgridView, "MaTaiKhoan", TaiKhoan_GrdLU);
            ////MaMucLienQuan
            //RepositoryItemGridLookUpEdit MucLienQuan_GrdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(MucLienQuan_GrdLU, mucLienQuanForCTCongThucMuaBieuBC_bindingSource, "TenMuc", "MaMuc", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(MucLienQuan_GrdLU, new string[] { "TenMuc", "MaSo" }, new string[] { "Mục", "Mã số" }, new int[] { 300, 100 }, false);
            //HamDungChung.RegisterControlFieldGridViewDev(CTCongThucMauBieuBCgridView, "MaMucLienQuan", MucLienQuan_GrdLU);
            ////TaiKhoanDoiUng
            //RepositoryItemGridLookUpEdit TaiKhoanDU_GrdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(TaiKhoanDU_GrdLU, heThongTaiKhoanDoiUngList_bindingSource, "SoHieuTK", "MaTaiKhoan", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TaiKhoanDU_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu", "Tên tài khoản" }, new int[] { 100, 150 }, false);
            //HamDungChung.RegisterControlFieldGridViewDev(CTCongThucMauBieuBCgridView, "MaTaiKhoanDoiUng", TaiKhoanDU_GrdLU);
            ////

            ////CongTru
            //RepositoryItemGridLookUpEdit CongTruNhanChia_GrdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(CongTruNhanChia_GrdLU, _CongTruNhanChialist, "Ten", "Ma", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(CongTruNhanChia_GrdLU, new string[] { "Ten" }, new string[] { "" }, new int[] { 300 }, true);
            //HamDungChung.RegisterControlFieldGridViewDev(CTCongThucMauBieuBCgridView, "CongTru", CongTruNhanChia_GrdLU);
            ////
            ////Loai
            //RepositoryItemGridLookUpEdit PhuongThucLaySo_GrdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(PhuongThucLaySo_GrdLU, _PhuongThucLaySoList, "Ten", "Ma", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(PhuongThucLaySo_GrdLU, new string[] { "Ten" }, new string[] { "" }, new int[] { 300 }, true);
            //HamDungChung.RegisterControlFieldGridViewDev(CTCongThucMauBieuBCgridView, "Loai", PhuongThucLaySo_GrdLU);
            ////HoatDong
            //RepositoryItemGridLookUpEdit HoatDong_GrdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(HoatDong_GrdLU, HoatDongList_bindingSource1, "TenHoatDong", "MaHoatDong", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(HoatDong_GrdLU, new string[] { "TenHoatDong", "MaQLHoatDong" }, new string[] { "Hoạt động", "Mã QL" }, new int[] { 120, 100 }, false);
            //HamDungChung.RegisterControlFieldGridViewDev(CTCongThucMauBieuBCgridView, "MaHoatDong", HoatDong_GrdLU);

            ////NoCo
            //RepositoryItemGridLookUpEdit NoorCo_GrdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(NoorCo_GrdLU, _noCoList, "Ten", "Ma", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(NoorCo_GrdLU, new string[] { "Ten" }, new string[] { "" }, new int[] { 300 }, true);
            //HamDungChung.RegisterControlFieldGridViewDev(CTCongThucMauBieuBCgridView, "NoCo", NoorCo_GrdLU);

            ////"MaTaiKhoan", "MaMucLienQuan", "CongTru", "MaTaiKhoanDoiUng", "MaHoatDong", "Loai", "NoCo", "LoaiHoatDong", "MaNguon", "MaLoaiKhoan", "MaTieuMuc"
            ////LoaiHoatDong
            //RepositoryItemGridLookUpEdit KhoanMuc_GrdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(KhoanMuc_GrdLU, _noCoList, "Ten", "Id", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(KhoanMuc_GrdLU, new string[] { "Ten", "MaQL" }, new string[] { "Khoản mục", "Mã QL" }, new int[] { 120, 100 }, true);
            //HamDungChung.RegisterControlFieldGridViewDev(CTCongThucMauBieuBCgridView, "LoaiHoatDong", KhoanMuc_GrdLU);
            ////NguonKinhPhi
            //RepositoryItemGridLookUpEdit NguonKinhPhi_GrdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(NguonKinhPhi_GrdLU, nguonKinhPhiListBindingSource, "TenNguonKinhPhi", "MaNguonKinhPhi", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(NguonKinhPhi_GrdLU, new string[] { "MaNguonKinhPhiQuanLy", "TenNguonKinhPhi" }, new string[] { "Mã nguồn KP", "Tên nguồn KP " }, new int[] { 100, 300 }, true);
            //HamDungChung.RegisterControlFieldGridViewDev(CTCongThucMauBieuBCgridView, "MaNguon", NguonKinhPhi_GrdLU);
            ////TieuMucNganSach
            //RepositoryItemGridLookUpEdit TieuMucNganSach_GrdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(TieuMucNganSach_GrdLU, tieuMucNganSachListBindingSource, "MaQuanLy", "MaTieuMuc", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TieuMucNganSach_GrdLU, new string[] { "MaQuanLy", "TenTieuMuc" }, new string[] { "Mã", "Tên" }, new int[] { 100, 300 }, true);
            //HamDungChung.RegisterControlFieldGridViewDev(CTCongThucMauBieuBCgridView, "MaTieuMuc", TieuMucNganSach_GrdLU);
            ////loại khoản
            //RepositoryItemGridLookUpEdit loaiKhoan_GrdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(loaiKhoan_GrdLU, loaiKhoanListBindingSource, "MaLoaiKhoanQuanLy", "MaLoaiKhoan", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(loaiKhoan_GrdLU, new string[] { "MaLoaiKhoanQuanLy", "TenLoaiKhoan" }, new string[] { "Mã", "Tên khoản" }, new int[] { 300, 100 }, true);
            //HamDungChung.RegisterControlFieldGridViewDev(CTCongThucMauBieuBCgridView, "MaLoaiKhoan", loaiKhoan_GrdLU);
            ////
            ////this.CTCongThucMauBieuBCgridView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.CTCongThucMauBieuBCgridView_RowCellClick);
            ////this.CTCongThucMauBieuBCgridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.CTCongThucMauBieuBCgridView_CellValueChanged);
            //this.CTCongThucMauBieuBCgridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CTCongThucMauBieuBCgridView_KeyDown);

            //HamDungChung.HideOrShowColumnofGridViewDev(CTCongThucMauBieuBCgridView, new string[] { "LoaiHoatDong", "MaNguon", "MaLoaiKhoan", "MaTieuMuc" }, new bool[] { false, false, false, false });
            //CTCongThucMauBieuBCgridView.OptionsView.ColumnAutoWidth = true;
            //CTCongThucMauBieuBCgridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            //CTCongThucMauBieuBCgridView.GroupPanelText = "Thiết Lập Công Thức Lấy Số"; 
            #endregion
            
        }

        private void DesignGridControl()
        {
            DesignMucLienQuangridLookUpEdit();
            DesignlueLoaiMuc();
            DesignCTCongThucMauBieuBCgridView();
        }

        private void LoadCongThucMauBieuBaoCaoParrentList()
        {
            _congThucMauBieuBCParentList = CongThucMauBieuBaoCaoList.GetCongThucMauBieuBaoCaoList(_loaiMauBaoCao, _maThongTu);
            CongThucMauBieuBaoCao NKP_Empt = CongThucMauBieuBaoCao.NewCongThucMauBieuBaoCao();
            NKP_Empt.TenMuc = "";
            _congThucMauBieuBCParentList.Insert(0, NKP_Empt);
            CongThucMauBieuBaoCaoParent_ListBindingSource1.DataSource = _congThucMauBieuBCParentList;
            mucLienQuanForCTCongThucMuaBieuBC_bindingSource.DataSource = _congThucMauBieuBCParentList;
        }

        private void KhoiTao()
        {

            CongThucMauBieuBaoCaoParent_ListBindingSource1.DataSource = typeof(CongThucMauBieuBaoCaoList);
            CongThucMauBieuBaoCao_bindingSource1.DataSource = typeof(CongThucMauBieuBaoCao);
            CT_CongThucMauBieuBaoCaobindingSource.DataSource = typeof(CT_CongThucMauBieuBaoCaoList);
            heThongTaiKhoanList_bindingSource.DataSource = typeof(HeThongTaiKhoan1List);
            heThongTaiKhoanDoiUngList_bindingSource.DataSource = typeof(HeThongTaiKhoan1List);
            mucLienQuanForCTCongThucMuaBieuBC_bindingSource.DataSource = typeof(CongThucMauBieuBaoCaoList);
            _CongTruNhanChialist = CongTruNhanChia.CreateListCongTruNhanChia();
            _PhuongThucLaySoList = PhuongThucLaySo.CreateListPhuongThucLaySo();
            _noCoList = NoorCo.CreateListNoorCo();
            _loaiMucCongThucList = LoaiMucCongThuc.CreateListLoaiMucCongThuc();
            LoadCongThucMauBieuBaoCaoParrentList();

            CongThucMauBieuBaoCaoList congthucmaubieubaocaoMucLienQuanList = CongThucMauBieuBaoCaoList.GetCongThucMauBieuBaoCaoMucLienQuanList(_loaiMauBaoCao, _maThongTu);
            CongThucMauBieuBaoCao congthuc_Empt = CongThucMauBieuBaoCao.NewCongThucMauBieuBaoCao();
            congthuc_Empt.TenMuc = "";
            congthucmaubieubaocaoMucLienQuanList.Insert(0, congthuc_Empt);
            MucLienQuanList_bindingSource.DataSource = congthucmaubieubaocaoMucLienQuanList;


            HeThongTaiKhoan1List hethongtaikhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();//HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListDangSuDungByCongTy_2018ForBCTC(_maThongTu);
            HeThongTaiKhoan1 tkEmpty = HeThongTaiKhoan1.NewHeThongTaiKhoan1("");
            hethongtaikhoanList.Insert(0, tkEmpty);
            heThongTaiKhoanList_bindingSource.DataSource = hethongtaikhoanList;
            heThongTaiKhoanDoiUngList_bindingSource.DataSource = hethongtaikhoanList;


            CongThucMauBieuBaoCao_bindingSource1.DataSource = _CongThucMauBieuBC;
            CT_CongThucMauBieuBaoCaobindingSource.DataSource = _CongThucMauBieuBC.CT_CongThucMauBieuBaoCaoChildList;

            DesignGridControl();
        }

        private void KhoiTaoCongThucMauBieuBaoCao()
        {
            #region temp
            int maMucCha = _CongThucMauBieuBC.MaMucCha;
            int maMucLienQuan = _CongThucMauBieuBC.MucLienQuan; 
            #endregion temp
            _CongThucMauBieuBC = CongThucMauBieuBaoCao.NewCongThucMauBieuBaoCao();
            _CongThucMauBieuBC.LoaiBaoCao = _loaiMauBaoCao;
            _CongThucMauBieuBC.MaThongTu = _maThongTu;
            _CongThucMauBieuBC.MaMucCha = maMucCha;
            _CongThucMauBieuBC.MucLienQuan = maMucLienQuan;
            BindingData();
            txtMaSo.Focus();

        }
        private void KhoiTaoCongThucMauBieuBaoCao(CongThucMauBieuBaoCao congthuc)
        {
            _CongThucMauBieuBC = CongThucMauBieuBaoCao.NewCongThucMauBieuBaoCao();
            _CongThucMauBieuBC = CongThucMauBieuBaoCao.GetCongThucMauBieuBaoCao(congthuc.MaMuc);
            BindingData();

        }
        private void KhoiTaoCongThucMauBieuBaoCao_MucCon(CongThucMauBieuBaoCao congthuc)
        {
            _CongThucMauBieuBC = CongThucMauBieuBaoCao.NewCongThucMauBieuBaoCao();
            _CongThucMauBieuBC.LoaiBaoCao = _loaiMauBaoCao;
            _CongThucMauBieuBC.MaThongTu = _maThongTu;
            _CongThucMauBieuBC.MaMucCha = congthuc.MaMuc;
            if (congthuc.Vitri!= 0)
                _CongThucMauBieuBC.MucLienQuan = congthuc.MucLienQuan;
            else
                _CongThucMauBieuBC.MucLienQuan = congthuc.MaMuc; 
            BindingData();

        }

        private void BindingData()
        {
            CongThucMauBieuBaoCao_bindingSource1.DataSource = _CongThucMauBieuBC;
            CT_CongThucMauBieuBaoCaobindingSource.DataSource = _CongThucMauBieuBC.CT_CongThucMauBieuBaoCaoChildList;
        }

        private bool KiemTraDuLieu()
        {
            bool kq = true;
            return kq;

        }


        private bool LuuDuLieu()
        {
            bool kq = true;
            try
            {
                if (KiemTraDuLieu())
                {
                    CongThucMauBieuBaoCao_bindingSource1.EndEdit();
                    _CongThucMauBieuBC.ApplyEdit();
                    _CongThucMauBieuBC.Save();
                }
            }
            catch (ApplicationException ex)
            {
                kq = false;
            }
            return kq;
        }

        #endregion

        #region Event


        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (LuuDuLieu())
            {
                MessageBox.Show(this, "Đã lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Cậpnhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }


        private void btnLuuvaThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (LuuDuLieu())
            {
                LoadCongThucMauBieuBaoCaoParrentList();
                KhoiTaoCongThucMauBieuBaoCao();
            }
            else
            {
                MessageBox.Show(this, "Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LapThongTinBoSung_button_Click(object sender, EventArgs e)
        {
            if (_CongThucMauBieuBC.MaMuc != 0)
            {
                frmThongTinBoSungThuyetMinhBCTC frm = new frmThongTinBoSungThuyetMinhBCTC(_CongThucMauBieuBC.MaMuc, _CongThucMauBieuBC.TenMuc);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Vui lòng lưu trước khi lập thông tin bổ sung!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Event handles
        //MaNguonNSNN_gridLookUpEdit_EditValueChanged
        private void MaNguonNSNN_gridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            //if (MaNguonNSNN_gridLookUpEdit.EditValue != null)
            //{
            //    int maNgonNSNN;
            //    if (int.TryParse(MaNguonNSNN_gridLookUpEdit.EditValue.ToString(), out maNgonNSNN))
            //    {
            //        if (maNgonNSNN != 0)
            //            MaQLNguonNSNN_textEdit.Text = MaNguonNSNN.GetMaNguonNSNN(maNgonNSNN).MaQuanLy;
            //    }
            //}
        }

        //MaLoaiKhoangridLookUpEdit_EditValueChanged
        private void MaLoaiKhoangridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            //if (MaLoaiKhoangridLookUpEdit.EditValue != null)
            //{
            //    int maLoaiKhoanOut;
            //    if (int.TryParse(MaLoaiKhoangridLookUpEdit.EditValue.ToString(), out maLoaiKhoanOut))
            //    {
            //        if (maLoaiKhoanOut != 0)
            //            TenLoaiKhoantextEdit.Text = LoaiKhoan.GetLoaiKhoan(maLoaiKhoanOut).TenLoaiKhoan;
            //    }
            //}
        }

        private void CTCongThucMauBieuBCgridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (CTCongThucMauBieuBCgridView.RowCount > 0)
                {
                    if (CTCongThucMauBieuBCgridView.GetSelectedRows().Length > 0)
                    {
                        if (MessageBox.Show(String.Format("Bạn có muốn xóa {0} dòng được chọn không?", CTCongThucMauBieuBCgridView.GetSelectedRows().Length), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            CTCongThucMauBieuBCgridView.DeleteSelectedRows();
                        }
                    }
                }
            }

        }

        private void CTCongThucMauBieuBCgridView_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
           
        }
        #endregion Event handles

        

    }
    //=======================

    #region Public Class
    public class CongTruNhanChia
    {
        public byte Ma { get; set; }
        public string Ten { get; set; }
        public CongTruNhanChia(byte ma, string ten)
        {
            Ma = ma;
            Ten = ten;
        }

        public static List<CongTruNhanChia> CreateListCongTruNhanChia()
        {
            List<CongTruNhanChia> listRS = new List<CongTruNhanChia>();
            listRS.Add(new CongTruNhanChia(0, ""));
            listRS.Add(new CongTruNhanChia(1, "Cộng"));
            listRS.Add(new CongTruNhanChia(2, "Trừ"));
            listRS.Add(new CongTruNhanChia(3, "Nhân"));
            listRS.Add(new CongTruNhanChia(4, "Chia"));
            return listRS;
        }

    }

    public class PhuongThucLaySo
    {
        public byte Ma { get; set; }
        public string Ten { get; set; }
        public PhuongThucLaySo(byte ma, string ten)
        {
            Ma = ma;
            Ten = ten;
        }

        public static List<PhuongThucLaySo> CreateListPhuongThucLaySo()
        {
            List<PhuongThucLaySo> listRS = new List<PhuongThucLaySo>();
            listRS.Add(new PhuongThucLaySo(0, ""));
            listRS.Add(new PhuongThucLaySo(2, "Lấy theo số phát sinh"));
            listRS.Add(new PhuongThucLaySo(3, "Lấy theo số dư đầu"));
            listRS.Add(new PhuongThucLaySo(4, "Lấy theo số dư cuối kỳ"));
            listRS.Add(new PhuongThucLaySo(5, "Lấy theo số dư cuối kỳ theo đối tượng"));
            return listRS;
        }

    }
    public class NoorCo
    {
        public byte Ma { get; set; }
        public string Ten { get; set; }
        public NoorCo(byte ma, string ten)
        {
            Ma = ma;
            Ten = ten;
        }

        public static List<NoorCo> CreateListNoorCo()
        {
            List<NoorCo> listRS = new List<NoorCo>();
            listRS.Add(new NoorCo(0, ""));
            listRS.Add(new NoorCo(1, "Nợ"));
            listRS.Add(new NoorCo(2, "Có"));
            return listRS;
        }

    }

    //public DataTable DTLoaiMuc()
    //   {
    //       DataTable dt = new DataTable();
    //       dt.Clear();
    //       dt.Columns.Add("Ma");
    //       dt.Columns.Add("Ten");
    //       dt.Rows.Add("0", "");
    //       dt.Rows.Add("1", "Tính theo mã tài khoản");
    //       dt.Rows.Add("2", "Tính từ mục khác");
    //       return dt;
    //   }

    public class LoaiMucCongThuc
    {
        public byte Ma { get; set; }
        public string Ten { get; set; }
        public LoaiMucCongThuc(byte ma, string ten)
        {
            Ma = ma;
            Ten = ten;
        }

        public static List<LoaiMucCongThuc> CreateListLoaiMucCongThuc()
        {
            List<LoaiMucCongThuc> listRS = new List<LoaiMucCongThuc>();
            listRS.Add(new LoaiMucCongThuc(0, ""));
            listRS.Add(new LoaiMucCongThuc(1, "Tính theo mã tài khoản"));
            listRS.Add(new LoaiMucCongThuc(2, "Tính từ mục khác"));
            return listRS;
        }

    }

    #endregion Public Class

}//End