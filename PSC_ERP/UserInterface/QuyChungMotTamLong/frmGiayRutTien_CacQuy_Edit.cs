using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using ERP_Library.ThanhToan;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;


namespace PSC_ERP
{
    public partial class frmGiayRutTien_CacQuy_Edit : Form
    {
        #region Properties
        private bool OK = false;
        private GiayRutTien_CacQuy _data;
        private ChiTiet_GiayRutTien_CacQuyList _CTGiayRutTien;
        private int _loaiDeNghi = 0;
        private bool _isNew = false;

        #endregion

        #region Loads
        public frmGiayRutTien_CacQuy_Edit()
        {
            InitializeComponent();
        }  

        public frmGiayRutTien_CacQuy_Edit(int LoaiDeNghi)
        {
            InitializeComponent();
            _loaiDeNghi = LoaiDeNghi;
            if (_loaiDeNghi == 1)
            {
                this.Text += " Các Quỹ";
            }
            else
            {
                this.Text += " Công Đoàn";
            }
        }

        private void grd_ChiTiet_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(grd_ChiTiet.DisplayLayout.Bands[0],
               new string[2] { "NoiDung", "SoTien" },
               new string[2] { "Nội dung", "Số tiền" },
               new int[2] { 300, 120 },
               new Control[2] { null, null },
               new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Tien },
               new bool[2] { true, true });
            //màu và font chữ
            foreach (UltraGridColumn col in this.grd_ChiTiet.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu nền
            this.grd_ChiTiet.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.grd_ChiTiet.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            UltraGridColumn columnToSummarize2 = e.Layout.Bands[0].Columns["SoTien"];
            SummarySettings summary2 = grd_ChiTiet.DisplayLayout.Bands[0].Summaries.Add("SoTien", SummaryType.Sum, columnToSummarize2, SummaryPosition.UseSummaryPositionColumn);
            summary2.DisplayFormat = " {0:###,###,###,###,###,###.##}";
            summary2.Appearance.TextHAlign = HAlign.Right;

            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
            grd_ChiTiet.DisplayLayout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;

            HamDungChung.EditThemDongMoi(grd_ChiTiet);
        }
        #endregion

        #region Process
        public bool ShowEdit(GiayRutTien_CacQuy data, bool bIsNew)
        {
            _data = data;
            bdData.DataSource = _data;
            _CTGiayRutTien = _data.CTGiayRutTien_CacQuyList;
            cTGiayRutTienListBindingSource.DataSource = _CTGiayRutTien;
            _isNew = bIsNew;
            Load_Form();
            this.ShowDialog();
            return OK;
        }

        private void Load_Form()
        {
            TaiKhoanNganHangCongTyList taiKhoanNganHangCongTyList = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList();
            cmb_TuTaiKhoan.DataSource = taiKhoanNganHangCongTyList;

            TTNhanVienRutGonList _thongTinList = TTNhanVienRutGonList.GetNhanVienListAll();
            TTNhanVienRutGon nv = TTNhanVienRutGon.NewTTNhanVienRutGon(0, "Chưa chọn");
            _thongTinList.Insert(0, nv);
            cmbu_NguoiNhan.DataSource = _thongTinList;

            if (!_isNew & KiemTraLapCT())
            {
                btnDongY.Enabled = false;
            }
        }

        private bool KiemTraLapCT()
        {
            bool bFind = false;
            //ChungTu_LenhChuyenTienNNChildList list = ChungTu_LenhChuyenTienNNChildList.GetChungTu_LenhChuyenTienNNChildList_ByMaPhieu(_data.MaLenhCT);
            //if (list.Count > 0)
            //    bFind = true;
            return bFind;
        }

        #endregion
        
        #region Event
        private void btnDongY_Click(object sender, EventArgs e)
        {
            bdData.EndEdit();
            if (cmb_TuTaiKhoan.Value == null || (int)cmb_TuTaiKhoan.Value == 0)
            {
                MessageBox.Show("Ngân hàng không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //_data.SoTienBangChu = txt_SoTienBangChu.Text;
            _data.ApplyEdit();
            OK = true;
            this.Close();
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            OK = false;
            this.Close();
        }

        private void cmb_TuTaiKhoan_ValueChanged(object sender, EventArgs e)
        {
            if (cmb_TuTaiKhoan.ActiveRow != null)
            {
                txt_TuNganHang.Text = Convert.ToString(cmb_TuTaiKhoan.ActiveRow.Cells["TenNganHang"].Value);
            }
        }

        #endregion

        private void cmbu_NguoiNhan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_NguoiNhan.DisplayLayout.Bands[0],
               new string[2] { "TenNhanVien", "TenBoPhan"},
               new string[2] { "Tên nhân viên", "Tên bộ phận" },
               new int[2] { 300, 200 },
               new Control[2] { null, null },
               new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
               new bool[2] { false, false });
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_NguoiNhan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu nền
            this.grd_ChiTiet.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.grd_ChiTiet.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            FilterCombo filter = new FilterCombo(cmbu_NguoiNhan, "TenNhanVien");
        }

        private void CapNhatSoTien()
        { 
            decimal _soTien = 0;
            foreach (ChiTiet_GiayRutTien_CacQuy ct in _data.CTGiayRutTien_CacQuyList)
            {
                _soTien += ct.SoTien;
            }
            _data.SoTien = _soTien;
        }

        private void grd_ChiTiet_AfterCellUpdate(object sender, CellEventArgs e)
        {
            CapNhatSoTien();
        }
    }
}