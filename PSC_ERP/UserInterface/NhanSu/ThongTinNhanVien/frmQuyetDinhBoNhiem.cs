using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Csla;
using Infragistics.Win;
using Infragistics.Shared;
using Infragistics.Win.UltraWinGrid;
namespace PSC_ERP
{
    public partial class frmQuyetDinhBoNhiem : Form
    {
        Util util = new Util();
        BoPhanList _BoPhanList = BoPhanList.NewBoPhanList();
        ChucVuList _ChucVuList = ChucVuList.NewChucVuList();
        LoaiQuyetDinhList _LoaiQD = LoaiQuyetDinhList.NewLoaiQuyetDinhList();
        ThongTinNhanVienTongHopList _Nguoiky = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
        ThongTinNhanVienTongHopList _NhanVien = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
        QuyetDinhBoNhiem _QDBoNhiem;
        ChucVuList _ChucvuMoiList = ChucVuList.NewChucVuList();
        BoPhanList _BoPhanMoi = BoPhanList.NewBoPhanList();
        ChuyenMonNghiepVuClassList _CMNVmoi = ChuyenMonNghiepVuClassList.NewChuyenMonNghiepVuClassList();
        int _maQD = 0;
        public frmQuyetDinhBoNhiem()
        {
            InitializeComponent();
            this.Load_Source();
        }
        public frmQuyetDinhBoNhiem(int _MaQd)
        {
            InitializeComponent();
            this._maQD = _MaQd;
            this.Load_Source();
        }

        #region Load
        private void Load_Source()
        {
            _BoPhanList = BoPhanList.GetBoPhanList();
            BindS_BoPhan.DataSource = _BoPhanList;
            _LoaiQD = LoaiQuyetDinhList.GetLoaiQuyetDinhList();
            BindS_LoaiQD.DataSource = _LoaiQD;
            _ChucVuList = ChucVuList.GetChucVuList();
            BindS_ChucVu.DataSource = _ChucVuList;
            if (_maQD.Equals(0))
            {
                _QDBoNhiem = QuyetDinhBoNhiem.NewQuyetDinhBoNhiem();
                BindS_QDBoNhiem.DataSource = _QDBoNhiem;
                lblTdaky.Text = "Tổng Số : " + _QDBoNhiem.QuyetDinhBoNhiem_CTList.Count;
            }
            else
            {
                _QDBoNhiem = QuyetDinhBoNhiem.GetQuyetDinhBoNhiem(_maQD);
                BindS_QDBoNhiem.DataSource = _QDBoNhiem;
                lblTdaky.Text = "Tổng Số : " + _QDBoNhiem.QuyetDinhBoNhiem_CTList.Count;
            }
            _ChucvuMoiList = ChucVuList.GetChucVuListAll();
            BindS_ChucVuMoi.DataSource = _ChucvuMoiList;

            _BoPhanMoi = BoPhanList.GetBoPhanList();
            BindS_BoPhanMoi.DataSource = _BoPhanMoi;

            _CMNVmoi = ChuyenMonNghiepVuClassList.GetChuyenMonNghiepVuClassList();
            BindS_ChyenMonMoi.DataSource = _CMNVmoi;
        }

        private void cmbu_ChucVu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_ChucVu.DisplayLayout.Bands[0],
             new string[2] { "TenChucvu", "Machucvu" },
             new string[2] { "Chức Vụ", "maso" },
             new int[2] {  cmbu_ChucVu.Width,10 },
             new Control[2] { null, null },
             new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
             new bool[2] { false, false });
            cmbu_ChucVu.DisplayLayout.Bands[0].Columns["TenChucvu"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_ChucVu.DisplayLayout.Bands[0].Columns["Machucvu"].Hidden = true;
        }

