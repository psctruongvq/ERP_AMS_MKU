using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Runtime.InteropServices;

namespace PSC_ERP
{
    public partial class frmDanhSachHoaDonDichVu : Form
    {
        long MaDangNhap = ERP_Library.Security.CurrentUser.Info.UserID;
        public bool IsSave = false;
        public HoaDonList _HoaDonList = HoaDonList.NewHoaDonList();
        public ChungTu_HoaDonList ct_hdList = ChungTu_HoaDonList.NewChungTu_HoaDonList();
        public decimal TongTien = 0;
        public decimal TongTienThue = 0;
        public Decimal TongTienChungTu = 0;
        decimal _tongtienthue = 0;
        decimal _tongtienhoadon = 0;
        public ButToan _bt;
        ChungTu _ct = ChungTu.NewChungTu();
        ChungTu_HoaDonList _chungTu_HoaDonList;

        private bool _isThueBanQuyen = false;
        public bool Luu = false;
        private bool _isSupportE = false;
        #region Load
        public frmDanhSachHoaDonDichVu()
        {
            InitializeComponent();
            DSHoaDonDichVu_BindingSource.DataSource = typeof(HoaDonList);
            this.bdCT_HoaDon.DataSource = typeof(ChungTu_HoaDonList);
        }
        public frmDanhSachHoaDonDichVu(ChungTu ct, ButToan bt) // true no false co
        {
            InitializeComponent();
            _ct = ct;
            _bt = bt;
            if (_bt.MaButToan != 0)
            {
                tbSoChungTu.Text = _ct.SoChungTu;
                this.cbSoTien.Value = bt.SoTien;
                //TongTienChungTu = bt.SoTien;

                foreach (ButToan btc in _ct.DinhKhoan.ButToan)
                {
                    if (btc.SoHieuTKNo.Contains("3113") || btc.SoHieuTKCo.Contains("3113"))
                    {
                        TongTienChungTu += btc.SoTien;
                    }

                }

                // phan nay gan cho but toan
                if (!_ct.DinhKhoan.LaMotNoNhieuCo)
                    txt_taikhoan.Text = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_bt.NoTaiKhoan).SoHieuTK;
                else
                    txt_taikhoan.Text = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_bt.CoTaiKhoan).SoHieuTK;

                // chi lay nhung hoa don cua nguoi lap chung tu
                _HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu_NguoiLap(ct.DoiTuong, 0, false, _ct.MaChungTu, _bt.MaButToan, ERP_Library.Security.CurrentUser.Info.UserID);
                DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
                bdCT_HoaDon.DataSource = _bt.ChungTu_HoaDonList;


