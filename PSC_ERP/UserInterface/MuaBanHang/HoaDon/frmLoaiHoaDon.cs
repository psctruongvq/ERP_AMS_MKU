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

namespace PSC_ERP
{
    public partial class frmLoaiHoaDon : Form
    {
        LoaiHoaDonList _loaiHoaDonList;
        HamDungChung hamDungChung = new HamDungChung();
        #region contructors
        public frmLoaiHoaDon()
        {
            InitializeComponent();
            hamDungChung.EventForm(this);
            KhoiTao();
        }
        #endregion

        #region KhoiTao()
        private void KhoiTao()
        {
            _loaiHoaDonList = LoaiHoaDonList.GetLoaiHoaDonList();
            loaiHoaDonListBindingSource.DataSource = _loaiHoaDonList;
        }
        #endregion

        #region KiemTraDuLieu()
        private Boolean KiemTraDuLieu()
        {
            Boolean kq = true;
            if (txtMaLoaiHoaDon.Text == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Mã Loại Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLoaiHoaDon.Focus();
                kq = false;
                return kq;
            }
            else if (txtTenLoaiHoaDon.Text == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Tên Loại Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoaiHoaDon.Focus();
                kq = false;
                return kq;
            }
            return kq;
        }

        private Boolean KiemTraDuLieu(LoaiHoaDon loaiHoaDon)
        {
            Boolean kq = true;
            if (loaiHoaDon.MaQuanLy == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Mã Loại Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLoaiHoaDon.Focus();
                kq = false;
                return kq;
            }
            else if (loaiHoaDon.TenLoaiHonDon == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Tên Loại Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoaiHoaDon.Focus();
                kq = false;
                return kq;
            }
            return kq;
        }
        #endregion

        #region ultraGridLoaiHoaDon_InitializeLayout
        private void ultraGridLoaiHoaDon_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ultraGridLoaiHoaDon.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultraGridLoaiHoaDon.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
            ultraGridLoaiHoaDon.DisplayLayout.Bands[0].Columns["TenLoaiHonDon"].Header.Caption = "Tên Loại Hóa Đơn";
            ultraGridLoaiHoaDon.DisplayLayout.Bands[0].Columns["TenLoaiHonDon"].Header.VisiblePosition = 2;
            ultraGridLoaiHoaDon.DisplayLayout.Bands[0].Columns["MaLoaiHoaDon"].Hidden = true;

            this.ultraGridLoaiHoaDon.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultraGridLoaiHoaDon.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.ultraGridLoaiHoaDon.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
        }
        #endregion

        #region thêmToolStripMenuItem_Click
        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (_loaiHoaDonList.Count == 0)
            {
                LoaiHoaDon loaiHoaDon = LoaiHoaDon.NewLoaiHoaDon();
                _loaiHoaDonList.Add(loaiHoaDon);
                ultraGridLoaiHoaDon.ActiveRow = ultraGridLoaiHoaDon.Rows[_loaiHoaDonList.Count - 1];
            }
            else
            {
                if (KiemTraDuLieu() == true)
                {
                    LoaiHoaDon loaiHoaDon = LoaiHoaDon.NewLoaiHoaDon();
                    _loaiHoaDonList.Add(loaiHoaDon);
                    ultraGridLoaiHoaDon.ActiveRow = ultraGridLoaiHoaDon.Rows[_loaiHoaDonList.Count - 1];
                }
            }
        }
        #endregion

        #region luuToolStripMenuItem_Click
        private void luuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoaiHoaDon loaiHoaDon;
            for (int i = 0; i < _loaiHoaDonList.Count; i++)
            {

                loaiHoaDon = _loaiHoaDonList[i];
                if (loaiHoaDon.MaQuanLy == string.Empty)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Quản Lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultraGridLoaiHoaDon.ActiveRow = ultraGridLoaiHoaDon.Rows[i];
                    txtMaLoaiHoaDon.Focus();
                    return;
                }
                else if (loaiHoaDon.TenLoaiHonDon == string.Empty)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Tên Loại Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultraGridLoaiHoaDon.ActiveRow = ultraGridLoaiHoaDon.Rows[i];
                    txtTenLoaiHoaDon.Focus();
                    return;
                }
            }
            if (MessageBox.Show(this, "Bạn Có Muốn Lưu Dữ Liệu Hiện Tại", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                _loaiHoaDonList.ApplyEdit();
                _loaiHoaDonList.Save();
                KhoiTao();
            }
        }
        #endregion

        #region xóaToolStripMenuItem_Click
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ultraGridLoaiHoaDon.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn Dữ Liệu Cần Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else ultraGridLoaiHoaDon.DeleteSelectedRows();
        }
        #endregion

        #region thoatToolStripMenuItem_Click
        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        
    }
}