
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
using Infragistics.Win;

namespace PSC_ERP.UserInterface.NhanSu.Thu_Lao
{
    public partial class frmPhanBoThuLao : Form
    {
        #region
        PhanBoThuLaoList _phanBoThuLaoList = PhanBoThuLaoList.NewPhanBoThuLaoList();
        ChiTietPhanBoThuLaoList _chiTietPhanBoThuLaoList = ChiTietPhanBoThuLaoList.NewChiTietPhanBoThuLaoList();
        PhanBoThuLao _phanBoThuLao;
        ChuongTrinh _chuongTrinh;
        BoPhan _boPhan;
        GiayXacNhanTongHop _giayXacNhan;
        ChuongTrinhList _chuongTrinhList;
        BoPhanList _boPhanList;
        GiayXacNhanTongHopList _giayXacNhanList;
        CongViecList _congViecList;
        KyTinhLuongList _kyTinhLuongList;
        int maBoPhanDen = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
        int maNguoiLap = Convert.ToInt32(ERP_Library.Security.CurrentUser.Info.UserID);
        int _suaDuLieu = 0;
        Boolean _choPhepSua = true;
        #endregion

        public frmPhanBoThuLao()
        {
            InitializeComponent();
            LoadForm();
            grdu_ChiTietPhanBoThuLao.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_ChiTietPhanBoThuLao.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_ChiTietPhanBoThuLao.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));

