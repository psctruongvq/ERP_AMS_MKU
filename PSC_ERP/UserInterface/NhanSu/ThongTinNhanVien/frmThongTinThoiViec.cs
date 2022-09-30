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
    public partial class frmThongTinThoiViec : Form
    {
        #region Properties
        LoaiQuyetDinhThoiViecList _LoaiQuyetDinhThoiViecList;
        static ThongTinNhanVienTongHop _ThongTinNhanVienTongHop;
        ThongTinNhanVienTongHopList _ThongTinNhanVienTongHopList;
        LyDoThoiViecList _LyDoThoiViecList;
        ThoiViec _ThoiViec;
        ThoiViecList _ThoiViecList;
        NhanVien _NhanVien;
        ChucVuList _ChucVuList;
        Util util = new Util();
        #endregion

        #region Contructor
        public frmThongTinThoiViec()
        {
            InitializeComponent();
            KhoiTao();

            toolStripLabel1.Visible = false;
            tlslblIn.Visible = false;
            tlslblThem.Visible = false;
            toolStripSeparator1.Visible = false;
            tlslblLuu.Enabled = false;
            tlslblUndo.Enabled = false;
            tlslblXoa.Enabled = false;
        }

        public frmThongTinThoiViec(ThongTinNhanVienTongHop thongTinNhanVienTongHop)
        {
            InitializeComponent();
            _ThongTinNhanVienTongHop = thongTinNhanVienTongHop;
        }
        #endregion

        #region Events

        #region KhoiTao
        public void KhoiTao()
        {
            _LoaiQuyetDinhThoiViecList = LoaiQuyetDinhThoiViecList.GetLoaiQuyetDinhThoiViecList();
            loaiQuyetDinhThoiViecListBindingSource.DataSource = _LoaiQuyetDinhThoiViecList;

            _ChucVuList = ChucVuList.GetChucVuList(4);
            ChucVu_BindingSource.DataSource = _ChucVuList;

            _LyDoThoiViecList = LyDoThoiViecList.GetLyDoThoiViecList();
            lyDoThoiViecListBindingSource.DataSource = _LyDoThoiViecList;
        }
        #endregion

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, util.thaoTac, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion

        #region tlslblTim_Click
        private void tlslblTim_Click(object sender, EventArgs e)
        {
            frmTimNhanVien _frmTimNhanVien = new frmTimNhanVien(6);
            if (_frmTimNhanVien.ShowDialog(this) != DialogResult.OK)
            {
                if (_ThongTinNhanVienTongHop != null)
                {
                    _NhanVien=NhanVien.GetNhanVien(_ThongTinNhanVienTongHop.MaNhanVien);

                    _ThoiViecList = ThoiViecList.GetThoiViecList(_ThongTinNhanVienTongHop.MaNhanVien);
                    _ThoiViec = ThoiViec.NewThoiViec(_ThongTinNhanVienTongHop.MaNhanVien);
                    _ThoiViecList.Add(_ThoiViec);
                    thoiViecListBindingSource.DataSource = _ThoiViecList;
                    grdu_DSThoiViec.ActiveRow = grdu_DSThoiViec.Rows[0];

                    txtu_TenNhanVien.Text = _NhanVien.TenNhanVien.ToString();
                    txtu_MaNhanVien.Value = _NhanVien.MaNhanVien;
                    txtu_MaNhanVienQL.Text = _NhanVien.MaQLNhanVien.ToString();
                    dtmp_NgayVaoNganh.Value = _NhanVien.NgayVaoNganh;
                    dtmp_NgayVaoBienChe.Value = _NhanVien.NgayTinhThamNien;
                    txt_ChucDanh.Text = ChucDanh.GetChucDanh(_NhanVien.MaChucDanh).TenChucDanh.ToString();
                    txt_ChucVu.Text = _NhanVien.TenChucVu.ToString();
                    cmbu_ChucVuNguoiKy.Text = "Chọn chức vụ người ký";
                    cmbu_LoaiQuyetDinh.Text = "Chọn loại quyết định";
                    cmbu_NguoiKy.Text = "Chọn người ký quyết định";
                    cmbu_LyDo.Text = "Chọn lý do thôi việc";

                    tlslblLuu.Enabled = true;
                    tlslblUndo.Enabled = true;
                    tlslblXoa.Enabled = true;

                }
            }
        }
        #endregion

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            try
            {
                _ThoiViec = ThoiViec.NewThoiViec(_ThongTinNhanVienTongHop.MaNhanVien);
                _ThoiViecList.Add(_ThoiViec);
                thoiViecListBindingSource.DataSource = _ThoiViecList;
                grdu_DSThoiViec.ActiveRow = grdu_DSThoiViec.Rows[_ThoiViecList.Count - 1];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region KT
        bool KT()
        {
            bool kq = false;
            if (txtu_MaNhanVienQL.Text != null)
            {
                kq = true;
            }
            else
            {
                MessageBox.Show(this, "Chưa Chọn Nhân Viên", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtu_MaNhanVienQL.Focus();
                kq = false;
                return kq;
            }
            return kq;
        }
        #endregion

        #region KTSoQuyetDinhLuu
        private void KTSoQuyetDinhLuu()
        {
            if (ThoiViec.KiemTraSoQuyetDinh(txtu_SoQuyetDinh.Text) != 0)
            {
                MessageBox.Show(this, "Số Quyết Định Bị Trùng", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtu_SoQuyetDinh.Text = string.Empty;
                txtu_SoQuyetDinh.Focus();
            }
            
        }
        #endregion

        #region KTSoQuyetDinhCapNhat
        private void KTSoQuyetDinhCapNhat()
        {
            if (ThoiViec.KiemTraSoQuyetDinh(txtu_SoQuyetDinh.Text) == 1)
            {
                MessageBox.Show(this, "Số Quyết Định Đã Tồn Tại", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtu_SoQuyetDinh.Text = string.Empty;
                txtu_SoQuyetDinh.Focus();
            }
        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ThoiViec.IsNew == true)
                {
                    KTSoQuyetDinhLuu();
                    _ThoiViecList.ApplyEdit();
                    _ThoiViecList.Save();
                    MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    KTSoQuyetDinhCapNhat();
                    _ThoiViecList.ApplyEdit();
                    _ThoiViecList.Save();
                    MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, util.thatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                string tem = ex.Message;
            }
        }
        #endregion      

        #region tlslblXoa_Click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_DSThoiViec.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grdu_DSThoiViec.DeleteSelectedRows();
        }
        #endregion

        #region cmbu_ChucVuNguoiKy_ValueChanged
        private void cmbu_ChucVuNguoiKy_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_ChucVuNguoiKy.Value != null)
            {
                    _ThongTinNhanVienTongHopList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_ChucVu((int)cmbu_ChucVuNguoiKy.Value);
                tenNhanVienListBindingSource.DataSource = _ThongTinNhanVienTongHopList;
            }
        }
        #endregion
        #endregion

        #region InitializeLayout
        #region cmbu_LoaiQuyetDinh_InitializeLayout
        private void cmbu_LoaiQuyetDinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_LoaiQuyetDinh.DisplayLayout.Bands[0].Columns["MaLoaiQuyetDinh"].Hidden = true;
            cmbu_LoaiQuyetDinh.DisplayLayout.Bands[0].Columns["Loai"].Hidden = true;
            cmbu_LoaiQuyetDinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = true;

            cmbu_LoaiQuyetDinh.DisplayLayout.Bands[0].Columns["TenLoaiQuyetDinh"].Header.Caption = "Tên Loại Quyết Định";
            cmbu_LoaiQuyetDinh.DisplayLayout.Bands[0].Columns["TenLoaiQuyetDinh"].Header.VisiblePosition = 1;
            cmbu_LoaiQuyetDinh.DisplayLayout.Bands[0].Columns["TenLoaiQuyetDinh"].Width = 180;
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_LoaiQuyetDinh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            }
            //màu nền
            this.cmbu_LoaiQuyetDinh.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_LoaiQuyetDinh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

        #region cmbu_NguoiKy_InitializeLayout
        private void cmbu_NguoiKy_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["MaChucVu"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["MaChucDanh"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["TenChucVu"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["MaBoPhan"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["PhanTramBHXH"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["TienBHXH"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["PhanTramBHYT"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["TienBHYT"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["SoTienCongDoan"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["CardID"].Hidden = true;

            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["SoNgayLamViec"].Hidden = true;

            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["NgayVaoLam"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["GioiTinh"].Hidden = true;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["CMND"].Hidden = true;

            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Nhân Viên";
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 0;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Width = 100;

            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            cmbu_NguoiKy.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 200;

            cmbu_NguoiKy.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.cmbu_NguoiKy.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.cmbu_NguoiKy.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        #endregion

        #region cmbu_LyDo_InitializeLayout
        private void cmbu_LyDo_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_LyDo.DisplayLayout.Bands[0].Columns["MaLyDoThoiViec"].Hidden = true;
            cmbu_LyDo.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = true;

            cmbu_LyDo.DisplayLayout.Bands[0].Columns["LyDo"].Header.Caption = "Lý Do";
            cmbu_LyDo.DisplayLayout.Bands[0].Columns["LyDo"].Header.VisiblePosition = 1;
            cmbu_LyDo.DisplayLayout.Bands[0].Columns["LyDo"].Width = 210;
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_LyDo.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            }
            //màu nền
            this.cmbu_LyDo.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_LyDo.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

        #region grdu_DSThoiViec_InitializeLayout
        private void grdu_DSThoiViec_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["MaThoiViec"].Hidden = true;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["NgayKy"].Hidden = true;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["NguoiKy"].Hidden = true;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["MaChucVuNguoiKy"].Hidden = true;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = true;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["MaLoaiQuyetDinh"].Hidden = true;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["MaLyDoThoiViec"].Hidden = true;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = true;

            //grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TenLoaiQuyetDinh"].Header.Caption = "Loại Quyết Định Thôi Việc";
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TenLyDoThoiViec"].Header.Caption = "Lý Do Thôi Việc";
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.Caption = "Số Quyết Định";
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Header.Caption = "Ngày Hiệu Lực";
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TroCapThoiViec"].Header.Caption = "Trợ Cấp Thôi Việc";
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TroCapKhac"].Header.Caption = "Trợ Cấp Khác";
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";

            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 0;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TenLoaiQuyetDinh"].Header.VisiblePosition = 1;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TenLyDoThoiViec"].Header.VisiblePosition = 2;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.VisiblePosition = 3;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Header.VisiblePosition = 4;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TroCapThoiViec"].Header.VisiblePosition = 5;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["TroCapKhac"].Header.VisiblePosition = 6;
            grdu_DSThoiViec.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 7;            

            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_DSThoiViec.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy

                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
            }
            //màu nền
            this.grdu_DSThoiViec.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.grdu_DSThoiViec.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

        #region cmbu_ChucVuNguoiKy_InitializeLayout
        private void cmbu_ChucVuNguoiKy_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_ChucVuNguoiKy.DisplayLayout.Bands[0].Columns["MaChucVu"].Hidden = true;
            cmbu_ChucVuNguoiKy.DisplayLayout.Bands[0].Columns["MaQLChucVu"].Hidden = true;
            cmbu_ChucVuNguoiKy.DisplayLayout.Bands[0].Columns["TenVietTat"].Hidden = true;
            cmbu_ChucVuNguoiKy.DisplayLayout.Bands[0].Columns["MaNhomChucVu"].Hidden = true;
            cmbu_ChucVuNguoiKy.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            cmbu_ChucVuNguoiKy.DisplayLayout.Bands[0].Columns["TenNhomChucVu"].Hidden = true;

            cmbu_ChucVuNguoiKy.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Chức Vụ";
            cmbu_ChucVuNguoiKy.DisplayLayout.Bands[0].Columns["TenChucVu"].Width = 170;

            foreach (UltraGridColumn col in this.cmbu_ChucVuNguoiKy.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            }
            this.cmbu_ChucVuNguoiKy.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_ChucVuNguoiKy.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion
        #endregion
    }
}