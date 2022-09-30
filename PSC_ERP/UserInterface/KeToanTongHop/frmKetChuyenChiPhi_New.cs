using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
using ERP_Library.Security;

namespace PSC_ERP
{
    public partial class frmKetChuyenChiPhi_New : Form
    {
        #region
        BoPhanList _boPhanList;
        ChuongTrinhList _chuongTrinhList;
        TieuMucNganSachList _tieuMucNganSachList;
        MucNganSachList _mucNganSachList;
        HeThongTaiKhoan1List _heThongTaiKhoan1ListNo;
        ChungTuList _chungTuList;
        ChungTu _chungTu = ChungTu.NewChungTu();
        XuatDuLieuList _danhSachChungTuTimDuocList = XuatDuLieuList.NewXuatDuLieuList();
        XuatDuLieuList _danhSachChungTuKetChuyenList = XuatDuLieuList.NewXuatDuLieuList();
        HamDungChung hamDungChung = new HamDungChung();
        ERP_Library.Security.UserList _UserList;
        int userID = CurrentUser.Info.UserID;
        int loaitien = 1;
        string SoCTMoiPS = "";
        string _duLieu = "";
        bool _khoiTaoChungTuTimDuoc = false;
        bool _khoiTaoChungTuKetChuyen = false;
        #endregion

        public frmKetChuyenChiPhi_New()
        {
            InitializeComponent();
            LoadForm();

            grdu_DanhSachChungTu.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_DanhSachChungTu.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_DanhSachChungTu.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));

