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
    public partial class frmKetChuyenChiPhi : Form
    {
        #region
        BoPhanList _boPhanList;
        ChuongTrinhList _chuongTrinhList;
        TieuMucNganSachList _tieuMucNganSachList;
        MucNganSachList _mucNganSachList;
        HeThongTaiKhoan1List _heThongTaiKhoan1ListNo;
        ChungTuList _chungTuList;
        ChungTu _chungTu = ChungTu.NewChungTu();
        XuatDuLieuList _xuatDuLieuList;
        XuatDuLieuList xuatDuLieuList = XuatDuLieuList.NewXuatDuLieuList();
        HamDungChung hamDungChung = new HamDungChung();
        ERP_Library.Security.UserList _UserList;
        int userID = CurrentUser.Info.UserID;
        int loaitien = 1;
        string SoCTMoiPS = "";
        string _duLieu = "";
        #endregion

        public frmKetChuyenChiPhi()
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
            BoPhan _boPhan = BoPhan.NewBoPhan("Tất Cả");
            _boPhanList.Insert(0,_boPhan);
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

            //_nguoiLapList = ThongTinNhanVienTongHopList.GetNguoiLapAll();
            //ThongTinNhanVienTongHop _nguoiLap = ThongTinNhanVienTongHop.NewThongTinNhanVienTongHop(0,"Tất Cả");
            //_nguoiLapList.Insert(0,_nguoiLap);
            //NguoiLap_BindingSource.DataSource = _nguoiLapList;

            _UserList = ERP_Library.Security.UserList.GetUserList(ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            ERP_Library.Security.UserItem user = ERP_Library.Security.UserItem.NewUserItem("Tất Cả");
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
            int userID = Convert.ToInt32(cbu_NguoiLap.Value);

            if (userID == 0)
            { maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan; }

            if (cbu_NoTaiKhoan.Value == null)
            {
                MessageBox.Show(this, "Chọn Nợ Tài Khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _xuatDuLieuList = XuatDuLieuList.GetXuatDuLieuListByKetChuyenChiPhi(tuNgay, denNgay, maBoPhan, userID, maChuongTrinh, maTaiKhoanNo, maTieuMucNganSach, maMucNganSach);
            if (_xuatDuLieuList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            grdu_DanhSachChungTu.DataSource = _xuatDuLieuList;
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

            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["Check"].CellClickAction = CellClickAction.Edit;

            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
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
           
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
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


            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["Check"].CellActivation = Activation.AllowEdit;

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
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["Check"].Width = 60;
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
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["Check"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["NgayLap"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenTieuMucNganSach"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenMucNganSach"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TKCo"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTuKetChuyen.DisplayLayout.Bands[0].Columns["TenNguoiLap"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

        }

        private void Check_TatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (_duLieu.Trim().CompareTo("") != 0 && _duLieu.Trim().CompareTo("(NonBlanks)") != 0)
            {
                if (Check_TatCa.Checked == true)
                {
                    for (int i = 0; i < grdu_DanhSachChungTu.Rows.Count; i++)
                    {
                        if (!grdu_DanhSachChungTu.Rows[i].Hidden == true && (grdu_DanhSachChungTu.Rows[i].Cells["TKCo"].Value.ToString().Trim() == _duLieu.Trim() || grdu_DanhSachChungTu.Rows[i].Cells["TenNguoiLap"].Value.ToString().Trim() == _duLieu.Trim() || grdu_DanhSachChungTu.Rows[i].Cells["TenMucNganSach"].Value.ToString().Trim() == _duLieu.Trim() || grdu_DanhSachChungTu.Rows[i].Cells["TenTieuMucNganSach"].Value.ToString().Trim() == _duLieu.Trim() || grdu_DanhSachChungTu.Rows[i].Cells["SoChungTu"].Value.ToString().Trim() == _duLieu.Trim()  || grdu_DanhSachChungTu.Rows[i].Cells["TenTaiKhoan"].Value.ToString().Trim() == _duLieu.Trim() || grdu_DanhSachChungTu.Rows[i].Cells["TenChuongTrinh"].Value.ToString().Trim() == _duLieu.Trim() || grdu_DanhSachChungTu.Rows[i].Cells["NgayLap"].Value.ToString().Trim() == _duLieu.Trim() || grdu_DanhSachChungTu.Rows[i].Cells["SoTien"].Value.ToString().Trim() == _duLieu.Trim() || grdu_DanhSachChungTu.Rows[i].Cells["SoTienChiPhiSanXuat"].Value.ToString().Trim() == _duLieu.Trim() || grdu_DanhSachChungTu.Rows[i].Cells["SoTienMucNganSach"].Value.ToString().Trim() == _duLieu.Trim()))
                        {
                            grdu_DanhSachChungTu.Rows[i].Cells["Check"].Value = (object)true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdu_DanhSachChungTu.Rows.Count; i++)
                    {
                        grdu_DanhSachChungTu.Rows[i].Cells["Check"].Value = (object)false;
                    }
                }

                _duLieu = "";
            }
            else
            {
                if (Check_TatCa.Checked == true)
                {
                    for (int i = 0; i < grdu_DanhSachChungTu.Rows.Count; i++)
                    {
                        if (!grdu_DanhSachChungTu.Rows[i].Hidden == true)
                        {
                            grdu_DanhSachChungTu.Rows[i].Cells["Check"].Value = (object)true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdu_DanhSachChungTu.Rows.Count; i++)
                    {
                        grdu_DanhSachChungTu.Rows[i].Cells["Check"].Value = (object)false;
                    }
                }
            }
        }

        private void Check_TatCaKetChuyen_CheckedChanged(object sender, EventArgs e)
        {
            if (_duLieu.Trim().CompareTo("") != 0 && _duLieu.Trim().CompareTo("(NonBlanks)") != 0)
            {
                if (Check_TatCaKetChuyen.Checked == true)
                {
                    for (int i = 0; i < grdu_DanhSachChungTuKetChuyen.Rows.Count; i++)
                    {
                        if (!grdu_DanhSachChungTuKetChuyen.Rows[i].Hidden == true && (grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["TKCo"].Value.ToString().Trim() == _duLieu.Trim() || grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["TenNguoiLap"].Value.ToString().Trim() == _duLieu.Trim() || grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["TenMucNganSach"].Value.ToString().Trim() == _duLieu.Trim() || grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["TenTieuMucNganSach"].Value.ToString().Trim() == _duLieu.Trim() || grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["SoChungTu"].Value.ToString().Trim() == _duLieu.Trim() || grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["TenChuongTrinh"].Value.ToString().Trim() == _duLieu.Trim() || grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["TenTaiKhoan"].Value.ToString().Trim() == _duLieu.Trim() || grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["NgayLap"].Value.ToString().Trim() == _duLieu.Trim() || grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["SoTien"].Value.ToString().Trim() == _duLieu.Trim() || grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["SoTienMucNganSach"].Value.ToString().Trim() == _duLieu.Trim() || grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["SoTienChiPhiSanXuat"].Value.ToString().Trim() == _duLieu.Trim()))
                        {
                            grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["Check"].Value = (object)true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdu_DanhSachChungTuKetChuyen.Rows.Count; i++)
                    {
                        grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["Check"].Value = (object)false;
                    }
                }

                _duLieu = "";
            }
            else
            {
                if (Check_TatCaKetChuyen.Checked == true)
                {
                    for (int i = 0; i < grdu_DanhSachChungTuKetChuyen.Rows.Count; i++)
                    {
                        if (!grdu_DanhSachChungTuKetChuyen.Rows[i].Hidden == true)
                        {
                            grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["Check"].Value = (object)true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdu_DanhSachChungTuKetChuyen.Rows.Count; i++)
                    {
                        grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["Check"].Value = (object)false;
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grdu_DanhSachChungTuKetChuyen.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (int i = 0; i < grdu_DanhSachChungTuKetChuyen.Rows.Count; i++)
            {
                if ((bool)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["Check"].Value == true)
                {
                    grdu_DanhSachChungTuKetChuyen.Rows[i].Selected = true;

                }
            }
            grdu_DanhSachChungTuKetChuyen.DeleteSelectedRows();
            Check_TatCaKetChuyen.Checked = false;
            lbSoTien.Text = "";
            lbSoTienChiPhi.Text = "";
            lbSoTienNganSach.Text = "";
            TinhSoTienKetChuyen();
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
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["Check"].CellClickAction = CellClickAction.Edit;

            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
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

            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
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


            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["Check"].CellActivation = Activation.AllowEdit;

            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTienChiPhiSanXuat"].Header.Caption = "Tiền SX";
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTienMucNganSach"].Header.Caption = "Tiền NS";
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Chọn";
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
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["Check"].Width = 60;
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
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["Check"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenTieuMucNganSach"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenMucNganSach"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TKCo"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTu.DisplayLayout.Bands[0].Columns["TenNguoiLap"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
  
        }

        private void TinhSoTienKetChuyen()
        {
            //// dua du lieu trong danh sach ket chuyen vao list tam thoi de tien xu ly 
            for (int i = 0; i < grdu_DanhSachChungTuKetChuyen.Rows.Count; i++)
            {
                int maChungTu = (int)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["MaChungTu"].Value;
                int maCT = (int)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["MaChuongTrinh"].Value;
                int maTieuMuc = (int)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["MaTieuMucNganSach"].Value;
                int maMuc = (int)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["MaMucNganSach"].Value;
                int maTaiKhoanCo = (int)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["MaTaiKhoanCo"].Value;
                int maButToan = (int)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["MaButToan"].Value;
                decimal soTien = (decimal)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["SoTien"].Value;
                decimal soTienChiPhiSanXuat = (decimal)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["SoTienChiPhiSanXuat"].Value;
                decimal soTienMucNganSach = (decimal)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["SoTienMucNganSach"].Value;
                int maButToanChiPhiSanXuat = (int)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["MaButToanChiPhiSanXuat"].Value;
                int maButToanMucNganSach = (int)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["MaButToanMucNganSach"].Value;
                int maChiPhiThucHien = (int)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["MaChiPhiThucHien"].Value;
                int maChiThuLao = (int)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["MaChiThuLao"].Value;
                Insert_KetChuyenChiPhiTam(maChungTu, soTien, soTienChiPhiSanXuat, soTienMucNganSach, maCT, maTieuMuc, maMuc, maTaiKhoanCo, maButToan, maButToanChiPhiSanXuat, maButToanMucNganSach, maChiPhiThucHien, maChiThuLao);
            }

            lbSoTien.Text = "Tiền bút toán : " + String.Format("{0:0,0}", LaySoTienChungTu());
            lbSoTienChiPhi.Text = "Tiền chi phí : " + String.Format("{0:0,0}", LaySoTienChiPhiSanXuat());
            lbSoTienNganSach.Text = "Tiền ngân sách : " + String.Format("{0:0,0}", LaySoTienNganSach());
            Delete_KetChuyenChiPhiTam(0,false);
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            grdu_DanhSachChungTu.UpdateData();
            int _bienTam = 0;
            ///lay du lieu tu danh sach chung tu dem qua danh sach chung tu ket chuyen
            DialogResult _DialogResult = MessageBox.Show("Bạn có đồng ý đưa chứng từ qua không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (_DialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < grdu_DanhSachChungTu.Rows.Count; i++)
                {
                    if ((bool)grdu_DanhSachChungTu.Rows[i].Cells["Check"].Value == true)
                    {
                        int maChungTu = Convert.ToInt32(grdu_DanhSachChungTu.Rows[i].Cells["MaChungTu"].Value);
                        int maChuongTrinh = Convert.ToInt32(grdu_DanhSachChungTu.Rows[i].Cells["MaChuongTrinh"].Value);
                        int maTieuMuc = Convert.ToInt32(grdu_DanhSachChungTu.Rows[i].Cells["MaTieuMucNganSach"].Value);
                        int maMuc = Convert.ToInt32(grdu_DanhSachChungTu.Rows[i].Cells["MaMucNganSach"].Value);
                        int maTaiKhoanCo = Convert.ToInt32(grdu_DanhSachChungTu.Rows[i].Cells["MaTaiKhoanCo"].Value);
                        int maButToan = Convert.ToInt32(grdu_DanhSachChungTu.Rows[i].Cells["MaButToan"].Value);
                        string soChungTu = Convert.ToString(grdu_DanhSachChungTu.Rows[i].Cells["SoChungTu"].Value);
                        string taiKhoanCo = Convert.ToString(grdu_DanhSachChungTu.Rows[i].Cells["TKCo"].Value);
                        string tenTaiKhoan = Convert.ToString(grdu_DanhSachChungTu.Rows[i].Cells["TenTaiKhoan"].Value);
                        string tenNguoiLap = Convert.ToString(grdu_DanhSachChungTu.Rows[i].Cells["TenNguoiLap"].Value);
                        string tenChuongTrinh = Convert.ToString(grdu_DanhSachChungTu.Rows[i].Cells["TenChuongTrinh"].Value);
                        string tenTieuMuc = Convert.ToString(grdu_DanhSachChungTu.Rows[i].Cells["TenTieuMucNganSach"].Value);
                        string tenMuc = Convert.ToString(grdu_DanhSachChungTu.Rows[i].Cells["TenMucNganSach"].Value);
                        decimal soTienChiPhiSanXuat = Convert.ToDecimal(grdu_DanhSachChungTu.Rows[i].Cells["SoTienChiPhiSanXuat"].Value);
                        decimal soTienMucNganSach = Convert.ToDecimal(grdu_DanhSachChungTu.Rows[i].Cells["SoTienMucNganSach"].Value);
                        decimal soTien = Convert.ToDecimal(grdu_DanhSachChungTu.Rows[i].Cells["SoTien"].Value);
                        DateTime ngayLap = Convert.ToDateTime(grdu_DanhSachChungTu.Rows[i].Cells["NgayLap"].Value);
                        int maButToanChiPhiSanXuat = Convert.ToInt32(grdu_DanhSachChungTu.Rows[i].Cells["MaButToanChiPhiSanXuat"].Value);
                        int maButToanMucNganSach = Convert.ToInt32(grdu_DanhSachChungTu.Rows[i].Cells["MaButToanMucNganSach"].Value);
                        int maChiThuLao = Convert.ToInt32(grdu_DanhSachChungTu.Rows[i].Cells["MaChiThuLao"].Value);
                        int maChiPhiThucHien = Convert.ToInt32(grdu_DanhSachChungTu.Rows[i].Cells["MaChiPhiThucHien"].Value);

                        for (int j = 0; j < grdu_DanhSachChungTuKetChuyen.Rows.Count; j++)
                        {
                            int _maChungTu = Convert.ToInt32(grdu_DanhSachChungTuKetChuyen.Rows[j].Cells["MaChungTu"].Value);
                            int _maChuongTrinh = Convert.ToInt32(grdu_DanhSachChungTuKetChuyen.Rows[j].Cells["MaChuongTrinh"].Value);
                            int _maTieuMuc = Convert.ToInt32(grdu_DanhSachChungTuKetChuyen.Rows[j].Cells["MaTieuMucNganSach"].Value);
                            int _maMuc = Convert.ToInt32(grdu_DanhSachChungTuKetChuyen.Rows[j].Cells["MaMucNganSach"].Value);
                            int _maTaiKhoanCo = Convert.ToInt32(grdu_DanhSachChungTuKetChuyen.Rows[j].Cells["MaTaiKhoanCo"].Value);
                            int _maButToan = Convert.ToInt32(grdu_DanhSachChungTuKetChuyen.Rows[j].Cells["MaButToan"].Value);
                            string _tenTaiKhoan = Convert.ToString(grdu_DanhSachChungTuKetChuyen.Rows[j].Cells["TenTaiKhoan"].Value);
                            string _soChungTu = Convert.ToString(grdu_DanhSachChungTuKetChuyen.Rows[j].Cells["SoChungTu"].Value);
                            string _taiKhoanCo = Convert.ToString(grdu_DanhSachChungTuKetChuyen.Rows[j].Cells["TKCo"].Value);
                            string _tenChuongTrinh = Convert.ToString(grdu_DanhSachChungTuKetChuyen.Rows[j].Cells["TenChuongTrinh"].Value);
                            string _tenNguoiLap = Convert.ToString(grdu_DanhSachChungTuKetChuyen.Rows[j].Cells["TenNguoiLap"].Value);     
                            string _tenTieuMuc = Convert.ToString(grdu_DanhSachChungTuKetChuyen.Rows[j].Cells["TenTieuMucNganSach"].Value);
                            string _tenMuc = Convert.ToString(grdu_DanhSachChungTuKetChuyen.Rows[j].Cells["TenMucNganSach"].Value);
                            decimal _soTienChiPhiSanXuat = Convert.ToDecimal(grdu_DanhSachChungTuKetChuyen.Rows[j].Cells["SoTienChiPhiSanXuat"].Value);
                            decimal _soTienMucNganSach = Convert.ToDecimal(grdu_DanhSachChungTuKetChuyen.Rows[j].Cells["SoTienMucNganSach"].Value);
                            decimal _soTien = Convert.ToDecimal(grdu_DanhSachChungTuKetChuyen.Rows[j].Cells["SoTien"].Value);
                            DateTime _ngayLap = Convert.ToDateTime(grdu_DanhSachChungTuKetChuyen.Rows[j].Cells["NgayLap"].Value);
                            int _maButToanChiPhiSanXuat = Convert.ToInt32(grdu_DanhSachChungTuKetChuyen.Rows[j].Cells["MaButToanChiPhiSanXuat"].Value);
                            int _maButToanMucNganSach = Convert.ToInt32(grdu_DanhSachChungTuKetChuyen.Rows[j].Cells["MaButToanMucNganSach"].Value);
                            int _maChiThuLao = Convert.ToInt32(grdu_DanhSachChungTuKetChuyen.Rows[j].Cells["MaChiThuLao"].Value);
                            int _maChiPhiThucHien = Convert.ToInt32(grdu_DanhSachChungTuKetChuyen.Rows[j].Cells["MaChiPhiThucHien"].Value);

                            if (_tenNguoiLap==tenNguoiLap && _maChungTu == maChungTu && _soChungTu == soChungTu && _tenChuongTrinh == tenChuongTrinh && taiKhoanCo == _taiKhoanCo && _tenMuc == tenMuc && tenTieuMuc == _tenTieuMuc && ngayLap == _ngayLap && _soTienChiPhiSanXuat == soTienChiPhiSanXuat && soTienMucNganSach == _soTienMucNganSach && _soTien == soTien && _maChuongTrinh == maChuongTrinh && maTieuMuc == _maTieuMuc && maMuc == _maMuc && maButToan == _maButToan && _maTaiKhoanCo == maTaiKhoanCo && _maButToanChiPhiSanXuat == maButToanChiPhiSanXuat && _maButToanMucNganSach == maButToanMucNganSach && _maChiPhiThucHien == maChiPhiThucHien && _maChiThuLao == maChiThuLao)
                            {
                                _bienTam = 1;
                            }
                        }

                        if (_bienTam == 0)
                        {
                            XuatDuLieu _xuatDuLieu = XuatDuLieu.NewXuatDuLieu(maChungTu, taiKhoanCo, tenChuongTrinh, tenTieuMuc, tenMuc, soChungTu, soTienMucNganSach, soTienChiPhiSanXuat, ngayLap);
                            _xuatDuLieu.MaChungTu = maChungTu;
                            _xuatDuLieu.TenChuongTrinh = tenChuongTrinh;
                            _xuatDuLieu.TenTieuMucNganSach = tenTieuMuc;
                            _xuatDuLieu.TenMucNganSach = tenMuc;
                            _xuatDuLieu.SoTienMucNganSach = soTienMucNganSach;
                            _xuatDuLieu.SoTienChiPhiSanXuat = soTienChiPhiSanXuat;
                            _xuatDuLieu.NgayLap = ngayLap;
                            _xuatDuLieu.TKCo = taiKhoanCo;
                            _xuatDuLieu.SoTien = soTien;
                            _xuatDuLieu.MaTaiKhoanCo = maTaiKhoanCo;
                            _xuatDuLieu.MaTieuMucNganSach = maTieuMuc;
                            _xuatDuLieu.MaMucNganSach = maMuc;
                            _xuatDuLieu.MaButToan = maButToan;
                            _xuatDuLieu.MaChuongTrinh = maChuongTrinh;
                            _xuatDuLieu.MaButToanChiPhiSanXuat = maButToanChiPhiSanXuat;
                            _xuatDuLieu.MaButToanMucNganSach = maButToanMucNganSach;
                            _xuatDuLieu.MaChiPhiThucHien = maChiPhiThucHien;
                            _xuatDuLieu.MaChiThuLao = maChiThuLao;
                            _xuatDuLieu.TenTaiKhoan = tenTaiKhoan;
                            _xuatDuLieu.TenNguoiLap = tenNguoiLap;
                            xuatDuLieuList.Add(_xuatDuLieu);
                        }
                        _bienTam = 0;
                    }
                }
                //gan vao du lieu vao danh sach chung tu ket chuyen
                grdu_DanhSachChungTuKetChuyen.DataSource = xuatDuLieuList;

                //khoi tao chung tu
                SetSoChungTuMoiPS(16);

                ///reload lai danh sach chung tu
                for (int j = 0; j < grdu_DanhSachChungTu.Rows.Count; j++)
                {
                    if ((bool)grdu_DanhSachChungTu.Rows[j].Cells["Check"].Value == true)
                    {
                        grdu_DanhSachChungTu.Rows[j].Cells["Check"].Value = false;
                        grdu_DanhSachChungTu.Rows[j].Hidden = true;
                    }
                }

                Check_TatCa.Checked = false;

                ////Hien so tien ket chuyen len man hinh
                TinhSoTienKetChuyen();
            }

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
                    _chungTu.SoChungTu = SoCTMoiPS;
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
                _chungTu.SoChungTu = "";

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

        private int LayGhiMucNganSach()
        {
            int _giaTri = 0;

            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LayGhiMucNganSach";
                    cm.Parameters.AddWithValue("@GiaTri", _giaTri).Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    _giaTri = Convert.ToInt32(cm.Parameters["@GiaTri"].Value);
                }
            }
            return _giaTri;
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

            if (cbu_TaiKhoanKetChuyen.Value == null)
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

            /////////////////////////////////////////////////////////Tien hanh luu du lieu///////////////////////////////////////////////////////////
            _chungTu.NgayLap = Convert.ToDateTime(dtu_NgayLap.Value);
            _chungTu.DienGiai = Convert.ToString(txtDienGiai.Value);
            _chungTu.SoChungTu = Convert.ToString(txtSoChungTu.Value);
            _chungTu.SoTT = ChungTu.GetSoTT() + 1;

            int maChuongTrinh = 0;
            if (cbu_ChuongTrinh.Value != null)
            {
                maChuongTrinh = Convert.ToInt32(cbu_ChuongTrinh.Value);
            }

            //// dua du lieu trong danh sach ket chuyen vao list tam thoi de tien xu ly 
            for (int i = 0; i < grdu_DanhSachChungTuKetChuyen.Rows.Count; i++)
            {
                int maChungTu = (int)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["MaChungTu"].Value;
                int maCT = (int)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["MaChuongTrinh"].Value;
                int maTieuMuc = (int)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["MaTieuMucNganSach"].Value;
                int maMuc = (int)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["MaMucNganSach"].Value;
                int maTaiKhoanCo = (int)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["MaTaiKhoanCo"].Value;
                int maButToan = (int)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["MaButToan"].Value;
                decimal soTien = (decimal)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["SoTien"].Value;
                decimal soTienChiPhiSanXuat = (decimal)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["SoTienChiPhiSanXuat"].Value;
                decimal soTienMucNganSach = (decimal)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["SoTienMucNganSach"].Value;
                int maButToanChiPhiSanXuat = (int)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["MaButToanChiPhiSanXuat"].Value;
                int maButToanMucNganSach = (int)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["MaButToanMucNganSach"].Value;
                int maChiPhiThucHien = (int)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["MaChiPhiThucHien"].Value;
                int maChiThuLao = (int)grdu_DanhSachChungTuKetChuyen.Rows[i].Cells["MaChiThuLao"].Value;
                ///them du lieu vao bang ket chuyen chi phi tam 
                Insert_KetChuyenChiPhiTam(maChungTu, soTien, soTienChiPhiSanXuat, soTienMucNganSach, maCT, maTieuMuc, maMuc, maTaiKhoanCo, maButToan, maButToanChiPhiSanXuat, maButToanMucNganSach, maChiPhiThucHien, maChiThuLao);
            }

            //////////////////////////////Luu dinh khoan ///////////////////////////////////////
            int _maDinhKhoan = 0;
            int _ghiMucNganSach = 0;
            //---lay ghi muc ngan sach
            _ghiMucNganSach = LayGhiMucNganSach();
            Insert_DinhKhoan(ref _maDinhKhoan, _ghiMucNganSach);

            //////////////////////////////////Luu chung tu//////////////////////////////////////
            long _maChungTu = 0;
            decimal _soTien_TienTe = 0;
            decimal _thanhTien_TienTe = 0;
            decimal _tiGiaQuyDoi_TienTe = 1;

            //--lay so tien chung tu trong bang chung tu tam
            _soTien_TienTe = LaySoTienChungTu();
            _thanhTien_TienTe = _soTien_TienTe;

            Insert_ChungTu(_chungTu, ref _maChungTu, _maDinhKhoan, _soTien_TienTe, _thanhTien_TienTe, _tiGiaQuyDoi_TienTe, _ghiMucNganSach);

            ///////////////////////////////// Luu but toan//////////////////////////////////////////////
            int _coTaiKhoan = Convert.ToInt32(cbu_NoTaiKhoan.Value);
            int _noTaiKhoan = Convert.ToInt32(cbu_TaiKhoanKetChuyen.Value);
            int _maButToan = 0;

            Insert_ButToan(_coTaiKhoan, _noTaiKhoan, _soTien_TienTe, _maDinhKhoan, ref _maButToan);
            /////////////////////////////// Luu but toan muc ngan sach /////////////////////////////////
            ButToan_MucNganSachImportList _butToanMucNganSachList = ButToan_MucNganSachImportList.GetButToan_MucNganSachImportListByKetChuyen();
            foreach (ButToan_MucNganSachImport _butToanMucNganSach in _butToanMucNganSachList)
            {
                if (Convert.ToInt32(_butToanMucNganSach.MaTieuMuc) != 0)
                {
                    Insert_ButToanMucNganSach(Convert.ToInt32(_butToanMucNganSach.MaTieuMuc), _maButToan, _butToanMucNganSach.SoTien);
                }
            }
            //////////////////////////////Luu chi phi san xuat /////////////////////////////////////////
            int _maCTChiPhiSanXuat = 0;
            ChungTu_ChiPhiSanXuatList _chiPhiSanXuatList = ChungTu_ChiPhiSanXuatList.GetChungTu_ChiPhiSanXuatByButToanListByKetChuyen();
            foreach (ChungTu_ChiPhiSanXuat _chiPhiSanXuat in _chiPhiSanXuatList)
            {
                if (_chiPhiSanXuat.MaChuongTrinh != 0)
                {
                    Insert_ButToanChiPhiSanXuat(ref _maCTChiPhiSanXuat, _maChungTu, _chungTu.SoChungTu, _chiPhiSanXuat.MaChuongTrinh, _chiPhiSanXuat.TenChuongTrinh, _chiPhiSanXuat.SoTien, _maButToan);

                    /////////////////////////// Luu chi thu lao /////////////////////////////////////////////////
                    DateTime _ngayLap = Convert.ToDateTime(dtu_NgayLap.Value);
                    DateTime _ngayThucHienChi = Convert.ToDateTime(dtu_NgayLap.Value);
                    ChiThuLaoList _chiThuLaoList = ChiThuLaoList.GetChiThuLaoListByKetChuyen(_chiPhiSanXuat.MaChuongTrinh);
                    foreach (ChiThuLao _chiThuLao in _chiThuLaoList)
                    {
                        if (_chiThuLao.MaBoPhanNhan != 0 && _chiThuLao.MaChuongTrinh != 0)
                        {
                            Insert_ChiThuLao(_maCTChiPhiSanXuat, _maChungTu, _chiThuLao.MaBoPhanNhan, _chiThuLao.SoTien, _chungTu.SoChungTu, _ngayLap, _ngayThucHienChi, _chiThuLao.MaChuongTrinh, _chiThuLao.TenChuongTrinh, _chiThuLao.TenBoPhanNhan, _chiThuLao.SoTienSeNhap, _chiThuLao.SoTienSeNhapNgoaiDai, _chiThuLao.SoTienDaNhap, _chiThuLao.SoTienConLai, _chiThuLao.SoTienDaNhapNgoaiDai, _chiThuLao.MaLoaiKinhPhi);
                        }
                    }
                    ///////////////////////luu chi phi thuc hien //////////////////////////////////////////////////
                    ChiPhiThucHienList _chiPhiThucHienList = ChiPhiThucHienList.GetChiPhiThucHienListByKetChuyen(_chiPhiSanXuat.MaChuongTrinh);
                    foreach (ChiPhiThucHien _chiPhiThucHien in _chiPhiThucHienList)
                    {
                        if (_chiPhiThucHien.MaDoiTuong != 0 && _chiPhiThucHien.MaChuongTrinh != 0)
                        {
                            Insert_ChiPhiThucHien(_maCTChiPhiSanXuat, _maChungTu, _chungTu.SoChungTu, _chiPhiThucHien.SoTien, _ngayLap, _chiPhiThucHien.MaChuongTrinh, _chiPhiThucHien.TenChuongTrinh, Convert.ToInt32(_chiPhiThucHien.MaDoiTuong), _chiPhiThucHien.TenDoiTuong, _chiPhiThucHien.DiaChi);
                        }
                    }               
                }
            }          
            ///Xoa bang ket chuyen chung tu tam
            Delete_KetChuyenChiPhiTam(_maChungTu,true);

            MessageBox.Show("Kết chuyển thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected void Insert_ChiThuLao(int _mactChiphisanxuat, long _maChungTu, int _maBoPhanNhan, decimal _soTien, string _soChungTu, DateTime _ngayLap, DateTime _ngayThucHienChi, int _maChuongTrinh, string _tenChuongTrinh, string _tenBoPhanNhan, decimal _soTienSeNhap, decimal _soTienSeNhapNgoaiDai, decimal _soTienDaNhap, decimal _soTienConLai, decimal _soTienDaNhapNgoaiDai, int _maLoaiKinhPhi)
        {
            long _maChiThuLao = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_InserttblcnChiThuLao";

                        cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
                        cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
                        cm.Parameters.AddWithValue("@MaBoPhanNhan", _maBoPhanNhan);
                        cm.Parameters.AddWithValue("@SoTien", _soTien);
                        cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
                        cm.Parameters.AddWithValue("@HoanTat", false);
                        cm.Parameters.AddWithValue("@MaChiThuLao", _maChiThuLao);
                        if (_soChungTu.Length > 0)
                            cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
                        else
                            cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
                        cm.Parameters.AddWithValue("@MaBoPhanGui", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                        cm.Parameters["@MaChiThuLao"].Direction = ParameterDirection.Output;
                        cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
                        cm.Parameters.AddWithValue("@NgayThucHienChi", _ngayThucHienChi);
                        if (_maChuongTrinh > 0)
                            cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
                        else
                            cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
                        if (_tenChuongTrinh.Length > 0)
                            cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
                        else
                            cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
                        cm.Parameters.AddWithValue("@TenBoPhanGui", BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);

                        if (_tenBoPhanNhan.Length > 0)
                            cm.Parameters.AddWithValue("@TenBoPhanNhan", _tenBoPhanNhan);
                        else
                            cm.Parameters.AddWithValue("@TenBoPhanNhan", DBNull.Value);
                        cm.Parameters.AddWithValue("@SoTienSeNhap", _soTienSeNhap);
                        cm.Parameters.AddWithValue("@SoTienSeNhapNgoaiDai", _soTienSeNhapNgoaiDai);
                        cm.Parameters.AddWithValue("@SoTienDaNhap", _soTienDaNhap);
                        cm.Parameters.AddWithValue("@SoTienDaNhapNgoaiDai", _soTienDaNhapNgoaiDai);
                        cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
                        cm.Parameters.AddWithValue("@NguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                        cm.Parameters.AddWithValue("@MaLoaiKinhPhi", _maLoaiKinhPhi);
                        if (_mactChiphisanxuat > 0)
                            cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", _mactChiphisanxuat);
                        else
                            cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", DBNull.Value);
                        cm.Parameters["@MaChiThuLao"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Insert_ChiPhiThucHien(int _mactChiphisanxuat, long _maChungTu, string _soChungTu, decimal _soTien, DateTime _ngayLap, int _maChuongTrinh, string _tenChuongTrinh, int _maDoiTuong, string _tenDoiTuong, string _diaChi)
        {
            long _maChiPhiThucHien = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "InserttblChiPhiThucHien";

                        if (_mactChiphisanxuat != 0)
                            cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", _mactChiphisanxuat);
                        else
                            cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", DBNull.Value);
                        if (_maChungTu != 0)
                            cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
                        else
                            cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
                        if (_soChungTu.Length > 0)
                            cm.Parameters.AddWithValue("@TenChungTu", _soChungTu);
                        else
                            cm.Parameters.AddWithValue("@TenChungTu", DBNull.Value);
                        if (_maChuongTrinh != 0)
                            cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
                        else
                            cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
                        if (_tenChuongTrinh.Length > 0)
                            cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
                        else
                            cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
                        cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
                        cm.Parameters.AddWithValue("@TenDoiTuong", _tenDoiTuong);
                        cm.Parameters.AddWithValue("@DiaChi", _diaChi);
                        if (_soTien != 0)
                            cm.Parameters.AddWithValue("@SoTien", _soTien);
                        else
                            cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
                        cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
                        cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
                        cm.Parameters.AddWithValue("@NguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                        cm.Parameters.AddWithValue("@MaLoaiChiPhiSanXuat", DBNull.Value);
                        cm.Parameters.AddWithValue("@MaChiPhiThucHien", _maChiPhiThucHien);
                        cm.Parameters["@MaChiPhiThucHien"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void Insert_ButToanChiPhiSanXuat(ref int _maCTChiPhiSanXuat, long _maChungTu, string _soChungTu, int _maChuongTrinh, string _tenChuongTrinh, decimal _soTien, int _maButToan)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "InserttblCT_ChiPhiSanXuat";

                        if (_maButToan != 0)
                            cm.Parameters.AddWithValue("@MaButToan", _maButToan);
                        else
                            cm.Parameters.AddWithValue("@MaButToan", DBNull.Value);
                        if (_maChungTu != 0)
                            cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
                        else
                            cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
                        cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
                        if (_soChungTu.Length > 0)
                            cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
                        else
                            cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
                        if (_maChuongTrinh != 0)
                            cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
                        else
                            cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
                        if (_tenChuongTrinh.Length > 0)
                            cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
                        else
                            cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
                        if (_soTien != 0)
                            cm.Parameters.AddWithValue("@SoTien", _soTien);
                        else
                            cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
                        cm.Parameters.AddWithValue("@MaLoaiChiPhi", DBNull.Value);
                        cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", 0);
                        cm.Parameters["@MaCT_ChiPhiSanXuat"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();

                        _maCTChiPhiSanXuat = (int)cm.Parameters["@MaCT_ChiPhiSanXuat"].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Insert_ButToanMucNganSach(int _maTieuMuc, int _maButToan, decimal _soTien)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Insert_ButToan_MucNganSach";
                        cm.Parameters.AddWithValue("@MaButToanMucNganSach", 0).Direction = ParameterDirection.Output;
                        cm.Parameters.AddWithValue("@MaTieuMuc", _maTieuMuc);
                        cm.Parameters.AddWithValue("@MaButToan", _maButToan);
                        cm.Parameters.AddWithValue("@SoTien", _soTien);
                        cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);

                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                        cm.Parameters.Add("@MaChungTu",maChungTu);
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
        private void Insert_KetChuyenChiPhiTam(int _maChungTu, decimal _soTien, decimal _soTienChiPhiSanXuat, decimal _soTienMucNganSach, int _maChuongTrinh, int _maTieuMuc, int _maMuc, int _maTaiKhoanCo, int _maButToan, int _maButToanChiPhiSanXuat, int _maButToanMucNganSach, int _maChiPhiThucHien, int _maChiThuLao)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Insert_KetChuyenChiPhiTam";
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
        protected int KiemTraGhiMucNganSach(long maChungTu)
        {
            int _giaTri = 0;

            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraGhiMucNganSach";
                    cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                    cm.Parameters.AddWithValue("@GiaTri", _giaTri).Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    _giaTri = (int)cm.Parameters["@GiaTri"].Value;
                }
            }
            return _giaTri;
        }
        protected void Insert_ButToan(int _coTaiKhoan, int _noTaiKhoan, decimal _soTien, int _maDinhKhoan, ref int _maButToan)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Insert_Buttoan";
                        cm.Parameters.AddWithValue("@MaButToan", 0).Direction = ParameterDirection.Output;
                        cm.Parameters.AddWithValue("@NoTaiKhoan", _noTaiKhoan);
                        cm.Parameters.AddWithValue("@CoTaiKhoan", _coTaiKhoan); ;
                        cm.Parameters.AddWithValue("@SoTien", _soTien);
                        cm.Parameters.AddWithValue("@MaDinhKhoan", _maDinhKhoan);
                        cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                        cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
                        cm.Parameters.AddWithValue("@MaDoiTuongNo", DBNull.Value);
                        cm.Parameters.AddWithValue("@MaDoiTuongCo", DBNull.Value);
                        cm.Parameters.AddWithValue("@MaHopDong", DBNull.Value);

                        cm.ExecuteNonQuery();

                        _maButToan = (int)cm.Parameters["@MaButToan"].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Insert_ChungTu(ChungTu chungTu, ref long _maChungTu, int _maDinhKhoan, decimal _soTien, decimal _thanhTien, decimal _tiGiaQuyDoi, int ghiMucNganSach)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Insert_ChungTu";
                        cm.Parameters.AddWithValue("@MaChungTu", chungTu.MaChungTu).Direction = ParameterDirection.Output;
                        cm.Parameters.AddWithValue("@SoTT", chungTu.SoTT);
                        cm.Parameters.AddWithValue("@MaChungTuQL", DBNull.Value);
                        cm.Parameters.AddWithValue("@SoChungTu", chungTu.SoChungTu);
                        cm.Parameters.AddWithValue("@NgayLap", chungTu.NgayLap);
                        cm.Parameters.AddWithValue("@GhiMucNganSach", ghiMucNganSach);
                        cm.Parameters.AddWithValue("@NgayThucHien", chungTu.NgayLap);
                        cm.Parameters.AddWithValue("@GhiSoCai", DBNull.Value);
                        cm.Parameters.AddWithValue("@MaBoPhanDangNhap", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                        cm.Parameters.AddWithValue("@TenBoPhanDangNhap", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                        cm.Parameters.AddWithValue("@MaLoaiDoiTuong", DBNull.Value);
                        cm.Parameters.AddWithValue("@LoaiChungTu", DBNull.Value);
                        cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                        cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
                        cm.Parameters.AddWithValue("@MaLoaiChungTu", 16);
                        cm.Parameters.AddWithValue("@KhoaSo", DBNull.Value);
                        cm.Parameters.AddWithValue("@MaDinhKhoan", _maDinhKhoan);
                        cm.Parameters.AddWithValue("@MaDoiTuongThuChi", 1);
                        cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", DBNull.Value);
                        cm.Parameters.AddWithValue("@DienGiai", chungTu.DienGiai);
                        cm.Parameters.AddWithValue("@MaKy", chungTu.NgayLap.Date.Month);
                        cm.Parameters.AddWithValue("@SoChungTuKemTheo", 1);
                        cm.ExecuteNonQuery();
                        _maChungTu = (long)cm.Parameters["@MaChungTu"].Value;
                        /// luu Tien Te
                        Insert_TienTe(_maChungTu, _soTien, _tiGiaQuyDoi, _thanhTien);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Insert_TienTe(long _maTienTe, decimal _soTien, decimal _tiGiaQuiDoi, decimal _thanhtien)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_InserttblTienTe";
                        cm.Parameters.AddWithValue("@MaTienTe", _maTienTe);
                        cm.Parameters.AddWithValue("@SoTien", _soTien);
                        cm.Parameters.AddWithValue("@MaLoaiTien", 1);
                        cm.Parameters.AddWithValue("@ThanhTien", _thanhtien);
                        cm.Parameters.AddWithValue("@VietBangChu", HamDungChung.DocTien(_soTien));
                        cm.Parameters.AddWithValue("@TiGiaQuyDoi", _tiGiaQuiDoi);
                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void Insert_DinhKhoan(ref int maDinhKhoan, int ghiMucNganSach)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Insert_DinhKhoan";
                        cm.Parameters.AddWithValue("@MaDinhKhoan", maDinhKhoan).Direction = ParameterDirection.Output;
                        cm.Parameters.AddWithValue("@GhiMucNganSach", ghiMucNganSach);
                        cm.Parameters.AddWithValue("@LaMotNoNhieuCo", true);
                        cm.Parameters.AddWithValue("@NoCo", false);
                        cm.ExecuteNonQuery();
                        maDinhKhoan = (int)cm.Parameters["@MaDinhKhoan"].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void grdu_DanhSachChungTu_FilterCellValueChanged(object sender, FilterCellValueChangedEventArgs e)
        {
            _duLieu = "";
            UltraGridFilterCell filterCell = e.FilterCell;
            EmbeddableEditorBase editor = filterCell.EditorResolved;

            if (filterCell.Value !=null && editor.IsValid)
            {
                _duLieu = editor.Value.ToString();
            }
        }

        private void grdu_DanhSachChungTuKetChuyen_FilterCellValueChanged(object sender, FilterCellValueChangedEventArgs e)
        {
            _duLieu = "";
            UltraGridFilterCell filterCell = e.FilterCell;
            EmbeddableEditorBase editor = filterCell.EditorResolved;

            if (filterCell.Value != null &&  editor.IsValid)
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
            xuatDuLieuList = XuatDuLieuList.NewXuatDuLieuList();
            grdu_DanhSachChungTuKetChuyen.DataSource = xuatDuLieuList;
        }

    }
}
