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
    public partial class frmLoaiHopDong : Form
    {
        LoaiHopDongList _loaiHopDongList;
        HamDungChung hamDungChung = new HamDungChung();

        #region contructors
        public frmLoaiHopDong()
        {
            InitializeComponent();
            //hamDungChung.EventForm(this);
            KhoiTao();
        }
        #endregion

        #region KhoiTao()
        private void KhoiTao()
        {
            _loaiHopDongList = LoaiHopDongList.GetLoaiHopDongList();
            loaiHopDongListBindingSource.DataSource = _loaiHopDongList;
        }
        #endregion

        #region KiemTraDuLieu()
        private Boolean KiemTraDuLieu()
        {
            Boolean kq = true;
            if (txtMaLoaiHopDong.Text == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Mã Loại Hợp Đồng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLoaiHopDong.Focus();
                kq = false;
                return kq;
            }
            else if (txtTenLoaiHopDong.Text == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Tên Loại Hợp Đồng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoaiHopDong.Focus();
                kq = false;
                return kq;
            }
            return kq;
        }

        private Boolean KiemTraDuLieu(LoaiHopDong loaiHopDong)
        {
            Boolean kq = true;
            if (loaiHopDong.MaQuanLy == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Mã Loại Hợp Đồng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLoaiHopDong.Focus();
                kq = false;
                return kq;
            }
            else if (loaiHopDong.TenLoaiHopDong == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Tên Loại Hợp Đồng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoaiHopDong.Focus();
                kq = false;
                return kq;
            }
            return kq;
        }
        #endregion

        #region ultraGridLoaiHopDong_InitializeLayout
        private void ultraGridLoaiHopDong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ultraGridLoaiHopDong.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultraGridLoaiHopDong.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
            ultraGridLoaiHopDong.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 150;
            ultraGridLoaiHopDong.DisplayLayout.Bands[0].Columns["TenLoaiHopDong"].Header.Caption = "Tên Loại Hợp Đồng";
            ultraGridLoaiHopDong.DisplayLayout.Bands[0].Columns["TenLoaiHopDong"].Header.VisiblePosition = 2;
            ultraGridLoaiHopDong.DisplayLayout.Bands[0].Columns["TenLoaiHopDong"].Width = 350;
            ultraGridLoaiHopDong.DisplayLayout.Bands[0].Columns["MaLoaiHopDong"].Hidden = true;

            this.ultraGridLoaiHopDong.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultraGridLoaiHopDong.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            foreach (UltraGridColumn col in this.ultraGridLoaiHopDong.DisplayLayout.Bands[0].Columns)
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

            if (_loaiHopDongList.Count == 0)
            {
                LoaiHopDong loaiHopDong = LoaiHopDong.NewLoaiHopDong();
                _loaiHopDongList.Add(loaiHopDong);
                ultraGridLoaiHopDong.ActiveRow = ultraGridLoaiHopDong.Rows[_loaiHopDongList.Count - 1];
            }
            else
            {
                if (KiemTraDuLieu() == true)
                {
                    LoaiHopDong loaiHopDong = LoaiHopDong.NewLoaiHopDong();
                    _loaiHopDongList.Add(loaiHopDong);
                    ultraGridLoaiHopDong.ActiveRow = ultraGridLoaiHopDong.Rows[_loaiHopDongList.Count - 1];
                }
            }
        }
        #endregion

        #region luuToolStripMenuItem_Click
        private void luuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoaiHopDong loaiHopDong;
            for (int i = 0; i < _loaiHopDongList.Count; i++)
            {

                loaiHopDong = _loaiHopDongList[i];
                if (loaiHopDong.MaQuanLy == string.Empty)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Quản Lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultraGridLoaiHopDong.ActiveRow = ultraGridLoaiHopDong.Rows[i];
                    txtMaLoaiHopDong.Focus();
                    return;
                }
                else if (loaiHopDong.MaQuanLy.Trim().Length != 4)
                {
                    MessageBox.Show(this, "Mã Quản Lý không hợp lệ, Phải có 4 ký tự", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultraGridLoaiHopDong.ActiveRow = ultraGridLoaiHopDong.Rows[i];
                    txtMaLoaiHopDong.Focus();
                    return;
                }
                else if (LoaiHopDong.KiemTraTrungMaloaiHopDong(loaiHopDong.MaLoaiHopDong, loaiHopDong.MaQuanLy))
                {
                    MessageBox.Show(this, "Trùng Mã quản lý, vui lòng sửa lại! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultraGridLoaiHopDong.ActiveRow = ultraGridLoaiHopDong.Rows[i];
                    txtMaLoaiHopDong.Focus();
                    return;
                }
                else if (loaiHopDong.TenLoaiHopDong == string.Empty)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Tên Loại Hợp đồng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultraGridLoaiHopDong.ActiveRow = ultraGridLoaiHopDong.Rows[i];
                    txtTenLoaiHopDong.Focus();
                    return;
                }
            }
            if (MessageBox.Show(this, "Bạn Có Muốn Lưu Dữ Liệu Hiện Tại", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                _loaiHopDongList.ApplyEdit();
                _loaiHopDongList.Save();
                KhoiTao();
            }
        }
        #endregion

        #region xóaToolStripMenuItem_Click
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ultraGridLoaiHopDong.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn Dữ Liệu Cần Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else ultraGridLoaiHopDong.DeleteSelectedRows();
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