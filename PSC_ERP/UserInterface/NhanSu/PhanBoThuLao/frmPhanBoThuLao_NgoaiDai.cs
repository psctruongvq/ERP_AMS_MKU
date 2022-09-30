using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
namespace PSC_ERP.UserInterface.NhanSu.Thu_Lao
{
    public partial class frmPhanBoThuLao_NgoaiDai : Form
    {
        #region
        PhanBoThuLaoList _phanBoThuLaoList = PhanBoThuLaoList.NewPhanBoThuLaoList();
        ChuongTrinh _chuongTrinh;
        KyTinhLuong _kyTinhLuong;
        BoPhanList _boPhanList;
        NhanVienNgoaiDaiList _nhanVienNgoaiDaiList;
        ChuongTrinhList _chuongTrinhList;
        KyTinhLuongList _kyTinhLuongList;
        PhanBoThuLao _phanBoThuLao;
        PhanBoThuLaoNhanVienNgoaiDaiList _phanBoThuLaoNhanVienNgoaiDaiList = PhanBoThuLaoNhanVienNgoaiDaiList.NewPhanBoThuLaoNhanVienNgoaiDaiList();
        PhanBoThuLaoNhanVienNgoaiDai _phanBoThuLaoNhanVienNgoaiDai;
        CongViecList _congViecList;
        long _maChiTietPhanBoThuLao = 0;
        int _suaDuLieu = 0;
        int maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
        decimal _soTienChoPhepCapNhat = 0;
        Boolean _giayPhanBoDaHoanTat = false;

