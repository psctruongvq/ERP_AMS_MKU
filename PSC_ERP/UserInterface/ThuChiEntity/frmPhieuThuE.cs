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
//26_04_2014
namespace PSC_ERP.ThuChiEntity
{
    public partial class frmPhieuThuE : DevExpress.XtraEditors.XtraForm
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
        public int LoaiChi = 0;
        long _maDoiTuong = 0;
        app_users _user;
        int _maCongTy = 0; //ERP_Library.Security.CurrentUser.Info.MaCongTy;
        IQueryable<tblTieuMucNganSach> _TieuMucNganSachList = null;

        //
        private int _maLoaiChungTu;
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
        IQueryable<tblLoaiTien> _LoaiTienList = null;
        IQueryable<tblTaiKhoan> _HeThongTaiKhoan1ListCo, _HeThongTaiKhoanSearchCo, _HeThongTaiKhoanSearchNo, _HeThongTaiKhoan1ListNo;
        IQueryable<tblcnLoaiDoiTuong> _loaiDoiTuongThuChiList = null;
        public static List<spd_DanhSachChiPhiSanXuatTheoThang_Result> _chiThuLaoList_DaChon = null;

        static public int DoiTuongThu_Chi = -1;

        static decimal TongTien = 0;
        static decimal soTien = 0;
        long soChungTu = 0;// dùng cho cập nhật các đề nghị thanh toán, chuyển khoản
        public long MaKhachHang = 0;

        static int Phieu = 2; // PhieuThu = 2; PhieuChi = 3; UyNhiemChi = 6; UyNhiemThu = 7; PhieuChuyenKhoan = 8

        public bool flag = false;

        int maTKNoSearch = 0; int maTKCoSearch = 0;
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

        DataSet dataSet = new DataSet();

        Boolean _daLoadXong = false;
        Boolean _taoMoiChungTu = true;
        DateTime _ngayLapCu;
        long _maChungTuGhiTangCuCanXemLai = 0;
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

        private void ChonNoLoad()
        {
            if (_ChungTu.tblDinhKhoan != null)
            {
                _ChungTu.tblDinhKhoan.LaMotNoNhieuCo = true;
                //cmbu_TaiKhoanNC.Text = "Nợ";
                cmbu_TaiKhoanNC.Value = true;
            }
        }

        private void ChonCoLoad()
        {
            if (_ChungTu.tblDinhKhoan != null)
            {
                _ChungTu.tblDinhKhoan.LaMotNoNhieuCo = false;
                //cmbu_TaiKhoanNC.Text = "Có";
                cmbu_TaiKhoanNC.Value = false;
            }
        }

        public int GetMaTaiKhoan(String soHieuTK)
        {
            foreach (tblTaiKhoan tk in _HeThongTaiKhoan1ListCo)
                if (tk.SoHieuTK == soHieuTK)
                    return tk.MaTaiKhoan;
            return 1;
        }

        private void FormatControlTaiKhoanvaDoiTuongNoCo()
        {
            if (cmbu_TaiKhoanNC.Value != null)
            {
                if ((bool)cmbu_TaiKhoanNC.Value == true)//LaNo
                {
                    //Control TaiKhoan
                    gridView_ButToan.Columns["CoTaiKhoan"].Visible = true;
                    gridView_ButToan.Columns["CoTaiKhoan"].VisibleIndex = 0;
                    gridView_ButToan.Columns["NoTaiKhoan"].Visible = false;
                    grdLU_TaiKhoanCo.Visible = false;
                    grdLU_TaiKhoanCo.EditValue = null;
                    grdLU_TaiKhoanNo.Visible = true;

                    //control Doi Tuong
                    tblTaiKhoanBindingSource_No.DataSource = _HeThongTaiKhoan1ListNo;
                    gridView_ButToan.Columns["MaDoiTuongCo"].Visible = true;
                    gridView_ButToan.Columns["MaDoiTuongCo"].VisibleIndex = 3;
                    gridView_ButToan.Columns["MaDoiTuongNo"].Visible = false;
                    grdLU_DoiTuongCo.Visible = false;
                    grdLU_DoiTuongCo.EditValue = null;
                    grdLU_DoiTuongNo.Visible = true;

                    ResetNullTaiKhoanButToan(true);//LaNo
                }
                else//LaCo
                {
                    //Control TaiKhoan
                    gridView_ButToan.Columns["CoTaiKhoan"].Visible = false;
                    gridView_ButToan.Columns["NoTaiKhoan"].Visible = true;
                    gridView_ButToan.Columns["NoTaiKhoan"].VisibleIndex = 0;
                    grdLU_TaiKhoanCo.Visible = true;
                    grdLU_TaiKhoanNo.Visible = false;
                    grdLU_TaiKhoanNo.EditValue = null;

                    //control Doi Tuong
                    tblTaiKhoanBindingSource_Co.DataSource = _HeThongTaiKhoan1ListCo;
                    gridView_ButToan.Columns["MaDoiTuongNo"].Visible = true;
                    gridView_ButToan.Columns["MaDoiTuongNo"].VisibleIndex = 3;
                    gridView_ButToan.Columns["MaDoiTuongCo"].Visible = false;
                    grdLU_DoiTuongCo.Visible = true;
                    grdLU_DoiTuongNo.Visible = false;
                    grdLU_DoiTuongNo.EditValue = null;

                    ResetNullTaiKhoanButToan(false);//LaCo
                }
            }
        }

