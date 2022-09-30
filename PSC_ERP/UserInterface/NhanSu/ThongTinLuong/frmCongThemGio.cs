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
    public partial class frmCongThemGio : Form
    {
        #region Properties
        static ThongTinNhanVienTongHop _ThongTinNhanVienTongHop;
        CongThemGioList _CongThemGioList;
        CongThemGio _CongThemGio;
        CacLoaiCongList _CacLoaiCongList;
        Util _Util = new Util();
        #endregion

        #region Events
        public frmCongThemGio()
        {
            InitializeComponent();
            LayDuLieuLenLuoi();

            toolStripLabel1.Visible = false;
            tlslblIn.Visible = false;
            tlslblThem.Enabled = false;
            tlslblLuu.Enabled = false;
            tlslblUndo.Enabled = false;
            tlslblXoa.Enabled = false;
        }

        private void LayDuLieuLenLuoi()
        {
            _CacLoaiCongList = CacLoaiCongList.GetCacLoaiCongList();
            CacLoaiCong_BindingSource.DataSource = _CacLoaiCongList;
        }

        private void Load()
        {
            _CongThemGioList = CongThemGioList.GetCongThemGioList(_ThongTinNhanVienTongHop.MaNhanVien);
            CongThemGio_BindingSource.DataSource = _CongThemGioList;
        }

        public frmCongThemGio(ThongTinNhanVienTongHop thongTinNhanVienTongHop)
        {
            InitializeComponent();
            _ThongTinNhanVienTongHop = thongTinNhanVienTongHop;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            frmTimNhanVien _frmTimNhanVien = new frmTimNhanVien(22);
            if (_frmTimNhanVien.ShowDialog(this) != DialogResult.OK)
            {
                if (_ThongTinNhanVienTongHop != null)
                {
                    _CongThemGioList = CongThemGioList.GetCongThemGioList(_ThongTinNhanVienTongHop.MaNhanVien);
                    CongThemGio_BindingSource.DataSource = _CongThemGioList;

                    txtu_TenNhanVien.Text = _ThongTinNhanVienTongHop.TenNhanVien.ToString();
                    txtu_MaNhanVien.Value = _ThongTinNhanVienTongHop.MaNhanVien;
                    txtu_MaNhanVienQL.Text = _ThongTinNhanVienTongHop.MaQLNhanVien.ToString();
                    txtu_TenNguoiLap.Text = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(96).TenNhanVien;

                    tlslblThem.Enabled = true;
                    tlslblLuu.Enabled = true;
                    tlslblUndo.Enabled = true;
                    tlslblXoa.Enabled = true;
                }
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (_CongThemGioList != null)
                {
                    grdu_QuaTrinhCongThemGio.UpdateData();
                    _CongThemGioList.ApplyEdit();
                    _CongThemGioList.Save();
                    MessageBox.Show(this, _Util.thanhcong, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load();
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

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            try
            {
                _CongThemGio = CongThemGio.NewCongThemGio(_ThongTinNhanVienTongHop.MaNhanVien);
                _CongThemGioList.Add(_CongThemGio);
                CongThemGio_BindingSource.DataSource = _CongThemGioList;
                grdu_QuaTrinhCongThemGio.ActiveRow = grdu_QuaTrinhCongThemGio.Rows[_CongThemGioList.Count - 1];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdu_QuaTrinhCongThemGio.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            Load();
        }
        #endregion

        #region InitializeLayout
        private void grdu_QuaTrinhCongThemGio_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            grdu_QuaTrinhCongThemGio.DisplayLayout.Bands[0].Columns["MaCongThemGio"].Hidden = true;
            grdu_QuaTrinhCongThemGio.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grdu_QuaTrinhCongThemGio.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;
            grdu_QuaTrinhCongThemGio.DisplayLayout.Bands[0].Columns["MaCacLoaiCong"].Hidden = true;
            grdu_QuaTrinhCongThemGio.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = true;

            grdu_QuaTrinhCongThemGio.DisplayLayout.Bands[0].Columns["NgayChamCong"].Header.Caption = "Ngày Chấm Công";
            grdu_QuaTrinhCongThemGio.DisplayLayout.Bands[0].Columns["NgayChamCong"].Header.VisiblePosition = 1;
            grdu_QuaTrinhCongThemGio.DisplayLayout.Bands[0].Columns["NgayChamCong"].Width = 100;

            grdu_QuaTrinhCongThemGio.DisplayLayout.Bands[0].Columns["TenCacLoaiCong"].Header.Caption = "Tên Các Loại Công";
            grdu_QuaTrinhCongThemGio.DisplayLayout.Bands[0].Columns["TenCacLoaiCong"].Header.VisiblePosition = 2;
            grdu_QuaTrinhCongThemGio.DisplayLayout.Bands[0].Columns["TenCacLoaiCong"].Width = 180;

            grdu_QuaTrinhCongThemGio.DisplayLayout.Bands[0].Columns["SoGio"].Header.Caption = "Số Giờ";
            grdu_QuaTrinhCongThemGio.DisplayLayout.Bands[0].Columns["SoGio"].Header.VisiblePosition = 3;
            grdu_QuaTrinhCongThemGio.DisplayLayout.Bands[0].Columns["SoGio"].Width = 60;

            grdu_QuaTrinhCongThemGio.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            grdu_QuaTrinhCongThemGio.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 4;
            grdu_QuaTrinhCongThemGio.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 200;

            ////grdu_QuaTrinhCongThemGio.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            ////this.grdu_QuaTrinhCongThemGio.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_QuaTrinhCongThemGio.DisplayLayout.Bands[0].Columns)
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
    }
}