        SqlCommand command;
        DataSet dataset;
        ReportDocument Report;
        frmHienThiReport dlg;
        SqlDataAdapter adapter;
        DataTable table;
        ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);
        #endregion
        public frmPhanBoThuLao_NgoaiDai()
        {
            InitializeComponent();
            LoadForm();

            grdu_PhanBoThuLaoNhanVien.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_PhanBoThuLaoNhanVien.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_PhanBoThuLaoNhanVien.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));

            grdu_PhanBoThuLaoNhanVien.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_PhanBoThuLaoNhanVien.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_PhanBoThuLaoNhanVien.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
  
        }

        public frmPhanBoThuLao_NgoaiDai(int maPhanBoThuLao, long maChiTietPhanBoThuLao, DateTime ngayLap, Boolean daDuyet)
        {
            InitializeComponent();
            _maChiTietPhanBoThuLao = maChiTietPhanBoThuLao;
            LoadForm(maPhanBoThuLao, maChiTietPhanBoThuLao,ngayLap,daDuyet);

            grdu_PhanBoThuLaoNhanVien.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_PhanBoThuLaoNhanVien.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_PhanBoThuLaoNhanVien.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));

            grdu_PhanBoThuLaoNhanVien.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_PhanBoThuLaoNhanVien.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_PhanBoThuLaoNhanVien.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
  
        }

        public void LoadForm(int maPhanBoThuLao,long maChiTietPhanBoThuLao, DateTime ngayLap, Boolean daDuyet)
        {
            _phanBoThuLaoNhanVienNgoaiDai = PhanBoThuLaoNhanVienNgoaiDai.GetPhanBoThuLaoNhanVienNgoaiDaiByMaPhanBoThuLao(maPhanBoThuLao,ngayLap);

            _phanBoThuLaoNhanVienNgoaiDaiList = PhanBoThuLaoNhanVienNgoaiDaiList.GetPhanBoThuLaoNhanVienNgoaiDaiListByPhanBoThuLao(maPhanBoThuLao,maChiTietPhanBoThuLao,ngayLap);
            PhanBoThuLaoNhanVien_BindingSource.DataSource = _phanBoThuLaoNhanVienNgoaiDaiList;

            _phanBoThuLao = PhanBoThuLao.GetPhanBoThuLaoByMaPhanBoThuLao(maPhanBoThuLao, maChiTietPhanBoThuLao);
            txt_DienGiai.Text = ChiTietPhanBoThuLao.GetChiTietPhanBoThuLao(maChiTietPhanBoThuLao).GhiChu;
           // txt_DienGiai.Text = _phanBoThuLao.GhiChu;
            _nhanVienNgoaiDaiList = NhanVienNgoaiDaiList.NewNhanVienNgoaiDaiList();
            NhanVien_BindingSource.DataSource = _nhanVienNgoaiDaiList;

            PhanBoThuLao_BindingSource.DataSource = PhanBoThuLaoList.GetPhanBoThuLaoList_BoPhan(maBoPhan,maPhanBoThuLao,maChiTietPhanBoThuLao, 2);
            KyTinhLuong_BindingSource.DataSource = KyTinhLuong.GetKyTinhLuong(_phanBoThuLaoNhanVienNgoaiDai.MaKyTinhLuong);
            ChuongTrinh_BindingSource.DataSource = ChuongTrinh.GetChuongTrinh(_phanBoThuLaoNhanVienNgoaiDai.MaChuongTrinh);

            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList();
            CTAn_BindingSource.DataSource = _chuongTrinhList;

            _boPhanList = BoPhanList.GetBoPhanListBy_All();
            BoPhan _boPhan = BoPhan.NewBoPhan(0, "---Tất Cả---");
            _boPhanList.Insert(0, _boPhan);
            BoPhan_BindingSource.DataSource = _boPhanList;

            cmbu_PhanBoThuLao.Value = _phanBoThuLao.MaBoPhanDi;
            cmbu_KyTinhLuong.Value = _phanBoThuLaoNhanVienNgoaiDai.MaKyTinhLuong;
            cmbu_ChuongTrinh.Value = _phanBoThuLaoNhanVienNgoaiDai.MaChuongTrinh;
            cmbu_NgayLap.Value = _phanBoThuLaoNhanVienNgoaiDai.NgayLap;

            cbSoTien.Value = _phanBoThuLao.SoTien;
            cbSoTienConLai.Value = LaySoTienConLai(Convert.ToInt32(_phanBoThuLao.MaPhanBoThuLao),maChiTietPhanBoThuLao, maBoPhan, Convert.ToDecimal(_phanBoThuLao.SoTien));

            _suaDuLieu = 1;
            _soTienChoPhepCapNhat = TongSoTienToiDaChoPhepCapNhat();

            //Nếu giấy phân bổ thù lao đã hoàn tất thì không cho cập nhật dữ liệu
            if (KiemTraGiayPhanBoDaHoanTatChua(maChiTietPhanBoThuLao) > 0)
            {
                _giayPhanBoDaHoanTat = true;
            }
            //Nếu giấy phân bổ thù lao đã duyệt rồi thì không cho cập nhật dữ liệu
            if (daDuyet == true)
            {
                tlslblLuu.Enabled = false;
            }
        }

        public void LoadForm()
        {
            _phanBoThuLaoNhanVienNgoaiDaiList = PhanBoThuLaoNhanVienNgoaiDaiList.NewPhanBoThuLaoNhanVienNgoaiDaiList();
            PhanBoThuLaoNhanVien_BindingSource.DataSource = _phanBoThuLaoNhanVienNgoaiDaiList;
            
            _phanBoThuLaoList = PhanBoThuLaoList.GetPhanBoThuLaoList_BoPhan(maBoPhan, 2);
            PhanBoThuLao _thulao = PhanBoThuLao.NewPhanBoThuLaoKhoiTao("Không Có Chi Tiết");
            _phanBoThuLaoList.Insert(0, _thulao);
            PhanBoThuLao_BindingSource.DataSource = _phanBoThuLaoList;

            _nhanVienNgoaiDaiList = NhanVienNgoaiDaiList.NewNhanVienNgoaiDaiList();
            NhanVien_BindingSource.DataSource = _nhanVienNgoaiDaiList;

            _kyTinhLuongList = KyTinhLuongList.NewKyTinhLuongList();
            KyTinhLuong_BindingSource.DataSource = _kyTinhLuongList;

            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList();
            ChuongTrinh_BindingSource.DataSource = _chuongTrinhList;
            CTAn_BindingSource.DataSource = _chuongTrinhList;

            _congViecList = CongViecList.GetCongViecList();
            CongViec_BindingSource.DataSource = _congViecList;

            BoPhanDen_BindingSource.DataSource = BoPhanList.GetBoPhanListBy_All();

            _boPhanList = BoPhanList.GetBoPhanListBy_All();
            BoPhan _boPhan = BoPhan.NewBoPhan(0, "---Tất Cả---");
            _boPhanList.Insert(0, _boPhan);
            BoPhan_BindingSource.DataSource = _boPhanList;

            cmbu_NgayLap.Value = DateTime.Now.Date;
            if (cmbu_PhanBoThuLao.Value != null)
            {
                cmbu_PhanBoThuLao.Value = 0;
            }

            _suaDuLieu = 0;
            _giayPhanBoDaHoanTat = false;
            tlslblLuu.Enabled = true;

        }
        private void grdu_DanhSachNhanVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            foreach (UltraGridColumn col in this.grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Hidden = false;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenNganHang"].Hidden = false;

            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Chọn";
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "CMND";
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenNganHang"].Header.Caption = "Tên Ngân Hàng";
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.Caption = "Số Tài Khoản";

            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 2;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 3;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenNganHang"].Header.VisiblePosition = 4;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.VisiblePosition = 5;

            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["Check"].Width = 40;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 150;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["CMND"].Width = 100;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenNganHang"].Width = 180;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Width = 100;
        }

        private decimal TongSoTienToiDaChoPhepCapNhat()
        {
            decimal soTienDaPhanBo = 0;
            decimal soTienChoPhepCapNhat = 0;
            foreach (PhanBoThuLaoNhanVienNgoaiDai item in _phanBoThuLaoNhanVienNgoaiDaiList)
            {
                soTienDaPhanBo += item.SoTien;
            }
            soTienChoPhepCapNhat += soTienDaPhanBo + Convert.ToDecimal(cbSoTienConLai.Value);

            return soTienChoPhepCapNhat;
        }

        private void grdu_PhanBoThuLaoChuongTrinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ///tao su kien cho luoi
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;
          //  e.Layout.Override.CellClickAction = CellClickAction.CellSelect;

            foreach (UltraGridColumn col in this.grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }


            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTien"].CellClickAction = CellClickAction.CellSelect;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["DienGiai"].CellClickAction = CellClickAction.CellSelect;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].CellClickAction = CellClickAction.CellSelect;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].CellClickAction = CellClickAction.CellSelect;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["PhanTramThue"].CellClickAction = CellClickAction.CellSelect;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TienThue"].CellClickAction = CellClickAction.CellSelect;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].CellClickAction = CellClickAction.CellSelect;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTienConLai"].CellClickAction = CellClickAction.CellSelect;
           // grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["Check"].CellClickAction = CellClickAction.CellSelect;

            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["Check"].CellActivation = Activation.AllowEdit;

            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Chọn";
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["PhanTramThue"].Header.Caption = "% Thuế";
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TienThue"].Header.Caption = "Tiền Thuế";
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.Caption = "Tiền Còn Lại";
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";

            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 7;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["PhanTramThue"].Header.VisiblePosition = 3;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TienThue"].Header.VisiblePosition = 4;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.VisiblePosition = 5;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 6;

            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTien"].Width = 100;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 150;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 180;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["Check"].Width = 70;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TienThue"].Width = 100;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTienConLai"].Width = 110;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["PhanTramThue"].Width = 80;

            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
          //  grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["PhanTramThue"].Hidden = false;
          //  grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TienThue"].Hidden = false;
           // grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTienConLai"].Hidden = false;

            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTien"].Format = "#,###";
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTien"].PromptChar = ' ';

            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTienConLai"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTienConLai"].Format = "#,###";
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTienConLai"].PromptChar = ' ';

            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TienThue"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TienThue"].Format = "#,###";
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TienThue"].PromptChar = ' ';
        }



        private void cmbu_KyTinhLuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;
            cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";
            cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Width = 150;

            cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Header.VisiblePosition = 0;
        }



        private void cmbu_BoPhan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            // FilterCombo f = new FilterCombo(cmbu_BoPhanDi, "TenBoPhan");
            foreach (UltraGridColumn col in this.cmbu_BoPhan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 1;
            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cmbu_BoPhan.Width;
            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 0;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            DialogResult _DialogResult = MessageBox.Show("Bạn thật sự muốn thoát không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (_DialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public void DanhSachNhanVien()
        {
            int maBoPhan = Convert.ToInt32(cmbu_BoPhan.Value);

            if (maBoPhan == 0)
            {
                _nhanVienNgoaiDaiList = NhanVienNgoaiDaiList.GetNhanVienNgoaiDaiListBySuDung(false);
                NhanVien_BindingSource.DataSource = _nhanVienNgoaiDaiList;
            }
            else
            {
                _nhanVienNgoaiDaiList = NhanVienNgoaiDaiList.GetNhanVienNgoaiDaiList(maBoPhan, 0);
                NhanVien_BindingSource.DataSource = _nhanVienNgoaiDaiList;
            }
        }

        private void cmbu_BoPhan_AfterCloseUp(object sender, EventArgs e)
        {
            DanhSachNhanVien();
        }

        private void Check_TatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_TatCa.Checked == true)
            {
                for (int i = 0; i < grdu_DanhSachNhanVien.Rows.Count; i++)
                {
                    if (!grdu_DanhSachNhanVien.Rows[i].Hidden == true)
                    {
                        grdu_DanhSachNhanVien.Rows[i].Cells["Check"].Value = (object)true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < grdu_DanhSachNhanVien.Rows.Count; i++)
                {
                    grdu_DanhSachNhanVien.Rows[i].Cells["Check"].Value = (object)false;
                }
            }
        }

        public bool KiemTra()
        {
            Boolean kq = false;

            if (Convert.ToInt32(cmbu_PhanBoThuLao.Value) == 0 && _suaDuLieu == 0)
            {
                MessageBox.Show("Vui lòng chọn chi tiết phân bổ thù lao.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbu_PhanBoThuLao.Focus();
                kq = false;
            }
            else if (grdu_DanhSachNhanVien.Rows.Count == 0 && grdu_PhanBoThuLaoNhanVien.Rows.Count == 0 && _suaDuLieu == 0)
            {
                MessageBox.Show("Vui lòng chọn danh sách nhân viên.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbu_BoPhan.Focus();
                kq = false;
            }
            else if (Convert.ToInt32(cmbu_ChuongTrinh.Value) == 0)
            {
                kq = false;
            }
            else if (Convert.ToInt32(cmbu_KyTinhLuong.Value) == 0)
            {
                kq = false;
            }
            else
                kq = true;

            return kq;

        }

        public decimal TinhSoTienPhanBoThuLao(int maPhanBoThuLao)
        {
            decimal soTienConLai = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LaySoTienTrongPhanBoThuLao";
                    cm.Parameters.AddWithValue("@MaPhanBoThuLao", maPhanBoThuLao);
                    cm.Parameters.AddWithValue("@Bien", 2);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@SoTien", SqlDbType.VarChar, 30);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);

                    cm.ExecuteNonQuery();
                    soTienConLai = Convert.ToDecimal(cm.Parameters["@SoTien"].Value);
                }
            }//using
            return soTienConLai;
        }

        public int TinhSoDongPhanBoThuLao(int maPhanBoThuLao)
        {
            int soDong = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LaySoDongTrongPhanBoThuLao";
                    cm.Parameters.AddWithValue("@MaPhanBoThuLao", maPhanBoThuLao);
                    cm.Parameters.AddWithValue("@Bien", 2);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@SoDong", SqlDbType.VarChar, 30);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);

                    cm.ExecuteNonQuery();
                    soDong = Convert.ToInt32(cm.Parameters["@SoDong"].Value);
                }
            }//using
            return soDong;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (KiemTra() == true)
            {
                grdu_DanhSachNhanVien.UpdateData();

                //KyTinhLuong _kyTinhLuong = KyTinhLuong.GetKyTinhLuong((int)cmbu_KyTinhLuong.Value);
                //if (_kyTinhLuong.KhoaSoKy2 == true)
                //{
                //    MessageBox.Show("Kỳ này đã khóa sổ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                DialogResult _DialogResult = MessageBox.Show("Bạn có đồng ý đưa nhân viên qua ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (_DialogResult == DialogResult.Yes)
                {
                    for (int i = 0; i < grdu_DanhSachNhanVien.Rows.Count; i++)
                    {
                        if ((bool)grdu_DanhSachNhanVien.Rows[i].Cells["Check"].Value == true)
                        {
                            if ((int)grdu_DanhSachNhanVien.Rows[i].Cells["MaNganHang"].Value == 0)
                            {
                                MessageBox.Show("[" + grdu_DanhSachNhanVien.Rows[i].Cells["TenNhanVien"].Value + "] chưa có ngân hàng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                _phanBoThuLaoNhanVienNgoaiDaiList = PhanBoThuLaoNhanVienNgoaiDaiList.NewPhanBoThuLaoNhanVienNgoaiDaiList();
                                return;
                            }
                            else if (grdu_DanhSachNhanVien.Rows[i].Cells["SoTaiKhoan"].Value.ToString().Replace(" ", "") == "")
                            {
                                MessageBox.Show("[" + grdu_DanhSachNhanVien.Rows[i].Cells["TenNhanVien"].Value + "] chưa có số tài khoản.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                _phanBoThuLaoNhanVienNgoaiDaiList = PhanBoThuLaoNhanVienNgoaiDaiList.NewPhanBoThuLaoNhanVienNgoaiDaiList();
                                return;
                            }
                            else if ((int)grdu_DanhSachNhanVien.Rows[i].Cells["MaQuocGia"].Value == 0)
                            {
                                MessageBox.Show("[" + grdu_DanhSachNhanVien.Rows[i].Cells["TenNhanVien"].Value + "] chưa có quốc gia.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                _phanBoThuLaoNhanVienNgoaiDaiList = PhanBoThuLaoNhanVienNgoaiDaiList.NewPhanBoThuLaoNhanVienNgoaiDaiList();
                                return;
                            }
                            else if (grdu_DanhSachNhanVien.Rows[i].Cells["DiaChi"].Value.ToString().Replace(" ", "") == "")
                            {
                                MessageBox.Show("[" + grdu_DanhSachNhanVien.Rows[i].Cells["TenNhanVien"].Value + "] chưa có địa chỉ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                _phanBoThuLaoNhanVienNgoaiDaiList = PhanBoThuLaoNhanVienNgoaiDaiList.NewPhanBoThuLaoNhanVienNgoaiDaiList();
                                return;
                            }
                            else if (grdu_DanhSachNhanVien.Rows[i].Cells["Cmnd"].Value.ToString().Replace(" ", "") == "")
                            {
                                MessageBox.Show("[" + grdu_DanhSachNhanVien.Rows[i].Cells["TenNhanVien"].Value + "] chưa có chứng minh nhân dân.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                _phanBoThuLaoNhanVienNgoaiDaiList = PhanBoThuLaoNhanVienNgoaiDaiList.NewPhanBoThuLaoNhanVienNgoaiDaiList();
                                return;
                            }
                            else if (grdu_DanhSachNhanVien.Rows[i].Cells["NoiCap"].Value.ToString().Replace(" ", "") == "")
                            {
                                MessageBox.Show("[" + grdu_DanhSachNhanVien.Rows[i].Cells["TenNhanVien"].Value + "] chưa có nơi cấp.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                _phanBoThuLaoNhanVienNgoaiDaiList = PhanBoThuLaoNhanVienNgoaiDaiList.NewPhanBoThuLaoNhanVienNgoaiDaiList();
                                return;
                            }
                            else if ((DateTime)grdu_DanhSachNhanVien.Rows[i].Cells["NgayCap"].Value == null || (DateTime)grdu_DanhSachNhanVien.Rows[i].Cells["NgayCap"].Value == Convert.ToDateTime("01-01-0001"))
                            {
                                MessageBox.Show("[" + grdu_DanhSachNhanVien.Rows[i].Cells["TenNhanVien"].Value + "] chưa có ngày cấp.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                _phanBoThuLaoNhanVienNgoaiDaiList = PhanBoThuLaoNhanVienNgoaiDaiList.NewPhanBoThuLaoNhanVienNgoaiDaiList();
                                return;
                            }
                            else
                            {//Thỏa các điều kiện trên

                                _phanBoThuLaoNhanVienNgoaiDai = PhanBoThuLaoNhanVienNgoaiDai.NewPhanBoThuLaoNhanVienNgoaiDai();
                                ////cai dat gia tri cho phan bo thu lao chuong trinh
                                _phanBoThuLaoNhanVienNgoaiDai.MaChuongTrinh = _phanBoThuLao.MaChuongTrinh;
                                _phanBoThuLaoNhanVienNgoaiDai.TenChuongTrinh = ChuongTrinh.GetChuongTrinh(_phanBoThuLao.MaChuongTrinh).TenChuongTrinh;
                                _phanBoThuLaoNhanVienNgoaiDai.MaKyTinhLuong = _phanBoThuLao.MaKyTinhLuong;
                                _phanBoThuLaoNhanVienNgoaiDai.NgayLap = Convert.ToDateTime(cmbu_NgayLap.Value);
                                _phanBoThuLaoNhanVienNgoaiDai.NguoiLap = Convert.ToInt32(ERP_Library.Security.CurrentUser.Info.UserID);
                                _phanBoThuLaoNhanVienNgoaiDai.MaPhanBoThuLao = _phanBoThuLao.MaPhanBoThuLao;
                                ///chi lay bo phan luc dang nhap he thong
                                _phanBoThuLaoNhanVienNgoaiDai.MaChiTietPhanBoThuLao = ChiTietPhanBoThuLao.GetChiTietPhanBoThuLaoByMaBoPhan_MaPhanBo(_maChiTietPhanBoThuLao, maBoPhan).MaChiTietPhanBoThuLao;
                                _phanBoThuLaoNhanVienNgoaiDai.MaCongViec = ChiTietPhanBoThuLao.GetChiTietPhanBoThuLaoByMaBoPhan_MaPhanBo(_maChiTietPhanBoThuLao, maBoPhan).MaCongViec;
                                //
                                _phanBoThuLaoNhanVienNgoaiDai.DuocNhapHo = true;
                                _phanBoThuLaoNhanVienNgoaiDai.ThanhToan = true;
                                _phanBoThuLaoNhanVienNgoaiDai.MaChiTietGiayXacNhan = _phanBoThuLao.MaChiTietGiayXacNhan;
                                _phanBoThuLaoNhanVienNgoaiDai.MaGiayXacNhan = _phanBoThuLao.MaGiayXacNhanChuongTrinh;
                                _phanBoThuLaoNhanVienNgoaiDai.DienGiai = PhanBoThuLao.GetPhanBoThuLao(_phanBoThuLao.MaPhanBoThuLao).GhiChu;
                                // _phanBoThuLaoNhanVienNgoaiDai.PhanTramThue = 10;
                                //
                                _phanBoThuLaoNhanVienNgoaiDai.MaNhanVien = (long)grdu_DanhSachNhanVien.Rows[i].Cells["MaNhanVien"].Value;
                                _phanBoThuLaoNhanVienNgoaiDai.TenNhanVien = Convert.ToString(grdu_DanhSachNhanVien.Rows[i].Cells["TenNhanVien"].Value);
                                _phanBoThuLaoNhanVienNgoaiDai.MaBoPhan = (int)grdu_DanhSachNhanVien.Rows[i].Cells["MaBoPhan"].Value;
                                _phanBoThuLaoNhanVienNgoaiDai.TenBoPhan = Convert.ToString(grdu_DanhSachNhanVien.Rows[i].Cells["TenBoPhan"].Value);
                                _phanBoThuLaoNhanVienNgoaiDai.MaQLBoPhan = BoPhan.GetBoPhan(_phanBoThuLaoNhanVienNgoaiDai.MaBoPhan).MaBoPhanQL;
                                _phanBoThuLaoNhanVienNgoaiDai.Cmnd = Convert.ToString(grdu_DanhSachNhanVien.Rows[i].Cells["CMND"].Value);
                                _phanBoThuLaoNhanVienNgoaiDai.MaSoThue = Convert.ToString(grdu_DanhSachNhanVien.Rows[i].Cells["MST"].Value);
                                _phanBoThuLaoNhanVienNgoaiDai.MaNhanVienChuyenTien = Convert.ToInt32(grdu_DanhSachNhanVien.Rows[i].Cells["MaNhanVienChuyenTien"].Value);
                                _phanBoThuLaoNhanVienNgoaiDai.DiaChi = Convert.ToString(grdu_DanhSachNhanVien.Rows[i].Cells["DiaChi"].Value);
                                _phanBoThuLaoNhanVienNgoaiDai.DienThoai = Convert.ToString(grdu_DanhSachNhanVien.Rows[i].Cells["DienThoai"].Value);

                                _phanBoThuLaoNhanVienNgoaiDaiList.Add(_phanBoThuLaoNhanVienNgoaiDai);
                            }
                        }

                    }

                    PhanBoThuLaoNhanVien_BindingSource.DataSource = _phanBoThuLaoNhanVienNgoaiDaiList;
                    ///reload lai danh sach nhan vien
                    for (int j = 0; j < grdu_DanhSachNhanVien.Rows.Count; j++)
                    {
                        if ((bool)grdu_DanhSachNhanVien.Rows[j].Cells["Check"].Value == true)
                        {
                            grdu_DanhSachNhanVien.Rows[j].Cells["Check"].Value = false;
                            grdu_DanhSachNhanVien.Rows[j].Hidden = true;
                        }
                    }

                    Check_TatCa.Checked = false;

                    this.NhanVien_BindingSource.DataSource = _nhanVienNgoaiDaiList;
                }
            }
            else
            {
                return;
            }
        }

        private void Check_TatCaThuLao_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_TatCaThuLao.Checked == true)
            {
                for (int i = 0; i < grdu_PhanBoThuLaoNhanVien.Rows.Count; i++)
                {
                    if (!grdu_PhanBoThuLaoNhanVien.Rows[i].Hidden == true)
                    {
                        grdu_PhanBoThuLaoNhanVien.Rows[i].Cells["Check"].Value = (object)true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < grdu_PhanBoThuLaoNhanVien.Rows.Count; i++)
                {
                    grdu_PhanBoThuLaoNhanVien.Rows[i].Cells["Check"].Value = (object)false;
                }
            }
        }

        public decimal TinhLaiSoTienConLai()
        {
            decimal _soTienConLai = 0;
            if (grdu_PhanBoThuLaoNhanVien.Rows.Count > 0)
            {
                for (int i = 0; i < grdu_PhanBoThuLaoNhanVien.Rows.Count; i++)
                {
                    _soTienConLai += Convert.ToDecimal(grdu_PhanBoThuLaoNhanVien.Rows[i].Cells["SoTien"].Value);
                }
            }
            return _soTienConLai;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            decimal _SoTien = 0;

            KyTinhLuong _kyTinhLuong = KyTinhLuong.GetKyTinhLuong((int)cmbu_KyTinhLuong.Value);
            if (_kyTinhLuong.KhoaSoKy2 == true)
            {
                MessageBox.Show("Kỳ này đã khóa sổ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (grdu_PhanBoThuLaoNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (int i = 0; i < grdu_PhanBoThuLaoNhanVien.Rows.Count; i++)
            {
                if ((bool)grdu_PhanBoThuLaoNhanVien.Rows[i].Cells["Check"].Value == true)
                {
                    grdu_PhanBoThuLaoNhanVien.Rows[i].Selected = true;
                }
            }

            //cap nhat lai so tien con lai tren from
            //_soTienPhanBo = TinhSoTienPhanBoThuLao(Convert.ToInt32(cmbu_PhanBoThuLao.Value));
            //_SoTien = _soTienPhanBo + LaySoTienConLai(Convert.ToInt32(cmbu_PhanBoThuLao.Value), maBoPhan, Convert.ToDecimal(cbSoTien.Value));
            //cbSoTienConLai.Value = _SoTien;

            ////xoa du lieu
            grdu_PhanBoThuLaoNhanVien.DeleteSelectedRows();

            Check_TatCaThuLao.Checked = false;

            /////load lai danh sach nhan vien
            if (cmbu_BoPhan.Value != null)
            {
                DanhSachNhanVien();
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            decimal tongSoTienPhanBo = 0;
            decimal soTienChiTietPhanBo = 0;
            int bien = 0;

            if (_giayPhanBoDaHoanTat == true)
            {
                MessageBox.Show("Giấy phân bổ đã hoàn tất. Không thể cập nhật.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (KiemTra() == true)
            {
                //KyTinhLuong kyTinhLuong = KyTinhLuong.GetKyTinhLuong((int)cmbu_KyTinhLuong.Value);
                //if (kyTinhLuong.KhoaSoKy2 == true)
                //{
                //    MessageBox.Show("Kỳ này đã khóa sổ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                if (grdu_PhanBoThuLaoNhanVien.Rows.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm dữ liệu vào danh sách thù lao.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //// kiem tra (tong so tien) trong phan bo thu lao nhan vien ngoai = so tien trong chi tiet phan bo thu lao
                foreach (PhanBoThuLaoNhanVienNgoaiDai item in _phanBoThuLaoNhanVienNgoaiDaiList)
                {
                    tongSoTienPhanBo += item.SoTien;
                    if (item.SoTien <= 0)
                    {
                        bien = 1;
                    }
                }
                soTienChiTietPhanBo = Convert.ToDecimal(cbSoTien.Value);

                if (bien == 1)
                {
                    MessageBox.Show("Số tiền của nhân viên không được để trống.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_suaDuLieu == 0)
                {
                    if (Convert.ToDecimal(cbSoTienConLai.Value) < tongSoTienPhanBo - TinhSoTienPhanBoThuLao((int)_phanBoThuLao.MaPhanBoThuLao) || Convert.ToDecimal(cbSoTienConLai.Value) < tongSoTienPhanBo)
                    {
                        MessageBox.Show("Tổng tiền trong Danh Sách Phân Bổ bé hơn hoặc bằng với Số Tiền Còn Lại trong Chi Tiết Phân Bổ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    if (tongSoTienPhanBo > _soTienChoPhepCapNhat || Convert.ToDecimal(cbSoTienConLai.Value) < tongSoTienPhanBo - TinhSoTienPhanBoThuLao((int)_phanBoThuLao.MaPhanBoThuLao))
                    {
                        MessageBox.Show("Tổng tiền trong Danh Sách Phân Bổ bé hơn hoặc bằng với Số Tiền Còn Lại trong Chi Tiết Phân Bổ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                ///cap nhat lai du lieu truoc khi luu
                foreach (PhanBoThuLaoNhanVienNgoaiDai item in _phanBoThuLaoNhanVienNgoaiDaiList)
                {
                    item.MaChuongTrinh = _phanBoThuLao.MaChuongTrinh;
                    item.TenChuongTrinh = ChuongTrinh.GetChuongTrinh(_phanBoThuLao.MaChuongTrinh).TenChuongTrinh;
                    item.MaKyTinhLuong = _phanBoThuLao.MaKyTinhLuong;
                    item.NgayLap = Convert.ToDateTime(cmbu_NgayLap.Value);
                    item.NguoiLap = Convert.ToInt32(ERP_Library.Security.CurrentUser.Info.UserID);
                    item.MaPhanBoThuLao = _phanBoThuLao.MaPhanBoThuLao;
                    ///chi lay bo phan luc dang nhap he thong
                    item.MaChiTietPhanBoThuLao = ChiTietPhanBoThuLao.GetChiTietPhanBoThuLaoByMaBoPhan_MaPhanBo(_maChiTietPhanBoThuLao, maBoPhan).MaChiTietPhanBoThuLao;
                    item.MaCongViec = ChiTietPhanBoThuLao.GetChiTietPhanBoThuLaoByMaBoPhan_MaPhanBo(_maChiTietPhanBoThuLao, maBoPhan).MaCongViec;
                    //
                    item.DuocNhapHo = true;
                    item.ThanhToan = true;
                    item.MaChiTietGiayXacNhan = _phanBoThuLao.MaChiTietGiayXacNhan;
                    item.MaGiayXacNhan = _phanBoThuLao.MaGiayXacNhanChuongTrinh;

                }

                ///lu du lieu 
                _phanBoThuLaoNhanVienNgoaiDai.ApplyEdit();
                _phanBoThuLaoNhanVienNgoaiDaiList.ApplyEdit();
                PhanBoThuLaoNhanVien_BindingSource.EndEdit();
                _phanBoThuLaoNhanVienNgoaiDaiList.Save();

                MessageBox.Show("Cập nhật thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cbSoTienConLai.Value = LaySoTienConLai((int)_phanBoThuLao.MaPhanBoThuLao, _maChiTietPhanBoThuLao, maBoPhan, Convert.ToDecimal(cbSoTien.Value));

                {//Refesh lại dữ liệu

                    cmbu_ChuongTrinh.Value = null;
                    cmbu_KyTinhLuong.Value = null;
                    cbSoTien.Value = 0;
                    cbSoTienConLai.Value = 0;
                    cmbu_PhanBoThuLao.Value = 0;
                    _suaDuLieu = 0;

                    _phanBoThuLaoNhanVienNgoaiDaiList = PhanBoThuLaoNhanVienNgoaiDaiList.NewPhanBoThuLaoNhanVienNgoaiDaiList();
                    PhanBoThuLaoNhanVien_BindingSource.DataSource = _phanBoThuLaoNhanVienNgoaiDaiList;

                    _phanBoThuLaoList = PhanBoThuLaoList.GetPhanBoThuLaoList_BoPhan(maBoPhan, 2);
                    PhanBoThuLao _thulao = PhanBoThuLao.NewPhanBoThuLaoKhoiTao("Không Có Chi Tiết");
                    _phanBoThuLaoList.Insert(0, _thulao);
                    PhanBoThuLao_BindingSource.DataSource = _phanBoThuLaoList;

                    cmbu_NgayLap.Value = DateTime.Now.Date;
                }
                //_suaDuLieu = 1;
                //_soTienChoPhepCapNhat = TongSoTienToiDaChoPhepCapNhat();

            }
        }

        private void cmbu_PhanBoThuLao_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            FilterCombo f = new FilterCombo(cmbu_PhanBoThuLao, "MaPhanBoThuLaoQL");
            t.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoThuLaoQL"].Header.Caption = "Mã Phân Bổ";
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Header.Caption = "Chương Trình";
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["GhiChuChiTietPBTL"].Header.Caption = "Ghi Chú Chi Tiết Phân Bổ";
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["TenCongViec"].Header.Caption = "Công Việc";

            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].EditorComponent = cmbu_ChuongTrinhAn;

            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoThuLaoQL"].Header.VisiblePosition = 0;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Header.VisiblePosition = 1;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 3;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["GhiChuChiTietPBTL"].Header.VisiblePosition = 4;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Header.VisiblePosition = 5;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["TenCongViec"].Header.VisiblePosition = 6;

            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoThuLaoQL"].Width = 150;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Width = 150;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Width = 150;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 300;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["GhiChuChiTietPBTL"].Width = 300;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Width = 200;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["TenCongViec"].Width = 200;

            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoThuLaoQL"].Hidden = false;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Hidden = false;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["GhiChuChiTietPBTL"].Hidden = false;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Hidden = false;
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["TenCongViec"].Hidden = false;

            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Format = "#,###";
            cmbu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].PromptChar = ' ';
        }

        public int KiemTraPhanBoThuLao(int maPhanBoThuLao, int maBoPhan)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraPhanBoThuLao";
                    cm.Parameters.AddWithValue("@MaPhanBoThuLao", maPhanBoThuLao);
                    cm.Parameters.AddWithValue("@Bien", 2);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTri", SqlDbType.VarChar, 30);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);

                    cm.ExecuteNonQuery();
                    gt = Convert.ToInt32(cm.Parameters["@GiaTri"].Value);
                }
            }//using
            return gt;
        }

        public decimal LaySoTienConLai(int maPhanBoThuLao,long maChiTiet, int maBoPhan, decimal soTien)
        {
            decimal soTienConLai = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LaySoTienConLaiTrongPhanBoThuLao";
                    cm.Parameters.AddWithValue("@MaPhanBoThuLao", maPhanBoThuLao);
                    cm.Parameters.AddWithValue("@SoTien", soTien);
                    cm.Parameters.AddWithValue("@MaChiTietPhanBoThuLao", maChiTiet);
                    cm.Parameters.Add("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@SoTienConLai", SqlDbType.VarChar, 30);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);

                    cm.ExecuteNonQuery();
                    soTienConLai = Convert.ToDecimal(cm.Parameters["@SoTienConLai"].Value);
                }
            }//using
            return soTienConLai;
        }

        public int KiemTraGiayPhanBoDaHoanTatChua(long maChiTietPhanBo)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraGiayPhanBoThuLaoDaHoanTatChua";
                    cm.Parameters.AddWithValue("@MaChiTietPhanBo", maChiTietPhanBo);
                    cm.Parameters.AddWithValue("@GiaTri", gt);
                    cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();
                    gt = (int)cm.Parameters["@GiaTri"].Value;
                }
            }//using
            return gt;
        }

        private void cmbu_PhanBoThuLao_AfterCloseUp(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbu_PhanBoThuLao.Value) == 0)
            {
                cmbu_ChuongTrinh.Value = null;
                cmbu_KyTinhLuong.Value = null;
                cbSoTien.Value = 0;
                cbSoTienConLai.Value = 0;
                return;
            }
            else
            {
                 _maChiTietPhanBoThuLao = Convert.ToInt64(cmbu_PhanBoThuLao.Value);

                _phanBoThuLao = PhanBoThuLao.GetPhanBoThuLaoByMaChiTiet(_maChiTietPhanBoThuLao);
                txt_DienGiai.Text = _phanBoThuLao.GhiChu;

                if (_phanBoThuLao != null)
                {
                    _chuongTrinh = ChuongTrinh.GetChuongTrinh(_phanBoThuLao.MaChuongTrinh);
                    cmbu_ChuongTrinh.Value = _chuongTrinh.MaChuongTrinh;
                    ChuongTrinh_BindingSource.DataSource = _chuongTrinh;

                    _kyTinhLuong = KyTinhLuong.GetKyTinhLuong(_phanBoThuLao.MaKyTinhLuong);
                    cmbu_KyTinhLuong.Value = _kyTinhLuong.MaKy;
                    KyTinhLuong_BindingSource.DataSource = _kyTinhLuong;

                    cbSoTien.Value = ChiTietPhanBoThuLao.GetChiTietPhanBoThuLaoByMaBoPhan_MaPhanBo(_maChiTietPhanBoThuLao, maBoPhan).SoTien;
                    cbSoTienConLai.Value = LaySoTienConLai((int)_phanBoThuLao.MaPhanBoThuLao,_maChiTietPhanBoThuLao, maBoPhan, Convert.ToDecimal(cbSoTien.Value));

                    _soTienChoPhepCapNhat = TongSoTienToiDaChoPhepCapNhat();
                }
            }
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            cmbu_ChuongTrinh.Value = null;
            cmbu_KyTinhLuong.Value = null;
            cbSoTien.Value = 0;
            cbSoTienConLai.Value = 0;
            cmbu_PhanBoThuLao.Value = 0;          
            _suaDuLieu = 0;

            _phanBoThuLaoNhanVienNgoaiDaiList = PhanBoThuLaoNhanVienNgoaiDaiList.NewPhanBoThuLaoNhanVienNgoaiDaiList();
            PhanBoThuLaoNhanVien_BindingSource.DataSource = _phanBoThuLaoNhanVienNgoaiDaiList;

            _phanBoThuLaoList = PhanBoThuLaoList.GetPhanBoThuLaoList_BoPhan(maBoPhan, 2);
            PhanBoThuLao _thulao = PhanBoThuLao.NewPhanBoThuLaoKhoiTao("Không Có Chi Tiết");
            _phanBoThuLaoList.Insert(0, _thulao);
            PhanBoThuLao_BindingSource.DataSource = _phanBoThuLaoList;

            cmbu_NgayLap.Value = DateTime.Now.Date;
        }

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
                    if (iscopyok && grdu_PhanBoThuLaoNhanVien.Selected != null && grdu_PhanBoThuLaoNhanVien.Selected.Cells != null)
                    {
                        e.Cancel = true;
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridCell item in grdu_PhanBoThuLaoNhanVien.Selected.Cells)
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

        private void grdData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdu_PhanBoThuLaoNhanVien.ActiveRow.IsFilterRow != true)
            {
                if (iskeyok && grdu_PhanBoThuLaoNhanVien.ActiveCell.Row.IsDataRow)
                {
                    if (grdu_PhanBoThuLaoNhanVien.ActiveCell.Column.DataType == typeof(decimal))
                        try
                        {
                            grdu_PhanBoThuLaoNhanVien.ActiveCell.Value = Convert.ToDecimal(e.KeyChar.ToString());
                        }
                        catch
                        { }
                    else
                        grdu_PhanBoThuLaoNhanVien.ActiveCell.Value = e.KeyChar.ToString();
                    grdu_PhanBoThuLaoNhanVien.ActiveCell.SelStart = grdu_PhanBoThuLaoNhanVien.ActiveCell.Text.Length;
                    e.Handled = true;
                    iskeyok = false;
                }
            }
        }
        private bool iskeyok = false;//xử lý key cho cột string
        private void grdData_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdu_PhanBoThuLaoNhanVien.ActiveRow.IsFilterRow != true)
            {
                if (grdu_PhanBoThuLaoNhanVien.ActiveCell != null && !grdu_PhanBoThuLaoNhanVien.ActiveCell.IsInEditMode )
                {
                    if ((e.KeyData >= Keys.A && e.KeyData <= Keys.Z) || (e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9))
                    {
                        grdu_PhanBoThuLaoNhanVien.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        grdu_PhanBoThuLaoNhanVien.ActiveCell.SelectAll();
                        iskeyok = true;
                    }
                    if (e.KeyCode == Keys.Space && grdu_PhanBoThuLaoNhanVien.ActiveCell.Column.DataType == typeof(bool))
                    {
                        grdu_PhanBoThuLaoNhanVien.ActiveCell.Value = !Convert.ToBoolean(grdu_PhanBoThuLaoNhanVien.ActiveCell.Value);
                    }
                }
            }
        }

        private void tlsblInDanhSachTongHop_Click(object sender, EventArgs e)
        {
            string kiTenNguoiLap = "";
            string kiTenThuTruong = "";
            string kiTenBanPhuTrach = "";

            if (nguoiky.NguoiLapTieude.Trim() != "")
            {
                kiTenNguoiLap = "\r\n (Họ và tên)";
            }
            if (nguoiky.ThuTruongTieude.Trim() != "")
            {
                kiTenThuTruong = "\r\n (Họ và tên)";
            }
            if (nguoiky.BptTieude.Trim() != "")
            {
                kiTenBanPhuTrach = "\r\n (Họ và tên)";
            } 

            Report = new Report.DanhSachPhanBoThuLaoChiTiet__NgoaiDai_DSNVTH();
            command = new SqlCommand();
            dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_DanhSachPhanBoThuLaoChuongTrinh_DSTHNgoaiDai";
            command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(cmbu_NgayLap.Value));
            command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(cmbu_NgayLap.Value));
            command.Parameters.AddWithValue("@MaNhanVien", 0);
            command.Parameters.AddWithValue("@MaChuongTrinh", 0);
            command.Parameters.AddWithValue("@MaBoPhan", 0);
            command.Parameters.AddWithValue("@MaPhanBoThuLao", _maChiTietPhanBoThuLao);
            command.Parameters.AddWithValue("@Loai", 1);
            command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            command.CommandTimeout = 90;
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_DanhSachPhanBoThuLaoChuongTrinh_DSTHNgoaiDai;1";
            dataset.Tables.Add(table);
            Report.SetDataSource(dataset);
            Report.SetParameterValue("TenNguoiLap", nguoiky.NguoiLapTen);
            Report.SetParameterValue("TenBPT", nguoiky.BptTen);
            Report.SetParameterValue("TenThuTruong", nguoiky.ThuTruongTen);
            Report.SetParameterValue("_tuNgay", Convert.ToDateTime(cmbu_NgayLap.Value));
            Report.SetParameterValue("_denNgay", Convert.ToDateTime(cmbu_NgayLap.Value));
            Report.SetParameterValue("NguoiLapBang", nguoiky.NguoiLapTieude + kiTenNguoiLap);
            Report.SetParameterValue("BanPhuTrach", nguoiky.BptTieude + kiTenBanPhuTrach);
            Report.SetParameterValue("ThuTruongDonVi", nguoiky.ThuTruongTieude + kiTenThuTruong);
            Report.SetParameterValue("_PTTToan", "Chuyển Khoản");
            Report.SetParameterValue("_TenBoPhanDangNhap", BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
            dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        private void tlsblInDanhSachChiTiet_Click(object sender, EventArgs e)
        {
            string kiTenNguoiLap = "";
            string kiTenThuTruong = "";
            string kiTenBanPhuTrach = "";

            if (nguoiky.NguoiLapTieude.Trim() != "")
            {
                kiTenNguoiLap = "\r\n (Họ và tên)";
            }
            if (nguoiky.ThuTruongTieude.Trim() != "")
            {
                kiTenThuTruong = "\r\n (Họ và tên)";
            }
            if (nguoiky.BptTieude.Trim() != "")
            {
                kiTenBanPhuTrach = "\r\n (Họ và tên)";
            } 

            Report = new Report.DanhSachPhanBoThuLaoChiTiet_NgoaiDai();
            command = new SqlCommand();
            dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_DanhSachPhanBoThuLaoNhanVienNgoaiDai_CTNV";
            command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(cmbu_NgayLap.Value));
            command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(cmbu_NgayLap.Value));
            command.Parameters.AddWithValue("@MaNhanVien", 0);
            command.Parameters.AddWithValue("@MaChuongTrinh", 0);
            command.Parameters.AddWithValue("@MaBoPhan", 0);
            command.Parameters.AddWithValue("@MaPhanBoThuLao", _maChiTietPhanBoThuLao);
            command.Parameters.AddWithValue("@Loai", 1);
            command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            command.CommandTimeout = 0;
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_DanhSachPhanBoThuLaoNhanVienNgoaiDai_CTNV;1";
            dataset.Tables.Add(table);
            Report.SetDataSource(dataset);
            Report.SetParameterValue("TenNguoiLap", nguoiky.NguoiLapTen);
            Report.SetParameterValue("TenBPT", nguoiky.BptTen);
            Report.SetParameterValue("TenThuTruong", nguoiky.ThuTruongTen);
            Report.SetParameterValue("_tuNgay", Convert.ToDateTime(cmbu_NgayLap.Value));
            Report.SetParameterValue("_denNgay", Convert.ToDateTime(cmbu_NgayLap.Value));
            Report.SetParameterValue("NguoiLapBang", nguoiky.NguoiLapTieude + kiTenNguoiLap);
            Report.SetParameterValue("BanPhuTrach", nguoiky.BptTieude + kiTenBanPhuTrach);
            Report.SetParameterValue("ThuTruongDonVi", nguoiky.ThuTruongTieude + kiTenThuTruong);
            Report.SetParameterValue("_PTTToan", "Chuyển Khoản");
            Report.SetParameterValue("_TenBoPhanDangNhap", BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
            dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

      
    }
}

