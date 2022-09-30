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
    public partial class frmLichSuBanThan : Form
    {
        #region Properties
        LichSuBanThanList _LichSuBanThanList = LichSuBanThanList.NewLichSuBanThanList();
        LichSuBanThan _LichSuBanThan = LichSuBanThan.NewLichSuBanThan();
        QuaTrinhCongTacList _QuaTrinhCongTacList=QuaTrinhCongTacList.NewQuaTrinhCongTacList();
        QuaTrinhCongTac _QuaTrinhCongTac = QuaTrinhCongTac.NewQuaTrinhCongTac();
        ChucVuList _ChucVuList= ChucVuList.NewChucVuList();
        QuaTrinhSinhHoatDang _QuaTrinhSinhHoatDang=QuaTrinhSinhHoatDang.NewQuaTrinhSinhHoatDang();
        QuaTrinhSinhHoatDangList _QuaTrinhSinhHoatDangList = QuaTrinhSinhHoatDangList.NewQuaTrinhSinhHoatDangList();
        static ThongTinNhanVienTongHop _ThongTinNhanVienTongHop;
        LyDoThoiViecList _LyDoThoiViecList;
        Util _Util = new Util();
        #endregion

        #region Contructor
        public frmLichSuBanThan(int indexTab)
        {
            InitializeComponent();
            tab_Chung.SelectedIndex = indexTab;
            LayDuLieu();

            toolStripLabel1.Visible = false;

            tlslblIn.Visible = false;
            tlslblThem.Enabled = false;
            tlslblLuu.Enabled = false;
            tlslblUndo.Enabled = false;
            tlslblXoa.Enabled = false;
        }

        public frmLichSuBanThan(ThongTinNhanVienTongHop thongTinNhanVienTongHop)
        {
            InitializeComponent();
            _ThongTinNhanVienTongHop = thongTinNhanVienTongHop;
        }
        #endregion

        private void LayDuLieu()
        {
            _ChucVuList = ChucVuList.GetChucVuList(1);
            chucVuListBindingSource.DataSource = _ChucVuList;

            _LyDoThoiViecList = LyDoThoiViecList.GetLyDoThoiViecList();
            LyDoThoiViec_BindingSource.DataSource = _LyDoThoiViecList;
        }

        #region KhoiTao
        public void KhoiTao()
        {
            _LichSuBanThanList = LichSuBanThanList.GetLichSuBanThanList(_ThongTinNhanVienTongHop.MaNhanVien);
            lichSuBanThanListBindingSource.DataSource = _LichSuBanThanList;

            _QuaTrinhCongTacList = QuaTrinhCongTacList.GetQuaTrinhCongTacList(_ThongTinNhanVienTongHop.MaNhanVien);
            quaTrinhCongTacListBindingSource.DataSource = _QuaTrinhCongTacList;

            _QuaTrinhSinhHoatDangList = QuaTrinhSinhHoatDangList.GetQuaTrinhSinhHoatDangList(_ThongTinNhanVienTongHop.MaNhanVien);
            quaTrinhSinhHoatDangListBindingSource.DataSource = _QuaTrinhSinhHoatDangList;
        }
        #endregion

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, _Util.thaoTac, _Util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            if (tab_Chung.SelectedTab.Name == "tabPageLichSuBanThan")
            {
                _LichSuBanThan = LichSuBanThan.NewLichSuBanThan(_ThongTinNhanVienTongHop.MaNhanVien);
                _LichSuBanThanList.Add(_LichSuBanThan);
                lichSuBanThanListBindingSource.DataSource = _LichSuBanThanList;
                grdu_LichSuBanThan.ActiveRow = grdu_LichSuBanThan.Rows[_LichSuBanThanList.Count - 1];
            }
            else if (tab_Chung.SelectedTab.Name == "tabPageQuaTrinhCongTac")
            {
                _QuaTrinhCongTac = QuaTrinhCongTac.NewQuaTrinhCongTac(_ThongTinNhanVienTongHop.MaNhanVien);
                _QuaTrinhCongTacList.Add(_QuaTrinhCongTac);
                quaTrinhCongTacListBindingSource.DataSource = _QuaTrinhCongTacList;
                ultragrdQuaTrinhCongTac.ActiveRow = ultragrdQuaTrinhCongTac.Rows[_QuaTrinhCongTacList.Count - 1];
            }
            else if (tab_Chung.SelectedTab.Name == "tabPageQuaTrinhSinhHoatDang")
            {
                _QuaTrinhSinhHoatDang = QuaTrinhSinhHoatDang.NewQuaTrinhSinhHoatDang(_ThongTinNhanVienTongHop.MaNhanVien);
                _QuaTrinhSinhHoatDangList.Add(_QuaTrinhSinhHoatDang);
                quaTrinhSinhHoatDangListBindingSource.DataSource = _QuaTrinhSinhHoatDangList;
                grdu_QuaTrinhSHDang.ActiveRow = grdu_QuaTrinhSHDang.Rows[_QuaTrinhSinhHoatDangList.Count - 1];
            }
        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (_LichSuBanThanList != null)
                {
                    grdu_LichSuBanThan.UpdateData();
                    _LichSuBanThanList.ApplyEdit();
                    _LichSuBanThanList.Save();
                }
                if (_QuaTrinhCongTacList != null)
                {
                    ultragrdQuaTrinhCongTac.UpdateData();
                    _QuaTrinhCongTacList.ApplyEdit();
                    _QuaTrinhCongTacList.Save();
                }
                if (_QuaTrinhSinhHoatDangList != null)
                {
                    grdu_QuaTrinhSHDang.UpdateData();
                    _QuaTrinhSinhHoatDangList.ApplyEdit();
                    _QuaTrinhSinhHoatDangList.Save();
                }
                MessageBox.Show(this, _Util.thanhcong, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                KhoiTao();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, _Util.thatbai, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw ex;
            }
        }
        #endregion

        #region tlslblXoa_Click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (tab_Chung.SelectedTab.Name == "tabPageLichSuBanThan")
            {
                grdu_LichSuBanThan.DeleteSelectedRows();
            }
            else if (tab_Chung.SelectedTab.Name == "tabPageQuaTrinhCongTac")
            {
                ultragrdQuaTrinhCongTac.DeleteSelectedRows();
            }
            else if (tab_Chung.SelectedTab.Name == "tabPageQuaTrinhSinhHoatDang")
            {
                grdu_QuaTrinhSHDang.DeleteSelectedRows();
            }
        }
        #endregion

        #region tlslblTim_Click
        private void tlslblTim_Click(object sender, EventArgs e)
        {
            frmTimNhanVien _frmTimNhanVien = new frmTimNhanVien(14);
            if (_frmTimNhanVien.ShowDialog(this) != DialogResult.OK)
            {
                if (_ThongTinNhanVienTongHop != null)
                {
                    _LichSuBanThanList = LichSuBanThanList.GetLichSuBanThanList(_ThongTinNhanVienTongHop.MaNhanVien);
                    lichSuBanThanListBindingSource.DataSource = _LichSuBanThanList;

                    _QuaTrinhCongTacList = QuaTrinhCongTacList.GetQuaTrinhCongTacList(_ThongTinNhanVienTongHop.MaNhanVien);
                    quaTrinhCongTacListBindingSource.DataSource = _QuaTrinhCongTacList;

                    _QuaTrinhSinhHoatDangList = QuaTrinhSinhHoatDangList.GetQuaTrinhSinhHoatDangList(_ThongTinNhanVienTongHop.MaNhanVien);
                    quaTrinhSinhHoatDangListBindingSource.DataSource = _QuaTrinhSinhHoatDangList;

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
        #endregion

        #region InitializeLayout
        #region ultragrdLichSuBanThan_InitializeLayout
        private void ultragrdLichSuBanThan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            grdu_LichSuBanThan.DisplayLayout.Bands[0].Columns["MactLichsubanthan"].Hidden = true;
            grdu_LichSuBanThan.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grdu_LichSuBanThan.DisplayLayout.Bands[0].Columns["TuNgay"].Header.Caption = "Từ Ngày";
            grdu_LichSuBanThan.DisplayLayout.Bands[0].Columns["DenNgay"].Header.Caption = "Đến Ngày";
            grdu_LichSuBanThan.DisplayLayout.Bands[0].Columns["CongViec"].Header.Caption = "Làm Gì";
            grdu_LichSuBanThan.DisplayLayout.Bands[0].Columns["NoiLamViec"].Header.Caption = "Ở Đâu";
            grdu_LichSuBanThan.DisplayLayout.Bands[0].Columns["NoiLamViec"].Width = 150;
            grdu_LichSuBanThan.DisplayLayout.Bands[0].Columns["DiaChiNoiO"].Header.Caption = "Địa Chỉ Nơi Ở";
            grdu_LichSuBanThan.DisplayLayout.Bands[0].Columns["DiaChiNoiO"].Width = 200;
            grdu_LichSuBanThan.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            grdu_LichSuBanThan.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 200;

            grdu_LichSuBanThan.DisplayLayout.Bands[0].Columns["TuNgay"].Header.VisiblePosition = 0;
            grdu_LichSuBanThan.DisplayLayout.Bands[0].Columns["DenNgay"].Header.VisiblePosition = 1;
            grdu_LichSuBanThan.DisplayLayout.Bands[0].Columns["CongViec"].Header.VisiblePosition = 2;
            grdu_LichSuBanThan.DisplayLayout.Bands[0].Columns["NoiLamViec"].Header.VisiblePosition = 3;
            grdu_LichSuBanThan.DisplayLayout.Bands[0].Columns["DiaChiNoiO"].Header.VisiblePosition = 4;
            grdu_LichSuBanThan.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 5;


            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_LichSuBanThan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            }
            //màu nền
            //this.grdu_LichSuBanThan.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //this.grdu_LichSuBanThan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

        #region ultragrdQuaTrinhCongTac_InitializeLayout
        private void ultragrdQuaTrinhCongTac_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["MaQuaTrinhCongTac"].Hidden = true;
            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;
            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = true;
            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Hidden = true;

            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["TuNgay"].Header.Caption = "Từ Ngày";
            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["DenNgay"].Header.Caption = "Đến Ngày";
            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["CoQuanCongTac"].Header.Caption = "Cơ Quan Công Tác";
            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["CoQuanCongTac"].Width = 150;
            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["ChucVu"].Header.Caption = "Chức Vụ";
            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["DiaChiCoQuan"].Header.Caption = "Địa Chỉ Cơ Quan";
            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["DiaChiCoQuan"].Width = 200;
            
            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["PhuCap"].Header.Caption = "Phụ Cấp";
            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["LyDoNghiViec"].Header.Caption = "Lý Do Nghĩ Việc";
            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["LyDoNghiViec"].EditorComponent = cmbu_LyDoThoiViec;
            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["ChuThich"].Header.Caption = "Chú Thích";

            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["TuNgay"].Header.VisiblePosition = 0;
            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["DenNgay"].Header.VisiblePosition = 1;
            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["CoQuanCongTac"].Header.VisiblePosition = 2;
            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["ChucVu"].Header.VisiblePosition = 3;
            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["DiaChiCoQuan"].Header.VisiblePosition = 4;
            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["PhuCap"].Header.VisiblePosition = 5;
            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["LyDoNghiViec"].Header.VisiblePosition = 6;
            ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns["ChuThich"].Header.VisiblePosition = 7;
            
            //màu và font chữ
            foreach (UltraGridColumn col in this.ultragrdQuaTrinhCongTac.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
            }
            ////màu nền
            //this.ultragrdQuaTrinhCongTac.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //this.ultragrdQuaTrinhCongTac.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

        #region grdu_QuaTrinhSHDang_InitializeLayout
        private void grdu_QuaTrinhSHDang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            grdu_QuaTrinhSHDang.DisplayLayout.Bands[0].Columns["MactSinhhoatdang"].Hidden = true;
            grdu_QuaTrinhSHDang.DisplayLayout.Bands[0].Columns["MaChucVuDang"].Hidden = true;
            grdu_QuaTrinhSHDang.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;
            grdu_QuaTrinhSHDang.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = true;
            grdu_QuaTrinhSHDang.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grdu_QuaTrinhSHDang.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Hidden = true;

            grdu_QuaTrinhSHDang.DisplayLayout.Bands[0].Columns["TuNgay"].Header.Caption = "Từ Ngày";
            grdu_QuaTrinhSHDang.DisplayLayout.Bands[0].Columns["DenNgay"].Header.Caption = "Đến Ngày";
            grdu_QuaTrinhSHDang.DisplayLayout.Bands[0].Columns["NoiSinhHoat"].Header.Caption = "Nơi Sinh Hoạt";
            grdu_QuaTrinhSHDang.DisplayLayout.Bands[0].Columns["NoiSinhHoat"].Width = 200;
            grdu_QuaTrinhSHDang.DisplayLayout.Bands[0].Columns["DiaChiNoiSH"].Header.Caption = "Địa Chỉ Nơi Sinh Hoạt";
            grdu_QuaTrinhSHDang.DisplayLayout.Bands[0].Columns["DiaChiNoiSH"].Width = 200;
            grdu_QuaTrinhSHDang.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            grdu_QuaTrinhSHDang.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 200;

            grdu_QuaTrinhSHDang.DisplayLayout.Bands[0].Columns["TuNgay"].Header.VisiblePosition = 0;
            grdu_QuaTrinhSHDang.DisplayLayout.Bands[0].Columns["DenNgay"].Header.VisiblePosition = 1;
            grdu_QuaTrinhSHDang.DisplayLayout.Bands[0].Columns["NoiSinhHoat"].Header.VisiblePosition = 2;
            grdu_QuaTrinhSHDang.DisplayLayout.Bands[0].Columns["DiaChiNoiSH"].Header.VisiblePosition = 3;
            grdu_QuaTrinhSHDang.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 4;
                     
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_QuaTrinhSHDang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
            }
            ////màu nền
            //this.grdu_QuaTrinhSHDang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //this.grdu_QuaTrinhSHDang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

        #region cmbu_ChucVuSH_InitializeLayout
        private void cmbu_ChucVuSH_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_ChucVuSH.DisplayLayout.Bands[0].Columns["MaChucVu"].Hidden = true;
            cmbu_ChucVuSH.DisplayLayout.Bands[0].Columns["MaNhomChucVu"].Hidden = true;
            cmbu_ChucVuSH.DisplayLayout.Bands[0].Columns["TenNhomChucVu"].Hidden = true;

            cmbu_ChucVuSH.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Chức Vụ";
            cmbu_ChucVuSH.DisplayLayout.Bands[0].Columns["MaQLChucVu"].Header.Caption = "Mã Chức Vụ";
            cmbu_ChucVuSH.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.Caption = "Tên Viết Tắt";
            cmbu_ChucVuSH.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";

            cmbu_ChucVuSH.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.VisiblePosition = 0;
            cmbu_ChucVuSH.DisplayLayout.Bands[0].Columns["MaQLChucVu"].Header.VisiblePosition = 1;
            cmbu_ChucVuSH.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.VisiblePosition = 2;
            cmbu_ChucVuSH.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_ChucVuSH.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            }
            //màu nền
            this.cmbu_ChucVuSH.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_ChucVuSH.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion
        #endregion
    }
}