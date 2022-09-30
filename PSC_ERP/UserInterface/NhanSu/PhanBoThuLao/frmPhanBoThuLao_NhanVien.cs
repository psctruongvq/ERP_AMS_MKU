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

    public partial class frmPhanBoThuLao_NhanVien : Form
    {
        #region
        PhanBoThuLaoList _phanBoThuLaoList = PhanBoThuLaoList.NewPhanBoThuLaoList();
        ChuongTrinh _chuongTrinh;
        KyTinhLuong _kyTinhLuong;
        BoPhanList _boPhanList;
        ThongTinNhanVienTongHopList _thongTinNhanVienTongHopList;
        ChuongTrinhList _chuongTrinhList;
        KyTinhLuongList _kyTinhLuongList;
        PhanBoThuLao _phanBoThuLao;
        PhanBoThuLaoNhanVienList _phanBoThuLaoNhanVienList = PhanBoThuLaoNhanVienList.NewPhanBoThuLaoNhanVienList();
        PhanBoThuLaoNhanVien _phanBoThuLaoNhanVien;
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
        public frmPhanBoThuLao_NhanVien()
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

        public frmPhanBoThuLao_NhanVien(int maPhanBoThuLao, long maChiTietPhanBoThuLao, DateTime ngayLap, Boolean daDuyet)
        {
            InitializeComponent();
            _maChiTietPhanBoThuLao = maChiTietPhanBoThuLao;
            LoadForm(maPhanBoThuLao,maChiTietPhanBoThuLao, ngayLap,daDuyet);

            grdu_PhanBoThuLaoNhanVien.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_PhanBoThuLaoNhanVien.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_PhanBoThuLaoNhanVien.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));

            grdu_PhanBoThuLaoNhanVien.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_PhanBoThuLaoNhanVien.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_PhanBoThuLaoNhanVien.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
  
        }

        public void LoadForm(int maPhanBoThuLao,long maChiTietPhanBoThuLao , DateTime ngayLap, Boolean daDuyet)
        {
            _phanBoThuLaoNhanVien = PhanBoThuLaoNhanVien.GetPhanBoThuLaoNhanVienByMaPhanBoThuLao(maPhanBoThuLao,ngayLap);

            _phanBoThuLaoNhanVienList = PhanBoThuLaoNhanVienList.GetPhanBoThuLaoNhanVienListByPhanBoThuLao(maPhanBoThuLao, maChiTietPhanBoThuLao, ngayLap);
            PhanBoThuLaoNhanVien_BindingSource.DataSource = _phanBoThuLaoNhanVienList;

            _phanBoThuLao = PhanBoThuLao.GetPhanBoThuLaoByMaPhanBoThuLao(maPhanBoThuLao,maChiTietPhanBoThuLao);

            txt_DienGiai.Text = ChiTietPhanBoThuLao.GetChiTietPhanBoThuLao(maChiTietPhanBoThuLao).GhiChu;
           // txt_DienGiai.Text = _phanBoThuLao.GhiChu;
            _thongTinNhanVienTongHopList = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
            NhanVien_BindingSource.DataSource = _thongTinNhanVienTongHopList;

            PhanBoThuLao_BindingSource.DataSource = PhanBoThuLaoList.GetPhanBoThuLaoList_BoPhan(maBoPhan, maPhanBoThuLao,maChiTietPhanBoThuLao, 1);
            KyTinhLuong_BindingSource.DataSource = KyTinhLuong.GetKyTinhLuong(_phanBoThuLaoNhanVien.MaKyTinhLuong);
            ChuongTrinh_BindingSource.DataSource = ChuongTrinh.GetChuongTrinh(_phanBoThuLaoNhanVien.MaChuongTrinh);
          
            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList();
            CTAn_BindingSource.DataSource = _chuongTrinhList;

            _boPhanList = BoPhanList.GetBoPhanListBy_All();
            BoPhan _boPhan = BoPhan.NewBoPhan(0, "---Tất Cả---");
            _boPhanList.Insert(0, _boPhan);
            BoPhan_BindingSource.DataSource = _boPhanList;

            cmbu_PhanBoThuLao.Value = _phanBoThuLao.MaBoPhanDi;
            cmbu_KyTinhLuong.Value = _phanBoThuLaoNhanVien.MaKyTinhLuong;
            cmbu_ChuongTrinh.Value = _phanBoThuLaoNhanVien.MaChuongTrinh;
            cmbu_NgayLap.Value = _phanBoThuLaoNhanVien.NgayLap;

            cbSoTien.Value = _phanBoThuLao.SoTien;
            cbSoTienConLai.Value = LaySoTienConLai(Convert.ToInt32(_phanBoThuLao.MaPhanBoThuLao),maChiTietPhanBoThuLao, maBoPhan, Convert.ToDecimal(_phanBoThuLao.SoTien));
            _suaDuLieu = 1;

            _soTienChoPhepCapNhat = TongSoTienToiDaChoPhepCapNhat();

            //Nếu giấy phân bổ thù lao đã hoàn tất thì không cho cập nhật dữ liệu
            if (KiemTraGiayPhanBoDaHoanTatChua(maChiTietPhanBoThuLao))
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
            _phanBoThuLaoNhanVienList = PhanBoThuLaoNhanVienList.NewPhanBoThuLaoNhanVienList();
            PhanBoThuLaoNhanVien_BindingSource.DataSource = _phanBoThuLaoNhanVienList;

            _phanBoThuLaoList = PhanBoThuLaoList.GetPhanBoThuLaoList_BoPhan(maBoPhan, 1);
            PhanBoThuLao _thulao = PhanBoThuLao.NewPhanBoThuLaoKhoiTao("Không Có Chi Tiết");
            _phanBoThuLaoList.Insert(0, _thulao);
            PhanBoThuLao_BindingSource.DataSource = _phanBoThuLaoList;

            _thongTinNhanVienTongHopList = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
            NhanVien_BindingSource.DataSource = _thongTinNhanVienTongHopList;

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

        private decimal TongSoTienToiDaChoPhepCapNhat()
        {
            decimal soTienDaPhanBo = 0;
            decimal soTienChoPhepCapNhat = 0;
            foreach (PhanBoThuLaoNhanVien item in _phanBoThuLaoNhanVienList)
            {
                soTienDaPhanBo += item.SoTien;
            }
            soTienChoPhepCapNhat += soTienDaPhanBo + Convert.ToDecimal(cbSoTienConLai.Value);

            return soTienChoPhepCapNhat;
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
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenNganHang"].Hidden = false;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Hidden = false;

            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Chọn";
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["Check"].Width = 40;


            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "CMND";
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenNganHang"].Header.Caption = "Tên Ngân Hàng";
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.Caption = "Số Tài Khoản";


            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 2;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 3;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenNganHang"].Header.VisiblePosition = 4;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.VisiblePosition = 5;

            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 100;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["CMND"].Width = 100;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["TenNganHang"].Width = 150;
            grdu_DanhSachNhanVien.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Width = 100;
        }


        private void grdu_PhanBoThuLaoChuongTrinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ///tao su kien cho luoi
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            //e.Layout.Override.CellClickAction = CellClickAction.CellSelect;

            foreach (UltraGridColumn col in this.grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["Check"].CellActivation = Activation.AllowEdit;


            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTien"].CellClickAction = CellClickAction.CellSelect;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["DienGiai"].CellClickAction = CellClickAction.CellSelect;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].CellClickAction = CellClickAction.CellSelect;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].CellClickAction = CellClickAction.CellSelect;
           // grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["Check"].CellClickAction = CellClickAction.CellSelect;

            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["ThucNhan"].Hidden = false;


            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 4;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["ThucNhan"].Header.VisiblePosition = 4;

            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Bộ Phận";
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Chọn";
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["ThucNhan"].Header.Caption = "Ngoài Định Mức";

            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTien"].Width = 100;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 150;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 150;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["Check"].Width = 60;
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["ThucNhan"].Width = 125;

            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTien"].Format = "#,###";
            grdu_PhanBoThuLaoNhanVien.DisplayLayout.Bands[0].Columns["SoTien"].PromptChar = ' ';
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
           //  FilterCombo f = new FilterCombo(cmbu_PhanBoThuLao, "MaPhanBoQL");
            foreach (UltraGridColumn col in this.cmbu_BoPhan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;

            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";

            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 0;
            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 1;

            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cmbu_BoPhan.Width;
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
            
            if (cmbu_BoPhan.ActiveRow != null)
            {
                maBoPhan = (int)cmbu_BoPhan.ActiveRow.Cells["MaBoPhan"].Value;
            }
            _thongTinNhanVienTongHopList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong(maBoPhan, false);
            NhanVien_BindingSource.DataSource = _thongTinNhanVienTongHopList;
            ////_nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByThuLaoChuongTrinh(maBoPhan, checkBox_NghiHuu.Checked);
            //_nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong(maBoPhan, checkBox_NghiHuu.Checked);
            //this.bindingSource1_NhanVien.DataSource = _nhanVienList;
            //if (maBoPhan == 0)
            //{
            //    _thongTinNhanVienTongHopList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong(maBoPhan, checkBox_NghiHuu.Checked);
            //    NhanVien_BindingSource.DataSource = _thongTinNhanVienTongHopList;
            //}
            //else
            //{
            //    //_nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong(maBoPhan, checkBox_NghiHuu.Checked);
            //    _thongTinNhanVienTongHopList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByBoPhan_DangLamViec(maBoPhan);
            //    NhanVien_BindingSource.DataSource = _thongTinNhanVienTongHopList;
            //}
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
                            //if ((int)grdu_DanhSachNhanVien.Rows[i].Cells["MaNganHang"].Value != 0 && grdu_DanhSachNhanVien.Rows[i].Cells["SoTaiKhoan"].Value.ToString().Replace(" ", "") != "")
                            //{
                                _phanBoThuLaoNhanVien = PhanBoThuLaoNhanVien.NewPhanBoThuLaoNhanVien();
                                ////cai dat gia tri cho phan bo thu lao chuong trinh
                                _phanBoThuLaoNhanVien.MaChuongTrinh = _phanBoThuLao.MaChuongTrinh;
                                _phanBoThuLaoNhanVien.TenChuongTrinh = ChuongTrinh.GetChuongTrinh(_phanBoThuLao.MaChuongTrinh).TenChuongTrinh;
                                _phanBoThuLaoNhanVien.MaKyTinhLuong = _phanBoThuLao.MaKyTinhLuong;
                                _phanBoThuLaoNhanVien.NgayLap = Convert.ToDateTime(cmbu_NgayLap.Value);
                                _phanBoThuLaoNhanVien.NguoiLap = Convert.ToInt32(ERP_Library.Security.CurrentUser.Info.UserID);
                                _phanBoThuLaoNhanVien.MaPhanBoThuLao = _phanBoThuLao.MaPhanBoThuLao;

                                ///chi lay bo phan luc dang nhap he thong
                                _phanBoThuLaoNhanVien.MaChiTietPhanBoThuLao = ChiTietPhanBoThuLao.GetChiTietPhanBoThuLaoByMaBoPhan_MaPhanBo(_maChiTietPhanBoThuLao, maBoPhan).MaChiTietPhanBoThuLao;
                                _phanBoThuLaoNhanVien.MaCongViec = ChiTietPhanBoThuLao.GetChiTietPhanBoThuLaoByMaBoPhan_MaPhanBo(_maChiTietPhanBoThuLao, maBoPhan).MaCongViec;
                                //
                                _phanBoThuLaoNhanVien.KhongTinhThuNhap = true;
                                _phanBoThuLaoNhanVien.DuocNhapHo = true;
                                _phanBoThuLaoNhanVien.ThucNhan = true;
                                _phanBoThuLaoNhanVien.ThanhToan = true;
                                _phanBoThuLaoNhanVien.TinhDangPhi = true;
                                _phanBoThuLaoNhanVien.MaChiTietGiayXacNhan = _phanBoThuLao.MaChiTietGiayXacNhan;
                                _phanBoThuLaoNhanVien.MaGiayXacNhan = _phanBoThuLao.MaGiayXacNhanChuongTrinh;
                                _phanBoThuLaoNhanVien.DienGiai = PhanBoThuLao.GetPhanBoThuLao(_phanBoThuLao.MaPhanBoThuLao).GhiChu; 

                                _phanBoThuLaoNhanVien.MaNhanVien = (long)grdu_DanhSachNhanVien.Rows[i].Cells["MaNhanVien"].Value;
                                _phanBoThuLaoNhanVien.TenNhanVien = Convert.ToString(grdu_DanhSachNhanVien.Rows[i].Cells["TenNhanVien"].Value);
                                _phanBoThuLaoNhanVien.MaQLNhanVien = Convert.ToString(grdu_DanhSachNhanVien.Rows[i].Cells["MaQLNhanVien"].Value);
                                _phanBoThuLaoNhanVien.MaBoPhan = (int)grdu_DanhSachNhanVien.Rows[i].Cells["MaBoPhan"].Value;
                                _phanBoThuLaoNhanVien.TenBoPhan = Convert.ToString(grdu_DanhSachNhanVien.Rows[i].Cells["TenBoPhan"].Value);
                                _phanBoThuLaoNhanVien.MaQLBoPhan = Convert.ToString(grdu_DanhSachNhanVien.Rows[i].Cells["MaQLBoPhan"].Value);
                                _phanBoThuLaoNhanVien.MaChucVu = (int)grdu_DanhSachNhanVien.Rows[i].Cells["MaChucVu"].Value;
                                _phanBoThuLaoNhanVien.TenChucVu = Convert.ToString(grdu_DanhSachNhanVien.Rows[i].Cells["TenChucVu"].Value);

                                _phanBoThuLaoNhanVienList.Add(_phanBoThuLaoNhanVien);
                            //}
                        }
                    }

                    PhanBoThuLaoNhanVien_BindingSource.DataSource = _phanBoThuLaoNhanVienList;
                    ///reload lai danh sach nhan vien
                    for (int j = 0; j < grdu_DanhSachNhanVien.Rows.Count; j++)
                    {
                        if ((bool)grdu_DanhSachNhanVien.Rows[j].Cells["Check"].Value == true)
                        {
                            grdu_DanhSachNhanVien.Rows[j].Cells["Check"].Value = false;
                            grdu_DanhSachNhanVien.Rows[j].Hidden = true;
                        }
                    }


                    this.NhanVien_BindingSource.DataSource = _thongTinNhanVienTongHopList;

                    Check_TatCa.Checked = false;
                    Check_NgoaiDinhMuc.CheckedValue = true;
                }
            }
            else
            {
                return;
            }

            //_suaDuLieu = 0;
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
                    cm.Parameters.AddWithValue("@Bien", 1);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@SoTien", SqlDbType.VarChar, 30);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);

                    cm.ExecuteNonQuery();
                    soTienConLai = Convert.ToDecimal(cm.Parameters["@SoTien"].Value);
                }
            }//using
            return soTienConLai;
        }

        public decimal TinhSoTienPhanBoThuLao_New(int maChiTietPhanBoThuLao)
        {
            decimal soTienConLai = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LaySoTienTrongPhanBoThuLao";
                    cm.Parameters.AddWithValue("@MaChiTietPhanBoThuLao", maChiTietPhanBoThuLao);
                    cm.Parameters.AddWithValue("@Bien", 1);
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
                    cm.Parameters.AddWithValue("@Bien", 1);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@SoDong", SqlDbType.VarChar, 30);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);

                    cm.ExecuteNonQuery();
                    soDong = Convert.ToInt32(cm.Parameters["@SoDong"].Value);
                }
            }//using
            return soDong;
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            decimal _SoTien = 0;
            grdu_PhanBoThuLaoNhanVien.UpdateData();

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

            ////xoa du lieu
            grdu_PhanBoThuLaoNhanVien.DeleteSelectedRows();

            //cap nhat lai so tien con lai tren from
            //_soTienPhanBo = TinhSoTienPhanBoThuLao(Convert.ToInt32(cmbu_PhanBoThuLao.Value));
            //_SoTien = _soTienPhanBo + LaySoTienConLai(Convert.ToInt32(cmbu_PhanBoThuLao.Value), maBoPhan, Convert.ToDecimal(cbSoTien.Value));
            //cbSoTienConLai.Value = _SoTien;

            Check_TatCaThuLao.Checked = false;

            /////load lai danh sach nhan vien
            if (cmbu_BoPhan.Value != null)
            {
                DanhSachNhanVien();
            }
        }

        private void tlsblExport_Click(object sender, EventArgs e)
        {

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
                    cm.Parameters.AddWithValue("@Bien", 1);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTri", SqlDbType.VarChar, 30);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);

                    cm.ExecuteNonQuery();
                    gt = Convert.ToInt32(cm.Parameters["@GiaTri"].Value);
                }
            }//using
            return gt;
        }
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            decimal tongSoTienPhanBo = 0;
            decimal soTienChiTietPhanBo = 0;
            int bien = 0;
            grdu_PhanBoThuLaoNhanVien.UpdateData();

            if (_giayPhanBoDaHoanTat == true)
            {
                MessageBox.Show("Giấy phân bổ đã hoàn tất. Không thể cập nhật.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (KiemTra() == true)
            {
                //KyTinhLuong _kyTinhLuong = KyTinhLuong.GetKyTinhLuong((int)cmbu_KyTinhLuong.Value);
                //if (_kyTinhLuong.KhoaSoKy2 == true)
                //{
                //    MessageBox.Show("Kỳ này đã khóa sổ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                if (grdu_PhanBoThuLaoNhanVien.Rows.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm dữ liệu vào danh sách nhân viên nhận thù lao.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //// kiem tra (tong so tien) trong phan bo thu lao nhan vien ngoai = so tien trong chi tiet phan bo thu lao
                foreach (PhanBoThuLaoNhanVien item in _phanBoThuLaoNhanVienList)
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

                if (tongSoTienPhanBo > soTienChiTietPhanBo)
                {
                    MessageBox.Show("Tổng tiền trong Danh Sách Phân Bổ bé hơn hoặc bằng với Số Tiền trong Chi Tiết Phân Bổ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    if (tongSoTienPhanBo > _soTienChoPhepCapNhat || (Convert.ToDecimal(cbSoTienConLai.Value) < tongSoTienPhanBo - TinhSoTienPhanBoThuLao((int)_phanBoThuLao.MaPhanBoThuLao)))
                    {
                        MessageBox.Show("Tổng tiền trong Danh Sách Phân Bổ bé hơn hoặc bằng với Số Tiền Còn Lại trong Chi Tiết Phân Bổ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                ///cap nhat lai du lieu roi moi luu
                foreach (PhanBoThuLaoNhanVien item in _phanBoThuLaoNhanVienList)
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
                    item.KhongTinhThuNhap = true;
                    item.DuocNhapHo = true;
                    item.ThanhToan = true;
                    item.TinhDangPhi = true;
                    item.MaChiTietGiayXacNhan = _phanBoThuLao.MaChiTietGiayXacNhan;
                    item.MaGiayXacNhan = _phanBoThuLao.MaGiayXacNhanChuongTrinh;

                    for (int i = 0; i < grdu_PhanBoThuLaoNhanVien.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(grdu_PhanBoThuLaoNhanVien.Rows[i].Cells["MaNhanVien"].Value) == item.MaNhanVien && Convert.ToBoolean(grdu_PhanBoThuLaoNhanVien.Rows[i].Cells["ThucNhan"].Value) == item.ThucNhan)
                        {
                            item.ThucNhan = Convert.ToBoolean(grdu_PhanBoThuLaoNhanVien.Rows[i].Cells["ThucNhan"].Value);
                        }
                    }
                }
                //// luu du lieu xuong
                _phanBoThuLaoNhanVien.ApplyEdit();
                _phanBoThuLaoNhanVienList.ApplyEdit();
                _phanBoThuLaoNhanVienList.Save();

                MessageBox.Show("Cập nhật thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cbSoTienConLai.Value = LaySoTienConLai((int)_phanBoThuLao.MaPhanBoThuLao, _maChiTietPhanBoThuLao, maBoPhan, Convert.ToDecimal(cbSoTien.Value));

                {
                    //Refesh lại dữ liệu
                    cmbu_ChuongTrinh.Value = null;
                    cmbu_KyTinhLuong.Value = null;
                    cbSoTien.Value = 0;
                    cbSoTienConLai.Value = 0;
                    cmbu_PhanBoThuLao.Value = 0;
                    _suaDuLieu = 0;

                    _phanBoThuLaoNhanVienList = PhanBoThuLaoNhanVienList.NewPhanBoThuLaoNhanVienList();
                    PhanBoThuLaoNhanVien_BindingSource.DataSource = _phanBoThuLaoNhanVienList;

                    _phanBoThuLaoList = PhanBoThuLaoList.GetPhanBoThuLaoList_BoPhan(maBoPhan, 1);
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
                txt_DienGiai.Text = ChiTietPhanBoThuLao.GetChiTietPhanBoThuLao(_maChiTietPhanBoThuLao).GhiChu;
               // txt_DienGiai.Text = _phanBoThuLao.GhiChu;
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
                    cm.Parameters.AddWithValue("@MaChiTietPhanBoThuLao", maChiTiet);
                    cm.Parameters.AddWithValue("@SoTien", soTien);
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

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            cmbu_ChuongTrinh.Value = null;
            cmbu_KyTinhLuong.Value = null;
            cbSoTien.Value = 0;
            cbSoTienConLai.Value = 0;
            _suaDuLieu = 0;

            _phanBoThuLaoNhanVienList = PhanBoThuLaoNhanVienList.NewPhanBoThuLaoNhanVienList();
            PhanBoThuLaoNhanVien_BindingSource.DataSource = _phanBoThuLaoNhanVienList;

            _phanBoThuLaoList = PhanBoThuLaoList.GetPhanBoThuLaoList_BoPhan(maBoPhan, 1);
            PhanBoThuLao _thulao = PhanBoThuLao.NewPhanBoThuLaoKhoiTao("Không Có Chi Tiết");
            _phanBoThuLaoList.Insert(0, _thulao);
            PhanBoThuLao_BindingSource.DataSource = _phanBoThuLaoList;

            cmbu_NgayLap.Value = DateTime.Now.Date;
            cmbu_PhanBoThuLao.Value = 0;
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
                if (grdu_PhanBoThuLaoNhanVien.ActiveCell != null && !grdu_PhanBoThuLaoNhanVien.ActiveCell.IsInEditMode)
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

        private void Check_NgoaiDinhMuc_CheckedValueChanged(object sender, EventArgs e)
        {
            if (Check_NgoaiDinhMuc.Checked == true)
            {
                for (int i = 0; i < grdu_PhanBoThuLaoNhanVien.Rows.Count; i++)
                {
                    if (!grdu_PhanBoThuLaoNhanVien.Rows[i].Hidden == true)
                    {
                        grdu_PhanBoThuLaoNhanVien.Rows[i].Cells["ThucNhan"].Value = (object)true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < grdu_PhanBoThuLaoNhanVien.Rows.Count; i++)
                {
                    grdu_PhanBoThuLaoNhanVien.Rows[i].Cells["ThucNhan"].Value = (object)false;
                }
            }
        }

        private bool KiemTraGiayPhanBoDaHoanTatChua(long maChiTietPhanBo)
        {
            Boolean gt = false;
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
                    gt = Convert.ToBoolean(cm.Parameters["@GiaTri"].Value);
                }
            }//using
            return gt;
        }

        private void tlslblInDanhSachTongHop_Click(object sender, EventArgs e)
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

            Report = new Report.DanhSachPhanBoThuLaoChiTiet__TrongDai_DSNVTH();
            command = new SqlCommand();
            dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_DanhSachPhanBoThuLaoChuongTrinh_DSTHNV";
            command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(cmbu_NgayLap.Value));
            command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(cmbu_NgayLap.Value));
            command.Parameters.AddWithValue("@MaNhanVien", 0);
            command.Parameters.AddWithValue("@MaChuongTrinh", 0);
            command.Parameters.AddWithValue("@MaBoPhan", 0);
            command.Parameters.AddWithValue("@MaPhanBoThuLao", _maChiTietPhanBoThuLao);
            command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
            command.Parameters.AddWithValue("@Loai", 1);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            command.CommandTimeout = 90;
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_DanhSachPhanBoThuLaoChuongTrinh_DSTHNV;1";
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

        private void tlslblInDanhSachChiTiet_Click(object sender, EventArgs e)
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

            Report = new Report.DanhSachPhanBoThuLaoChiTiet_TrongDai();
            command = new SqlCommand();
            dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_DanhSachPhanBoThuLaoChuongTrinh_CTNV";
            command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(cmbu_NgayLap.Value));
            command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(cmbu_NgayLap.Value));
            command.Parameters.AddWithValue("@MaNhanVien", 0);
            command.Parameters.AddWithValue("@MaChuongTrinh", 0);
            command.Parameters.AddWithValue("@MaBoPhan", 0);
            command.Parameters.AddWithValue("@MaPhanBoThuLao", _maChiTietPhanBoThuLao);
            command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
            command.Parameters.AddWithValue("@Loai", 1);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            command.CommandTimeout = 0;
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_DanhSachPhanBoThuLaoChuongTrinh_CTNV;1";
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
