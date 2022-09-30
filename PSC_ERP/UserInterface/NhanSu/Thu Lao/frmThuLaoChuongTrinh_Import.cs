using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;
namespace PSC_ERP
{//lan
    public partial class frmThuLaoChuongTrinh_Import : Form
    {
        #region Properties
        //ChiThuLaoList _chiThuLaoList;
        ChiThuLaoTongHopList _chiThuLaoList;
        BoPhanList _boPhanList;
        ChuongTrinhList _chuongTrinhList;
        KyTinhLuongList _kyTinhLuongList;
        ERP_Library.ThongTinNhanVienTongHopList _nhanVienList;
        ChiThuLao _chiThuLao_NhanVienList = ChiThuLao.NewChiThuLao();
        ThuLaoChuongTrinhList _thuLaoChuongTrinhList = ThuLaoChuongTrinhList.NewThuLaoChuongTrinhList();
        //GiayXacNhanChuongTrinhList _giayXacNhanChuongTrinhList = GiayXacNhanChuongTrinhList.NewGiayXacNhanChuongTrinhList();
        //ChiTietGiayXacNhanList _chiTietGiayXacNhanList = ChiTietGiayXacNhanList.NewChiTietGiayXacNhanList();
        //ChiTietGiayXacNhan chiTietGXN = ChiTietGiayXacNhan.NewChiTietGiayXacNhan();
        ChiTietGiayXacNhanTongHopList _chiTietGiayXacNhanList = ChiTietGiayXacNhanTongHopList.NewChiTietGiayXacNhanTongHopList();
        ChiTietGiayXacNhanTongHop chiTietGXN = ChiTietGiayXacNhanTongHop.NewChiTietGiayXacNhanTongHop();

        decimal _tienChiTietGiayXacNhan = 0;
        decimal _tienTuPhieuChi = 0;
        string _tenPhieuChi = string.Empty;
        int maBoPhanDen = 0;

        static int maBoPhan = 0;
        static int maKyTinhluong = 0;
        static int maChuongTrinh = 0;
        bool nhapHo = false;

        string tenChuongTrinh = string.Empty;
        long maChiThuLao = 0;
        string soChungTu = string.Empty;
        string tenChungTu = string.Empty;
        string tenGiayXacNhan = string.Empty;
        string ghiChuPhieuChi = string.Empty;
        int maChiTietGiayXacNhan = 0;
        int maGiayXacNhan = 0;
        bool _hoanTat = false;
        string tenNguon = string.Empty;
        int _maChiTietGiayXacNhan_Update = 0;
        int maNguon = 0;
        Boolean _suaDuLieu = false;
        decimal _tongTienChoPhepCapNhat = 0;
        #endregion

        #region Load
        public frmThuLaoChuongTrinh_Import()
        {
            InitializeComponent();
            this.bindingSource1_BoPhan.DataSource = typeof(BoPhanList);
            this.bindingSource1_ChuongTrinh.DataSource = typeof(ChuongTrinhList);
            this.bindingSource1_KyTinhLuong.DataSource = typeof(KyTinhLuongList);
            this.bindingSource1_ChiTietGiayXacNhan.DataSource = typeof(ChiTietGiayXacNhanList);
            this.bindingSource1_ThuLaoChuongTrinh.DataSource = typeof(ThuLaoChuongTrinhList);
            this.bindingSource1_ChungTu.DataSource = typeof(ChiThuLaoList);
            bindingSource1_NhanVien.DataSource = typeof(ThongTinNhanVienTongHopList);
            LoadControls();
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_QuocGia.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_QuocGia.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_QuocGia.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
            dateTimePicker_NgayLap.Value = DateTime.Today;

        }

        public frmThuLaoChuongTrinh_Import(int _maChuongTrinh, int _maKyTinhLuong, int _maChiTietGiayXacNhan, int _nguoiLap, bool _tinhDangPhi, DateTime _ngayLap, int _maGiayXacNhan, long _maChiThuLao)
        {
            InitializeComponent();
            KhoiTao(_maChuongTrinh, _maKyTinhLuong, _maChiTietGiayXacNhan, _nguoiLap, _tinhDangPhi, _ngayLap, _maGiayXacNhan, _maChiThuLao);
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_QuocGia.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_QuocGia.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_QuocGia.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);

        }

