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
    public partial class frmHoSoLuong : Form
    {
        #region Properties
        static ThongTinNhanVienTongHop _ThongTinNhanVienTongHop;
        HoSoLuongList _HoSoLuongList;
        HoSoLuong _HoSoLuong;
        NgachLuongCoBanList _NgachLuongCoBanList;
        BacLuongCoBanList _BacLuongCoBanList;
        Util _Util = new Util();
        #endregion

        #region Events
        public frmHoSoLuong()
        {
            InitializeComponent();
            LayDuLieu();

            toolStripLabel1.Visible = false;
            tlslblIn.Visible = false;
            tlslblThem.Enabled = false;
            tlslblLuu.Enabled = false;
            tlslblUndo.Enabled = false;
            tlslblXoa.Enabled = false;
        }

        public frmHoSoLuong(ThongTinNhanVienTongHop thongTinNhanVienTongHop)
        {
            InitializeComponent();
            _ThongTinNhanVienTongHop = thongTinNhanVienTongHop;
        }

        private void LayDuLieu()
        {
            _NgachLuongCoBanList = NgachLuongCoBanList.GetNgachLuongCoBanList();
            NgachLuongCB_BindingSource.DataSource = _NgachLuongCoBanList;

        }

        private void tlslblTim_Click(object sender, EventArgs e) 
        {
            frmTimNhanVien _frmTimNhanVien = new frmTimNhanVien(13);
            if (_frmTimNhanVien.ShowDialog(this) != DialogResult.OK)
            {
                if (_ThongTinNhanVienTongHop != null)
                {
                    _HoSoLuongList = HoSoLuongList.GetHoSoLuongList(_ThongTinNhanVienTongHop.MaNhanVien);
                    HoSoLuong_BindingSource.DataSource = _HoSoLuongList;

                    txtu_TenNhanVien.Text = _ThongTinNhanVienTongHop.TenNhanVien.ToString();
                    txtu_MaNhanVien.Value = _ThongTinNhanVienTongHop.MaNhanVien;
                    txtu_MaNhanVienQL.Text = _ThongTinNhanVienTongHop.MaQLNhanVien.ToString();

                    tlslblThem.Enabled = true;
                    tlslblLuu.Enabled = true;
                    tlslblUndo.Enabled = true;
                    tlslblXoa.Enabled = true;
                }
            }
        }
        
        private void cmbu_NgachLuongCB_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_NgachLuongCB.Value != null)
            {
                _BacLuongCoBanList = BacLuongCoBanList.GetBacLuongCoBanList((int)cmbu_NgachLuongCB.Value);
                BacLuongCB_BindingSource.DataSource = _BacLuongCoBanList;
            }
        }

        private void cmbu_BacLuongCB_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_BacLuongCB.Value != null)
            {
                numeu_HeSoLuongCB.Value = BacLuongCoBan.GetBacLuongCoBan((int)cmbu_BacLuongCB.Value).HeSoLuong;
            }
        }

        private bool KiemTraTruocKhiLuu()
        {
            bool kq = true;
            foreach (Control control in gbx_ThongTinHoSoLuong.Controls)
            {
                if (errorProvider1.GetError(control) != String.Empty)
                {
                    if (control.Name == dtmp_NgayBatDauLuong.Name)
                    {
                        MessageBox.Show(this, "Vui Lòng Chọn Ngày Bắt Đầu", _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Focus();
                        kq = false;
                        return kq;
                    }
                    if (control.Name == cmbu_NgachLuongCB.Name)
                    {
                        MessageBox.Show(this, "Vui Lòng Chọn Ngạch Lương CB", _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Focus();
                        kq = false;
                        return kq;
                    }
                    if (control.Name == cmbu_BacLuongCB.Name)
                    {
                        MessageBox.Show(this, "Vui Lòng Chọn Bậc Lương CB", _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Focus();
                        kq = false;
                        return kq;
                    }
                }
            }
            return kq;
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTraTruocKhiLuu() == false)
                {
                    return;
                }
                _HoSoLuong = HoSoLuong.NewHoSoLuong(_ThongTinNhanVienTongHop.MaNhanVien);
                _HoSoLuongList.Add(_HoSoLuong);
                HoSoLuong_BindingSource.DataSource = _HoSoLuongList;
                grdu_HoSoLuong.ActiveRow = grdu_HoSoLuong.Rows[_HoSoLuongList.Count - 1];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (_HoSoLuongList != null)
            {
                if (KiemTraTruocKhiLuu() == false)
                    return;
                grdu_HoSoLuong.UpdateData();
                _HoSoLuongList.Update1(NhanVien.GetNhanVien(_ThongTinNhanVienTongHop.MaNhanVien));
                MessageBox.Show(this, _Util.thanhcong, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (_ThongTinNhanVienTongHop != null)
                {
                    _HoSoLuongList = HoSoLuongList.GetHoSoLuongList(_ThongTinNhanVienTongHop.MaNhanVien);
                    HoSoLuong_BindingSource.DataSource = _HoSoLuongList;
                }
            }
            else
            {
                MessageBox.Show(this, _Util.khongcodulieu, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_HoSoLuong.ActiveRow != null)
            {
                grdu_HoSoLuong.DeleteSelectedRows();
            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LayDuLieu();
            if (_ThongTinNhanVienTongHop != null)
            {
                _HoSoLuongList = HoSoLuongList.GetHoSoLuongList(_ThongTinNhanVienTongHop.MaNhanVien);
                HoSoLuong_BindingSource.DataSource = _HoSoLuongList;
            }
        }
        #endregion

        #region InitializeLayout
        private void cmbu_NgachLuongCB_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            cmbu_NgachLuongCB.DisplayLayout.Bands[0].Columns["MaNgachLuongCoBan"].Hidden = true;
            cmbu_NgachLuongCB.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            cmbu_NgachLuongCB.DisplayLayout.Bands[0].Columns["ThoiGianNangBac"].Hidden = true;
            cmbu_NgachLuongCB.DisplayLayout.Bands[0].Columns["DonViThoiGian"].Hidden = true;

            cmbu_NgachLuongCB.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Ngạch Lương Cơ Bản";

            cmbu_NgachLuongCB.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_NgachLuongCB.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Black;
            }
            //màu nền
            this.cmbu_NgachLuongCB.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_NgachLuongCB.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }

        private void cmbu_BacLuongCB_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_BacLuongCB.DisplayLayout.Bands[0].Columns["MaBacLuongCoBan"].Hidden = true;
            cmbu_BacLuongCB.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            cmbu_BacLuongCB.DisplayLayout.Bands[0].Columns["MaNgachLuongCB"].Hidden = true;
            cmbu_BacLuongCB.DisplayLayout.Bands[0].Columns["HeSoLuong"].Hidden = true;

            cmbu_BacLuongCB.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Bậc Lương CB";

            cmbu_BacLuongCB.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_BacLuongCB.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Black;
            }
            //màu nền
            this.cmbu_BacLuongCB.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_BacLuongCB.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }

        private void grdu_HoSoLuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            grdu_HoSoLuong.DisplayLayout.Bands[0].Columns["MaHeSoLuong"].Hidden = true;
            grdu_HoSoLuong.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grdu_HoSoLuong.DisplayLayout.Bands[0].Columns["MaNgachLuongCB"].Hidden = true;
            grdu_HoSoLuong.DisplayLayout.Bands[0].Columns["MaBacLuongCB"].Hidden = true;
            grdu_HoSoLuong.DisplayLayout.Bands[0].Columns["MaNgachLuongKD"].Hidden = true;
            grdu_HoSoLuong.DisplayLayout.Bands[0].Columns["MaBacLuongKD"].Hidden = true;
            grdu_HoSoLuong.DisplayLayout.Bands[0].Columns["HeSoLuongKD"].Hidden = true;
            grdu_HoSoLuong.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Hidden = true;
            grdu_HoSoLuong.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = true;

            grdu_HoSoLuong.DisplayLayout.Bands[0].Columns["MaQLNgachLuongCB"].Header.Caption = "Ngạch Lương";
            grdu_HoSoLuong.DisplayLayout.Bands[0].Columns["MaQLNgachLuongCB"].Header.VisiblePosition = 1;
            grdu_HoSoLuong.DisplayLayout.Bands[0].Columns["MaQLNgachLuongCB"].Width = 100;

            grdu_HoSoLuong.DisplayLayout.Bands[0].Columns["MaQLBacLuongCB"].Header.Caption = "Bậc Lương";
            grdu_HoSoLuong.DisplayLayout.Bands[0].Columns["MaQLBacLuongCB"].Header.VisiblePosition = 2;
            grdu_HoSoLuong.DisplayLayout.Bands[0].Columns["MaQLBacLuongCB"].Width = 100;

            grdu_HoSoLuong.DisplayLayout.Bands[0].Columns["NgayBatDau"].Header.Caption = "Ngày Bắt Đầu";
            grdu_HoSoLuong.DisplayLayout.Bands[0].Columns["NgayBatDau"].Header.VisiblePosition = 4;
            grdu_HoSoLuong.DisplayLayout.Bands[0].Columns["NgayBatDau"].Width = 100;            

            grdu_HoSoLuong.DisplayLayout.Bands[0].Columns["HeSoLuongCB"].Header.Caption = "HSL CB";
            grdu_HoSoLuong.DisplayLayout.Bands[0].Columns["HeSoLuongCB"].Header.VisiblePosition = 3;
            grdu_HoSoLuong.DisplayLayout.Bands[0].Columns["HeSoLuongCB"].Width = 100;



            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_HoSoLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Black;
            }
            //màu nền
            this.grdu_HoSoLuong.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.grdu_HoSoLuong.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}