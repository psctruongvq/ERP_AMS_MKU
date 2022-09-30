using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace PSC_ERP.UserInterface.QuyChungMotTamLong
{
    public partial class frmDanhSachTaiTro : Form
    {
        #region Properties
        TaiTroList _taiTroList;
        DateTime _tuNgay = DateTime.Today.Date;
        DateTime _denNgay = DateTime.Today.Date;
        #endregion

        #region Loads
        public frmDanhSachTaiTro()
        {
            InitializeComponent();
            this.bdChungTu.DataSource = typeof(ERP_Library.TaiTroList);
            LoadForm();
        }
        #endregion

        #region Process
        #endregion

        #region Events
        #endregion

        private void LoadForm()
        {
            _tuNgay = Convert.ToDateTime(txtTuNgay.Value);
            _denNgay = Convert.ToDateTime(txtDenNgay.Value);

            _taiTroList = TaiTroList.GetTaiTroList(_tuNgay, _denNgay);
            bdChungTu.DataSource = _taiTroList;

            DoiTacList _doiTacList = DoiTacList.GetDoiTacListByTen(0);
            bdDoiTuong.DataSource = _doiTacList;

            LoaiThuChi_CacQuyList _LoaiThuChi_CacQuyList = LoaiThuChi_CacQuyList.GetLoaiThuChi_CacQuyList();
            bdLoaiThuChi.DataSource = _LoaiThuChi_CacQuyList;

            LoaiTienList _loaiTienList = LoaiTienList.GetLoaiTienList();
            bdLoaiTien.DataSource = _loaiTienList;
        }

        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung hdc = new HamDungChung();
            hdc.ultragrdEmail_InitializeLayout(sender, e);

            HamDungChung.EditBand(grdData.DisplayLayout.Bands[0],
                new string[7] { "NgayLap", "NgayPhatSong", "MaDoiTuong", "MaChuongTrinh", "SoTien", "LoaiTien", "DienGiai" },
                new string[7] { "Ngày lập", "Ngày phát sóng", "Người tài trợ", "Chương trình", "Số tiền", "Loại tiền", "Diễn giải" },
                new int[7] { 100, 120, 200, 200, 120, 90,  200 },
                new Control[7] { null, txtDenNgay, cmb_DoiTuong, cmbu_LoaiThuChi, null, cmbu_LoaiTien, null },
                new KieuDuLieu[7] { KieuDuLieu.Ngay, KieuDuLieu.Ngay, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.TienLe, KieuDuLieu.Null, KieuDuLieu.Null },
                new bool[7] { true, true, true, true, true, true, true });

            //màu và font chữ
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            this.grdData.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdData.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;

            FilterCombo f = new FilterCombo(grdData, "MaDoiTuong", "TenDoiTac");
        }

        private void tlThem_Click(object sender, EventArgs e)
        {

        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                grdData.UpdateData();
                _taiTroList.ApplyEdit();
                bdChungTu.EndEdit();


                _taiTroList.Save();
                MessageBox.Show(this, "Cập nhật dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void tlSua_Click(object sender, EventArgs e)
        {

        }

        private void tlXoa_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count <= 0)
            {
                MessageBox.Show(this, "Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grdData.DeleteSelectedRows();
            grdData.UpdateData();
        }

        private void tlUndo_Click(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void tlClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslbl_Export_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }

        private void cmb_DoiTuong_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            FilterCombo f = new FilterCombo(cmb_DoiTuong, "TenDoiTac");
            
            foreach (UltraGridColumn col in this.cmb_DoiTuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmb_DoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTac"].Hidden = false;
            cmb_DoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Tên đối tác";
            cmb_DoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.VisiblePosition = 0;
            cmb_DoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTac"].Width = 350;

            cmb_DoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Hidden = false;
            cmb_DoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Header.Caption = "Địa chỉ";
            cmb_DoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Width = 300;
            cmb_DoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Header.VisiblePosition = 1;
        }

        private void cmbu_LoaiThuChi_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cmbu_LoaiThuChi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_LoaiThuChi.DisplayLayout.Bands[0].Columns["TenLoaiThuChi"].Hidden = false;
            cmbu_LoaiThuChi.DisplayLayout.Bands[0].Columns["TenLoaiThuChi"].Header.Caption = "Tên chương trình";
            cmbu_LoaiThuChi.DisplayLayout.Bands[0].Columns["TenLoaiThuChi"].Header.VisiblePosition = 0;
            cmbu_LoaiThuChi.DisplayLayout.Bands[0].Columns["TenLoaiThuChi"].Width = 350;
        }

        private void txtTuNgay_ValueChanged(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void txtDenNgay_ValueChanged(object sender, EventArgs e)
        {
            LoadForm();
        }
    }
}
