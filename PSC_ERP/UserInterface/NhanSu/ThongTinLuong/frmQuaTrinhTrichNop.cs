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
    public partial class frmQuaTrinhTrichNop : Form
    {
        #region Properties
        QuaTrinhTrichNopList _QuaTrinhTrichNopList;
        QuaTrinhTrichNop _QuaTrinhTrichNop;
        LoaiTrichNopList _LoaiTrichNopList;
        HinhThucTrichNopList _HinhThucTrichNopList;
        static ThongTinNhanVienTongHop _ThongTinNhanVienTongHop;
        static long MaNhanVien;
        Util _Util = new Util();
        static Decimal TongTien;
        #endregion

        #region Events
        public frmQuaTrinhTrichNop()
        {
            InitializeComponent();
        }

        public frmQuaTrinhTrichNop(ThongTinNhanVienTongHop thongTinNhanVienTongHop)
        {
            InitializeComponent();
            _ThongTinNhanVienTongHop = thongTinNhanVienTongHop;
        }

        private void LayDuLieuLenLuoi()
        {
            _LoaiTrichNopList = LoaiTrichNopList.GetLoaiTrichNopList();
            LoaiTrichNop_BindingSource.DataSource = _LoaiTrichNopList;

            _HinhThucTrichNopList = HinhThucTrichNopList.GetHinhThucTrichNopList();
            HinhThucTrichNop_BindingSource.DataSource = _HinhThucTrichNopList;

            tlslblIn.Visible = false;
        }

        private void LayQuaTrinhTrichNop()
        {
            _QuaTrinhTrichNopList = QuaTrinhTrichNopList.GetQuaTrinhTrichNopList(_ThongTinNhanVienTongHop.MaNhanVien);
            QuaTrinhTrichNop_BindingSource.DataSource = _QuaTrinhTrichNopList;
        }

        private bool KiemTraTruocKhiLuu()
        {
            bool kq = true;
            foreach (Control control in gbx_QuaTrinhTrichNop.Controls)
            {
                if (errorProvider1.GetError(control) != String.Empty)
                {
                    if (control.Name == dtmp_NgayTrichNop.Name)
                    {
                        MessageBox.Show(this, _Util.vuilongnhapngaytrichnop, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Focus();
                        kq = false;
                        return kq;
                    }
                }
            }
            return kq;
        }

        private void frmTrichNop_Load(object sender, EventArgs e)
        {
            LayDuLieuLenLuoi();
            toolStripLabel1.Visible = false;
            tlslblIn.Visible = false;
            tlslblThem.Enabled = false;
            tlslblLuu.Enabled = false;
            tlslblUndo.Enabled = false;
            tlslblXoa.Enabled = false;
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTraTruocKhiLuu() == false)
                {
                    return;
                }
                MaNhanVien = Convert.ToInt64(txtu_MaNhanVien.Value);
                _QuaTrinhTrichNop = QuaTrinhTrichNop.NewQuaTrinhTrichNop(MaNhanVien);
                _QuaTrinhTrichNopList.Add(_QuaTrinhTrichNop);
                QuaTrinhTrichNop_BindingSource.DataSource = _QuaTrinhTrichNopList;
                grdu_QuaTrinhTrichNop.ActiveRow = grdu_QuaTrinhTrichNop.Rows[_QuaTrinhTrichNopList.Count - 1];
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
                if (_QuaTrinhTrichNopList != null)
                {
                    if (KiemTraTruocKhiLuu() == false)
                        return;
                    grdu_QuaTrinhTrichNop.UpdateData();
                    _QuaTrinhTrichNopList.ApplyEdit();
                    _QuaTrinhTrichNopList.Save();
                    MessageBox.Show(this, _Util.thanhcong, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LayQuaTrinhTrichNop();
                }
                else
                {
                    MessageBox.Show(this, _Util.khongcodulieu, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdu_QuaTrinhTrichNop.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LayQuaTrinhTrichNop();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            frmTimNhanVien _frmTimNhanVien = new frmTimNhanVien(4);
            if (_frmTimNhanVien.ShowDialog(this) != DialogResult.OK)
            {
                if (_ThongTinNhanVienTongHop != null)
                {
                    _QuaTrinhTrichNopList = QuaTrinhTrichNopList.GetQuaTrinhTrichNopList(_ThongTinNhanVienTongHop.MaNhanVien);
                    QuaTrinhTrichNop_BindingSource.DataSource = _QuaTrinhTrichNopList;
                    txtu_TenNhanVien.Text = _ThongTinNhanVienTongHop.TenNhanVien.ToString();
                    txtu_MaNhanVien.Value = _ThongTinNhanVienTongHop.MaNhanVien;
                    txtu_MaNhanVienQL.Text = _ThongTinNhanVienTongHop.MaQLNhanVien.ToString();
                    //crceu_LuongCB.Value = _ThongTinNhanVienTongHop.LuongCB;

                    tlslblThem.Enabled = true;
                    tlslblLuu.Enabled = true;
                    tlslblUndo.Enabled = true;
                    tlslblXoa.Enabled = true;
                }
            }
        }
        #endregion

        #region grdu_QuaTrinhTrichNop_InitializeLayout
        private void grdu_QuaTrinhTrichNop_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["MaQuaTrinhTrichNop"].Hidden = true;
            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["MaLoaiTrichNop"].Hidden = true;
            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["MaHinhThucTrichNop"].Hidden = true;
            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;
            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = true;
            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Hidden = true;
            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["HeSoTrichNopV2"].Hidden = true;

            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["NgayTrichNop"].Header.Caption = "Ngày Trích Nộp";
            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["NgayTrichNop"].Header.VisiblePosition = 0;
            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["NgayTrichNop"].Width = 80;

            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["TenLoaiTrichNop"].Header.Caption = "Tên Lọai Trích Nộp";
            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["TenLoaiTrichNop"].Header.VisiblePosition = 1;
            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["TenLoaiTrichNop"].Width = 100;

            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["TenHinhThucTrichNop"].Header.Caption = "Tên Hình Thức Trích Nộp";
            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["TenHinhThucTrichNop"].Header.VisiblePosition = 1;
            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["TenHinhThucTrichNop"].Width = 100;

            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["HeSoTrichNopV1"].Header.Caption = "Hệ Số V1";
            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["HeSoTrichNopV1"].Header.VisiblePosition = 2;
            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["HeSoTrichNopV1"].Width = 70;

            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["HeSoTrichNopV2"].Header.Caption = "Hệ Số V2";
            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["HeSoTrichNopV2"].Header.VisiblePosition = 3;
            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["HeSoTrichNopV2"].Width = 100;

            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["TongTien"].Header.VisiblePosition = 4;
            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["TongTien"].Width = 100;

            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Ghi Chú";
            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 11;
            grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 100;

            grdu_QuaTrinhTrichNop.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.grdu_QuaTrinhTrichNop.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_QuaTrinhTrichNop.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        #endregion
    }
}
