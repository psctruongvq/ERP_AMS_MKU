using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
//122
namespace PSC_ERP
{
    public partial class frmKetChuyenXacDinhKQHDKD : Form
    {
        TaiKhoanKetChuyenList _TaiKhoanKetChuyenList = TaiKhoanKetChuyenList.NewTaiKhoanKetChuyenList();
        TaiKhoanKetChuyenList _TaiKhoanDaXoaList = TaiKhoanKetChuyenList.NewTaiKhoanKetChuyenList();
        int maLoaiKetChuyen = 1;
        ChungTu _ChungTu;
        Ky _ky = Ky.NewKy();
        byte _noCo = 1;
        CongThucKetChuyenChinhThucList _congThucKetChuyenChinhThucList = CongThucKetChuyenChinhThucList.NewCongThucKetChuyenChinhThucList();

        #region Contructors
        public frmKetChuyenXacDinhKQHDKD()
        {
            InitializeComponent();
            DangNhap._MaNguoiSuDung = 1;
            KhoiTao();

        }
        #endregion

        #region Khởi Tạo
        private void KhoiTao()
        {
            _ChungTu = ChungTu.NewChungTu(17);
            cbu_LoaiKetChuyen.Value = 1;

            taiKhoanKetChuyenListBindingSource.DataSource = _TaiKhoanKetChuyenList;
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List();
            heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List();
            KyList _kyList = KyList.GetKyList();
            kyListBindingSource.DataSource = _kyList;
            ChungTubindingSource.DataSource = _ChungTu;
            DinhKhoanbindingSource.DataSource = _ChungTu.DinhKhoan;
            butToanBindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;

            //Lấy dữ liệu cho loại kết chuyển
            LoaiKetChuyenList loaiKetChuyenList = LoaiKetChuyenList.GetLoaiKetChuyenList();
            LoaiKetChuyen_BindingSource.DataSource = loaiKetChuyenList;

        }
        #endregion

        private Boolean KiemTraDuLieu()
        {
            Boolean kq = true;
            if (_ChungTu.SoChungTu == "")
            {
                MessageBox.Show(this, "Vui Lòng Nhập Số Chứng Từ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoChungTu.Focus();
               return kq = false;
            }
            else if (_ChungTu.DinhKhoan.ButToan.Count == 0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Bút Toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return kq = false;
            }

            if (ChungTu.KiemTraSoChungTu(txt_SoChungTu.Text, _ChungTu) == true)
            {
                MessageBox.Show(this, "Số Chứng Từ Đã Có Vui Lòng Nhập SCT Khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoChungTu.Focus();
                return kq = false;
            }

            KhoaSo_UserList khoaList = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(Convert.ToDateTime(dtu_NgayLap.Value));
            if (khoaList.Count > 0)
            {
                if (khoaList[0].KhoaSo == true)
                {
                    MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return kq = false;
                }
            }
            return kq;
        }

        #region grd_DinhKhoan_InitializeLayout
        private void grd_DinhKhoan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["NoTaiKhoan"].Header.Caption = "Nợ Tài Khoản";
            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["NoTaiKhoan"].Header.VisiblePosition = 1;
            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["NoTaiKhoan"].EditorComponent = cbu_NoTaiKhoan;
            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["CoTaiKhoan"].Header.Caption = "Có Tài Khoản";
            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["CoTaiKhoan"].Header.VisiblePosition = 2;
            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["CoTaiKhoan"].EditorComponent = cbu_CoTaiKhoan;
            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["CoTaiKhoan"].Header.Caption = "Có Tài Khoản";
            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["DienGiai"].Header.VisiblePosition = 4;
            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["DienGiai"].Width = 300;
            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["SoTien"].Header.Caption = "Số Tiền";
            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["SoTien"].Header.VisiblePosition = 3;

            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["NoTaiKhoan"].Width = 100;
            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["CoTaiKhoan"].Width = 100;
            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["SoTien"].Width = 150;
            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["DienGiai"].Width = 300;
            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Override.RowSelectors = DefaultableBoolean.True;
            UltraGridColumn columnToSummarize2 = e.Layout.Bands["ButToan"].Columns["SoTien"];
            SummarySettings summary2 = grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Summaries.Add("SoTien", SummaryType.Sum, columnToSummarize2);
            summary2.SummaryPosition = SummaryPosition.Left;
            summary2.DisplayFormat = "Tổng Tiền = {0:###,###,###}";
            summary2.Appearance.TextHAlign = HAlign.Right;
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            this.grd_DinhKhoan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grd_DinhKhoan.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                col.Hidden = true;
            }

            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["SoTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["SoTien"].Format = "#,###";
            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["SoTien"].PromptChar = ' ';

            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["CoTaiKhoan"].Hidden = false;
            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["NoTaiKhoan"].Hidden = false;
            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["DienGiai"].Hidden = false;
            grd_DinhKhoan.DisplayLayout.Bands["ButToan"].Columns["SoTien"].Hidden = false;
        }
        #endregion

        #region cbu_CoTaiKhoan_InitializeLayout
        private void cbu_CoTaiKhoan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbu_CoTaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }

