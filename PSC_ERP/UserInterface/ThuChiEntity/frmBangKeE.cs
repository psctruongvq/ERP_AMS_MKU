using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.Diagnostics;
using System.IO;

using PSC_ERP_Business.Main;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;
using PSC_ERPNew.Main.Reports;
using System.Data.Objects;
using System.Linq;
using PSC_ERPNew.Main;
using System.Threading;
using ERP_Library;
using PSC_ERPNew.Main.PhanHe.DIGITIZING;

using System.Data.Entity;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid;
using CrystalDecisions.CrystalReports.Engine;


//26_04_2014
namespace PSC_ERP.ThuChiEntity
{
    public partial class frmBangKeE : DevExpress.XtraEditors.XtraForm
    {
        #region Singleton

        private static frmBangKeE singleton_ = null;
        public static frmBangKeE Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmBangKeE();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent = null)
        {
            PSC_ERP_Common.FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }

        #endregion//Singleton

        #region properties
        ChungTuThuChi_DerivedFactory _factory = null;
        ChungTu_Factory _factorypublic = null;

        ChungTuThuChi_DerivedFactory _factoryForDanhSachChungTuChiTiet = null;
        public int LoaiChi = 0;
        long _maDoiTuong = 0;
        app_users _user;
        int _maCongTy = 0; //ERP_Library.Security.CurrentUser.Info.MaCongTy;
        IQueryable<tblTieuMucNganSach> _TieuMucNganSachList = null;

        //
        private int _maLoaiChungTu = 0;
        public int MaLoaiChungtu
        {
            get
            {
                return _maLoaiChungTu;
            }
        }
        int _maLoaiDoiTuong = 0;
        public tblChungTu _ChungTu = null;
        List<tblButToan> _ButToanDeleteList = null;
        List<tblCT_ChiPhiSanXuat> _ct_ChiPhiSanXuatListDelete = null;
        List<tblChungTu_HoaDon> _chungtu_HoaDonListDelete = null;
        List<tblPhieuThutuPhieuChi> _PhieuThutuPhieuChiListDelete = null;
        IQueryable<tblLoaiTien> _LoaiTienList = null;
        IQueryable<tblTaiKhoan> _HeThongTaiKhoan1ListCo, _HeThongTaiKhoan1ListNo;
        List<tblTaiKhoan> _HeThongTaiKhoanSearchCo, _HeThongTaiKhoanSearchNo;
        IQueryable<tblcnLoaiDoiTuong> _loaiDoiTuongThuChiList = null;
        public static List<spd_DanhSachChiPhiSanXuatTheoThang_Result> _chiThuLaoList_DaChon = null;

        static public int DoiTuongThu_Chi = -1;

        static decimal TongTien = 0;
        static decimal soTien = 0;
        long soChungTu = 0;// dùng cho cập nhật các đề nghị thanh toán, chuyển khoản
        public long MaKhachHang = 0;

        static int Phieu = 2; // PhieuThu = 2; PhieuChi = 3; UyNhiemChi = 6; UyNhiemThu = 7; PhieuChuyenKhoan = 8

        public bool flag = false;

        int maTKNoSearch = 0;
        int maTKCoSearch = 0;
        long MaDangNhap;
        string SoChungTuTuDongTang = string.Empty;
        DateTime NgayLap = DateTime.Today;

        sp_AllDoiTuong_Result dtKhachHang = null;

        string SoCTMoiPS = "";
        //
        List<sp_AllDoiTuong_Result> _DoiTuongThuChiList = null;
        List<sp_AllDoiTuong_Result> _DoiTuongNoList = null;
        List<sp_AllDoiTuong_Result> _DoiTuongCoList = null;

        IQueryable<tblChungTu> _ChungTuList;
        List<tblHopDong> _hopDongList = null;

        bool kiemTraTaiKhoan;

        Boolean _daLoadXong = false;
        Boolean _taoMoiChungTu = true;
        DateTime _ngayLapCu;
        long _maChungTuGhiTangCuCanXemLai = 0;

        DataSet dataSet = new DataSet();
        int UserId = PSC_ERP_Global.Main.UserID;

        private int _selectIndexTabControl = 1;//1: xtraTabPage1(Chứng từ); 2:xtraTabPage2(Danh sách chứng từ)
        private bool _selectedTabPage2 = false;


        private bool clickButtoan = false;
        private bool handlefocus = true;

        #region BSHoaDon
        HoaDon_Factory _hoaDonFactory = null;
        List<tblHoaDon> _hoaDonListbyChungTu = null;
        DoiTacList _DoiTacList;
        List<ERP_Library.LoaiHoaDonClass> _listLoaiHoaDonClass;
        private bool _isCellValuechangeBT = true;
        #endregion//BSHoaDon
        #endregion//Properties

        #region Funtions

        private void Check_chkKhachHangClick()
        {
            if (chkKhachHang.Checked == true)
            {
                ShowKH();
                _maDoiTuong = 0;
                _ChungTu.MaDoiTuong = _maDoiTuong;
            }
            else
            {
                HideKH();
            }
        }

        public int GetMaTaiKhoan(String soHieuTK)
        {
            foreach (tblTaiKhoan tk in _HeThongTaiKhoan1ListCo)
                if (tk.SoHieuTK == soHieuTK)
                    return tk.MaTaiKhoan;
            return 1;
        }

        void SetTaiKhoanDefaultForNewFirstButtoan(tblButToan buttoan)
        {
            if (_maLoaiChungTu == 16)//Bang Ke
            {

                if (_maCongTy == 2)
                {
                    buttoan.NoTaiKhoan = GetMaTaiKhoan("1121.9");
                }
                else if (_maCongTy == 3)
                {
                    buttoan.NoTaiKhoan = GetMaTaiKhoan("1121.5");
                }
                else
                {
                    buttoan.NoTaiKhoan = GetMaTaiKhoan("1121");
                }
            }
            else if (_maLoaiChungTu == 2)//Phieu Thu
            {
                if (_maCongTy == 2)//HTVC
                {
                    buttoan.NoTaiKhoan = GetMaTaiKhoan("1111.9");
                }
                else if (_maCongTy == 3)
                {
                    buttoan.NoTaiKhoan = GetMaTaiKhoan("1111.5");
                }
                else
                    buttoan.NoTaiKhoan = GetMaTaiKhoan("1111");
            }
            else if (_maLoaiChungTu == 3)//Phieu Chi
            {
                if (_maCongTy == 1)//HTVC
                {
                    buttoan.CoTaiKhoan = GetMaTaiKhoan("1111");
                }
                else if (_maCongTy == 2)//HTVC
                {
                    buttoan.CoTaiKhoan = GetMaTaiKhoan("1111.9");
                }
                else if (_maCongTy == 3)
                {
                    buttoan.CoTaiKhoan = GetMaTaiKhoan("1111.5");
                }
            }

        }