                for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
                {
                    grdu_DSHoaDon.Rows[i].Cells["Chon"].Value = true;
                }
                if (bt.ChungTu_HoaDonList.Count != 0)
                    tlslblThem.Enabled = true;
                else
                    tlslblThem.Enabled = false;
            }

        }

        public frmDanhSachHoaDonDichVu(ChungTu ct, ButToan bt,bool support) // true no false co
        {
            InitializeComponent();
            tlslblThem.Visible = false;
            toolStripButton1.Visible = false;
            _isSupportE = support;
            _ct = ct;
            _bt = bt;
            if (_bt.MaButToan != 0)
            {
                tbSoChungTu.Text = _ct.SoChungTu;
                this.cbSoTien.Value = bt.SoTien;
                //TongTienChungTu = bt.SoTien;

                foreach (ButToan btc in _ct.DinhKhoan.ButToan)
                {
                    if (btc.SoHieuTKNo.Contains("3113"))
                    {
                        TongTienChungTu += btc.SoTien;
                    }

                }

                // phan nay gan cho but toan
                if (!_ct.DinhKhoan.LaMotNoNhieuCo)
                    txt_taikhoan.Text = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_bt.NoTaiKhoan).SoHieuTK;
                else
                    txt_taikhoan.Text = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_bt.CoTaiKhoan).SoHieuTK;

                // chi lay nhung hoa don cua nguoi lap chung tu
                _HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu_NguoiLap(ct.DoiTuong, 0, false, _ct.MaChungTu, _bt.MaButToan, ERP_Library.Security.CurrentUser.Info.UserID);
                DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
                bdCT_HoaDon.DataSource = _bt.ChungTu_HoaDonList;


                for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
                {
                    grdu_DSHoaDon.Rows[i].Cells["Chon"].Value = true;
                }
                if (bt.ChungTu_HoaDonList.Count != 0)
                    tlslblThem.Enabled = true;
                else
                    tlslblThem.Enabled = false;
            }

        }

        #region BoSung
        public frmDanhSachHoaDonDichVu(ChungTu ct, ChungTu_HoaDonList ct_hdList, ButToan bt, bool isThueBQ) // true no false co
        {
            _isThueBanQuyen = true;
            InitializeComponent();
            _ct = ct;
            _bt = bt;
            _chungTu_HoaDonList = ct_hdList;
            tbSoChungTu.Text = _ct.SoChungTu;
            // phan nay gan cho but toan
            if (!_ct.DinhKhoan.LaMotNoNhieuCo)
                txt_taikhoan.Text = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_bt.NoTaiKhoan).SoHieuTK;
            else
                txt_taikhoan.Text = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_bt.CoTaiKhoan).SoHieuTK;
            this.cbSoTien.Value = bt.SoTien;
            _HoaDonList = HoaDonList.GetHoaDonBanQuyenListforLapChungTu(_ct.DoiTuong, 0);
            foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
            {
                HoaDon hoadon = HoaDon.GetHoaDon(ct_hd.MaHoaDon);
                if (!_HoaDonList.Contains(hoadon))
                {
                    _HoaDonList.Add(hoadon);
                }

            }
            //TongTienChungTu = bt.SoTien;
            HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.NoTaiKhoan);
            //if (tk.SoHieuTK.Contains("3113") || tk.SoHieuTK.Contains("3337"))
            //{
            TongTienChungTu = bt.SoTien;
            //txt_taikhoan.Text = tk.SoHieuTK;
            //}
            // chi lay nhung hoa don cua nguoi lap chung tu
            //_HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu_NguoiLap(0, 0, false, _ct.MaPhieuNhapXuat, _bt.MaButToan, ERP_Library.Security.CurrentUser.Info.UserID);
            DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
            bdCT_HoaDon.DataSource = _bt.ChungTu_HoaDonList;

            for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
            {
                HoaDon ct_hd = _HoaDonList[i];
                foreach (ChungTu_HoaDon ct_hd1 in _bt.ChungTu_HoaDonList)
                {
                    if (ct_hd.MaHoaDon == ct_hd1.MaHoaDon)
                    {
                        grdu_DSHoaDon.Rows[i].Cells["Chon"].Value = true;
                        break;
                    }

                }
            }
            if (bt.ChungTu_HoaDonList.Count != 0)
                tlslblThem.Enabled = true;
            else
                tlslblThem.Enabled = false;
        }
        public frmDanhSachHoaDonDichVu(ChungTu ct, ChungTu_HoaDonList ct_hdList, ButToan bt, bool isThueBQ,bool support) // true no false co
        {
            _isThueBanQuyen = true;
            InitializeComponent();
            tlslblThem.Visible = false;
            toolStripButton1.Visible = false;
            _isSupportE = support;
            _ct = ct;
            _bt = bt;
            _chungTu_HoaDonList = ct_hdList;
            tbSoChungTu.Text = _ct.SoChungTu;
            // phan nay gan cho but toan
            if (!_ct.DinhKhoan.LaMotNoNhieuCo)
                txt_taikhoan.Text = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_bt.NoTaiKhoan).SoHieuTK;
            else
                txt_taikhoan.Text = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_bt.CoTaiKhoan).SoHieuTK;
            this.cbSoTien.Value = bt.SoTien;
            _HoaDonList = HoaDonList.GetHoaDonBanQuyenListforLapChungTu(_ct.DoiTuong, 0);
            foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
            {
                HoaDon hoadon = HoaDon.GetHoaDon(ct_hd.MaHoaDon);
                if (!_HoaDonList.Contains(hoadon))
                {
                    _HoaDonList.Add(hoadon);
                }

            }
            //TongTienChungTu = bt.SoTien;
            HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.NoTaiKhoan);
            //if (tk.SoHieuTK.Contains("3113") || tk.SoHieuTK.Contains("3337"))
            //{
            TongTienChungTu = bt.SoTien;
            //txt_taikhoan.Text = tk.SoHieuTK;
            //}
            // chi lay nhung hoa don cua nguoi lap chung tu
            //_HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu_NguoiLap(0, 0, false, _ct.MaPhieuNhapXuat, _bt.MaButToan, ERP_Library.Security.CurrentUser.Info.UserID);
            DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
            bdCT_HoaDon.DataSource = _bt.ChungTu_HoaDonList;

            for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
            {
                HoaDon ct_hd = _HoaDonList[i];
                foreach (ChungTu_HoaDon ct_hd1 in _bt.ChungTu_HoaDonList)
                {
                    if (ct_hd.MaHoaDon == ct_hd1.MaHoaDon)
                    {
                        grdu_DSHoaDon.Rows[i].Cells["Chon"].Value = true;
                        break;
                    }

                }
            }
            if (bt.ChungTu_HoaDonList.Count != 0)
                tlslblThem.Enabled = true;
            else
                tlslblThem.Enabled = false;
        }
        #endregion//BoSung
        private void InitiallizeGrdDsHoaDonBanQuyen(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.grdu_DSHoaDon.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.CellAppearance.TextHAlign = HAlign.Right;
                    col.Format = "dd/MM/yyyy";
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.Format = "#,###";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
                col.CellActivation = Activation.NoEdit;
            }
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["Chon"].CellActivation = Activation.AllowEdit;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["Chon"].Hidden = false;
            //grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["Chon"].Header.Caption = "Chọn";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["Chon"].Header.VisiblePosition = 0;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 30;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["LoaiHoaDon"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["LoaiHoaDon"].Header.Caption = "Loại HĐ";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["LoaiHoaDon"].Header.VisiblePosition = 1;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["LoaiHoaDon"].EditorComponent = cbo_LoaiHoaDon;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 65;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 2;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 70;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.Caption = "Số Hóa Đơn";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.VisiblePosition = 3;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Width = 75;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].CellAppearance.TextHAlign = HAlign.Center;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoSerial"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoSerial"].Header.Caption = "Số Serial";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoSerial"].Header.VisiblePosition = 4;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Width = 55;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Header.VisiblePosition = 5;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Width = 120;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TienThue"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TienThue"].Header.Caption = "Tiền Thuế";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TienThue"].Header.VisiblePosition = 6;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TienThue"].Width = 120;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienDaThanhToan"].Hidden = true;
            // grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienDaThanhToan"].CellActivation = Activation.AllowEdit;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienDaThanhToan"].Header.Caption = "Số Tiền Đã Thanh Toán";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienDaThanhToan"].Header.VisiblePosition = 7;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienConLai"].Hidden = true;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.Caption = "Số Tiền Còn Lại";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.VisiblePosition = 8;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienConLai"].Width = 120;

            //  grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TatToan"].CellActivation = Activation.AllowEdit;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TatToan"].Hidden = true;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TatToan"].Header.Caption = "Hoàn Tất";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TatToan"].Header.VisiblePosition = 9;

            UltraGridColumn columnToSummarize2 = e.Layout.Bands[0].Columns["ThueVAT"];
            SummarySettings summary2 = grdu_DSHoaDon.DisplayLayout.Bands[0].Summaries.Add("ThueVAT", SummaryType.Sum, columnToSummarize2);
            summary2.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
            summary2.DisplayFormat = "Tổng={0:###,###,###,###,###,###}";
            summary2.Appearance.TextHAlign = HAlign.Right;
            summary2.SummaryType = SummaryType.Sum;
            summary2.SummaryPositionColumn = columnToSummarize2;

            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Top;
            e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
        }

        private void grdu_DSHoaDon_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            if (_isThueBanQuyen)
            {
                InitiallizeGrdDsHoaDonBanQuyen(sender, e);
                return;
            }
            #region HoaDonThuong
            foreach (UltraGridColumn col in this.grdu_DSHoaDon.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.CellAppearance.TextHAlign = HAlign.Right;
                    col.Format = "dd/MM/yyyy";
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.Format = "#,###";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
                col.CellActivation = Activation.NoEdit;
            }
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["Chon"].CellActivation = Activation.AllowEdit;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["Chon"].Hidden = false;
            //grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["Chon"].Header.Caption = "Chọn";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["Chon"].Header.VisiblePosition = 0;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 30;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["LoaiHoaDon"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["LoaiHoaDon"].Header.Caption = "Loại HĐ";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["LoaiHoaDon"].Header.VisiblePosition = 1;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["LoaiHoaDon"].EditorComponent = cbo_LoaiHoaDon;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 2;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 70;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.Caption = "Số Hóa Đơn";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.VisiblePosition = 3;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Width = 75;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].CellAppearance.TextHAlign = HAlign.Center;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoSerial"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoSerial"].Header.Caption = "Số Serial";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoSerial"].Header.VisiblePosition = 4;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoSerial"].Width = 55;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["MauHoaDon"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["MauHoaDon"].Header.Caption = "Mẫu Hóa Đơn";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["MauHoaDon"].Header.VisiblePosition = 5;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["MauHoaDon"].Width = 55;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["KyHieuMauHoaDon"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["KyHieuMauHoaDon"].Header.Caption = "Ký Hiệu Mẫu HĐ";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["KyHieuMauHoaDon"].Header.VisiblePosition = 6;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["KyHieuMauHoaDon"].Width = 55;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Header.VisiblePosition = 7;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Width = 120;

            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["ThueVAT"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["ThueVAT"].Header.Caption = "Tiền Thuế";
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["ThueVAT"].Header.VisiblePosition = 8;
            grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["ThueVAT"].Width = 120;

            //grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienDaThanhToan"].Hidden = true;
            //grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienDaThanhToan"].CellActivation = Activation.AllowEdit;
            //grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienDaThanhToan"].Header.Caption = "Số Tiền Đã Thanh Toán";
            //grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienDaThanhToan"].Header.VisiblePosition = 9;

            //grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienConLai"].Hidden = true;
            //grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.Caption = "Số Tiền Còn Lại";
            //grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.VisiblePosition = 10;
            //grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["SoTienConLai"].Width = 120;

            //  grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TatToan"].CellActivation = Activation.AllowEdit;
            //grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TatToan"].Hidden = true;
            //grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TatToan"].Header.Caption = "Hoàn Tất";
            //grdu_DSHoaDon.DisplayLayout.Bands[0].Columns["TatToan"].Header.VisiblePosition = 11;

            UltraGridColumn columnToSummarize2 = e.Layout.Bands[0].Columns["ThueVAT"];
            SummarySettings summary2 = grdu_DSHoaDon.DisplayLayout.Bands[0].Summaries.Add("ThueVAT", SummaryType.Sum, columnToSummarize2);
            summary2.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
            summary2.DisplayFormat = "Tổng={0:###,###,###,###,###,###}";
            summary2.Appearance.TextHAlign = HAlign.Right;
            summary2.SummaryType = SummaryType.Sum;
            summary2.SummaryPositionColumn = columnToSummarize2;

            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.Top;
            e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            #endregion//HoaDonThuong
        }

        #endregion

        #region Event
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            // kiem tra da co hoa don cho chung tu nay chua
            if (_bt.ChungTu_HoaDonList.Count != 0)
            {
                MessageBox.Show(this, "Đã có hóa đơn cho chứng từ này đề nghị xem lại dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Them())
                Save();
        }
        private void grdu_DSHoaDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdu_DSHoaDon.ActiveRow != null)
            {
                if (e.KeyCode == Keys.Space)
                {
                    if ((bool)grdu_DSHoaDon.ActiveRow.Cells["Chon"].Value)
                        grdu_DSHoaDon.ActiveRow.Cells["Chon"].Value = false;
                    else
                        grdu_DSHoaDon.ActiveRow.Cells["Chon"].Value = true;
                    grdu_DSHoaDon.Refresh();
                }
            }
        }
        private void tlshdmuavao_Click(object sender, EventArgs e)
        {
            if (_bt.MaButToan == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn bút toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmHoaDonDichVuMuaVao frmhoadondichvu = new frmHoaDonDichVuMuaVao(_ct, _bt, false);
            frmhoadondichvu.ShowDialog();
            _HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu_NguoiLap(0, 0, false, _ct.MaChungTu, _bt.MaButToan, ERP_Library.Security.CurrentUser.Info.UserID);
            DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
            for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
            {
                grdu_DSHoaDon.Rows[i].Cells["Chon"].Value = true;
            }

        }
        private void tlshdbanra_Click(object sender, EventArgs e)
        {
            if (_ct.MaChungTu == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn chứng từ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmHoaDonDichVuBanRa frmhoadondichvu = new frmHoaDonDichVuBanRa(_ct.DoiTuong, 5, _ct.NgayLap.Date);
            frmhoadondichvu.ShowDialog();


            _HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu_NguoiLap(0, 0, false, _ct.MaChungTu, _bt.MaButToan, ERP_Library.Security.CurrentUser.Info.UserID);
            DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;

            for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
            {
                grdu_DSHoaDon.Rows[i].Cells["Chon"].Value = true;
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region Process


        private bool Them()
        {
            _tongtienthue = 0;
            _tongtienhoadon = 0;
            grdu_DSHoaDon.UpdateData();
            // duyet qua cac hoa don dang co duoc chon . mac nhien la duoc chon 
            if (_ct.MaChungTu == 0)
            {
                MessageBox.Show(this, "Vui lòng lưu chứng từ trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (txt_taikhoan.Text == "")
            {
                MessageBox.Show(this, "Vui lòng lưu bút toán của chứng từ trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            ChungTu_HoaDon ct_hd;
            // kiem tra tong tien tren hoa don
            for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
            {
                if ((bool)grdu_DSHoaDon.Rows[i].Cells["Chon"].Value == true && grdu_DSHoaDon.Rows[i].IsFilterRow == false)
                {
                    long maHoaDon = (long)grdu_DSHoaDon.Rows[i].Cells["MaHoaDon"].Value;
                    if (_isThueBanQuyen)
                    {

                        _tongtienthue = _tongtienthue + (decimal)grdu_DSHoaDon.Rows[i].Cells["TienThue"].Value;
                        decimal _tienthue = (decimal)grdu_DSHoaDon.Rows[i].Cells["TienThue"].Value;
                    }
                    else
                    {
                        _tongtienthue = _tongtienthue + (decimal)grdu_DSHoaDon.Rows[i].Cells["ThueVAT"].Value;
                        decimal _tienthue = (decimal)grdu_DSHoaDon.Rows[i].Cells["ThueVAT"].Value;
                    }
                    _tongtienhoadon = _tongtienhoadon + (decimal)grdu_DSHoaDon.Rows[i].Cells["ThanhTien"].Value;
                }
            }



            // kime tra 
            if (_tongtienthue != 0)
            {
                if (_tongtienthue != TongTienChungTu)
                {
                    MessageBox.Show("Tổng tiền hóa đơn khác tổng tiền bút toán có các tài khoản 3113..", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                if (_tongtienhoadon != TongTienChungTu)
                {
                    //MessageBox.Show("Tổng tiền hóa đơn khác tổng tiền bút toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //return false;
                }
            }

            for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
            {
                bool exists = false;
                if ((bool)grdu_DSHoaDon.Rows[i].Cells["Chon"].Value == true && grdu_DSHoaDon.Rows[i].IsFilterRow == false)
                {
                    long maHoaDon = (long)grdu_DSHoaDon.Rows[i].Cells["MaHoaDon"].Value;
                    decimal _tienthue;
                    if (_isThueBanQuyen)
                    {
                        _tienthue = (decimal)grdu_DSHoaDon.Rows[i].Cells["TienThue"].Value;
                    }
                    else
                    {
                        _tienthue = (decimal)grdu_DSHoaDon.Rows[i].Cells["ThueVAT"].Value;
                    }
                    decimal _tienhoadon = (decimal)grdu_DSHoaDon.Rows[i].Cells["ThanhTien"].Value;
                    string soHoaDon = (string)grdu_DSHoaDon.Rows[i].Cells["SoHoaDon"].Value;
                    foreach (ChungTu_HoaDon ct_hd1 in _bt.ChungTu_HoaDonList)
                    {
                        if (maHoaDon == ct_hd1.MaHoaDon)//Đã tồn tại hóa đơn bên danh sách Chứng từ-hóa đơn list                                                  
                            exists = true;
                    }
                    if (exists == false)
                    {
                        ct_hd = ChungTu_HoaDon.NewChungTu_HoaDon();
                        // truong hop ho don khong thue thi xet theo tong tien hoa don
                        if (_tongtienthue != 0)
                        {
                            ct_hd.SoTien = _tongtienthue;
                            ct_hd.SoTienSeThanhToan = _tienthue;
                        }
                        else
                        {
                            ct_hd.SoTien = _tongtienhoadon;
                            ct_hd.SoTienSeThanhToan = _tienhoadon;
                        }


                        ct_hd.MaHoaDon = maHoaDon;
                        ct_hd.MaChungTu = _ct.MaChungTu;
                        ct_hd.MaButToan = _bt.MaButToan;
                        ct_hd.SoHoaDon = soHoaDon;
                        _bt.ChungTu_HoaDonList.Add(ct_hd);
                    }
                }
            }
            this.bdCT_HoaDon.DataSource = _bt.ChungTu_HoaDonList;
            return true;
        }
        private void Save()
        {
            //decimal _soTienDaThanhToan = 0;
            //foreach (ChungTu_HoaDon ct_Hd in _bt.ChungTu_HoaDonList)
            //{
            //    decimal _tienDaThanhToanHoaDon = 0;
            //    if (ChungTu_HoaDonList.GetChungTu_HoaDonListByMaChungTu_HoaDon(ct_Hd.MaChungTu, ct_Hd.MaHoaDon).Count > 1)
            //    {
            //        _tienDaThanhToanHoaDon = ChungTu_HoaDonList.GetChungTu_HoaDonListByMaChungTu_HoaDon(ct_Hd.MaChungTu, ct_Hd.MaHoaDon)[0].SoTienDaThanhToan;
            //    }
            //    if (ct_Hd.IsNew == true)
            //        _soTienDaThanhToan += ct_Hd.SoTienSeThanhToan;
            //    else ////
            //        _soTienDaThanhToan += _tienDaThanhToanHoaDon + ct_Hd.SoTienSeThanhToan;
            //}
            // truong hop tong tien thue bang khong thi xet theo dk 


            //try
            //{
            //    _bt.ChungTu_HoaDonList._Update();
            //    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    Luu = true;
            //    this.Close();
            //}
            //catch (Exception ex)
            //{ MessageBox.Show(ex.ToString()); }

            if (_isSupportE)
            {
                try
                {
                    Luu = true;
                    this.Close();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.ToString()); }
            }
            else
            {
                try
                {
                    _bt.ChungTu_HoaDonList._Update();
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Luu = true;
                    this.Close();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.ToString()); }
            }

        }
        #endregion

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            frmDanhSachHoaDonDichVu_DadinhKem frm = new frmDanhSachHoaDonDichVu_DadinhKem(_ct, _bt);
            frm.ShowDialog();

            _HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu_NguoiLap(0, 0, false, _ct.MaChungTu, _bt.MaButToan, ERP_Library.Security.CurrentUser.Info.UserID);
            DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
            for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
            {
                grdu_DSHoaDon.Rows[i].Cells["Chon"].Value = true;
            }

        }

        private void hóaĐơnMuaVàoKhôngCóVATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_bt.MaButToan == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn bút toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmHoaDonDichVuMuaVao frmhoadondichvu = new frmHoaDonDichVuMuaVao(_ct, _bt, true);
            frmhoadondichvu.ShowDialog();

            _HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu_NguoiLap(0, 0, false, _ct.MaChungTu, _bt.MaButToan, ERP_Library.Security.CurrentUser.Info.UserID);
            DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
            for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
            {
                grdu_DSHoaDon.Rows[i].Cells["Chon"].Value = true;
            }

        }


        private void grdu_DSHoaDon_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (grdu_DSHoaDon.ActiveRow != null && grdu_DSHoaDon.ActiveRow.IsFilterRow == false)
            {
                HoaDon _HoaDon = HoaDon.NewHoaDon();
                _HoaDon = HoaDon.GetHoaDon((long)grdu_DSHoaDon.ActiveRow.Cells["MaHoaDon"].Value);
                if ((int)grdu_DSHoaDon.ActiveRow.Cells["LoaiHoaDon"].Value == 4) // mua vao 
                {
                    frmHoaDonDichVuMuaVao _frmHoaDonDichVu = new frmHoaDonDichVuMuaVao(_ct, _HoaDon);
                    _frmHoaDonDichVu.ShowDialog();
                }
                else if ((int)grdu_DSHoaDon.ActiveRow.Cells["LoaiHoaDon"].Value == 30) // mua vao 
                {
                    frmHoaDonMuaBanQuyen _frmHoaDonDichVu = new frmHoaDonMuaBanQuyen(_ct, _HoaDon);
                    _frmHoaDonDichVu.ShowDialog();
                }
                else // ban ra
                {
                    frmHoaDonDichVuBanRa _frmHoaDonDichVu = new frmHoaDonDichVuBanRa(_HoaDon);
                    _frmHoaDonDichVu.ShowDialog();
                }
            }
            if (_isThueBanQuyen)
            {
                _HoaDonList = HoaDonList.GetHoaDonBanQuyenListforLapChungTu(_ct.DoiTuong, 0);
            }
            else
                _HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu_NguoiLap(0, 0, false, _ct.MaChungTu, _bt.MaButToan, ERP_Library.Security.CurrentUser.Info.UserID);
            DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
            for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
            {
                grdu_DSHoaDon.Rows[i].Cells["Chon"].Value = true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa các hóa đơn được chon ra khỏi hệ thổng không ?", "Xóa hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (grdu_DSHoaDon.Selected.Rows.Count == 0)
                {
                    MessageBox.Show(this, "Chọn Dòng cần xóa", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                grdu_DSHoaDon.DeleteSelectedRows();

                _HoaDonList.Save();
                if (_isThueBanQuyen)
                {
                    _HoaDonList = HoaDonList.GetHoaDonBanQuyenListforLapChungTu(_ct.DoiTuong, 0);
                }
                else
                    _HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu_NguoiLap(0, 0, false, _ct.MaChungTu, _bt.MaButToan, ERP_Library.Security.CurrentUser.Info.UserID);
                DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;

            }

        }

        private void hóaĐơnBảnQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (_bt.MaButToan == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn bút toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmHoaDonMuaBanQuyen frmhoadondichvu = new frmHoaDonMuaBanQuyen(_ct.DoiTuong, DateTime.Today, false);
            frmhoadondichvu.ShowDialog();
            _HoaDonList = HoaDonList.GetHoaDonBanQuyenListforLapChungTu(_ct.DoiTuong, 0);
            DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
            for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
            {
                grdu_DSHoaDon.Rows[i].Cells["Chon"].Value = true;
            }
        }
    }
}