using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using ERP_Library;

namespace PSC_ERP.ThanhToan
{
    public partial class frmPhieuDeNghiChuyenKhoanHDDV_Edit : Form
    {
        #region Properties

        private bool OK = false;
        private ERP_Library.ThanhToan.DeNghiChuyenKhoan _data;
        internal string MaPhanHe = "";
        private Nullable<int> OldMaTaiKhoan;
        private bool _IsDichVu = false;
        private DoiTacList _doiTacList;
        DeNghiChuyenKhoan_DichVuList dnList;
        HopDongMuaBanList _hopDong;

        Point locCuoi = new Point(6, 100);
        Size sizeCuoi = new Size(540, 202);
        Point locDau = new Point(6, 154);
        Size sizeDau = new Size(540, 146);
        Point locChay = new Point(6, 100);
        Size sizeChay = new Size(540, 202);
        bool Active = false;

        #endregion

        #region Loads
        public frmPhieuDeNghiChuyenKhoanHDDV_Edit()
        {
            InitializeComponent();
        }

        public frmPhieuDeNghiChuyenKhoanHDDV_Edit(bool DichVu)
        {
            InitializeComponent();
            //dn = DeNghiCK_DichVuList.NewDeNghiCK_DichVuList();
            //bindingSource_DNDVList.DataSource = dn;
        }

        private void frmPhieuDeNghiChuyenKhoan_Edit_Load(object sender, EventArgs e)
        {
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 30)
                this.Text = "Phiếu chuyển cho tài chính";
        }

        private void grd_DSDeNghi_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(grd_DSDeNghi.DisplayLayout.Bands[0],
                new string[6] { "GhiChu", "SoTien", "SoTienTruocThue", "SoTienThue","GhiChuThem", "LoaiTien" },
                new string[6] { "Nội dung", "Số tiền", "Trước thuế", "Tiền thuế","Ghi chú", "Loại tiền" },
                new int[6] { 240, 140, 140, 140,100, 100 },
                new Control[6] { null, null, null, null,null, cmb_LoaiTien },
                new KieuDuLieu[6] { KieuDuLieu.Null, KieuDuLieu.TienLe, KieuDuLieu.TienLe, KieuDuLieu.TienLe, KieuDuLieu.Null, KieuDuLieu.Null },
                new bool[6] { true, true, true, true,true, true });
            //màu và font chữ
            foreach (UltraGridColumn col in this.grd_DSDeNghi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu nền
            this.grd_DSDeNghi.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.grd_DSDeNghi.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            UltraGridColumn columnToSummarize2 = e.Layout.Bands[0].Columns["SoTien"];
            SummarySettings summary2 = grd_DSDeNghi.DisplayLayout.Bands[0].Summaries.Add("SoTien", SummaryType.Sum, columnToSummarize2, SummaryPosition.UseSummaryPositionColumn);
            summary2.DisplayFormat = " {0:###,###,###,###,###,###.##}";
            summary2.Appearance.TextHAlign = HAlign.Right;

            UltraGridColumn columnToSummarize3 = e.Layout.Bands[0].Columns["SoTienTruocThue"];
            SummarySettings summary3 = grd_DSDeNghi.DisplayLayout.Bands[0].Summaries.Add("SoTienTruocThue", SummaryType.Sum, columnToSummarize3, SummaryPosition.UseSummaryPositionColumn);
            summary3.DisplayFormat = " {0:###,###,###,###,###,###.##}";
            summary3.Appearance.TextHAlign = HAlign.Right;

            UltraGridColumn columnToSummarize4 = e.Layout.Bands[0].Columns["SoTienThue"];
            SummarySettings summary4 = grd_DSDeNghi.DisplayLayout.Bands[0].Summaries.Add("SoTienThue", SummaryType.Sum, columnToSummarize4, SummaryPosition.UseSummaryPositionColumn);
            summary4.DisplayFormat = " {0:###,###,###,###,###,###.##}";
            summary4.Appearance.TextHAlign = HAlign.Right;

            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
            grd_DSDeNghi.DisplayLayout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;

            HamDungChung.EditThemDongMoi(grd_DSDeNghi);
            //hdc.ultragrdEmail_InitializeLayout(sender, e);
            //e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
        }