        private void DesignGrid_ButToan()
        {
            HamDungChung.InitGridViewDev(gridView_ButToan, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(gridView_ButToan, new string[] { "NoTaiKhoan", "CoTaiKhoan", "SoTien", "MaDoiTuongNo", "MaDoiTuongCo", "MaHopDong", "DienGiai" },
                                new string[] { "Nợ Tài Khoản", "Có Tài Khoản", "Số Tiền", "Đối tượng nợ", "Đối tượng có", "Số hợp đồng", "Diễn Giải" },
                                             new int[] { 80, 80, 90, 120, 120, 100, 150 });
            //Column Cong Viec/ChuongTrinh
            RepositoryItemButtonEdit ButtonEdit_CongViec_CT = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(ButtonEdit_CongViec_CT)).BeginInit();
            ButtonEdit_CongViec_CT.AutoHeight = false;
            ButtonEdit_CongViec_CT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Công việc/Chương trình", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), new DevExpress.Utils.SerializableAppearanceObject(), "", null, null, true)});
            ButtonEdit_CongViec_CT.Name = "repositoryItemButtonEdit1";
            ButtonEdit_CongViec_CT.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            //add button colCT_ChiPhiSX
            GridColumn colCT_ChiPhiSX = new GridColumn();
            colCT_ChiPhiSX.Caption = "Công việc/Chương trình";
            colCT_ChiPhiSX.ColumnEdit = ButtonEdit_CongViec_CT;
            colCT_ChiPhiSX.Name = "colCT_ChiPhiSX";
            colCT_ChiPhiSX.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colCT_ChiPhiSX.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            colCT_ChiPhiSX.Visible = true;
            colCT_ChiPhiSX.VisibleIndex = 8;
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ButtonEdit_CongViec_CT });
            gridView_ButToan.Columns.Add(colCT_ChiPhiSX);
            ((System.ComponentModel.ISupportInitialize)(ButtonEdit_CongViec_CT)).EndInit();

            #region add Column HoaDon
            ////Begin Column HoaDon
            //RepositoryItemButtonEdit ButtonEdit_DsHoaDon = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            //((System.ComponentModel.ISupportInitialize)(ButtonEdit_DsHoaDon)).BeginInit();
            //ButtonEdit_DsHoaDon.AutoHeight = false;
            //ButtonEdit_DsHoaDon.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            //new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "DS Hóa đơn", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), new DevExpress.Utils.SerializableAppearanceObject(), "", null, null, true)});
            //ButtonEdit_DsHoaDon.Name = "repositoryItemButtonEdit2";
            //ButtonEdit_DsHoaDon.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            ////add button colChungTu_HoaDon
            //GridColumn colChungTu_HoaDon = new GridColumn();
            //colChungTu_HoaDon.Caption = "DS Hóa đơn";
            //colChungTu_HoaDon.ColumnEdit = ButtonEdit_DsHoaDon;
            //colChungTu_HoaDon.Name = "colChungTu_HoaDon";
            //colChungTu_HoaDon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //colChungTu_HoaDon.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            //colChungTu_HoaDon.Visible = true;
            //colChungTu_HoaDon.VisibleIndex = 9;
            //this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ButtonEdit_DsHoaDon });
            //gridView_ButToan.Columns.Add(colChungTu_HoaDon);
            //((System.ComponentModel.ISupportInitialize)(ButtonEdit_DsHoaDon)).EndInit();
            ////End Column HoaDon 
            #endregion//add Column HoaDon

            //this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ButtonEdit_CongViec_CT, ButtonEdit_DsHoaDon });
            //gridView_ButToan.Columns.Add(colCT_ChiPhiSX);
            //gridView_ButToan.Columns.Add(colChungTu_HoaDon);

            //((System.ComponentModel.ISupportInitialize)(ButtonEdit_CongViec_CT)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(ButtonEdit_DsHoaDon)).EndInit();
            //

            HamDungChung.AlignHeaderColumnGridViewDev(gridView_ButToan, new string[] { "NoTaiKhoan", "CoTaiKhoan", "SoTien", "DienGiai", "MaDoiTuongNo", "MaDoiTuongCo", "MaHopDong" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_ButToan, new string[] { "SoTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView_ButToan, new string[] { "SoTien" }, "{0:#,###.#}");
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
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DoiTuongNo_grdLU, new string[] { "MaQLDoiTuong", "MaSoThue", "TenDoiTuong" }, new string[] { "Mã đối tượng", "Mã số thuế", "Tên đối tượng" }, new int[] { 90, 90, 200 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "MaDoiTuongNo", DoiTuongNo_grdLU);
            //
            //
            
            RepositoryItemGridLookUpEdit DoiTuongCo_grdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(DoiTuongCo_grdLU, DoiTuongCoList_BindingSource, "TenDoiTuong", "MaDoiTuong", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DoiTuongCo_grdLU, new string[] { "MaQLDoiTuong", "MaSoThue", "TenDoiTuong" }, new string[] { "Mã đối tượng", "Mã số thuế", "Tên đối tượng" }, new int[] { 90, 90, 200 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "MaDoiTuongCo", DoiTuongCo_grdLU);
            //

            //
            
            RepositoryItemGridLookUpEdit HopDong_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(HopDong_GrdLU, HopDong_bindingSource, "tblHopDongMuaBan.SoHopDong", "MaHopDong", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(HopDong_GrdLU, new string[] { "tblHopDongMuaBan.SoHopDong", "TenHopDong" }, new string[] { "Số hợp đồng", "Nội dung" }, new int[] { 100, 200 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "MaHopDong", HopDong_GrdLU);
            //

            //
            RepositoryItemCalcEdit repositoryItemCalcEditSoTien = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();

            repositoryItemCalcEditSoTien.AutoHeight = false;
            repositoryItemCalcEditSoTien.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditSoTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repositoryItemCalcEditSoTien.Name = "repositoryItemCalcEditSoTien";
            gridView_ButToan.Columns["SoTien"].ColumnEdit = repositoryItemCalcEditSoTien;
            //
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_ButToan, new string[] { "SoTien" }, "#,###.#");
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

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_DSDeNghi, new string[] { "SoTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView_DSDeNghi, new string[] { "SoTien" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(gridView_DSDeNghi);

            Utils.GridUtils.SetSTTForGridView(gridView_DSDeNghi, 50);//M
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_DSDeNghi, new string[] { "SoTien" }, "#,###.#");
            this.gridView_DSDeNghi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_DSDeNghi_KeyDown);
        }
        private void DesignGrid_HoaDon()
        {
            #region Design ChungTu_HoaDon
            ChungTu_HoaDongridControl.DataSource = ChungTuHoaDon_bindingSource;

            HamDungChung.InitGridViewDev(ChungTu_HoaDongridView, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, false, true);


            HamDungChung.ShowFieldGridViewDev_Modify(ChungTu_HoaDongridView, new string[] { "tblHoaDon.GhiChu", "LoaiHoaDon", "tblHoaDon.NgayLap", "tblHoaDon.SoHoaDon", "tblHoaDon.SoSerial", "tblHoaDon.MauHoaDon", "tblHoaDon.KyHieuMauHoaDon", "tblHoaDon.TongTien", "tblHoaDon.ThueVAT" },
                                new string[] { "Nội dung", "Loại Hóa đơn", "Ngày Lập", "Số hóa đơn", "Số Serial", "Mẫu hóa đơn", "Ký hiệu", "Tông tiền", "Tiền Thuế" },
                                             new int[] { 200, 100, 80, 90, 90, 90, 90, 100, 100 }, true);

            #region Coulumn HoaDon
            ////Begin Column HoaDon
            //RepositoryItemButtonEdit ButtonEdit_DsHoaDon = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            //((System.ComponentModel.ISupportInitialize)(ButtonEdit_DsHoaDon)).BeginInit();
            //ButtonEdit_DsHoaDon.AutoHeight = false;
            //ButtonEdit_DsHoaDon.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            //new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Thêm hóa đơn", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), new DevExpress.Utils.SerializableAppearanceObject(), "", null, null, true)});
            //ButtonEdit_DsHoaDon.Name = "repositoryItemButtonEdit2";
            //ButtonEdit_DsHoaDon.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            ////add button colChungTu_HoaDon
            //GridColumn colChungTu_HoaDon = new GridColumn();
            //colChungTu_HoaDon.Caption = "Thêm hóa đơn";
            //colChungTu_HoaDon.ColumnEdit = ButtonEdit_DsHoaDon;
            //colChungTu_HoaDon.Name = "colChungTu_HoaDon";
            //colChungTu_HoaDon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //colChungTu_HoaDon.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            //colChungTu_HoaDon.Visible = true;
            //colChungTu_HoaDon.VisibleIndex = 0;
            //this.ChungTu_HoaDongridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ButtonEdit_DsHoaDon });
            //ChungTu_HoaDongridView.Columns.Add(colChungTu_HoaDon);
            //((System.ComponentModel.ISupportInitialize)(ButtonEdit_DsHoaDon)).EndInit();
            ////End Column HoaDon 
            #endregion//Coulumn HoaDon

            HamDungChung.AlignHeaderColumnGridViewDev(ChungTu_HoaDongridView, new string[] { "tblHoaDon.GhiChu", "LoaiHoaDon", "tblHoaDon.NgayLap", "tblHoaDon.SoHoaDon", "tblHoaDon.SoSerial", "tblHoaDon.MauHoaDon", "tblHoaDon.KyHieuMauHoaDon", "tblHoaDon.TongTien", "tblHoaDon.ThueVAT" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(ChungTu_HoaDongridView, new string[] { "tblHoaDon.TongTien", "tblHoaDon.ThueVAT" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(ChungTu_HoaDongridView, new string[] { "tblHoaDon.TongTien", "tblHoaDon.ThueVAT" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(ChungTu_HoaDongridView);
            HamDungChung.ReadOnlyColumnGridViewDev(ChungTu_HoaDongridView);

            Utils.GridUtils.SetSTTForGridView(ChungTu_HoaDongridView, 50);//M
            this.ChungTu_HoaDongridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChungTu_HoaDongridView_KeyDown);
            //this.ChungTu_HoaDongridView.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.ChungTu_HoaDongridView_InitNewRow);
            this.ChungTu_HoaDongridView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.ChungTu_HoaDongridView_RowCellClick);
            #endregion//Design ChungTu_HoaDon


            #region Design New HoaDon
            //ChungTu_HoaDongridControl.DataSource = HoaDonbindingSource;

            //HamDungChung.InitGridViewDev(ChungTu_HoaDongridView, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, false, true);
            //HamDungChung.ShowFieldGridViewDev_Modify(ChungTu_HoaDongridView, new string[] { "GhiChu", "ThanhTien", "ThueSuatVAT", "ThueVAT", "LoaiHoaDon", "SoSerial", "SoHoaDon", "MauHoaDon", "KyHieuMauHoaDon", "MaHinhThucTT", "NgayLap", "MaDoiTac", "tblHoaDon_DoiTac.TenDoiTac", "MaSoThue", "MaDCGuiHD", "MaDienThoai", "MaSoThueKhac", "DiaChiDoiTacKhac", "DienThoaiDoiTacKhac" },
            //                    new string[] { "Diễn giải", "Tiền chưa thuế", "Thuế suất(%)", "Tiền thuế", "Loại hóa đơn", "Ký hiệu HĐ", "Số hóa đơn", "Mẫu HĐ", "Ký hiệu mẫu HĐ", "Hình thức TT", "Ngày lập", "Đối tượng", "Đối tượng khác", "Mã số thuế", "Địa chỉ", "Điện thoai", "Mã số thuế", "Địa chỉ", "Điện thoai" },
            //                                 new int[] { 200, 100, 100, 100, 100, 100, 100, 100, 100, 80, 150, 150, 100, 100, 200, 90, 100, 200, 90 }, false);
            //HamDungChung.AlignHeaderColumnGridViewDev(ChungTu_HoaDongridView, new string[] { "GhiChu", "ThanhTien", "ThueSuatVAT", "ThueVAT", "LoaiHoaDon", "SoSerial", "SoHoaDon", "MauHoaDon", "KyHieuMauHoaDon", "MaHinhThucTT", "NgayLap", "MaDoiTac", "tblHoaDon_DoiTac.TenDoiTac", "MaSoThue", "MaDCGuiHD", "MaDienThoai", "MaSoThueKhac", "DiaChiDoiTacKhac", "DienThoaiDoiTacKhac" }, DevExpress.Utils.HorzAlignment.Center);

            //HamDungChung.FormatNumberTypeofColumnGridViewDev2(ChungTu_HoaDongridView, new string[] { "ThanhTien", "ThueVAT" }, "#,###.#");
            //HamDungChung.ShowSummaryFooterofColumnGridViewDev2(ChungTu_HoaDongridView, new string[] { "ThanhTien", "ThueVAT" }, "{0:#,###.#}");
            //HamDungChung.NewRowGridViewDev(ChungTu_HoaDongridView);
            ////LoaiHoaDon
            //RepositoryItemGridLookUpEdit LoaiHoaDon_GrdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(LoaiHoaDon_GrdLU, _listLoaiHoaDonClass, "TenLoaiHoaDon", "Ma", "", false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiHoaDon_GrdLU, new string[] { "TenLoaiHoaDon" }, new string[] { "Loại hóa đơn" }, new int[] { 200 }, true);
            //HamDungChung.RegisterControlFieldGridViewDev(ChungTu_HoaDongridView, "LoaiHoaDon", LoaiHoaDon_GrdLU);
            ////HinhThucThanhToan
            //RepositoryItemGridLookUpEdit HinhThucThanhToan_GrdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(HinhThucThanhToan_GrdLU, phuongThucThanhToanListBindingSource, "TenPhuongThucThanhToan", "MaPhuongThucThanhToan", "", false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(HinhThucThanhToan_GrdLU, new string[] { "TenPhuongThucThanhToan" }, new string[] { "Phương thức thanh toán" }, new int[] { 200 }, true);
            //HamDungChung.RegisterControlFieldGridViewDev(ChungTu_HoaDongridView, "MaHinhThucTT", HinhThucThanhToan_GrdLU);
            ////MauHoaDon
            //RepositoryItemGridLookUpEdit MauHoaDon_GrdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(MauHoaDon_GrdLU, mauHDBindingSource, "MaQuanLy", "MaQuanLy", "", false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(MauHoaDon_GrdLU, new string[] { "MaQuanLy", "TenLoaiHoaDon" }, new string[] { "Mã Hóa Đơn", "Tên loại hóa đơn" }, new int[] { 100, 200 }, true);
            //HamDungChung.RegisterControlFieldGridViewDev(ChungTu_HoaDongridView, "MauHoaDon", MauHoaDon_GrdLU);

            ////DoiTuong
            //RepositoryItemGridLookUpEdit DoiTuong_GrdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(DoiTuong_GrdLU, doiTacListBindingSource, "TenDoiTac", "MaDoiTac", "", false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DoiTuong_GrdLU, new string[] { "MaQLDoiTac", "TenDoiTac", "MaSoThue" }, new string[] { "Mã đối tác", "Tên đối tác", "Mã số thuế" }, new int[] { 100, 200, 120 }, true);
            //HamDungChung.RegisterControlFieldGridViewDev(ChungTu_HoaDongridView, "MaDoiTac", DoiTuong_GrdLU);
            ////DiaChiDoiTac
            //RepositoryItemGridLookUpEdit DiaChiDoiTac_GrdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(DiaChiDoiTac_GrdLU, diaChiDoiTacListBindingSource, "TenDiaChi", "MaDiaChi", "", false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DiaChiDoiTac_GrdLU, new string[] { "TenDiaChi" }, new string[] { "Địa chỉ" }, new int[] { 300 }, true);
            //HamDungChung.RegisterControlFieldGridViewDev(ChungTu_HoaDongridView, "MaDCGuiHD", DiaChiDoiTac_GrdLU);
            ////DienThoaiDoiTac
            //RepositoryItemGridLookUpEdit DienThoaiDoiTac_GrdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(DienThoaiDoiTac_GrdLU, doiTacDienThoaiFaxListBindingSource, "SoDTFax", "MaDienThoaiFax", "", false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DienThoaiDoiTac_GrdLU, new string[] { "SoDTFax" }, new string[] { "Điện thoại" }, new int[] { 300 }, true);
            //HamDungChung.RegisterControlFieldGridViewDev(ChungTu_HoaDongridView, "MaDienThoai", DienThoaiDoiTac_GrdLU);

            //HamDungChung.HideOrShowColumnofGridViewDev(ChungTu_HoaDongridView, new string[] { "MaSoThue", "MaDCGuiHD", "MaDienThoai", "MaSoThueKhac", "DiaChiDoiTacKhac", "DienThoaiDoiTacKhac" }, new bool[] { true, true, true, false, false, false });
            ////HamDungChung.HideOrShowColumnofGridViewDev(ChungTu_HoaDongridView, new string[] { "MaSoThue", "MaDCGuiHD", "MaDienThoai", "MaSoThueKhac", "DiaChiDoiTacKhac", "DienThoaiDoiTacKhac" }, new bool[] {false, false, false, true, true, true });


            //Utils.GridUtils.SetSTTForGridView(ChungTu_HoaDongridView, 50);//M
            //this.ChungTu_HoaDongridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChungTu_HoaDongridView_KeyDown);
            #endregion//Design New HoaDon
        }

        private void DesignGridControls()
        {
            btnInDVKhoanChi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            DesignGrid_ButToan();
            if (_maLoaiChungTu == 16 || _maLoaiChungTu == 2)//Bang Ke or PhieThu
            {
                if (_maLoaiChungTu == 16)//BangKe
                {
                    btnInDVKhoanChi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                DesignGrid_DSDeNghiChuyenKhoan();
            }
            DesignGrid_HoaDon();

        }

        private void KhoiTao()
        {
            _factorypublic = ChungTu_Factory.New();
            HoaDonbindingSource.DataSource = typeof(tblHoaDon);
            _user = app_users_Factory.New().Get_AppUserByUserID(PSC_ERP_Global.Main.UserID);
            _maCongTy = _user.MaCongTy.Value;
            _ButToanDeleteList = new List<tblButToan>();
            _ct_ChiPhiSanXuatListDelete = new List<tblCT_ChiPhiSanXuat>();
            _chungtu_HoaDonListDelete = new List<tblChungTu_HoaDon>();
            _PhieuThutuPhieuChiListDelete = new List<tblPhieuThutuPhieuChi>();
            tblChungTuBindingSource_Single.DataSource = typeof(PSC_ERP_Business.Main.Model.tblChungTu);
            tblDinhKhoanBindingSource_Single.DataSource = typeof(PSC_ERP_Business.Main.Model.tblDinhKhoan);
            tblButToanBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblButToan);
            TienTe_bindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblTienTe);
            tblTaiKhoanBindingSource_No.DataSource = typeof(PSC_ERP_Business.Main.Model.tblTaiKhoan);
            tblTaiKhoanBindingSource_Co.DataSource = typeof(PSC_ERP_Business.Main.Model.tblTaiKhoan);
            AllDoiTuong_bindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.sp_AllDoiTuong_Result);
            DoiTuongAllHoaDonbindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.sp_AllDoiTuong_Result);
            LoaiTien_bindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblLoaiTien);
            ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblChungTu_DeNghiChuyenKhoan);
            ChungTuHoaDon_bindingSource.DataSource = typeof(tblChungTu_HoaDon);
            LoaiDoiTuongThuChi_bindingSource.DataSource = typeof(tblcnLoaiDoiTuong);

            tblChungTubindingSource_ListChiTiet.DataSource = typeof(PSC_ERP_Business.Main.Model.tblChungTu);
            bdCoTKSearch.DataSource = typeof(PSC_ERP_Business.Main.Model.tblTaiKhoan);
            bdNoTKSearch.DataSource = typeof(PSC_ERP_Business.Main.Model.tblTaiKhoan);

            doiTacListBindingSource.DataSource = typeof(DoiTacList);
            diaChiDoiTacListBindingSource.DataSource = typeof(DiaChi_DoiTacList);
            doiTacDienThoaiFaxListBindingSource.DataSource = typeof(DoiTac_DienThoai_FaxList);
            phuongThucThanhToanListBindingSource.DataSource = typeof(PhuongThucThanhToanList);
            mauHDBindingSource.DataSource = typeof(DanhMucMauHoaDonList);
            //this.WindowState = FormWindowState.Maximized;

            DesignGridControls();
        }

        private void GanBindingSource()
        {
            tblChungTuBindingSource_Single.DataSource = _ChungTu;
            TienTe_bindingSource.DataSource = _ChungTu.tblTienTe;
            tblDinhKhoanBindingSource_Single.DataSource = _ChungTu.tblDinhKhoan;
            tblButToanBindingSource.DataSource = _ChungTu.tblDinhKhoan.tblButToans;
            ChungTuHoaDon_bindingSource.DataSource = _ChungTu.tblChungTu_HoaDon;
            if (_maLoaiChungTu == 16 || _maLoaiChungTu == 2)//Bang Ke or PhieThu
                ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = _ChungTu.tblChungTu_DeNghiChuyenKhoan;

        }

        private void TaoBindingDeNghiChuyenKhoan()
        {
            if (_ChungTu.LoaiChungTu == 1)
            {
                this.ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = typeof(tblChungTu_DeNghiChuyenKhoan);
                ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = _ChungTu.tblChungTu_DeNghiChuyenKhoan;
            }
            else if (_ChungTu.LoaiChungTu == 2 || _ChungTu.LoaiChungTu == 6) //Giấy báo có & Phí Ngân hàng
            {
                this.ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = typeof(tblChungTu_GiayBaoCo);
                ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = _ChungTu.tblChungTu_GiayBaoCo;
            }
            else if (_ChungTu.LoaiChungTu == 3)
            {
                this.ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = typeof(tblChungTu_GiayBanNT);
                ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = _ChungTu.tblChungTu_GiayBanNT;
            }
            else if (_ChungTu.LoaiChungTu == 4)
            {
                this.ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = typeof(tblChungTu_LenhChuyenTien);
                ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = _ChungTu.tblChungTu_LenhChuyenTien;
            }
            else if (_ChungTu.LoaiChungTu == 5 || _ChungTu.LoaiChungTu == 8) //5: Ủy Nhiệm Chi cấp 1 || 8: Điều chuyển nội bộ
            {
                this.ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = typeof(tblChungTu_UyNhiemChi);
                ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = _ChungTu.tblChungTu_UyNhiemChi;
            }
            else if (_ChungTu.LoaiChungTu == 7) // Giấy rút tiền mặt ( Chú ý: Chỉ tồn tại trong phiếu thu không tồn tại trong bảng kê)
            {
                this.ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = typeof(tblChungTu_GiayRutTien);
                ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = _ChungTu.tblChungTu_GiayRutTien;
            }
        }

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

        #region Tab Danh Sach Chung Tu - Chi Tiet

        private void LoadDaTaForTabDanhSachChungTu_ChiTiet()
        {
            _factoryForDanhSachChungTuChiTiet = ChungTuThuChi_DerivedFactory.New();
            _HeThongTaiKhoanSearchCo = TaiKhoan_Factory.New().Get_TaiKhoanbyMaCongTy(_maCongTy).ToList();
            tblTaiKhoan tk = new tblTaiKhoan { MaTaiKhoan = 0, SoHieuTK = "<<Tất cả>>" };
            _HeThongTaiKhoanSearchCo.Insert(0, tk);
            _HeThongTaiKhoanSearchNo = _HeThongTaiKhoanSearchCo;
            bdCoTKSearch.DataSource = _HeThongTaiKhoanSearchCo;
            bdNoTKSearch.DataSource = _HeThongTaiKhoanSearchNo;

        }

        private void TimDanhSachChungTu_ChiTiet()
        {
            string SoChungTu = textEdit_SoChungTu.Text.Trim();

            decimal SoTienTu = calcEdit_TuSoTien.Value;
            decimal SoTienDen = calcEdit_DenSoTien.Value;

            DateTime tuNgaySearch = Convert.ToDateTime(dtmp_TuNgay.EditValue);
            DateTime denNgaySearch = Convert.ToDateTime(dtmp_DenNgay.EditValue);

            maTKNoSearch = 0;
            if (gridLookUpEdit_TKNoSearch.EditValue != null)
            {
                int maTKNoOut;
                if (int.TryParse(gridLookUpEdit_TKNoSearch.EditValue.ToString(), out maTKNoOut))
                {
                    maTKNoSearch = maTKNoOut;
                }
            }
            maTKCoSearch = 0;
            if (gridLookUpEdit_TKCoSearch.EditValue != null)
            {
                int maTKCoOut;
                if (int.TryParse(gridLookUpEdit_TKCoSearch.EditValue.ToString(), out maTKCoOut))
                {
                    maTKCoSearch = maTKCoOut;
                }
            }

            string TenDoiTuong = "";//textEdit_DoiTuong.Text;
            string DienGiai = textEdit_DienGiai.Text;



            _ChungTuList = _factoryForDanhSachChungTuChiTiet.TimKiemChungTuThuChibySearch(_maLoaiChungTu, SoChungTu, SoTienTu, SoTienDen, tuNgaySearch, denNgaySearch, maTKNoSearch, maTKCoSearch, DienGiai, TenDoiTuong, _user.UserID);
            tblChungTubindingSource_ListChiTiet.DataSource = _ChungTuList;
            if (_ChungTuList.Count() == 0)
            {
                MessageBox.Show(this, "Không có chứng từ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void DesignGrid_TabDanhSachChungTu_ChiTiet()
        {
            gridControl_DanhSachChungTu_ChiTiet.DataSource = tblChungTubindingSource_ListChiTiet;

            HamDungChung.InitGridViewDev(gridView_DanhSachChungTu_ChiTiet, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, true, false, true, true);
            HamDungChung.ShowFieldGridViewDev2(gridView_DanhSachChungTu_ChiTiet, new string[] { "SoChungTu", "NgayLap", "ThanhTien", "DienGiai" },
                                new string[] { "Số chứng từ", "Ngày lập", "Số tiền", "Diễn giải" },
                                             new int[] { 50, 300, 300, 500 }, true);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView_DanhSachChungTu_ChiTiet, new string[] { "SoChungTu", "NgayLap", "ThanhTien", "DienGiai" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_DanhSachChungTu_ChiTiet, new string[] { "ThanhTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView_DanhSachChungTu_ChiTiet, new string[] { "ThanhTien" }, "{0:#,###.#}");
            Utils.GridUtils.SetSTTForGridView(gridView_DanhSachChungTu_ChiTiet, 50);//M
            this.gridView_DanhSachChungTu_ChiTiet.DoubleClick += new System.EventHandler(this.gridView_DanhSachChungTu_ChiTiet_DoubleClick);

            //gridView_CT_ButToan
            DesignGrid_Tab2_GridviewButoanChild();
        }

        private void DesignGrid_Tab2_GridViewDinhKhoanChild()
        {
            HamDungChung.InitGridViewDev(gridView_DinhKhoanChild, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, true, true, false, true);
            HamDungChung.ShowFieldGridViewDev(gridView_DinhKhoanChild, new string[] { "tblDinhKhoan.LaMotNoNhieuCo" },
                                new string[] { "Là 1 Nợ nhiều Có" },
                                             new int[] { 100 });


            HamDungChung.AlignHeaderColumnGridViewDev(gridView_DinhKhoanChild, new string[] { "tblDinhKhoan.LaMotNoNhieuCo" }, DevExpress.Utils.HorzAlignment.Center);
        }

        private void DesignGrid_Tab2_GridviewButoanChild()
        {
            HamDungChung.InitGridViewDev(gridView_ButToanChild, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, true, true, false, true);
            HamDungChung.ShowFieldGridViewDev(gridView_ButToanChild, new string[] { "NoTaiKhoan", "CoTaiKhoan", "SoTien", "DienGiai" },
                                new string[] { "Nợ Tài Khoản", "Có Tài Khoản", "Số Tiền", "Diễn Giải" },
                                             new int[] { 100, 100, 100, 150 });

            gridView_ButToanChild.GroupPanelText = "Thông Tin Bút Toán";
            HamDungChung.AlignHeaderColumnGridViewDev(gridView_ButToanChild, new string[] { "NoTaiKhoan", "CoTaiKhoan", "SoTien", "DienGiai" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_ButToanChild, new string[] { "SoTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView_ButToanChild, new string[] { "SoTien" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(gridView_ButToanChild);

            Utils.GridUtils.SetSTTForGridView(gridView_ButToanChild, 50);//M
            //
            RepositoryItemGridLookUpEdit TaiKhoanNo_GrdLU = new RepositoryItemGridLookUpEdit();
            TaiKhoanNo_GrdLU.DataSource = bdNoTKSearch;
            TaiKhoanNo_GrdLU.DisplayMember = "SoHieuTK";
            TaiKhoanNo_GrdLU.ValueMember = "MaTaiKhoan";
            HamDungChung.InitRepositoryItemGridLookUpDev(TaiKhoanNo_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TaiKhoanNo_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu", "Tên tài khoản" }, new int[] { 100, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToanChild, "NoTaiKhoan", TaiKhoanNo_GrdLU);
            //
            //
            RepositoryItemGridLookUpEdit TaiKhoanCo_GrdLU = new RepositoryItemGridLookUpEdit();
            TaiKhoanCo_GrdLU.DataSource = bdCoTKSearch;
            TaiKhoanCo_GrdLU.DisplayMember = "SoHieuTK";
            TaiKhoanCo_GrdLU.ValueMember = "MaTaiKhoan";
            HamDungChung.InitRepositoryItemGridLookUpDev(TaiKhoanCo_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TaiKhoanCo_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu", "Tên tài khoản" }, new int[] { 100, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToanChild, "CoTaiKhoan", TaiKhoanCo_GrdLU);

        }

        private void LoadTemplateForTabDanhSachChungTu()
        {
            if (!_selectedTabPage2)
            {
                dtmp_TuNgay.EditValue = DateTime.Today.Date;
                dtmp_DenNgay.EditValue = DateTime.Today.Date;
                LoadDaTaForTabDanhSachChungTu_ChiTiet();
                DesignGrid_TabDanhSachChungTu_ChiTiet();
            }
        }

        #endregion//Tab Danh Sach Chung Tu - Chi Tiet

        private void LoadDaTa()
        {
            _LoaiTienList = LoaiTien_Factory.New().GetAll();
            LoaiTien_bindingSource.DataSource = _LoaiTienList;
            // tai khoan
            _HeThongTaiKhoan1ListCo = TaiKhoan_Factory.New().Get_TaiKhoanbyMaCongTy(_maCongTy);
            tblTaiKhoanBindingSource_No.DataSource = _HeThongTaiKhoan1ListCo;
            _HeThongTaiKhoan1ListNo = _HeThongTaiKhoan1ListCo;
            tblTaiKhoanBindingSource_Co.DataSource = _HeThongTaiKhoan1ListNo;

            _TieuMucNganSachList = TieuMucNganSach_Factory.New().GetAll();
            TblTieuMucNganSach_bindingSource.DataSource = _TieuMucNganSachList;

            _loaiDoiTuongThuChiList = cnLoaiDoiTuong_Factory.New().Get_LoaiDoiTuongbyMaCongTy(_maCongTy);
            LoaiDoiTuongThuChi_bindingSource.DataSource = _loaiDoiTuongThuChiList;


        }



        private void LoadDataAfterInitChungTu()
        {
            LoadDoiTuong_HopDong();

        }

        private void LoadDoiTuong_HopDong()
        {

            Thread thr = new Thread(() =>
            {
                if (this.InvokeRequired)
                {
                    PSC_ERP_Common.Delegate.VoidDelegate dele = new PSC_ERP_Common.Delegate.VoidDelegate(this.LoadDoiTuong_HopDong_Helper);
                    this.Invoke(dele);
                }
                else
                {
                    this.LoadDoiTuong_HopDong_Helper();
                }
            });
            thr.Start();
        }

        void LoadDoiTuong_HopDong_Helper()
        {
            // doi tuong
            _DoiTuongThuChiList = _factorypublic.Context.sp_AllDoiTuong(0).Where(x => x.MaCongTy == _maCongTy).ToList();
            sp_AllDoiTuong_Result doituong = new sp_AllDoiTuong_Result() { MaDoiTuong = 0, TenDoiTuong = "<<không chọn>>" };
            _DoiTuongThuChiList.Insert(0, doituong);
            AllDoiTuong_bindingSource.DataSource = _DoiTuongThuChiList;
            List<sp_AllDoiTuong_Result> lisdoituongHoaDon = _factorypublic.Context.sp_AllDoiTuong(0).Where(x => x.Loai == 2 || x.Loai == 3).ToList();
            sp_AllDoiTuong_Result dtHD = new sp_AllDoiTuong_Result() { MaDoiTuong = 0, TenDoiTuong = "<<Không chọn>>" };
            lisdoituongHoaDon.Insert(0, dtHD);
            DoiTuongAllHoaDonbindingSource.DataSource = lisdoituongHoaDon;
            _DoiTuongNoList = new List<sp_AllDoiTuong_Result>(); //_DoiTuongThuChiList;
            _DoiTuongCoList = new List<sp_AllDoiTuong_Result>();//_DoiTuongThuChiList;
            DoiTuongNoList_BindingSource.DataSource = _DoiTuongNoList;
            // doi tuong co
            DoiTuongCoList_BindingSource.DataSource = _DoiTuongCoList;//_DoiTuongCoList;

            //HopDong
            _hopDongList = HopDong_Factory.New().GetAll().ToList();
            tblHopDong hopDong_khongChon = new tblHopDong() { MaHopDong = 0, TenHopDong = "<<Không chọn>>" };
            hopDong_khongChon.tblHopDongMuaBan = new tblHopDongMuaBan() { SoHopDong = "<<Không chọn>>" };
            _hopDongList.Insert(0, hopDong_khongChon);
            HopDong_bindingSource.DataSource = _hopDongList;


            LoadDoiTuongTheoDoiForChungTu();
            //LoadDataBoSung();
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
            _ChungTu.SoChungTu = _factory.Get_NextSoChungThuChi_ByYear(LoaiChungTu, (Convert.ToDateTime(dtmp_Ngay.EditValue)).Date.Year);
            txtSoChungTu.Text = _ChungTu.SoChungTu;
        }

        private void KhoiTaoChungTuMoi()
        {
            dtmp_Ngay.EditValue = (object)DateTime.Today.Date;
            gridLookUpEditMaChungTuPC.Properties.NullText = "";
            //chưa load xong
            _daLoadXong = false;
            {
                //khởi tạo mới chứng từ factory
                _factory = ChungTuThuChi_DerivedFactory.New();
                _hoaDonFactory = HoaDon_Factory.New();
                //khởi tạo chứng từ mới
                _ChungTu = _factory.NewChungTuThuChi(_maLoaiChungTu, (Convert.ToDateTime(dtmp_Ngay.EditValue)).Date.Year);
                _ChungTu.MaBoPhanDangNhap = _user.MaBoPhan;
                SetSoChungTuMoiPS(_maLoaiChungTu);
                dtmp_Ngay.EditValue = DateTime.Today;
                _ChungTu.SoChungTuKemTheo = 1;

                LoadDataAfterInitChungTu();
                //gán bindingSource
                GanBindingSource();
                grdLU_MaDoiTuongThuChi.Focus();
                btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                _chiThuLaoList_DaChon = new List<spd_DanhSachChiPhiSanXuatTheoThang_Result>();
                _ButToanDeleteList = new List<tblButToan>();

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
                _factory = ChungTuThuChi_DerivedFactory.New();
                _hoaDonFactory = HoaDon_Factory.New();
                //load chứng từ được quản lý bởi _factory
                _ChungTu = _factory.Get_ChungTu_ByMaChungTu(maChungTu);
                if (_ChungTu.MaChungTu != 0)
                {

                    GanBindingSource();

                    if (_ChungTu.NgayLap.Value.Year <= 2013)
                    {
                        btnLuu.Enabled = false;
                    }
                    else
                    {
                        btnLuu.Enabled = true;
                    }
                    _ngayLapCu = _ChungTu.NgayLap.Value;
                    dtmp_Ngay.EditValue = _ChungTu.NgayLap;
                    Phieu = _ChungTu.MaLoaiChungTu;

                    DoiTuongThu_Chi = _ChungTu.MaDoiTuongThuChi == null ? 0 : _ChungTu.MaDoiTuongThuChi.Value;

                    group_ThongTinPhieu.Enabled = true;
                    LoadDataAfterInitChungTu();
                    if (_maLoaiChungTu == 16 || _maLoaiChungTu == 2)//Bang Ke or PhieThu
                        TaoBindingDeNghiChuyenKhoan();

                    if (Phieu != 8)
                    {
                        if (_ChungTu.MaDoiTuong != null)
                        {
                            _maDoiTuong = _ChungTu.MaDoiTuong.Value;
                        }

                    }
                    GanDuLieuChoTextDoiTac();
                    soChungTu = _ChungTu.MaChungTu;
                    btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    TongTien = _ChungTu.tblTienTe.ThanhTien.Value;
                    soTien = _ChungTu.tblTienTe.SoTien;

                    KhoiTaoGridLookupEditMaChungTuPhieuChi();//--

                    LoadDoiTuongTheoDoiForChungTu();
                }

            }
            //đã load xong
            _daLoadXong = true;
        }

        private void ClearChiTietKH()
        {
            txt_TenDoiTuongNhan.DataBindings.Clear();
            txt_DiaChiDoiTuongNhan.DataBindings.Clear();
            txt_TenDoiTuongNhan.EditValue = DBNull.Value;
            txt_DiaChiDoiTuongNhan.EditValue = DBNull.Value;
        }

        private void ShowKH()
        {
            ClearChiTietKH();
            txt_TenDoiTuongNhan.Properties.ReadOnly = false;
            txt_DiaChiDoiTuongNhan.Properties.ReadOnly = false;
            txt_TenDoiTuongNhan.Properties.Appearance.BackColor = System.Drawing.Color.White;
            txt_DiaChiDoiTuongNhan.Properties.Appearance.BackColor = System.Drawing.Color.White;
            btn_DoiTuong.Enabled = false;
            if (_ChungTu.tblChungTu_DiaChi != null)
            {
                txt_TenDoiTuongNhan.Text = _ChungTu.tblChungTu_DiaChi.Ten;
                txt_DiaChiDoiTuongNhan.Text = _ChungTu.tblChungTu_DiaChi.DiaChi;
             
            }
            else
            {
                txt_TenDoiTuongNhan.Text = "";
                txt_DiaChiDoiTuongNhan.Text = "";
            }
        }

        private void HideKH()
        {
            ClearChiTietKH();
            txt_TenDoiTuongNhan.Properties.ReadOnly = true;
            txt_DiaChiDoiTuongNhan.Properties.ReadOnly = true;
            txt_TenDoiTuongNhan.Properties.Appearance.BackColor = System.Drawing.Color.PaleGoldenrod;
            txt_DiaChiDoiTuongNhan.Properties.Appearance.BackColor = System.Drawing.Color.PaleGoldenrod;
            btn_DoiTuong.Enabled = true;
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
            _ChungTu.tblDinhKhoan.LaMotNoNhieuCo = true;
            if (_ChungTu.tblDinhKhoan.tblButToans.Count == 1 && _maLoaiChungTu == 3)
            {
                _ChungTu.tblDinhKhoan.LaMotNoNhieuCo = false;
                return true;
            }
            else if (_ChungTu.tblDinhKhoan.tblButToans.Count > 1)
            {
                int[] noArry = new int[_ChungTu.tblDinhKhoan.tblButToans.Count];
                int[] coArry = new int[_ChungTu.tblDinhKhoan.tblButToans.Count];
                int n = 0;
                foreach (tblButToan bt in _ChungTu.tblDinhKhoan.tblButToans)
                {
                    if ((bt.NoTaiKhoan ?? 0) == 0 || (bt.CoTaiKhoan ?? 0) == 0)
                    {
                        DialogUtil.ShowError("Chưa chọn đầy đủ tài khoản của bút toán");
                        return false;
                    }
                    noArry[n] = bt.NoTaiKhoan.Value;
                    coArry[n] = bt.CoTaiKhoan.Value;
                    n += 1;
                }
                if (
                    (ElementsInArryDifference(noArry) && ElementsInArryDifference(coArry))
                    //||
                    //(ElementsInArryEqual(noArry) && ElementsInArryEqual(coArry))
                    )
                {
                    MessageBox.Show("Bút toán nhiều Nợ nhiều Có, không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (ElementsInArryDifference(noArry))
                {
                    _ChungTu.tblDinhKhoan.LaMotNoNhieuCo = false;
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

        private Boolean DuocPhepLuu()
        {
            Boolean duocPhepLuu = true;

            if (KhoaSo())
            {
                MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_ChungTu.MaDoiTuongThuChi == 0)
            {
                MessageBox.Show(this, "Bạn phải chọn công việc/chương trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if ((DateTime)dtmp_Ngay.EditValue <= Convert.ToDateTime("31-12-2013"))
            {
                MessageBox.Show(this, "Ngày lập phải lớn hơn ngày 31-12-2013", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtSoChungTu.Text.Trim() == "" || KiemTraSoChungTu(txtSoChungTu.Text.Trim()) == false)
            {
                if (Convert.ToInt32(grdLU_LoaiTien.EditValue) == 1)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Số Chứng Từ theo định dạng 1234B/DVXX", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Số Chứng Từ theo định dạng 1234NTB/DVXX", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (_ChungTu.MaChungTu == 0)
                    txtSoChungTu.Text = SoCTMoiPS;
                else
                    txtSoChungTu.Text = _ChungTu.SoChungTu;
                txtSoChungTu.Focus();
                return false;
            }
            //kiểm tra trùng số chứng từ
            if (_factory.KiemTraTrungSoChungTu(_ChungTu) == true)
            {
                txtSoChungTu.Focus();
                DialogResult dlgResult = DialogUtil.ShowYesNo("Trùng số chứng từ. Tự động phát sinh số chứng từ mới");
                if (dlgResult == DialogResult.Yes)
                {
                    _ChungTu.SoChungTu = _factory.Get_NextSoChungThuChi_ByYear(_maLoaiChungTu, _ChungTu.NgayLap.Value.Year);
                    //đệ quy
                    return DuocPhepLuu();
                }
                else
                    return false;
            }
            else if (_ChungTu.tblTienTe.SoTien == 0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Số Tiền Chứng Từ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                calcEdit_SoTien.Focus();
                return false;
            }


            if (KiemTraButToanHopLe() == false)
                return false;
            if (_ChungTu.KiemTraDinhKhoanBangKe() == false)
                return false;

            if (_ChungTu.KiemTraHoaDonThuChi() == false)
                return false;



            return duocPhepLuu;
        }

        private bool DeleteChungTu()
        {
            try
            {
                using (DialogUtil.WaitForDelete(this))
                {
                    _factory.XoaChungTuThuChi(_ChungTu);
                    //lưu lại thay đổi
                    _factory.SaveChanges();
                }
                //thông báo đã xóa thành công
                DialogUtil.ShowDeleteSuccessful();
                return true;
            }
            catch (Exception ex)
            {
                //thông báo không xóa được
                DialogUtil.ShowNotDeleteSuccessful();
            }
            return false;
        }

        private void CapNhatMaButToanChiPhiSanXuat(long maButToanChiPhiSanXuat, int maBoPhan, int maChuongTrinh, string soDeNghi, bool loaiNV, bool isDelete)
        {
            spd_DanhSachChiPhiSanXuatTheoThang_Result_Factory.New().CapNhatMaButToanChiPhiSanXuat(maButToanChiPhiSanXuat, maBoPhan, maChuongTrinh, soDeNghi, loaiNV, isDelete);
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
                        if (chkKhachHang.Checked == true)
                        {

                            _ChungTu.MaDoiTuong = 0;
                        }
                        else
                        {
                            _ChungTu.MaDoiTuong = _maDoiTuong;// dtKhachHang.MaDoiTuong;

                        }
                        XuLyButToanTruocKhiLuu();
                        XuLyChungTu_DiaChi();
                        Delete_DeletedChilList();
                        UpdateButToan_ChiPhiHDfromButToan();
                        UpdateTamUng();
                        if (_ChungTu.MaLoaiChungTu != 16)
                            UpdateChungTu_TheoDoifromChungTu();
                        _factory.SaveChanges(BusinessCodeEnum.BangKe_ThuChi.ToString());//lưu lại chứng từ
                        #region BS ChiThuLao
                        foreach (tblButToan bt in _ChungTu.tblDinhKhoan.tblButToans)
                        {
                            foreach (tblCT_ChiPhiSanXuat cpsx in bt.tblCT_ChiPhiSanXuat)
                            {
                                //ChiThuLao
                                foreach (tblcnChiThuLao ctl in cpsx.tblcnChiThuLaos)
                                {
                                    ctl.MaChungTu = _ChungTu.MaChungTu;
                                    ctl.SoChungTu = _ChungTu.SoChungTu;
                                }
                                //ChiPhiThucHien
                                foreach (tblChiPhiThucHien cpth in cpsx.tblChiPhiThucHiens)
                                {
                                    cpth.MaChungTu = _ChungTu.MaChungTu;
                                    cpth.TenChungTu = _ChungTu.SoChungTu;
                                }

                            }
                        }
                        _factory.SaveChanges();
                        #endregion //BS Chi ThuLa0

                    }
                    _taoMoiChungTu = false;
                    _ngayLapCu = _ChungTu.NgayLap.Value;
                    _ct_ChiPhiSanXuatListDelete = new List<tblCT_ChiPhiSanXuat>();
                    _chungtu_HoaDonListDelete = new List<tblChungTu_HoaDon>();
                    _PhieuThutuPhieuChiListDelete = new List<tblPhieuThutuPhieuChi>();
                    _ButToanDeleteList = new List<tblButToan>();
                    //Tiến hành cập nhật lại mã chứng từ chí phí (nếu có)
                    if (_chiThuLaoList_DaChon != null && _chiThuLaoList_DaChon.Count > 0)
                    {
                        foreach (tblButToan itemButToan in _ChungTu.tblDinhKhoan.tblButToans)
                        {
                            foreach (tblCT_ChiPhiSanXuat itemChungTu in itemButToan.tblCT_ChiPhiSanXuat)
                            {
                                foreach (spd_DanhSachChiPhiSanXuatTheoThang_Result item in _chiThuLaoList_DaChon)
                                {
                                    if (item.MaChuongTrinh == itemChungTu.MaChuongTrinh)
                                    {
                                        CapNhatMaButToanChiPhiSanXuat(itemChungTu.MaCT_ChiPhiSanXuat, item.MaBoPhan ?? 0, item.MaChuongTrinh ?? 0, item.SoDNCK, item.LoaiNV ?? false, false);
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

        private void GanDuLieuChoTextDoiTac()
        {
            if (_maDoiTuong != 0)
            {
                _ChungTu.MaDoiTuong = _maDoiTuong;
                dtKhachHang = _factory.Context.sp_AllDoiTuong(0).Where(x => x.MaDoiTuong == _maDoiTuong).First();
                chkKhachHang.Checked = false;
                HideKH();
                txt_TenDoiTuongNhan.Text = dtKhachHang.MaQLDoiTuong + " - " + dtKhachHang.TenDoiTuong;
                txt_DiaChiDoiTuongNhan.Text = dtKhachHang.DiaChi;
                //maLoaiDoiTuong = ;


                _hopDongList = HopDong_Factory.New().GetAll().Where(x => x.MaDoiTac.Value == _maDoiTuong && x.DaThanhToan.Value == 0).ToList();
                tblHopDong hopDong_khongChon = new tblHopDong() { MaHopDong = 0, TenHopDong = "<<Không chọn>>" };
                hopDong_khongChon.tblHopDongMuaBan = new tblHopDongMuaBan() { SoHopDong = "<<Không chọn>>" };
                _hopDongList.Insert(0, hopDong_khongChon);
                HopDong_bindingSource.DataSource = _hopDongList;

            }
            else if (_ChungTu.MaDoiTuong == 0 || _ChungTu.MaDoiTuong == null)
            {
                chkKhachHang.Checked = true;
                ShowKH();

            }
        }

        private bool KhoaSo()
        {
            bool khoaso = false;
            List<tblKhoaSo_User> khoa = KhoaSoUser_Factory.New().GetKhoaSo_UserbyNgay_User(_user.UserID, _ChungTu.NgayLap.Value).ToList();
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    khoaso = true;
                }
            }

            if (khoaso == false && _taoMoiChungTu == false)
            {
                khoa = KhoaSoUser_Factory.New().GetKhoaSo_UserbyNgay_User(_user.UserID, _ngayLapCu).ToList();
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

        private bool KhoaSoThue()
        {
            bool khoasothue = false;
            List<tblKhoaSo_User> khoa = KhoaSoUser_Factory.New().GetKhoaSo_UserbyNgay_User(_user.UserID, _ChungTu.NgayLap.Value).ToList();
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSoThue == true)
                {
                    khoasothue = true;
                }
            }

            if (khoasothue == false && _taoMoiChungTu == false)
            {
                khoa = KhoaSoUser_Factory.New().GetKhoaSo_UserbyNgay_User(_user.UserID, _ngayLapCu).ToList();
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

        private bool KhoaButToanTheoTaiKhoan(int mataiKhoan)
        {
            #region ThamKhao
            //bool khoataiKhoan = false;
            //List<tblKhoaSo_User> khoa = KhoaSoUser_Factory.New().GetKhoaSo_UserbyNgay_User(_user.UserID, _ChungTu.NgayLap.Value).ToList();
            //if (khoa.Count > 0)
            //{
            //    if (khoa[0].KhoaSoThue == true)
            //    {
            //        khoataiKhoan = true;
            //    }
            //}

            //if (khoataiKhoan == false && _taoMoiChungTu == false)
            //{
            //    khoa = KhoaSoUser_Factory.New().GetKhoaSo_UserbyNgay_User(_user.UserID, _ngayLapCu).ToList();
            //    if (khoa.Count > 0)
            //    {
            //        if (khoa[0].KhoaSoThue == true)
            //        {
            //            khoataiKhoan = true;
            //        }
            //    }
            //}
            //return khoataiKhoan; 
            #endregion//ThamKhao

            bool khoataiKhoan = false;
            KhoaSo_MaTaiKhoanRootList khoa = KhoaSo_MaTaiKhoanRootList.GetKhoaSo_MaTaiKhoanRootList(_user.UserID, mataiKhoan, _ChungTu.NgayLap.Value);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    khoataiKhoan = true;
                }
            }

            if (khoataiKhoan == false && _taoMoiChungTu == false)
            {
                khoa = KhoaSo_MaTaiKhoanRootList.GetKhoaSo_MaTaiKhoanRootList(_user.UserID, mataiKhoan, _ngayLapCu);
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

        private void TaoButToanDeleteList()
        {
            if (gridView_ButToan.RowCount > 0)
            {
                if (gridView_ButToan.GetSelectedRows().Length > 0)
                {
                    if (XtraMessageBox.Show(String.Format("Bạn có muốn xóa {0} dòng được chọn không?", gridView_ButToan.GetSelectedRows().Length), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (int btDeleteindex in gridView_ButToan.GetSelectedRows())
                        {
                            tblButToan butToan = _ChungTu.tblDinhKhoan.tblButToans.ElementAtOrDefault(btDeleteindex);
                            _ButToanDeleteList.Add(butToan);
                        }
                        gridView_ButToan.DeleteSelectedRows();
                    }
                }
            }
        }

        private void Delete_DeletedChilList()
        {
            foreach (tblCT_ChiPhiSanXuat cp in _ct_ChiPhiSanXuatListDelete)
            {
                CT_ChiPhiSanXuat_Factory.DeleteChildrenCT_ChiPhiSanXuat(_factory.Context, cp);
            }
            foreach (tblButToan btDelete in _ButToanDeleteList)
            {
                ButToan_Factory.DeleteChildrenButToanThuChi(_factory.Context, btDelete);
            }
            foreach (tblPhieuThutuPhieuChi pttpcDelete in _PhieuThutuPhieuChiListDelete)
            {
                _factory.Context.tblPhieuThutuPhieuChis.DeleteObject(pttpcDelete);
            }
            foreach (tblChungTu_HoaDon ct_hdlist in _chungtu_HoaDonListDelete)
            {
                _factory.Context.tblChungTu_HoaDon.DeleteObject(ct_hdlist);
            }
        }

        private void CapNhatThanhTienChungTu()
        {
            decimal tongTien = 0;
            foreach (tblButToan bt in _ChungTu.tblDinhKhoan.tblButToans)
            {
                tongTien += bt.SoTien;
            }
            _ChungTu.tblTienTe.SoTien = tongTien;
            _ChungTu.tblTienTe.MaLoaiTien = 1;
        }

        #region tblChungTu_TheoDoi
        private void UpdateChungTu_TheoDoifromChungTu()
        {
            if (_ChungTu != null)
            {
                if (_ChungTu.tblChungTu_TheoDoi.Count() == 0)
                {
                    tblChungTu_TheoDoi ct_td = new tblChungTu_TheoDoi();
                    ct_td.SoChungTu = _ChungTu.SoChungTu;
                    ct_td.NgayLapChungTu = _ChungTu.NgayLap;
                    ct_td.SoTienChungTu = _ChungTu.tblTienTe.ThanhTien;
                    if (_ChungTu.DienGiai != null)
                        ct_td.DienGiaiChungTu = _ChungTu.DienGiai;
                    ct_td.NguoiLapChungTu = _ChungTu.MaNguoiLap;
                    ct_td.NguoiChiTien = UserId;
                    ct_td.NgayChiTien = DateTime.Today.Date;
                    _ChungTu.tblChungTu_TheoDoi.Add(ct_td);
                }
                else
                {
                    foreach (tblChungTu_TheoDoi ct_td in _ChungTu.tblChungTu_TheoDoi)
                    {
                        ct_td.SoChungTu = _ChungTu.SoChungTu;
                        ct_td.NgayLapChungTu = _ChungTu.NgayLap;
                        ct_td.SoTienChungTu = _ChungTu.tblTienTe.ThanhTien;
                        if (_ChungTu.DienGiai != null)
                            ct_td.DienGiaiChungTu = _ChungTu.DienGiai;
                        ct_td.NguoiLapChungTu = _ChungTu.MaNguoiLap;
                    }
                }
            }
        }

        private bool KiemTraSoQuy()
        {
            #region Old
            //if (_ChungTu.tblChungTu_TheoDoi.Count() > 0)
            //{
            //    if ((_ChungTu.tblChungTu_TheoDoi.FirstOrDefault<tblChungTu_TheoDoi>().SoTienDaChi ?? 0) != 0)
            //    {
            //        MessageBox.Show(this, "Chứng từ này đã thu chi thực tế, vui lòng liên hệ Thủ Quỹ ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return false;
            //    }
            //}
            #endregion//Old
            if (_taoMoiChungTu == false && _maLoaiChungTu != 16 && _factory.KiemTraSoQuy(_ChungTu.MaChungTu) != 0)
            {
                MessageBox.Show(this, "Chứng từ này đã thu chi thực tế, vui lòng liên hệ Thủ Quỹ ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        #endregion//tblChungTu_TheoDoi

        private void XuLyChungTu_DiaChi()
        {
            if (_ChungTu != null)
            {
                if (_ChungTu.MaDoiTuong != 0)
                {
                    if (_ChungTu.tblChungTu_DiaChi != null)
                    {
                        ChungTu_DiaChi_Factory.FullDelete(_factory.Context, _ChungTu.tblChungTu_DiaChi);
                    }
                }
                else
                {
                    if (_ChungTu.tblChungTu_DiaChi == null)
                    {
                        _ChungTu.tblChungTu_DiaChi = ChungTu_DiaChi_Factory.New().CreateAloneObject();
                    }
                    _ChungTu.tblChungTu_DiaChi.Ten = txt_TenDoiTuongNhan.Text;
                    _ChungTu.tblChungTu_DiaChi.DiaChi = txt_DiaChiDoiTuongNhan.Text;
                }
            }
        }

        private void XuLyButToanTruocKhiLuu()
        {
            foreach (tblButToan bt in _ChungTu.tblDinhKhoan.tblButToans)
            {
                if (bt.MaDoiTuongNo != null && bt.MaDoiTuongNo.Value == 0)
                {
                    bt.MaDoiTuongNo = null;
                }
                if (bt.MaDoiTuongCo != null && bt.MaDoiTuongCo == 0)
                {
                    bt.MaDoiTuongCo = null;
                }
                if (bt.MaHopDong != null && bt.MaHopDong == 0)
                {
                    bt.MaHopDong = null;
                }

            }

        }

        private void UpdateButToan_ChiPhiHDfromButToan()
        {
            if (_ChungTu.tblDinhKhoan.tblButToans != null)
            {
                foreach (tblButToan buttoan in _ChungTu.tblDinhKhoan.tblButToans)
                {
                    if (buttoan.tblButToan_ChiPhiHD.Count() == 0)
                    {
                        string tenBoPhan = (BoPhan_Factory.New().Get_ByID(_user.MaBoPhan ?? 0)).TenBoPhan;
                        tblButToan_ChiPhiHD bt_cp = new tblButToan_ChiPhiHD();
                        bt_cp.NguoiLap = _user.UserID;
                        bt_cp.MaBoPhan = _user.MaBoPhan;
                        bt_cp.TenBoPhan = tenBoPhan;
                        bt_cp.MaCongTy = _user.MaCongTy;
                        bt_cp.SoTien = buttoan.SoTien;
                        bt_cp.NgayLap = DateTime.Today;
                        bt_cp.ThuChi = false;

                        buttoan.tblButToan_ChiPhiHD.Add(bt_cp);
                    }
                    else
                    {
                        foreach (tblButToan_ChiPhiHD bt_cp in buttoan.tblButToan_ChiPhiHD)
                        {
                            bt_cp.SoTien = buttoan.SoTien;
                        }
                    }
                }
            }
        }

        private void UpdateTamUng()
        {
            if (_ChungTu.tblTamUngs != null)
            {
                int loaithuchi = 0;
                string TKNo;
                string TKCo;
                foreach (tblButToan buttoan in _ChungTu.tblDinhKhoan.tblButToans)
                {
                    TKNo = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(buttoan.NoTaiKhoan ?? 0).SoHieuTK;
                    TKCo = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(buttoan.CoTaiKhoan ?? 0).SoHieuTK;
                    if (TKNo.StartsWith("312"))
                    {
                        loaithuchi = 2;
                        break;
                    }
                    if (TKCo.StartsWith("312"))
                    {
                        loaithuchi = 3;
                        break;
                    }
                }

                foreach (tblTamUng tamung in _ChungTu.tblTamUngs)
                {
                    tamung.NgayLap = _ChungTu.NgayLap;
                    tamung.LoaiThuChi = loaithuchi;
                    tamung.SoChungTu = _ChungTu.SoChungTu;
                    tamung.LoaiChungTu = _ChungTu.MaLoaiChungTu;
                }

            }

        }

        private void FormatForm()
        {
            if (_maLoaiChungTu == 2)
            {
                this.Text = "Phiếu Thu";
                Tab1_xtraTabPage2.PageVisible = true;

                checkBox_ThuLao.Text = "Không In Thuế";
                lblPhieuChi.Visible = true;
                gridLookUpEditMaChungTuPC.Visible = true;
                KhoiTaoGridLookupEditMaChungTuPhieuChi();//--
            }
            else if (_maLoaiChungTu == 3)
            {
                this.Text = "Phiếu Chi";
                Tab1_xtraTabPage2.PageVisible = true;

                checkBox_ThuLao.Visible = false;
                lblPhieuChi.Visible = false;
                gridLookUpEditMaChungTuPC.Visible = false;
            }
            else if (_maLoaiChungTu == 16)
            {
                this.Text = "Chứng Từ Nghiệp Vụ Khác";
                Tab1_xtraTabPage2.PageVisible = true;

                checkBox_ThuLao.Text = "Theo Dõi Thù Lao";
                lblPhieuChi.Visible = false;
                gridLookUpEditMaChungTuPC.Visible = false;
            }
        }

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
                    dt.TableName = "spd_CongNo_PhieuChi;1";
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
                    dt.TableName = "spd_BaoCaoChungTuGhiSo;1";
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

        #region BS KhoaSoThue

        private void UnLockControl()//Them
        {

        }
        private void LockControl()
        {

        }

        private byte CheckCoTaiKhoanThueTrongButToan()
        {
            //1: Thuế GTGT Được Khấu Trừ;/2:Thuế Khác;/ 0: không có tài khoản thuế
            foreach (tblButToan buttoan in _ChungTu.tblDinhKhoan.tblButToans)
            {
                tblTaiKhoan tk = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(buttoan.NoTaiKhoan ?? 0);
                tblTaiKhoan tkco = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(buttoan.CoTaiKhoan ?? 0);
                if (tk.SoHieuTK.StartsWith("3113"))
                {
                    return 1;
                }
                else if (tk.SoHieuTK.StartsWith("3337") || tkco.SoHieuTK.StartsWith("3337"))
                {
                    return 2;
                }
            }
            return 0;
        }
        private bool IsTaiKhoanThue(int? mataikhoan)
        {
            if (mataikhoan == null || mataikhoan.Value == 0) return false;
            tblTaiKhoan tk = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(mataikhoan ?? 0);
            if (tk.SoHieuTK.StartsWith("3113") || tk.SoHieuTK.StartsWith("3337"))
            {
                return true;
            }
            return false;
        }

        #region BS Khoa TaiKhoan
        private bool CheckCoTaiKhoanBiKhoaTrongButToan()
        {
            foreach (tblButToan buttoan in _ChungTu.tblDinhKhoan.tblButToans)
            {
                //tblTaiKhoan tk = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(buttoan.NoTaiKhoan ?? 0);
                //tblTaiKhoan tkco = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(buttoan.CoTaiKhoan ?? 0);
                if (KhoaButToanTheoTaiKhoan(buttoan.NoTaiKhoan ?? 0) || KhoaButToanTheoTaiKhoan(buttoan.CoTaiKhoan ?? 0))
                {
                    return true;
                }
            }
            return false;
        }
        private void LockgrdView_DinhKhoan()
        {

            gridView_ButToan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit = false;
            gridView_ButToan.Columns["CoTaiKhoan"].OptionsColumn.AllowEdit = false;
            gridView_ButToan.Columns["SoTien"].OptionsColumn.AllowEdit = false;
            gridView_ButToan.Columns["MaDoiTuongCo"].OptionsColumn.AllowEdit = false;
            gridView_ButToan.Columns["MaDoiTuongNo"].OptionsColumn.AllowEdit = false;//
            //gridView_ButToan.Columns["DienGiai"].OptionsColumn.AllowEdit = false;

        }//Them

        private void UnLockgrdView_DinhKhoan()
        {

            gridView_ButToan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit = true;
            gridView_ButToan.Columns["CoTaiKhoan"].OptionsColumn.AllowEdit = true;
            gridView_ButToan.Columns["SoTien"].OptionsColumn.AllowEdit = true;
            gridView_ButToan.Columns["MaDoiTuongCo"].OptionsColumn.AllowEdit = true;
            gridView_ButToan.Columns["MaDoiTuongNo"].OptionsColumn.AllowEdit = true;//
            //gridView_ButToan.Columns["DienGiai"].OptionsColumn.AllowEdit = true;
        }//Them

        private void EventRowOrColumnGrdView_DinhKhoanChange(int rowhandle)
        {
            UnLockgrdView_DinhKhoan();
            if (gridView_ButToan.GetFocusedRow() != null)
            {
                tblButToan buttoan = (tblButToan)gridView_ButToan.GetFocusedRow();
                if (KhoaButToanTheoTaiKhoan(buttoan.NoTaiKhoan ?? 0) || KhoaButToanTheoTaiKhoan(buttoan.CoTaiKhoan ?? 0))
                {
                    if (buttoan.MaButToan == 0)
                    {
                        _isCellValuechangeBT = false;
                        MessageBox.Show(this, "Đã khóa sổ tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        buttoan.NoTaiKhoan = null;
                        buttoan.CoTaiKhoan = null;
                        _isCellValuechangeBT = true;
                    }
                    else
                        LockgrdView_DinhKhoan();
                }
            }

        }//Them 
        private bool CheckValidKhoaTaiKhoanWhenChangeNgayCT()//Them
        {
            if (CheckCoTaiKhoanBiKhoaTrongButToan())
            {
                MessageBox.Show("Ngày thay đổi rơi vào ngày Khóa Tài khoản, không thể thực hiện", "Thông Báo");
                _ChungTu.NgayLap = _ngayLapCu;
                dtmp_Ngay.EditValue = _ngayLapCu as object;
                return false;
            }
            return true;
        }
        #endregion// BS Khoa TaiKhoan

        private void FormatFormTheoKhoaSoThue()//Them
        {
            if (_taoMoiChungTu == false)
                if (CheckCoTaiKhoanThueTrongButToan() != 0)
                    if (KhoaSoThue())
                    {
                        LockControl();
                    }

        }

        #endregion// BS KhoaSoThue

        #region BoSung Lap PhieuThu tu PhieuChi

        private void KhoiTaoGridLookupEditMaChungTuPhieuChi()
        {
            if (_maLoaiChungTu == 2)//Phieu Thu
            {
                gridLookUpEditMaChungTuPC.Properties.NullText = "";
                if (_ChungTu != null)
                {
                    if (_ChungTu.tblPhieuThutuPhieuChis != null && _ChungTu.tblPhieuThutuPhieuChis.Count > 0)
                    {
                        gridLookUpEditMaChungTuPC.Properties.NullText = PhieuThuTuPhieuChi_Factory.GetSoChungTuString(_ChungTu.tblPhieuThutuPhieuChis.ToList());
                    }
                }
            }

        }

        #endregion//BoSung Lap PhieuThu tu PhieuChi


        private void ClickChiPhiSX()
        {
            tblButToan currentButToan = this.gridView_ButToan.GetFocusedRow() as tblButToan;
            if (currentButToan != null)
            {
                if (currentButToan.SoTien == 0) return;
                using (frmChiPhiSanXuatChuongTrinhE frm = new frmChiPhiSanXuatChuongTrinhE(context: _factory.Context, chungTu: _ChungTu, butToan: currentButToan))
                {
                    frm.ShowDialog();
                    if (frm.IsSave)
                    {
                        if (currentButToan.tblCT_ChiPhiSanXuat.Count > 0)
                            currentButToan.SoTien = frm.SoTienDaNhap;
                        foreach (tblCT_ChiPhiSanXuat cp in currentButToan.tblCT_ChiPhiSanXuat)
                        {
                            cp.TaoTuTapHopCPSX = false;
                            #region Add ButToan MucNganSach vao ButToan
                            foreach (tblButToan_MucNganSach bt_mns in cp.tblButToan_MucNganSach)
                            {
                                currentButToan.tblButToan_MucNganSach.Add(bt_mns);
                            }
                            #endregion//Add ButToan MucNganSach vao ButToan
                        }
                        //CapNhatThanhTienChungTu();
                        foreach (var cp in frm.ChungTu_ChiPhiSanXuatList_Delete)
                        {
                            _ct_ChiPhiSanXuatListDelete.Add(cp);
                        }
                    }
                }

            }

            tblButToanBindingSource.DataSource = _ChungTu.tblDinhKhoan.tblButToans;
        }

        private void ClickDSHoaDon()
        {
            tblButToan currentButToan = this.gridView_ButToan.GetFocusedRow() as tblButToan;
            if (currentButToan != null)
            {
                if (currentButToan.NoTaiKhoan == null || currentButToan.NoTaiKhoan.Value == 0) return;
                if (TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(currentButToan.NoTaiKhoan.Value).SoHieuTK.StartsWith("3113"))
                {
                    //show danh sách bút toán hóa đơn
                    //using (frmDialogDanhSachHoaDonTheoButToan frm = new frmDialogDanhSachHoaDonTheoButToan(context: _factory.Context, chungTu: _ChungTu, butToan: currentButToan, noTaiKhoanList: _HeThongTaiKhoan1ListNo, coTaiKhoanList: _HeThongTaiKhoan1ListCo))
                    using (frmDanhSachHoaDonTheoButToan frm = new frmDanhSachHoaDonTheoButToan(context: _factory.Context, chungTu: _ChungTu, butToan: currentButToan, noTaiKhoanList: _HeThongTaiKhoan1ListNo, coTaiKhoanList: _HeThongTaiKhoan1ListCo))
                    {
                        frm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Vui lòng chọn nợ tài khoản 3113....", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private bool KiemTraCoTKTamUng()
        {
            tblButToan currentButToan = (tblButToan)tblButToanBindingSource.Current;
            if (currentButToan == null) return false;
            if (gridView_ButToan.FocusedColumn.Name == "colNoTaiKhoan")
            {
                string TKNo = "";
                if (currentButToan.NoTaiKhoan == null || currentButToan.NoTaiKhoan.Value == 0)
                    return false;
                TKNo = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(currentButToan.NoTaiKhoan ?? 0).SoHieuTK;
                if (TKNo.StartsWith("312"))
                {
                    return true;
                    //if (_ChungTu.MaDoiTuong != null)
                    //{
                    //    return true;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Vui lòng nhập đối tượng tạm ứng!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}

                }
            }
            else if (gridView_ButToan.FocusedColumn.Name == "colCoTaiKhoan")
            {
                string TKCo = "";

                if (currentButToan.CoTaiKhoan == null || currentButToan.CoTaiKhoan.Value == 0) return false;
                TKCo = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(currentButToan.CoTaiKhoan ?? 0).SoHieuTK;
                if (TKCo.StartsWith("312"))
                {
                    if (_ChungTu.MaDoiTuong != null)
                    {

                        return true;
                    }
                    //else
                    //{
                    //    MessageBox.Show("Vui lòng nhập đối tượng tạm ứng!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}

                }
            }
            return false;

        }

        #region Load Doi tuong theo doi theo tai khoan

        private void loadDoiTuongNoTheoTaiKhoan(int mataikhoan)
        {
            _DoiTuongNoList = _factorypublic.Context.sp_AllDoiTuong(mataikhoan).Where(x => x.MaCongTy == _maCongTy).ToList();
            sp_AllDoiTuong_Result doituong = new sp_AllDoiTuong_Result() { MaDoiTuong = 0, TenDoiTuong = "<<không chọn>>" };
            _DoiTuongNoList.Insert(0, doituong);
            DoiTuongNoList_BindingSource.DataSource = _DoiTuongNoList;
        }
        private void loadDoiTuongCoTheoTaiKhoan(int mataikhoan)
        {
            _DoiTuongCoList = _factorypublic.Context.sp_AllDoiTuong(mataikhoan).Where(x => x.MaCongTy == _maCongTy).ToList();
            sp_AllDoiTuong_Result doituong = new sp_AllDoiTuong_Result() { MaDoiTuong = 0, TenDoiTuong = "<<không chọn>>" };
            _DoiTuongCoList.Insert(0, doituong);
            DoiTuongCoList_BindingSource.DataSource = _DoiTuongCoList;
        }

        private bool KiemTraDoiTuongNoTrongDoiTuongTheoDoi(long madoituong)
        {
            foreach (sp_AllDoiTuong_Result dt in _DoiTuongNoList)
            {
                if (dt.MaDoiTuong == madoituong)
                {
                    return true;
                }
            }
            return false;
        }

        private bool KiemTraDoiTuongCoTrongDoiTuongTheoDoi(long madoituong)
        {
            foreach (sp_AllDoiTuong_Result dt in _DoiTuongCoList)
            {
                if (dt.MaDoiTuong == madoituong)
                {
                    return true;
                }
            }
            return false;
        }

        private bool KiemTraTaiKhoanCoTheoDoiDoiTuong(int maTaiKhoan)
        {
            tblTaiKhoan tk = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(maTaiKhoan);
            if (tk.CoDoiTuongTheoDoi == true)
            {
                return true;
            }
            return false;
        }

        private void LoadDoiTuongTheoDoiForChungTu()
        {
            foreach (tblButToan bt in _ChungTu.tblDinhKhoan.tblButToans)
            {
                if (KiemTraTaiKhoanCoTheoDoiDoiTuong(bt.CoTaiKhoan ?? 0))
                {
                    loadDoiTuongCoTheoTaiKhoan(bt.CoTaiKhoan ?? 0);
                    return;
                }
                else if (KiemTraTaiKhoanCoTheoDoiDoiTuong(bt.NoTaiKhoan ?? 0))
                {
                    loadDoiTuongNoTheoTaiKhoan(bt.NoTaiKhoan ?? 0);
                    return;
                }
                else
                {
                    _DoiTuongNoList = new List<sp_AllDoiTuong_Result>(); //_DoiTuongThuChiList;
                    _DoiTuongCoList = new List<sp_AllDoiTuong_Result>();//_DoiTuongThuChiList;
                    DoiTuongNoList_BindingSource.DataSource = _DoiTuongNoList;
                    // doi tuong co
                    DoiTuongCoList_BindingSource.DataSource = _DoiTuongCoList;//_DoiTuongCoList;
                }
            }

        }

        private void LoadDataBoSung()
        {
            phuongThucThanhToanListBindingSource.DataSource = PhuongThucThanhToanList.GetPhuongThucThanhToanList();
            mauHDBindingSource.DataSource = DanhMucMauHoaDonList.GetDanhMucMauHoaDonList();
            _listLoaiHoaDonClass = ERP_Library.LoaiHoaDonClass.CreateListLoaiHoaDon();
            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            DoiTac _DoiTac = DoiTac.NewDoiTac(0, "<<Không chọn>>");
            _DoiTacList.Insert(0, _DoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;
        }

        #endregion //Load Doi tuong theo doi theo tai khoan

        private void UpdateDienGiaiButToan()
        {
            if (_taoMoiChungTu == false) return;
            foreach (tblButToan buttoan in _ChungTu.tblDinhKhoan.tblButToans)
            {
                buttoan.DienGiai = txt_DienGiai.Text;

            }
        }

        private void TaoChungTuHoaDonForButToan(ChungTu_HoaDonList cthoadonlist, tblButToan tblbuttoanCurrent)
        {
            foreach (ChungTu_HoaDon cthd in cthoadonlist)
            {
                bool insert = false;
                if (KiemTraTonTaiHoaDonTrongChungTu_HoaDonList(cthd.MaHoaDon) == false)
                    insert = true;
                if (insert)
                {
                    tblChungTu_HoaDon tblct_hd = ChungTu_HoaDon_Factory.New().CreateAloneObject();
                    tblct_hd.MaHoaDon = cthd.MaHoaDon;
                    tblct_hd.MaPhieuNhapXuat = cthd.MaPhieuNhapXuat;
                    tblct_hd.SoTien = cthd.SoTien;
                    tblct_hd.NgayLap = cthd.NgayLap;
                    tblct_hd.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                    tblct_hd.MaBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
                    tblct_hd.TenBoPhan = ERP_Library.Security.CurrentUser.Info.TenBoPhan;

                    _ChungTu.tblChungTu_HoaDon.Add(tblct_hd);
                    tblbuttoanCurrent.tblChungTu_HoaDon.Add(tblct_hd);
                }
            }
            ChungTuHoaDon_bindingSource.DataSource = _ChungTu.tblChungTu_HoaDon;
        }

        private bool KiemTraTonTaiHoaDonTrongChungTu_HoaDonList(long maHoaDon)
        {
            foreach (tblButToan bt in _ChungTu.tblDinhKhoan.tblButToans)
            {
                foreach (tblChungTu_HoaDon ct_hd in bt.tblChungTu_HoaDon)
                {
                    if (ct_hd.MaHoaDon == maHoaDon)
                        return true;
                }
            }
            return false;
        }

        private void XoaChungTu_HoaDon()
        {
            if (ChungTu_HoaDongridView.RowCount > 0)
            {
                if (ChungTu_HoaDongridView.GetSelectedRows().Length > 0)
                {
                    if (XtraMessageBox.Show(String.Format("Bạn có muốn xóa {0} dòng được chọn không?", ChungTu_HoaDongridView.GetSelectedRows().Length), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (int cthdDeleteindex in ChungTu_HoaDongridView.GetSelectedRows())
                        {
                            tblChungTu_HoaDon itemCthd = _ChungTu.tblChungTu_HoaDon.ElementAtOrDefault(cthdDeleteindex);
                            _chungtu_HoaDonListDelete.Add(itemCthd);
                        }
                        ChungTu_HoaDongridView.DeleteSelectedRows();
                    }
                }
            }
        }

        private void AddNewRowhandleGridviewButToan(int rowhandle)
        {
            decimal sotien = Convert.ToDecimal(calcEdit_ThanhTien.EditValue);
            foreach (tblButToan bt in _ChungTu.tblDinhKhoan.tblButToans)
            {

                if (sotien != bt.SoTien)
                    sotien -= bt.SoTien;
                else if (sotien == bt.SoTien)
                    sotien = 0;
            }

            if (sotien !=0 && gridView_ButToan.IsNewItemRow(rowhandle))
            {
                if (gridView_ButToan.GetRow(rowhandle) == null)
                    gridView_ButToan.AddNewRow();
            }


        }

        #region InTheoPhieuCu
        ReportDocument Report;
        private void LoaiInBangKe(int loaiIn)
        {
            DataSet _DataSet = new DataSet();

            if (Phieu == 16) // In Phieu Chuyen Khoan
            {
                #region Phieu Chuyen Khoan
                if (loaiIn == 5)
                {
                    Report = new PSC_ERP.Report.CongNo.ChungTuGhiSo();
                }
                else if (loaiIn == 4)
                {
                    Report = new PSC_ERP.Report.CongNo.ChungTuGhiSoA4();
                }


                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_BaoCaoChungTuGhiSo";
                command.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);

                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.CommandText = "spd_REPORT_ReportHeader";
                command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command2 = new SqlCommand();
                command2.CommandType = CommandType.StoredProcedure;
                command2.CommandText = "spd_LayNguoiKyTenCongNo";
                command2.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

                command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);




                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_BaoCaoChungTuGhiSo;1";
                _DataSet.Tables.Add(table);

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show(this, "Lưu dữ liệu trước khi in.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";
                _DataSet.Tables.Add(table1);

                SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
                DataTable table2 = new DataTable();
                adapter2.Fill(table2);
                table2.TableName = "spd_LayNguoiKyTenCongNo;1";
                _DataSet.Tables.Add(table2);


                Report.SetDataSource(_DataSet);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
                #endregion
            }

        }

        private void LoaiInPhieuThu(int loaiIn)
        {
            DataSet _DataSet = new DataSet();

            if (Phieu == 2) // In phieu thu
            {
                #region Phieu Thu

                if (loaiIn == 5)
                {
                    if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 9)
                        Report = new Report.CongNo.PhieuThu();
                    else
                        Report = new Report.CongNo.PhieuThu_DonViCon();
                }
                else if (loaiIn == 4)
                {
                    if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 9)
                        Report = new Report.CongNo.PhieuThuA4();
                    else
                        Report = new Report.CongNo.PhieuThuA4_DonViCon();
                }
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_CongNo_PhieuThu";
                command.Parameters.AddWithValue("@MaPhieuThu", _ChungTu.MaChungTu);
                command.Parameters.AddWithValue("@SoCTKemTheo", 0);

                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.CommandText = "spd_REPORT_ReportHeader";
                command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command2 = new SqlCommand();
                command2.CommandType = CommandType.StoredProcedure;
                command2.CommandText = "spd_LayNoTaiKhoan_1";
                command2.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);

                command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command3 = new SqlCommand();
                command3.CommandType = CommandType.StoredProcedure;
                command3.CommandText = "spd_LayCoTaiKhoan_1";
                command3.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);

                command3.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                SqlCommand command4 = new SqlCommand();
                command4.CommandType = CommandType.StoredProcedure;
                command4.CommandText = "spd_LayNguoiKyTenCongNo";
                command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

                command4.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_CongNo_PhieuThu;1";
                _DataSet.Tables.Add(table);

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show(this, "Lưu dữ liệu trước khi in.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";
                _DataSet.Tables.Add(table1);

                SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
                DataTable table2 = new DataTable();
                adapter2.Fill(table2);
                table2.TableName = "spd_LayNoTaiKhoan_1;1";
                _DataSet.Tables.Add(table2);

                SqlDataAdapter adapter3 = new SqlDataAdapter(command3);
                DataTable table3 = new DataTable();
                adapter3.Fill(table3);
                table3.TableName = "spd_LayCoTaiKhoan_1;1";
                _DataSet.Tables.Add(table3);

                SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                DataTable table4 = new DataTable();
                adapter4.Fill(table4);
                table4.TableName = "spd_LayNguoiKyTenCongNo;1";
                _DataSet.Tables.Add(table4);
                Report.SetDataSource(_DataSet);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
                #endregion
            }

        }

        private void LoaiInPhieuChi(int loaiIn)
        {
            DataSet _DataSet = new DataSet();

            if (Phieu == 3) // In phieu chi
            {
                #region Phieu Chi

                if (loaiIn == 5)
                {
                    if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 9)
                        Report = new Report.CongNo.PhieuChi();
                    else
                        Report = new Report.CongNo.PhieuChi_DonViCon();
                }
                else if (loaiIn == 4)
                {
                    if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 9)
                        Report = new Report.CongNo.PhieuChiA4();
                    else
                        Report = new Report.CongNo.PhieuChiA4_DonViCon();

                }

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_CongNo_PhieuChi";
                command.Parameters.AddWithValue("@MaPhieuChi", _ChungTu.MaChungTu);
                command.Parameters.AddWithValue("@SoCTKemTheo", 0);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                SqlCommand command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.CommandText = "spd_REPORT_ReportHeader";
                command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);


                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command2 = new SqlCommand();
                command2.CommandType = CommandType.StoredProcedure;
                command2.CommandText = "spd_LayNoTaiKhoan_1";
                command2.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);

                command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command3 = new SqlCommand();
                command3.CommandType = CommandType.StoredProcedure;
                command3.CommandText = "spd_LayCoTaiKhoan_1";
                command3.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);

                command3.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command4 = new SqlCommand();
                command4.CommandType = CommandType.StoredProcedure;
                command4.CommandText = "spd_LayNguoiKyTenCongNo";
                command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

                command4.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_CongNo_PhieuChi;1";
                _DataSet.Tables.Add(table);

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show(this, "Lưu dữ liệu trước khi in.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";
                _DataSet.Tables.Add(table1);

                SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
                DataTable table2 = new DataTable();
                adapter2.Fill(table2);
                table2.TableName = "spd_LayNoTaiKhoan_1;1";
                _DataSet.Tables.Add(table2);

                SqlDataAdapter adapter3 = new SqlDataAdapter(command3);
                DataTable table3 = new DataTable();
                adapter3.Fill(table3);
                table3.TableName = "spd_LayCoTaiKhoan_1;1";
                _DataSet.Tables.Add(table3);

                SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                DataTable table4 = new DataTable();
                adapter4.Fill(table4);
                table4.TableName = "spd_LayNguoiKyTenCongNo;1";
                _DataSet.Tables.Add(table4);
                Report.SetDataSource(_DataSet);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
                #endregion
            }

        }

        private void InDVKhoanChiTheoMauCu_BangKe()
        {
            frmXemIn f = new frmXemIn();


            Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;

            rpt.ReportEmbeddedResource = "PSC_ERP.Report.CongNo.rpBangKe.rdlc";
            BangKeList bangkelist = ERP_Library.BangKeList.GetBangKeList(_ChungTu.MaChungTu);

            rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_BangKeList", bangkelist));

            f.SetParameter("TenBoPhan", BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);

            f.SetParameter("TieuDeReport", "PHIẾU KẾ TOÁN ");
            ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);

            //string ngay ="";// "Tp.HCM, Ngày " + _ChungTu.NgayLap.Day+ " tháng " + _ChungTu.NgayLap.Month.ToString() + " năm " + _ChungTu.NgayLap.Year.ToString();
            //f.SetParameter("Ngay", ngay);
            if (ERP_Library.Security.CurrentUser.Info.MaCongTy != 1)
            {
                f.SetNguoiKyTongHopBangKe(2, _ChungTu.NgayLap.Value);
            }
            else if (ERP_Library.Security.CurrentUser.Info.MaCongTy == 1 & ERP_Library.Security.CurrentUser.Info.MaBoPhan != 9)
            {
                f.SetNguoiKyTongHopBangKe(10, _ChungTu.NgayLap.Value);
            }
            else
            {
                f.SetNguoiKyTongHop(3);
            }

            f.Show(this);
            return;
        }

        private void InMauA4_BangKe()
        {
            LoaiInBangKe(4);
        }
        private void InMauA5_BangKe()
        {
            LoaiInBangKe(5);
        }
        private void InMauA4_PhieuThu()
        {
            LoaiInPhieuThu(4);
        }
        private void InMauA5_PhieuThu()
        {
            LoaiInPhieuThu(5);
        }

        private void InMauA4_PhieuChi()
        {
            LoaiInPhieuChi(4);
        }
        private void InMauA5_PhieuChi()
        {
            LoaiInPhieuChi(5);
        }

        #endregion//InTheoPhieuCu
        #endregion

        #region eventHandle

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
            if (gridView_ButToan.FocusedColumn.Name == "colChungTu_HoaDon")
            {
                ClickDSHoaDon();
            }

            else if (gridView_ButToan.FocusedColumn.Name == "colCT_ChiPhiSX")
            {
                ClickChiPhiSX();

            }
            else if (gridView_ButToan.FocusedColumn.FieldName == "NoTaiKhoan" || gridView_ButToan.FocusedColumn.FieldName == "CoTaiKhoan")
            {
                #region Tạm ứng
                tblButToan currentButToan = this.gridView_ButToan.GetFocusedRow() as tblButToan;
                if (currentButToan != null)
                {
                    if (gridView_ButToan.FocusedColumn.Name == "colNoTaiKhoan")
                    {
                        string TKNo = "";
                        if (currentButToan.NoTaiKhoan != null)
                        {
                            TKNo = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(currentButToan.NoTaiKhoan ?? 0).SoHieuTK;
                        }
                        if (TKNo.StartsWith("312"))
                        {

                            PSC_ERP.ThuChiEntity.frmTamUng _frmTamUng = new PSC_ERP.ThuChiEntity.frmTamUng(_factory.Context, _ChungTu);
                            _frmTamUng.Show(this);

                        }
                        //else if (clickButtoan && handlefocus && gridView_ButToan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit == true)
                        //{
                        //    gridView_ButToan.ShowEditor();
                        //    ((GridLookUpEdit)gridView_ButToan.ActiveEditor).ShowPopup();
                        //}
                    }
                    else if (gridView_ButToan.FocusedColumn.Name == "colCoTaiKhoan")
                    {
                        string TKCo = "";


                        if (currentButToan.CoTaiKhoan != null)
                        {
                            TKCo = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(currentButToan.CoTaiKhoan ?? 0).SoHieuTK;
                        }
                        if (TKCo.StartsWith("312"))
                        {

                            PSC_ERP.ThuChiEntity.frmTamUng _frmTamUng = new PSC_ERP.ThuChiEntity.frmTamUng(_factory.Context, _ChungTu);
                            _frmTamUng.Show(this);

                        }
                        //else if (clickButtoan && handlefocus && gridView_ButToan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit == true)
                        //{
                        //    gridView_ButToan.ShowEditor();
                        //    ((GridLookUpEdit)gridView_ButToan.ActiveEditor).ShowPopup();
                        //}
                    }
                }
                #endregion Hết tạm ứng
            }
            //else
            //{
            //    if (clickButtoan)
            //    {
            //        if (e.Column.FieldName == "MaDoiTuongNo"
            //            || e.Column.FieldName == "MaDoiTuongCo"
            //            || e.Column.FieldName == "MaHopDong"
            //            )
            //        {
            //            if (handlefocus && gridView_ButToan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit == true)
            //            {
            //                gridView_ButToan.ShowEditor();
            //                ((GridLookUpEdit)gridView_ButToan.ActiveEditor).ShowPopup();
            //            }
            //        }
            //    }
            //}//
            handlefocus = true;
        }

        private void gridView_ButToan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (_isCellValuechangeBT == false) return;
            tblButToan currentButToan = (tblButToan)tblButToanBindingSource.Current;
            if (gridView_ButToan.FocusedColumn.Name == "colNoTaiKhoan" || gridView_ButToan.FocusedColumn.Name == "colCoTaiKhoan")
            {
                #region BS Kiem Tra Khoa So TaiKhoan
                //
                if (KhoaButToanTheoTaiKhoan(currentButToan.NoTaiKhoan ?? 0) || KhoaButToanTheoTaiKhoan(currentButToan.CoTaiKhoan ?? 0))
                {
                    _isCellValuechangeBT = false;
                    MessageBox.Show(this, "Đã khóa sổ tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    currentButToan.NoTaiKhoan = null;
                    currentButToan.CoTaiKhoan = null;
                    _isCellValuechangeBT = true;
                }
                // 
                #endregion//BS Kiem Tra Khoa So TaiKhoan
                bool NocoThue = false;
                bool CocoThue = false;
                tblTaiKhoan taiKhoanNo = null;
                tblTaiKhoan taiKhoanCo = null;
                if (currentButToan.NoTaiKhoan != null && currentButToan.NoTaiKhoan != 0)
                {
                    taiKhoanNo = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(currentButToan.NoTaiKhoan ?? 0);
                    if (taiKhoanNo != null && taiKhoanNo.SoHieuTK.StartsWith("31131"))
                        NocoThue = true;
                }
                if (currentButToan.CoTaiKhoan != null)
                {
                    taiKhoanCo = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(currentButToan.CoTaiKhoan ?? 0);
                    if (taiKhoanCo != null && taiKhoanCo.SoHieuTK.StartsWith("31131"))
                        CocoThue = true;
                }

                ////Xu Ly Dien Giai
                //if (NocoThue || CocoThue)
                //{
                //    currentButToan.DienGiai = "Thuế GTGT Được Khấu Trừ Của Hàng Hóa, Dịch Vụ";
                //}
                //Xu ly Doi Tuong No Co
                if (taiKhoanNo != null)
                {
                    currentButToan.MaDoiTuongNo = 0;
                    if (taiKhoanNo.CoDoiTuongTheoDoi == true)
                    {
                        loadDoiTuongNoTheoTaiKhoan(currentButToan.NoTaiKhoan ?? 0);
                        if (KiemTraDoiTuongNoTrongDoiTuongTheoDoi(_ChungTu.MaDoiTuong ?? 0))
                        {
                            currentButToan.MaDoiTuongNo = _ChungTu.MaDoiTuong;
                        }
                    }
                    else
                    {
                        _DoiTuongNoList = new List<sp_AllDoiTuong_Result>(); //_DoiTuongThuChiList;
                        DoiTuongNoList_BindingSource.DataSource = _DoiTuongNoList;
                    }


                }

                if (taiKhoanCo != null)
                {
                    currentButToan.MaDoiTuongCo = 0;
                    if (taiKhoanCo.CoDoiTuongTheoDoi == true)
                    {
                        loadDoiTuongCoTheoTaiKhoan(currentButToan.CoTaiKhoan ?? 0);
                        if (KiemTraDoiTuongCoTrongDoiTuongTheoDoi(_ChungTu.MaDoiTuong ?? 0))
                        {
                            currentButToan.MaDoiTuongCo = _ChungTu.MaDoiTuong;
                        }
                    }
                    else
                    {
                        _DoiTuongCoList = new List<sp_AllDoiTuong_Result>();//_DoiTuongThuChiList;
                        DoiTuongCoList_BindingSource.DataSource = _DoiTuongCoList;//_DoiTuongCoList;
                    }
                }

                #region Tạm ứng
                if (gridView_ButToan.FocusedColumn.Name == "colNoTaiKhoan")
                {
                    string TKNo = "";
                    if (currentButToan.NoTaiKhoan != null)
                    {
                        TKNo = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(currentButToan.NoTaiKhoan ?? 0).SoHieuTK;
                    }
                    if (TKNo.StartsWith("312"))
                    {
                        if (_ChungTu.MaDoiTuong != null)
                        {
                            PSC_ERP.ThuChiEntity.frmTamUng _frmTamUng = new PSC_ERP.ThuChiEntity.frmTamUng(_factory.Context, _ChungTu);
                            _frmTamUng.Show(this);
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập đối tượng tạm ứng!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                }
                else if (gridView_ButToan.FocusedColumn.Name == "colCoTaiKhoan")
                {
                    string TKCo = "";


                    if (currentButToan.CoTaiKhoan != null)
                    {
                        TKCo = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(currentButToan.CoTaiKhoan ?? 0).SoHieuTK;
                    }
                    if (TKCo.StartsWith("312"))
                    {
                        if (_ChungTu.MaDoiTuong != null)
                        {

                            PSC_ERP.ThuChiEntity.frmTamUng _frmTamUng = new PSC_ERP.ThuChiEntity.frmTamUng(_factory.Context, _ChungTu);
                            _frmTamUng.Show(this);
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập đối tượng tạm ứng!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                }


                #endregion Hết tạm ứng
            }
        }

        private void gridView_ButToan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                TaoButToanDeleteList();
            }

        }

        private void gridView_ButToan_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {

            decimal sotien = Convert.ToDecimal(calcEdit_ThanhTien.EditValue);


            #region New
            tblButToan buttoan = this.gridView_ButToan.GetRow(e.RowHandle) as tblButToan;
            if (buttoan != null)
            {
                foreach (tblButToan bt in _ChungTu.tblDinhKhoan.tblButToans)
                {

                    if (sotien != bt.SoTien)
                        sotien -= bt.SoTien;
                    else if (sotien == bt.SoTien)
                        sotien = 0;
                }
                if (_ChungTu.tblDinhKhoan.tblButToans.Count > 0 && sotien != 0)
                {
                    tblButToan previousBt = _ChungTu.tblDinhKhoan.tblButToans.LastOrDefault();
                    buttoan.NoTaiKhoan = previousBt.NoTaiKhoan;
                    buttoan.CoTaiKhoan = previousBt.CoTaiKhoan;
                    buttoan.SoTien = sotien;
                    buttoan.MaDoiTuongCo = previousBt.MaDoiTuongCo;
                    buttoan.MaDoiTuongNo = previousBt.MaDoiTuongNo;
                    buttoan.DienGiai = previousBt.DienGiai;
                    buttoan.MaHopDong = previousBt.MaHopDong;
                }
                else if (sotien !=0)
                {
                    SetTaiKhoanDefaultForNewFirstButtoan(buttoan);
                    buttoan.SoTien = sotien;
                    buttoan.DienGiai = txt_DienGiai.EditValue.ToString();
                }


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

        private void gridView_DSDeNghi_KeyDown(object sender, KeyEventArgs e)
        {
            HamDungChung.DeleteSelectedRowsGridViewDev(gridView_DSDeNghi, e);

        }

        private void gridView_DanhSachChungTu_ChiTiet_DoubleClick(object sender, EventArgs e)
        {
            tblChungTu chungTu1 = tblChungTubindingSource_ListChiTiet.Current as tblChungTu;
            if (chungTu1 != null)
            {
                LoadChungTuCu(chungTu1.MaChungTu);
                _taoMoiChungTu = false;//
                xtraTabControl1.SelectedTabPage = xtraTabPage1;
            }
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

        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (gridView_ButToan.FocusedColumn == gridView_ButToan.Columns.ColumnByName("colCT_ChiPhiSX"))
                {
                    ClickChiPhiSX();
                }
                else if (gridView_ButToan.FocusedColumn == gridView_ButToan.Columns.ColumnByName("colCT_ChiPhiSX"))
                {
                    ClickDSHoaDon();
                }
                else if (KiemTraCoTKTamUng())
                {
                    PSC_ERP.ThuChiEntity.frmTamUng _frmTamUng = new PSC_ERP.ThuChiEntity.frmTamUng(_factory.Context, _ChungTu);
                    _frmTamUng.Show(this);
                }
                else
                {

                    gridView_ButToan.PostEditor();
                    gridView_ButToan.UpdateCurrentRow();
                    handlefocus = false;//
                    gridView_ButToan.FocusedColumn = gridView_ButToan.VisibleColumns[0];

                    decimal sotien = Convert.ToDecimal(calcEdit_ThanhTien.EditValue);
                    foreach (tblButToan bt in _ChungTu.tblDinhKhoan.tblButToans)
                    {

                        if (sotien != bt.SoTien)
                            sotien -= bt.SoTien;
                        else if (sotien == bt.SoTien)
                            sotien = 0;
                    }
                    if (sotien !=0)
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

        private void gridView_ButToan_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (clickButtoan)
            {
                if (e.FocusedColumn.FieldName == "NoTaiKhoan"
                    || e.FocusedColumn.FieldName == "CoTaiKhoan"
                    || e.FocusedColumn.FieldName == "MaDoiTuongNo"
                    || e.FocusedColumn.FieldName == "MaDoiTuongCo"
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

        private void ChungTu_HoaDongridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (CheckCoTaiKhoanBiKhoaTrongButToan())
                {
                    MessageBox.Show(this, "Đã khóa sổ tài khoản, không thể thực hiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                XoaChungTu_HoaDon();
                //HamDungChung.DeleteSelectedRowsGridViewDev(ChungTu_HoaDongridView, e);
            }
        }

        private void ChungTu_HoaDongridView_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            if (CheckCoTaiKhoanThueTrongButToan() == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn tài khoản thuế 3113 hay 3337....", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (CheckCoTaiKhoanBiKhoaTrongButToan())
            {
                MessageBox.Show(this, "Đã khóa sổ tài khoản, không thể thực hiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (CheckCoTaiKhoanThueTrongButToan() == 1)
            {
                ChungTu chungtuforHD = ChungTu.NewChungTu();
                chungtuforHD.SoChungTu = _ChungTu.SoChungTu;
                chungtuforHD.NgayLap = _ChungTu.NgayLap.Value;
                chungtuforHD.SoTien = _ChungTu.SoTien;

                foreach (tblButToan tblbt in _ChungTu.tblDinhKhoan.tblButToans)
                {
                    if (IsTaiKhoanThue(tblbt.NoTaiKhoan))
                    {
                        ButToan buttoan = ButToan.NewButToan(tblbt.NoTaiKhoan.Value, tblbt.CoTaiKhoan.Value, tblbt.SoTien, tblbt.DienGiai, tblbt.MaDoiTuongNo.Value, tblbt.MaDoiTuongCo.Value);
                        foreach (tblChungTu_HoaDon cthd in tblbt.tblChungTu_HoaDon)
                        {
                            ChungTu_HoaDon chungtuHoaDon = ChungTu_HoaDon.NewChungTu_HoaDon();
                            chungtuHoaDon.MaHoaDon = cthd.MaHoaDon;
                            chungtuHoaDon.MaPhieuNhapXuat = cthd.MaPhieuNhapXuat.Value;
                            chungtuHoaDon.SoTien = cthd.SoTien;
                            chungtuHoaDon.NgayLap = cthd.NgayLap.Value;
                            buttoan.ChungTu_HoaDonList.Add(chungtuHoaDon);
                        }
                        chungtuforHD.DinhKhoan.ButToan.Add(buttoan);
                        frmDanhSachHoaDonDichVu frm = new frmDanhSachHoaDonDichVu(chungtuforHD, buttoan, true);
                        if (frm.ShowDialog() != DialogResult.OK)
                        {
                            if (frm.Luu)
                            {
                                TaoChungTuHoaDonForButToan(frm._bt.ChungTu_HoaDonList, tblbt);
                            }
                        }
                        //frm.ShowDialog();
                    }
                }

            }
            else if (CheckCoTaiKhoanThueTrongButToan() == 2)
            {
                ChungTu chungtuforHD = ChungTu.NewChungTu();
                chungtuforHD.SoChungTu = _ChungTu.SoChungTu;
                chungtuforHD.NgayLap = _ChungTu.NgayLap.Value;
                chungtuforHD.SoTien = _ChungTu.SoTien;

                foreach (tblButToan tblbt in _ChungTu.tblDinhKhoan.tblButToans)
                {
                    if (IsTaiKhoanThue(tblbt.NoTaiKhoan) || IsTaiKhoanThue(tblbt.CoTaiKhoan))
                    {
                        ButToan buttoan = ButToan.NewButToan(tblbt.NoTaiKhoan.Value, tblbt.CoTaiKhoan.Value, tblbt.SoTien, tblbt.DienGiai, tblbt.MaDoiTuongNo.Value, tblbt.MaDoiTuongCo.Value);
                        foreach (tblChungTu_HoaDon cthd in tblbt.tblChungTu_HoaDon)
                        {
                            ChungTu_HoaDon chungtuHoaDon = ChungTu_HoaDon.NewChungTu_HoaDon();
                            chungtuHoaDon.MaHoaDon = cthd.MaHoaDon;
                            chungtuHoaDon.MaPhieuNhapXuat = cthd.MaPhieuNhapXuat.Value;
                            chungtuHoaDon.SoTien = cthd.SoTien;
                            chungtuHoaDon.NgayLap = cthd.NgayLap.Value;
                            buttoan.ChungTu_HoaDonList.Add(chungtuHoaDon);
                        }
                        chungtuforHD.DinhKhoan.ButToan.Add(buttoan);
                        frmDanhSachHoaDonDichVu frm = new frmDanhSachHoaDonDichVu(chungtuforHD, buttoan.ChungTu_HoaDonList, buttoan, true, true);
                        if (frm.ShowDialog() != DialogResult.OK)
                        {
                            if (frm.Luu)
                            {
                                TaoChungTuHoaDonForButToan(frm._bt.ChungTu_HoaDonList, tblbt);
                            }
                        }
                        //frm.ShowDialog();
                    }
                }
            }

        }

        private void ChungTu_HoaDongridView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (ChungTu_HoaDongridView.IsNewItemRow(e.RowHandle))
            {
                if (ChungTu_HoaDongridView.GetRow(e.RowHandle) == null)
                    if (ChungTu_HoaDongridView.FocusedColumn.Name == "coltblHoaDon.GhiChu")//"colChungTu_HoaDon")
                    {
                        //ClickDSHoaDon();
                        #region XuLy
                        if (CheckCoTaiKhoanThueTrongButToan() == 0)
                        {
                            MessageBox.Show(this, "Vui lòng chọn tài khoản thuế 3113 hay 3337....", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else if (CheckCoTaiKhoanThueTrongButToan() == 1)
                        {
                            ChungTu chungtuforHD = ChungTu.NewChungTu();
                            chungtuforHD.MaChungTu = 1;
                            chungtuforHD.SoChungTu = _ChungTu.SoChungTu;
                            chungtuforHD.NgayLap = _ChungTu.NgayLap.Value;
                            chungtuforHD.SoTien = _ChungTu.SoTien;
                            chungtuforHD.DoiTuong = _ChungTu.MaDoiTuong ?? 0;
                            int keyMaBT = 0;
                            bool isNocoTHue = false;
                            tblButToan tblbtCoThue = new tblButToan(); ;
                            foreach (tblButToan tblbt in _ChungTu.tblDinhKhoan.tblButToans)
                            {
                                tblTaiKhoan tk = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(tblbt.NoTaiKhoan ?? 0);
                                tblTaiKhoan tkco = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(tblbt.CoTaiKhoan ?? 0);
                                keyMaBT += 1;
                                isNocoTHue = IsTaiKhoanThue(tblbt.NoTaiKhoan);
                                ButToan buttoan = ButToan.NewButToan();
                                buttoan.MaButToan = keyMaBT;
                                buttoan.NoTaiKhoan = tblbt.NoTaiKhoan ?? 0;
                                buttoan.SoHieuTKNo = tk.SoHieuTK;
                                buttoan.CoTaiKhoan = tblbt.CoTaiKhoan ?? 0;
                                buttoan.SoHieuTKCo = tkco.SoHieuTK;
                                buttoan.SoTien = tblbt.SoTien;
                                buttoan.DienGiai = tblbt.DienGiai;
                                buttoan.DoiTuongNo = tblbt.MaDoiTuongNo ?? 0;
                                buttoan.DoiTuongCo = tblbt.MaDoiTuongCo ?? 0;
                                if (isNocoTHue)
                                {
                                    tblbtCoThue = tblbt;
                                    foreach (tblChungTu_HoaDon cthd in tblbt.tblChungTu_HoaDon)
                                    {
                                        ChungTu_HoaDon chungtuHoaDon = ChungTu_HoaDon.NewChungTu_HoaDon();
                                        chungtuHoaDon.MaHoaDon = cthd.MaHoaDon;
                                        chungtuHoaDon.MaPhieuNhapXuat = cthd.MaPhieuNhapXuat ?? 0;
                                        chungtuHoaDon.SoTien = cthd.SoTien;
                                        chungtuHoaDon.NgayLap = cthd.NgayLap.Value;
                                        buttoan.ChungTu_HoaDonList.Add(chungtuHoaDon);
                                    }
                                }
                                chungtuforHD.DinhKhoan.ButToan.Add(buttoan);
                            }
                            foreach (ButToan buttoan in chungtuforHD.DinhKhoan.ButToan)
                            {
                                isNocoTHue = IsTaiKhoanThue(buttoan.NoTaiKhoan);
                                if (isNocoTHue)
                                {

                                    frmDanhSachHoaDonDichVu frm = new frmDanhSachHoaDonDichVu(chungtuforHD, buttoan, true);
                                    if (frm.ShowDialog() != DialogResult.OK)
                                    {
                                        if (frm.Luu)
                                        {
                                            TaoChungTuHoaDonForButToan(frm._bt.ChungTu_HoaDonList, tblbtCoThue);
                                        }
                                    }
                                    //frm.ShowDialog();
                                }
                            }

                        }
                        else if (CheckCoTaiKhoanThueTrongButToan() == 2)
                        {
                            ChungTu chungtuforHD = ChungTu.NewChungTu();
                            chungtuforHD.MaChungTu = 1;
                            chungtuforHD.SoChungTu = _ChungTu.SoChungTu;
                            chungtuforHD.NgayLap = _ChungTu.NgayLap.Value;
                            chungtuforHD.SoTien = _ChungTu.SoTien;
                            chungtuforHD.DoiTuong = _ChungTu.MaDoiTuong ?? 0;
                            int keyMaBT = 0;
                            bool isNocoTHue = false;
                            tblButToan tblbtCoThue = new tblButToan(); ;
                            foreach (tblButToan tblbt in _ChungTu.tblDinhKhoan.tblButToans)
                            {
                                tblTaiKhoan tk = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(tblbt.NoTaiKhoan ?? 0);
                                tblTaiKhoan tkco = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(tblbt.CoTaiKhoan ?? 0);
                                keyMaBT += 1;
                                isNocoTHue = IsTaiKhoanThue(tblbt.NoTaiKhoan);
                                ButToan buttoan = ButToan.NewButToan();
                                buttoan.MaButToan = keyMaBT;
                                buttoan.NoTaiKhoan = tblbt.NoTaiKhoan ?? 0;
                                buttoan.SoHieuTKNo = tk.SoHieuTK;
                                buttoan.CoTaiKhoan = tblbt.CoTaiKhoan ?? 0;
                                buttoan.SoHieuTKCo = tkco.SoHieuTK;
                                buttoan.SoTien = tblbt.SoTien;
                                buttoan.DienGiai = tblbt.DienGiai;
                                buttoan.DoiTuongNo = tblbt.MaDoiTuongNo ?? 0;
                                buttoan.DoiTuongCo = tblbt.MaDoiTuongCo ?? 0;
                                if (isNocoTHue)
                                {
                                    tblbtCoThue = tblbt;
                                    foreach (tblChungTu_HoaDon cthd in tblbt.tblChungTu_HoaDon)
                                    {
                                        ChungTu_HoaDon chungtuHoaDon = ChungTu_HoaDon.NewChungTu_HoaDon();
                                        chungtuHoaDon.MaHoaDon = cthd.MaHoaDon;
                                        chungtuHoaDon.MaPhieuNhapXuat = cthd.MaPhieuNhapXuat ?? 0;
                                        chungtuHoaDon.SoTien = cthd.SoTien;
                                        chungtuHoaDon.NgayLap = cthd.NgayLap.Value;
                                        buttoan.ChungTu_HoaDonList.Add(chungtuHoaDon);
                                    }
                                }
                                chungtuforHD.DinhKhoan.ButToan.Add(buttoan);
                            }
                            foreach (ButToan buttoan in chungtuforHD.DinhKhoan.ButToan)
                            {
                                isNocoTHue = (IsTaiKhoanThue(buttoan.NoTaiKhoan) || IsTaiKhoanThue(buttoan.CoTaiKhoan));
                                if (isNocoTHue)
                                {

                                    frmDanhSachHoaDonDichVu frm = new frmDanhSachHoaDonDichVu(chungtuforHD, buttoan.ChungTu_HoaDonList, buttoan, true, true);
                                    if (frm.ShowDialog() != DialogResult.OK)
                                    {
                                        if (frm.Luu)
                                        {
                                            TaoChungTuHoaDonForButToan(frm._bt.ChungTu_HoaDonList, tblbtCoThue);
                                        }
                                    }
                                    //frm.ShowDialog();
                                }
                            }
                        }
                        #endregion //XuLy
                    }
            }

        }
        #endregion

        #region Initialize
        public frmBangKeE()
        {
            InitializeComponent();
            //Tab1_xtraTabPage2.PageVisible = false;
            //xtraTabPage2.PageVisible = false;//Ẩn Tab Danh Sách Chứng Từ
        }

        public frmBangKeE(tblChungTu chungTu)
        {
            _maLoaiChungTu = chungTu.MaLoaiChungTu;
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
            _maLoaiChungTu = 16;//Bảng kê
            FormatForm();
            _taoMoiChungTu = true;
            KhoiTao();
            LoadDaTa();
            this.Show();
        }
        public void ShowPhieuThu()
        {
            _maLoaiChungTu = 2;//Phiếu Thu
            FormatForm();
            _taoMoiChungTu = true;
            KhoiTao();
            LoadDaTa();
            this.Show();
        }

        public void ShowPhieuChi()
        {
            _maLoaiChungTu = 3;//Phiếu Chi
            FormatForm();
            _taoMoiChungTu = true;
            KhoiTao();
            LoadDaTa();
            this.Show();
        }
        #endregion//Initialize

        #region Events

        //private void cmbu_TaiKhoanNC_ValueChanged(object sender, EventArgs e)
        //{
        //    if (_daLoadXong)
        //    {
        //        FormatControlTaiKhoanvaDoiTuongNoCo();
        //    }

        //}

        private void frmBangKeE_Load(object sender, EventArgs e)
        {
            if (_taoMoiChungTu)
            {

                KhoiTaoChungTuMoi();
            }
            else
            {
                LoadChungTuCu(_maChungTuGhiTangCuCanXemLai);
            }

            Check_chkKhachHangClick();
        }

        private void btn_DoiTuong_Click(object sender, EventArgs e)
        {
            frmTimKhachHang _frmKH = new frmTimKhachHang();
            if (_frmKH.ShowDialog(this) != DialogResult.OK)
            {
                if (_frmKH._maDoiTuong != 0)
                {

                    _maDoiTuong = _frmKH._maDoiTuong;
                    dtKhachHang = _factory.Context.sp_AllDoiTuong(0).Where(x => x.MaDoiTuong == _maDoiTuong).First(); ;
                    txt_TenDoiTuongNhan.Text = dtKhachHang.MaQLDoiTuong + " - " + dtKhachHang.TenDoiTuong;
                    txt_DiaChiDoiTuongNhan.Text = dtKhachHang.DiaChi;
                    //maLoaiDoiTuong = ;
                    _ChungTu.MaDoiTuong = _maDoiTuong;


                    _hopDongList = HopDong_Factory.New().GetAll().Where(x => x.MaDoiTac.Value == _maDoiTuong && x.DaThanhToan.Value == 0).ToList();
                    tblHopDong hopDong_khongChon = new tblHopDong() { MaHopDong = 0, TenHopDong = "<<Không chọn>>" };
                    hopDong_khongChon.tblHopDongMuaBan = new tblHopDongMuaBan() { SoHopDong = "<<Không chọn>>" };
                    _hopDongList.Insert(0, hopDong_khongChon);
                    HopDong_bindingSource.DataSource = _hopDongList;
                }
            }
            else
            {
                _maLoaiDoiTuong = 0;
            }
        }

        private void chkKhachHang_Click(object sender, EventArgs e)
        {
            Check_chkKhachHangClick();
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhoiTaoChungTuMoi();
            Check_chkKhachHangClick();
            _taoMoiChungTu = true;//
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textBoxFocus1.Focus();
            grdLU_MaDoiTuongThuChi.Focus();

            if (_taoMoiChungTu == false && _maLoaiChungTu != 16 && KiemTraSoQuy() == false)
            {
                return;
            }
            if (_taoMoiChungTu == true && CheckCoTaiKhoanBiKhoaTrongButToan())
            {
                MessageBox.Show(this, "Đã khóa sổ tài khoản, không thể lưu ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ;
            }
            if (this.Save())
            {
                btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }

        private void btnXoaChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (KhoaSo())
            {
                MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_taoMoiChungTu == false && _maLoaiChungTu != 16 && KiemTraSoQuy() == false)
            {
                return;
            }
            if (CheckCoTaiKhoanBiKhoaTrongButToan())
            {
                MessageBox.Show(this, "Đã khóa sổ Tài Khoản,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //yêu cầu người dùng xác nhận xóa
            DialogResult dlgResult = MessageBox.Show("Bạn thật sự muốn xóa chứng từ này?", "Hộp Thoại Xác Nhận!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlgResult == DialogResult.Yes)
            {
                if (DeleteChungTu())
                {
                    btnThemMoi.PerformClick();
                }
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void tlslblThemDN_Click(object sender, EventArgs e)
        {
            if (_ChungTu.tblChungTu_DeNghiChuyenKhoan.Count == 0 && _ChungTu.tblChungTu_GiayBaoCo.Count == 0 && _ChungTu.tblChungTu_LenhChuyenTien.Count == 0 && _ChungTu.tblChungTu_GiayBanNT.Count == 0 && _ChungTu.tblChungTu_UyNhiemChi.Count == 0 && _ChungTu.tblChungTu_GiayRutTien.Count == 0)
            {
                _ChungTu.LoaiChungTu = 0;
            }
            frmChonDeNghiChuyenKhoan frm = new frmChonDeNghiChuyenKhoan(_factory.Context, _ChungTu, _user.UserID);
            frm.ShowDialog();
            if (frm.Save)
            {
                _maDoiTuong = _ChungTu.MaDoiTuong == null ? 0 : _ChungTu.MaDoiTuong.Value;
                GanDuLieuChoTextDoiTac();
                dtmp_Ngay.EditValue = _ChungTu.NgayLap.Value;
                TaoBindingDeNghiChuyenKhoan();
            }
        }

        private void btnDSChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //_maLoaiChungTu = 16;
            //frmTimDanhSachChungTu.ShowSingleton(null, this.MdiParent);
            #region Old
            //frmTimDanhSachChungTu f = new frmTimDanhSachChungTu(_maLoaiChungTu);
            frmDanhSachChungTuCanTim f = new frmDanhSachChungTuCanTim(_maLoaiChungTu);
            f.StartPosition = FormStartPosition.CenterScreen;
            //f.MdiParent = this.MdiParent;
            if (f.ShowDialog() != DialogResult.OK)
            {
                if (f.DaChon == true)
                {
                    LoadChungTuCu(f.MaChungTu);
                    _taoMoiChungTu = false;//
                }

            }
            #endregion//Old

        }

        private void btnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PSC_ERPNew.Main.Sys.frmEntityTrackingLog.ShowSingleton(null, BusinessCodeEnum.BangKe_ThuChi, this.MdiParent);
        }

        private void txt_DienGiai_Enter(object sender, EventArgs e)
        {
            txt_DienGiai.SelectAll();
        }

        private void txt_TenDoiTuongNhan_Enter(object sender, EventArgs e)
        {
            txt_TenDoiTuongNhan.SelectAll();
        }

        private void txt_DiaChiDoiTuongNhan_Enter(object sender, EventArgs e)
        {
            txt_DiaChiDoiTuongNhan.SelectAll();
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

        private void btnInDVKhoanChi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InDVKhoanChiTheoMauCu_BangKe();
        }

        private void btnPrintA4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region InTheoPhieuCu
            //if (_maLoaiChungTu == 16)//Bảng Kê
            //{
            //    InMauA4_BangKe(); 
            //}
            //else if (_maLoaiChungTu == 2)//Phiếu Thu
            //{
            //    InMauA4_PhieuThu();
            //}
            //else if (_maLoaiChungTu == 3)//Phiếu Chi
            //{
            //    InMauA4_PhieuChi();
            //}
            #endregion//InTheoPhieuCu
            #region Devexpress
            if (_maLoaiChungTu == 16)//Bảng Kê
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
            else if (_maLoaiChungTu == 2)//Phiếu Thu
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
            else if (_maLoaiChungTu == 3)//Phiếu Chi
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
            #region InTheoPhieuCu
            //if (_maLoaiChungTu == 16)//Bảng Kê
            //{
            //    InMauA5_BangKe();
            //}
            //else if (_maLoaiChungTu == 2)//Phiếu Thu
            //{
            //    InMauA5_PhieuThu();
            //}
            //else if (_maLoaiChungTu == 3)//Phiếu Chi
            //{
            //    InMauA5_PhieuChi();
            //}
            #endregion//InTheoPhieuCu

            #region Devexpress
            if (_maLoaiChungTu == 16)//Bảng Kê
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
            else if (_maLoaiChungTu == 2)//Phiếu Thu
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
            else if (_maLoaiChungTu == 3)//Phiếu Chi
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

        private void btnDanhSachVanBan_Click(object sender, EventArgs e)
        {
            if (_ChungTu != null && _ChungTu.MaChungTu != 0)
            {
                List<DigitizingBag> dsFilePreView = new List<DigitizingBag>();
                dsFilePreView = DigitizingBag_Factory.New().LayFileTheoMaChungTu_SoChungTu(_ChungTu.MaChungTu, _ChungTu.SoChungTu).ToList();
                if (dsFilePreView != null && dsFilePreView.Count > 0)
                {
                    using (frmDigitizing_Find_and_PreViewFile frm = new frmDigitizing_Find_and_PreViewFile(dsFilePreView))
                    {
                        frm.WindowState = FormWindowState.Maximized;
                        frm.Text = "Bạn Đang Xem File " + dsFilePreView[0].Name;
                        if (dsFilePreView.Count == 1)
                        {
                            frm.splitContainerControl1.Panel1.Hide();
                            frm.splitContainerControl1.SplitterPosition = 0;
                            frm.splitContainerControl1.IsSplitterFixed = true;
                        }
                        else
                        {
                            frm.groupControl_TimKiem.Visible = false;
                            frm.groupControl_TimKiem.Size = new System.Drawing.Size(0, 0);

                            frm.splitContainerControl2.Panel1.Hide();
                            frm.splitContainerControl2.SplitterPosition = 0;
                            frm.splitContainerControl2.IsSplitterFixed = true;
                        }
                        frm.ShowDialog();
                    }

                }
                else
                {
                    DialogUtil.ShowWarning("Chứng từ chưa được scan File \nVui lòng thực hiện nghiệp vụ số hóa");
                }
            }
            else
            {
                MessageBox.Show("Chọn chứng từ cần xem.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
            {
                _selectIndexTabControl = 1;
                ShoworHideButtonMenu(true);
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
            {
                _selectIndexTabControl = 2;
                LoadTemplateForTabDanhSachChungTu();
                ShoworHideButtonMenu(false);
                _selectedTabPage2 = true;
            }
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            TimDanhSachChungTu_ChiTiet();
            //GridUtil.InitDetailForGridView<tblChungTu>(gridView_DanhSachChungTu_ChiTiet, tblChungTu.tblChungTu_TheoDoi_EntityCollectionPropertyName, 0, 1);
            ////DesignGrid_Tab2_GridViewDinhKhoanChild();
            //GridUtil.InitDetailForGridView<tblDinhKhoan>(gridView_DinhKhoanChild, tblDinhKhoan.tblButToans_EntityCollectionPropertyName, 0, 1);
            //DesignGrid_Tab2_GridviewButoanChild();
        }

        private void gridLookUpEditMaChungTuPC_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 9)
                {
                    frmDanhSachPhieuChiforThuThueE frm = new frmDanhSachPhieuChiforThuThueE(_factory.Context, _ChungTu, false);
                    if (frm.ShowDialog() != DialogResult.OK)
                    {
                        if (frm.TrangThai)
                        {
                            //_ChungTu.tblPhieuThutuPhieuChis = frm.PhieuThutuPhieuChiSelectedList;
                            gridLookUpEditMaChungTuPC.Properties.NullText = frm.SoChungtuPhieuChiString;
                            _ChungTu.tblTienTe.SoTien = frm.TongTienChon;
                            _ChungTu.tblTienTe.MaLoaiTien = 1;
                            TienTe_bindingSource.DataSource = _ChungTu.tblTienTe;
                            foreach (var pttupc in frm.PhieuThutuPhieuChiListDelete)
                            {
                                _PhieuThutuPhieuChiListDelete.Add(pttupc);
                            }
                        }

                    }
                }

            }
        }

        private void gridView_DanhSachChungTu_ChiTiet_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
        {
            tblChungTu ct = (tblChungTu)gridView_DanhSachChungTu_ChiTiet.GetRow(e.RowHandle);
            e.IsEmpty = ct.tblDinhKhoan.tblButToans.Count == 0;

        }

        private void gridView_DanhSachChungTu_ChiTiet_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void gridView_DanhSachChungTu_ChiTiet_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "tblDinhKhoan.tblButToans";
        }

        private void gridView_DanhSachChungTu_ChiTiet_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            tblChungTu ct = (tblChungTu)gridView_DanhSachChungTu_ChiTiet.GetRow(e.RowHandle);
            e.ChildList = ct.tblDinhKhoan.tblButToans.ToList<tblButToan>();
            //e.ChildList = new BindingSource(ct, "tblDinhKhoan.tblButToans");
        }

        private void gridView_ButToanChild_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
        {
            if (gridView_ButToanChild.GetRow(e.RowHandle) != null)
            {
                tblButToan bt = (tblButToan)gridView_ButToanChild.GetRow(e.RowHandle);
                e.IsEmpty = bt.tblCT_ChiPhiSanXuat.Count == 0;
            }
        }

        private void gridView_ButToanChild_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void gridView_ButToanChild_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "tblCT_ChiPhiSanXuat";
        }

        private void gridView_ButToanChild_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            if (gridView_ButToanChild.GetRow(e.RowHandle) != null)
            {
                tblButToan bt = (tblButToan)gridView_ButToanChild.GetRow(e.RowHandle);
                e.ChildList = bt.tblCT_ChiPhiSanXuat.ToList();
            }
        }

        private void dtmp_Ngay_Leave(object sender, EventArgs e)
        {
            if (dtmp_Ngay.OldEditValue != dtmp_Ngay.EditValue)
            {
                CheckValidKhoaTaiKhoanWhenChangeNgayCT();
            }
        }

        private void txt_DienGiai_Leave(object sender, EventArgs e)
        {
            UpdateDienGiaiButToan();
        }
        private void txt_DienGiai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateDienGiaiButToan();
            }
        }
        #endregion//Events

        




















    }
}