            grdu_ChiTietPhanBoThuLao.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_ChiTietPhanBoThuLao.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_ChiTietPhanBoThuLao.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
        }
        public frmPhanBoThuLao(int maPhanBoThuLao)
        {
            InitializeComponent();
            LoadForm(maPhanBoThuLao);

            grdu_ChiTietPhanBoThuLao.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_ChiTietPhanBoThuLao.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_ChiTietPhanBoThuLao.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));

            grdu_ChiTietPhanBoThuLao.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_ChiTietPhanBoThuLao.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_ChiTietPhanBoThuLao.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);

        }

        public void LoadForm()
        {
            _phanBoThuLao = PhanBoThuLao.NewPhanBoThuLao();
            _phanBoThuLao.MaPhanBoThuLaoQL = PhanBoThuLao.MaPhanBoThuLaoQuanLy();
            PhanBoThuLao_BindingSource.DataSource = _phanBoThuLao;

            ChiTietPhanBoThuLao_BindingSource.DataSource = _phanBoThuLao.ChiTietPhanBoThuLaoList;

            _giayXacNhanList = GiayXacNhanTongHopList.GetGiayXacNhanTongHopListByBoPhanDen(maBoPhanDen);
            GiayXacNhanTongHop _giayXacNhanChuongTrinh = GiayXacNhanTongHop.NewGiayXacNhanTongHop(0, "Không Giấy Xác Nhận");
            _giayXacNhanList.Insert(0, _giayXacNhanChuongTrinh);
            GiayXacNhan_BindingSource.DataSource = _giayXacNhanList;

            _congViecList = CongViecList.GetCongViecList();
            CongViec_BindingSource.DataSource = _congViecList;

            _boPhanList = BoPhanList.GetBoPhanListBy_All();
            BoPhanDen_BindingSource.DataSource = _boPhanList;

            _chuongTrinhList = ChuongTrinhList.NewChuongTrinhList();
            ChuongTrinh_BindingSource.DataSource = _chuongTrinhList;

            _boPhanList = BoPhanList.NewBoPhanList();
            BoPhanDi_BindingSource.DataSource = _boPhanList;

            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongListByKhoaSo();
            KyTinhLuong_BindingSource.DataSource = _kyTinhLuongList;


            //Cài đặt lại phân quyền 
            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["MaBoPhanDen"].CellActivation = Activation.AllowEdit;
            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["MaCongViec"].CellActivation = Activation.AllowEdit;
            cmbu_GiayXacNhan.Enabled = true;
            cmbu_KyTinhLuong.Enabled = true;
            cbSoTien.Enabled = true;
            cbSoTienConLai.Enabled = true;
        }

        public void LoadForm(int maPhanBoThuLao)
        {
            _phanBoThuLao = PhanBoThuLao.GetPhanBoThuLao(maPhanBoThuLao);
            PhanBoThuLao_BindingSource.DataSource = _phanBoThuLao;

            ChiTietPhanBoThuLao_BindingSource.DataSource = _phanBoThuLao.ChiTietPhanBoThuLaoList;

            _giayXacNhanList = GiayXacNhanTongHopList.GetGiayXacNhanTongHopListByBoPhanDen(maBoPhanDen, maPhanBoThuLao);
            GiayXacNhan_BindingSource.DataSource = _giayXacNhanList;

            _congViecList = CongViecList.GetCongViecList();
            CongViec _congViec = CongViec.NewCongViec(0, "------");
            _congViecList.Insert(0, _congViec);
            CongViec_BindingSource.DataSource = _congViecList;

            _boPhanList = BoPhanList.GetBoPhanListBy_All();
            BoPhan _boPhan = BoPhan.NewBoPhan(0, "------");
            _boPhanList.Insert(0, _boPhan);
            BoPhanDen_BindingSource.DataSource = _boPhanList;

            ChuongTrinh_BindingSource.DataSource = ChuongTrinh.GetChuongTrinh(_phanBoThuLao.MaChuongTrinh);

            _boPhanList = BoPhanList.GetBoPhanListBy_All();
            BoPhanDi_BindingSource.DataSource = _boPhanList;

            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongListByKhoaSo();
            KyTinhLuong_BindingSource.DataSource = _kyTinhLuongList;

            cmbu_KyTinhLuong.Value = _phanBoThuLao.MaKyTinhLuong;
            cmbu_ChuongTrinh.Value = _phanBoThuLao.MaChuongTrinh;
            cmbu_BoPhan.Value = _phanBoThuLao.MaBoPhanDi;

            cbSoTienConLai.Value = _phanBoThuLao.SoTien - SoTienPhanBoThuLaoByGiayXacNhan(_phanBoThuLao.MaGiayXacNhanChuongTrinh, _phanBoThuLao.MaBoPhanDi);
            _suaDuLieu = 1;

            //Phân quyền cho lưới chi tiết phân bổ thù lao
            for(int i = 0; i< grdu_ChiTietPhanBoThuLao.Rows.Count ; i++)
            {
                long maChiTietPhanBoThuLao = Convert.ToInt64(grdu_ChiTietPhanBoThuLao.Rows[i].Cells["MaChiTietPhanBoThuLao"].Value);

                if (KiemTraChiTietPhanBoThuLao(maChiTietPhanBoThuLao) == 1)
                {
                    //Không cho sửa bộ phận đến và công việc
                    grdu_ChiTietPhanBoThuLao.Rows[i].Cells["MaBoPhanDen"].Activation = Activation.ActivateOnly;
                    grdu_ChiTietPhanBoThuLao.Rows[i].Cells["MaCongViec"].Activation = Activation.ActivateOnly;
                    // Không cho sửa kỳ tính lương và giấy xác nhận, số tiền
                    cmbu_GiayXacNhan.Enabled = false;
                    cmbu_KyTinhLuong.Enabled = false;
                    cbSoTien.Enabled = false;
                    cbSoTienConLai.Enabled = false;
                }
            }
        }
        private void grdu_ChiTietPhanBoThuLao_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            ///tao su kien cho luoi
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;
            e.Layout.Override.CellClickAction = CellClickAction.CellSelect;

            foreach (UltraGridColumn col in this.grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Diễn Giải";
            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["NgayHoanTat"].Header.Caption = "Ngày Hoàn Tất";
            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["MaBoPhanDen"].Header.Caption = "Mã Bộ Phận";
            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["MaCongViec"].Header.Caption = "Công Việc";

            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["MaBoPhanDen"].EditorComponent = cmbu_BoPhanDen;
            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["MaCongViec"].EditorComponent = cmbu_CongViec;

            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["MaBoPhanDen"].Header.VisiblePosition = 0;
            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["MaCongViec"].Header.VisiblePosition = 1;

            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Width = 150;
            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 200;
            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["MaBoPhanDen"].Width = 140;
            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["MaCongViec"].Width = 200;
            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["NgayHoanTat"].Width = 130;

            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;
            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["NgayHoanTat"].Hidden = false;
            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["MaBoPhanDen"].Hidden = false;
            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["MaCongViec"].Hidden = false;

            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Format = "#,###";
            grdu_ChiTietPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].PromptChar = ' ';

        }

        private void cmbu_GiayXacNhan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_GiayXacNhan, "TenGiayXacNhan");
            foreach (UltraGridColumn col in this.cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Hidden = false;
            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;

            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Header.Caption = "Tên Giấy Xác Nhận";
            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Width = 200;

            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";

            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Header.VisiblePosition = 0;
            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 1;
            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 2;


            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###,###";
            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

        }

        private void cmbu_ChuongTrinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            // FilterCombo f = new FilterCombo(cmbu_ChuongTrinh, "TenChuongTrinh");
            foreach (UltraGridColumn col in this.cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
            }
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Hidden = false;

            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = cmbu_ChuongTrinh.Width;

            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.Caption = "Tên Nguồn";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Header.Caption = "Mã QL";

            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 0;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Header.VisiblePosition = 1;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.VisiblePosition = 2;
        }

        private void cmbu_BoPhanDi_InitializeLayout(object sender, InitializeLayoutEventArgs e)
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
            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;

            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";

            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 1;
            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 0;

            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cmbu_BoPhan.Width;
        }

        private void cmbu_CongViec_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_CongViec, "TenCongViec");
            foreach (UltraGridColumn col in this.cmbu_CongViec.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_CongViec.DisplayLayout.Bands[0].Columns["TenCongViec"].Hidden = false;
            cmbu_CongViec.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;

            cmbu_CongViec.DisplayLayout.Bands[0].Columns["TenCongViec"].Header.Caption = "Tên Công Việc";
            cmbu_CongViec.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Công Việc";

            cmbu_CongViec.DisplayLayout.Bands[0].Columns["TenCongViec"].Width = cmbu_CongViec.Width;

            cmbu_CongViec.DisplayLayout.Bands[0].Columns["TenCongViec"].Header.VisiblePosition = 0;
            cmbu_CongViec.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
        }

        private void cmbu_BoPhanDen_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_BoPhanDen, "TenBoPhan");
            foreach (UltraGridColumn col in this.cmbu_BoPhanDen.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_BoPhanDen.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbu_BoPhanDen.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;

            cmbu_BoPhanDen.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cmbu_BoPhanDen.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";

            cmbu_BoPhanDen.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
            cmbu_BoPhanDen.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;

            cmbu_BoPhanDen.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cmbu_BoPhanDen.Width;
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

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            DialogResult _DialogResult = MessageBox.Show("Bạn thật sự muốn thoát không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (_DialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void cmbu_GiayXacNhan_AfterCloseUp(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbu_GiayXacNhan.Value) == 0)
            {
                return;
            }
            else
            {
                int maGiayXacNhan = Convert.ToInt32(cmbu_GiayXacNhan.Value);
                _giayXacNhan = GiayXacNhanTongHop.GetGiayXacNhanTongHop(maGiayXacNhan, maBoPhanDen);

                if (_giayXacNhan != null)
                {
                    _chuongTrinh = ChuongTrinh.GetChuongTrinh(_giayXacNhan.MaChuongTrinh);
                    cmbu_ChuongTrinh.Value = _chuongTrinh.MaChuongTrinh;
                    ChuongTrinh_BindingSource.DataSource = _chuongTrinh;

                    // cai dat gia tri cho phan bo thu lao
                    _phanBoThuLao.SoTien = Convert.ToDecimal(_giayXacNhan.SoTien);
                    _phanBoThuLao.MaGiayXacNhanChuongTrinh = _giayXacNhan.MaGiayXacNhan;
                    _phanBoThuLao.MaChiTietGiayXacNhan = ChiTietGiayXacNhan.GetChiTietGiayXacNhanByGiayXacNhan_BoPhan(_giayXacNhan.MaGiayXacNhan, maBoPhanDen).MaChiTietGiayXacNhan;
                    _phanBoThuLao.MaChuongTrinhQL = _chuongTrinh.MaQL;
                    _boPhan = BoPhan.GetBoPhan(maBoPhanDen);
                    cmbu_BoPhan.Value = _boPhan.MaBoPhan;
                    BoPhanDi_BindingSource.DataSource = _boPhan;
                    _phanBoThuLao.MaChuongTrinh = _chuongTrinh.MaChuongTrinh;
                    _phanBoThuLao.MaBoPhanDi = _boPhan.MaBoPhan;
                    cbSoTienConLai.Value = _phanBoThuLao.SoTien - SoTienPhanBoThuLaoByGiayXacNhan(_phanBoThuLao.MaGiayXacNhanChuongTrinh, _phanBoThuLao.MaBoPhanDi);
                }
            }
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            cmbu_ChuongTrinh.Value = null;
            cmbu_BoPhan.Value = null;
            cbSoTienConLai.Value = 0;
            LoadForm();
        }

        public bool KiemTra()
        {
            Boolean kq = false;
            if (Convert.ToInt32(cmbu_GiayXacNhan.Value) == 0)
            {
                MessageBox.Show("Vui lòng chọn giấy xác nhận chương trình.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                kq = false;
            }

            else if (Convert.ToInt32(cmbu_KyTinhLuong.Value) == 0)
            {
                MessageBox.Show("Vui lòng chọn kỳ tính lương.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                kq = false;
            }

            else if ((decimal)grdu_ChiTietPhanBoThuLao.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập chi tiết phân bổ thù lao.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                kq = false;
            }

            else
                kq = true;

            return kq;
        }

        public int KiemTraMaQuanLyPhanBoThuLao(string maQuanLy)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraMaQuanLyPhanBoThuLao";
                    cm.Parameters.AddWithValue("@MaQuanLy", maQuanLy);

                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTri", SqlDbType.VarChar, 30);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();
                    gt = Convert.ToInt32(cm.Parameters["@GiaTri"].Value);
                }
            }//using
            return gt;
        }

        public int KiemTraMaQuanLyPhanBoThuLaoKhiSua(int maPhanBoThuLao, string maQuanLy)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraMaQuanLyPhanBoThuLaoKhiSua";
                    cm.Parameters.AddWithValue("@MaQuanLy", maQuanLy);
                    cm.Parameters.AddWithValue("@MaPhanBoThuLao", maPhanBoThuLao);

                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTri", SqlDbType.VarChar, 30);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();
                    gt = Convert.ToInt32(cm.Parameters["@GiaTri"].Value);
                }
            }//using
            return gt;
        }

        public decimal SoTienPhanBoThuLaoByGiayXacNhan(int maGiayXacNhan, int maBoPhan)
        {
            decimal soTienPhanBoThuLao = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraSoTienPhanBoThuLao";
                    cm.Parameters.AddWithValue("@MaGiayXacNhan", maGiayXacNhan);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@SoTienPhanBo", soTienPhanBoThuLao);
                    cm.Parameters["@SoTienPhanBo"].Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();
                    soTienPhanBoThuLao = Convert.ToDecimal(cm.Parameters["@SoTienPhanBo"].Value);
                }
            }//using
            return soTienPhanBoThuLao;

        }

        public decimal SoTienPhanBoThuLaobyMaPhanBoThuLao(int maPhanBoThuLao)
        {
            decimal soTienPhanBoThuLao = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraSoTienPhanBoThuLaoByMaPhanBoThuLao";
                    cm.Parameters.AddWithValue("@MaPhanBoThuLao", maPhanBoThuLao);
                    cm.Parameters.AddWithValue("@SoTienPhanBo", soTienPhanBoThuLao);
                    cm.Parameters["@SoTienPhanBo"].Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();
                    soTienPhanBoThuLao = Convert.ToDecimal(cm.Parameters["@SoTienPhanBo"].Value);
                }
            }//using
            return soTienPhanBoThuLao;

        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            grdu_ChiTietPhanBoThuLao.UpdateData();
            decimal tongTienTrongPhanBoChiTiet = 0;

            if (KiemTra() == true)
            {
                //KyTinhLuong _kyTinhLuong = KyTinhLuong.GetKyTinhLuong((int)cmbu_KyTinhLuong.Value);
                //if (_kyTinhLuong.KhoaSoKy2 == true)
                //{
                //    MessageBox.Show("Kỳ này đã khóa sổ, không thể cập nhật.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                for (int i = 0; i < grdu_ChiTietPhanBoThuLao.Rows.Count; i++)
                {
                    if ((int)grdu_ChiTietPhanBoThuLao.Rows[i].Cells["MaBoPhanDen"].Value == 0)
                    {
                        MessageBox.Show("Vui lòng nhập bộ phận.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if ((int)grdu_ChiTietPhanBoThuLao.Rows[i].Cells["MaCongViec"].Value == 0)
                    {
                        MessageBox.Show("Vui lòng chọn công việc.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if ((decimal)grdu_ChiTietPhanBoThuLao.Rows[i].Cells["SoTien"].Value == 0)
                    {
                        MessageBox.Show("Vui lòng nhập số tiền phân bổ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    tongTienTrongPhanBoChiTiet += Convert.ToDecimal(grdu_ChiTietPhanBoThuLao.Rows[i].Cells["SoTien"].Value);
                }

                _phanBoThuLao.NgayLap = Convert.ToDateTime(cmbu_NgayLap.Value);
                _phanBoThuLao.MaKyTinhLuong = Convert.ToInt32(cmbu_KyTinhLuong.Value);
                _phanBoThuLao.GhiChu = txt_GhiChu.Text;
                _phanBoThuLao.NguoiLap = maNguoiLap;

                foreach (ChiTietPhanBoThuLao item in _phanBoThuLao.ChiTietPhanBoThuLaoList)
                {
                    item.DuocNhapHo = true;
                    item.TenBoPhanDen = BoPhan.GetBoPhan(item.MaBoPhanDen).TenBoPhan;
                    item.TenCongViec = CongViec.GetCongViec(item.MaCongViec).TenCongViec;

                }
                _phanBoThuLaoList.Add(_phanBoThuLao);

                //// kiem tra so tien phan bo thu lao
                if (SoTienPhanBoThuLaoByGiayXacNhan(_phanBoThuLao.MaGiayXacNhanChuongTrinh, _phanBoThuLao.MaBoPhanDi) > _phanBoThuLao.SoTien)
                {
                    MessageBox.Show("Giấy xác nhận này đã phân bổ hết tiền.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_phanBoThuLao.SoTien < tongTienTrongPhanBoChiTiet)
                {
                    MessageBox.Show("Không đủ tiền phân bổ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_suaDuLieu == 0)
                {
                    if (Convert.ToDecimal(cbSoTienConLai.Value) < tongTienTrongPhanBoChiTiet)
                    {
                        MessageBox.Show("Không đủ tiền phân bổ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (KiemTraMaQuanLyPhanBoThuLao((string)txt_MaPhanBoThuLaoQL.Value) == 1)
                    {
                        MessageBox.Show("Mã phân bổ thù lao bị trùng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_MaPhanBoThuLaoQL.Focus();
                        return;
                    }
                }
                else
                {

                    if (Convert.ToDecimal(cbSoTienConLai.Value) < tongTienTrongPhanBoChiTiet - SoTienPhanBoThuLaobyMaPhanBoThuLao((int)_phanBoThuLao.MaPhanBoThuLao))
                    {
                        MessageBox.Show("Không đủ tiền phân bổ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //if (KiemTraPhanBoThuLao((int)_phanBoThuLao.MaPhanBoThuLao) == 1 && _choPhepSua == true)
                    //{
                    //    MessageBox.Show("Mã này đã phân bổ. Chỉ được sửa số tiền hoặc ngày hoàn tất.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}

                    if (KiemTraMaQuanLyPhanBoThuLaoKhiSua((int)_phanBoThuLao.MaPhanBoThuLao, (string)txt_MaPhanBoThuLaoQL.Value) == 0)
                    {
                        if (KiemTraMaQuanLyPhanBoThuLao((string)txt_MaPhanBoThuLaoQL.Value) == 1)
                        {
                            MessageBox.Show("Mã phân bổ thù lao bị trùng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txt_MaPhanBoThuLaoQL.Focus();
                            return;
                        }
                    }
                }
                ///Luu du lieu   
                _phanBoThuLaoList.ApplyEdit();
                _phanBoThuLaoList.Save();
                MessageBox.Show("Cập nhật thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cbSoTienConLai.Value = _phanBoThuLao.SoTien - SoTienPhanBoThuLaoByGiayXacNhan(_phanBoThuLao.MaGiayXacNhanChuongTrinh, _phanBoThuLao.MaBoPhanDi);
                _suaDuLieu = 1;
                _choPhepSua = true;
            }
            else
            {
                return;
            }
        }

        public int KiemTraChiTietPhanBoThuLao(long maChiTietPhanBoThuLao)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraPhanBoThuLaoByMaChiTietPhanBoThuLao";
                    cm.Parameters.AddWithValue("@MaChiTietPhanBoThuLao", maChiTietPhanBoThuLao);
                    cm.Parameters.AddWithValue("@GiaTri", gt);
                    cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();
                    gt = Convert.ToInt32(cm.Parameters["@GiaTri"].Value);
                }
            }//using
            return gt;
        }
        private void tlslblXoa_Click(object sender, EventArgs e)
        {       
            if (grdu_ChiTietPhanBoThuLao.Selected.Rows.Count == 0)
            {
                MessageBox.Show("Chọn dòng cần xóa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Lấy mã chi tiết đã chọn
            ChiTietPhanBoThuLao chiTietPhanBoThuLao = ChiTietPhanBoThuLao_BindingSource.Current as ChiTietPhanBoThuLao;

            if (chiTietPhanBoThuLao == null)
                return;
            long maChiTietPhanBoThuLao = chiTietPhanBoThuLao.MaChiTietPhanBoThuLao;

            if (KiemTraChiTietPhanBoThuLao(maChiTietPhanBoThuLao) == 1)
            {
                MessageBox.Show("Mã chi tiết này đã phân bổ. Không được xóa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grdu_ChiTietPhanBoThuLao.DeleteSelectedRows();
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
                    if (iscopyok && grdu_ChiTietPhanBoThuLao.Selected != null && grdu_ChiTietPhanBoThuLao.Selected.Cells != null)
                    {
                        e.Cancel = true;
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridCell item in grdu_ChiTietPhanBoThuLao.Selected.Cells)
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
            if (grdu_ChiTietPhanBoThuLao.ActiveRow.IsFilterRow != true)
            {
                if (iskeyok && grdu_ChiTietPhanBoThuLao.ActiveCell.Row.IsDataRow)
                {
                    if (grdu_ChiTietPhanBoThuLao.ActiveCell.Column.DataType == typeof(decimal))
                        try
                        {
                            grdu_ChiTietPhanBoThuLao.ActiveCell.Value = Convert.ToDecimal(e.KeyChar.ToString());
                        }
                        catch
                        { }
                    else
                        grdu_ChiTietPhanBoThuLao.ActiveCell.Value = e.KeyChar.ToString();
                    grdu_ChiTietPhanBoThuLao.ActiveCell.SelStart = grdu_ChiTietPhanBoThuLao.ActiveCell.Text.Length;
                    e.Handled = true;
                    iskeyok = false;
                }
            }
        }
        private bool iskeyok = false;//xử lý key cho cột string
        private void grdData_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdu_ChiTietPhanBoThuLao.ActiveRow.IsFilterRow != true)
            {
                if (grdu_ChiTietPhanBoThuLao.ActiveCell != null && !grdu_ChiTietPhanBoThuLao.ActiveCell.IsInEditMode)
                {
                    if ((e.KeyData >= Keys.A && e.KeyData <= Keys.Z) || (e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9))
                    {
                        grdu_ChiTietPhanBoThuLao.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        grdu_ChiTietPhanBoThuLao.ActiveCell.SelectAll();
                        iskeyok = true;
                    }
                    if (e.KeyCode == Keys.Space && grdu_ChiTietPhanBoThuLao.ActiveCell.Column.DataType == typeof(bool))
                    {
                        grdu_ChiTietPhanBoThuLao.ActiveCell.Value = !Convert.ToBoolean(grdu_ChiTietPhanBoThuLao.ActiveCell.Value);
                    }
                }
            }
        }

        public static void In(long maPhanBoThuLao)
        {


            ReportDocument Report = new Report.GiayPhanBoThuLao();
            SqlCommand command = new SqlCommand();
            DataSet dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_ReportSelecttblnsGiayPhanBoThuLao";

            command.Parameters.AddWithValue("@MaPhanBoThuLao", maPhanBoThuLao);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_ReportSelecttblnsGiayPhanBoThuLao;1";

            dataset.Tables.Add(table);

            Report.SetDataSource(dataset);
            // Report.SetParameterValue("SoTienChu", soTien);
            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }
        private void tlslblIn_Click(object sender, EventArgs e)
        {
            In(((PhanBoThuLao)PhanBoThuLao_BindingSource.Current).MaPhanBoThuLao);
        }

        private void grdu_ChiTietPhanBoThuLao_AfterCellUpdate(object sender, CellEventArgs e)
        {
            //if (e.Cell.Column.ToString() == "SoTien" || e.Cell.Column.ToString() == "NgayHoanTat")
            //{
            //    _choPhepSua = false;
            //}
            //else
            //{
            //    _choPhepSua = true;
            //}
        }
    }
}
