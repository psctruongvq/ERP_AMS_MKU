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
namespace PSC_ERP
{
    public partial class frmDSHoaDonDichVu : Form
    {
        #region properties
        HoaDonList _HoaDonList;
        HamDungChung hamDungChung = new HamDungChung();
        Util util = new Util();
        int _loai = 0;
        byte _loaiHoaDon;

        DateTime _tuNgay = DateTime.Today.Month > 6 ? new DateTime(DateTime.Today.Year, 7, 1) : new DateTime(DateTime.Today.Year - 1, 7, 1);
        DateTime _denNgay = DateTime.Today.Month > 6 ? new DateTime(DateTime.Today.Year + 1, 6, 30) : new DateTime(DateTime.Today.Year, 6, 30);

        #endregion

        #region Contructor
        public frmDSHoaDonDichVu()
        {
            InitializeComponent();
        }

        public frmDSHoaDonDichVu(byte loaiHD)
        {
            InitializeComponent();
            KhoiTao(loaiHD);
        }
        public void ShowHoaDonMuaHangDichVu()
        {
            dtmp_TuNgay.Value = _tuNgay;
            dtmp_DenNgay.Value = _denNgay;
            this.Text = "Danh Sách Hóa Đơn Mua Hàng Dịch Vụ";
            _loaiHoaDon = (byte)LoaiHoaDonEnum.HoaDonMuaHangDichVu;
            KhoiTao(_loaiHoaDon);
            this.Show();
        }
        public void ShowHoaDonBanHangDichVu()
        {
            this.Text = "Danh Sách Hóa Đơn Bán Hàng Dịch Vụ";
            _loaiHoaDon = (byte)LoaiHoaDonEnum.HoaDonBanHangDichVu;
            KhoiTao(_loaiHoaDon);
            this.Show();
        }
        public void ShowHoaDonMuaBanQuyen()
        {
            KhoiTao(30);
            this.Show();
        }

        #endregion

        #region KhoiTao
        public void KhoiTao()
        {
            _HoaDonList = HoaDonList.GetHoaDonListByLoaiNgayLap(Convert.ToByte(cmbu_LoaiHD.Value), Convert.ToDateTime(dtmp_TuNgay.Value), Convert.ToDateTime(dtmp_DenNgay.Value));
            hoaDonListBindingSource.DataSource = _HoaDonList;
        }

        public void KhoiTao(byte loaiHD)
        {
            cmbu_LoaiHD.Value = loaiHD;
            _HoaDonList = HoaDonList.GetHoaDonListByLoaiNgayLap(loaiHD, Convert.ToDateTime(dtmp_TuNgay.Value), Convert.ToDateTime(dtmp_DenNgay.Value));
            hoaDonListBindingSource.DataSource = _HoaDonList;
            cmbu_LoaiHD.ReadOnly = true;
        }

        #endregion