        private void cmbDoiTac_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbDoiTac.DisplayLayout.Bands[0],
            new string[4] { "MaQLDoiTac", "TenDoiTac", "MaSoThue", "DiaChi" },
            new string[4] { "Mã đối tác", "Tên đối tác", "Mã số thuế", "Đơn vị" },
            new int[4] { 150, 250, 120, 250 },
            new Control[4] { null, null, null, null },
            new KieuDuLieu[4] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[4] { false, false, false, false });
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbDoiTac.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                col.CellAppearance.TextHAlign = HAlign.Left;
            }
            //màu nền
            this.cmbDoiTac.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.cmbDoiTac.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            FilterCombo filter = new FilterCombo(cmbDoiTac, "TenDoiTac");
        }

        private void cmb_NganHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmb_NganHang.DisplayLayout.Bands[0],
                    new string[2] { "TenNganHang", "SoTk" },
                    new string[2] { "Tên ngân hàng", "Số tài khoản" },
                    new int[2] { 300, 100 },
                    new Control[2] { null, null },
                    new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
                    new bool[2] { false, false }); //màu và font chữ
            foreach (UltraGridColumn col in this.cmb_NganHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                col.CellAppearance.TextHAlign = HAlign.Left;
            }
            //màu nền
            this.cmb_NganHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.cmb_NganHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            FilterCombo filter = new FilterCombo(cmb_NganHang, "TenNganHang");
        }

        private void cmb_HopDong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmb_HopDong.DisplayLayout.Bands[0],
                new string[5] { "SoHopDong", "TenHopDong", "TenDoiTac", "NgayLap", "NgayHetHan" },
                new string[5] { "Số hợp đồng", "Tên hợp đồng", "Tên đối tác", "Ngày lập", "Ngày hết hạn" },
                new int[5] { 100, 150, 150, 100, 100 },
                new Control[5] { null, null, null, null, null },
                new KieuDuLieu[5] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Ngay, KieuDuLieu.Ngay },
                new bool[5] { false, false, false, false, false });
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmb_HopDong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            FilterCombo filter = new FilterCombo(cmb_HopDong, "SoHopDong");
        }

        private void cmb_TaiKhoanPhu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmb_TaiKhoanPhu.DisplayLayout.Bands[0],
                    new string[3] { "TenDoiTacPhu", "TenNganHang", "SoTaiKhoan" },
                    new string[3] { "Đơn vị nhận", "Tên ngân hàng", "Số tài khoản" },
                    new int[3] { 250, 250, 100 },
                    new Control[3] { null, null, null },
                    new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
                    new bool[3] { false, false, false }); //màu và font chữ
            foreach (UltraGridColumn col in this.cmb_TaiKhoanPhu.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                col.CellAppearance.TextHAlign = HAlign.Left;
            }
            //màu nền
            this.cmb_TaiKhoanPhu.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.cmb_TaiKhoanPhu.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            FilterCombo filter = new FilterCombo(cmb_TaiKhoanPhu, "TenDoiTacPhu");
        }
        #endregion

        #region Process
        public bool EditData(ERP_Library.ThanhToan.DeNghiChuyenKhoan data)
        {
            cmbBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanList();
            bdTaiKhoan.DataSource = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList();
            cmbCongTy.DataSource = ERP_Library.CongTyList.GetCongTyList();
            _hopDong = HopDongMuaBanList.NewHopDongMuaBanList();
            _hopDong.Insert(0, HopDongMuaBan.NewHopDongMuaBan(0, "Không có hợp đồng"));
            cmb_HopDong.DataSource = _hopDong;

            HamDungChung.VisibleColumn(cmbCongTy.DisplayLayout.Bands[0], "MaCongTyQuanLy", "TenCongTy");
            _data = data;
            _data.ChungTu.BeginEdit();
            _data.BeginEdit();
            _data.Loai = false;

            bdData.DataSource = _data;
            lblHoanTat.Visible = _data.DaDuyet;
            btnDongY.Enabled = !_data.DaDuyet;
            OldMaTaiKhoan = _data.MaTaiKhoanChuyen;

            //Thành bổ sung
            _doiTacList = DoiTacList.GetDoiTacListByTen(0);
            cmbDoiTac.DataSource = _doiTacList;

            dnList = _data.DeNghiDichVuList;
            bindingSource_DNDVList.DataSource = dnList;

            cmb_LoaiTien.DataSource = LoaiTienList.GetLoaiTienList();

            //Tài khoản phụ
            if (_data.TaiKhoanPhu.IsTaiKhoanPhu)
            {
                chk_TaiKhoanPhu.Checked = true;
                cmb_TaiKhoanPhu.Value = _data.TaiKhoanPhu.MaTKPhu;
                TKPhu_NganHang tk = TKPhu_NganHang.GetTKPhu_NganHang(_data.TaiKhoanPhu.MaTKPhu);
                txt_NganHang.Text = tk.TenNganHang;
                txt_TaiKhoanPhu.Text = tk.SoTaiKhoan;

                locChay = new Point(6, 154);
                sizeChay = new Size(540, 146);
                grp_DanhSach.Location = locChay;
                grp_DanhSach.Size = sizeChay;
            }
            else
            {
                chk_TaiKhoanPhu.Checked = false;
            }

            //-----------------------------------------------
            this.ShowDialog();
            return OK;
        }

        private void CapNhatTongSoTien()
        {
            //cập nhật lại tổng tiền
            decimal tong = 0;
            foreach (ERP_Library.ThanhToan.DeNghiChuyenKhoan_ChungTu item in _data.ChungTu)
            {
                tong += item.SoTien;
            }
            _data.SoTien = tong;
        }

        private bool MoChungTu(ERP_Library.ThanhToan.LoaiChungTuGoc loai, ERP_Library.ThanhToan.DeNghiChuyenKhoan_ChungTu chungtu, bool isnew)
        {
            System.Type t = System.Type.GetType("PSC_ERP.ThanhToan." + loai.TenForm);
            frmChungTuGoc f = (frmChungTuGoc)Activator.CreateInstance(t);
            f._denghi = _data;
            bool GiaTri = f.MoChungTu(loai, chungtu, isnew);

            //Tải dữ liệu từ Hóa Đơn Dịch Vụ vừa chọn
            _data.TenNguoiNhan = f.strTenDoiTac;
            _data.NganHangNhan = f.strTenNganHang;
            _data.SoTaiKhoanNhan = f.strTaiKhoan;
            return GiaTri;
        }


        private void GetLyDo()
        {
            string strLyDo = string.Empty;
            foreach (DeNghiChuyenKhoan_DichVu dv in _data.DeNghiDichVuList)
            {
                if (strLyDo != string.Empty)
                    strLyDo += ", " + dv.GhiChu;
                else
                    strLyDo += dv.GhiChu;
            }
            _data.LyDo = strLyDo;
        }
        #endregion

        #region Event
        private void btnKhong_Click(object sender, EventArgs e)
        {
            _data.ChungTu.CancelEdit();
            _data.CancelEdit();
            this.Close();
        }

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbBoPhan.Value != null)
                cmbNhanVien.LoadDataByBoPhan((int)cmbBoPhan.Value);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmChonLoaiChungTuGoc f = new frmChonLoaiChungTuGoc();
            if (f.ChonLoaiChungTuGoc(MaPhanHe, "ChuyenKhoan"))
            {
                ERP_Library.ThanhToan.DeNghiChuyenKhoan_ChungTu _chungtu = _data.ChungTu.AddNew();
                if (MoChungTu(f.LoaiChungTu, _chungtu, true))
                {

                    _data.ChungTu.EndNew(_data.ChungTu.IndexOf(_chungtu));
                    if (_data.LyDo == "")
                        _data.LyDo = _chungtu.DienGiai;
                    CapNhatTongSoTien();
                }
                else
                {
                    _data.ChungTu.CancelNew(_data.ChungTu.IndexOf(_chungtu));
                    _data.ChungTu.Remove(_chungtu);
                }
            }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDoiTac.ActiveRow == null)
                {
                    MessageBox.Show(this, "Vui lòng chọn tên đối tác.", "Lưu Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbDoiTac.Focus();
                    return;
                }

                //if (cmb_NganHang.ActiveRow == null)
                //{
                //    MessageBox.Show(this, "Vui lòng chọn ngân hàng.", "Lưu Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    cmb_NganHang.Focus();
                //    return;
                //}

                long lMaDoiTac = Convert.ToInt64(cmbDoiTac.Value);
                int iMaNganHang = Convert.ToInt32(cmb_NganHang.Value);
                int iMaTKPhu = Convert.ToInt32(cmb_TaiKhoanPhu.Value);
                decimal deSoTien = 0;

                foreach (DeNghiChuyenKhoan_DichVu dndv in _data.DeNghiDichVuList)
                {
                    dndv.MaDoiTac = lMaDoiTac;
                    dndv.MaNganHang = iMaNganHang;
                    dndv.TenNganHang = cmb_NganHang.Text;
                    dndv.Cmnd = KhachHang.GetKhachHang(lMaDoiTac).Cmnd;
                    deSoTien += dndv.SoTien;
                    //_data.DeNghiDichVuList.r
                }

                //Cập nhật thêm dữ liệu cho tài khoản phụ
                _data.TaiKhoanPhu.MaDoiTac = lMaDoiTac;
                if (chk_TaiKhoanPhu.Checked)
                {
                    //Nếu sử dụng tài khoản phụ thì lưu lại thông tin TK lại
                    _data.TaiKhoanPhu.IsTaiKhoanPhu = true;
                    _data.TaiKhoanPhu.MaTKPhu = iMaTKPhu;
                    _data.TaiKhoanPhu.SoTaiKhoan = cmb_TaiKhoanPhu.ActiveRow.Cells["SoTaiKhoan"].Value.ToString();
                    _data.TaiKhoanPhu.TenDoiTac = cmb_TaiKhoanPhu.ActiveRow.Cells["TenDoiTacPhu"].Value.ToString();
                }
                else
                {
                    //Nếu không sử dụng tài khoản phụ thì lưu lại thông tin TK lại
                    _data.TaiKhoanPhu.IsTaiKhoanPhu = false;
                    _data.TaiKhoanPhu.MaTKPhu = 0;
                    _data.TaiKhoanPhu.SoTaiKhoan = txtTaiKhoan.Text.ToString();
                    _data.TaiKhoanPhu.TenDoiTac = cmbDoiTac.Text.ToString();
                }

                bdData.EndEdit();
                _data.Loai = false;
                _data.SoTien = deSoTien;
                _data.ChungTu.ApplyEdit();
                _data.ApplyEdit();
                OK = true;
                this.Close();
            }
            catch (Exception ex)
            {
                OK = false;
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
            }
        }

        private void grdChungTu_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            int MaLoaiChungTu = (int)e.Row.Cells["MaLoaiChungTu"].Value;
            ERP_Library.ThanhToan.LoaiChungTuGoc LoaiChungTu = ERP_Library.ThanhToan.LoaiChungTuGoc.GetLoaiChungTuGoc(MaLoaiChungTu);
            if (MoChungTu(LoaiChungTu, (ERP_Library.ThanhToan.DeNghiChuyenKhoan_ChungTu)e.Row.ListObject, false))
            {
                CapNhatTongSoTien();
            }
        }

        private void grdChungTu_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa chứng từ gốc này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        private void grdChungTu_AfterRowsDeleted(object sender, EventArgs e)
        {
            CapNhatTongSoTien();
        }

        private void cmb_NganHang_ValueChanged(object sender, EventArgs e)
        {
            int iMaDoiTac = 0;
            int iMaNganHang = 0;
            if (cmb_NganHang.ActiveRow != null && cmbDoiTac.ActiveRow!=null)
            {
                iMaDoiTac = Convert.ToInt32(cmbDoiTac.ActiveRow.Cells["MaDoiTac"].Value);
                iMaNganHang = Convert.ToInt32(cmb_NganHang.Value);
                txtTaiKhoan.Text = TK_NganHang.GetSoTaiKhoan(iMaDoiTac, iMaNganHang);
                //txt_MST.Text = DoiTac.GetDoiTac(iMaDoiTac).MaSoThue;
                txt_MST.Text = DoiTac.GetDoiTacWithoutChild(iMaDoiTac).MaSoThue;
                _data.ApplyEdit();
                bdData.EndEdit();
            }
        }

        private void cmbDoiTac_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbDoiTac.ActiveRow != null)
                {
                    //DoiTac doitac = DoiTac.GetDoiTac(Convert.ToInt64(cmbDoiTac.ActiveRow.Cells["MaDoiTac"].Value));
                    DoiTac doitac = DoiTac.GetDoiTacForDeNghiChuyenKhoanHDDV(Convert.ToInt64(cmbDoiTac.ActiveRow.Cells["MaDoiTac"].Value));
                    tKNganHangListBindingSource.DataSource = doitac.TK_NganHangList;
                    TaiKhoanPhu_binding.DataSource = doitac.tKPhu_NganHangList;

                    long maDoiTac = Convert.ToInt64(cmbDoiTac.Value);
                    _hopDong = HopDongMuaBanList.GetHopDongMuaBanList_TheoDoiTac(maDoiTac);
                    _hopDong.Insert(0, HopDongMuaBan.NewHopDongMuaBan(0, "Không chọn"));
                    cmb_HopDong.DataSource = _hopDong;
                    bdData.EndEdit();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void grd_DSDeNghi_AfterRowInsert(object sender, RowEventArgs e)
        {
            grd_DSDeNghi.UpdateData();
            bindingSource_DNDVList.EndEdit();
        }

        private void grd_DSDeNghi_AfterCellUpdate(object sender, CellEventArgs e)
        {
            _data.ApplyEdit();
            bdData.EndEdit();
            GetLyDo();
        }

        private void chk_TaiKhoanPhu_CheckedChanged(object sender, EventArgs e)
        {
            Active = true;
            tm_ChayTKPhu.Enabled = true;
        }

        private void tm_ChayTKPhu_Tick(object sender, EventArgs e)
        {
            if (!chk_TaiKhoanPhu.Checked)
            {
                if (Active == true && !locChay.Equals(locCuoi) && !sizeChay.Equals(sizeCuoi))
                {
                    locChay.Y -= 2;
                    sizeChay.Height += 2;
                    grp_DanhSach.Location = locChay;
                    grp_DanhSach.Size = sizeChay;
                }
                else
                {
                    Active = false;
                    tm_ChayTKPhu.Enabled = false;
                }
            }
            else
            {
                if (Active == true && !locChay.Equals(locDau) && !sizeChay.Equals(sizeDau))
                {
                    locChay.Y += 2;
                    sizeChay.Height -= 2;
                    grp_DanhSach.Location = locChay;
                    grp_DanhSach.Size = sizeChay;
                }
                else
                {
                    Active = false;
                    tm_ChayTKPhu.Enabled = false;
                }
            }
        }

        private void cmb_TaiKhoanPhu_ValueChanged(object sender, EventArgs e)
        {
            if (cmb_TaiKhoanPhu.ActiveRow != null)
            {
                txt_TaiKhoanPhu.Text = cmb_TaiKhoanPhu.SelectedRow.Cells["SoTaiKhoan"].Value.ToString();
                txt_NganHang.Text = cmb_TaiKhoanPhu.SelectedRow.Cells["TenNganHang"].Value.ToString();
                bdData.EndEdit();
            }
        }
        #endregion

        private void HopDongbd_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void cmbDoiTac_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (cmbDoiTac.ActiveRow != null)
            //    {

            //        long maDoiTac = Convert.ToInt64(cmbDoiTac.Value);
            //        _hopDong = HopDongMuaBanList.GetHopDongMuaBanList_TheoDoiTac(maDoiTac);
            //        _hopDong.Insert(0, HopDongMuaBan.NewHopDongMuaBan(0, "Không chọn"));
            //        cmb_HopDong.DataSource = _hopDong;
            //        bdData.EndEdit();
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

    }
}