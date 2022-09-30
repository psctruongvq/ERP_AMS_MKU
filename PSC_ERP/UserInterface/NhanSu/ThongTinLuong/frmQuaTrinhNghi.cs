using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Shared;
using Infragistics.Win;

namespace PSC_ERP
{
    public partial class frmQuaTrinhNghi : Form
    {
        #region Properties
        QuaTrinhNghiList _QuaTrinhNghiList;
        QuaTrinhNghi _QuaTrinhNghi = QuaTrinhNghi.NewQuaTrinhNghi();
        HinhThucNghiList _HinhThucNghiList;
        static ThongTinNhanVienTongHop _ThongTinNhanVienTongHop;
        HamDungChung t = new HamDungChung();
        Util _Util = new Util();
        #endregion

        #region Evenst
        public frmQuaTrinhNghi()
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

        public frmQuaTrinhNghi(ThongTinNhanVienTongHop thongTinNhanVienTongHop)
        {
            InitializeComponent();
            _ThongTinNhanVienTongHop = thongTinNhanVienTongHop;
        }

        private void LayDuLieu()
        {
            try
            {
                _HinhThucNghiList = HinhThucNghiList.GetHinhThucNghiList();
                HinhThucNghi_BindingSource.DataSource = _HinhThucNghiList;
            }
            catch (ApplicationException)
            {

            }
        }

        private void LayQuaTrinhNghi()
        {
            try
            {
                _QuaTrinhNghiList = QuaTrinhNghiList.GetQuaTrinhNghiList(_ThongTinNhanVienTongHop.MaNhanVien);
                QuaTrinhNghi_BindingSource.DataSource = _QuaTrinhNghiList;
            }
            catch (ApplicationException)
            {

            }
        }

        private bool KiemTraTruocKhiLuu()
        {
            bool kq = true;
            foreach (Control control in gbx_QuaTrinhNghiViec.Controls)
            {
                if (errorProvider1.GetError(control) != String.Empty)
                {
                    if (control.Name == cmbu_HinhThucNghi.Name)
                    {
                        MessageBox.Show(this, "Vui Lòng Chọn Hình Thức Nghỉ", _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                //MaNhanVien = Convert.ToInt64(txtu_MaNhanVien.Value);
                _QuaTrinhNghi = QuaTrinhNghi.NewQuaTrinhNghi(_ThongTinNhanVienTongHop.MaNhanVien);
                _QuaTrinhNghiList.Add(_QuaTrinhNghi);
                QuaTrinhNghi_BindingSource.DataSource = _QuaTrinhNghiList;
                grdu_QuaTrinhTrichNghi.ActiveRow = grdu_QuaTrinhTrichNghi.Rows[_QuaTrinhNghiList.Count - 1];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (_QuaTrinhNghiList != null)
                {
                    if (KiemTraTruocKhiLuu() == false)
                        return;
                    grdu_QuaTrinhTrichNghi.UpdateData();
                    _QuaTrinhNghiList.ApplyEdit();
                    _QuaTrinhNghiList.Save();
                    MessageBox.Show(this, _Util.thanhcong, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LayQuaTrinhNghi();
                }
                else
                {
                    MessageBox.Show(this, _Util.khongcodulieu, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Ngày Hôm Nay Đã Xin Nghỉ", _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LayQuaTrinhNghi();
                MessageBox.Show(this, _Util.luuthatbai, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_QuaTrinhTrichNghi.ActiveRow != null)
            {
                grdu_QuaTrinhTrichNghi.DeleteSelectedRows();
            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LayQuaTrinhNghi();
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            frmTimNhanVien _frmTimNhanVien = new frmTimNhanVien(5);
            if (_frmTimNhanVien.ShowDialog(this) != DialogResult.OK)
            {
                if (_ThongTinNhanVienTongHop != null)
                {
                    _QuaTrinhNghiList = QuaTrinhNghiList.GetQuaTrinhNghiList(_ThongTinNhanVienTongHop.MaNhanVien);
                    QuaTrinhNghi_BindingSource.DataSource = _QuaTrinhNghiList;

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

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbu_HinhThucNghi_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_HinhThucNghi.Value != null)
            {
                if ((int)cmbu_HinhThucNghi.Value == 3)
                {
                    numeu_SoGioNghi.Value = 4;
                    _QuaTrinhNghi.SoGioNghi = 4;
                    numeu_SoGioNghi.ReadOnly = false;
                }
                else
                {
                    numeu_SoGioNghi.Value = 8;
                    _QuaTrinhNghi.SoGioNghi = 8;
                    numeu_SoGioNghi.ReadOnly = true;
                }
            }
        }
        #endregion

        #region grdu_QuaTrinhTrichNghi_InitializeLayout
        private void grdu_QuaTrinhTrichNghi_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["MaQuaTrinhNghi"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["MaHinhThucNghi"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["NgayNghi"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["SoTienHuong"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TinhTrang"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["SuDung"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["LuongTinh"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["Giahan"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = true;

            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TuNgay"].Header.Caption = "Từ Ngày";
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TuNgay"].Header.VisiblePosition = 1;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TuNgay"].Width = 80;

            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["DenNgay"].Header.Caption = "Đến Ngày";
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["DenNgay"].Header.VisiblePosition = 2;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["DenNgay"].Width = 80;

            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["SoGioNghi"].Header.Caption = "Số Giờ Nghỉ";
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["SoGioNghi"].Header.VisiblePosition = 3;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["SoGioNghi"].Width = 80;

            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TenHinhThucNghi"].Header.Caption = "Hình Thức Nghỉ";
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TenHinhThucNghi"].Header.VisiblePosition = 4;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TenHinhThucNghi"].Width = 120;

            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TruChuyenCan"].Header.Caption = "Trừ Chuyên Cần";
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TruChuyenCan"].Header.VisiblePosition = 9;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TruChuyenCan"].Width = 100;

            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["LyDo"].Header.Caption = "Lý Do";
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["LyDo"].Header.VisiblePosition = 10;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["LyDo"].Width = 233;

            grdu_QuaTrinhTrichNghi.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.grdu_QuaTrinhTrichNghi.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;

                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
            }
        }
        #endregion

        private void tlslblIn_Click(object sender, EventArgs e)
        {

        }


    }
}