        private void cmbu_Nguoiky_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_Nguoiky.DisplayLayout.Bands[0],
             new string[2] { "MaQLNHanvien", "Tennhanvien" },
             new string[2] { "Mã Số", "Họ Tên" },
             new int[2] { 100, cmbu_Nguoiky.Width - 100 },
             new Control[2] { null, null },
             new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
             new bool[2] { false, false });
            cmbu_Nguoiky.DisplayLayout.Bands[0].Columns["MaQLNHanvien"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_Nguoiky.DisplayLayout.Bands[0].Columns["Tennhanvien"].CellAppearance.TextHAlign = HAlign.Left;

        }

        private void cmbu_Bophan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_Bophan.DisplayLayout.Bands[0],
            new string[2] { "Tenbophan", "mabophan" },
            new string[2] { "Bộ Phận", "Mã bộ phận" },
            new int[2] { cmbu_Bophan.Width, 90 },
            new Control[2] { null, null },
            new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[2] { false, false });
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["Tenbophan"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["mabophan"].Hidden = true;
        }

        private void cmbu_LoaiQD_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_LoaiQD.DisplayLayout.Bands[0],
            new string[2] { "TenLoaiQuyetDinh", "maLoaiQuyetDinh" },
            new string[2] { "Loại Quyết Định", "maso" },
            new int[2] { cmbu_LoaiQD.Width ,0 },
            new Control[2] { null, null },
            new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[2] { false, false });
            cmbu_LoaiQD.DisplayLayout.Bands[0].Columns["TenLoaiQuyetDinh"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_LoaiQD.DisplayLayout.Bands[0].Columns["maLoaiQuyetDinh"].Hidden = true;
        }

        private void grdu_DSQuyetDinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_ChucVumoi.Visible = false;
            cmbu_BoPhanmoi.Visible = false;
            cmbu_NhanVien.Visible = false;
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);
            
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["maquyetdinh"].Hidden = true;
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["Machitiet"].Hidden = true;

            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = true;
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["machucvucu"].Hidden = true;
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["TenChuCdanhCu"].Hidden = true;
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["MaPhongBancu"].Hidden = true;            

            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["machucdanhcu"].Hidden = true;
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["machucdanhmoi"].Hidden = true;
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["madonvicu"].Hidden = true;
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["madonvimoi"].Hidden = true;
            
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["machuyenmonnghiepvucu"].Hidden = true;
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["machuyenmonnghiepvumoi"].Hidden = true;
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["TenChuyenmonNghiepVuCu"].Hidden = true;


            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["maNhanVien"].Header.Caption = "Mã Số";
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["maNhanVien"].EditorComponent = cmbu_NhanVien;
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["tennhanvien"].Header.Caption = "Họ Tên";
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["Tenbophancu"].Header.Caption = "Bộ Phận Cũ";
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["TenChucvucu"].Header.Caption = "Chức Vụ Cũ";            


            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["tennhanvien"].CellActivation = Activation.NoEdit;
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["Tenbophancu"].CellActivation = Activation.NoEdit;
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["TenChucvucu"].CellActivation = Activation.NoEdit;         

            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["maphongbanmoi"].Header.Caption = "Bộ Phận Mới";
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["maphongbanmoi"].EditorComponent = cmbu_BoPhanmoi;

         
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["maChucvumoi"].Header.Caption = "Chức Vụ Mới";
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["maChucvumoi"].EditorComponent = cmbu_ChucVumoi;

            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["ManhanVien"].Header.VisiblePosition = 0;
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["tennhanvien"].Header.VisiblePosition = 1;
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["Tenbophancu"].Header.VisiblePosition = 2;
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["TenChucvucu"].Header.VisiblePosition = 3;
            

            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["maphongbanmoi"].Header.VisiblePosition = 6;
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["MaChucvumoi"].Header.VisiblePosition = 7;
            


            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["Manhanvien"].Width = 100;
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["tennhanvien"].Width = 200;
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["Tenbophancu"].Width = 130;
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["TenChucvucu"].Width = 150;
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["maphongbanmoi"].Width = 150;
            grdu_DSQuyetDinh.DisplayLayout.Bands[0].Columns["MaChucvumoi"].Width = 170;
            

            this.grdu_DSQuyetDinh.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.grdu_DSQuyetDinh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }

        private void cmbu_NhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_NhanVien.DisplayLayout.Bands[0],
            new string[6] { "MaQLNHanvien", "Tennhanvien", "mabophan", "TenBoPhan", "maChucvu", "TenChucvu" },
            new string[6] { "Mã Số", "Họ Tên", "mabophan", "Bộ Phận", "machucvu", "Chức Vụ" },
            new int[6] { 100, 170, 50, 100, 50, 100 },
            new Control[6] { null, null, null, null, null, null },
            new KieuDuLieu[6] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[6] { false, false, false, false, false, false });
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNHanvien"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["Tennhanvien"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["TenChucVu"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["mabophan"].Hidden = true;
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["machucvu"].Hidden = true;
        }

        #endregion

        #region Event
        private void cmbu_ChucVu_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_ChucVu.Value != null)
            {
                _Nguoiky = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_ChucVu((int)cmbu_ChucVu.Value);
                BindS_NguoiKy.DataSource = _Nguoiky;
            }
        }

        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_Bophan.Value != null)
            {
                _NhanVien = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_Bophan((int)cmbu_Bophan.Value,0);
                BindS_NhanVien.DataSource = _NhanVien;
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show(this, "Chương Trình Sẽ Cập Nhật Chức Vụ Mới Và Bộ Phận làm Việc Mới Cho Các Nhân Viên Được Quyết Định. Thực Hiện Thao Tá (Yes/No) ?", "Thông Báo",MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (DialogResult==DialogResult.Yes)
            {
                if (this.KiemtraRong())
                {
                    grdu_DSQuyetDinh.UpdateData();
                    _QDBoNhiem.ApplyEdit();
                    _QDBoNhiem.Save();
                    MessageBox.Show(this, util.luuthanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } 
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show(this, "Chương Trình Sẽ Phục Hồi Lại Bộ Phận Và Chức Vụ Cho Nhân Viên. Thực Hiện Thao Tác (Yes/No) ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (DialogResult==DialogResult.Yes)
            {
                if (grdu_DSQuyetDinh.ActiveRow != null)
                {
                    grdu_DSQuyetDinh.DeleteSelectedRows();
                }
            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Source();
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            frmQuyetDinhBoNhiem_TimQD frm_tim = new frmQuyetDinhBoNhiem_TimQD();
            if (frm_tim.ShowDialog() != DialogResult.OK)
            {
                _maQD = frm_tim._maQuyetDinh;
                this.Load_Source();
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {

        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            _QDBoNhiem = QuyetDinhBoNhiem.NewQuyetDinhBoNhiem();
            BindS_QDBoNhiem.DataSource = _QDBoNhiem;
        }

        private void grdu_DSQuyetDinh_KeyDown(object sender, KeyEventArgs e)
        {
            grdu_DSQuyetDinh.Update();
        }

        private void cmbu_NhanVien_AfterCloseUp(object sender, EventArgs e)
        {
            if (grdu_DSQuyetDinh.ActiveRow != null)
            {
                if (cmbu_NhanVien.ActiveRow != null)
                {
                    grdu_DSQuyetDinh.ActiveRow.Cells["Tennhanvien"].Value = cmbu_NhanVien.ActiveRow.Cells["TenNhanVien"].Value;
                    grdu_DSQuyetDinh.ActiveRow.Cells["maphongbancu"].Value = cmbu_NhanVien.ActiveRow.Cells["mabophan"].Value;
                    grdu_DSQuyetDinh.ActiveRow.Cells["maChucvucu"].Value = cmbu_NhanVien.ActiveRow.Cells["machucvu"].Value;
                    grdu_DSQuyetDinh.ActiveRow.Cells["Tenbophancu"].Value = cmbu_NhanVien.ActiveRow.Cells["TenBoPhan"].Value;
                    grdu_DSQuyetDinh.ActiveRow.Cells["TenChucVuCu"].Value = cmbu_NhanVien.ActiveRow.Cells["TenChucvu"].Value;
                }
            }
        }
        #endregion

        #region Process
        private bool KiemtraRong()
        {
            if (cmbu_LoaiQD.ActiveRow==null)
            {
                MessageBox.Show(this,"Chọn Loại Quyết Định Bổ Nhiệm !","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            //if (cmbu_Nguoiky.Value == null)
            //{
            //    MessageBox.Show(this, "Chọn Người Ký !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            if (txt_SoQD.Text.Trim() == "")
            {
                MessageBox.Show(this, "Nhập Số Quyết Định !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        #endregion

        private void grdu_DSQuyetDinh_Leave(object sender, EventArgs e)
        {
            grdu_DSQuyetDinh.UpdateData();
        }

    }
}