            grdu_DanhSachChungTu.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_DanhSachChungTu.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_DanhSachChungTu.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);

            grdu_DanhSachChungTuKetChuyen.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_DanhSachChungTuKetChuyen.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_DanhSachChungTuKetChuyen.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));

            grdu_DanhSachChungTuKetChuyen.KeyDown += new KeyEventHandler(grdData_KeyDown1);
            grdu_DanhSachChungTuKetChuyen.KeyPress += new KeyPressEventHandler(grdData_KeyPress1);
            grdu_DanhSachChungTuKetChuyen.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation1);
        }
        private void LoadForm()
        {
            _heThongTaiKhoan1ListNo = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
            NoTaiKhoan_BindingSource.DataSource = _heThongTaiKhoan1ListNo;

            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList();
            ChuongTrinh itemChuongTrinh = ChuongTrinh.NewChuongTrinh("Tất Cả");
            _chuongTrinhList.Insert(0, itemChuongTrinh);
            ChuongTrinh_BindingSource.DataSource = _chuongTrinhList;

            _boPhanList = BoPhanList.GetBoPhanListByUserID(userID);
            //BoPhan _boPhan = BoPhan.NewBoPhan("Tất Cả");
            // _boPhanList.Insert(0,_boPhan);
            BoPhan_BindingSource.DataSource = _boPhanList;

            _tieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList();
            TieuMucNganSach tieuMucNganSach = TieuMucNganSach.NewTieuMucNganSach("0", "Tất Cả");
            _tieuMucNganSachList.Insert(0, tieuMucNganSach);
            TieuMucNganSach_BindingSource.DataSource = _tieuMucNganSachList;

            _mucNganSachList = MucNganSachList.GetMucNganSachList();
            MucNganSach mucNganSach = MucNganSach.NewMucNganSach("Tất Cả");
            _mucNganSachList.Insert(0, mucNganSach);
            MucNganSach_BindingSource.DataSource = _mucNganSachList;

            grdu_DanhSachChungTu.DataSource = XuatDuLieuList.NewXuatDuLieuList();
            grdu_DanhSachChungTuKetChuyen.DataSource = XuatDuLieuList.NewXuatDuLieuList();

            _UserList = UserList.GetUserList(CurrentUser.Info.MaBoPhan);
            UserItem user = UserItem.NewUserItem("Tất Cả");
            _UserList.Insert(0, user);
            NguoiLap_BindingSource.DataSource = _UserList;

            dtu_DenNgay.Value = DateTime.Now.Date;
            dtu_TuNgay.Value = DateTime.Now.Date;
            dtu_NgayLap.Value = DateTime.Now.Date;
        }
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cbu_BoPhan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbu_BoPhan, "TenBoPhan");
            foreach (UltraGridColumn col in this.cbu_BoPhan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cbu_BoPhan.Width;
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;

        }

        private void cbu_ChuongTrinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbu_ChuongTrinh, "TenChuongTrinh");
            foreach (UltraGridColumn col in this.cbu_ChuongTrinh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            cbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Hidden = false;
            cbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Hidden = false;

            cbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = cbu_ChuongTrinh.Width;

            cbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            cbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.Caption = "Tên Nguồn";
            cbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Header.Caption = "Mã QL";

            cbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 0;
            cbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Header.VisiblePosition = 1;
            cbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.VisiblePosition = 2;

        }

        private void cbu_NoTaiKhoan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbu_NoTaiKhoan, "SoHieuTK");
            foreach (UltraGridColumn col in this.cbu_NoTaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbu_NoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            cbu_NoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            cbu_NoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            cbu_NoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Width = 70;
            cbu_NoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            cbu_NoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            cbu_NoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 200;
            cbu_NoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;
        }

        private void cbu_TieuMuc_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbu_TieuMuc, "MaMucNganSachQL");
            foreach (UltraGridColumn col in this.cbu_TieuMuc.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbu_TieuMuc.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Hidden = false;
            cbu_TieuMuc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cbu_TieuMuc.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Width = cbu_TieuMuc.Width;

            cbu_TieuMuc.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Header.Caption = "Tên Tiểu Mục";
            cbu_TieuMuc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            cbu_TieuMuc.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Header.VisiblePosition = 0;
            cbu_TieuMuc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
        }

        private void cbu_Muc_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbu_Muc, "MaMucNganSachQL");
            foreach (UltraGridColumn col in this.cbu_Muc.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbu_Muc.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Hidden = false;
            cbu_Muc.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Hidden = false;

            cbu_Muc.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Width = cbu_Muc.Width;
            cbu_Muc.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Header.Caption = "Tên Mục Ngân Sách";
            cbu_Muc.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Header.Caption = "Mã Quản Lý";
            cbu_Muc.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Header.VisiblePosition = 0;
            cbu_Muc.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Header.VisiblePosition = 1;

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = Convert.ToDateTime(dtu_TuNgay.Value);
            DateTime denNgay = Convert.ToDateTime(dtu_DenNgay.Value);
            int maChuongTrinh = Convert.ToInt32(cbu_ChuongTrinh.Value);
            int maBoPhan = Convert.ToInt32(cbu_BoPhan.Value);
            int maTieuMucNganSach = Convert.ToInt32(cbu_TieuMuc.Value);
            int maMucNganSach = Convert.ToInt32(cbu_Muc.Value);
            int maTaiKhoanNo = Convert.ToInt32(cbu_NoTaiKhoan.Value);
            int userID = 0;
            if (maBoPhan == 0)
            {
                userID = CurrentUser.Info.UserID;
            }
            else
            {
                userID = Convert.ToInt32(cbu_NguoiLap.Value);
            }
            if (cbu_NoTaiKhoan.Value == null)
            {
                MessageBox.Show(this, "Chọn Nợ Tài Khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _danhSachChungTuTimDuocList = XuatDuLieuList.GetXuatDuLieuListByKetChuyenChiPhi_New(tuNgay, denNgay, maBoPhan, userID, maChuongTrinh, maTaiKhoanNo, maTieuMucNganSach, maMucNganSach);
            if (_danhSachChungTuTimDuocList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            grdu_DanhSachChungTu.DataSource = _danhSachChungTuTimDuocList;
        }

        private void grdu_DanhSachChungTuKetChuyen_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ///tao su kien cho luoi
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;
            e.Layout.Override.CellClickAction = CellClickAction.CellSelect;

            foreach (UltraGridColumn col in this.grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["Chon"].CellClickAction = CellClickAction.Edit;

            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["Chon"].Hidden = false;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TKCo"].Hidden = false;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenTieuMucNganSach"].Hidden = false;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Hidden = false;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"].Hidden = false;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTienChiPhiSanXuat"].Hidden = false;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Hidden = false;

            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["Chon"].Header.VisiblePosition = 0;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 1;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 2;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Header.VisiblePosition = 3;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TKCo"].Header.VisiblePosition = 4;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 5;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenTieuMucNganSach"].Header.VisiblePosition = 6;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Header.VisiblePosition = 7;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 8;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 9;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"].Header.VisiblePosition = 10;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTienChiPhiSanXuat"].Header.VisiblePosition = 11;


            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["Chon"].CellActivation = Activation.AllowEdit;

            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTienChiPhiSanXuat"].Header.Caption = "Tiền SX";
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"].Header.Caption = "Tiền NS";
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Chọn";
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenTieuMucNganSach"].Header.Caption = "Tiểu Mục";
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Header.Caption = "Mục";
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TKCo"].Header.Caption = "Có TK";
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Tiền BT";
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tài Khoản";
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Header.Caption = "Người Lập";

            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTienChiPhiSanXuat"].Width = 80;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"].Width = 80;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTien"].Width = 80;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 110;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = 180;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenTieuMucNganSach"].Width = 80;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Width = 60;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["Chon"].Width = 60;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TKCo"].Width = 70;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 85;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 90;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Width = 90;

            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTienChiPhiSanXuat"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTienChiPhiSanXuat"].Format = "#,###";
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTienChiPhiSanXuat"].PromptChar = ' ';

            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"].Format = "#,###";
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"].PromptChar = ' ';

            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTien"].Format = "#,###";
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTien"].PromptChar = ' ';

            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTienChiPhiSanXuat"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoChungTu"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["Chon"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["NgayLap"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenTieuMucNganSach"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenMucNganSach"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TKCo"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenNguoiLap"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

            if (_khoiTaoChungTuKetChuyen == false)
            {
                UltraGridColumn columnToSummarize = grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTien"];
                SummarySettings summary = grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Summaries.Add("SoTien", SummaryType.Sum, columnToSummarize);
                summary.DisplayFormat = " {0:###,###,###}";
                summary.Appearance.TextHAlign = HAlign.Right;

                UltraGridColumn columnToSummarize1 = grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTienChiPhiSanXuat"];
                SummarySettings summary1 = grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Summaries.Add("SoTienChiPhiSanXuat", SummaryType.Sum, columnToSummarize1);
                summary1.DisplayFormat = " {0:###,###,###}";
                summary1.Appearance.TextHAlign = HAlign.Right;

                UltraGridColumn columnToSummarize2 = grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"];
                SummarySettings summary2 = grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Summaries.Add("SoTienMucNganSach", SummaryType.Sum, columnToSummarize2);
                summary2.DisplayFormat = " {0:###,###,###}";
                summary2.Appearance.TextHAlign = HAlign.Right;
                _khoiTaoChungTuKetChuyen = true;
            }
            grdu_DanhSachChungTu.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
        }

        private void Check_TatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (_duLieu.Trim().CompareTo("") != 0 && _duLieu.Trim().CompareTo("(NonBlanks)") != 0)
            {
                if (Check_TatCa.Checked == true)
                {
                    foreach (XuatDuLieu item in _danhSachChungTuTimDuocList)
                    {
                        if (item.Chon == false && (item.TKCo.Trim() == _duLieu.Trim() || item.TenNguoiLap.Trim() == _duLieu.Trim() || item.TenMucNganSach.Trim() == _duLieu.Trim() || item.TenTieuMucNganSach.Trim() == _duLieu.Trim() || item.SoChungTu.Trim() == _duLieu.Trim() || item.TenChuongTrinh.Trim() == _duLieu.Trim() || item.TenTaiKhoan.Trim() == _duLieu.Trim() || item.NgayLap.ToString() == _duLieu.Trim()))
                        {
                            item.Chon = true;
                        }
                    }
                }
                else
                {
                    foreach (XuatDuLieu item in _danhSachChungTuTimDuocList)
                    {
                        if (item.Chon == true)
                        {
                            item.Chon = false;
                        }
                    }
                }
                _duLieu = "";
            }
            else
            {
                if (Check_TatCa.Checked == true)
                {
                    foreach (XuatDuLieu item in _danhSachChungTuTimDuocList)
                    {
                        if (item.Chon == false)
                        {
                            item.Chon = true;
                        }
                    }
                }
                else
                {
                    foreach (XuatDuLieu item in _danhSachChungTuTimDuocList)
                    {
                        if (item.Chon == true)
                        {
                            item.Chon = false;
                        }
                    }
                }
            }

            grdu_DanhSachChungTu.DataSource = _danhSachChungTuTimDuocList;
            grdu_DanhSachChungTu.Refresh();
        }

        private void Check_TatCaKetChuyen_CheckedChanged(object sender, EventArgs e)
        {
            if (_duLieu.Trim().CompareTo("") != 0 && _duLieu.Trim().CompareTo("(NonBlanks)") != 0)
            {
                if (Check_TatCaKetChuyen.Checked == true)
                {
                    foreach (XuatDuLieu item in _danhSachChungTuKetChuyenList)
                    {
                        if (item.Chon == false && (item.TKCo.Trim() == _duLieu.Trim() || item.TenNguoiLap.Trim() == _duLieu.Trim() || item.TenMucNganSach.Trim() == _duLieu.Trim() || item.TenTieuMucNganSach.Trim() == _duLieu.Trim() || item.SoChungTu.Trim() == _duLieu.Trim() || item.TenChuongTrinh.Trim() == _duLieu.Trim() || item.TenTaiKhoan.Trim() == _duLieu.Trim() || item.NgayLap.ToString() == _duLieu.Trim()))
                        {
                            item.Chon = true;
                        }
                    }
                }
                else
                {
                    foreach (XuatDuLieu item in _danhSachChungTuKetChuyenList)
                    {
                        if (item.Chon == true)
                        {
                            item.Chon = false;
                        }
                    }
                }

                _duLieu = "";
            }
            else
            {
                if (Check_TatCaKetChuyen.Checked == true)
                {
                    foreach (XuatDuLieu item in _danhSachChungTuKetChuyenList)
                    {
                        if (item.Chon == false)
                        {
                            item.Chon = true;
                        }
                    }
                }
                else
                {
                    foreach (XuatDuLieu item in _danhSachChungTuKetChuyenList)
                    {
                        if (item.Chon == true)
                        {
                            item.Chon = false;
                        }
                    }
                }
            }
            grdu_DanhSachChungTuKetChuyen.DataSource = _danhSachChungTuKetChuyenList;
            grdu_DanhSachChungTuKetChuyen.Refresh();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            dtu_NgayLap.Focus();
            Boolean isDelete = false;
            XuatDuLieuList danhSachChungTuCanXoaList = XuatDuLieuList.NewXuatDuLieuList();

            DialogResult _DialogResult = MessageBox.Show("Bạn có thật sự muốn xóa dòng đã chọn không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (_DialogResult == DialogResult.Yes)
            {
                //Lấy dữ liệu đã chọn trên lưới đưa vào danh sách tạm
                foreach (XuatDuLieu item in _danhSachChungTuKetChuyenList)
                {
                    if (item.Chon == true)
                    {
                        isDelete = true;
                        danhSachChungTuCanXoaList.Add(item);
                    }
                }

                if (!isDelete)//Nếu không có dòng nào được chọn thì thông báo người dùng biết
                {
                    MessageBox.Show("Vui lòng chọn dữ liệu cần xóa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Tiến hành xóa dữ liệu dựa vào danh sách tạm
                foreach (XuatDuLieu itemChungTuCanXoa in danhSachChungTuCanXoaList)
                {
                    XuatDuLieu chungTuCanXoa = null;
                    foreach (XuatDuLieu itemChungTuKetChuyen in _danhSachChungTuKetChuyenList)
                    {
                        if (itemChungTuCanXoa == itemChungTuKetChuyen)
                        {
                            chungTuCanXoa = itemChungTuKetChuyen;
                        }
                    }
                    if (chungTuCanXoa != null)
                    {
                        _danhSachChungTuKetChuyenList.Remove(chungTuCanXoa);
                    }
                }
                //Gán dữ liệu vào bindingSource
                ChungTuKetChuyen_BindingSource.DataSource = _danhSachChungTuKetChuyenList;
                //Tính lại số tiền kết chuyển chi phí
                TinhSoTienKetChuyen();
                //Setup lại dữ liệu
                Check_TatCaKetChuyen.Checked = false;
                lbSoTien.Text = "";
                lbSoTienChiPhi.Text = "";
                lbSoTienNganSach.Text = "";
            }
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
                    if (iscopyok && grdu_DanhSachChungTu.Selected != null && grdu_DanhSachChungTu.Selected.Cells != null)
                    {
                        e.Cancel = true;
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridCell item in grdu_DanhSachChungTu.Selected.Cells)
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
                    if (iscopyok && grdu_DanhSachChungTuKetChuyen.Selected != null && grdu_DanhSachChungTuKetChuyen.Selected.Cells != null)
                    {
                        e.Cancel = true;
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridCell item in grdu_DanhSachChungTuKetChuyen.Selected.Cells)
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

        private bool iscopyok1 = false;
        private object copyvalue1;
        private void grdData_BeforeMultiCellOperation1(object sender, Infragistics.Win.UltraWinGrid.BeforeMultiCellOperationEventArgs e)
        {
            if (e.Operation == Infragistics.Win.UltraWinGrid.MultiCellOperation.Copy)
            {
                if (e.Cells.RowCount == 1 && e.Cells.ColumnCount == 1)
                {
                    iscopyok1 = true;
                    copyvalue1 = e.Cells[0, 0].Value;
                }
            }
            else
                if (e.Operation == Infragistics.Win.UltraWinGrid.MultiCellOperation.Paste)
                {
                    if (iscopyok1 && grdu_DanhSachChungTuKetChuyen.Selected != null && grdu_DanhSachChungTuKetChuyen.Selected.Cells != null)
                    {
                        e.Cancel = true;
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridCell item in grdu_DanhSachChungTuKetChuyen.Selected.Cells)
                        {
                            try
                            {
                                item.Value = copyvalue1;
                                item.Row.Update();
                            }
                            catch { }
                        }
                    }
                    iscopyok1 = false;
                }
        }

        private void grdData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdu_DanhSachChungTu.ActiveRow.IsFilterRow != true)
            {
                if (iskeyok && grdu_DanhSachChungTu.ActiveCell.Row.IsDataRow)
                {
                    if (grdu_DanhSachChungTu.ActiveCell.Column.DataType == typeof(decimal))
                        try
                        {
                            grdu_DanhSachChungTu.ActiveCell.Value = Convert.ToDecimal(e.KeyChar.ToString());
                        }
                        catch
                        { }
                    else
                        grdu_DanhSachChungTu.ActiveCell.Value = e.KeyChar.ToString();
                    grdu_DanhSachChungTu.ActiveCell.SelStart = grdu_DanhSachChungTu.ActiveCell.Text.Length;
                    e.Handled = true;
                    iskeyok = false;
                }
            }
        }

        private void grdData_KeyPress1(object sender, KeyPressEventArgs e)
        {

            if (grdu_DanhSachChungTuKetChuyen.ActiveRow.IsFilterRow != true)
            {
                if (iskeyok && grdu_DanhSachChungTuKetChuyen.ActiveCell.Row.IsDataRow)
                {
                    if (grdu_DanhSachChungTuKetChuyen.ActiveCell.Column.DataType == typeof(decimal))
                        try
                        {
                            grdu_DanhSachChungTuKetChuyen.ActiveCell.Value = Convert.ToDecimal(e.KeyChar.ToString());
                        }
                        catch
                        { }
                    else
                        grdu_DanhSachChungTuKetChuyen.ActiveCell.Value = e.KeyChar.ToString();
                    grdu_DanhSachChungTuKetChuyen.ActiveCell.SelStart = grdu_DanhSachChungTuKetChuyen.ActiveCell.Text.Length;
                    e.Handled = true;
                    iskeyok1 = false;
                }
            }
        }

        private bool iskeyok1 = false;//xử lý key cho cột string
        private void grdData_KeyDown1(object sender, KeyEventArgs e)
        {

            if (grdu_DanhSachChungTuKetChuyen.ActiveRow.IsFilterRow != true)
            {
                if (grdu_DanhSachChungTuKetChuyen.ActiveCell != null && !grdu_DanhSachChungTuKetChuyen.ActiveCell.IsInEditMode)
                {
                    if ((e.KeyData >= Keys.A && e.KeyData <= Keys.Z) || (e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9))
                    {
                        grdu_DanhSachChungTuKetChuyen.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        grdu_DanhSachChungTuKetChuyen.ActiveCell.SelectAll();
                        iskeyok1 = true;
                    }
                    if (e.KeyCode == Keys.Space && grdu_DanhSachChungTuKetChuyen.ActiveCell.Column.DataType == typeof(bool))
                    {
                        grdu_DanhSachChungTuKetChuyen.ActiveCell.Value = !Convert.ToBoolean(grdu_DanhSachChungTuKetChuyen.ActiveCell.Value);
                    }
                }
            }
        }
        private bool iskeyok = false;//xử lý key cho cột string
        private void grdData_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdu_DanhSachChungTu.ActiveRow.IsFilterRow != true)
            {
                if (grdu_DanhSachChungTu.ActiveCell != null && !grdu_DanhSachChungTu.ActiveCell.IsInEditMode)
                {
                    if ((e.KeyData >= Keys.A && e.KeyData <= Keys.Z) || (e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9))
                    {
                        grdu_DanhSachChungTu.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        grdu_DanhSachChungTu.ActiveCell.SelectAll();
                        iskeyok = true;
                    }
                    if (e.KeyCode == Keys.Space && grdu_DanhSachChungTu.ActiveCell.Column.DataType == typeof(bool))
                    {
                        grdu_DanhSachChungTu.ActiveCell.Value = !Convert.ToBoolean(grdu_DanhSachChungTu.ActiveCell.Value);
                    }
                }
            }
        }

        private void grdu_DanhSachChungTu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
 
            ///tao su kien cho luoi
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;
            e.Layout.Override.CellClickAction = CellClickAction.CellSelect;

            foreach (UltraGridColumn col in this.grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["Chon"].CellClickAction = CellClickAction.Edit;

            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["Chon"].Hidden = false;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TKCo"].Hidden = false;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenTieuMucNganSach"].Hidden = false;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Hidden = false;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"].Hidden = false;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTienChiPhiSanXuat"].Hidden = false;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Hidden = false;

            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["Chon"].Header.VisiblePosition = 0;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 1;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 2;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Header.VisiblePosition = 3;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TKCo"].Header.VisiblePosition = 4;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 5;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenTieuMucNganSach"].Header.VisiblePosition = 6;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Header.VisiblePosition = 7;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 8;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 9;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"].Header.VisiblePosition = 10;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTienChiPhiSanXuat"].Header.VisiblePosition = 11;


            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["Chon"].CellActivation = Activation.AllowEdit;

            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTienChiPhiSanXuat"].Header.Caption = "Tiền SX";
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"].Header.Caption = "Tiền NS";
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["Chon"].Header.Caption = "Chọn";
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenTieuMucNganSach"].Header.Caption = "Tiểu Mục";
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Header.Caption = "Mục";
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TKCo"].Header.Caption = "Có TK";
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Tiền BT";
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tài Khoản";
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Header.Caption = "Người Lập";

            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTienChiPhiSanXuat"].Width = 80;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"].Width = 80;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Width = 80;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 110;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = 180;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenTieuMucNganSach"].Width = 80;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Width = 60;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["Chon"].Width = 60;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TKCo"].Width = 70;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 85;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 90;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Width = 95;

            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTienChiPhiSanXuat"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTienChiPhiSanXuat"].Format = "#,###";
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTienChiPhiSanXuat"].PromptChar = ' ';

            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"].Format = "#,###";
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"].PromptChar = ' ';

            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Format = "#,###";
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTien"].PromptChar = ' ';

            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTienChiPhiSanXuat"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["Chon"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenTieuMucNganSach"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenMucNganSach"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TKCo"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenNguoiLap"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

            if (_khoiTaoChungTuTimDuoc == false)
            {
                UltraGridColumn columnToSummarize = grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTien"];
                SummarySettings summary = grdu_DanhSachChungTu.DisplayLayout.Bands[0].Summaries.Add("SoTien", SummaryType.Sum, columnToSummarize);
                summary.DisplayFormat = " {0:###,###,###}";
                summary.Appearance.TextHAlign = HAlign.Right;

                UltraGridColumn columnToSummarize1 = grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTienChiPhiSanXuat"];
                SummarySettings summary1 = grdu_DanhSachChungTu.DisplayLayout.Bands[0].Summaries.Add("SoTienChiPhiSanXuat", SummaryType.Sum, columnToSummarize1);
                summary1.DisplayFormat = " {0:###,###,###}";
                summary1.Appearance.TextHAlign = HAlign.Right;

                UltraGridColumn columnToSummarize2 = grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"];
                SummarySettings summary2 = grdu_DanhSachChungTu.DisplayLayout.Bands[0].Summaries.Add("SoTienMucNganSach", SummaryType.Sum, columnToSummarize2);
                summary2.DisplayFormat = " {0:###,###,###}";
                summary2.Appearance.TextHAlign = HAlign.Right;

                _khoiTaoChungTuTimDuoc = true;
            }
            grdu_DanhSachChungTu.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
        }
        private void Delete_KetChuyenChiPhiTam(long maChungTu, bool loai)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Delete_KetChuyenChiPhiTam";
                        cm.Parameters.Add("@MaChungTu", maChungTu);
                        cm.Parameters.Add("@Loai", loai);
                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void TinhSoTienKetChuyen()
        {

            foreach (XuatDuLieu item in _danhSachChungTuKetChuyenList)
            {
                Insert_KetChuyenChiPhiTam((int)item.MaChungTu, item.SoTien, item.SoTienChiPhiSanXuat, item.SoTienMucNganSach, item.MaChuongTrinh, item.MaTieuMucNganSach, item.MaMucNganSach, item.MaTaiKhoanCo, item.MaButToan, item.MaButToanChiPhiSanXuat, item.MaButToanMucNganSach, item.MaChiPhiThucHien, item.MaChiThuLao, item.MaButToanMucNganSachNew);
            }

            lbSoTien.Text = "Tiền bút toán : " + String.Format("{0:0,0}", LaySoTienChungTu());
            lbSoTienChiPhi.Text = "Tiền chi phí : " + String.Format("{0:0,0}", LaySoTienChiPhiSanXuat());
            lbSoTienNganSach.Text = "Tiền ngân sách : " + String.Format("{0:0,0}", LaySoTienNganSach_New());

            //Xóa bảng kết chuyển chứng từ tạm
            Delete_KetChuyenChiPhiTam(0, false);
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            dtu_NgayLap.Focus();
            grdu_DanhSachChungTu.UpdateData();


            DialogResult _DialogResult = MessageBox.Show("Bạn có đồng ý đưa chứng từ qua không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (_DialogResult == DialogResult.Yes)
            {
                //Ẩn đi các dòng đã chọn trong danh sách chứng từ tìm được
                for (int i = 0; i < grdu_DanhSachChungTu.Rows.Count; i++)
                {
                    if ((bool)grdu_DanhSachChungTu.Rows[i].Cells["Chon"].Value == true)
                    {
                        grdu_DanhSachChungTu.Rows[i].Hidden = true;
                    }
                }

                //Đưa dữ liệu vào danh sách chứng từ kết chuyển
                foreach (XuatDuLieu item in _danhSachChungTuTimDuocList)
                {
                    if (item.Chon == true)//Nếu đã chọn
                    {
                        item.Chon = false;
                        _danhSachChungTuKetChuyenList.Add(item);
                    }
                }

                //Gán vào bindingSource
                grdu_DanhSachChungTuKetChuyen.DataSource = _danhSachChungTuKetChuyenList;

                //Khởi tạo số chứng từ
                SetSoChungTuMoiPS(16);

                ///Xóa tất cả chứng từ đã thêm vào danh sách kết chuyển
                //DeleteAllChungTuDaCoTrongDanhSachKetChuyenChiPhi();

                //Set lại dữ liệu
                Check_TatCa.Checked = false;

                //Lấy số tiền kết chuyển
                TinhSoTienKetChuyen();

                //Set giá trị cho tài khoản kết chuyển
                foreach (XuatDuLieu item in _danhSachChungTuKetChuyenList)
                {
                    if (Convert.ToInt32(cbu_TaiKhoanKetChuyen.Value) == 0)
                    {
                        cbu_TaiKhoanKetChuyen.Value = item.MaTaiKhoan;
                    }
                    else if ( Convert.ToInt32(cbu_TaiKhoanKetChuyen.Value) != 0 && Convert.ToInt32(cbu_TaiKhoanKetChuyen.Value) != item.MaTaiKhoan && item.MaTaiKhoan!=0)
                    {
                       cbu_TaiKhoanKetChuyen.Value = null;
                    }                 
                }
            }

        }

        private void DeleteAllChungTuDaCoTrongDanhSachKetChuyenChiPhi()
        {
            foreach (XuatDuLieu itemChungTuKetChuyen in _danhSachChungTuKetChuyenList)
            {
                XuatDuLieu chungTuCanXoa = null;
                foreach (XuatDuLieu itemChungTuTimDuoc in _danhSachChungTuTimDuocList)
                {
                    if (itemChungTuTimDuoc.MaButToanMucNganSach == itemChungTuKetChuyen.MaButToanMucNganSach && itemChungTuKetChuyen.MaButToanChiPhiSanXuat == itemChungTuTimDuoc.MaButToanChiPhiSanXuat && itemChungTuTimDuoc.SoTien == itemChungTuKetChuyen.SoTien && itemChungTuTimDuoc.SoTienBT == itemChungTuKetChuyen.SoTienBT && itemChungTuKetChuyen.SoTienChiPhiSanXuat == itemChungTuTimDuoc.SoTienChiPhiSanXuat && itemChungTuTimDuoc.SoChungTu == itemChungTuKetChuyen.SoChungTu && itemChungTuTimDuoc.TKCo == itemChungTuKetChuyen.TKCo && itemChungTuTimDuoc.TenChuongTrinh == itemChungTuKetChuyen.TenChuongTrinh && itemChungTuTimDuoc.TenMucNganSach == itemChungTuKetChuyen.TenMucNganSach && itemChungTuTimDuoc.TenTieuMucNganSach == itemChungTuKetChuyen.TenTieuMucNganSach && itemChungTuTimDuoc.TenNguoiLap == itemChungTuKetChuyen.TenNguoiLap && itemChungTuTimDuoc.NgayLap == itemChungTuKetChuyen.NgayLap)
                    {
                        chungTuCanXoa = itemChungTuTimDuoc;
                    }
                }
                if (chungTuCanXoa != null)
                {
                    _danhSachChungTuTimDuocList.Remove(chungTuCanXoa);
                }
            }
            ChungTuTimDuoc_BindingSource.DataSource = _danhSachChungTuTimDuocList;

            grdu_DanhSachChungTu.Refresh();
        }

        private void SetSoChungTuMoiPS(int MaPhieu)
        {

            string soCTCu = ChungTu.KiemTraSoChungTuMoiNhat(MaPhieu, loaitien, Convert.ToDateTime(dtu_NgayLap.Value).Year);
            if (soCTCu != null)
            {

                if (_chungTu.MaChungTu == 0)
                {

                    SoCTMoiPS = ChungTu.LaySoChungTuMax(MaPhieu, Convert.ToDateTime(dtu_NgayLap.Value).Year);
                    txtSoChungTu.Text = SoCTMoiPS;
                }
                else
                {
                    SoCTMoiPS = _chungTu.SoChungTu;
                    txtSoChungTu.Text = SoCTMoiPS;

                }
            }
            else
            {
                SoCTMoiPS = "";
                txtSoChungTu.Text = "";
            }
        }

        bool KiemTraSoChungTu(string soct)
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


        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            ///Kiem tra du lieu truoc khi luu
            if (grdu_DanhSachChungTuKetChuyen.Rows.Count == 0)
            {
                MessageBox.Show(this, "Chưa lấy dữ liệu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbu_NoTaiKhoan.Value == null)
            {
                MessageBox.Show(this, "Chọn Nợ Tài Khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbu_TaiKhoanKetChuyen.Value == null || ( cbu_TaiKhoanKetChuyen.Value != null  && Convert.ToInt32(cbu_TaiKhoanKetChuyen.Value) == 0))
            {
                MessageBox.Show(this, "Chọn Tài Khoản Kết Chuyển.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtSoChungTu.Text == "" || KiemTraSoChungTu(txtSoChungTu.Text) == false)
            {
                if (loaitien == 1)
                {

                    MessageBox.Show(this, "Vui Lòng Nhập Số Chứng Từ theo định dạng 1234B/DVXX", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Số Chứng Từ theo định dạng 1234NTB/DVXX", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                if (_chungTu.MaChungTu == 0)
                    txtSoChungTu.Text = SoCTMoiPS;
                else
                    txtSoChungTu.Text = _chungTu.SoChungTu;
                txtSoChungTu.Focus();
                return;
            }

            if (ChungTu.KiemTraSoChungTu(txtSoChungTu.Text, _chungTu) == true)
            {
                MessageBox.Show(this, "Số Chứng Từ Đã Có Vui Lòng Nhập SCT Khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoChungTu.Focus();
                return;
            }

            KhoaSo_UserList khoaList = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(Convert.ToDateTime(dtu_NgayLap.Value));
            if (khoaList.Count > 0)
            {
                if (khoaList[0].KhoaSo == true)
                {
                    MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                ////////////////////////////////////Tiến hành lưu dữ liệu ////////////////////////////////////////
                int maChuongTrinh = 0;
                if (cbu_ChuongTrinh.Value != null)
                {
                    maChuongTrinh = Convert.ToInt32(cbu_ChuongTrinh.Value);
                }

                //Lấy dữ liệu đưa vào bảng tạm
                foreach (XuatDuLieu item in _danhSachChungTuKetChuyenList)
                {
                    Insert_KetChuyenChiPhiTam((int)item.MaChungTu, item.SoTien, item.SoTienChiPhiSanXuat, item.SoTienMucNganSach, item.MaChuongTrinh, item.MaTieuMucNganSach, item.MaMucNganSach, item.MaTaiKhoanCo, item.MaButToan, item.MaButToanChiPhiSanXuat, item.MaButToanMucNganSach, item.MaChiPhiThucHien, item.MaChiThuLao, item.MaButToanMucNganSachNew);
                }

                //Khởi tạo chứng từ mới
                _chungTu = ChungTu.NewChungTu();

                //Lấy dữ liệu cho định khoản
                _chungTu.DinhKhoan.GhiMucNganSach = false;
                _chungTu.DinhKhoan.LaMotNoNhieuCo = true;
                _chungTu.DinhKhoan.NoCo = false;

                //Lấy dữ liệu cho chứng từ
                _chungTu.NgayLap = Convert.ToDateTime(dtu_NgayLap.Value);
                _chungTu.DienGiai = Convert.ToString(txtDienGiai.Value);
                _chungTu.SoChungTu = Convert.ToString(txtSoChungTu.Value);
                //_chungTu.LoaiChungTu.MaLoaiCT = 16;
                _chungTu.LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDevByMaQuanLy("PKT");
                _chungTu.MaDoiTuongThuChi = 1;
                _chungTu.KhoaSo = 1;

                //Lấy dữ liệu cho tiền tệ
                decimal _soTien_TienTe = 0;
                decimal _thanhTien_TienTe = 0;
                decimal _tiGiaQuyDoi_TienTe = 1;

                _soTien_TienTe = LaySoTienChungTu();
                _thanhTien_TienTe = _soTien_TienTe;

                _chungTu.Tien.SoTien = _soTien_TienTe;
                _chungTu.Tien.ThanhTien = _thanhTien_TienTe;
                _chungTu.Tien.TiGiaQuyDoi = _tiGiaQuyDoi_TienTe;
                _chungTu.Tien.MaLoaiTien = 1;

                //Lấy dữ liệu cho bút toán
                int coTaiKhoan = Convert.ToInt32(cbu_NoTaiKhoan.Value);
                int noTaiKhoan = Convert.ToInt32(cbu_TaiKhoanKetChuyen.Value);
                string dienGiai = "";

                //Lấy tất cả diễn giải của bút toán trong chứng từ kết chuyển chi phí
                ButToanList butToanList = ButToanList.LayButToanInKetChuyenChungTuList();
                int bien = 0;
                foreach (ButToan item in butToanList)
                {
                    if (item.DienGiai != null && bien == butToanList.Count - 1)
                        dienGiai += item.DienGiai.Trim();
                    else
                        dienGiai += item.DienGiai.Trim() + ",";
                    bien += 1;
                }

                ButToan butToan = ButToan.NewButToan();
                butToan.CoTaiKhoan = coTaiKhoan;
                butToan.NoTaiKhoan = noTaiKhoan;
                butToan.DienGiai = dienGiai;
                butToan.SoTien = _soTien_TienTe;
                _chungTu.DinhKhoan.ButToan.Add(butToan);

                //Lấy dữ liệu chi phí sản xuất
                ChungTu_ChiPhiSanXuatList chiPhiSanXuatList = ChungTu_ChiPhiSanXuatList.GetChungTu_ChiPhiSanXuatByButToanListByKetChuyen_New();

                foreach (ChungTu_ChiPhiSanXuat chiPhiSanXuat in chiPhiSanXuatList)//Duyệt qua từng dòng dữ liệu
                {
                    if (chiPhiSanXuat.MaChuongTrinh != 0)
                    {
                        ChungTu_ChiPhiSanXuat chungTuChiPhiSanXuat = ChungTu_ChiPhiSanXuat.NewChungTu_ChiPhiSanXuat();
                        chungTuChiPhiSanXuat.MaChuongTrinh = chiPhiSanXuat.MaChuongTrinh;
                        chungTuChiPhiSanXuat.TenChuongTrinh = chiPhiSanXuat.TenChuongTrinh;
                        chungTuChiPhiSanXuat.SoTien = chiPhiSanXuat.SoTien;

                        //Lấy dữ liệu bút toán mục ngân sách
                        ButtoanMucNganSachList buttoanMucNganSachList = ButtoanMucNganSachList.GetButtoanMucNganSachListByKetChuyenChiPhi_New(chiPhiSanXuat.MactChiphisanxuat);
                        foreach (ButToanMucNganSach butToanMucNganSach in buttoanMucNganSachList)
                        {
                            if (butToanMucNganSach.MaTieuMucNganSach != 0)
                            {
                                ButToanMucNganSach butToan_MucNganSach = ButToanMucNganSach.NewButToanMucNganSach();
                                butToan_MucNganSach.MaTieuMucNganSach = butToanMucNganSach.MaTieuMucNganSach;
                                butToan_MucNganSach.SoTien = butToanMucNganSach.SoTien;
                                butToan_MucNganSach.DienGiai = butToanMucNganSach.DienGiai;

                                chungTuChiPhiSanXuat.ButtoanMucNganSachList.Add(butToan_MucNganSach);
                            }
                        }

                        _chungTu.DinhKhoan.ButToan[0].ChungTuChiPhiSanXuatList.Add(chungTuChiPhiSanXuat);
                    }
                }

                //Lưu chứng từ
                _chungTu.ApplyEdit();
                _chungTu.Save();

                //Xóa bảng kết chuyển chứng từ tạm
                Delete_KetChuyenChiPhiTam(_chungTu.MaChungTu, true);

                MessageBox.Show("Kết chuyển thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //
                {
                    _danhSachChungTuKetChuyenList = XuatDuLieuList.NewXuatDuLieuList();
                    grdu_DanhSachChungTuKetChuyen.DataSource = _danhSachChungTuKetChuyenList;
                    _chungTu = ChungTu.NewChungTu();
                    txtSoChungTu.Value = null;
                    cbu_TaiKhoanKetChuyen.Value = null;
                    lbSoTien.Text = null;
                    lbSoTienChiPhi.Text = null;
                    lbSoTienNganSach.Text = null;
                }
            }
            catch
            {
                throw;
            }
        }

        protected void Insert_KetChuyenChiPhiTam(int _maChungTu, decimal _soTien, decimal _soTienChiPhiSanXuat, decimal _soTienMucNganSach, int _maChuongTrinh, int _maTieuMuc, int _maMuc, int _maTaiKhoanCo, int _maButToan, int _maButToanChiPhiSanXuat, int _maButToanMucNganSach, int _maChiPhiThucHien, int _maChiThuLao, int _maButToanMucNganSachNew)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Insert_KetChuyenChiPhiTam_New";
                        cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
                        cm.Parameters.AddWithValue("@SoTien", _soTien);
                        cm.Parameters.AddWithValue("@SoTienChiPhiSanXuat", _soTienChiPhiSanXuat);
                        cm.Parameters.AddWithValue("@SoTienMucNganSach", _soTienMucNganSach);
                        cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
                        cm.Parameters.AddWithValue("@MaTieuMuc", _maTieuMuc);
                        cm.Parameters.AddWithValue("@MaMuc", _maMuc);
                        cm.Parameters.AddWithValue("@MaTaiKhoanCo", _maTaiKhoanCo);
                        cm.Parameters.AddWithValue("@MaButToan", _maButToan);
                        cm.Parameters.AddWithValue("@MaButToanChiPhiSanXuat", _maButToanChiPhiSanXuat);
                        cm.Parameters.AddWithValue("@MaButToanMucNganSach", _maButToanMucNganSach);
                        cm.Parameters.AddWithValue("@MaChiPhiThucHien", _maChiPhiThucHien);
                        cm.Parameters.AddWithValue("@MaChiThuLao", _maChiThuLao);
                        cm.Parameters.AddWithValue("@MaButToanMucNganSachNew", _maButToanMucNganSachNew);
                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal LaySoTienChiPhiSanXuat()
        {
            decimal _soTien = 0;

            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LaySoTienChiPhiSanXuat";
                    cm.Parameters.AddWithValue("@SoTien", _soTien).Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    _soTien = Convert.ToDecimal(cm.Parameters["@SoTien"].Value);
                }
            }
            return _soTien;
        }
        private decimal LaySoTienNganSach()
        {
            decimal _soTien = 0;

            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LaySoTienNganSach";
                    cm.Parameters.AddWithValue("@SoTien", _soTien).Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    _soTien = Convert.ToDecimal(cm.Parameters["@SoTien"].Value);
                }
            }
            return _soTien;
        }

        private decimal LaySoTienNganSach_New()
        {
            decimal _soTien = 0;

            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LaySoTienNganSach_New";
                    cm.Parameters.AddWithValue("@SoTien", _soTien).Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    _soTien = Convert.ToDecimal(cm.Parameters["@SoTien"].Value);
                }
            }
            return _soTien;
        }

        private decimal LaySoTienChungTu()
        {
            decimal _soTien = 0;

            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LaySoTienChungTu";
                    cm.Parameters.AddWithValue("@SoTien", _soTien).Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    _soTien = Convert.ToDecimal(cm.Parameters["@SoTien"].Value);
                }
            }
            return _soTien;
        }

        private decimal LaySoTienButToan(int coTaiKhoan)
        {
            decimal _soTien = 0;

            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LaySoTienButToan";
                    cm.Parameters.AddWithValue("@MaKhoanCo", coTaiKhoan);
                    cm.Parameters.AddWithValue("@SoTien", _soTien).Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    _soTien = Convert.ToDecimal(cm.Parameters["@SoTien"].Value);
                }
            }
            return _soTien;
        }


        private void grdu_DanhSachChungTu_FilterCellValueChanged(object sender, FilterCellValueChangedEventArgs e)
        {
            _duLieu = "";
            UltraGridFilterCell filterCell = e.FilterCell;
            EmbeddableEditorBase editor = filterCell.EditorResolved;

            if (filterCell.Value != null && editor.IsValid)
            {
                _duLieu = editor.Value.ToString();
            }
        }

        private void grdu_DanhSachChungTuKetChuyen_FilterCellValueChanged(object sender, FilterCellValueChangedEventArgs e)
        {
            _duLieu = "";
            UltraGridFilterCell filterCell = e.FilterCell;
            EmbeddableEditorBase editor = filterCell.EditorResolved;

            if (filterCell.Value != null && editor.IsValid)
            {
                _duLieu = editor.Value.ToString();
            }
        }

        private void cbu_TaiKhoanKetChuyen_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbu_TaiKhoanKetChuyen, "SoHieuTK");
            foreach (UltraGridColumn col in this.cbu_TaiKhoanKetChuyen.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbu_TaiKhoanKetChuyen.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            cbu_TaiKhoanKetChuyen.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            cbu_TaiKhoanKetChuyen.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            cbu_TaiKhoanKetChuyen.DisplayLayout.Bands[0].Columns["SoHieuTK"].Width = 70;
            cbu_TaiKhoanKetChuyen.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            cbu_TaiKhoanKetChuyen.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            cbu_TaiKhoanKetChuyen.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 200;
            cbu_TaiKhoanKetChuyen.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;
        }

        private void cbu_NguoiLap_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbu_NguoiLap.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            cbu_NguoiLap.DisplayLayout.Bands[0].Columns["TenDangNhap"].Hidden = false;
            cbu_NguoiLap.DisplayLayout.Bands[0].Columns["TenDangNhap"].Header.Caption = "Người Lập";
            cbu_NguoiLap.DisplayLayout.Bands[0].Columns["TenDangNhap"].Header.VisiblePosition = 0;
            cbu_NguoiLap.DisplayLayout.Bands[0].Columns["TenDangNhap"].Width = 80;

            this.cbu_NguoiLap.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cbu_NguoiLap.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            txtSoChungTu.Value = null;
            txtDienGiai.Value = null;
            dtu_NgayLap.Value = DateTime.Now.Date;
            cbu_TaiKhoanKetChuyen.Value = null;
            lbSoTien.Text = null;
            lbSoTienChiPhi.Text = null;
            lbSoTienNganSach.Text = null;
            _danhSachChungTuKetChuyenList = XuatDuLieuList.NewXuatDuLieuList();
            grdu_DanhSachChungTuKetChuyen.DataSource = _danhSachChungTuKetChuyenList;
            _chungTu = ChungTu.NewChungTu();
        }
    }
}