            cbu_CoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            cbu_CoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            cbu_CoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;

            cbu_CoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            cbu_CoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 100;
            cbu_CoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;
            cbu_CoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;

        }
        #endregion

        #region cbu_NoTaiKhoan_InitializeLayout
        private void cbu_NoTaiKhoan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbu_NoTaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }

            cbu_NoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            cbu_NoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            cbu_NoTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;

            cbu_NoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            cbu_NoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 100;
            cbu_NoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;
            cbu_NoTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
        }
        #endregion

        #region grdu_DanhSachKetChuyen_InitializeLayout
        private void grdu_DanhSachKetChuyen_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.grdu_DanhSachKetChuyen.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DanhSachKetChuyen.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy; 
            }

            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["MaTaiKhoanNhanKC"].Hidden = true;
            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["MaTaiKhoanKC"].Hidden = true;
            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["MaCongThucKC"].Hidden = true;
            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["SoTT"].Hidden = true;
            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["MaBoPhan"].Hidden = true;
            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;

            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Chọn";
            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 1;

            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["SoHieuTaiKhoan"].Header.Caption = "Tài khoản";
            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["SoHieuTaiKhoan"].Header.VisiblePosition = 2;

            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["SoTien"].Width = 150;
            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 3;
            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["TenTaiKhoanKC"].Header.Caption = "Tên TK Kết Chuyển";
            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["TenTaiKhoanKC"].Header.VisiblePosition = 4;

            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["TenTaiKhoanNhanKC"].Header.Caption = "Tên Tài Khoản Nhận";
            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["TenTaiKhoanNhanKC"].Header.VisiblePosition = 5;

            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["MaLoaiKetChuyen"].EditorComponent = cbu_LoaiKetChuyen;
            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["MaLoaiKetChuyen"].Header.Caption = "Loại Kết Chuyển";
            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["MaLoaiKetChuyen"].Header.VisiblePosition = 4;
            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["MaLoaiKetChuyen"].Width = cbu_LoaiKetChuyen.Width;

            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["KetChuyenNoCo"].Header.Caption = "Kết Chuyển Nợ Có";
            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["KetChuyenNoCo"].Header.VisiblePosition = 7;
            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["KetChuyenNoCo"].EditorComponent = cmbu_TaiKhoanNC;

            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["SoTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["SoTien"].Format = "#,###";
            grdu_DanhSachKetChuyen.DisplayLayout.Bands[0].Columns["SoTien"].PromptChar = ' ';
        }
        #endregion

        #region cbu_KyKetChuyen_InitializeLayout
        private void cbu_KyKetChuyen_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.cbu_KyKetChuyen.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cbu_KyKetChuyen.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                //x =  //= System.Drawing.w;//RoyalBlue
            }


            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["MaKy"].Header.Caption = "Mã Kỳ";
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["MaKy"].Header.VisiblePosition = 1;
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["MaKy"].Hidden = false;

            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["TenKy"].Header.VisiblePosition = 2;
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;

            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayBatDau"].Header.Caption = "Ngày Bắt Đầu";
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayBatDau"].Header.VisiblePosition = 3;
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayBatDau"].Hidden = false;

            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Header.Caption = "Ngày Kết Thúc";
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Header.VisiblePosition = 4;
            cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Hidden = false;
        }
        #endregion

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            _congThucKetChuyenChinhThucList = CongThucKetChuyenChinhThucList.NewCongThucKetChuyenChinhThucList();
            KhoiTao();
        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (KiemTraDuLieu() == true)
            {
                if (MessageBox.Show(this, "Bạn Muốn Lưu Dữ Liệu", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        _ChungTu.ApplyEdit();
                        _ChungTu.Save();

                        {
                            //Lưu công thức kết chuyển chính thức
                            if (_congThucKetChuyenChinhThucList.Count > 0 && _ChungTu.MaChungTu != 0)
                            {
                                foreach (CongThucKetChuyenChinhThuc item in _congThucKetChuyenChinhThucList)
                                {
                                    item.MaChungTu = _ChungTu.MaChungTu;
                                }
                            }
                            _congThucKetChuyenChinhThucList.ApplyEdit();
                            _congThucKetChuyenChinhThucList.Save();
                        }

                        MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "Cập Nhật Không Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        #endregion

        #region bt_Add_Click
        private void bt_Add_Click(object sender, EventArgs e)
        {
            Boolean choPhepThem = true;
            decimal soTienChungTu = 0;
            for (int i = 0; i < _TaiKhoanKetChuyenList.Count; i++) // TaiKhoanKetChuyen _taiKhoanKetChuyen in _TaiKhoanKetChuyenList)
            {
                if (_TaiKhoanKetChuyenList[i].Check == true)
                {
                    for (int j = 0; j < _congThucKetChuyenChinhThucList.Count; j++)
                    {
                        if (_congThucKetChuyenChinhThucList[j].MaCongThuc == _TaiKhoanKetChuyenList[i].MaCongThucKC)
                        {
                            choPhepThem = false;
                            break;
                        }
                    }

                    if (choPhepThem)
                    {
                        {
                            //Lấy dữ liệu cho công thức kết chuyển
                            CongThucKetChuyenChinhThuc congThucKC = CongThucKetChuyenChinhThuc.NewCongThucKetChuyenChinhThuc();
                            congThucKC.SoTT = _TaiKhoanKetChuyenList[i].SoTT;
                            congThucKC.MaTaiKhoanKC = _TaiKhoanKetChuyenList[i].MaTaiKhoanKC;
                            congThucKC.MaTaiKhoanNhanKC = _TaiKhoanKetChuyenList[i].MaTaiKhoanNhanKC;
                            congThucKC.SoHieuTaiKhoan = _TaiKhoanKetChuyenList[i].SoHieuTaiKhoan;
                            congThucKC.MaLoaiKetChuyen = _TaiKhoanKetChuyenList[i].MaLoaiKetChuyen;
                            congThucKC.KetChuyenNoCo = _TaiKhoanKetChuyenList[i].KetChuyenNoCo;
                            congThucKC.MaBoPhan = _TaiKhoanKetChuyenList[i].MaBoPhan;
                            congThucKC.MaCongThuc = _TaiKhoanKetChuyenList[i].MaCongThucKC;
                            congThucKC.MaNguoiLap = _TaiKhoanKetChuyenList[i].MaNguoiLap;

                            _congThucKetChuyenChinhThucList.Add(congThucKC);
                        }
                        //Phát sinh số chứng
                        SetSoChungTuMoiPS(16);

                        //Set chứng từ
                        //_ChungTu.LoaiChungTu.MaLoaiCT = 16;
                        _ChungTu.LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDevByMaQuanLy("PKT");
                        _ChungTu.MaDoiTuongThuChi = 1;
                        _ChungTu.DinhKhoan.ButToan.Add(ButToan.NewButToan(_TaiKhoanKetChuyenList[i]));

                    }
                    //Ẩn đi dòng đã chọn trong tài khoản kết chuyển
                    grdu_DanhSachKetChuyen.Rows[i].Hidden = true;
                    //
                    _TaiKhoanKetChuyenList[i].Check = false;
                    choPhepThem = true;
                }
            }
            {
                foreach (ButToan item in _ChungTu.DinhKhoan.ButToan)
                {
                    soTienChungTu += item.SoTien;
                }
                //Set số tiền chứng từ
                _ChungTu.Tien.SoTien = soTienChungTu;
                _ChungTu.Tien.MaLoaiTien = 1;
                _ChungTu.Tien.ThanhTien = soTienChungTu;
            }
            butToanBindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;

            if (cbu_KyKetChuyen.Value != null)
            {
                //Lấy mã kỳ
                _ChungTu.Ky = Convert.ToInt32(cbu_KyKetChuyen.Value);
            }
        }
        #endregion
        private void SetSoChungTuMoiPS(int MaPhieu)
        {
            string soCTCu = ChungTu.KiemTraSoChungTuMoiNhat(MaPhieu, 1, Convert.ToDateTime(dtu_NgayLap.Value).Year);
            if (soCTCu != null)
            {
                if (_ChungTu.MaChungTu == 0)
                {
                    _ChungTu.SoChungTu = ChungTu.LaySoChungTuMax(MaPhieu, Convert.ToDateTime(dtu_NgayLap.Value).Year);
                }
            }
        }
        #region bt_Remove_Click
        private void bt_Remove_Click(object sender, EventArgs e)
        {
            //Lấy dòng bút toán hiện tại
            ButToan butToanCurrent = butToanBindingSource.Current as ButToan;

            if (butToanCurrent == null || grd_DinhKhoan.Selected.Rows.Count == 0)
            {
                MessageBox.Show("Chọn dòng cần xóa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (int i = 0; i < _congThucKetChuyenChinhThucList.Count; i++)
            {
                if (_congThucKetChuyenChinhThucList[i].MaCongThuc == butToanCurrent.MaCongThuc)
                {
                    _congThucKetChuyenChinhThucList.RemoveAt(i);
                    i--;
                }
            }

            grd_DinhKhoan.DeleteSelectedRows(false);
        }
        #endregion

        private void dtu_TuNgay_ValueChanged(object sender, EventArgs e)
        {

        }

        #region cbu_LoaiKetChuyen_ValueChanged
        private void cbu_LoaiKetChuyen_ValueChanged(object sender, EventArgs e)
        {
            maLoaiKetChuyen = Convert.ToByte(cbu_LoaiKetChuyen.Value);
            _ChungTu.DinhKhoan.ButToan = ButToanList.NewButToanList();
            _TaiKhoanKetChuyenList = TaiKhoanKetChuyenList.GetTaiKhoanKetChuyenList(maLoaiKetChuyen, _ky.MaKy, _ky.NgayBatDau, _ky.NgayKetThuc, _noCo);
            taiKhoanKetChuyenListBindingSource.DataSource = _TaiKhoanKetChuyenList;
            butToanBindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;
        }
        #endregion


        private void dtu_DenNgay_ValueChanged(object sender, EventArgs e)
        {

        }

        #region cmbu_TaiKhoanNC_ValueChanged
        private void cmbu_TaiKhoanNC_ValueChanged(object sender, EventArgs e)
        {
            _noCo = Convert.ToByte(cmbu_TaiKhoanNC.Value);
            //_ChungTu.DinhKhoan.ButToan = ButToanList.NewButToanList();
            _TaiKhoanKetChuyenList = TaiKhoanKetChuyenList.GetTaiKhoanKetChuyenList(maLoaiKetChuyen, _ky.MaKy, _ky.NgayBatDau, _ky.NgayKetThuc, _noCo);
            taiKhoanKetChuyenListBindingSource.DataSource = _TaiKhoanKetChuyenList;
        }
        #endregion

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void cbu_KyKetChuyen_Leave(object sender, EventArgs e)
        {
            if (cbu_KyKetChuyen.Value != null)
            {
                _ky = Ky.GetKy(Convert.ToInt32(cbu_KyKetChuyen.Value));
                dtu_TuNgay.Value = _ky.NgayBatDau;
                dtu_DenNgay.Value = _ky.NgayKetThuc;
                _ChungTu.DinhKhoan.ButToan = ButToanList.NewButToanList();
                _TaiKhoanKetChuyenList = TaiKhoanKetChuyenList.GetTaiKhoanKetChuyenList(maLoaiKetChuyen, _ky.MaKy, _ky.NgayBatDau, _ky.NgayKetThuc, _noCo);
                taiKhoanKetChuyenListBindingSource.DataSource = _TaiKhoanKetChuyenList;
                butToanBindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;
            }
        }

        private void cbu_LoaiKetChuyen_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbu_LoaiKetChuyen.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbu_LoaiKetChuyen.DisplayLayout.Bands[0].Columns["TenLoaiKetChuyen"].Header.Caption = "Tên Loại Kết Chuyển";
            cbu_LoaiKetChuyen.DisplayLayout.Bands[0].Columns["TenLoaiKetChuyen"].Width = cbu_LoaiKetChuyen.Width;
            cbu_LoaiKetChuyen.DisplayLayout.Bands[0].Columns["TenLoaiKetChuyen"].Header.VisiblePosition = 1;
            cbu_LoaiKetChuyen.DisplayLayout.Bands[0].Columns["TenLoaiKetChuyen"].Hidden = false;

        }

        private void frmKetChuyenXacDinhKQHDKD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                tlslblLuu_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.D)
            {
                tlslblXoa_Click(sender, e);
            }
            if (e.Alt && e.KeyCode == Keys.X)
            {
                tlslblLuu_Click(sender, e);
            }
            if (e.Alt && e.KeyCode == Keys.N)
            {
                tlslblThem_Click(sender, e);
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grd_DinhKhoan.Selected.Rows.Count == 0)
            {
                MessageBox.Show("Chọn dòng cần xóa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grd_DinhKhoan.DeleteSelectedRows();
        }

        private void cbu_LoaiKetChuyen_ValueChanged_1(object sender, EventArgs e)
        {
            if (_ChungTu.IsNew)
            {
                maLoaiKetChuyen = Convert.ToByte(cbu_LoaiKetChuyen.Value);
                _ChungTu.DinhKhoan.ButToan = ButToanList.NewButToanList();
                _TaiKhoanKetChuyenList = TaiKhoanKetChuyenList.GetTaiKhoanKetChuyenList(maLoaiKetChuyen, _ky.MaKy, _ky.NgayBatDau, _ky.NgayKetThuc, _noCo);
                taiKhoanKetChuyenListBindingSource.DataSource = _TaiKhoanKetChuyenList;
                butToanBindingSource.DataSource = _ChungTu.DinhKhoan.ButToan;
            }
        }
    }
}