        private void frmThuLaoChuongTrinh_Load(object sender, EventArgs e)
        {
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, Infragistics.Win.UltraWinGrid.UltraGridState.AddRow, 0, 0, 0));
            //LoadControls();
            cmbu_ChuongTrinh.Enabled = false;
        }
        
        private void grdu_QuocGia_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            // Turn on all of the Cut, Copy, and Paste functionality. 
            e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;

            // In order to cut or copy, the user needs to select cells or rows. 
            // So set CellClickAction so that clicking on a cell selects that cell
            // instead of going into edit mode.
            e.Layout.Override.CellClickAction = CellClickAction.CellSelect;
            foreach (UltraGridColumn col in this.grdu_QuocGia.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;

            }
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Chọn";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["Check"].Width = 60;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Width = 80;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 150;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 4;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 120;

            //grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            //grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            //grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 5;
            //grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 100;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["ThucNhan"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["ThucNhan"].Header.Caption = "Ngoài Định Mức";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["ThucNhan"].Header.VisiblePosition = 6;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["ThucNhan"].Width = 80;
        }

        private void ultraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.ultraGrid1.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChucvu"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaSoThue"].Hidden = false;

            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Chọn";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Quản Lý";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "Chứng Minh";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChucvu"].Header.Caption = "Chức Vụ";
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.Caption = "Mã Số Thuế";

            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 2;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 3;
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 4;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChucvu"].Header.VisiblePosition = 5;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.VisiblePosition = 6;

            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Width = 40;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Width = 100;
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].Width = 100;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 150;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChucvu"].Width = 100;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaSoThue"].Width = 100;

            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChucVu"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaSoThue"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;

        }

        private void cbChiTietGiayXacNhan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //HamDungChung.Combobox_InitializeLayout(sender, e);
            //FilterCombo f = new FilterCombo(cbChiTietGiayXacNhan, "TenGiayXacNhan");
        }

        private void cmbu_Bophan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_Bophan, "TenBoPhan");
            foreach (UltraGridColumn col in this.cmbu_Bophan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cmbu_Bophan.Width;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
        }

        private void cbChiTietGiayXacNhan_InitializeLayout_1(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbChiTietGiayXacNhan, "TenGiayXacNhan");
            foreach (UltraGridColumn col in this.cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
            }
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Header.Caption = "Tên Giấy Xác Nhận";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Header.VisiblePosition = 0;

            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###,###";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 1;
            //cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.Caption = "Số Tiền Còn Lại";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].Format = "###,###,###,###,###";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.VisiblePosition = 2;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDi"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDi"].Header.Caption = "Đơn Vị Gửi";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDi"].Header.VisiblePosition = 3;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDen"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDen"].Header.Caption = "Đơn Vị Nhận";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDen"].Header.VisiblePosition = 4;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 5;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Header.Caption = "Nhập Hộ";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Header.VisiblePosition = 6;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["HoanTat"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["HoanTat"].Header.Caption = "Hoàn Tất";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["HoanTat"].Header.VisiblePosition = 7;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 8;
        }
        #endregion

        #region Process
        public void KhoiTao(int _maChuongTrinh, int _maKyTinhLuong, int _maChiTietGiayXacNhan, int _nguoiLap, bool _tinhDangPhi, DateTime _ngayLap, int _maGiayXacNhan, long _maChiThuLao)
        {
            _maChiTietGiayXacNhan_Update = _maChiTietGiayXacNhan;
            LoadControls();

            cbKyTinhLuong.Value = _maKyTinhLuong;
            cmbu_ChuongTrinh.EditValue = _maChuongTrinh;
            maChiTietGiayXacNhan = _maChiTietGiayXacNhan;
            if (ChiTietGiayXacNhan.GetChiTietGiayXacNhan(maChiTietGiayXacNhan).HoanTat == true)
            {
                _hoanTat = true;
                GiayXacNhanChuongTrinh gxn = GiayXacNhanChuongTrinh.GetGiayXacNhanChuongTrinh(ChiTietGiayXacNhan.GetChiTietGiayXacNhan(maChiTietGiayXacNhan).MaGiayXacNhan);
                cmbu_ChuongTrinh.Text = gxn.TenChuongTrinh;
                cbChiTietGiayXacNhan.Text = gxn.TenGiayXacNhan;
            }
            else
            {
                cbChiTietGiayXacNhan.Value = _maChiTietGiayXacNhan;

            }
            maChuongTrinh = _maChuongTrinh;
            _thuLaoChuongTrinhList = ThuLaoChuongTrinhList.GetThuLaoChuongTrinhListByChuyenKhoan(_maChuongTrinh, _maKyTinhLuong, _maChiTietGiayXacNhan, _nguoiLap, _tinhDangPhi, _ngayLap, _maChiThuLao);
            maKyTinhluong = _maKyTinhLuong;
            if (_thuLaoChuongTrinhList.Count != 0)
            {

                dateTimePicker_NgayLap.Value = _thuLaoChuongTrinhList[0].NgayLap;
            }

            bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;
            this.lbSoLuong.Text = _thuLaoChuongTrinhList.Count.ToString();

            _tongTienChoPhepCapNhat = TongSoTienToiDaChoPhepCapNhat();
        }
        private decimal TongSoTienToiDaChoPhepCapNhat()
        {
            decimal soTienDaNhapThuLao = 0;
            decimal soTienChoPhepCapNhat = 0;
            foreach (ThuLaoChuongTrinh item in _thuLaoChuongTrinhList)
            {
                soTienDaNhapThuLao += item.SoTien;
            }
            soTienChoPhepCapNhat += soTienDaNhapThuLao + Convert.ToDecimal(tbSoTienConLaiGXN.Value);

            return soTienChoPhepCapNhat;
        }
        private void ComBoChangedValue()
        {
            lbSoLuong.Text = _thuLaoChuongTrinhList.Count.ToString();
        }

        private void LoadControls()
        {
            dateTimePicker_NgayLap.Value = DateTime.Today;
            _boPhanList = BoPhanList.GetBoPhanListByMaBoPhanChaNotNull();
            BoPhan itemBoPhan = BoPhan.NewBoPhan("Tất Cả");
            _boPhanList.Insert(0, itemBoPhan);
            this.bindingSource1_BoPhan.DataSource = _boPhanList;
            //chuong trinh
            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;

            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongListByKhoaSo();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;


            ///------Chay cham--------////
            //_chiTietGiayXacNhanList = ChiTietGiayXacNhanList.GetChiTietGiayXacNhanListByUserID(ERP_Library.Security.CurrentUser.Info.UserID);
            //ChiTietGiayXacNhan itemAdd = ChiTietGiayXacNhan.NewChiTietGiayXacNhan(0, "Không Có Giấy Xác Nhận");
            //_chiTietGiayXacNhanList.Insert(0, itemAdd);
            //this.bindingSource1_ChiTietGiayXacNhan.DataSource = _chiTietGiayXacNhanList;

            ///------Chay nhanh--------////
            _chiTietGiayXacNhanList = ChiTietGiayXacNhanTongHopList.GetChiTietGiayXacNhanTongHopListByUserIDAndMaChiTietGiayXacNhan(ERP_Library.Security.CurrentUser.Info.UserID,_maChiTietGiayXacNhan_Update);
            ChiTietGiayXacNhanTongHop itemAdd = ChiTietGiayXacNhanTongHop.NewChiTietGiayXacNhanTongHop(0, "Không Có Giấy Xác Nhận");
            _chiTietGiayXacNhanList.Insert(0, itemAdd);
            this.bindingSource1_ChiTietGiayXacNhan.DataSource = _chiTietGiayXacNhanList;


            _nhanVienList = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
            bindingSource1_NhanVien.DataSource = _nhanVienList;
            _thuLaoChuongTrinhList = ThuLaoChuongTrinhList.NewThuLaoChuongTrinhList();
            this.bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;

            //_chiThuLaoList = ChiThuLaoList.GetChiThuLaoListByUser(ERP_Library.Security.CurrentUser.Info.UserID);
            //ChiThuLao itemChiTL = ChiThuLao.NewChiThuLao("Không Có Chứng Từ");
            //_chiThuLaoList.Insert(0, itemChiTL);
            //this.bindingSource1_ChungTu.DataSource = _chiThuLaoList;

            //_chiThuLaoList = ChiThuLaoTongHopList.GetChiThuLaoTongHopListByUser(ERP_Library.Security.CurrentUser.Info.UserID);
            //ChiThuLaoTongHop itemChiTL = ChiThuLaoTongHop.NewChiThuLaoTongHop("Không Có Chứng Từ");
            //_chiThuLaoList.Insert(0, itemChiTL);
            //this.bindingSource1_ChungTu.DataSource = _chiThuLaoList;
        }
        #endregion

        #region Event
        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbu_Bophan.ActiveRow != null)
                {
                    maBoPhan = (int)cmbu_Bophan.ActiveRow.Cells["MaBoPhan"].Value;
                }
                //_nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByThuLaoChuongTrinh(maBoPhan, checkBox_NghiHuu.Checked);
                _nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong(maBoPhan, false);
                this.bindingSource1_NhanVien.DataSource = _nhanVienList;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void chkAlldanhsach_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlldanhsach.Checked == true)
            {
                for (int i = 0; i < ultraGrid1.Rows.Count; i++)
                {
                    if (!ultraGrid1.Rows[i].Hidden == true && ultraGrid1.Rows[i].IsFilteredOut == false)
                    {
                        ultraGrid1.Rows[i].Cells["Check"].Value = (object)true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < ultraGrid1.Rows.Count; i++)
                {
                    ultraGrid1.Rows[i].Cells["Check"].Value = (object)false;
                }
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (cmbu_ChuongTrinh.EditValue == null || (cmbu_ChuongTrinh.EditValue != null && Convert.ToInt32(cmbu_ChuongTrinh.EditValue) == 0))
            {
                MessageBox.Show("Vui Lòng Chọn Chương Trình ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbu_ChuongTrinh.Focus();
                return;
            }
            if (cbKyTinhLuong.Value == null || (cbKyTinhLuong.Value != null && Convert.ToInt32(cbKyTinhLuong.Value) == 0))
            {
                MessageBox.Show("Vui Lòng Chọn Kỳ Tính Lương ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbKyTinhLuong.Focus();
                return;
            }

            {
                KyTinhLuong ktl = KyTinhLuong.GetKyTinhLuong(maKyTinhluong);

                if (ktl.KhoaSoKy2 == true || ktl.KhoaSo == true)
                {
                    MessageBox.Show("Tháng lương Đã Khóa Sổ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult _DialogResult = MessageBox.Show("Bạn Có Đồng Ý Đứa Nhân Viên Qua", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (_DialogResult == DialogResult.Yes)
                {
                    for (int i = 0; i < ultraGrid1.Rows.Count; i++)
                    {
                        if ((bool)ultraGrid1.Rows[i].Cells["Check"].Value == true)
                        {
                            ThuLaoChuongTrinh thuLao = ThuLaoChuongTrinh.NewThuLaoChuongTrinh();
                            thuLao.ThanhToan = true;
                            thuLao.MaChuongTrinh = maChuongTrinh;
                            thuLao.MaKyTinhLuong = maKyTinhluong;
                            thuLao.MaNhanVien = (long)ultraGrid1.Rows[i].Cells["MaNhanVien"].Value;
                            thuLao.TenNhanVien = (string)ultraGrid1.Rows[i].Cells["TenNhanVien"].Value;
                            thuLao.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
                            thuLao.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;

                            thuLao.SoTien = Convert.ToDecimal(ultraGrid1.Rows[i].Cells["SoTien"].Value);
                            thuLao.MaQLNhanVien = (string)ultraGrid1.Rows[i].Cells["MaQLNhanVien"].Value;
                            thuLao.MaQLBoPhan = (string)ultraGrid1.Rows[i].Cells["MaQLBoPhan"].Value;
                            thuLao.MaBoPhan = (int)ultraGrid1.Rows[i].Cells["MaBoPhan"].Value;
                            thuLao.MaChucVu = (int)ultraGrid1.Rows[i].Cells["MaChucVu"].Value;
                            thuLao.TenBoPhan = (string)ultraGrid1.Rows[i].Cells["TenBoPhan"].Value;
                            thuLao.TenChucVu = (string)ultraGrid1.Rows[i].Cells["TenChucVu"].Value;
                            thuLao.DienGiai = ghiChuPhieuChi;
                            thuLao.TenChuongTrinh = tenChuongTrinh;
                            thuLao.SoChungTu = soChungTu;
                            thuLao.MaChiThuLao = maChiThuLao;
                            thuLao.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
                            thuLao.MaGiayXacNhan = maGiayXacNhan;
                            thuLao.MaPhieuChi = soChungTu;
                            thuLao.MaNguonChuongTrinh = maNguon;
                            thuLao.TenNguonChuongTrinh = tenNguon;
                            thuLao.ThucNhan = cbDinhMuc.Checked;

                            _thuLaoChuongTrinhList.Add(thuLao);

                        }
                    }
                    this.bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;
                    this.lbSoLuong.Text = _thuLaoChuongTrinhList.Count.ToString();

                    for (int i = 0; i < ultraGrid1.Rows.Count; i++)
                    {
                        if ((bool)ultraGrid1.Rows[i].Cells["Check"].Value == true)
                        {
                            ultraGrid1.Rows[i].Cells["Check"].Value = false;
                            ultraGrid1.Rows[i].Hidden = true;
                        }
                    }
                    this.bindingSource1_NhanVien.DataSource = _nhanVienList;
                }
                else
                {
                    return;
                }
            }        
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {

            try
            {
                if (cbChiTietGiayXacNhan.Value == null || (cbChiTietGiayXacNhan.Value !=null && Convert.ToInt32(cbChiTietGiayXacNhan.Value)  == 0))
                {
                    MessageBox.Show("Vui lòng chọn giấy xác nhận.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                KyTinhLuong ktl = KyTinhLuong.GetKyTinhLuong(maKyTinhluong);
                if (_hoanTat == true && maChiThuLao != 0)
                {
                    MessageBox.Show("Chứng Từ Đã Đánh Dấu Hoàn Tất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (ktl.KhoaSoKy2 == true || ktl.KhoaSo == true)
                {
                    MessageBox.Show("Tháng lương Đã Khóa Sổ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                else
                {
                    if (maChiTietGiayXacNhan != 0 && maChiThuLao != 0)
                    {
                        if (GiayXacNhanChuongTrinh.GetGiayXacNhanChuongTrinh(maGiayXacNhan).MaChuongTrinh != ChiThuLao.GetChiThuLao(maChiThuLao).MaChuongTrinh)
                        {
                            MessageBox.Show("Chương trình từ Giấy Xác Nhận và Phiếu Chi không giống nhau", "ThôngBáo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    decimal soTienDaNhap = 0;
                    foreach (ThuLaoChuongTrinh tl in _thuLaoChuongTrinhList)
                    {
                        KyTinhLuong ktlTrack = KyTinhLuong.GetKyTinhLuong(tl.MaKyTinhLuong);
                        if (ktlTrack.KhoaSoKy2 == true)
                        {
                            MessageBox.Show("Kỳ Trước Đã Được Khóa Sổ Rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if ((DateTime)dateTimePicker_NgayLap.Value >= ktlTrack.NgayKhoaThuLao)
                        {
                            MessageBox.Show("Ngày Lập lớn hơn Ngày Khóa Thù Lao", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (tl.MaNhanVien == 0)
                        {
                            _thuLaoChuongTrinhList.Clear();
                        }
                        tl.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
                        tl.TenChuongTrinh = tenChuongTrinh;
                        tl.MaChuongTrinh = maChuongTrinh;
                        tl.MaKyTinhLuong = maKyTinhluong;

                        tl.MaChiThuLao = maChiThuLao;
                        tl.SoChungTu = soChungTu;

                        tl.SoChungTu = soChungTu;
                        tl.MaChiThuLao = maChiThuLao;
                        tl.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
                        tl.MaGiayXacNhan = maGiayXacNhan;
                        tl.TenGiayXacNhan = tenGiayXacNhan;
                        tl.MaPhieuChi = soChungTu;
                        tl.MaNguonChuongTrinh = maNguon;
                        tl.TenNguonChuongTrinh = tenNguon;
                        soTienDaNhap += tl.SoTien;
                        tl.DuocNhapHo = nhapHo;
                        tl.ThanhToan = true;
                        tl.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;

                        if (tl.NgayLap < ktl.NgayBatDau || tl.NgayLap > ktl.NgayKetThuc)
                        {
                            MessageBox.Show("Ngày Lập phải năm trong tháng của kỳ lương", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    if (cbChiTietGiayXacNhan.Value != null && (int)cbChiTietGiayXacNhan.Value != 0)
                    {
                        if (!_suaDuLieu)
                        {
                            if (Convert.ToDecimal(tbSoTienConLaiGXN.Value) < soTienDaNhap)
                            {
                                MessageBox.Show("Không đủ tiền nhập thù lao.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            if (soTienDaNhap > _tongTienChoPhepCapNhat || Convert.ToDecimal(tbSoTienConLaiGXN.Value) < soTienDaNhap - TinhSoTienDaNhapThuLao((int)cbChiTietGiayXacNhan.Value))
                            {
                                MessageBox.Show("Không đủ tiền nhập thù lao.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    _thuLaoChuongTrinhList.ApplyEdit();
                    bindingSource1_ThuLaoChuongTrinh.EndEdit();
                    _thuLaoChuongTrinhList.Save();

                    MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    //Cập nhật số tiền còn lại
                    tbSoTienConLaiGXN.Value = ChiTietGiayXacNhanTongHop.GetChiTietGiayXacNhanTongHop(maChiTietGiayXacNhan).SoTienConLai;

                    ///------Chay nhanh--------////
                    _chiTietGiayXacNhanList = ChiTietGiayXacNhanTongHopList.GetChiTietGiayXacNhanTongHopListByUserIDAndMaChiTietGiayXacNhan(ERP_Library.Security.CurrentUser.Info.UserID, maChiTietGiayXacNhan);
                    ChiTietGiayXacNhanTongHop itemAdd = ChiTietGiayXacNhanTongHop.NewChiTietGiayXacNhanTongHop(0, "Không Có Giấy Xác Nhận");
                    _chiTietGiayXacNhanList.Insert(0, itemAdd);
                    this.bindingSource1_ChiTietGiayXacNhan.DataSource = _chiTietGiayXacNhanList;

                    _tongTienChoPhepCapNhat = TongSoTienToiDaChoPhepCapNhat();
                    _suaDuLieu = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        private decimal TinhSoTienDaNhapThuLao(int maChiTietGiayXacNhan)
        {
            decimal soTienConLai = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LaySoTienDaNhapThuLao";
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", maChiTietGiayXacNhan);
                    cm.Parameters.AddWithValue("@SoTien", soTienConLai);
                    cm.Parameters["@SoTien"].Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();
                    soTienConLai = Convert.ToDecimal(cm.Parameters["@SoTien"].Value);
                }
            }//using
            return soTienConLai;
        }
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            ComBoChangedValue();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            // KhoiTao(maKyTinhluong,maChuongTrinh,maGiayXacNhan);           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (KyTinhLuong.GetKyTinhLuong(maKyTinhluong).KhoaSoKy2 != true)
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    if ((bool)grdu_QuocGia.Rows[i].Cells["Check"].Value == true)
                    {
                        grdu_QuocGia.Rows[i].Selected = true;
                    }
                }
                grdu_QuocGia.DeleteSelectedRows();
                //_thuLaoChuongTrinhList.ApplyEdit();
                // _thuLaoChuongTrinhList.Save();
                _nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong(maBoPhan, false);
                this.bindingSource1_NhanVien.DataSource = _nhanVienList;
                this.lbSoLuong.Text = _thuLaoChuongTrinhList.Count.ToString();
            }
            else
            {
                MessageBox.Show("Kỳ Này Đã Được Khóa Sổ Rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //ComBoChangedValue();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    if (!grdu_QuocGia.Rows[i].Hidden == true)
                    {
                        grdu_QuocGia.Rows[i].Cells["Check"].Value = (object)true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    grdu_QuocGia.Rows[i].Cells["Check"].Value = (object)false;
                }
            }
        }

        private void grdu_QuocGia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                button2_Click_1(null, null);
                // this.ultraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Copy);
            }
        }

        private void ultraGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ultraGrid1.ActiveRow != null)
            {

                if (e.KeyCode == Keys.Space)
                {
                    if (ultraGrid1.ActiveRow.Cells["Check"].Value.ToString() != "")
                    {
                        if ((bool)ultraGrid1.ActiveRow.Cells["Check"].Value == true)
                            ultraGrid1.ActiveRow.Cells["Check"].Value = false;
                        else
                            ultraGrid1.ActiveRow.Cells["Check"].Value = true;
                    }
                }
            }
        }

        private void ultraGrid1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                btnthem_Click(null, null);
            }
        }

        private void cmbu_ChucVu_Leave(object sender, EventArgs e)
        {
            if (cmbu_ChuongTrinh.EditValue != null)
            {
                maChuongTrinh = (int)cmbu_ChuongTrinh.EditValue;
                foreach (ThuLaoChuongTrinh tl in _thuLaoChuongTrinhList)
                {
                    tl.MaChuongTrinh = maChuongTrinh;
                }
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            frmBaoCaoThuLaoChiTiet f = new frmBaoCaoThuLaoChiTiet();
            f.Show();
        }

        private void dateTimePicker_NgayLap_Leave(object sender, EventArgs e)
        {

            foreach (ThuLaoChuongTrinh tl in _thuLaoChuongTrinhList)
            {
                tl.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
            }
        }

        private bool iskeyok = false;//xử lý key cho cột string
        private void grdData_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdu_QuocGia.ActiveCell != null && !grdu_QuocGia.ActiveCell.IsInEditMode && grdu_QuocGia.ActiveCell.Column.Key != "TenNhanVien")
            {
                if ((e.KeyData >= Keys.A && e.KeyData <= Keys.Z) || (e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9))
                {
                    grdu_QuocGia.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    grdu_QuocGia.ActiveCell.SelectAll();
                    iskeyok = true;
                }
                if (e.KeyCode == Keys.Space && grdu_QuocGia.ActiveCell.Column.DataType == typeof(bool))
                {
                    grdu_QuocGia.ActiveCell.Value = !Convert.ToBoolean(grdu_QuocGia.ActiveCell.Value);
                }
            }
        }

        private void grdData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (iskeyok && grdu_QuocGia.ActiveCell.Row.IsDataRow)
            {
                if (grdu_QuocGia.ActiveCell.Column.DataType == typeof(decimal))
                    try
                    {
                        grdu_QuocGia.ActiveCell.Value = Convert.ToDecimal(e.KeyChar.ToString());
                    }
                    catch
                    { }
                else
                    grdu_QuocGia.ActiveCell.Value = e.KeyChar.ToString();
                grdu_QuocGia.ActiveCell.SelStart = grdu_QuocGia.ActiveCell.Text.Length;
                e.Handled = true;
                iskeyok = false;
            }
        }
        //xử lý copy 1 cell cho nhiều cell
        private bool iscopyok = false;
        private object copyvalue;
        private void grdData_BeforeMultiCellOperation(object sender, Infragistics.Win.UltraWinGrid.BeforeMultiCellOperationEventArgs e)
        {
            if (e.Operation == Infragistics.Win.UltraWinGrid.MultiCellOperation.Copy)
            {
                if (e.Cells.RowCount == 1 && e.Cells.ColumnCount == 1)
                {
                    iscopyok = true;
                    copyvalue = e.Cells[0, 0].Value;
                }
            }
            else
                if (e.Operation == Infragistics.Win.UltraWinGrid.MultiCellOperation.Paste)
                {
                    if (iscopyok && grdu_QuocGia.Selected != null && grdu_QuocGia.Selected.Cells != null)
                    {
                        e.Cancel = true;
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridCell item in grdu_QuocGia.Selected.Cells)
                        {
                            try
                            {
                                item.Value = copyvalue;
                                item.Row.Update();
                            }
                            catch { }
                        }
                    }
                    iscopyok = false;
                }
        }

        private void cbKyTinhLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cbKyTinhLuong.ActiveRow != null)
            {
                maKyTinhluong = (int)cbKyTinhLuong.ActiveRow.Cells["MaKy"].Value;

            }
        }

        private void cbKyTinhLuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbKyTinhLuong, "TenKy");
            foreach (UltraGridColumn col in this.cbKyTinhLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Width = cbKyTinhLuong.Width;
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            cbChiTietGiayXacNhan.Value = 0;
            _maChiTietGiayXacNhan_Update = 0;
            cmbu_ChuongTrinh.EditValue = null;
            _suaDuLieu = false;
            _thuLaoChuongTrinhList = ThuLaoChuongTrinhList.NewThuLaoChuongTrinhList();
            this.bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;

            _chiTietGiayXacNhanList = ChiTietGiayXacNhanTongHopList.GetChiTietGiayXacNhanTongHopListByUserIDAndMaChiTietGiayXacNhan(ERP_Library.Security.CurrentUser.Info.UserID, _maChiTietGiayXacNhan_Update);
            ChiTietGiayXacNhanTongHop itemAdd = ChiTietGiayXacNhanTongHop.NewChiTietGiayXacNhanTongHop(0, "Không Có Giấy Xác Nhận");
            _chiTietGiayXacNhanList.Insert(0, itemAdd);
            this.bindingSource1_ChiTietGiayXacNhan.DataSource = _chiTietGiayXacNhanList;
        }

        private void cbDinhMuc_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDinhMuc.Checked == true)
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    if (!grdu_QuocGia.Rows[i].Hidden == true)
                    {
                        grdu_QuocGia.Rows[i].Cells["ThucNhan"].Value = (object)true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    grdu_QuocGia.Rows[i].Cells["ThucNhan"].Value = (object)false;
                }
            }
        }
    
        private void cbChiTietGiayXacNhan_ValueChanged_1(object sender, EventArgs e)
        {
            maChiTietGiayXacNhan = 0;
            if (cbChiTietGiayXacNhan.ActiveRow != null)
            {
                maChiTietGiayXacNhan = Convert.ToInt32(cbChiTietGiayXacNhan.ActiveRow.Cells["MaChiTietGiayXacNhan"].Value);
            }
            //if (cbChiTietGiayXacNhan.Value != null &&maChiTietGiayXacNhan != 0)
            if (maChiTietGiayXacNhan != 0)
            {

                _tienChiTietGiayXacNhan = 0;
                if (cbChiTietGiayXacNhan.ActiveRow != null)
                {
                    maGiayXacNhan = (int)cbChiTietGiayXacNhan.ActiveRow.Cells["MaGiayXacNhan"].Value;
                    maChiTietGiayXacNhan = Convert.ToInt32(cbChiTietGiayXacNhan.Value);

                    maBoPhanDen = (int)cbChiTietGiayXacNhan.ActiveRow.Cells["MaBoPhanDen"].Value;
                    tenGiayXacNhan = (string)cbChiTietGiayXacNhan.ActiveRow.Cells["TenGiayXacNhan"].Value;
                    _hoanTat = (bool)cbChiTietGiayXacNhan.ActiveRow.Cells["HoanTat"].Value;
                    _tienChiTietGiayXacNhan = (decimal)cbChiTietGiayXacNhan.ActiveRow.Cells["SoTien"].Value;
                    nhapHo = (bool)cbChiTietGiayXacNhan.ActiveRow.Cells["DuocNhapHo"].Value;
                }
                cmbu_ChuongTrinh.Enabled = false;
                //GiayXacNhanChuongTrinh gxn = GiayXacNhanChuongTrinh.GetGiayXacNhanChuongTrinh(maGiayXacNhan);
                GiayXacNhanTongHop gxn = GiayXacNhanTongHop.GetGiayXacNhanChuongTrinh(maGiayXacNhan);

                maChuongTrinh = gxn.MaChuongTrinh;
                tenChuongTrinh = gxn.TenChuongTrinh;

                TbTongTienGXN.Value = _tienChiTietGiayXacNhan;

                cmbu_ChuongTrinh.EditValue = maChuongTrinh;

                chiTietGXN = ChiTietGiayXacNhanTongHop.GetChiTietGiayXacNhanTongHop(maChiTietGiayXacNhan);
                tbSoTienConLaiGXN.Value = chiTietGXN.SoTienConLai;
            }
            else
            {
                cmbu_ChuongTrinh.EditValue = 0;
                maChuongTrinh = 0;
                _tienChiTietGiayXacNhan = 0;
                TbTongTienGXN.Value = 0;
                tenGiayXacNhan = string.Empty;
                maGiayXacNhan = 0;
                maChiTietGiayXacNhan = 0;
                nhapHo = false;
            }
            _tongTienChoPhepCapNhat = TongSoTienToiDaChoPhepCapNhat();
        }

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_QuocGia);
        }

        private void tlslbl_ImportMau_Click(object sender, EventArgs e)
        {

            if (maChiThuLao == 0 && maChuongTrinh == 0)
            {
                MessageBox.Show("Vui lòng chọn chương trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string cnnExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dlg.FileName + ";Extended Properties='Excel 8.0;HDR=NO'";
                    OleDbDataAdapter daExcel = new OleDbDataAdapter("Select * From [DanhSachTheoPB$A7:F] ", cnnExcel);
                    DataTable tblExcel = new DataTable("Import");
                    daExcel.Fill(tblExcel);

                    daExcel.UpdateCommand = new OleDbCommand("Update [DanhSachTheoPB$A7:F] Set F6=? Where F2=?", daExcel.SelectCommand.Connection);
                    daExcel.UpdateCommand.Parameters.Add("p1", OleDbType.WChar, 8, "F6");
                    daExcel.UpdateCommand.Parameters.Add("p2", OleDbType.WChar, 20, "F2");

                    //thêm dữ liệu vào object và save lại
                    ThuLaoChuongTrinh objNew;
                    bool ok;
                    foreach (DataRow row in tblExcel.Rows)
                    {

                        ok = true;
                        if (row.IsNull("F2")) continue;

                        if (ok)
                        {
                            objNew = ERP_Library.ThuLaoChuongTrinh.NewThuLaoChuongTrinh();

                            objNew.ThanhToan = true;
                            objNew.MaChuongTrinh = maChuongTrinh;
                            objNew.MaKyTinhLuong = maKyTinhluong;
                            objNew.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                            objNew.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);

                            objNew.DienGiai = ghiChuPhieuChi;
                            objNew.TenChuongTrinh = tenChuongTrinh;
                            objNew.SoChungTu = soChungTu;
                            objNew.MaChiThuLao = maChiThuLao;
                            objNew.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
                            objNew.MaGiayXacNhan = maGiayXacNhan;
                            objNew.MaPhieuChi = soChungTu;
                            objNew.MaNguonChuongTrinh = maNguon;
                            objNew.TenNguonChuongTrinh = tenNguon;
                            objNew.ThucNhan = cbDinhMuc.Checked;

                            if (row["F2"].ToString() == string.Empty) return;

                            NhanVien nv = NhanVien.GetNhanVien_ByCMND(row["F2"].ToString());
                            BoPhan bp = BoPhan.GetBoPhan(nv.MaBoPhan);
                            objNew.MaQLNhanVien = nv.MaQLNhanVien;
                            objNew.MaQLBoPhan = bp.MaBoPhanQL;
                            objNew.MaBoPhan = nv.MaBoPhan;
                            objNew.MaChucVu = nv.MaChucVu;
                            objNew.TenBoPhan = nv.TenBoPhan;
                            objNew.TenChucVu = nv.TenChucVu;
                            objNew.MaNhanVien = nv.MaNhanVien;
                            objNew.TenNhanVien = nv.TenNhanVien;

                            objNew.SoTien = Convert.ToDecimal(row["F4"]);
                            objNew.DienGiai = row["F5"].ToString();

                            if (objNew.MaNhanVien != 0)
                            {
                                _thuLaoChuongTrinhList.Add(objNew);
                            }
                            row["F6"] = "OK";
                        }
                        else
                        {
                            row["F6"] = "Lỗi";
                        }
                    }
                   
                    daExcel.Update(tblExcel);
                    this.bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslbl_ExportMau_Click(object sender, EventArgs e)
        {
            try
            {
                frmExportThuLapImport frm = new frmExportThuLapImport(0);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private void cmbu_ChuongTrinh_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbu_ChuongTrinh.EditValue != null)
            {
                maChuongTrinh = Convert.ToInt32(cmbu_ChuongTrinh.EditValue);
                ChuongTrinh ct = ChuongTrinh.GetChuongTrinh(maChuongTrinh);
                tenChuongTrinh = ct.TenChuongTrinh;
                maNguon = ct.MaNguon;
                tenNguon = ct.TenNguon;
            }
        }

    }
}