        void SetTaiKhoanDefault()
        {

            if (_maCongTy == 2)//HTVC
            {
                grdLU_TaiKhoanNo.EditValue = GetMaTaiKhoan("1111.9");
            }
            else if (_maCongTy == 3)
            {
                grdLU_TaiKhoanNo.EditValue = GetMaTaiKhoan("1111.5");
            }
            else
                grdLU_TaiKhoanNo.EditValue = GetMaTaiKhoan("1111");

        }

        private void DesignGrid_ButToan()
        {
            HamDungChung.InitGridViewDev(gridView_ButToan, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(gridView_ButToan, new string[] { "NoTaiKhoan", "CoTaiKhoan", "SoTien", "DienGiai", "MaDoiTuongNo", "MaDoiTuongCo", "MaHopDong" },
                                new string[] { "Nợ Tài Khoản", "Có Tài Khoản", "Số Tiền", "Diễn Giải", "Đối tượng nợ", "Đối tượng có", "Số hợp đồng" },
                                             new int[] { 100, 100, 100, 150, 100, 100, 100 });

            RepositoryItemButtonEdit ButtonEdit_CongViec_CT = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(ButtonEdit_CongViec_CT)).BeginInit();
            ButtonEdit_CongViec_CT.AutoHeight = false;
            ButtonEdit_CongViec_CT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Công việc/Chương trình", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), new DevExpress.Utils.SerializableAppearanceObject(), "", null, null, true)});
            ButtonEdit_CongViec_CT.Name = "repositoryItemButtonEdit1";
            ButtonEdit_CongViec_CT.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

            //
            RepositoryItemButtonEdit ButtonEdit_DsHoaDon = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(ButtonEdit_DsHoaDon)).BeginInit();
            ButtonEdit_DsHoaDon.AutoHeight = false;
            ButtonEdit_DsHoaDon.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "DS Hóa đơn", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), new DevExpress.Utils.SerializableAppearanceObject(), "", null, null, true)});
            ButtonEdit_DsHoaDon.Name = "repositoryItemButtonEdit2";
            ButtonEdit_DsHoaDon.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

            //add button colCT_ChiPhiSX
            GridColumn colCT_ChiPhiSX = new GridColumn();
            colCT_ChiPhiSX.Caption = "Công việc/Chương trình";
            colCT_ChiPhiSX.ColumnEdit = ButtonEdit_CongViec_CT;
            colCT_ChiPhiSX.Name = "colCT_ChiPhiSX";
            colCT_ChiPhiSX.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colCT_ChiPhiSX.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            colCT_ChiPhiSX.Visible = true;
            colCT_ChiPhiSX.VisibleIndex = 8;
            //add button colChungTu_HoaDon
            GridColumn colChungTu_HoaDon = new GridColumn();
            colChungTu_HoaDon.Caption = "DS Hóa đơn";
            colChungTu_HoaDon.ColumnEdit = ButtonEdit_DsHoaDon;
            colChungTu_HoaDon.Name = "colChungTu_HoaDon";
            colChungTu_HoaDon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colChungTu_HoaDon.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            colChungTu_HoaDon.Visible = true;
            colChungTu_HoaDon.VisibleIndex = 9;

            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ButtonEdit_CongViec_CT, ButtonEdit_DsHoaDon });
            gridView_ButToan.Columns.Add(colCT_ChiPhiSX);
            gridView_ButToan.Columns.Add(colChungTu_HoaDon);

            ((System.ComponentModel.ISupportInitialize)(ButtonEdit_CongViec_CT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ButtonEdit_DsHoaDon)).EndInit();
            //

            HamDungChung.AlignHeaderColumnGridViewDev(gridView_ButToan, new string[] { "NoTaiKhoan", "CoTaiKhoan", "SoTien", "DienGiai", "MaDoiTuongNo", "MaDoiTuongCo", "MaHopDong" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_ButToan, new string[] { "SoTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView_ButToan, new string[] { "SoTien" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(gridView_ButToan);

            Utils.GridUtils.SetSTTForGridView(gridView_ButToan, 50);//M
            //
            RepositoryItemGridLookUpEdit TaiKhoanNo_GrdLU = new RepositoryItemGridLookUpEdit();
            TaiKhoanNo_GrdLU.DataSource = tblTaiKhoanBindingSource_No;
            TaiKhoanNo_GrdLU.DisplayMember = "SoHieuTK";
            TaiKhoanNo_GrdLU.ValueMember = "MaTaiKhoan";
            HamDungChung.InitRepositoryItemGridLookUpDev(TaiKhoanNo_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TaiKhoanNo_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu", "Tên tài khoản" }, new int[] { 100, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "NoTaiKhoan", TaiKhoanNo_GrdLU);
            //
            //
            RepositoryItemGridLookUpEdit TaiKhoanCo_GrdLU = new RepositoryItemGridLookUpEdit();
            TaiKhoanCo_GrdLU.DataSource = tblTaiKhoanBindingSource_Co;
            TaiKhoanCo_GrdLU.DisplayMember = "SoHieuTK";
            TaiKhoanCo_GrdLU.ValueMember = "MaTaiKhoan";
            HamDungChung.InitRepositoryItemGridLookUpDev(TaiKhoanCo_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TaiKhoanCo_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu", "Tên tài khoản" }, new int[] { 100, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "CoTaiKhoan", TaiKhoanCo_GrdLU);
            //
            //
            RepositoryItemGridLookUpEdit DoiTuongNo_grdLU = new RepositoryItemGridLookUpEdit();
            DoiTuongNo_grdLU.DataSource = DoiTuongNoList_BindingSource;
            DoiTuongNo_grdLU.DisplayMember = "TenDoiTuong";
            DoiTuongNo_grdLU.ValueMember = "MaDoiTuong";
            HamDungChung.InitRepositoryItemGridLookUpDev(DoiTuongNo_grdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DoiTuongNo_grdLU, new string[] { "MaQLDoiTuong", "MaSoThue", "TenDoiTuong" }, new string[] { "Mã đối tượng", "Mã số thuế", "Tên đối tượng" }, new int[] { 90, 90, 200 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "MaDoiTuongNo", DoiTuongNo_grdLU);
            //
            //
            RepositoryItemGridLookUpEdit DoiTuongCo_grdLU = new RepositoryItemGridLookUpEdit();
            DoiTuongCo_grdLU.DataSource = DoiTuongCoList_BindingSource;
            DoiTuongCo_grdLU.DisplayMember = "TenDoiTuong";
            DoiTuongCo_grdLU.ValueMember = "MaDoiTuong";
            HamDungChung.InitRepositoryItemGridLookUpDev(DoiTuongCo_grdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DoiTuongCo_grdLU, new string[] { "MaQLDoiTuong", "MaSoThue", "TenDoiTuong" }, new string[] { "Mã đối tượng", "Mã số thuế", "Tên đối tượng" }, new int[] { 90, 90, 200 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "MaDoiTuongCo", DoiTuongCo_grdLU);
            //
            //
            RepositoryItemGridLookUpEdit HopDong_GrdLU = new RepositoryItemGridLookUpEdit();
            HopDong_GrdLU.DataSource = HopDong_bindingSource;
            HopDong_GrdLU.DisplayMember = "tblHopDongMuaBan.SoHopDong";
            HopDong_GrdLU.ValueMember = "MaHopDong";
            HamDungChung.InitRepositoryItemGridLookUpDev(HopDong_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(HopDong_GrdLU, new string[] { "tblHopDongMuaBan.SoHopDong", "TenHopDong" }, new string[] { "Số hợp đồng", "Nội dung" }, new int[] { 100, 200 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "MaHopDong", HopDong_GrdLU);
            //


            HamDungChung.FormatNumberTypeofColumnGridViewDev(gridView_ButToan, new string[] { "SoTien" });
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_ButToan, new string[] { "SoTien" }, "#,###.#");
            this.gridView_ButToan.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView_ButToan_RowCellClick);
            this.gridView_ButToan.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_ButToan_CellValueChanged);
            this.gridView_ButToan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_ButToan_KeyDown);
            this.gridView_ButToan.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView_ButToan_InitNewRow);
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

        private void KhoiTao()
        {
            _user = app_users_Factory.New().Get_AppUserByUserID(PSC_ERP_Global.Main.UserID);
            _maCongTy = _user.MaCongTy.Value;
            _ButToanDeleteList = new List<tblButToan>();

            tblChungTuBindingSource_Single.DataSource = typeof(PSC_ERP_Business.Main.Model.tblChungTu);
            tblDinhKhoanBindingSource_Single.DataSource = typeof(PSC_ERP_Business.Main.Model.tblDinhKhoan);
            tblButToanBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblButToan);
            TienTe_bindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblTienTe);
            tblTaiKhoanBindingSource_No.DataSource = typeof(PSC_ERP_Business.Main.Model.tblTaiKhoan);
            tblTaiKhoanBindingSource_Co.DataSource = typeof(PSC_ERP_Business.Main.Model.tblTaiKhoan);
            AllDoiTuong_bindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.sp_AllDoiTuong_Result);
            LoaiTien_bindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblLoaiTien);
            ChungTu_DeNghiChuyenKhoan_bindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblChungTu_DeNghiChuyenKhoan);
            LoaiDoiTuongThuChi_bindingSource.DataSource = typeof(tblcnLoaiDoiTuong);

            //this.WindowState = FormWindowState.Maximized;

            DesignGrid_ButToan();
            DesignGrid_DSDeNghiChuyenKhoan();
        }

        private void GanBindingSource()
        {
            tblChungTuBindingSource_Single.DataSource = _ChungTu;
            TienTe_bindingSource.DataSource = _ChungTu.tblTienTe;
            tblDinhKhoanBindingSource_Single.DataSource = _ChungTu.tblDinhKhoan;
            tblButToanBindingSource.DataSource = _ChungTu.tblDinhKhoan.tblButToans;
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

        private void LoadDaTa()
        {
            _LoaiTienList = LoaiTien_Factory.New().GetAll();
            LoaiTien_bindingSource.DataSource = _LoaiTienList;
            // tai khoan
            _HeThongTaiKhoan1ListCo = TaiKhoan_Factory.New().Get_TaiKhoanbyMaCongTy(_maCongTy);
            tblTaiKhoanBindingSource_No.DataSource = _HeThongTaiKhoan1ListCo;
            _HeThongTaiKhoan1ListNo = _HeThongTaiKhoan1ListCo;
            tblTaiKhoanBindingSource_Co.DataSource = _HeThongTaiKhoan1ListNo;
            _HeThongTaiKhoanSearchCo = _HeThongTaiKhoan1ListNo;
            _HeThongTaiKhoanSearchNo = _HeThongTaiKhoanSearchCo;

            _TieuMucNganSachList = TieuMucNganSach_Factory.New().GetAll();
            TblTieuMucNganSach_bindingSource.DataSource = _TieuMucNganSachList;

            _loaiDoiTuongThuChiList = cnLoaiDoiTuong_Factory.New().Get_LoaiDoiTuongbyMaCongTy(_maCongTy);
            LoaiDoiTuongThuChi_bindingSource.DataSource = _loaiDoiTuongThuChiList;

        }

        private void GanMotNoNhieuCoKhiKhoiTaoMoi()
        {
            if (_ChungTu.tblDinhKhoan != null)
            {
                if (_ChungTu.tblDinhKhoan.LaMotNoNhieuCo == false)
                {
                    ChonNoLoad();
                }
                else ChonCoLoad();
            }
            else
            {
                ChonCoLoad();
            }
            //this.cmbu_TaiKhoanNC.ValueChanged += new EventHandler(cmbu_TaiKhoanNC_ValueChanged);
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
            _DoiTuongThuChiList = _factory.Context.sp_AllDoiTuong(0).Where(x => x.MaCongTy == _maCongTy).ToList();
            sp_AllDoiTuong_Result doituong = new sp_AllDoiTuong_Result() { MaDoiTuong = 0, TenDoiTuong = "<<không chọn>>" };
            _DoiTuongThuChiList.Insert(0, doituong);
            AllDoiTuong_bindingSource.DataSource = _DoiTuongThuChiList;
            _DoiTuongNoList = _DoiTuongThuChiList;
            _DoiTuongCoList = _DoiTuongThuChiList;
            DoiTuongNoList_BindingSource.DataSource = _DoiTuongNoList;
            // doi tuong co
            DoiTuongCoList_BindingSource.DataSource = _DoiTuongCoList;//_DoiTuongCoList;

            //HopDong
            _hopDongList = HopDong_Factory.New().GetAll().ToList();
            tblHopDong hopDong_khongChon = new tblHopDong() { MaHopDong = 0, TenHopDong = "<<Không chọn>>" };
            hopDong_khongChon.tblHopDongMuaBan = new tblHopDongMuaBan() { SoHopDong = "<<Không chọn>>" };
            _hopDongList.Insert(0, hopDong_khongChon);
            HopDong_bindingSource.DataSource = _hopDongList;
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
            //chưa load xong
            _daLoadXong = false;
            {
                //khởi tạo mới chứng từ factory
                _factory = ChungTuThuChi_DerivedFactory.New();
                //khởi tạo chứng từ mới 
                _maLoaiChungTu = 2;
                _ChungTu = _factory.NewChungTuThuChi(_maLoaiChungTu, (Convert.ToDateTime(dtmp_Ngay.EditValue)).Date.Year);
                _ChungTu.MaBoPhanDangNhap = _user.MaBoPhan;
                SetSoChungTuMoiPS(_maLoaiChungTu);
                dtmp_Ngay.EditValue = DateTime.Today;
                _ChungTu.SoChungTuKemTheo = 1;
                ChonNoLoad();
                FormatControlTaiKhoanvaDoiTuongNoCo();
                SetTaiKhoanDefault();

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

                    DoiTuongThu_Chi = _ChungTu.MaDoiTuongThuChi.Value;

                    group_ThongTinPhieu.Enabled = true;

                    cmbu_TaiKhoanNC.Value = _ChungTu.tblDinhKhoan.LaMotNoNhieuCo;
                    if (_ChungTu.tblDinhKhoan.tblButToans.Count != 0)
                    {
                        if (_ChungTu.tblDinhKhoan.LaMotNoNhieuCo == true) // no tren
                        {
                            grdLU_TaiKhoanNo.EditValue = _ChungTu.tblDinhKhoan.tblButToans.First().NoTaiKhoan;
                            if ((TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(_ChungTu.tblDinhKhoan.tblButToans.First().NoTaiKhoan ?? 0)).CoDoiTuongTheoDoi ?? false)
                            {
                                grdLU_DoiTuongNo.EditValue = _ChungTu.tblDinhKhoan.tblButToans.First().MaDoiTuongNo;
                            }
                        }
                        else // co tren
                        {
                            grdLU_TaiKhoanCo.EditValue = _ChungTu.tblDinhKhoan.tblButToans.First().CoTaiKhoan;
                            if ((TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(_ChungTu.tblDinhKhoan.tblButToans.First().CoTaiKhoan ?? 0)).CoDoiTuongTheoDoi ?? false)
                            {
                                grdLU_DoiTuongCo.EditValue = _ChungTu.tblDinhKhoan.tblButToans.First().MaDoiTuongCo;
                            }
                        }
                    }
                    FormatControlTaiKhoanvaDoiTuongNoCo();
                    LoadDataAfterInitChungTu();
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

                }

            }
            //đã load xong
            _daLoadXong = true;
        }

        private void ClearChiTietKH()
        {
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
                txtSoTien.Focus();
                return false;
            }



            if (_ChungTu.KiemTraDinhKhoanPhieuThu() == false)
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
                        XuLyChungTu_DiaChi();
                        XoaButToanTrongButToanDeleteList();
                        UpdateButToan_ChiPhiHDfromButToan();
                        if (_ChungTu.MaLoaiChungTu != 16)
                            UpdateChungTu_TheoDoifromChungTu();
                        _factory.SaveChanges(BusinessCodeEnum.BangKe_ThuChi.ToString());//lưu lại chứng từ

                    }
                    _taoMoiChungTu = false;
                    _ngayLapCu = _ChungTu.NgayLap.Value;
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
            else if (_ChungTu.MaDoiTuong == 0)
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

        private void XoaButToanTrongButToanDeleteList()
        {

            foreach (tblButToan btDelete in _ButToanDeleteList)
            {
                ButToan_Factory.DeleteChildrenButToanThuChi(_factory.Context, btDelete);
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

        private bool KiemTraSoQuy()
        {
            if (_ChungTu.tblChungTu_TheoDoi.Count() > 0)
            {
                if ((_ChungTu.tblChungTu_TheoDoi.FirstOrDefault<tblChungTu_TheoDoi>().SoTienDaChi ?? 0) == 0)
                {
                    MessageBox.Show(this, "Chứng từ này đã thu chi thực tế, vui lòng liên hệ Thủ Quỹ ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

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
                        _ChungTu.tblChungTu_DiaChi.Ten = txt_TenDoiTuongNhan.Text;
                        _ChungTu.tblChungTu_DiaChi.DiaChi = txt_DiaChiDoiTuongNhan.Text;
                    }
                }
            }
        }

        private void ResetNullTaiKhoanButToan(bool LaNo)
        {
            if (LaNo)//Tai Khoan Co
            {
                if (grdLU_TaiKhoanNo.EditValue == null)
                {
                    grdLU_DoiTuongNo.EditValue = null;
                    foreach (tblButToan bt in _ChungTu.tblDinhKhoan.tblButToans)
                    {
                        bt.NoTaiKhoan = 0;
                        bt.MaDoiTuongNo = 0;
                    }
                }
            }
            else//Tai Khoan Co
            {
                if (grdLU_TaiKhoanCo.EditValue == null)
                {
                    grdLU_DoiTuongCo.EditValue = null;
                    foreach (tblButToan bt in _ChungTu.tblDinhKhoan.tblButToans)
                    {
                        bt.CoTaiKhoan = 0;
                        bt.MaDoiTuongCo = 0;
                    }
                }
            }

        }

        #endregion

        #region eventHandle

        private void gridView_ButToan_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (gridView_ButToan.FocusedColumn.Name == "colChungTu_HoaDon")
            {
                tblButToan currentButToan = this.gridView_ButToan.GetFocusedRow() as tblButToan;
                if (currentButToan != null)
                {
                    if (TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(currentButToan.NoTaiKhoan.Value).SoHieuTK.StartsWith("3113"))
                    {
                        //show danh sách bút toán hóa đơn
                        using (frmDialogDanhSachHoaDonTheoButToan frm = new frmDialogDanhSachHoaDonTheoButToan(context: _factory.Context, chungTu: _ChungTu, butToan: currentButToan, noTaiKhoanList: _HeThongTaiKhoan1ListNo, coTaiKhoanList: _HeThongTaiKhoan1ListCo))
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

            else if (gridView_ButToan.FocusedColumn.Name == "colCT_ChiPhiSX")
            {
                tblButToan currentButToan = this.gridView_ButToan.GetFocusedRow() as tblButToan;
                if (currentButToan != null)
                {
                    using (frmChiPhiSanXuatChuongTrinhE frm = new frmChiPhiSanXuatChuongTrinhE(context: _factory.Context, chungTu: _ChungTu, butToan: currentButToan))
                    {
                        frm.ShowDialog();
                        if (frm.IsSave)
                        {
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
                            CapNhatThanhTienChungTu();
                        }
                    }

                }
                else
                {
                    tblButToan butToanNew = ButToan_Factory.New().CreateAloneObject(); //new tblButToan();
                    butToanNew.DienGiai = txt_DienGiai.EditValue.ToString();
                    if (grdLU_TaiKhoanCo.EditValue != null)
                        butToanNew.CoTaiKhoan = Convert.ToInt32(grdLU_TaiKhoanCo.EditValue);
                    if (grdLU_TaiKhoanNo.EditValue != null)
                        butToanNew.NoTaiKhoan = Convert.ToInt32(grdLU_TaiKhoanNo.EditValue);
                    _ChungTu.tblDinhKhoan.tblButToans.Add(butToanNew);
                    using (frmChiPhiSanXuatChuongTrinhE frm = new frmChiPhiSanXuatChuongTrinhE(context: _factory.Context, chungTu: _ChungTu, butToan: butToanNew))
                    {
                        frm.ShowDialog();
                        if (frm.IsSave)
                        {
                            butToanNew.SoTien = frm.SoTienDaNhap;
                            foreach (tblCT_ChiPhiSanXuat cp in butToanNew.tblCT_ChiPhiSanXuat)
                            {
                                cp.TaoTuTapHopCPSX = false;
                                #region Add ButToan MucNganSach vao ButToan
                                foreach (tblButToan_MucNganSach bt_mns in cp.tblButToan_MucNganSach)
                                {
                                    butToanNew.tblButToan_MucNganSach.Add(bt_mns);
                                }
                                #endregion//Add ButToan MucNganSach vao ButToan
                            }
                            CapNhatThanhTienChungTu();
                        }
                    }

                }

                tblButToanBindingSource.DataSource = _ChungTu.tblDinhKhoan.tblButToans;

            }
        }

        private void gridView_ButToan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            tblButToan currentButToan = (tblButToan)tblButToanBindingSource.Current;
            if (gridView_ButToan.FocusedColumn.Name == "colNoTaiKhoan" || gridView_ButToan.FocusedColumn.Name == "colCoTaiKhoan")
            {
                bool NocoThue = false;
                bool CocoThue = false;
                tblTaiKhoan taiKhoanNo = null;
                tblTaiKhoan taiKhoanCo = null;
                if (currentButToan.NoTaiKhoan != null)
                {
                    taiKhoanNo = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(currentButToan.NoTaiKhoan ?? 0);
                    if (taiKhoanNo.SoHieuTK.StartsWith("31131"))
                        NocoThue = true;
                }
                if (currentButToan.CoTaiKhoan != null)
                {
                    taiKhoanCo = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(currentButToan.CoTaiKhoan ?? 0);
                    if (taiKhoanCo.SoHieuTK.StartsWith("31131"))
                        CocoThue = true;
                }

                //Xu Ly Dien Giai
                if (NocoThue || CocoThue)
                {
                    currentButToan.DienGiai = "Thuế GTGT Được Khấu Trừ Của Hàng Hóa, Dịch Vụ";
                }
                //Xu ly Doi Tuong No Co
                if (taiKhoanNo != null)
                {
                    if (taiKhoanNo.CoDoiTuongTheoDoi == true)
                    {
                        currentButToan.MaDoiTuongNo = _ChungTu.MaDoiTuong;
                    }
                    else
                    {
                        currentButToan.MaDoiTuongNo = 0;
                    }
                }
                else
                {
                    currentButToan.MaDoiTuongNo = 0;
                }

                if (taiKhoanNo != null)
                {
                    if (taiKhoanCo.CoDoiTuongTheoDoi == true)
                    {
                        currentButToan.MaDoiTuongCo = _ChungTu.MaDoiTuong;
                    }
                    else
                    {
                        currentButToan.MaDoiTuongCo = 0;
                    }
                }
                else
                {
                    currentButToan.MaDoiTuongCo = 0;
                }
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
            decimal sotien = Convert.ToDecimal(txt_ThanhTien.EditValue);

            foreach (tblButToan bt in _ChungTu.tblDinhKhoan.tblButToans)
            {

                if (sotien != bt.SoTien)
                    sotien -= bt.SoTien;
                else if (sotien == bt.SoTien)
                    sotien = 0;
            }
            tblButToan buttoan = tblButToanBindingSource.Current as tblButToan;
            if (buttoan != null)
            {
                buttoan.SoTien = sotien;
                buttoan.DienGiai = txt_DienGiai.EditValue.ToString();
                if (grdLU_TaiKhoanCo.EditValue != null)
                    buttoan.CoTaiKhoan = Convert.ToInt32(grdLU_TaiKhoanCo.EditValue);
                if (grdLU_TaiKhoanNo.EditValue != null)
                    buttoan.NoTaiKhoan = Convert.ToInt32(grdLU_TaiKhoanNo.EditValue);
            }
        }

        private void gridView_DSDeNghi_KeyDown(object sender, KeyEventArgs e)
        {
            HamDungChung.DeleteSelectedRowsGridViewDev(gridView_DSDeNghi, e);

        }

        #endregion
        public frmPhieuThuE()
        {
            InitializeComponent();
            _taoMoiChungTu = true;
            KhoiTao();
            LoadDaTa();
        }

        public frmPhieuThuE(tblChungTu chungTu)
        {
            InitializeComponent();
            _taoMoiChungTu = false;
            _maChungTuGhiTangCuCanXemLai = chungTu.MaChungTu;
            KhoiTao();
            LoadDaTa();
            btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        #region Event

        private void cmbu_TaiKhoanNC_ValueChanged(object sender, EventArgs e)
        {
            if (_daLoadXong)
            {
                FormatControlTaiKhoanvaDoiTuongNoCo();
            }

        }

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

        private void grdLU_TaiKhoanCo_EditValueChanged(object sender, EventArgs e)
        {
            if (_daLoadXong)
            {
                if (cmbu_TaiKhoanNC.Value != null)
                {
                    tblButToanBindingSource.DataSource = _ChungTu.tblDinhKhoan.tblButToans;
                    if ((bool)cmbu_TaiKhoanNC.Value == false)
                    {
                        if (grdLU_TaiKhoanCo.EditValue != null)
                        {
                            tblTaiKhoan tkc = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(Convert.ToInt32(grdLU_TaiKhoanCo.EditValue));


                            if (tkc.CoDoiTuongTheoDoi == true)
                            {
                                grdLU_DoiTuongCo.EditValue = _ChungTu.MaDoiTuong;
                            }
                            else grdLU_DoiTuongCo.EditValue = 0;
                            foreach (tblButToan bt in _ChungTu.tblDinhKhoan.tblButToans)
                            {
                                bt.CoTaiKhoan = tkc.MaTaiKhoan;
                                if (tkc.CoDoiTuongTheoDoi == true)
                                {
                                    bt.MaDoiTuongCo = _ChungTu.MaDoiTuong;
                                }
                                else
                                {
                                    bt.MaDoiTuongCo = 0;
                                }
                            }

                            tblButToanBindingSource.DataSource = _ChungTu.tblDinhKhoan.tblButToans;
                        }
                    }

                }
            }
        }

        private void grdLU_TaiKhoanNo_EditValueChanged(object sender, EventArgs e)
        {
            if (_daLoadXong)
            {
                if (cmbu_TaiKhoanNC.Value != null)
                {
                    if ((bool)cmbu_TaiKhoanNC.Value == true)
                    {
                        if (grdLU_TaiKhoanNo.EditValue != null)
                        {
                            tblTaiKhoan tkn = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(Convert.ToInt32(grdLU_TaiKhoanNo.EditValue));

                            if (tkn.CoDoiTuongTheoDoi == true)
                            {
                                grdLU_DoiTuongNo.EditValue = _ChungTu.MaDoiTuong;
                            }
                            else grdLU_DoiTuongNo.EditValue = 0;
                            foreach (tblButToan bt in _ChungTu.tblDinhKhoan.tblButToans)
                            {
                                bt.NoTaiKhoan = tkn.MaTaiKhoan;
                                if (tkn.CoDoiTuongTheoDoi == true)
                                {
                                    bt.MaDoiTuongNo = _ChungTu.MaDoiTuong;
                                }
                                else
                                {
                                    bt.MaDoiTuongNo = 0;
                                }
                            }

                            tblButToanBindingSource.DataSource = _ChungTu.tblDinhKhoan.tblButToans;

                        }
                    }
                }
            }
        }


        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhoiTaoChungTuMoi();
            Check_chkKhachHangClick();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textBoxFocus1.Focus();
            grdLU_MaDoiTuongThuChi.Focus();
            if (_taoMoiChungTu == true)
            {
                if (this.Save())
                {
                    btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
            }
            else
            {
                if (KiemTraSoQuy())
                {
                    if (this.Save())
                    {
                        btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                }
            }
        }

        private void btnXoaChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Ky_Factory.New().DaKhoaSoTSCD(_ChungTu.NgayLap.Value,_maCongTy))
            {
                DialogUtil.ShowDaKhoaSoTSCD(_ChungTu.NgayLap.Value);
            }
            else
            {
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
                _maDoiTuong = _ChungTu.MaDoiTuong.Value;
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
            frmTimDanhSachChungTu f = new frmTimDanhSachChungTu(2);
            if (f.ShowDialog() != DialogResult.OK)
            {
                if (f.DaChon == true)
                {
                    LoadChungTuCu(f.MaChungTu);
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

        #endregion//Event












    }
}