        #region LayHoaDon
        public void LayHoaDon(byte loai, DateTime tuNgay, DateTime denNgay)
        {
            _HoaDonList = HoaDonList.GetHoaDonListByLoaiNgayLap(loai, tuNgay, denNgay);
            if (_HoaDonList.Count == 0)
            {
                hoaDonListBindingSource.DataSource = HoaDonList.NewHoaDonList();
                MessageBox.Show(this, util.khongcodulieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                hoaDonListBindingSource.DataSource = _HoaDonList;
            }
        }
        #endregion

        #region grdu_DSHoaDonDichVu_InitializeLayout
        private void grdu_DSHoaDonDichVu_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.grdu_DSHoaDonDichVu.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DSHoaDonDichVu.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_DSHoaDonDichVu.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoSerial"].Hidden = false;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoSerial"].Header.Caption = "Số Serial";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoSerial"].CellActivation = Activation.NoEdit;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoSerial"].Header.VisiblePosition = 4;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoSerial"].Width = 70;

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoHoaDon"].Hidden = false;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoHoaDon"].Header.Caption = "Số Hóa Đơn";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoHoaDon"].CellActivation = Activation.NoEdit;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoHoaDon"].Header.VisiblePosition = 3;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoHoaDon"].Width = 100;

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["TongTien"].Hidden = false;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["TongTien"].CellActivation = Activation.NoEdit;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["TongTien"].Header.VisiblePosition = 6;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["TongTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["TongTien"].Format = "###,###,###,###,###";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["TongTien"].CellAppearance.TextHAlign = HAlign.Right;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["TongTien"].Width = 120;

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["NgayLap"].Hidden = false;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["NgayLap"].Header.Caption = "Ngày Hóa Đơn";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["NgayLap"].CellActivation = Activation.NoEdit;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["NgayLap"].Header.VisiblePosition = 2;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["NgayLap"].Width = 90;

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["TenDoiTac"].Header.Caption = "Tên Đối Tác";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["TenDoiTac"].CellActivation = Activation.NoEdit;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["TenDoiTac"].Header.VisiblePosition = 23;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["TenDoiTac"].Hidden = false;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["TenDoiTac"].Width = 300;

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["MaQLDoiTac"].Header.Caption = "Mã Đối Tác";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["MaQLDoiTac"].CellActivation = Activation.NoEdit;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["MaQLDoiTac"].Header.VisiblePosition = 24;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["MaQLDoiTac"].Hidden = false;

            //grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["CMND"].Header.Caption = "Số CMND";
            //grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["CMND"].CellActivation = Activation.NoEdit;
            //grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["CMND"].Header.VisiblePosition = 10;
            //grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["CMND"].Hidden = true;

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoChungTu"].Header.Caption = "Số chứng từ";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoChungTu"].CellActivation = Activation.NoEdit;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoChungTu"].Header.VisiblePosition = 1;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoChungTu"].Hidden = false;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoChungTu"].Width = 100;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoChungTu"].CellAppearance.ForeColor = Color.Blue;

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["NgayLapCT"].Header.Caption = "Ngày Ghi Sổ";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["NgayLapCT"].CellActivation = Activation.NoEdit;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["NgayLapCT"].Format = "dd/MM/yyyy";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["NgayLapCT"].Header.VisiblePosition = 0;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["NgayLapCT"].Hidden = false;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["NgayLapCT"].Width = 90;

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["GhiChu"].Header.Caption = "Diễn giải";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["GhiChu"].CellActivation = Activation.NoEdit;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["GhiChu"].Header.VisiblePosition = 20;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["GhiChu"].Hidden = false;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["GhiChu"].Width = 150;

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoChungTu_ThanhToan"].Header.Caption = "Số c.từ thanh toán";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoChungTu_ThanhToan"].CellActivation = Activation.NoEdit;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoChungTu_ThanhToan"].Header.VisiblePosition = 21;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoChungTu_ThanhToan"].Hidden = false;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoChungTu_ThanhToan"].Width = 110;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoChungTu_ThanhToan"].CellAppearance.ForeColor = Color.Blue;

            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoTienThanhToan"].Hidden = false;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoTienThanhToan"].Header.Caption = "Tiền thanh toán";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoTienThanhToan"].CellActivation = Activation.NoEdit;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoTienThanhToan"].Header.VisiblePosition = 22;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoTienThanhToan"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoTienThanhToan"].Format = "###,###,###,###,###";
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoTienThanhToan"].CellAppearance.TextHAlign = HAlign.Right;
            grdu_DSHoaDonDichVu.DisplayLayout.Bands["HoaDon"].Columns["SoTienThanhToan"].Width = 120;

            this.grdu_DSHoaDonDichVu.DisplayLayout.Bands[1].Hidden = true;
            this.grdu_DSHoaDonDichVu.DisplayLayout.Bands[2].Hidden = true;
            this.grdu_DSHoaDonDichVu.DisplayLayout.Bands[3].Hidden = true;
            this.grdu_DSHoaDonDichVu.DisplayLayout.Bands[4].Hidden = true;
            this.grdu_DSHoaDonDichVu.DisplayLayout.Bands[5].Hidden = true;
            //this.grdu_DSHoaDonDichVu.DisplayLayout.Override.ColumnSizingArea = ColumnSizingArea.EntireColumn;

            /*
                        //Ct hóa đơn dịch vụ
                        foreach (UltraGridColumn col in this.grdu_DSHoaDonDichVu.DisplayLayout.Bands[1].Columns)
                        {
                            col.Hidden = true;
                            col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                            col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                        }

                        grdu_DSHoaDonDichVu.DisplayLayout.Bands["CT_HoaDonDichVuList"].Columns["MaChiTiet"].Hidden = true;            
                        grdu_DSHoaDonDichVu.DisplayLayout.Bands["CT_HoaDonDichVuList"].Columns["MaHoaDon"].Hidden = true;
                        grdu_DSHoaDonDichVu.DisplayLayout.Bands["CT_HoaDonDichVuList"].Columns["MaDonViTinh"].Hidden = true;

                        grdu_DSHoaDonDichVu.DisplayLayout.Bands["CT_HoaDonDichVuList"].Columns["TenHangHoaDichVu"].Hidden = false;
                        grdu_DSHoaDonDichVu.DisplayLayout.Bands["CT_HoaDonDichVuList"].Columns["TenHangHoaDichVu"].Header.Caption = "Tên Hàng Hóa Dịch Vụ";
                        grdu_DSHoaDonDichVu.DisplayLayout.Bands["CT_HoaDonDichVuList"].Columns["TenHangHoaDichVu"].Width = 150;
                        grdu_DSHoaDonDichVu.DisplayLayout.Bands["CT_HoaDonDichVuList"].Columns["TenHangHoaDichVu"].Header.VisiblePosition = 0;

                        grdu_DSHoaDonDichVu.DisplayLayout.Bands["CT_HoaDonDichVuList"].Columns["SoLuong"].Header.Caption = "Số Lượng";
                        grdu_DSHoaDonDichVu.DisplayLayout.Bands["CT_HoaDonDichVuList"].Columns["SoLuong"].Header.VisiblePosition = 1;
                        grdu_DSHoaDonDichVu.DisplayLayout.Bands["CT_HoaDonDichVuList"].Columns["SoLuong"].Hidden = false;

                        grdu_DSHoaDonDichVu.DisplayLayout.Bands["CT_HoaDonDichVuList"].Columns["DonGia"].Header.Caption = "Đơn Giá";
                        grdu_DSHoaDonDichVu.DisplayLayout.Bands["CT_HoaDonDichVuList"].Columns["DonGia"].Header.VisiblePosition = 2;
                        grdu_DSHoaDonDichVu.DisplayLayout.Bands["CT_HoaDonDichVuList"].Columns["DonGia"].Hidden = false;

                        grdu_DSHoaDonDichVu.DisplayLayout.Bands["CT_HoaDonDichVuList"].Columns["ThanhTien"].Header.Caption = "Thành Tiền";
                        grdu_DSHoaDonDichVu.DisplayLayout.Bands["CT_HoaDonDichVuList"].Columns["ThanhTien"].Header.VisiblePosition = 3;
                        grdu_DSHoaDonDichVu.DisplayLayout.Bands["CT_HoaDonDichVuList"].Columns["ThanhTien"].Hidden = false;
            */
        }
        #endregion

        #region tlslblTim_Click
        private void tlslblTim_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtmp_TuNgay.Value) > Convert.ToDateTime(dtmp_DenNgay.Value))
            {
                MessageBox.Show(this, util.ngaycantimkhonghople, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtmp_TuNgay.Focus();
            }
            else
            {
                LayHoaDon(Convert.ToByte(cmbu_LoaiHD.Value), Convert.ToDateTime(dtmp_TuNgay.Value), Convert.ToDateTime(dtmp_DenNgay.Value));
            }
        }
        #endregion

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {

            this.Close();

        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                _HoaDonList.ApplyEdit();
                _HoaDonList.Save();
                MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, util.thatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                string tem = ex.Message;
            }
        }
        #endregion

        #region grdu_DSHoaDonDichVu_DoubleClick
        private void grdu_DSHoaDonDichVu_DoubleClick(object sender, EventArgs e)
        {

        }
        #endregion



        #region cmbu_LoaiHD_AfterCloseUp
        private void cmbu_LoaiHD_AfterCloseUp(object sender, EventArgs e)
        {
            if (cmbu_LoaiHD.Value != null)
            {
                _loai = Convert.ToInt32(cmbu_LoaiHD.Value);
            }
        }
        #endregion

        private void frmDSHoaDonDichVu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Danh Sach Cac Loai Hoa Don", "HelpCamDo.chm");
            }
        }

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            Main.frmMain.LoadHelp(this, "Danh Sach Cac Loai Hoa Don", "HelpCamDo.chm");
        }

        private void grdu_DSHoaDonDichVu_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (_isShowChungTu == true)
            {
                _isShowChungTu = false;
                return;
            }
            HoaDon _HoaDon = HoaDon.NewHoaDon();
            _HoaDon = HoaDon.GetHoaDon((long)grdu_DSHoaDonDichVu.ActiveRow.Cells["MaHoaDon"].Value);
            if ((int)grdu_DSHoaDonDichVu.ActiveRow.Cells["LoaiHoaDon"].Value == 4)
            {
                frmHoaDonDichVuMuaVao _frmHoaDonDichVu = new frmHoaDonDichVuMuaVao(_HoaDon);
                _frmHoaDonDichVu.WindowState = FormWindowState.Maximized;
                _frmHoaDonDichVu.Show();
            }
            else if ((int)grdu_DSHoaDonDichVu.ActiveRow.Cells["LoaiHoaDon"].Value == 5)
            {
                frmHoaDonDichVuBanRa _frmHoaDonDichVu = new frmHoaDonDichVuBanRa(_HoaDon);
                _frmHoaDonDichVu.WindowState = FormWindowState.Maximized;
                _frmHoaDonDichVu.Show();
            }
            else if ((int)grdu_DSHoaDonDichVu.ActiveRow.Cells["LoaiHoaDon"].Value == 30)
            {
                frmHoaDonMuaBanQuyen _frmHoaDonDichVu = new frmHoaDonMuaBanQuyen(_HoaDon);
                _frmHoaDonDichVu.WindowState = FormWindowState.Maximized;
                _frmHoaDonDichVu.Show();
            }
           
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            if (_loaiHoaDon == (byte)LoaiHoaDonEnum.HoaDonMuaHangDichVu)
            {
                frmHoaDonDichVuMuaVao frm = new frmHoaDonDichVuMuaVao();
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    tlslblTim.PerformClick();
                }
            }
            else if (_loaiHoaDon == (byte)LoaiHoaDonEnum.HoaDonBanHangDichVu)
            {
                frmHoaDonDichVuBanRa frm = new frmHoaDonDichVuBanRa();
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    tlslblTim.PerformClick();
                }
            }
        }

        private void grdu_DSHoaDonDichVu_ClickCell(object sender, ClickCellEventArgs e)
        {
            
        }

        bool _isShowChungTu = false;
        private void grdu_DSHoaDonDichVu_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            HoaDon _HoaDon = HoaDon.NewHoaDon();
            //_HoaDon = HoaDon.GetHoaDon((long)grdu_DSHoaDonDichVu.ActiveRow.Cells["MaHoaDon"].Value);
            _HoaDon = (HoaDon)hoaDonListBindingSource.Current;
            long maChungTu = 0;
            int maLoaiChungTu = 0;
            if (e.Cell.Column.Key == "SoChungTu")
            {
                maChungTu = _HoaDon.MaChungTu_CongNo;
                maLoaiChungTu = _HoaDon.MaLoaiChungTu_CongNo;
                _isShowChungTu = true;
            }
            else if (e.Cell.Column.Key == "SoChungTu_ThanhToan")
            {
                maChungTu = _HoaDon.MaChungTu_ThanhToan;
                maLoaiChungTu = _HoaDon.MaLoaiChungTu_ThanhToan;
                _isShowChungTu = true;
            }

            if (maChungTu > 0)
            {
                switch (maLoaiChungTu)
                {
                    case 2:
                        //PSC_ERP.FrmChungTuThuTienMat frm = new PSC_ERP.FrmChungTuThuTienMat(maChungTu,isShowFromReport);
                        PSC_ERP.FrmChungTuThuTienMat frm = new PSC_ERP.FrmChungTuThuTienMat(maChungTu);
                        //frm.maChungTuOfReport = maChungTu;
                        //frm.isShowFromReport = isShowFromReport;
                        frm.WindowState = FormWindowState.Maximized;
                        frm.ShowDialog();
                        break;

                    case 3:
                        PSC_ERP.FrmChungTuChiTienMat frm3 = new PSC_ERP.FrmChungTuChiTienMat(maChungTu);
                        frm3.WindowState = FormWindowState.Maximized;
                        frm3.ShowDialog();
                        break;

                    case 4:
                        PSC_ERP.frmPhieuNhapVatTuHangHoa_New frm4 = new PSC_ERP.frmPhieuNhapVatTuHangHoa_New(maChungTu);
                        frm4.WindowState = FormWindowState.Maximized;
                        frm4.ShowDialog();
                        break;

                    case 5:
                        PSC_ERP.FrmPhieuXuatVatTuHangHoa_New frm5 = new PSC_ERP.FrmPhieuXuatVatTuHangHoa_New(maChungTu, 1);
                        frm5.WindowState = FormWindowState.Maximized;
                        frm5.ShowDialog();
                        break;

                    case 6:
                        PSC_ERP.FrmChungTuThuTienGui frm6 = new PSC_ERP.FrmChungTuThuTienGui(maChungTu);
                        frm6.WindowState = FormWindowState.Maximized;
                        frm6.ShowDialog();
                        break;

                    case 7:
                        PSC_ERP.FrmChungTuChiTienGui frm7 = new PSC_ERP.FrmChungTuChiTienGui(maChungTu);
                        frm7.WindowState = FormWindowState.Maximized;
                        frm7.ShowDialog();
                        break;

                    case 8:
                        PSC_ERP.FrmChungTuKetChuyenXacDinhKQHDKD frm8 = new PSC_ERP.FrmChungTuKetChuyenXacDinhKQHDKD(maChungTu);
                        frm8.WindowState = FormWindowState.Maximized;
                        frm8.ShowDialog();
                        break;

                    case 9:
                        PSC_ERP.FrmChungTuMuaChuaThanhToan frm9 = new PSC_ERP.FrmChungTuMuaChuaThanhToan(maChungTu);
                        frm9.WindowState = FormWindowState.Maximized;
                        frm9.ShowDialog();
                        break;

                    case 10:
                        PSC_ERP.FrmChungTuGiayNhanNo frm10 = new PSC_ERP.FrmChungTuGiayNhanNo(maChungTu);
                        frm10.WindowState = FormWindowState.Maximized;
                        frm10.ShowDialog();
                        break;

                    case 14:
                        PSC_ERP.FrmChungTuChuyenTienNoiBo frm14 = new PSC_ERP.FrmChungTuChuyenTienNoiBo(maChungTu);
                        frm14.WindowState = FormWindowState.Maximized;
                        frm14.ShowDialog();
                        break;

                    case 16:
                        PSC_ERP.FrmChungTuKeToanCustomize frm16 = new PSC_ERP.FrmChungTuKeToanCustomize(maChungTu);
                        frm16.WindowState = FormWindowState.Maximized;
                        frm16.ShowDialog();
                        break;

                    case 22:
                        PSC_ERP.FrmChungTuPhiNganHang frm22 = new PSC_ERP.FrmChungTuPhiNganHang(maChungTu);
                        frm22.WindowState = FormWindowState.Maximized;
                        frm22.ShowDialog();
                        break;

                    case 23:
                        PSC_ERP.FrmChungTuMuaNgoaiTe frm23 = new PSC_ERP.FrmChungTuMuaNgoaiTe(maChungTu);
                        frm23.WindowState = FormWindowState.Maximized;
                        frm23.ShowDialog();
                        break;

                    case 24:
                        PSC_ERP.FrmChungTuLenhChuyenTienNuocNgoai frm24 = new PSC_ERP.FrmChungTuLenhChuyenTienNuocNgoai(maChungTu);
                        frm24.WindowState = FormWindowState.Maximized;
                        frm24.ShowDialog();
                        break;

                    case 25:
                        PSC_ERP.FrmChungTuGiayRutTienMat frm25 = new PSC_ERP.FrmChungTuGiayRutTienMat(maChungTu);
                        frm25.WindowState = FormWindowState.Maximized;
                        frm25.ShowDialog();
                        break;


                    default:
                        MessageBox.Show("Không tìm thấy form chứng từ");
                        break;
                }
            }
        }

        private void tlslblXemBaoCao_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_DSHoaDonDichVu);
        }

        private void frmDSHoaDonDichVu_Load(object sender, EventArgs e)
        {
            dtmp_TuNgay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtmp_DenNgay.DateTime = DateTime.Now.Date;
        }

        private void grdu_DSHoaDonDichVu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                HoaDon _HoaDon = HoaDon.NewHoaDon();              
                _HoaDon = (HoaDon)hoaDonListBindingSource.Current;
                if (_HoaDon.SoChungTu + "" != "")
                {
                    MessageBox.Show("Hóa đơn này đã có chứng từ hạch toán, không thể thực hiện xóa");
                    e.Handled = true;
                }
                if (_HoaDon.SoChungTu_ThanhToan + "" != "")
                {
                    MessageBox.Show("Hóa đơn này đã có chứng từ hạch toán, không thể thực hiện xóa");
                    e.Handled = true;
                }
            }
        }

    }
}